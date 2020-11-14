using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using RestSharp;
using S9API.Models;
using Newtonsoft.Json;
using System.Net;


namespace IAC2018SQL
{
	static class Program
	{
		static public RestClient ApiClient = new RestClient("http://sql-iac/Square9API"); //path to the website where the api is hosted

		public struct AmortRec
		{
			public double InterestAmount;
			public double PrincipleAmount;
			public double Balance;
		}

		private static Regex _isNumber = new Regex(@"^\d+$");
		static public FileStream fs;
		static public String GsDataPath = "",gsProgMessage = "";
		static public String gsKey = null, gsUserID = null, gsUserName = null,gsAmortProgressText = "";
		static public Boolean gbClosedPaymentEdit = false, gbClosedPaymentAdd = false,gbClosedPaymentJustSaved = false;
		static public Boolean gbOpenPaymentEdit = false, gbOpenPaymentAdd = false, gbOpenPaymentJustSaved = false;
		static public Boolean gbClosedDealerContingentEdit = false, gbClosedDealerContingentAdd = false, gbClosedDealerContingentJustSaved = false;
		static public Boolean gbOpenDealerContingentEdit = false, gbOpenDealerContingentAdd = false, gbOpenDealerContingentJustSaved = false;
		static public Object[] goOpenPaymentKeys = null, goClosedPaymentKeys = null, goClosedDealerContingentKeys = null, goOpenDealerContingentKeys = null;
		// Moses Newman 03/23/2012 Save old tab position before entering edit mode!
		static public Int32 gnClosedCustomerTab = 0, gnOpenCustomerTab = 0;
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static private int lnSub;
		static private double lnMonthlyAmountOwed = 0, lnPrincipalOwed = 0,
				   lnMonthlyInterest = 0, lnxyzNumber = 0, lnNumerator = 0,
				   lnDenominator = 0, lnAPR = 0;

		static private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
		static private System.Data.SqlClient.SqlConnection tableAdapConn = null;

		static private void ClearAllVariables()
		{
			lnSub = 0; 
			lnMonthlyAmountOwed = 0; lnPrincipalOwed = 0;
			lnMonthlyInterest = 0; lnxyzNumber = 0; lnNumerator = 0;
			lnDenominator = 0; lnAPR = 0;
		}

		static public decimal TVSimpleGetBuyout(IACDataSet tdsAmortDT,DateTime tdPayoffDate,double tnTerm,double tnAPR,double tnMonthlyAmountOwed, String tcCustomer = "99-", Boolean tbSimple = false,Boolean tbSave = false,Boolean tbEOM = true,Boolean tbPayment = false, Int32 tnPaymentPos = -1,Boolean tbCutoff = false)
		{
			// tnLoanAmount         = Original Loan Amount
			// tnTerm                = Loan term in months
			// tnAPR                = Annual percentage rate as a decimal
			// tnMonthlyAmountOwed  = Total monthly payment P&I
			// 
			IACDataSet.CUSTHISTDataTable DTPayStream = new IACDataSet.CUSTHISTDataTable();
			IACDataSet.CUSTOMERDataTable CUSTOMERDT = new IACDataSet.CUSTOMERDataTable();
            // Moses Newman 03/13/2018 add new PAYMENT DataTable and TableAdapter for multiple payment support.
            IACDataSet.PAYMENTDataTable PAYMENTDT = new IACDataSet.PAYMENTDataTable();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();

			IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
			IACDataSetTableAdapters.CUSTHISTTableAdapter  CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
			BindingSource CUSTHISTBindingSource = new BindingSource();

			if (tcCustomer == "99-")
				tcCustomer += gsUserID;

			//Define all needed variables.            
			TValueEngineLib.TValueUser user;
			TValueEngineLib.TValueCashFlowMatrix cfm;
			TValueEngineLib.TValueEvent cfmEvent;
			decimal roundingAmount;
            // Moses Newman 8/4/2013 add sequence number for customer history!
            int lnSeqNo = 0;
			DateTime roundingDate;
			object unknownValue, loSeqNo = null;
			// Create the user.
			user = new TValueEngineLib.TValueUser();
			//Test the expiration date of the Engine. If you are past
			//the expiration date you will need to get a new DLL
			//from TimeValue Software at (800)426-4741.
			DateTime expireDate = user.ExpirationDate;
			if (expireDate < DateTime.Now.Date)   // "DateTime.Now.Date" returns today's date.
			{
				MessageBox.Show("TValueEngine.dll has expired. Call TimeValue Software at (800)426-4741 to get a new TValueEngine DLL.", "TValueEngine.dll has expired.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return -99;
			}
			CUSTOMERTableAdapter.Fill(CUSTOMERDT, tcCustomer);

			// Create the Cash flow matrix.
			cfm = user.CreateCashFlowMatrix();
			if (tbSave)
				cfm.Label = CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_NO").TrimEnd() + " " + 
							CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_FIRST_NAME").TrimEnd() + " " + CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_LAST_NAME").TrimEnd();
			cfm.IncludeStdEvents = 1;
			cfm.IncludeUserLoanAndPaymentEvents = 1;

			// Set the compounding to Monthly.
            if (tbSimple)
                // Moses Newman 04/30/2017 For tbSimple flaf now do exact days for US Rule Simple Interest
                cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVExactDaysCompound;
            else
                cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVDailyCompound;
				//cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVMonthlyCompound;

			// Use a 365 day year from now on.
            //if(tbSimple)
            // Moses Newman 04/30/2017 Both daily compunding and simple use 365 year length.
                cfm.YearLength = TValueEngineLib.TVYearLength.TVYearLength365;
            //else
                // Old side used 360 day year.
                //cfm.YearLength = TValueEngineLib.TVYearLength.TVYearLength360;

			// Use Normal (compounded) compute method if NOT Simple Interest else Use US Rule Amortization
            // Moses Newman 04/30/2017 Reactivate use of US Rule Amortization if tbSimple flag set.
			if (tbSimple)
			   cfm.ComputeMethod = TValueEngineLib.TVComputeMethod.TVUSRuleAmortization;
			else
               cfm.ComputeMethod = TValueEngineLib.TVComputeMethod.TVNormalAmortization;

			//Set the interest rate.
			cfm.NominalAnnualRate = tnAPR;

			cfm.UserPaymentName1 = "PAY/ADJ";
			cfm.UserPaymentName2 = "UPD";
			if(CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_BUY_OUT") != "Y")
				cfm.UserPaymentName3 = "BUYOUT";
			else
				cfm.UserPaymentName3 = "UNEARNED";
			cfm.UserLoanName1 = "NEW";
			cfm.UserLoanName2 = "LATE/ISF FEE";
			cfm.UserLoanName3 = "INSUF";

			if (!tbCutoff)
				CUSTHISTTableAdapter.FillByPaymentsSoFar(DTPayStream, tcCustomer);
			else
				CUSTHISTTableAdapter.FillByPaymentsSoFarWithCutoff(DTPayStream, tcCustomer, tdPayoffDate);
			// If Posting Payments we must add today's payment to payment stream!
			if (tbPayment)
			{
                // Moses Newman 03/13/2018 add new temp payment datatable to take all payments (in case more than one, from customer) and loop through them.
                PAYMENTDT.Clear();
                PAYMENTTableAdapter.Fill(PAYMENTDT, tcCustomer);
                CUSTHISTBindingSource.DataSource = DTPayStream;
                // Moses Newman 03/20/2018 check against passed PAYMENT record in todays payments for that account and determine what order
                // it is in the payments for today (if more than one).  Only add up to and including that payment!
                DataRow[] result = PAYMENTDT.Select("SeqNo = " + tdsAmortDT.PAYMENT.Rows[tnPaymentPos].Field<Int32>("SeqNo").ToString().Trim());
                int lnLastRec = 0,FindRow;
                if(result.Length > 0)
                    lnLastRec = PAYMENTDT.Rows.IndexOf(result[0]);
                lnLastRec += 1;
                for (int pcnt = 0; pcnt < lnLastRec; pcnt++)
                {
					// Moses Newman 10/11/2020 if it is an INSUF don't put it in the PayStream and remove the corresponding payment from the paystream!
					if(PAYMENTDT.Rows[pcnt].Field<String>("PAYMENT_TYPE") == "I")
                    {
						FindRow = CUSTHISTBindingSource.Find("ID", PAYMENTDT.Rows[pcnt].Field<Int32>("ISFID"));
						if (FindRow > -1)
						{
							CUSTHISTBindingSource.RemoveAt(FindRow);
							CUSTHISTBindingSource.EndEdit();
						}
						continue;
					}
                    CUSTHISTBindingSource.AddNew();
                    CUSTHISTBindingSource.EndEdit();
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", tcCustomer);
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", PAYMENTDT.Rows[pcnt].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_TYPE", PAYMENTDT.Rows[pcnt].Field<String>("PAYMENT_TYPE"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_CODE", PAYMENTDT.Rows[pcnt].Field<String>("PAYMENT_CODE_2"));
                    // Moses Newman 03/22/2013 Add sequence number at Max Value so no chance of newly added payment interfereing with any other history transactions 
                    // for the same date.
                    // Moses Newman 8/4/2013 No longer use 999 as sequence number, we simply  add 1 to existing!
                    // Moses Newman 12/2/2013 Fixed overly complex after the fact payment date change on ISFs
                    loSeqNo = PAYMENTDT.Rows[pcnt].Field<Int32>("SeqNo");
                    // Moses Newman 07/13/2019 Use TVDate for reording ISNSUF's now.
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", PAYMENTDT.Rows[pcnt].Field<DateTime>("PAYMENT_DATE"));
                    if (PAYMENTDT.Rows[pcnt].Field<Decimal>("PAYMENT_AMOUNT_RCV") >= 0 || PAYMENTDT.Rows[pcnt].Field<DateTime?>("PAYMENT_ISF_DATE") == null)
                    {
                        //loSeqNo = CUSTHISTTableAdapter.SeqNoQuery(tcCustomer, PAYMENTDT.Rows[pcnt].Field<DateTime>("PAYMENT_DATE"));
                        DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("TVDate", PAYMENTDT.Rows[pcnt].Field<DateTime>("PAYMENT_DATE"));
                    }
                    else
                    {
                        //loSeqNo = CUSTHISTTableAdapter.SeqNoQuery(tcCustomer, PAYMENTDT.Rows[pcnt].Field<DateTime>("PAYMENT_ISF_DATE"));
                        // Moses Newman 07/13/2019 Use TVDate for reording ISNSUF's now.
                        //DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", PAYMENTDT.Rows[pcnt].Field<DateTime>("PAYMENT_ISF_DATE"));
                        DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("TVDate", PAYMENTDT.Rows[pcnt].Field<DateTime>("PAYMENT_ISF_DATE"));
                    } 
                    if (loSeqNo != null)
                        lnSeqNo = (Int32)loSeqNo + 1 + pcnt;
                    else 
                        lnSeqNo = 1 + pcnt;
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeqNo);
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<DateTime>>("CUSTHIST_ISF_DATE", PAYMENTDT.Rows[pcnt].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE"));
                    // Moses Newman 04/13/2018 Add ISFSeqNo, ISFPaymentType, and ISFPaymentCode.
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Int32>>("ISFSeqNo", PAYMENTDT.Rows[pcnt].Field<Nullable<Int32>>("ISFSeqNo"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("ISFPaymentType", PAYMENTDT.Rows[pcnt].Field<String>("ISFPaymentType"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("ISFPaymentCode", PAYMENTDT.Rows[pcnt].Field<String>("ISFPaymentCode"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Decimal>>("CUSTHIST_CURR_INT", PAYMENTDT.Rows[pcnt].Field<Nullable<Decimal>>("PAYMENT_CURR_INT"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Decimal>>("CUSTHIST_LATE_CHARGE_PAID", PAYMENTDT.Rows[pcnt].Field<Nullable<Decimal>>("PAYMENT_LATE_CHARGE_PAID"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Boolean>>("IsSimple", PAYMENTDT.Rows[pcnt].Field<Nullable<Boolean>>("IsSimple"));
                    // Moses Newman 04/04/2018 Add Extension Months!
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_THRU_UD", PAYMENTDT.Rows[pcnt].Field<Int32>("PAYMENT_THRU_UD"));
                    // Moses Newman 03/15/2018 Add TransactionDate, Fee, FromIVR
                    if (PAYMENTDT.Rows[pcnt].Field<Nullable<DateTime>>("TransactionDate") == null)
                        PAYMENTDT.Rows[pcnt].SetField<DateTime>("TransactionDate", PAYMENTDT.Rows[pcnt].Field<DateTime>("PAYMENT_DATE"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("TransactionDate", PAYMENTDT.Rows[pcnt].Field<DateTime>("TransactionDate"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("Fee", PAYMENTDT.Rows[pcnt].Field<Decimal>("Fee"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Boolean>("FromIVR", PAYMENTDT.Rows[pcnt].Field<Boolean>("FromIVR"));
                    //  Moses Newman 06/28/2016 add paycode to markpay call so IVR will show if IVR!
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", Program.MarkPay(CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_ACT_STAT"), PAYMENTDT.Rows[pcnt].Field<String>("PAYMENT_TYPE"), PAYMENTDT.Rows[pcnt].Field<String>("PAYMENT_CODE_2")));
                    // Moses Newman 10/17/2018 Add PaymentSeq to CUSTHIST record.
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Int32>>("PaymentSeq", PAYMENTDT.Rows[pcnt].Field<Nullable<Int32>>("SeqNo"));
                    CUSTHISTBindingSource.EndEdit();
                }
                // Moses Newman 03/13/2018 if more than one payment for the same customer tdPayoffDate needs to be the most recent payment or TValue will crash!
                tdPayoffDate = PAYMENTDT.Rows[PAYMENTDT.Rows.Count-1].Field<DateTime>("PAYMENT_DATE");
			}
            // Moses Newman 12/2/2013 Removed after the fact payment date change on ISFs
            // Now create sorted DataView of CUSTHIST DataTable (Memory Only)
            DataView SortedPayStream = new DataView(DTPayStream, "", "TVDate,CUSTHIST_PAY_DATE,CUSTHIST_DATE_SEQ", DataViewRowState.CurrentRows);
            SortedPayStream.AllowNew = true;
            IACDataSet.CUSTHISTDataTable  NewPSTR = new IACDataSet.CUSTHISTDataTable();
            CUSTHISTBindingSource.DataSource = NewPSTR;
            // Insert DataView's records into a blank temp CUSTHIST DataTable (Because code was previously source to DTPayStream (CUSTHIST DataTable Instance) and not a DataView
            // Easier than resourcing all previous code, and must be a DataTable for call to TVGetTable (write and rename Events in TVAmort SQL Server Table)
            foreach (DataRowView drv in SortedPayStream)
            {
                NewPSTR.ImportRow(drv.Row);
                CUSTHISTBindingSource.EndEdit();
            }
            SortedPayStream.Dispose(); // Don't need DataView anymore.
            DTPayStream.Clear();  
            DTPayStream = (IACDataSet.CUSTHISTDataTable)NewPSTR.Copy();  // Now put sorted records into DTPayStream
            NewPSTR.Dispose(); // No longer need temp DataTable
            CUSTHISTBindingSource.DataSource = DTPayStream;
            // Moses Newman 03/22/2013 End of ISF Date Sort Mods
			for (Int32 i = 0; i < DTPayStream.Rows.Count; i++)
			{
				if (i==0)
				{
					//Create the first cash flow line (the loan).
					//Set the loan date and amount.
					cfmEvent = cfm.CreateNewEvent(-1);//-1 = end of list.
					cfmEvent.EventType = TValueEngineLib.TVEventType.TVUserLoanEvent1;
					cfmEvent.EventAmount = CUSTOMERDT.Rows[0].Field<Decimal>("CUSTOMER_LOAN_CASH");
                    cfmEvent.EventDate = DTPayStream.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE");
                }
                else
				{
					// Create a cash flow line for ALL Payents
					cfmEvent = cfm.CreateNewEvent(-1);
					switch (DTPayStream.Rows[i].Field<String>("CUSTHIST_PAYMENT_TYPE"))
					{
						case "R":
						case "P":
						case "V":
						case "A":
						case "B":
                        // Moses Newman 07/31/2013 Added Cancelations and Waive Fees
                        case "C":
                        case "W":
                        case "E": // Moses Newman 01/29/2015 Extensions must now be able to call Amort!
							cfmEvent.EventType = TValueEngineLib.TVEventType.TVUserPaymentEvent1;
                            cfmEvent.EventAmount = DTPayStream.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV");
							break;
						case "I":
							cfmEvent.EventType = TValueEngineLib.TVEventType.TVUserLoanEvent3;
							cfmEvent.EventAmount = DTPayStream.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV") * -1;
							break;
						case "N":
							cfmEvent.EventType = TValueEngineLib.TVEventType.TVUserLoanEvent2;
							cfmEvent.EventAmount = DTPayStream.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV") * -1;
							break;
                        // Moses Newman 10/23/2013 Add support for Rate Change Events
                        case "F":
                            cfmEvent.EventType = TValueEngineLib.TVEventType.TVRateChangeEvent;
                            cfmEvent.EventRate = (Double)(DTPayStream.Rows[i].Field<Decimal>("TVRateChange")/100);
                        break;
						default:
							// Late Fee
                            if (DTPayStream.Rows[i].Field<String>("CUSTHIST_PAY_REM_1").TrimEnd() == "LATE")
                            {
                                cfmEvent.EventType = TValueEngineLib.TVEventType.TVUserLoanEvent2;
                                // Moses Newman 07/12/2013 Fix from fixed $10 late fee to customer's actual late fee!
                                cfmEvent.EventAmount = DTPayStream.Rows[i].Field<Decimal>("CUSTHIST_LATE_CHARGE");
                            }
                            else
                            {
                                // UPDATE
                                cfmEvent.EventType = TValueEngineLib.TVEventType.TVUserPaymentEvent2;
                                cfmEvent.EventAmount = DTPayStream.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV");
                            }
						    break;
					}
				}
				
                //cfmEvent.EventDate = DTPayStream.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE");
                // Moses Newman 07/13/2019 use new TVDate field for EventDate so that ISNSUF's or negative adjustments apply retroactively
                cfmEvent.EventDate = DTPayStream.Rows[i].Field<DateTime>("TVDate");

                // Moses Newman 02/10/2013 Set Payoff Date =  final payment if a paid loan
                // Moses Newman 02/26/2018 If PAID regardless of BUY_OUT flag used last transaction date for payoff date!
                if (DTPayStream.Rows[i].Field<String>("CUSTHIST_PAY_REM_1").TrimEnd() == "PAID" )//&& CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_BUY_OUT") == "Y")
                    tdPayoffDate = DTPayStream.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE");
				if(DTPayStream.Rows[i].Field<String>("CUSTHIST_PAYMENT_TYPE") != "F")
                    cfmEvent.EventNumber = 1;
			}
			
			// Create a cash flow line for the payoff date and unknown payment amount
			cfmEvent = cfm.CreateNewEvent(-1);
			cfmEvent.EventType = TValueEngineLib.TVEventType.TVUserPaymentEvent3;
            // Always use month end date for buyout amount!
            // Moses Newman 02/26/2018 If PAID regardless of BUY_OUT flag used last transaction date for payoff date!
            // Moses Newman 06/29/2018 Change PAID to PAID2 to prevent date out of sequence issues for PAIDS pn monthly update.
            if (tbEOM && CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_PAY_REM_1") != "PAID2" ) //CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_BUY_OUT") != "Y")
			{
				tdPayoffDate = Convert.ToDateTime(tdPayoffDate.Month.ToString() + "/01/" + tdPayoffDate.Year.ToString()).AddMonths(1);
				tdPayoffDate = tdPayoffDate.AddDays(-1);
			}
            // Moses Newman 07/13/2018
			if(DTPayStream.Rows.Count > 0) // Moses Newman 10/11/2020
				if (tdPayoffDate < DTPayStream.Rows[DTPayStream.Rows.Count - 1].Field<DateTime>("CUSTHIST_PAY_DATE"))
					tdPayoffDate = DTPayStream.Rows[DTPayStream.Rows.Count - 1].Field<DateTime>("CUSTHIST_PAY_DATE");
            cfmEvent.EventDate = tdPayoffDate;
			cfmEvent.EventAmount = TValueDefines.TV_UNKNOWN_AMOUNT;
			cfmEvent.EventNumber = 1;

			cfm.SuspendDateSequenceChecking = 0;
            // Moses Newman 03/22/2013 Changed due to new handling of INSUF transactions
            // Do NOT sort event anymore because they are already sorted the way we need, a call to the TValue engine's sort will put INSUF in the wrong order with the original payment!
			//cfm.Sort();   

		   cfm.RateMode = TValueEngineLib.TVRateMode.TVRateModeExtended;

			// Solve the problem. Returns the unknownValue
			// Also creates the amortization schedule.
            
			if (tbSave)
			{
				String lsPath = Program.GsDataPath + @"\TV5\" + CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_NO").TrimEnd() + 
								CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_FIRST_NAME").TrimEnd() + 
								CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_LAST_NAME").TrimEnd() + ".tv5";
				cfm.WriteToFile(lsPath, 0);
			}
			cfm.CalculateAndAmortize(out unknownValue, out roundingAmount, out roundingDate);
			tnMonthlyAmountOwed = (Double)(Decimal)unknownValue;
            // Moses Newman 8/14/2013 Add APR Info 
            Double lnAPR = 0;
            Decimal lnFinanceCharge = 0, lnAmountFinanced = 0, lnTotalofPayments = 0;
            IACDataSetTableAdapters.TVAPRInfoTableAdapter TVAPRInfoTableAdapter = new IACDataSetTableAdapters.TVAPRInfoTableAdapter();

            cfm.GetAPRInfo(out lnAPR, out lnFinanceCharge, out lnAmountFinanced, out lnTotalofPayments);
            // Moses Newman 11/15/2016 make sure apr info is there so we don't post large negative error code!
            if (lnAPR >= 0 && lnFinanceCharge >= 0 && lnAmountFinanced >= 0 && lnTotalofPayments >= 0)
            {
                // Delete old APR Info for customer if it exists
                TVAPRInfoTableAdapter.Delete(CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_NO"));
                TVAPRInfoTableAdapter.Insert(CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_NO"), (Decimal)lnAPR, lnFinanceCharge, lnAmountFinanced, lnTotalofPayments);
            }
            TVAPRInfoTableAdapter.Dispose();
            // End of new APRInfo
			TVGetAmortTable(ref cfm, DTPayStream, tcCustomer, false, false);

			DTPayStream.Dispose();
			CUSTOMERDT.Dispose();
			return (Decimal)tnMonthlyAmountOwed;
		}

		static public void TVAmortize(DateTime tdStartDate, DateTime tdFirstPaymentDate, ref double tnLoanAmount, ref double tnTerm, ref double tnAPR, ref double tnMonthlyAmountOwed, ref string tsReturnCodeMessage, ref AmortRec[] tAmortRec, Boolean MemOnly = false, String tcCustomer = "99-", Boolean tbSimple = false)
		{ 
			// tnLoanAmount         = Original Loan Amount
			// tnTerm                = Loan term in months
			// tnAPR                = Annual percentage rate as a decimal
			// tnMonthlyAmountOwed  = Total monthly payment P&I
			// 

			if(tcCustomer == "99-")
				tcCustomer += gsUserID;

			//Define all needed variables.            
			IACDataSetTableAdapters.AmortTempTableAdapter AmortTempTableAdapter = new IACDataSetTableAdapters.AmortTempTableAdapter();
			TValueEngineLib.TValueUser user;
			TValueEngineLib.TValueCashFlowMatrix cfm;
			TValueEngineLib.TValueEvent cfmEvent;
			decimal roundingAmount;
			DateTime roundingDate;
			object unknownValue;
			int index;
			TValueEngineLib.TVAmortizationLineType lineType;
			int sequenceNumber;
			DateTime eventDate;
			decimal[] dataArray;
			object varDataArray;
			double rateChangeRate; 
			TValueEngineLib.TVCompoundPeriod rateChangeCompounding;
			String lsUnKnown = "";

			// Create the user.
			user = new TValueEngineLib.TValueUser();
			//Test the expiration date of the Engine. If you are past
			//the expiration date you will need to get a new DLL
			//from TimeValue Software at (800)426-4741.
			DateTime expireDate = user.ExpirationDate;
			if (expireDate < DateTime.Now.Date)   // "DateTime.Now.Date" returns today's date.
			{
				MessageBox.Show("TValueEngine.dll has expired. Call TimeValue Software at (800)426-4741 to get a new TValueEngine DLL.", "TValueEngine.dll has expired.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			   
			// Create the Cash flow matrix.
			cfm = user.CreateCashFlowMatrix();
			cfm.IncludeAnnualTotals = 0;

			// Set the compounding to Monthly.
            // Moses Newman 04/30/2017 reinstate tbSimple and use exact days for simple interest.
			if (tbSimple)
				cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVExactDaysCompound;
			else
                cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVDailyCompound;


			// Use a 365 day year.
            // Moses Newman 04/30/2017 ALWAYS use 365 day year.
		    cfm.YearLength = TValueEngineLib.TVYearLength.TVYearLength365;
			

			// Use Normal (compounded) compute method if NOT Simple Interest else Use US Rule Amortization
            // Reinstate tbSimple flag
			if (tbSimple)
				cfm.ComputeMethod = TValueEngineLib.TVComputeMethod.TVUSRuleAmortization;
			else
			    cfm.ComputeMethod = TValueEngineLib.TVComputeMethod.TVNormalAmortization;

			//Set the interest rate.
			if(tnAPR > 0)
				cfm.NominalAnnualRate = tnAPR;
			else
			{
				cfm.NominalAnnualRate = (double)TValueDefines.TV_UNKNOWN_AMOUNT;
				lsUnKnown = "APR";
			}
			//Create the first cash flow line (the loan).
			//Set the loan date and amount.
			cfmEvent = cfm.CreateNewEvent(-1);//-1 = end of list.
			cfmEvent.EventType = TValueEngineLib.TVEventType.TVLoanEvent;
			cfmEvent.EventDate = tdStartDate;
			if(tnLoanAmount > 0)
				cfmEvent.EventAmount = (Decimal)tnLoanAmount;
			else
			{
				cfmEvent.EventAmount = TValueDefines.TV_UNKNOWN_AMOUNT;
				lsUnKnown = "LoanAmount";
			}

			// Create the second cash flow line
			cfmEvent = cfm.CreateNewEvent(-1);
			cfmEvent.EventType = TValueEngineLib.TVEventType.TVPaymentEvent;
            cfmEvent.EventDate = tdFirstPaymentDate;
			if(tnMonthlyAmountOwed > 0)
				cfmEvent.EventAmount = (Decimal)tnMonthlyAmountOwed;
			else
			{
				cfmEvent.EventAmount = TValueDefines.TV_UNKNOWN_AMOUNT;
				lsUnKnown = "Payment";
			}
			cfmEvent.EventNumber = (int)tnTerm;

			cfm.SuspendDateSequenceChecking = 1;
			cfm.Sort();

			//cfm.RateMode = TValueEngineLib.TVRateMode.TVRateModeExtended;
			
			// Solve the problem. Returns the unknownValue
			// Also creates the amortization schedule.
			cfm.CalculateAndAmortize(out unknownValue, out roundingAmount, out roundingDate);

			switch(lsUnKnown)
			{
				case "APR":
					tnAPR = (Double)unknownValue;
					break;
				case "Payment":
					tnMonthlyAmountOwed = (Double)(Decimal)unknownValue;
					break;
				case "LoanAmount":
					tnLoanAmount = (Double)(Decimal)unknownValue;
					break;
			}

            // Moses Newman 8/14/2013 Add APR Info 
            Double lnAPR = 0;
            Decimal lnFinanceCharge = 0, lnAmountFinanced = 0, lnTotalofPayments = 0;
            IACDataSetTableAdapters.TVAPRInfoTableAdapter TVAPRInfoTableAdapter = new IACDataSetTableAdapters.TVAPRInfoTableAdapter();

            cfm.GetAPRInfo(out lnAPR, out lnFinanceCharge, out lnAmountFinanced, out lnTotalofPayments);
            // Delete old APR Info for customer if it exists
            TVAPRInfoTableAdapter.Delete(tcCustomer);
                TVAPRInfoTableAdapter.Insert(tcCustomer, (Decimal)lnAPR, lnFinanceCharge, lnAmountFinanced, lnTotalofPayments);
            TVAPRInfoTableAdapter.Dispose();
            // End of new APRInfo
			// load the amortization schedule.
			AmortTempTableAdapter.DeleteByCustomer(tcCustomer);
			for (index = 0; index < tnTerm+1; index++)
			{
				// Get the next amortization line
				cfm.GetAmortizationData(index, out lineType, out sequenceNumber, out eventDate, out varDataArray, out rateChangeRate, out rateChangeCompounding);
	   
				// Get the currency values
				dataArray = (decimal[])varDataArray;
				if (lineType == TValueEngineLib.TVAmortizationLineType.TVPaymentLine || 
					lineType == TValueEngineLib.TVAmortizationLineType.TVUserPayment1Line ||
					lineType == TValueEngineLib.TVAmortizationLineType.TVUserPayment2Line ||
					lineType == TValueEngineLib.TVAmortizationLineType.TVUserPayment3Line) 
				{
						tAmortRec[index-1].InterestAmount = (Double)dataArray[TValueDefines.AmortInterestAccruedIndex];
						tAmortRec[index-1].PrincipleAmount = (Double)dataArray[TValueDefines.AmortPrincipalPaidIndex];
						tAmortRec[index-1].Balance = (Double)dataArray[TValueDefines.AmortTotalBalanceIndex];
						if (!MemOnly)
							AmortTempTableAdapter.Insert(tcCustomer,index, Convert.ToDecimal(tAmortRec[index-1].InterestAmount), Convert.ToDecimal(tAmortRec[index-1].PrincipleAmount), Convert.ToDecimal(tAmortRec[index-1].Balance),0,0,"");
				}
			}
            
            String lsPath = Program.GsDataPath + @"\TV5\" + tcCustomer + ".tv5";
            cfm.WriteToFile(lsPath, 0);
		}

		static private void TVGetAmortTable(ref TValueEngineLib.TValueCashFlowMatrix cfm,IACDataSet.CUSTHISTDataTable tdtCUSTHIST,String tcCustomer = "99",Boolean tbIncludeTotals = false,Boolean tbAmort = false)
		{
			IACDataSet.TVAmortDataTable TVAmortDT = new IACDataSet.TVAmortDataTable();
			IACDataSet.CUSTOMERDataTable CustomerDT = new IACDataSet.CUSTOMERDataTable();
			if(tcCustomer == "99-")
				tcCustomer += gsUserID;

			TValueEngineLib.TVAmortizationLineType lineType;
            int sequenceNumber, lnRowNumber = 0;
			DateTime eventDate,LeapDate;
			decimal[] dataArray;
			object varDataArray;
			double rateChangeRate;
            String lsDayDue;

			TValueEngineLib.TVCompoundPeriod rateChangeCompounding;
			IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
			IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
			TVAmortTableAdapter.DeleteByCustomerNo(tcCustomer);
			Int32 AmortIndex = 0;
			TVAmortDT.Clear();
			CUSTOMERTableAdapter.Fill(CustomerDT, tcCustomer);
			for (Int32 index = 0; index < cfm.AmortizationScheduleSize; index++)
			{
				// Get the next amortization line
				cfm.GetAmortizationData(index, out lineType,  out sequenceNumber, out eventDate, out varDataArray, out rateChangeRate, out rateChangeCompounding);

				// Get the currency values
				dataArray = (decimal[])varDataArray;

				// Put data into the dataset based on the line type
				DataRow dr;
				switch (lineType)
				{
					case TValueEngineLib.TVAmortizationLineType.TVLoanLine:
					case TValueEngineLib.TVAmortizationLineType.TVUserLoan1Line:
					case TValueEngineLib.TVAmortizationLineType.TVUserLoan2Line:
					case TValueEngineLib.TVAmortizationLineType.TVUserLoan3Line:
						// Create new DataRow objects and add to DataTable.
						dr = TVAmortDT.NewRow();
						dr["CustomerNo"] = tcCustomer;
                        lnRowNumber += 1;
                        dr["RowNumber"] = lnRowNumber;
						if (AmortIndex < tdtCUSTHIST.Rows.Count)
						{
							dr["Event"] = tdtCUSTHIST.Rows[AmortIndex].Field<String>("CUSTHIST_PAY_REM_1");
							if (tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_PAID_THRU"].ToString().Trim() != "")
							{
								if (CustomerDT.Rows[0].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_PAID_THRU"].ToString().Substring(0, 2) == "02")
								{
									LeapDate = DateTime.Parse("03/01/" + DateTime.Now.Year.ToString().Substring(0, 2) +
											   tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_PAID_THRU"].ToString().Substring(2, 2)).AddDays(-1);
									lsDayDue = LeapDate.Day.ToString().Trim().PadLeft(2, '0');
								}
								else
									lsDayDue = CustomerDT.Rows[0].Field<Int32>("CUSTOMER_DAY_DUE").ToString().Trim().PadLeft(2, '0');
								dr["PaidThrough"] = DateTime.Parse(tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_PAID_THRU"].ToString().Substring(0, 2) + '/' + lsDayDue + '/' +
													DateTime.Now.Year.ToString().Substring(0, 2) + tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_PAID_THRU"].ToString().Substring(2, 2));
							}
							switch (tdtCUSTHIST.Rows[AmortIndex].Field<String>("CUSTHIST_PAY_REM_1").TrimEnd())
							{
								case "NEW":
									dr["New"] = dataArray[TValueDefines.AmortLoan1Index];
									break;
								case "LATE":
									dr["LateFee"] = tdtCUSTHIST.Rows[AmortIndex].Field<Decimal>("CUSTHIST_LATE_CHARGE");
									break;
								case "ISFC":
									dr["ISF"] = tdtCUSTHIST.Rows[AmortIndex].Field<Decimal>("CUSTHIST_PAYMENT_RCV") * -1;
									break;
								case "INSUF":
									dr["Payment"] = dataArray[TValueDefines.AmortLoan3Index] * -1;
									// Moses Newman 04/13/2018 Add ISFDate, ISFSeqNo, ISFPaymentType, and ISFPaymentCode so that exact returned check can be found.
									dr.SetField<DateTime?>("ISFDate", tdtCUSTHIST.Rows[AmortIndex].Field<DateTime?>("CUSTHIST_ISF_DATE"));
									dr.SetField<Int32?>("ISFSeqNo", tdtCUSTHIST.Rows[AmortIndex].Field<Int32?>("ISFSeqNo"));
									dr["ISFPaymentType"] = tdtCUSTHIST.Rows[AmortIndex].Field<String>("ISFPaymentType");
									dr["ISFPaymentCode"] = tdtCUSTHIST.Rows[AmortIndex].Field<String>("ISFPaymentCode");
									break;
							}
							dr["HistorySeq"] = tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_DATE_SEQ"];
							// Moses Newman 07/25/2019 Add History Date to Amort for proper sequencing in FixLateFeesandPartialPayments
							dr["HistoryDate"] = tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_PAY_DATE"];

							// Moses Newman 10/17/2018 add PaymentSeq for lookup in posting.
							dr["PaymentSeq"] = tdtCUSTHIST.Rows[AmortIndex].Field<Int32?>("PaymentSeq") != null ? tdtCUSTHIST.Rows[AmortIndex].Field<Int32>("PaymentSeq") : 0;
							dr["PartialPayment"] = tdtCUSTHIST.Rows[AmortIndex]["PartialPayment"];
							dr["LateFeeBalance"] = tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_LATE_CHARGE_BAL"];
						}
						AmortIndex += 1; 
						dr["Date"] = eventDate;
						dr["Interest"] = dataArray[TValueDefines.AmortInterestAccruedIndex];
						dr["Principal"] = dataArray[TValueDefines.AmortPrincipalPaidIndex];
						dr["Balance"] = dataArray[TValueDefines.AmortTotalBalanceIndex];
                        dr["PaymentCode"] = "";
						TVAmortDT.Rows.Add(dr);
						break;

					case TValueEngineLib.TVAmortizationLineType.TVPaymentLine:
					case TValueEngineLib.TVAmortizationLineType.TVUserPayment1Line:
					case TValueEngineLib.TVAmortizationLineType.TVUserPayment2Line:
					case TValueEngineLib.TVAmortizationLineType.TVUserPayment3Line:
						// Create new DataRow objects and add to DataTable.
						dr = TVAmortDT.NewRow();
						dr["CustomerNo"] = tcCustomer;
                        lnRowNumber += 1;
                        dr["RowNumber"] = lnRowNumber;
						if (AmortIndex >= tdtCUSTHIST.Rows.Count)
							if(!tbAmort)
								if(CustomerDT.Rows[0].Field<String>("CUSTOMER_BUY_OUT") != "Y")
									dr["Event"] = "BUYOUT"; 
								else
									dr["Event"] = "UNEARNED";
							else
								dr["Event"] = "PAY";
						else
						{
							dr["Event"] = tdtCUSTHIST.Rows[AmortIndex].Field<String>("CUSTHIST_PAY_REM_1");
							AmortIndex += 1;
						}
							
						dr["Date"] = eventDate;
                        // Moses Newman 03/20/2018 Add History Sequence Number to amort
                        dr["HistorySeq"] = tdtCUSTHIST.Rows[AmortIndex-1]["CUSTHIST_DATE_SEQ"];
                        // Moses Newman 07/25/2019 Add History Date to Amort for proper sequencing in FixLateFeesandPartialPayments
                        dr["HistoryDate"] = tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_PAY_DATE"];
                        // Moses Newman 10/17/2018 add PaymentSeq for lookup in posting.
                        dr["PaymentSeq"] = tdtCUSTHIST.Rows[AmortIndex-1].Field<Int32?>("PaymentSeq") != null ? tdtCUSTHIST.Rows[AmortIndex-1].Field<Int32>("PaymentSeq") : 0;

                        dr["PartialPayment"] = tdtCUSTHIST.Rows[AmortIndex - 1]["PartialPayment"];
                        dr["LateFeeBalance"] = tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_LATE_CHARGE_BAL"];
                        // Moses Newman 04/03/2018 Add Payment Code to TVAmort so we know what the wave type is!
                        dr["PaymentCode"] = (String)tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_PAYMENT_TYPE"] + (String)tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_PAYMENT_CODE"];
                        if (tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_PAID_THRU"].ToString().Trim() != "")
                        {
                            if (CustomerDT.Rows[0].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_PAID_THRU"].ToString().Substring(0, 2) == "02")
                            {
                                LeapDate = DateTime.Parse("03/01/" + DateTime.Now.Year.ToString().Substring(0, 2) +
                                           tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_PAID_THRU"].ToString().Substring(2, 2)).AddDays(-1);
                                lsDayDue = LeapDate.Day.ToString().Trim().PadLeft(2, '0');
                            }
                            else
                                lsDayDue = CustomerDT.Rows[0].Field<Int32>("CUSTOMER_DAY_DUE").ToString().Trim().PadLeft(2, '0');
                            dr["PaidThrough"] = DateTime.Parse(tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_PAID_THRU"].ToString().Substring(0, 2) + '/' + lsDayDue + '/' +
                                                DateTime.Now.Year.ToString().Substring(0, 2) + tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_PAID_THRU"].ToString().Substring(2, 2));
                        }
                        // Moses Newman 03/22/2018 Add Extension Months to Amort 
                        if(dr["Event"].ToString().Trim() == "EXT")
                            dr["ExtensionMonths"] = tdtCUSTHIST.Rows[AmortIndex - 1]["CUSTHIST_THRU_UD"];
						switch(lineType)
						{
							case TValueEngineLib.TVAmortizationLineType.TVPaymentLine:
							case TValueEngineLib.TVAmortizationLineType.TVUserPayment1Line:
                                // Moses Newman 07/31/2013 Added switch to handle positng of W or C payments to Non Cash Column of TVAmort table
                                if ((AmortIndex - 1) < tdtCUSTHIST.Rows.Count && AmortIndex > 0)
                                    switch (tdtCUSTHIST.Rows[AmortIndex-1].Field<String>("CUSTHIST_PAYMENT_TYPE"))
                                    {
                                        case "W":
                                        case "C":
                                            dr["NonCash"] = dataArray[TValueDefines.AmortPayment1Index];
                                            break;
                                        default:
                                            dr["Payment"] = dataArray[TValueDefines.AmortPayment1Index];
                                            break;
                                    }
                                else
                                    dr["Payment"] = dataArray[TValueDefines.AmortPayment1Index];
								    break;
							case TValueEngineLib.TVAmortizationLineType.TVUserPayment2Line:
								dr["Payment"] = dataArray[TValueDefines.AmortPayment2Index];
								break;
							case TValueEngineLib.TVAmortizationLineType.TVUserPayment3Line:
								dr["Payment"] = dataArray[TValueDefines.AmortPayment3Index];
								break;                
						}
                        if ((Decimal)dr["Payment"] < 0 && (AmortIndex - 1) < tdtCUSTHIST.Rows.Count && AmortIndex > 0 &&
                            tdtCUSTHIST.Rows[AmortIndex - 1].Field<String>("CUSTHIST_PAYMENT_TYPE") != "W")
                        {
                            // Moses Newman 04/13/2018 Add ISFDate, ISFSeqNo, ISFPaymentType, and ISFPaymentCode so that exact returned check can be found.
                            dr.SetField<DateTime?>("ISFDate", tdtCUSTHIST.Rows[AmortIndex-1].Field<DateTime?>("CUSTHIST_ISF_DATE"));
                            dr.SetField<Int32?>("ISFSeqNo", tdtCUSTHIST.Rows[AmortIndex-1].Field<Int32?>("ISFSeqNo"));
                            dr["ISFPaymentType"] = tdtCUSTHIST.Rows[AmortIndex-1].Field<String>("ISFPaymentType");
                            dr["ISFPaymentCode"] = tdtCUSTHIST.Rows[AmortIndex-1].Field<String>("ISFPaymentCode");
                        }
						dr["Interest"] = dataArray[TValueDefines.AmortInterestAccruedIndex];
						dr["Principal"] = dataArray[TValueDefines.AmortPrincipalPaidIndex];
						dr["Balance"] = dataArray[TValueDefines.AmortTotalBalanceIndex];
						TVAmortDT.Rows.Add(dr);
						break;

                    // Moses Newman 10/23/2013 Add support for Rate Change Events
                    case TValueEngineLib.TVAmortizationLineType.TVRateChangeLine:
                            // Create new DataRow objects and add to DataTable.
                            dr = TVAmortDT.NewRow();
                            dr["CustomerNo"] = tcCustomer;
                            lnRowNumber += 1;
                            dr["RowNumber"] = lnRowNumber;
                            dr["Event"] = tdtCUSTHIST.Rows[AmortIndex].Field<String>("CUSTHIST_PAY_REM_1");
                            dr["Date"] = eventDate;
                            dr["Payment"] = 0;
                            dr["Interest"] = dataArray[TValueDefines.AmortInterestAccruedIndex];
                            dr["Principal"] = dataArray[TValueDefines.AmortPrincipalPaidIndex];
                            dr["RateChange"] = (Decimal)(rateChangeRate * 100);
                            dr["Balance"] = dataArray[TValueDefines.AmortTotalBalanceIndex];
                            dr["HistorySeq"] = tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_DATE_SEQ"];
                            // Moses Newman 07/25/2019 Add History Date to Amort for proper sequencing in FixLateFeesandPartialPayments
                            dr["HistoryDate"] = tdtCUSTHIST.Rows[AmortIndex]["CUSTHIST_PAY_DATE"];

                            AmortIndex += 1;
                            TVAmortDT.Rows.Add(dr);
                            break;

					case TValueEngineLib.TVAmortizationLineType.TVAnnualTotalLine:
						if (tbIncludeTotals)
						{
							// Create new DataRow objects and add to DataTable.
							dr = TVAmortDT.NewRow();
							dr["CustomerNo"] = tcCustomer;
                            lnRowNumber += 1;
							dr["RowNumber"] = lnRowNumber;
							dr["Event"] = sequenceNumber.ToString() + " Totals";
							dr["Date"] = eventDate;
							dr["Payment"] = dataArray[TValueDefines.AmortPayment1Index];
							dr["Interest"] = dataArray[TValueDefines.AmortInterestAccruedIndex];
							dr["Principal"] = dataArray[TValueDefines.AmortPrincipalPaidIndex];
							dr["Balance"] = 0;
							TVAmortDT.Rows.Add(dr);
						}
						break;

					case TValueEngineLib.TVAmortizationLineType.TVGrandTotalLine:
						if (tbIncludeTotals)
						{
							// Create new DataRow objects and add to DataTable.
							dr = TVAmortDT.NewRow();
							dr["CustomerNo"] = tcCustomer;
                            lnRowNumber += 1;
							dr["RowNumber"] = lnRowNumber;
							dr["Date"] = eventDate;
							dr["Event"] = "Grand Totals";
							dr["Payment"] = dataArray[TValueDefines.AmortPayment1Index];
							dr["Interest"] = dataArray[TValueDefines.AmortInterestAccruedIndex];
							dr["Principal"] = dataArray[TValueDefines.AmortPrincipalPaidIndex];
							dr["Balance"] = 0;
							TVAmortDT.Rows.Add(dr);
						}
						break;
				}
			}
			TVAmortTableAdapter.Update(TVAmortDT);
			TVAmortTableAdapter.Dispose();
			TVAmortDT.Dispose();
		}

		static public String amortize(ref double tnLoanAmount, ref double tnTerm, ref double tnAPR, ref double tnMonthlyAmountOwed,ref string tsReturnCodeMessage,ref AmortRec[] tAmortRec,Boolean MemOnly = false,String tcCustomer = "99-")
		// tnLoanAmount         = Original Loan Amount
		// tnTem                = Loan term in months
		// tnAPR                = Annual percentage rate as a decimal
		// tnMonthlyAmountOwed  = Total monthly payment P&I
		// 
		{
			ClearAllVariables();
			if (tcCustomer == "99-")
				tcCustomer += gsUserID;

			lnAPR = tnAPR;
			if (tnLoanAmount < 0)
				return "EInvalid loan amount";
			if (tnTerm < 0)
				return "EInvalid term";
			if (tnMonthlyAmountOwed > 0 && tnAPR == 0)
			{
				lnMonthlyAmountOwed = tnMonthlyAmountOwed;
				CalculateAPR(tnLoanAmount, tnTerm);
				tnAPR = lnAPR;
				if (lnMonthlyInterest <= .001 || tnAPR <= .012)
					return "EPayment too low for this loan!";
				if (lnMonthlyInterest >= .04 || tnAPR >= .48)
					return "EPayment too high for this loan!";
			}
			lnMonthlyInterest = Math.Round(tnAPR / 12, 8);
			CalculateMonthlyAmountOwed(tnLoanAmount, tnTerm);
			loadAmortizationTable(tnLoanAmount, tnTerm, tnAPR,ref tAmortRec,MemOnly,tcCustomer);
			
			tnMonthlyAmountOwed = lnMonthlyAmountOwed;
			return tsReturnCodeMessage;
		}

		static private void loadAmortizationTable(double tnLoanAmount, double tnTerm, double tnAPR, ref AmortRec[] AmortTable,Boolean MemOnly = false,String tcCustomer = "99-")
		{
			if(tcCustomer == "99-")
				tcCustomer += gsUserID;
			lnSub = Convert.ToInt32(tnTerm);

			IACDataSetTableAdapters.AmortTempTableAdapter AmortTempTableAdapter = new IACDataSetTableAdapters.AmortTempTableAdapter();

			lnMonthlyInterest = Math.Round(tnAPR / 12, 8);
			lnPrincipalOwed = tnLoanAmount;

			AmortTempTableAdapter.DeleteByCustomer(tcCustomer);
			for (lnSub = 0; ((lnSub < tnTerm) && (lnSub < 1000));lnSub++)
			{
				AmortTable[lnSub].InterestAmount    = Math.Round(lnPrincipalOwed * lnMonthlyInterest, 2);
				AmortTable[lnSub].PrincipleAmount   = Math.Round(lnMonthlyAmountOwed - AmortTable[lnSub].InterestAmount,2);
				lnPrincipalOwed                     = lnPrincipalOwed - AmortTable[lnSub].PrincipleAmount;
				AmortTable[lnSub].Balance           = Math.Round(lnPrincipalOwed,2);

				if (lnSub == tnTerm - 1)
					if (AmortTable[lnSub].Balance != 0)
					{
						AmortTable[lnSub].InterestAmount -= AmortTable[lnSub].Balance;
						AmortTable[lnSub].PrincipleAmount = Math.Round(lnMonthlyAmountOwed - AmortTable[lnSub].InterestAmount,2);
						AmortTable[lnSub].Balance = 0;
					}
				if (!MemOnly)
					AmortTempTableAdapter.Insert(tcCustomer,lnSub + 1, Convert.ToDecimal(AmortTable[lnSub].InterestAmount), Convert.ToDecimal(AmortTable[lnSub].PrincipleAmount), Convert.ToDecimal(AmortTable[lnSub].Balance),0,0,"");
			}
		}


		static private void CalculateMonthlyAmountOwed(double tnLoanAmount, Double tnTerm)
		{
			if (lnMonthlyInterest == 0)
				lnMonthlyAmountOwed = Math.Round(tnLoanAmount / tnTerm, 2);
			else
			{
				lnxyzNumber   = Math.Round(Math.Pow((1 + lnMonthlyInterest), tnTerm), 8);
				lnNumerator   = Math.Round(lnMonthlyInterest * lnxyzNumber,8);
				lnDenominator = lnxyzNumber - 1;
				lnMonthlyAmountOwed = Math.Round(tnLoanAmount * (lnNumerator / lnDenominator),2);
			}
		}

		static private double MKCalcInterest(double NumPay, double Payment, double NPV, double FV,int bStart)
		{
			// Start with an arbitrary 1% Interest rate
			double IntRate = 1.00 / 1200.00;
			NPV *= (-1);
			double iPer = Math.Log10((Payment + Payment * IntRate * bStart - FV * IntRate) /
						  (NPV * IntRate + Payment + Payment * IntRate * bStart)) /
						  Math.Log10(1 + IntRate);

			if (iPer > NumPay)
			{
				while (iPer > NumPay)
				{
					IntRate -= 0.000001;
					iPer = Math.Log10((Payment + Payment * IntRate * bStart - FV * IntRate) /
							   (NPV * IntRate + Payment + Payment * IntRate * bStart)) /
						   Math.Log10(1 + IntRate);
				}
			}
			else
			{
				while (iPer < NumPay)
				{
					IntRate += 0.000001;
					iPer = Math.Log10((Payment + Payment * IntRate * bStart - FV * IntRate) /
							   (NPV * IntRate + Payment + Payment * IntRate * bStart)) /
						   Math.Log10(1 + IntRate);
				}
			}
			lnMonthlyInterest = IntRate;
			return Math.Round(IntRate * 1200.00,2)/100;
		}


		static private void CalculateAPR(double tnLoanAmount, Double tnTerm)
		{
			lnAPR = MKCalcInterest(tnTerm, lnMonthlyAmountOwed, tnLoanAmount, 0, 0);
			 if (lnMonthlyInterest > .04 || lnMonthlyInterest < .001)
				lnAPR = 0;
		}

		
		static public string IAC_NumDatetoString(string tcDOB)
		{
			string lDOBYY, lDOBMM, lDOBDD;
			if (tcDOB.TrimEnd() == "0")
				return "";
			else
				if (tcDOB.Length > 5)
				{
					lDOBYY = tcDOB.Substring(tcDOB.Length - 4, 4);
					lDOBMM = tcDOB.Substring(tcDOB.Length - 6, 6);
					lDOBMM = lDOBMM.Substring(0, 2);
					lDOBDD = (tcDOB.Length == 7) ? tcDOB.Substring(0, 1).PadLeft(2, '0') : tcDOB.Substring(0, 2);
					return (lDOBDD + lDOBMM + lDOBYY);
				}
				else
					return tcDOB;
		}


		// Closed end New Customer Posting Routines
		static public void NewClosedCustomerPosting(ref BackgroundWorker worker)
		{
			int lnREAD = 0;
			Decimal lnTotalCustomerDealerDisc = 0, lnMasterInterest = 0;
			IACDataSet CustomerPostDataSet = new IACDataSet();
			IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
			IACDataSetTableAdapters.CUSTHISTTableAdapter CustomerHistTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();

			ClearAllVariables();
			CustomerTableAdapter.FillByNonPosted(CustomerPostDataSet.CUSTOMER);
			if (CustomerPostDataSet.CUSTOMER.Rows.Count == 0)
			{
				MessageBox.Show("No new customers to post!", "New Customer Posting Error");
				return;
			}
			MailMergeComponents MailMerge = new MailMergeComponents();

			MailMerge.CreateMailMerge(CustomerPostDataSet);
            // Mose 02/14/2018 add envelopes to new business
            MailMerge.CreateMailMerge(CustomerPostDataSet,false,"","S",false,"","",true);

			lnREAD = CustomerPostDataSet.CUSTOMER.Rows.Count;
			ProcessClosedCustomer(ref CustomerPostDataSet,ref CustomerTableAdapter,ref CustomerHistTableAdapter, ref lnTotalCustomerDealerDisc, ref lnMasterInterest,ref worker);
		}

		
		static public void ProcessClosedCustomer(ref IACDataSet CustomerPostDataSet, 
										   ref IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter, 
										   ref IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter, ref Decimal lnTotalCustomerDealerDisc,
										   ref Decimal lnMasterInterest,ref BackgroundWorker worker)
		{
			IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
			IACDataSetTableAdapters.AMORTIZETableAdapter AMORTIZETableAdapter = new IACDataSetTableAdapters.AMORTIZETableAdapter();
			IACDataSetTableAdapters.WSDEALERTableAdapter WS_DEALERTableAdapter = new IACDataSetTableAdapters.WSDEALERTableAdapter();
			IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
			IACDataSetTableAdapters.DEALHISTTableAdapter DEALHISTTableAdapter = new IACDataSetTableAdapters.DEALHISTTableAdapter();
			IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
			IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
            // Moses Newman 12/12/2014
            // Add TVAmortTableAdapter.PaidThrough instead of CUSTOMERTableAdapter.GetPaidThrough
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
			IACDataSet.ACCOUNTDataTable ACCOUNT = new IACDataSet.ACCOUNTDataTable();
			IACDataSet.AMORTIZEDataTable AMORTIZE = new IACDataSet.AMORTIZEDataTable();
			IACDataSet.DEALERDataTable DEALER = new IACDataSet.DEALERDataTable();
			IACDataSet.DEALHISTDataTable DEALHIST = new IACDataSet.DEALHISTDataTable();
			IACDataSet.MASTERDataTable MASTER = new IACDataSet.MASTERDataTable();
			IACDataSet.MASTHISTDataTable MASTHIST = new IACDataSet.MASTHISTDataTable();
			IACDataSet.WS_DEALERDataTable WS_DEALER = new IACDataSet.WS_DEALERDataTable();

			BindingSource DealerBindingSource = new BindingSource();
			BindingSource DealhistBindingSource = new BindingSource();
			BindingSource CustomerBindingSource = new BindingSource();
			BindingSource CusthistBindingSource = new BindingSource();
			BindingSource MasterBindingSource = new BindingSource();
			BindingSource MasthistBindingSource = new BindingSource();

			DealerBindingSource.DataSource = DEALER;
			DealhistBindingSource.DataSource = DEALHIST;
			CustomerBindingSource.DataSource = CustomerPostDataSet.CUSTOMER;
			CusthistBindingSource.DataSource = CustomerPostDataSet.CUSTHIST;
			MasterBindingSource.DataSource = MASTER;
			MasthistBindingSource.DataSource = MASTHIST;


			int lnSeq = 0;
			Decimal lnInitialPrepayPenalty = 25,lnBuyout=0,lnMasterOLoan = 0;
			String lsAmortMessage = "", lsMasterKey = "";
			Double lnLoanAmount = 0,lnAPR = 0,lnRegularAmount = 0,lnTerm = 0;
			Object loDealhistSeq = null, loMastHistSeq = null, loMasterKey = null, loCustHistSeq = null;

			AmortRec[] AmortTable;

			tableAdapConn = new System.Data.SqlClient.SqlConnection();
			tableAdapConn.ConnectionString = IAC2018SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
			tableAdapConn.Open();

			CUSTOMERTableAdapter.Connection = tableAdapConn;
			tableAdapTran = CUSTOMERTableAdapter.BeginTransaction();

			DEALERTableAdapter.Connection = tableAdapConn;
			DEALHISTTableAdapter.Connection = tableAdapConn;
			CUSTHISTTableAdapter.Connection = tableAdapConn;
			AMORTIZETableAdapter.Connection = tableAdapConn;
			MASTERTableAdapter.Connection = tableAdapConn;
			MASTHISTTableAdapter.Connection = tableAdapConn;
			WS_DEALERTableAdapter.Connection = tableAdapConn;
			WS_DEALERTableAdapter.Transaction = tableAdapTran;
			WS_DEALERTableAdapter.Fill(WS_DEALER);
            Object loPaidThru = null;
            String lsPaidThru = "";
			for (int i = 0; i < CustomerPostDataSet.CUSTOMER.Rows.Count; i++)
			{
                // Moses Newman 12/19/2013 No need to set CUSTOMER_PAID_THRU_MM or CUSTOMER_PAID_THRU_YY as they are now computed fields!
                // Moses Newman 05/30/2014 Add call to ClosedCustomerPaidThrough to get correct paid thru
                // Moses Newman 12/12/2014 Change CUSTOMERTableAdapter.GetPaidThrough to TVAmortTableAdapter.PaidThrough!
                loPaidThru = TVAmortTableAdapter.PaidThrough(CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                if(loPaidThru != null)
                    lsPaidThru = (String)loPaidThru;
                else
                    lsPaidThru = "    ";
                CustomerPostDataSet.CUSTOMER.Rows[i].SetField<String>("CUSTOMER_PAID_THRU",lsPaidThru);
                CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_HIGHEST_BALANCE_DUE", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_LAST_PAYMENT_MADE", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Nullable<DateTime>>("CUSTOMER_HIGHEST_BALANCE_DUE", null);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_PAID_INTEREST", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_PAID_DISCOUNT", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_PT_UPDATE", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_CREDIT_AVAILABLE", 0);
                // Moses Newman 04/26/2013 Simple Interest do NOT Pre-Calculate Interest!
                // Moses Newman 03/21/2014 do not clear out estimate of Loan Interest anymore!
                /*
                if (CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "S")
                    CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_LOAN_INTEREST", (Decimal)0.00);*/
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_UE_INTEREST", 0);
				// Moses Newman 01/17/2013 Simple Interest No More Precalculated Interest!!!
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_BALANCE", CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_CASH"));
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_PREV_BALANCE", CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_CASH"));
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Int32>("CUSTOMER_PAY_REM_2", CustomerPostDataSet.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM"));
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Int32>("CUSTOMER_UPD_COUNT", 0);
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<String>("CUSTOMER_CONTROL_MONTH", DateTime.Now.Date.Month.ToString().PadLeft(2, '0'));
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<String>("CUSTOMER_CONTROL_YEAR", DateTime.Now.Date.Year.ToString().Substring(2, 2));
				if (CustomerPostDataSet.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_CREDIT_LIMIT") <= 0)
					CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Int32>("CUSTOMER_CREDIT_LIMIT", (Int32)(CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_AMOUNT")));
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<String>("CUSTOMER_POST_IND", "D");
				lnBuyout = CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_CASH") + lnInitialPrepayPenalty;
				CustomerPostDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_BUYOUT", lnBuyout);
				CustomerBindingSource.EndEdit();
				CUSTHISTTableAdapter.Transaction = tableAdapTran;
				loCustHistSeq = CUSTHISTTableAdapter.SeqNoQuery(CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), DateTime.Now.Date);
				if (loCustHistSeq != null)
					lnSeq = (int)loCustHistSeq + 1;
				else
					lnSeq = 1;
				CusthistBindingSource.AddNew();
				CusthistBindingSource.EndEdit();
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<String>("CUSTHIST_NO", CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<String>("CUSTHIST_ADD_ON", CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ADD_ON"));
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<String>("CUSTHIST_IAC_TYPE", CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_IAC_TYPE"));
                // Moses Newman 01/20/2015 Set the date of the NEW hostory record = to the new Contract Date field!
                if (CustomerPostDataSet.CUSTOMER.Rows[i].Field<Nullable<DateTime>>("ContractDate") == null)
                    CustomerPostDataSet.CUSTOMER.Rows[i].SetField<DateTime>("ContractDate", DateTime.Now.Date);
                CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", CustomerPostDataSet.CUSTOMER.Rows[i].Field<DateTime>("ContractDate"));
                CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
                // Moses Newman 03/15/2018 added TransactionDate, Fee, FromIVR
                CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<DateTime>("TransactionDate", DateTime.Now.Date);  // Moses Newman 03/14/2019 todays date instead of contract date!
                CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("Fee", 0);
                CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Boolean>("FromIVR", false);
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", 0);
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", 0);
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_DISCOUNT", 0);
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", 0);
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", 0);
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ACT_STAT"));
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("CUSTHIST_BUYOUT", CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BUYOUT"));
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PAID_THRU"));
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Int32>("CUSTHIST_PAY_REM_2", CustomerPostDataSet.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_PAY_REM_2"));
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
				CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "NEW");
				if (CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_DEALER_DISC") > 0)
					lnTotalCustomerDealerDisc += CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_DEALER_DISC");
				lnMasterInterest += CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_INTEREST");
				CUSTOMERTableAdapter.Transaction = tableAdapTran;
				CUSTHISTTableAdapter.Transaction = tableAdapTran;
                // Moses Newman 04/30/2017 Add Handling of "N" for Normal Daily Compounding
				if (CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "Y" ||
					CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "S" ||
                    CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "N")
				{
					lnLoanAmount = Convert.ToDouble(CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_CASH"));
					lnTerm = Convert.ToDouble(CustomerPostDataSet.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM"));
					lnAPR = Convert.ToDouble(CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE"));
					lnAPR = lnAPR / 100;
					//lnMonthlyAmountOwed = Convert.ToDouble(CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                    if (lnAPR != 0)
                        lnRegularAmount = 0;
                    else
                        lnRegularAmount = (Double)CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT");
					AmortTable = new AmortRec[CustomerPostDataSet.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM")];
                    // Moses Newman 01/21/2015 Add Contract Date handling!
                    TVAmortize(CustomerPostDataSet.CUSTOMER.Rows[i].Field<DateTime>("ContractDate").Date,CustomerPostDataSet.CUSTOMER.Rows[i].Field<DateTime>("CUSTOMER_INIT_DATE").Date, ref lnLoanAmount, ref lnTerm, ref lnAPR, ref lnRegularAmount, ref lsAmortMessage, ref AmortTable, true);
					lnAPR = lnAPR * 100;
					AMORTIZETableAdapter.Transaction = tableAdapTran;
				}
				CustomerBindingSource.EndEdit();
				CusthistBindingSource.EndEdit();
				try
				{
					CUSTOMERTableAdapter.Update(CustomerPostDataSet.CUSTOMER.Rows[i]);
					CUSTHISTTableAdapter.Update(CustomerPostDataSet.CUSTHIST.Rows[CusthistBindingSource.Position]);
                    // Moses Newman 04/30/2017 add handling of N form Normal Daily Compounding
					if (CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "Y" ||
						CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "S" ||
                        CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "N")
					{
						AMORTIZETableAdapter.Insert(CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
													CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ADD_ON"),
													CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_IAC_TYPE"),
													CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_CASH"),
													CustomerPostDataSet.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM"),
													CustomerPostDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE"),
													(Decimal)lnRegularAmount, 0, 0, 0, 0, 0, 0);
					}
					tableAdapTran.Commit();
				}
				catch (System.Data.SqlClient.SqlException ex)
				{
					tableAdapTran.Rollback();
					MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
				}
				catch (System.InvalidOperationException ex)
				{
					tableAdapTran.Rollback();
					MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
				}
				catch (Exception ex)
				{
					tableAdapTran.Rollback();
					MessageBox.Show("General Exception Error: " + ex.Message.ToString());
				}
				finally
				{
					worker.ReportProgress(30);
				}
				tableAdapTran = CUSTOMERTableAdapter.BeginTransaction();
		}
			for (Int32 dlrCount = 0; dlrCount < WS_DEALER.Rows.Count; dlrCount++)
			{
                tableAdapTran.Dispose();
                tableAdapTran = DEALERTableAdapter.BeginTransaction();
                DEALERTableAdapter.Transaction = tableAdapTran;
                DEALHISTTableAdapter.Transaction = tableAdapTran;
                DEALERTableAdapter.Fill(DEALER, WS_DEALER[dlrCount].Field<String>("KEY").ToString());
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_RSV", 0);
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_CONT", 0);
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_ADJ", 0);
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_BAD", 0);
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_LOSS", 0);
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLOAN", WS_DEALER.Rows[dlrCount].Field<Decimal>("OS_L"));
                DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLOAN", DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_OLOAN") != null ? DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN") + WS_DEALER.Rows[dlrCount].Field<Decimal>("OS_L") : WS_DEALER.Rows[dlrCount].Field<Decimal>("OS_L"));
				DEALER.Rows[0].SetField<DateTime>("DEALER_POST_DATE", DateTime.Now.Date);
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_AMORT_INT", WS_DEALER.Rows[dlrCount].Field<Decimal>("AMORT_INT"));
                DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_AMORT_INT", DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_AMORT_INT") != null ? DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_INT") + WS_DEALER.Rows[dlrCount].Field<Decimal>("AMORT_INT") : WS_DEALER.Rows[dlrCount].Field<Decimal>("AMORT_INT"));
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_SIMPLE_INT", WS_DEALER.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                if(DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_SIMPLE_INT") != null)
				    DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_SIMPLE_INT", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_SIMPLE_INT") + WS_DEALER.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                else
                    DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_SIMPLE_INT", WS_DEALER.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                if (DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_SIMPLE_PDI") == null)
                    DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_SIMPLE_PDI", 0);
                DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLD_INT", WS_DEALER.Rows[dlrCount].Field<Decimal>("OLD_INT"));
                DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLD_INT", DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_OLD_INT") != null ? DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_INT") + WS_DEALER.Rows[dlrCount].Field<Decimal>("OLD_INT") : WS_DEALER.Rows[dlrCount].Field<Decimal>("OLD_INT"));
                DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_AMORT_PDI", 0);
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_SIMPLE_PDI", 0);
				DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLD_PDI", 0);
				lnMasterOLoan += WS_DEALER.Rows[dlrCount].Field<Decimal>("OS_L");
				loDealhistSeq = DEALHISTTableAdapter.SeqNoQuery(WS_DEALER.Rows[dlrCount].Field<String>("KEY").ToString(), DateTime.Now.Date, DateTime.Now.Date);
				if (loDealhistSeq != null)
					lnSeq = (int)loDealhistSeq + 1;
				else
					lnSeq = 1;
				DealerBindingSource.EndEdit();
				DealhistBindingSource.AddNew();
				DealhistBindingSource.EndEdit();
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<String>("DEALHIST_ACC_NO", DEALER.Rows[0].Field<String>("DEALER_ACC_NO"));
                // Moses Newman  08/3/2013 have to limit DEALHIST_NAME TO 25 Charaters if ther are single quotes because they require padding with aditional quotes
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<String>("DEALHIST_NAME", Left(DEALER.Rows[0].Field<String>("DEALER_NAME").Replace("\'", "\'\'"),25));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_RSV", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_RSV"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_CONT", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_CONT"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLOAN", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLOAN"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_ADJ", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_ADJ"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_BAD", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_BAD"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_LOSS", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_LOSS"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_RSV", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_RSV"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_CONT", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_CONT"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLOAN", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_ADJ", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_ADJ"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_BAD", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_BAD"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_LOSS", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_LOSS"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<DateTime>("DEALHIST_POST_DATE", DateTime.Now.Date);
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<DateTime>("DEALHIST_LAST_POST_DATE", DateTime.Now.Date);
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<String>("DEALHIST_POST_CODE", "N");
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_AMORT_INT", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_AMORT_INT"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_AMORT_PDI", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_AMORT_PDI"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_AMORT_INT", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_INT"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_AMORT_PDI", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_PDI"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_SIMPLE_INT", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_SIMPLE_INT"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_SIMPLE_PDI", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_SIMPLE_PDI"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_SIMPLE_INT", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_SIMPLE_INT"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_SIMPLE_PDI", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_SIMPLE_PDI"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLD_INT", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLD_INT"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLD_PDI", DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLD_PDI"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLD_INT", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_INT"));
				DEALHIST.Rows[DealhistBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLD_PDI", DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_PDI"));
				DealhistBindingSource.EndEdit();
				DEALHISTTableAdapter.Transaction = tableAdapTran;
				try
				{
					DEALERTableAdapter.Update(DEALER.Rows[0]);
					DEALHISTTableAdapter.Update(DEALHIST.Rows[DealhistBindingSource.Position]);
					tableAdapTran.Commit();
				}
				catch (System.Data.SqlClient.SqlException ex)
				{
					tableAdapTran.Rollback();
					MessageBox.Show(ex.Message.ToString());
				}
				catch (System.InvalidOperationException ex)
				{
					tableAdapTran.Rollback();
					MessageBox.Show("Error: " + ex.Message.ToString());
				}
				finally
				{
					worker.ReportProgress(60);
				}
			}
			tableAdapTran.Dispose();
			lnMasterInterest += lnTotalCustomerDealerDisc;
            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;

			MASTERTableAdapter.Fill(MASTER, lsMasterKey.TrimEnd()); 
			MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
			MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
			MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
			MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
			MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
			MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", lnMasterOLoan);
			MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_OLOAN", MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN") + lnMasterOLoan);
			MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
			MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
			MASTER.Rows[0].SetField<Decimal>("MASTER_SIMPLE_CUR_OLOAN", lnMasterOLoan);
            if(MASTER.Rows[0].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_OLOAN") != null)
			    MASTER.Rows[0].SetField<Decimal>("MASTER_SIMPLE_YTD_OLOAN", MASTER.Rows[0].Field<Decimal>("MASTER_SIMPLE_YTD_OLOAN") + lnMasterOLoan);
            else
                MASTER.Rows[0].SetField<Decimal>("MASTER_SIMPLE_YTD_OLOAN", lnMasterOLoan);
			MasterBindingSource.EndEdit();
			MasthistBindingSource.AddNew();
			MasthistBindingSource.EndEdit();
			loMastHistSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey.TrimEnd(), DateTime.Now.Date);
			if (loMastHistSeq != null)
				lnSeq = (int)loMastHistSeq + 1;
			else
				lnSeq = 1;
            MASTHIST.Rows[MasthistBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
			MASTHIST.Rows[MasthistBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", DateTime.Now.Date);
			MASTHIST.Rows[MasthistBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
            MASTHIST.Rows[MasthistBindingSource.Position].SetField<String>("MASTHIST_NAME", MASTER.Rows[0].Field<String>("MASTER_NAME"));
			MASTHIST.Rows[MasthistBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_OLOAN", MASTER.Rows[0].Field<Decimal>("MASTER_CUR_OLOAN"));
			MASTHIST.Rows[MasthistBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_OLOAN", MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN"));
			MASTHIST.Rows[MasthistBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_NOTES", MASTER.Rows[0].Field<Decimal>("MASTER_CUR_NOTES"));
			MASTHIST.Rows[MasthistBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_NOTES", MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES"));
			MASTHIST.Rows[MasthistBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
			MasthistBindingSource.EndEdit();            
			tableAdapTran = MASTERTableAdapter.BeginTransaction();
			MASTHISTTableAdapter.Transaction = tableAdapTran;
            MASTERTableAdapter.Transaction = tableAdapTran;
			try
			{
				MASTERTableAdapter.Update(MASTER.Rows[0]);
				MASTHISTTableAdapter.Update(MASTHIST.Rows[MasthistBindingSource.Position]);
                tableAdapTran.Commit();
			}
			catch (System.Data.SqlClient.SqlException ex)
			{
				tableAdapTran.Rollback();
				MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
			}
			catch (System.InvalidOperationException ex)
			{
				tableAdapTran.Rollback();
				MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
			}
			catch (Exception ex)
			{
				tableAdapTran.Rollback();
				MessageBox.Show("General Exception Error: " + ex.Message.ToString());
			}
			finally
			{
				worker.ReportProgress(100);
			}
			// Moses Newman 01/17/2013 Not posting Interest on New Business any more!  Will post interest at monthly Update Per Paul!
			tableAdapConn.Close();
			tableAdapConn = null;
			tableAdapTran = null;
		}
		// End of Closed End New Customer Posting Routines


		// Open End New Customer Posting Routines
		static public void NewOpenCustomerPosting(ref BackgroundWorker worker)
		{
			int lnREAD = 0;
			Decimal lnTotalCustomerDealerDisc = 0, lnMasterInterest = 0;

			IACDataSet CustomerPostDataSet = new IACDataSet();
			IACDataSetTableAdapters.OPNCUSTTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
			IACDataSetTableAdapters.OPNHCUSTTableAdapter CustomerHistTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();

			ClearAllVariables();
			CustomerTableAdapter.FillByNonPosted(CustomerPostDataSet.OPNCUST);
			if (CustomerPostDataSet.OPNCUST.Rows.Count == 0)
			{
				MessageBox.Show("No new customers to post!", "New Customer Posting Error");
				return;
			}
			lnREAD = CustomerPostDataSet.OPNCUST.Rows.Count;
			ProcessOpenCustomer(CustomerPostDataSet, ref lnTotalCustomerDealerDisc, ref lnMasterInterest, ref worker);

		}

		static public void ProcessOpenCustomer(IACDataSet CustomerPostDataSet, ref Decimal lnTotalCustomerDealerDisc,
								   ref Decimal lnMasterInterest, ref BackgroundWorker worker)
		{
			IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
			IACDataSetTableAdapters.OPNCUSTTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
			IACDataSetTableAdapters.OPNHCUSTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
			IACDataSetTableAdapters.OPNWSDEALERTableAdapter WS_DEALERTableAdapter = new IACDataSetTableAdapters.OPNWSDEALERTableAdapter();
			IACDataSetTableAdapters.OPNDEALRTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
			IACDataSetTableAdapters.OPNHDEALTableAdapter DEALHISTTableAdapter = new IACDataSetTableAdapters.OPNHDEALTableAdapter();
			IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
			IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
			IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter StatementCustomerHeaderTableAdapter = new IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter();
			IACDataSet.ACCOUNTDataTable ACCOUNT = new IACDataSet.ACCOUNTDataTable();
			IACDataSet.OPNDEALRDataTable DEALER = new IACDataSet.OPNDEALRDataTable();
			IACDataSet.OPNHDEALDataTable DEALHIST = new IACDataSet.OPNHDEALDataTable();
			IACDataSet.MASTERDataTable MASTER = new IACDataSet.MASTERDataTable();
			IACDataSet.MASTHISTDataTable MASTHIST = new IACDataSet.MASTHISTDataTable();
			IACDataSet.OPN_WS_DEALERDataTable WS_DEALER = new IACDataSet.OPN_WS_DEALERDataTable();

			int lnSeq = 0,lnCustCount = 0;
			Decimal lnMasterOLoan = 0;
			String lsMasterKey = "";
			Object loDealhistSeq = null, loMastHistSeq = null, loMasterKey = null, loCustHistSeq = null, loLastPostDate = null;
            DateTime ldLastPostDate;

			WS_DEALERTableAdapter.Fill(WS_DEALER);
			StatementCustomerHeaderTableAdapter.DeleteNewBusinessStatements(); // Delete old new business statements!

            lnCustCount = CustomerPostDataSet.OPNCUST.Rows.Count; 
			for (int i = 0; i < CustomerPostDataSet.OPNCUST.Rows.Count; i++)
			{
				loCustHistSeq = CUSTHISTTableAdapter.SeqNoQuery(CustomerPostDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"), DateTime.Now.Date);

				if (loCustHistSeq != null)
					lnSeq = (int)loCustHistSeq + 1;
				else
					lnSeq = 1;
                // Moses Newman 12/25/2013 Remove Inline SQL and replace with UPDATE and INSERT
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_1",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_2",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_3",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_4",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_5",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_6",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_7",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_8",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_9",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_10",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_TOTAL_ISF",0);
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<String>("CUSTOMER_CONTROL_MONTH",DateTime.Now.Date.Month.ToString().PadLeft(2,'0'));
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<String>("CUSTOMER_CONTROL_YEAR",DateTime.Now.Date.Year.ToString().Substring(2,2));
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<String>("CUSTOMER_POST_IND","D");
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_BALANCE",
                    CustomerPostDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_LOAN_AMOUNT"));
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_TOT_FINANCE_CHARGE",
                    CustomerPostDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_YTD_FINANCE_CHARGE"));
                if(CustomerPostDataSet.OPNCUST.Rows[i].Field<Int32>("CUSTOMER_CREDIT_LIMIT") <= 0)
                    CustomerPostDataSet.OPNCUST.Rows[i].SetField<Int32>("CUSTOMER_CREDIT_LIMIT",
                        (Int32)CustomerPostDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_LOAN_AMOUNT"));
                CustomerPostDataSet.OPNCUST.Rows[i].SetField<String>("CUSTOMER_PAY_REM_1","NEW");

				try
				{
                    // Moses Newman 12/25/2013 Remove SQL PASS Through and replace with UPDATE and INSERT
                    CUSTOMERTableAdapter.Update(CustomerPostDataSet.OPNCUST.Rows[i]);
					CUSTHISTTableAdapter.Insert(CustomerPostDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"),"","O",DateTime.Now.Date,lnSeq,false,
                        "A",CustomerPostDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_LOAN_AMOUNT"),0,0,0,0,
                        CustomerPostDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAID_THRU"),CustomerPostDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAID_THRU_MM"),CustomerPostDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAID_THRU_YY"),
                        "NEW",
                        CustomerPostDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"),
                        CustomerPostDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_INTEREST_RATE1"),
                        CustomerPostDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_INTEREST_RATE2"),
                        CustomerPostDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_INTEREST_RATE3"),
                        0,0,0,0,0,0,0," ",0,0," ","N",Convert.ToInt32(CustomerPostDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO")),
                        DateTime.Now.Date,0,0,0,0,0,0,0,0,0,0,0," ",CustomerPostDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_AUTO_PAY"));
				}
				catch (System.Data.SqlClient.SqlException ex)
				{
					MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
				}
				catch (System.InvalidOperationException ex)
				{
					MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
				}
				catch (Exception ex)
				{
					MessageBox.Show("General Exception Error: " + ex.Message.ToString());
				}
				finally
				{
					PopulateOpenNewStatementFile(i, CustomerPostDataSet);
					worker.ReportProgress(30);
				}
			}
			for (Int32 dlrCount = 0; dlrCount < WS_DEALER.Rows.Count; dlrCount++)
			{
                DEALERTableAdapter.Fill(CustomerPostDataSet.OPNDEALR, WS_DEALER.Rows[dlrCount].Field<String>("KEY"));
                if (CustomerPostDataSet.OPNDEALR.Rows.Count > 0)
                {
                    CustomerPostDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_RSV", 0);
                    CustomerPostDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_CONT", 0);
                    CustomerPostDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_ADJ", 0);
                    CustomerPostDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_BAD", 0);
                    CustomerPostDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_LOSS", 0);
                    CustomerPostDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_OLOAN", WS_DEALER.Rows[dlrCount].Field<Decimal>("OS_L"));
                    CustomerPostDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_OLOAN",
                        CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN") + WS_DEALER.Rows[dlrCount].Field<Decimal>("OS_L"));
                    CustomerPostDataSet.OPNDEALR.Rows[0].SetField<DateTime>("OPNDEALR_POST_DATE", DateTime.Now.Date);

                    lnMasterOLoan += WS_DEALER.Rows[dlrCount].Field<Decimal>("OS_L");
                    // Moses Newman 12/25/2013 Get rid of SQL Pass through and replace with UPDATE and INSERT.
                    try
                    {
                        // Moses Newman 12/25/2013 Get rid of SQL Pass through and replace with UPDATE and INSERT.
                        DEALERTableAdapter.Update(CustomerPostDataSet.OPNDEALR);
                        loDealhistSeq = DEALHISTTableAdapter.SeqNoQuery(WS_DEALER.Rows[dlrCount].Field<String>("KEY").ToString(), DateTime.Now.Date, CustomerPostDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE").Date);
                        if (loDealhistSeq != null)
                            lnSeq = (int)loDealhistSeq + 1;
                        else
                            lnSeq = 1;
                        // Moses Newman 12/25/2013 Get rid of SQL Pass through and replace with UPDATE and INSERT.					
                        DEALHISTTableAdapter.Insert(WS_DEALER[dlrCount].Field<String>("KEY"), DateTime.Now.Date, CustomerPostDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE").Date, lnSeq,
                                                    CustomerPostDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_NAME").Replace(@"'", @""), 0, 0, CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_RSV"),
                                                    CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_CONT"), CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_OLOAN"), CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_ADJ"),
                                                    CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_BAD"), CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_LOSS"), CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_RSV"),
                                                    CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_CONT"), CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN"), CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_ADJ"),
                                                    CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_BAD"), CustomerPostDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_LOSS"), " ", Program.gsUserName, 0, "N");

                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("General Exception Error: " + ex.Message.ToString());
                    }
                    finally
                    {
                        worker.ReportProgress(60);
                    }
                }
            }
			loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
			lsMasterKey = (String)loMasterKey;
			lnMasterInterest += lnTotalCustomerDealerDisc;
            MASTERTableAdapter.FillByKey(MASTER, lsMasterKey);
            if (MASTER.Rows.Count != 0)
            {
                // Moses Newman 12/25/2013 Replace SQL Pass Through with Update and INSERT.
                MASTER.Rows[0].SetField<String>("MASTER_COMMENT1", "Open New Business");
                MASTER.Rows[0].SetField<String>("MASTER_COMMENT2", "");
                MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", lnMasterOLoan);
                MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_OLOAN", MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN") + lnMasterOLoan);
                MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                MASTER.Rows[0].SetField<Decimal>("MASTER_SIMPLE_CUR_OLOAN", 0);

                // Moses Newman 12/25/2013 Replace SQL Pass Through with Update and INSERT.
                try
                {
                    MASTERTableAdapter.Update(MASTER.Rows[0]);
                    loMastHistSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey.TrimEnd(), DateTime.Now.Date);
                    if (loMastHistSeq != null)
                        lnSeq = (int)loMastHistSeq + 1;
                    else
                        lnSeq = 1;
                    loLastPostDate = MASTHISTTableAdapter.LastPostDate(lsMasterKey);
                    if(loLastPostDate == null)
                        ldLastPostDate = DateTime.Now.Date;
                    else
                        ldLastPostDate = (DateTime)loLastPostDate;

                    MASTHISTTableAdapter.Insert(lsMasterKey, DateTime.Now.Date, lnSeq, MASTER.Rows[0].Field<String>("MASTER_NAME"),
                        0, 0,
                        MASTER.Rows[0].Field<Decimal>("MASTER_CUR_OLOAN"),
                        0, 0, 0, 0,
                        MASTER.Rows[0].Field<Decimal>("MASTER_CUR_NOTES"),
                        MASTER.Rows[0].Field<Decimal>("MASTER_YTD_RSV"),
                        MASTER.Rows[0].Field<Decimal>("MASTER_YTD_CONT"),
                        MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN"),
                        MASTER.Rows[0].Field<Decimal>("MASTER_YTD_ADJ"),
                        MASTER.Rows[0].Field<Decimal>("MASTER_YTD_BAD"),
                        MASTER.Rows[0].Field<Decimal>("MASTER_YTD_LOSS"),
                        MASTER.Rows[0].Field<Decimal>("MASTER_YTD_INT"),
                        MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES"),
                        ldLastPostDate.Year.ToString() + ldLastPostDate.Month.ToString().PadLeft(2, '0') + ldLastPostDate.Day.ToString().PadLeft(2, '0'),
                        lnCustCount,
                        "O",
                        "OPEN END NEW BUSINESS", "", 0,
                        MASTER.Rows[0].Field<Decimal>("MASTER_AMORT_YTD_OLOAN"), 0,
                        (MASTER.Rows[0].Field<Nullable<Decimal>>("MASTER_AMORT_YTD_NOTES") != null) ? MASTER.Rows[0].Field<Decimal>("MASTER_AMORT_YTD_NOTES") : 0, 0,
                        (MASTER.Rows[0].Field<Nullable<Decimal>>("MASTER_AMORT_YTD_INT") != null) ? MASTER.Rows[0].Field<Decimal>("MASTER_AMORT_YTD_INT") : 0, 0,
                        (MASTER.Rows[0].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_NOTES") != null) ? MASTER.Rows[0].Field<Decimal>("MASTER_SIMPLE_YTD_NOTES") : 0, 0,
                        (MASTER.Rows[0].Field<Nullable<Decimal>>("MASTER_AMORT_YTD_INT") != null) ? MASTER.Rows[0].Field<Decimal>("MASTER_SIMPLE_YTD_INT") : 0, 0,
                        (MASTER.Rows[0].Field<Nullable<Decimal>>("MASTER_AMORT_YTD_OLOAN") != null) ? MASTER.Rows[0].Field<Decimal>("MASTER_SIMPLE_YTD_OLOAN") : 0);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
                }
                catch (System.InvalidOperationException ex)
                {
                    MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("General Exception Error: " + ex.Message.ToString());
                }
                finally
                {
                    worker.ReportProgress(100);
                }
            }
		}

		static private void PopulateOpenNewStatementFile(Int32 CustomerPos, IACDataSet StatementDataSet)
		{
			IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter StatementCustomerHeaderTableAdapter = new IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter();
			BindingSource StatementCustomerHeaderBindingSource = new BindingSource();

			StatementCustomerHeaderBindingSource.DataSource = StatementDataSet.StatementCustomerHeader;

			// First row of boxes on statement
			StatementCustomerHeaderBindingSource.AddNew();
			StatementCustomerHeaderBindingSource.EndEdit();
			

			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<String>("AccountNumber", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<DateTime>("ScheduledPaymentDate", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<DateTime>("CUSTOMER_INIT_DATE"));
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("ScheduledPayment", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("PastDueAmount", 0);
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("LateCharge", 0);
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("TotalDue", 0);

			// Second Row of boxes non redundant fields
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("PreviousBalance", 0);
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<DateTime>("ClosingDate", DateTime.Now.Date);
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<DateTime>("LastClosingDate", DateTime.Now.Date);


			//Fourth Row of boxes non redundant fields
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("NewLoans", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_AMOUNT"));
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("FinanceCharge", 0);
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("Payments", 0);
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Decimal>("NewBalance", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_AMOUNT"));

			// New Busines and Add On Flags
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Boolean>("NewBusiness", true);
			StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Boolean>("AddOn", false);


			StatementCustomerHeaderBindingSource.EndEdit();
			StatementCustomerHeaderTableAdapter.Update(StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position]);
			StatementDataSet.StatementCustomerHeader.AcceptChanges();

			StatementCustomerHeaderTableAdapter.Dispose();
			StatementCustomerHeaderBindingSource.Dispose();
		}
		// End of Open End New Customer Posting

		// Create table fields for improperly designed AMORTIZE table for Closed End New Customer Posting
		static String CreateAmortFieldList(Int32 tnTerm)
		{
			// Moses Newman 03/02/2012 Reversed AMORTIZE_ADD_ON AND AMORTIZE_TYPE BECAUSE THEY WERE REVERSED
			String lsReturnClause  = "INSERT INTO AMORTIZE (AMORTIZE_CUST_NO,AMORTIZE_ADD_ON,AMORTIZE_TYPE,AMORTIZE_LOAN_CASH,AMORTIZE_LOAN_TERM,";
				   lsReturnClause += "AMORTIZE_LOAN_ANNUAL_RATE,AMORTIZE_MONTHLY_AMOUNT_OWED,";
			for (int i = 1; i <= tnTerm; i++)
			{
				lsReturnClause += "AMORTIZE_INTEREST_AMOUNT_" + Convert.ToString(i).PadLeft(5, '0') + ",";
				lsReturnClause += "AMORTIZE_PRINCIPLE_AMOUNT_" + Convert.ToString(i).PadLeft(5, '0') + ",";
				lsReturnClause += "AMORTIZE_BALANCE_" + Convert.ToString(i).PadLeft(5, '0') + ",";
				lsReturnClause += "AMORTIZE_INTEREST_PAID_" + Convert.ToString(i).PadLeft(5, '0') + ",";
				lsReturnClause += "AMORTIZE_PRINCIPLE_PAID_" + Convert.ToString(i).PadLeft(5, '0');
				if (i < tnTerm)
					lsReturnClause += ",";
				else
					lsReturnClause += ") VALUES(";
			}
			return lsReturnClause;
		}

			static public void RecreatePayments()
			{
				IACDataSet FixPay = new IACDataSet();

				IACDataSetTableAdapters.CUSTHISTTableAdapter  CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
				IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();


				String lsCusthist = @"SELECT CUSTOMER_DEALER AS CUSTHIST_DEALER,CUSTHIST.* FROM CUSTHIST,CUSTOMER WHERE (CUSTHIST_NO = CUSTOMER_NO) AND (CUSTHIST_PAY_DATE > '2011-11-22') AND (CUSTHIST_PAY_DATE < '2011-11-29') AND (CUSTOMER_AMORTIZE_IND = 'Y') AND (ASCII(CUSTHIST_PAYMENT_TYPE) <> 32) ORDER BY CUSTHIST_PAY_DATE,CUSTHIST_DEALER,CUSTHIST_NO", lsPayment = "";
				

				CUSTHISTTableAdapter.CustomizeFill(lsCusthist);
				CUSTHISTTableAdapter.CustomFillBy(FixPay.CUSTHIST);
				PAYMENTTableAdapter.DeleteQueryAll();

				for(int i =0; i < FixPay.CUSTHIST.Rows.Count;i++)
				{
					lsPayment = "INSERT INTO PAYMENT (PAYMENT_CUSTOMER,PAYMENT_ADD_ON,PAYMENT_IAC_TYPE,PAYMENT_DATE,PAYMENT_DEALER,PAYMENT_POST_INDICATOR,";
					lsPayment +="PAYMENT_AMOUNT_RCV,PAYMENT_TYPE,PAYMENT_THRU_UD,PAYMENT_CODE_2,PAYMENT_AUTO_PAY,PAYMENT_TSB_COMMENT_CODE) VALUES(\'";
					lsPayment += FixPay.CUSTHIST.Rows[i].Field<String>("CUSTHIST_NO")+@"',' ','C','"+
						FixPay.CUSTHIST.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE").Date.Year.ToString()+"-"+
						FixPay.CUSTHIST.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE").Date.Month.ToString()+"-"+
						FixPay.CUSTHIST.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE").Date.Day.ToString() + @"','"+
						FixPay.CUSTHIST.Rows[i].Field<String>("CUSTHIST_DEALER") + @"',";
					lsPayment += "\' \'," + FixPay.CUSTHIST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV").ToString().TrimStart().TrimEnd() + @",'";
					lsPayment += FixPay.CUSTHIST.Rows[i].Field<String>("CUSTHIST_PAYMENT_TYPE") + @"',";
					lsPayment += FixPay.CUSTHIST.Rows[i].Field<Decimal>("CUSTHIST_THRU_UD").ToString().TrimStart().TrimEnd() + ",\'";
					lsPayment += FixPay.CUSTHIST.Rows[i].Field<String>("CUSTHIST_PAYMENT_CODE") + @"','";
					lsPayment += FixPay.CUSTHIST.Rows[i].Field<String>("CUSTHIST_AUTO_PAY") + @"',' ')";

					PAYMENTTableAdapter.CustomizeFill(lsPayment);
					PAYMENTTableAdapter.CustomInsertQuery("");
				}
				MessageBox.Show("Done!!!");
			}

			static public Boolean LockfileExclusive()
			{
				IACDataSet BackupDataSet = new IACDataSet();
				IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
				String lsConnect = IAC2018SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsFilePath = "";
                Boolean lbResult = true;

				//lsFilePath = lsConnect.Substring(lsConnect.IndexOf("DATA SOURCE=") + 12, (lsConnect.IndexOf(@"\MFDATA\") + 8) - (lsConnect.IndexOf("DATA SOURCE=") + 12));
				DataPathTableAdapter.Fill(BackupDataSet.DataPath);
				lsFilePath = BackupDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();
				lsFilePath += @"LOCKFILE"; 

				try
				{
					// Try and open LOCKFILE for EXCLUSIVE ReadWrite Access
					fs.Close();
					fs.Dispose();
					fs = new FileStream(lsFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
				}
				catch (IOException ex)
				{
					MessageBox.Show("*** Can not perform posting operation because one or more users are in the system! *** : "+ ex.Message);
					lbResult = false;
				}
				finally
				{
					BackupDataSet.Clear();
					BackupDataSet.Dispose();
					DataPathTableAdapter.Dispose();
				}
				return lbResult;
			}

		static public void ReleaseExclusiveLock()
		{
			if (fs != null)
			{
				fs.Close();
				fs.Dispose();
			}
		}

		static public Boolean LockfileShare()
		{
			IACDataSet BackupDataSet = new IACDataSet();
			IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
            Boolean lbResult = true;

			String lsConnect = IAC2018SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsFilePath = "";

			DataPathTableAdapter.Fill(BackupDataSet.DataPath);
			lsFilePath = BackupDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();

				//lsFilePath  = lsConnect.Substring(lsConnect.IndexOf("DATA SOURCE=") + 12, (lsConnect.IndexOf(@"\MFDATA\") + 8) - (lsConnect.IndexOf("DATA SOURCE=") +12));
				lsFilePath += @"LOCKFILE"; 
				try
				{
				// Try and open the LOCKFILE for shared ReadWrite Access
				fs = new FileStream(lsFilePath,FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite);
				}
				catch (IOException ex)
				{
					MessageBox.Show("*** System maintenance is going on and it is locked by an admininstrator! *** : " + ex.Message);
                    lbResult = false;
				}
				finally
				{
					BackupDataSet.Clear();
					BackupDataSet.Dispose();
					DataPathTableAdapter.Dispose();                    
				}
			return lbResult;
		}


		static public void CreateMastHistSummary()
		{
			int lnSeq = 0, MASTHISTPos = 0, MASTERPos = 0;
			Object loMASTHISTSeq, loMasterKey;
			String lsMasterKey = "";

			IACDataSet MastHistDataSet = new IACDataSet();
			IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
			IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
			IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
			BindingSource MASTERBindingSource = new BindingSource();
			BindingSource MASTHISTBindingSource = new BindingSource();


			MASTERBindingSource.DataSource = MastHistDataSet.MASTER;
			MASTHISTBindingSource.DataSource = MastHistDataSet.MASTHIST;

			loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
			lsMasterKey = (String)loMasterKey;

			MASTERTableAdapter.FillAllRecords(MastHistDataSet.MASTER);
			MASTHISTTableAdapter.CustomizeFill(@"SELECT * FROM MASTHIST WHERE MASTHIST_ACC_NO = '" + lsMasterKey + @"' ORDER BY MASTHIST_POST_DATE ASC,MASTHIST_SEQ_NO");
			MASTHISTTableAdapter.CustomFillBy(MastHistDataSet.MASTHIST);

			MASTHISTBindingSource.AddNew();
			MASTHISTBindingSource.EndEdit();

			MASTHISTPos = MASTHISTBindingSource.Position;

			MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);


			if (MASTHISTPos > -1)
			{
				loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey,Convert.ToDateTime("2003-01-01"));
				if (loMASTHISTSeq != null)
					lnSeq = (int)loMASTHISTSeq + 1;
				else
					lnSeq = 1;
				// Set up the new history record key
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", "211");
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", Convert.ToDateTime("2003-01-01"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", MastHistDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "S");

				//  End of MASTHIST KEY

				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_OLOAN", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_OLOAN") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_OLOAN"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_OLOAN", 0);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_NOTES", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_NOTES") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_NOTES"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_NOTES", 0);
			}
			MASTHISTBindingSource.EndEdit();
			MASTHISTTableAdapter.Update(MastHistDataSet.MASTHIST);

			loMasterKey = ACCOUNTTableAdapter.AccountNumber("CONTING");
			lsMasterKey = (String)loMasterKey;

			MASTHISTTableAdapter.CustomizeFill(@"SELECT * FROM MASTHIST WHERE MASTHIST_ACC_NO = '" + lsMasterKey + @"' ORDER BY MASTHIST_POST_DATE ASC,MASTHIST_SEQ_NO");
			MASTHISTTableAdapter.CustomFillBy(MastHistDataSet.MASTHIST);

			MASTHISTBindingSource.AddNew();
			MASTHISTBindingSource.EndEdit();

			MASTHISTPos = MASTHISTBindingSource.Position;

			MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);


			if (MASTHISTPos > -1)
			{
				loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, Convert.ToDateTime("2003-01-01"));
				if (loMASTHISTSeq != null)
					lnSeq = (int)loMASTHISTSeq + 1;
				else
					lnSeq = 1;
				// Set up the new history record key
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", "210");
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", Convert.ToDateTime("2003-01-01"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", MastHistDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "S");

				//  End of MASTHIST KEY

				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_CONT", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_CONT") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_CONT"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_CONT", 0);
			}

			MASTHISTBindingSource.EndEdit();
			MASTHISTTableAdapter.Update(MastHistDataSet.MASTHIST);

			loMasterKey = ACCOUNTTableAdapter.AccountNumber("AMORT_INT");
			lsMasterKey = (String)loMasterKey;

			MASTHISTTableAdapter.CustomizeFill(@"SELECT * FROM MASTHIST WHERE MASTHIST_ACC_NO = '" + lsMasterKey + @"' ORDER BY MASTHIST_POST_DATE ASC,MASTHIST_SEQ_NO");
			MASTHISTTableAdapter.CustomFillBy(MastHistDataSet.MASTHIST);

			MASTHISTBindingSource.AddNew();
			MASTHISTBindingSource.EndEdit();

			MASTHISTPos = MASTHISTBindingSource.Position;

			MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);


			if (MASTHISTPos > -1)
			{
				loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, Convert.ToDateTime("2003-01-01"));
				if (loMASTHISTSeq != null)
					lnSeq = (int)loMASTHISTSeq + 1;
				else
					lnSeq = 1;
				// Set up the new history record key
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", "212");
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", Convert.ToDateTime("2003-01-01"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", MastHistDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "S");

				//  End of MASTHIST KEY
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_INT", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_INT") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_INT"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_INT", 0);

				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_AMORT_CUR_INT", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_AMORT_YTD_INT") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_AMORT_CUR_INT"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_AMORT_YTD_INT", 0);
			}

			MASTHISTBindingSource.EndEdit();
			MASTHISTTableAdapter.Update(MastHistDataSet.MASTHIST);

			loMasterKey = ACCOUNTTableAdapter.AccountNumber("INTEREST");
			lsMasterKey = (String)loMasterKey;

			MASTHISTTableAdapter.CustomizeFill(@"SELECT * FROM MASTHIST WHERE MASTHIST_ACC_NO = '" + lsMasterKey + @"' ORDER BY MASTHIST_POST_DATE ASC,MASTHIST_SEQ_NO");
			MASTHISTTableAdapter.CustomFillBy(MastHistDataSet.MASTHIST);

			MASTHISTBindingSource.AddNew();
			MASTHISTBindingSource.EndEdit();

			MASTHISTPos = MASTHISTBindingSource.Position;

			MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);


			if (MASTHISTPos > -1)
			{
				loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, Convert.ToDateTime("2003-01-01"));
				if (loMASTHISTSeq != null)
					lnSeq = (int)loMASTHISTSeq + 1;
				else
					lnSeq = 1;
				// Set up the new history record key
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", "213");
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", Convert.ToDateTime("2003-01-01"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", MastHistDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "S");

				//  End of MASTHIST KEY

				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_INT", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_INT") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_INT"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_INT", 0);
			}

			MASTHISTBindingSource.EndEdit();
			MASTHISTTableAdapter.Update(MastHistDataSet.MASTHIST);

			loMasterKey = ACCOUNTTableAdapter.AccountNumber("BAD_DEBTS");
			lsMasterKey = (String)loMasterKey;

			MASTHISTTableAdapter.CustomizeFill(@"SELECT * FROM MASTHIST WHERE MASTHIST_ACC_NO = '" + lsMasterKey + @"' ORDER BY MASTHIST_POST_DATE ASC,MASTHIST_SEQ_NO");
			MASTHISTTableAdapter.CustomFillBy(MastHistDataSet.MASTHIST);

			MASTHISTBindingSource.AddNew();
			MASTHISTBindingSource.EndEdit();

			MASTHISTPos = MASTHISTBindingSource.Position;

			MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);


			if (MASTHISTPos > -1)
			{
				loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, Convert.ToDateTime("2003-01-01"));
				if (loMASTHISTSeq != null)
					lnSeq = (int)loMASTHISTSeq + 1;
				else
					lnSeq = 1;
				// Set up the new history record key
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", "214");
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", Convert.ToDateTime("2003-01-01"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", MastHistDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "S");

				//  End of MASTHIST KEY

				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_BAD", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_BAD") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_BAD"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_BAD", 0);
			}

			MASTHISTBindingSource.EndEdit();
			MASTHISTTableAdapter.Update(MastHistDataSet.MASTHIST);

			loMasterKey = ACCOUNTTableAdapter.AccountNumber("RES_LOSS");
			lsMasterKey = (String)loMasterKey;

			MASTHISTTableAdapter.CustomizeFill(@"SELECT * FROM MASTHIST WHERE MASTHIST_ACC_NO = '" + lsMasterKey + @"' ORDER BY MASTHIST_POST_DATE ASC,MASTHIST_SEQ_NO");
			MASTHISTTableAdapter.CustomFillBy(MastHistDataSet.MASTHIST);

			MASTHISTBindingSource.AddNew();
			MASTHISTBindingSource.EndEdit();

			MASTHISTPos = MASTHISTBindingSource.Position;

			MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);


			if (MASTHISTPos > -1)
			{
				loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, Convert.ToDateTime("2003-01-01"));
				if (loMASTHISTSeq != null)
					lnSeq = (int)loMASTHISTSeq + 1;
				else
					lnSeq = 1;
				// Set up the new history record key
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", "216");
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", Convert.ToDateTime("2003-01-01"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", MastHistDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "S");

				//  End of MASTHIST KEY

				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_RSV", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_RSV") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_RSV"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_RSV", 0);
			}

			MASTHISTBindingSource.EndEdit();
			MASTHISTTableAdapter.Update(MastHistDataSet.MASTHIST);

			loMasterKey = ACCOUNTTableAdapter.AccountNumber("LOSS_RES");
			lsMasterKey = (String)loMasterKey;

			MASTHISTTableAdapter.CustomizeFill(@"SELECT * FROM MASTHIST WHERE MASTHIST_ACC_NO = '" + lsMasterKey + @"' ORDER BY MASTHIST_POST_DATE ASC,MASTHIST_SEQ_NO");
			MASTHISTTableAdapter.CustomFillBy(MastHistDataSet.MASTHIST);

			MASTHISTBindingSource.AddNew();
			MASTHISTBindingSource.EndEdit();

			MASTHISTPos = MASTHISTBindingSource.Position;

			MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);


			if (MASTHISTPos > -1)
			{
				loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, Convert.ToDateTime("2003-01-01"));
				if (loMASTHISTSeq != null)
					lnSeq = (int)loMASTHISTSeq + 1;
				else
					lnSeq = 1;
				// Set up the new history record key
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", "217");
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", Convert.ToDateTime("2003-01-01"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", MastHistDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "S");

				//  End of MASTHIST KEY

				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_LOSS", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_LOSS") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_LOSS"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_LOSS", 0);
			}

			MASTHISTBindingSource.EndEdit();
			MASTHISTTableAdapter.Update(MastHistDataSet.MASTHIST);

			loMasterKey = ACCOUNTTableAdapter.AccountNumber("ADJUST");
			lsMasterKey = (String)loMasterKey;

			MASTHISTTableAdapter.CustomizeFill(@"SELECT * FROM MASTHIST WHERE MASTHIST_ACC_NO = '" + lsMasterKey + @"' ORDER BY MASTHIST_POST_DATE ASC,MASTHIST_SEQ_NO");
			MASTHISTTableAdapter.CustomFillBy(MastHistDataSet.MASTHIST);

			MASTHISTBindingSource.AddNew();
			MASTHISTBindingSource.EndEdit();

			MASTHISTPos = MASTHISTBindingSource.Position;

			MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);


			if (MASTHISTPos > -1)
			{
				loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, Convert.ToDateTime("2003-01-01"));
				if (loMASTHISTSeq != null)
					lnSeq = (int)loMASTHISTSeq + 1;
				else
					lnSeq = 1;
				// Set up the new history record key
			   MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", "422");
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", Convert.ToDateTime("2003-01-01"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", MastHistDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "S");

				//  End of MASTHIST KEY

				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_ADJ", MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_ADJ") - MastHistDataSet.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_CUR_ADJ"));
				MastHistDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_ADJ", 0);
			}

			MASTHISTBindingSource.EndEdit();
			MASTHISTTableAdapter.Update(MastHistDataSet.MASTHIST);


		}
		
		static public  void UpdateComments(ref IACDataSet iACDataSet, ref BindingSource cOMMENTBindingSource, Boolean tbOpen = false)
		{
			String lsComment1, lsComment2, lsComment3;
			Int32 lnCommentLength = 0;


			IACDataSetTableAdapters.COMMENTTableAdapter cOMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();
			IACDataSetTableAdapters.OPNCOMMTableAdapter oPNCOMMTableAdapter = new IACDataSetTableAdapters.OPNCOMMTableAdapter();

			if (!tbOpen)
			{
				for (Int32 i = 0; i < iACDataSet.COMMENT.Rows.Count; i++)
				{
                    if (iACDataSet.COMMENT.Rows[i].RowState == DataRowState.Deleted)
                        continue;
                    // Moses Newman 02/21/2019 handle if comment is null!
                    if (iACDataSet.COMMENT.Rows[i].Field<String>("COMMENT_WHOLE") == null)
                        continue;
                    else
                        if (iACDataSet.COMMENT.Rows[i].Field<String>("COMMENT_WHOLE").Length <=0)
                            continue;
					if (iACDataSet.COMMENT.Rows[i].RowState != DataRowState.Deleted)
					{
						lsComment1 = "";
						lsComment2 = "";
						lsComment3 = "";
						lnCommentLength = iACDataSet.COMMENT.Rows[i].Field<String>("COMMENT_WHOLE").Length;
						if (lnCommentLength <= 60)
							lsComment1 = iACDataSet.COMMENT.Rows[i].Field<String>("COMMENT_WHOLE");
						else
						{
							lsComment1 = iACDataSet.COMMENT.Rows[i].Field<String>("COMMENT_WHOLE").Substring(0, 60);
							if (lnCommentLength <= 120)
								lsComment2 = iACDataSet.COMMENT.Rows[i].Field<String>("COMMENT_WHOLE").Substring(60, lnCommentLength - 60);
							else
							{
								lsComment2 = iACDataSet.COMMENT.Rows[i].Field<String>("COMMENT_WHOLE").Substring(60, 60);
								lsComment3 = iACDataSet.COMMENT.Rows[i].Field<String>("COMMENT_WHOLE").Substring(120, lnCommentLength - 120);
							}
						}

						iACDataSet.COMMENT.Rows[i].SetField<String>("COMMENT_1", lsComment1);
						iACDataSet.COMMENT.Rows[i].SetField<String>("COMMENT_2", lsComment2);
						iACDataSet.COMMENT.Rows[i].SetField<String>("COMMENT_3", lsComment3);
						if (iACDataSet.COMMENT.Rows[i].Field<Nullable<Boolean>>("IsArchive") == null)
							iACDataSet.COMMENT.Rows[i].SetField<Boolean>("IsArchive", false);
					}
                    cOMMENTBindingSource.EndEdit();
				}
			}
			else
			{
				for (Int32 i = 0; i < iACDataSet.OPNCOMM.Rows.Count; i++)
				{
                    if (iACDataSet.OPNCOMM.Rows[i].RowState == DataRowState.Deleted)
                        continue;
                    if (iACDataSet.OPNCOMM.Rows[i].Field<String>("COMMENT_WHOLE").Length <= 0)
                        continue;
					if (iACDataSet.OPNCOMM.Rows[i].RowState != DataRowState.Deleted)
					{
						lsComment1 = "";
						lsComment2 = "";
						lsComment3 = "";
						lnCommentLength = iACDataSet.OPNCOMM.Rows[i].Field<String>("COMMENT_WHOLE").Length;
						if (lnCommentLength <= 60)
							lsComment1 = iACDataSet.OPNCOMM.Rows[i].Field<String>("COMMENT_WHOLE");
						else
						{
							lsComment1 = iACDataSet.OPNCOMM.Rows[i].Field<String>("COMMENT_WHOLE").Substring(0, 60);
							if (lnCommentLength <= 120)
								lsComment2 = iACDataSet.OPNCOMM.Rows[i].Field<String>("COMMENT_WHOLE").Substring(60, lnCommentLength - 60);
							else
							{
								lsComment2 = iACDataSet.OPNCOMM.Rows[i].Field<String>("COMMENT_WHOLE").Substring(60, 60);
								lsComment3 = iACDataSet.OPNCOMM.Rows[i].Field<String>("COMMENT_WHOLE").Substring(120, lnCommentLength - 120);
							}
						}
						iACDataSet.OPNCOMM.Rows[i].SetField<String>("COMMENT_1", lsComment1);
						iACDataSet.OPNCOMM.Rows[i].SetField<String>("COMMENT_2", lsComment2);
						iACDataSet.OPNCOMM.Rows[i].SetField<String>("COMMENT_3", lsComment3);
						if (iACDataSet.OPNCOMM.Rows[i].Field<Nullable<Boolean>>("IsArchive") == null)
							iACDataSet.OPNCOMM.Rows[i].SetField<Boolean>("IsArchive", false);
					}
				}
                cOMMENTBindingSource.EndEdit();
			}
			if (tbOpen)
			{
				oPNCOMMTableAdapter.Update(iACDataSet.OPNCOMM);  // Delete, Update, and Insert all the customers comment records!
				iACDataSet.OPNCOMM.AcceptChanges();
			}
		}

		static public void FixOpenCustomerStatus()
		{
			IACDataSet FIXDATASET = new IACDataSet();
			OpenPaymentPosting OPPosting = new OpenPaymentPosting();
			IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
			IACDataSetTableAdapters.OPNNOTTableAdapter OPNNOTTableAdapter = new IACDataSetTableAdapters.OPNNOTTableAdapter();
			OPNCUSTTableAdapter.CustomizeFill("SELECT * FROM OPNCUST");
			OPNCUSTTableAdapter.CustomFillBy(FIXDATASET.OPNCUST);
			// Get old AMORTIZE into AmortTemp
			for (Int32 i = 0; i < FIXDATASET.OPNCUST.Rows.Count; i++) 
			{
				OPPosting.OpenNewContractStatus(i, ref FIXDATASET);
			}
			OPNCUSTTableAdapter.Update(FIXDATASET.OPNCUST);
			OPNNOTTableAdapter.FixNoticeStatus();
		}

		// Moses Newman 11/26/2012 Added Regular Express IsInteger test function
		public static bool IsInteger(string theValue)
		{
			Match m = _isNumber.Match(theValue);
			return m.Success;
		} //IsInteger

		// Moses Newman 01/22/2013 Create fucntion to add payment decriptors
		public static void MarkPaymentDescriptor(ref IACDataSet PAYMENTDataSet, Int32 CustomerPos, Int32 CusthistPosition, Int32 PaymentPos)
		{
			// Moses Newman 07/07/2013 Replace big case statement with function call
            PAYMENTDataSet.CUSTHIST.Rows[CusthistPosition].SetField<String>("CUSTHIST_PAY_REM_1", MarkPay(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT"), PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE"), PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CODE_2")));
		}

		// Moses Newman 02/07/2013 Create fucntion to return payment decriptors
		public static string MarkPay(String tsActStat,String tsPayType, String tsPayCode = "0")
		{
			String lsPayDesc = "PAID";
			if (tsActStat == "I")
				lsPayDesc = "PAID";
			else
			{
				switch (tsPayType)
				{
					case "R":
						lsPayDesc = "PAY  ";
						break;
					case "E":
						lsPayDesc = "EXT  ";
						break;
					case "I":
						lsPayDesc ="INSUF";
						break;
					case "N":
						lsPayDesc = "ISFC ";
						break;
					case "W":
						lsPayDesc = "WAVE ";
						break;
					case "A":
						lsPayDesc = "ADJ  ";
						break;
					case "C":
						lsPayDesc = "CANCL";
						break;
					case "B":
						lsPayDesc = "BUYBK";
						break;
					case "V":
                        // Moses Newman06/28/2016 if paycode = "I" IVR
						lsPayDesc = (tsPayCode != "I") ? "CCARD":"IVR";
						break;
					case "P":
						lsPayDesc = "PWRCK";
						break;
					case "S":
						lsPayDesc = "STLMT";
						break;
					case "M":
						lsPayDesc = "MRCHT";
						break;
					case "H":
						lsPayDesc = "HOUSE";
						break;
					case "T":
						lsPayDesc = "TRNSF";
						break;
					case "D":
						lsPayDesc = "DLRTR";
						break;
					default:
						lsPayDesc = "";
						break;
				}
			}
			return lsPayDesc;
		}

        public static string Left(string text, int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException("length", length, "length must be > 0");
            else if (length == 0 || text.Length == 0)
                return "";
            else if (text.Length <= length)
                return text;
            else
                return text.Substring(0, length);
        }

        public static void FixLateandPartialBuckets(string tsCustomerNo,bool tbPayment = false)
        {
            IACDataSet FixData = new IACDataSet();
            // Moses Newman 09/17/2018 Add new DataTable and TaleAdapter to retreive total payments for current date, as well as RowNumber of last payment for current date.
            PaymentDataSet Pmts = new PaymentDataSet();
            PaymentDataSetTableAdapters.DailyPaymentsTableAdapter DailyPaymentsTableAdapter = new PaymentDataSetTableAdapters.DailyPaymentsTableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            IACDataSetTableAdapters.LateRatesSelectTableAdapter LateRatesSelectTableAdapter = new IACDataSetTableAdapters.LateRatesSelectTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter FixDataPAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();

            // Moses Newman 07/25/2019 Order By ACTUAL CUSTHIST order.
            //TVAmortTableAdapter.FillByCustomerNo(FixData.TVAmort, tsCustomerNo);
            TVAmortTableAdapter.FillByCustHist(FixData.TVAmort, tsCustomerNo);
            decimal lnPayAmount = 0, lnPartialPayment = 0, lnRegular = 0, lnLastLateFeeBalance = 0, lnLastPartialPaymentBalance = 0, lnLastLateFee = 0,
                    lnContractStatus = 0, lnLastPartialPaymentApplied = 0, lnLastPaymentContractStatus = 0, lnPrePaymentPartialPayment = 0, lnPrePaymentLateFeeBalance = 0,
                    // Moses Newman 09/24/2018 add lnLastBalance so we can caculate balance as of today.
                    lnNewLate = 0, lnDeltaLC = 0, lnLateFeePartial = 0, lnDeltaPPB = 0, lnLastPPDueToLC = 0, lnLastBalance = 0, lnTempPartial = 0;
            int lnPayments = 0, lnDateDiff = 0, lnNewDiff = 0, lnSeq = 0, CurrentRow = 0,lnNumPayments = 0, lnLastPaymentRow = 0;
            DateTime ldFirstPaymentDate, ldLastPaidThrough;
            DateTime? ldPaymentDate;
            TimeSpan ltsDateDiff;
            string lsEvent = "";
            Boolean lbADJFound = false;  // Moses Newmn 12/10/2018 Flag to fix negative adjustment issue if reversing a previous negative adjustment.


            CUSTOMERTableAdapter.Fill(FixData.CUSTOMER, tsCustomerNo);

            if (FixData.CUSTOMER.Rows.Count != 0)
            {
                lnRegular = FixData.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT");
                ldLastPaidThrough = FixData.CUSTOMER.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE");
                ldFirstPaymentDate = ldLastPaidThrough;
                ldLastPaidThrough = ldLastPaidThrough.AddMonths(-1); // First Paid Through is always First Payment Date -1 month
																	 // Moses Newman 09/19/2018 if posting payments make sure amort has ALL PAYMENTS FOR THIS CUSTOMER TODAY!
				tbPayment = false;  // Moses Newman 06/26/2020 No longer need this routine as TVAmort already added the payments.
                if (tbPayment)
                {
                    FixDataPAYMENTTableAdapter.Fill(FixData.PAYMENT, tsCustomerNo);
                    if (FixData.PAYMENT.Rows.Count > 0)
                    {
                        decimal lnSimpBal;
                        lnSimpBal = Program.TVSimpleGetBuyout(FixData, DateTime.Now.Date,
                         (Double)FixData.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM"),
                         (Double)(FixData.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                         (Double)FixData.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                         tsCustomerNo,
                         // 04/30/2017 Handle BOTH Simple Interest and Normal Daily Compounding
                         // Moses Newman 04/02/2018 fixed Payment and PaymentPos parameters so TVSimpleGetBuyout knows to add payments!
                         FixData.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, false, false, tbPayment, FixData.PAYMENT.Rows.Count - 1, true);
                        TVAmortTableAdapter.Update(FixData.TVAmort);
                        TVAmortTableAdapter.FillByCustomerNo(FixData.TVAmort, tsCustomerNo);
                    }
                }
                for (int i = 0; i < FixData.TVAmort.Rows.Count; i++)
                {
                    // Moses Newman 09/17/2018 Get total payments for current transaction date, and location of last payment for this date.
                    DailyPaymentsTableAdapter.Fill(Pmts.DailyPayments, tsCustomerNo, FixData.TVAmort.Rows[i].Field<DateTime>("Date"));
                    if(Pmts.DailyPayments.Rows.Count > 0)
                    {
                        ldPaymentDate = Pmts.DailyPayments.Rows[0].Field<DateTime>("Date");
                        lnNumPayments = Pmts.DailyPayments.Rows[0].Field<int>("NumPayments");
                        lnLastPaymentRow = Pmts.DailyPayments.Rows[0].Field<int>("LastPaymentRow");
                    }
                    else
                    {
                        ldPaymentDate = null;
                        lnNumPayments = 0;
                        lnLastPaymentRow = 0;
                    }
                    FixData.TVAmort.Rows[i].SetField<Decimal>("LastPPBBalance", lnLastPartialPaymentBalance);
                    FixData.TVAmort.Rows[i].SetField<Decimal>("LastLFBalance", lnLastLateFeeBalance);
                    FixData.TVAmort.Rows[i].SetField<Decimal>("LastPPBUsedLC", lnLastPPDueToLC);
                    lsEvent = FixData.TVAmort.Rows[i].Field<String>("Event").Trim();
                    FixData.TVAmort.Rows[i].SetField<Decimal>("PrevPPBUsed", 0);
                    FixData.TVAmort.Rows[i].SetField<Decimal>("PrevPPBUsedLC", 0);
                    FixData.TVAmort.Rows[i].SetField<Int32>("DeltaPTMonths", 0);
                    switch (lsEvent)
                    {
                        case "NEW":
                        case "BUYOUT":
                        case "UNEARNED":
                        case "LATE":
                        case "UPD":
                        case "ISFC":
                        case "RTCHG":
                            FixData.TVAmort.Rows[i].SetField<DateTime>("PaidThrough", ldLastPaidThrough);
                            FixData.TVAmort.Rows[i].SetField<Decimal>("ContractStatus", lnContractStatus);
                            FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnLastPartialPaymentBalance);
                            if (FixData.TVAmort.Rows[i].Field<String>("Event").Trim() != "LATE")
                                FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", lnLastLateFeeBalance);
                            else
                            {
                                if (FixData.TVAmort.Rows[i].Field<Decimal>("LateFee") == 0)
                                {
                                    LateRatesSelectTableAdapter.Fill(FixData.LateRatesSelect, FixData.CUSTOMER.Rows[0].Field<String>("CUSTOMER_STATE"));
                                    if ((lnLastPaymentContractStatus * -1) >= (lnRegular * 2))
                                        lnNewLate = lnRegular * FixData.LateRatesSelect.Rows[0].Field<Decimal>("Rate");
                                    else
                                        lnNewLate = (lnRegular - lnLastPartialPaymentBalance) * FixData.LateRatesSelect.Rows[0].Field<Decimal>("Rate");
                                    if (lnNewLate > FixData.LateRatesSelect.Rows[0].Field<Decimal>("CutOff") && FixData.LateRatesSelect.Rows[0].Field<Decimal>("CutOff") != 0)
                                        lnNewLate = FixData.LateRatesSelect.Rows[0].Field<Decimal>("CutOff");
                                    FixData.TVAmort.Rows[i].SetField<Decimal>("LateFee", lnNewLate);
                                    FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", lnLastLateFeeBalance + lnNewLate);
                                    if (FixData.TVAmort.Rows[i].Field<Int32?>("HistorySeq") != null)
                                        lnSeq = FixData.TVAmort.Rows[i].Field<Int32>("HistorySeq");
                                    else
                                        lnSeq = 1;
                                    // Moses Newman 04/24/2018 Grab only the late charge!
                                    CUSTHISTTableAdapter.GetLate(FixData.CUSTHIST, tsCustomerNo, FixData.TVAmort.Rows[i].Field<DateTime>("Date").Date);
                                    //CUSTHISTTableAdapter.Fill(FixData.CUSTHIST, tsCustomerNo, lnSeq, FixData.TVAmort.Rows[i].Field<DateTime>("Date").Date);
                                    FixData.CUSTHIST.Rows[0].SetField<Decimal>("CUSTHIST_LATE_CHARGE", lnNewLate);
                                    FixData.CUSTHIST.Rows[0].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", lnLastLateFeeBalance + lnNewLate);
                                    CUSTHISTTableAdapter.Update(FixData.CUSTHIST.Rows[0]);
                                }
                                FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", lnLastLateFeeBalance + FixData.TVAmort.Rows[i].Field<Decimal>("LateFee"));
                                lnLastLateFee = FixData.TVAmort.Rows[i].Field<Decimal>("LateFee");
                            }
                            // Moses Newman 03/29/2018 Make sure we have last late fee in buyout row!
                            if (FixData.TVAmort.Rows[i].Field<String>("Event").Trim() == "BUYOUT" || FixData.TVAmort.Rows[i].Field<String>("Event").Trim() == "UNEARNED")
                                if (FixData.TVAmort.Rows[i].Field<Decimal>("LateFeeBalance") > 0)
                                    FixData.TVAmort.Rows[i].SetField<Decimal>("LateFee", lnLastLateFee);
                                else
                                    FixData.TVAmort.Rows[i].SetField<Decimal>("LateFee", 0);
                            lnPayments = 0;
                            break;
                        case "CCARD":
                        case "IVR":
                        case "PAY":
                        case "PWRCK":
                        case "PAID":
                        case "WAVE":
                        case "BUYBK":
                        case "HOUSE":
                        case "CANCL":
                        case "ADJ":
                        case "INSUF":
                            lnPrePaymentPartialPayment = lnLastPartialPaymentBalance - lnLastPPDueToLC;
                            lnPrePaymentLateFeeBalance = lnLastLateFeeBalance;
                            lnLastPaymentContractStatus = lnContractStatus;
                            if (lsEvent != "WAVE")
                                lnPayAmount = FixData.TVAmort.Rows[i].Field<Decimal>("Payment");
                            else
                                lnPayAmount = FixData.TVAmort.Rows[i].Field<Decimal>("NonCash");
                            if (lnPayAmount > 0)
                                // Moses Newman 08/23/2018 properly handle WAVE Late Fees
                                if (FixData.TVAmort.Rows[i].Field<String>("PaymentCode") != "WL")
                                    lnPayments = (Int32)((lnPayAmount + lnPrePaymentPartialPayment) / lnRegular);
                                else
                                    lnPayments = 0;
                            else
                            {
                                if (lnPayAmount < 0 && FixData.TVAmort.Rows[i].Field<String>("PaymentCode") != "WL")
                                {
                                    CurrentRow = i;
                                    // Moses Newman 06/28/2018 no reason to check for negative payment, because if not ISF date wont find it anyway!
                                    var res = from row in FixData.TVAmort.AsEnumerable()
                                              where row.Field<String>("CustomerNo") == FixData.TVAmort.Rows[CurrentRow].Field<String>("CustomerNo") &&
                                                    row.Field<String>("Event").Trim() != "UPD" && row.Field<String>("Event").Trim() != "LATE" &&
                                                    row.Field<DateTime?>("Date") == FixData.TVAmort.Rows[CurrentRow].Field<DateTime?>("ISFDate") &&
                                                    row.Field<Int32?>("HistorySeq") == FixData.TVAmort.Rows[CurrentRow].Field<Int32?>("ISFSeqNo") &&
                                                    row.Field<String>("PaymentCode") == FixData.TVAmort.Rows[CurrentRow].Field<String>("ISFPaymentType") +
                                                                                        FixData.TVAmort.Rows[CurrentRow].Field<String>("ISFPaymentCode")
                                              select row;


                                    // Moses Newman 04/19/2018 if isf fields are empty got to last previous match.
                                    if (!res.Any())
                                    {
                                        var subres = from dres in FixData.TVAmort.AsEnumerable()
                                                     where dres.Field<String>("CustomerNo") == FixData.TVAmort.Rows[CurrentRow].Field<String>("CustomerNo") &&
                                                           dres.Field<String>("Event").Trim() != "UPD" && dres.Field<String>("Event").Trim() != "LATE" &&
                                                           dres.Field<String>("Event").Trim() != "NEW" &&
                                                           dres.Field<Decimal>("Payment") == FixData.TVAmort.Rows[CurrentRow].Field<Decimal>("Payment") * -1 &&
                                                           dres.Date < FixData.TVAmort.Rows[CurrentRow].Field<DateTime>("Date").Date
                                                     select dres;
                                        if (subres.Any())
                                            res = from row in FixData.TVAmort.AsEnumerable()
                                                  where row.Field<String>("Event").Trim() != "UPD" && row.Field<String>("Event").Trim() != "LATE" &&
                                                        row.Field<DateTime?>("Date") == (from dres in FixData.TVAmort
                                                                                         where dres.Field<String>("CustomerNo") == FixData.TVAmort.Rows[CurrentRow].Field<String>("CustomerNo") &&
                                                                                               dres.Field<String>("Event").Trim() != "UPD" && dres.Field<String>("Event").Trim() != "LATE" &&
                                                                                               dres.Field<String>("Event").Trim() != "NEW" &&
                                                                                               dres.Field<Decimal>("Payment") == FixData.TVAmort.Rows[CurrentRow].Field<Decimal>("Payment") * -1 &&
                                                                                               dres.Date < FixData.TVAmort.Rows[CurrentRow].Field<DateTime>("Date").Date
                                                                                         select dres.Date).Max()
                                                  select row;
                                        else
                                            res = subres;
                                    }
                                    if (res.Any())
                                    {
                                        // Moses Newman 08/10/2019 Only reduce by Previous Partial Payment Balance Used if it is > 0!
                                        lnPayments = (Int32)((lnPayAmount + (res.ElementAt(0).PrevPPBUsed < 0 ? res.ElementAt(0).PrevPPBUsed:0)) / lnRegular);
                                        lnPartialPayment = res.ElementAt(0).PrevPPBUsed + res.ElementAt(0).PrevPPBUsedLC;
                                        lnPartialPayment *= -1;
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", lnLastLateFeeBalance +
                                            (res.ElementAt(0).LastLFBalance - res.ElementAt(0).LateFeeBalance));
                                        // Moses Newman 07/25/2019 Fix partial payment return if partial bounce from old days when multiple checks where combined with one.
                                        if(lnPayAmount * -1 < res.ElementAt(0).Payment) // Moses Newman 08/10/2019 only do this if bounced check was more than one check combined.
                                            // Moses Newman 11/14/2019 partial payment on partial return is the last partial - the difference in amounts)
                                            FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnLastPartialPaymentBalance - (lnPayAmount + res.ElementAt(0).Payment));
                                        else
                                            FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnLastPartialPaymentBalance + res.ElementAt(0).LastPPBBalance - res.ElementAt(0).PartialPayment);
                                        // Moses Newman 08/01/2018 new partial payment after INSUF could be greater than a payment so we must adjust lnPayments accordingly!
                                        Int32 lnPaymentsAdjust = (Int32)(FixData.TVAmort.Rows[i].Field<Decimal>("PartialPayment") / lnRegular);
                                        lnPayments += lnPaymentsAdjust;
                                        // Moses Newman 08/10/2019 On a negative payment NEVER increase the paid thru!!!
                                        if (lnPayments > 0)
                                            lnPayments = 0;
                                        // Moses Newman 01/15/2019 If INSUF leaves negative partial payment back off one month and add complete payment to partial payment.
                                        lnTempPartial = FixData.TVAmort.Rows[i].Field<Decimal>("PartialPayment") - (lnPaymentsAdjust * lnRegular);
                                        if(lnTempPartial < 0 && lnPayments != 0) // Moses Newman 01/23/2020 make sure lnPayments is not 0.
                                        {
                                            lnPayments -= 1;
                                            lnTempPartial += lnRegular;
                                        }
                                        // 01/15/2019
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnTempPartial);
                                        // Moses Newman 08/01/2018 end partial payment fixup
                                        // Moses Newman 12/10/2018 Set Flag for found ADJ to reverse.
                                        lbADJFound = true;
                                    }
                                    else
                                    {
                                        lnPartialPayment = 0;
                                        // Moses Newman 04/24/2018 If no match dont include partial payment balance in lnPayment calculations!
                                        lnPayments = (Int32)((lnPayAmount) / lnRegular);
                                        FixData.TVAmort.Rows[i].SetField<Int32>("DeltaPTMonths", lnPayments);
                                        lnPartialPayment = FixData.TVAmort.Rows[i].Field<Decimal>("Payment") - (lnPayments * lnRegular);
                                        // Moses Newman 04/24/2018 dont let the Partial Payment balance go negative on a negative payment!
                                        if (lnLastPartialPaymentBalance == 0)
                                            lnPartialPayment = 0;
                                        else
                                        {
                                            if (lnPartialPayment * -1 > lnLastPartialPaymentBalance)
                                                lnPartialPayment = lnLastPartialPaymentBalance * -1;
                                            // Moses Newman 11/15/2018 if negative adjustment calculated partial payment carry over last partial payment balance.
                                            if (lnPartialPayment < 0 && (lnLastPartialPaymentBalance + lnPartialPayment) >= 0)
                                                lnPartialPayment = lnLastPartialPaymentBalance + lnPartialPayment;
                                        }
                                        if (lsEvent == "PAID")
                                        {
                                            FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", 0);
                                            FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", 0);
                                        }
                                    }
                                }
                            }
                            if (lnPayAmount > 0)
                            {
                                if (FixData.TVAmort.Rows[i].Field<String>("PaymentCode") != "WL")
                                {
                                    FixData.TVAmort.Rows[i].SetField<Int32>("DeltaPTMonths", lnPayments);
                                    // Moses Newman 12/4/2018 change FixData.TVAmort.Rows[i].Field<Decimal>("Payment") tp lnPayamount incase of Waive Charge.
                                    // Moses Newman 09/24/2018 if last payment partial payment is payment - balance.
                                    if (lnPayAmount < (lnLastBalance + FixData.TVAmort.Rows[i].Field<Decimal>("Interest")))
                                        lnPartialPayment = lnPayAmount - (lnPayments * lnRegular);
                                    else
                                        lnPartialPayment = lnPayAmount - (lnLastBalance + FixData.TVAmort.Rows[i].Field<Decimal>("Interest"));
                                }
                                else
                                {
                                    FixData.TVAmort.Rows[i].SetField<Int32>("DeltaPTMonths", 0);
                                    lnPartialPayment = 0;
                                }
                            }
                            // Moses Newman 04/12/2018 store the amount of the Previous Partial Payment Balance used to complete the number of payments.
                            if (lnPartialPayment < 0 && lnPayAmount > 0)
                                FixData.TVAmort.Rows[i].SetField<Decimal>("PrevPPBUsed", lnPartialPayment);
                            if (FixData.TVAmort.Rows[i].Field<String>("PaymentCode") != "WL")
                            {
                                // Moses Newman 09/19/2018 Do not pay off any of the latefee balance if there are multiple partial payments for this date and it is not on the last payment,
                                // unless date is earlier than 09/19/2018!
                                if (((lnLastLateFeeBalance != 0 && (lnPartialPayment + lnLastPartialPaymentBalance) > 0) && lnPayAmount > 0) &&
                                    (ldPaymentDate == null || ldPaymentDate < DateTime.Parse("09/19/2018") || lnNumPayments < 2 || (lnNumPayments > 1 && lnLastPaymentRow == FixData.TVAmort.Rows[i].Field<int>("RowNumber"))))
                                {
                                    if ((lnPartialPayment + lnLastPartialPaymentBalance) >= lnLastLateFeeBalance)
                                    {
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", 0);
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnPartialPayment + lnLastPartialPaymentBalance - lnLastLateFeeBalance);
                                        lnLastPartialPaymentApplied = lnLastLateFeeBalance;
                                    }
                                    else
                                        if ((lnPartialPayment + lnLastPartialPaymentBalance) < lnLastLateFeeBalance)
                                    {
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", lnLastLateFeeBalance - (lnPartialPayment + lnLastPartialPaymentBalance));
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", 0);
                                        lnLastPartialPaymentApplied = lnPartialPayment + lnLastPartialPaymentBalance;
                                    }
                                    // Moses Newman 04/16/2018 Add saving of the amount of Partial Payment Balance used to pay down late charges.
                                    lnDeltaLC = FixData.TVAmort.Rows[i].Field<Decimal>("LateFeeBalance") - lnLastLateFeeBalance;
                                    lnDeltaPPB = FixData.TVAmort.Rows[i].Field<Decimal>("PartialPayment") - lnLastPartialPaymentBalance;
                                    lnLateFeePartial = lnPartialPayment > 0 ? lnPartialPayment : lnLastPartialPaymentBalance - FixData.TVAmort.Rows[i].Field<Decimal>("PartialPayment") + lnPartialPayment;
                                    if (lnPartialPayment < 0)
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("PrevPPBUsedLC", lnDeltaLC);
                                    else
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("PrevPPBUsedLC", lnDeltaPPB);
                                }
                                else
                                {
                                    if (lnPayAmount > 0)
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", lnLastLateFeeBalance);
                                    if (lnPayAmount > 0)
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnPartialPayment + lnLastPartialPaymentBalance > 0 ?
                                            lnPartialPayment + lnLastPartialPaymentBalance : 0);
                                    else // Moses Newman 11/15/2018 Handle partial for negative adjustment
                                    {
                                        if (lnPartialPayment > 0 && lsEvent != "INSUF" && !lbADJFound)  // Moses Newman 11/20/2018 ignore INSUF's!
                                            FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnPartialPayment);
                                        lbADJFound = false;
                                    }
                                }
                                FixData.TVAmort.Rows[i].SetField<DateTime>("PaidThrough", ldLastPaidThrough.AddMonths(lnPayments));
                            }
                            else  // WL
                            {
                                // Moses Newman 08/23/2018 If Wave Late Fee and Amount is <= Late Fee Balance
                                if (lnPayAmount <= lnLastLateFeeBalance)
                                {
                                    FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", lnLastLateFeeBalance - lnPayAmount);
                                    if (lnPayAmount < 0 && lnLastPPDueToLC > 0 && lnLastPartialPaymentBalance > 0)
                                    {
                                        if (lnLastPPDueToLC <= (lnPayAmount * -1))
                                        {
                                            if (lnLastPPDueToLC <= lnLastPartialPaymentBalance)
                                                FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnLastPartialPaymentBalance - lnLastPPDueToLC);
                                            else
                                                FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", 0);
                                        }
                                        else
                                        {
                                            if ((lnPayAmount * -1) <= lnLastPartialPaymentBalance)
                                                FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnLastPartialPaymentBalance + lnPayAmount);
                                            else
                                                FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", 0);
                                        }
                                        if ((lnLastPPDueToLC + lnPayAmount) >= 0)
                                            FixData.TVAmort.Rows[i].SetField<Decimal>("LastPPBUsedLC", lnLastPPDueToLC + lnPayAmount);
                                        else
                                            FixData.TVAmort.Rows[i].SetField<Decimal>("LastPPBUsedLC", 0);
                                    }
                                    else
                                        // Moses Newman 09/06/2018 Save partial previous partial payment
                                        FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnLastPartialPaymentBalance);
                                }
                                else  // Amount is greater than Late Fee Balance!
                                {
                                    FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnLastPartialPaymentBalance + lnPayAmount - lnLastLateFeeBalance);
                                    FixData.TVAmort.Rows[i].SetField<Decimal>("LastPPBUsedLC", lnLastPPDueToLC + lnPayAmount - lnLastLateFeeBalance);
                                    FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", 0);
                                }
                                FixData.TVAmort.Rows[i].SetField<DateTime>("PaidThrough", ldLastPaidThrough);
                                //TVAmortTableAdapter.Update(FixData.TVAmort);
                            }
                            break;
                        case "EXT":
                            FixData.TVAmort.Rows[i].SetField<DateTime>("PaidThrough", ldLastPaidThrough.AddMonths(FixData.TVAmort.Rows[i].Field<Int32>("ExtensionMonths")));
                            FixData.TVAmort.Rows[i].SetField<Decimal>("ContractStatus", lnContractStatus);
                            FixData.TVAmort.Rows[i].SetField<Decimal>("PartialPayment", lnLastPartialPaymentBalance);
                            FixData.TVAmort.Rows[i].SetField<Decimal>("LateFeeBalance", lnLastLateFeeBalance);
                            lnPayments = 0;
                            break;
                    }
                    if (i != FixData.TVAmort.Rows.Count - 1)
                    {
                        // Moses Newman 09/24/2018 Add lnLastBalance for todays balance compare in calculating number of payments.
                        lnLastBalance = FixData.TVAmort.Rows[i].Field<Decimal>("Balance");
                        if (i != 0)
                        {
							// Moses Newman 01/22/2020 Add rounding to two decimals on LateCharge and PartialPayments.
                            // Moses Newman 09/24/2018 Add lnLastBalance for todays balance compare in calculating number of payments.
                            lnLastBalance = FixData.TVAmort.Rows[i].Field<Decimal>("Balance");
                            lnLastLateFeeBalance = FixData.TVAmort.Rows[i].Field<Decimal?>("LateFeeBalance") == null ? 0 : Math.Round(FixData.TVAmort.Rows[i].Field<Decimal>("LateFeeBalance"),2);
                            // Moses Newman 10/10/2018 handle possible Null values.
                            lnLastPartialPaymentBalance = FixData.TVAmort.Rows[i].Field<Decimal?>("PartialPayment") == null ? 0 : Math.Round(FixData.TVAmort.Rows[i].Field<Decimal>("PartialPayment"),2);
                            lnLastPPDueToLC = FixData.TVAmort.Rows[i].Field<Decimal?>("LastPPBUsedLC") == null ? 0 : Math.Round(FixData.TVAmort.Rows[i].Field<Decimal>("LastPPBUsedLC"),2);
                            ldLastPaidThrough = FixData.TVAmort.Rows[i].Field<DateTime>("PaidThrough");
                            ltsDateDiff = FixData.TVAmort.Rows[i].Field<DateTime>("PaidThrough") - FixData.TVAmort.Rows[i].Field<DateTime>("Date");
                            lnDateDiff = (Int32)ltsDateDiff.TotalDays;
                            lnDateDiff /= 30;
                            // Moses Newman 09/25/2018 If Loan already payed off Contract Status = Partial Payment Balance
                            if (lnLastBalance > 0)
                                lnContractStatus = lnDateDiff * lnRegular + lnLastPartialPaymentBalance - lnLastLateFeeBalance;
                            else
                                lnContractStatus = lnLastPartialPaymentBalance;
                            ltsDateDiff = ldFirstPaymentDate - FixData.TVAmort.Rows[i].Field<DateTime>("PaidThrough");
                            lnNewDiff = (Int32)ltsDateDiff.TotalDays;
                            if (lnNewDiff == 1 && FixData.TVAmort.Rows[i].Field<DateTime>("Date") < ldFirstPaymentDate)
                                lnContractStatus = 0;
                            // Moses Newman 09/25/2018 Don't mess with contract status if loan is paid off!
                            if (lnLastBalance > 0)
                                if (lnContractStatus > FixData.TVAmort.Rows[i].Field<Decimal>("Balance"))
                                    lnContractStatus = FixData.TVAmort.Rows[i].Field<Decimal>("Balance");
                                else
                                    if (lnContractStatus < 0)
                                        if (lnContractStatus * -1 > FixData.TVAmort.Rows[i].Field<Decimal>("Balance"))
                                            lnContractStatus = FixData.TVAmort.Rows[i].Field<Decimal>("Balance") * -1;
                            FixData.TVAmort.Rows[i].SetField<Decimal>("ContractStatus", lnContractStatus);
                            if (lsEvent == "BUYOUT" || lsEvent == "UNEARNED")
                                FixData.TVAmort.Rows[i].SetField<Decimal>("ContractStatus", FixData.TVAmort.Rows[i - 1].Field<Decimal>("ContractStatus"));
                        }
                    }
                }
            }
            TVAmortTableAdapter.Update(FixData.TVAmort);
        }

        // Moses Newman 04/11/2018 move here and make uniform thtorught application!
        public static DateTime NextDueDate(int CustomerPos, IACDataSet Bank)
        {
            DateTime ldNewPaidThru;
            // Moses Newman 12/19/2013 CUSTOMER_PAID_THRU_MM and CUSTOMER_PAID_THRU_YY are now computed fields so no need to set!
            if (Bank.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && Convert.ToInt32(Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_MM")) == 2)
            {
                ldNewPaidThru = Convert.ToDateTime("03/1/" + DateTime.Now.Year.ToString().Substring(0, 2) + Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
                ldNewPaidThru = ldNewPaidThru.AddDays(-1); // Force Date to proper February Date!
            }
            else
                ldNewPaidThru = Convert.ToDateTime(Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_MM") + "/" + Bank.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE").ToString().TrimStart() + "/" + DateTime.Now.Year.ToString().Substring(0, 2) + Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
            // Moses Newman 04/11/2018 Make sure if paidthrough is 2/28/yyyy that new paidthrough is 3/30/yyyy and NOT 3/28/yyyy or 3/29/yyyy!
            if (ldNewPaidThru == Convert.ToDateTime("03/1/" + DateTime.Now.Year.ToString().Substring(0, 2) + Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY")).Date.AddDays(-1))
            {
                ldNewPaidThru = ldNewPaidThru.AddMonths(1);     // Add 1 to get next Due Date.
                ldNewPaidThru = ldNewPaidThru.AddDays(30 - ldNewPaidThru.Day);     // Add 1 to get next Due Date.
            }
            else
                ldNewPaidThru = ldNewPaidThru.AddMonths(1);     // Add 1 to get next Due Date.
            return ldNewPaidThru;
        }

        // Moses Newman 04/11/2018 move here and make uniform thtorught application!
        public static DateTime OpenNextDueDate(int CustomerPos, IACDataSet Bank)
        {
            DateTime ldNewPaidThru;
            // Moses Newman 12/19/2013 CUSTOMER_PAID_THRU_MM and CUSTOMER_PAID_THRU_YY are now computed fields so no need to set!
            if (Bank.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && Convert.ToInt32(Bank.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_MM")) == 2)
            {
                ldNewPaidThru = Convert.ToDateTime("03/1/" + DateTime.Now.Year.ToString().Substring(0, 2) + Bank.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
                ldNewPaidThru = ldNewPaidThru.AddDays(-1); // Force Date to proper February Date!
            }
            else
                ldNewPaidThru = Convert.ToDateTime(Bank.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_MM") + "/" + Bank.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE").ToString().TrimStart() + "/" + DateTime.Now.Year.ToString().Substring(0, 2) + Bank.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
            // Moses Newman 04/11/2018 Make sure if paidthrough is 2/28/yyyy that new paidthrough is 3/30/yyyy and NOT 3/28/yyyy or 3/29/yyyy!
            if (ldNewPaidThru == Convert.ToDateTime("03/1/" + DateTime.Now.Year.ToString().Substring(0, 2) + Bank.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY")).Date.AddDays(-1))
            {
                ldNewPaidThru = ldNewPaidThru.AddMonths(1);     // Add 1 to get next Due Date.
                ldNewPaidThru = ldNewPaidThru.AddDays(30 - ldNewPaidThru.Day);     // Add 1 to get next Due Date.
            }
            else
                ldNewPaidThru = ldNewPaidThru.AddMonths(1);     // Add 1 to get next Due Date.
            return ldNewPaidThru;
        }

		// Moses Newman 12/18/2019 set exception if email address passed is NOT the correct format.
		public static bool IsValidEmail(string email, ref String errmsg)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				errmsg = "";
				return addr.Address == email;
			}
			catch (System.FormatException e)
			{
				errmsg = e.Message;
				return false;
			}
		}

		// Moses Newman 12/18/2019 generic Email Address Validator
		public static void EmailValidator(ref object sender, ref CancelEventArgs e,ref ErrorProvider errmsg)
		{
			String msg = "";
			errmsg.SetError((TextBox)sender, "");
			if (((TextBox)sender).Text.Trim() == "")
			{
				return;
			}
			if (!Program.IsValidEmail(((TextBox)sender).Text.Trim(), ref msg))
			{
				e.Cancel = true;
				errmsg.SetError((TextBox)sender, msg);
			}
			else
			{
				errmsg.SetError((TextBox)sender, "");
				e.Cancel = false;
			}
			return;
		}

		public static void ReplaceMailMergeField(ref Word._Document doc, ref Word.Application app,string msWordFileName, string FieldName, string FieldDesiredValue)
		{			
			foreach (Word.Field f in doc.Fields)
			{
				if (f.Code.Text.IndexOf(FieldName) > -1)
				{
					f.Code.Text = FieldDesiredValue;
					f.Update();
				}
			}
		}

		static public String PostFile(String fileToPost)
		{
			String uploadedFileName = String.Empty;

			var request = new RestRequest("api/files/", Method.POST);
			request.AddFile("File", fileToPost);
			var response = ApiClient.Execute(request);

			if (response.StatusCode != HttpStatusCode.OK)
			{
				throw new Exception("Unable to upload file: " + response.Content);
			}
			//for some reason the restsharp deserializer is having trouble with this object
			var uploadedFiles = JsonConvert.DeserializeObject<UploadedFileList>(response.Content);
			uploadedFileName = uploadedFiles.files[0].name;

			return uploadedFileName;
		}

		static public void IndexDocument(Int32 DatabaseID, Int32 ArchiveID, List<FieldItem> FieldData, String UploadedFileName, String Token)
		{
			//load up our data
			var indexData = new Indexer();
			indexData.files.Add(new S9API.Models.File(UploadedFileName));

			if (FieldData != null && FieldData.Count > 0)
			{
				foreach (FieldItem field in FieldData)
				{
					var fieldItem = new Field(field.ID.ToString(), field.VAL);
					indexData.fields.Add(fieldItem);
				}
			}

			var request = new RestRequest("api/dbs/{db}/archives/{arch}?token={token}", Method.POST);
			request.AddParameter("token", Token, ParameterType.UrlSegment); //have to specifiy type on POST
			request.AddParameter("db", DatabaseID, ParameterType.UrlSegment);
			request.AddParameter("arch", ArchiveID, ParameterType.UrlSegment);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(indexData);

			var response = ApiClient.Execute(request);
			if (response.StatusCode != HttpStatusCode.OK)
			{
				throw new Exception("Unable to index document: " + response.Content);
			}
		}



		static public String GetLicense()
		{
			var request = new RestRequest("api/licenses");
			var license = ApiClient.Execute<S9API.Models.License>(request);
			if (license.StatusCode != HttpStatusCode.OK)
			{
				if (license.StatusCode == HttpStatusCode.Unauthorized)
				{
					throw new Exception("Unable to get a License: The passed user is Unauthorized.");
				}
				else if (license.StatusCode == HttpStatusCode.BadRequest)
				{
					throw new Exception("Unable to get a License: " + license.Content);
				}
				else if (license.StatusCode == HttpStatusCode.NotFound)
				{
					throw new Exception("Unable to get a License: Unable to connect to the license server, server not found.");
				}
				else
				{
					throw new Exception("Unable to get a License: " + license.Content);
				}
			}
			return license.Data.Token;
		}

		static public void ReleaseLicense(String Token)
		{
			var request = new RestRequest("api/licenses/" + Token);
			var response = ApiClient.Execute(request);
			if (response.ErrorException != null)
			{
				throw new Exception("Unable to release license token. ", response.ErrorException);
			}
			else if (response.StatusCode != HttpStatusCode.OK)
			{
				throw new Exception("Unable to release license token. " + response.Content);
			}
		}


		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MDIIAC2013());
		}
	}
}

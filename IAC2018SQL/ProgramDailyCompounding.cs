using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;



namespace IAC2013SQL 
{
	static class Program
	{
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
            cfm.ComputeMethod = TValueEngineLib.TVComputeMethod.TVUSRuleAmortization;
			// Set the compounding to Monthly.
			if (tbSimple)
				cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVExactDaysCompound;
			else
				cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVMonthlyCompound;

			// Use a 365 day year from now on.
            if(tbSimple)
                cfm.YearLength = TValueEngineLib.TVYearLength.TVYearLength365;
            else
                // Old side used 360 day year.
                cfm.YearLength = TValueEngineLib.TVYearLength.TVYearLength360;

			// Use Normal (compounded) compute method if NOT Simple Interest else Use US Rule Amortization
			//if (tbSimple)
			  //  cfm.ComputeMethod = TValueEngineLib.TVComputeMethod.TVUSRuleAmortization;
			//else
                cfm.ComputeMethod = TValueEngineLib.TVComputeMethod.TVUSRuleAmortization;

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
				CUSTHISTBindingSource.DataSource = DTPayStream;
				CUSTHISTBindingSource.AddNew();
				CUSTHISTBindingSource.EndEdit();
				DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", tcCustomer);
				DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", tdsAmortDT.PAYMENT[tnPaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
				DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_TYPE", tdsAmortDT.PAYMENT[tnPaymentPos].Field<String>("PAYMENT_TYPE"));
				DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_CODE", tdsAmortDT.PAYMENT[tnPaymentPos].Field<String>("PAYMENT_CODE_2"));
                // Moses Newman 03/22/2013 Add sequence number at Max Value so no chance of newly added payment interfereing with any other history transactions 
                // for the same date.
                // Moses Newman 8/4/2013 No longer use 999 as sequence number, we simply  add 1 to existing!
                // Moses Newman 12/2/2013 Fixed overly complex after the fact payment date change on ISFs
                if (tdsAmortDT.PAYMENT[tnPaymentPos].Field<String>("PAYMENT_TYPE") != "I")
                {
                    loSeqNo = CUSTHISTTableAdapter.SeqNoQuery(tcCustomer, tdsAmortDT.PAYMENT[tnPaymentPos].Field<DateTime>("PAYMENT_DATE"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", tdsAmortDT.PAYMENT[tnPaymentPos].Field<DateTime>("PAYMENT_DATE"));
                }
                else
                {
                    loSeqNo = CUSTHISTTableAdapter.SeqNoQuery(tcCustomer, tdsAmortDT.PAYMENT[tnPaymentPos].Field<DateTime>("PAYMENT_ISF_DATE"));
                    DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", tdsAmortDT.PAYMENT[tnPaymentPos].Field<DateTime>("PAYMENT_ISF_DATE"));
                }
                if (loSeqNo != null)
                    lnSeqNo = (Int32)loSeqNo +1;
                else
                    lnSeqNo = 1;
                DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeqNo);
                DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<DateTime>>("CUSTHIST_ISF_DATE", tdsAmortDT.PAYMENT[tnPaymentPos].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE"));
                DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Decimal>>("CUSTHIST_CURR_INT", tdsAmortDT.PAYMENT[tnPaymentPos].Field<Nullable<Decimal>>("PAYMENT_CURR_INT"));
                DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Decimal>>("CUSTHIST_LATE_CHARGE_PAID", tdsAmortDT.PAYMENT[tnPaymentPos].Field<Nullable<Decimal>>("PAYMENT_LATE_CHARGE_PAID"));
                DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Boolean>>("IsSimple", tdsAmortDT.PAYMENT[tnPaymentPos].Field<Nullable<Boolean>>("IsSimple"));
                //  Moses Newman 06/28/2016 add paycode to markpay call so IVR will show if IVR!
                DTPayStream.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", Program.MarkPay(CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_ACT_STAT"), tdsAmortDT.PAYMENT[tnPaymentPos].Field<String>("PAYMENT_TYPE"), tdsAmortDT.PAYMENT[tnPaymentPos].Field<String>("PAYMENT_CODE_2")));
				CUSTHISTBindingSource.EndEdit();
			}
            // Moses Newman 12/2/2013 Removed after the fact payment date change on ISFs
            // Now create sorted DataView of CUSTHIST DataTable (Memory Only)
            DataView SortedPayStream = new DataView(DTPayStream, "", "CUSTHIST_PAY_DATE,CUSTHIST_DATE_SEQ", DataViewRowState.CurrentRows);
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
                            if (DTPayStream.Rows[i].Field<String>("CUSTHIST_PAY_REM_1").TrimEnd() != "UPD")
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
				
                cfmEvent.EventDate = DTPayStream.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE");
                // Moses Newman 02/10/2013 Set Payoff Date =  final payment if a paid loan
                if (DTPayStream.Rows[i].Field<String>("CUSTHIST_PAY_REM_1").TrimEnd() == "PAID" && CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_BUY_OUT") == "Y")
                    tdPayoffDate = DTPayStream.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE");
				if(DTPayStream.Rows[i].Field<String>("CUSTHIST_PAYMENT_TYPE") != "F")
                    cfmEvent.EventNumber = 1;
			}
			
			// Create a cash flow line for the payoff date and unknown payment amount
			cfmEvent = cfm.CreateNewEvent(-1);
			cfmEvent.EventType = TValueEngineLib.TVEventType.TVUserPaymentEvent3;
			// Always use month end date for buyout amount!
			if (tbEOM && CUSTOMERDT.Rows[0].Field<String>("CUSTOMER_BUY_OUT") != "Y")
			{
				tdPayoffDate = Convert.ToDateTime(tdPayoffDate.Month.ToString() + "/01/" + tdPayoffDate.Year.ToString()).AddMonths(1);
				tdPayoffDate = tdPayoffDate.AddDays(-1);
			}
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
			if (tbSimple)
				cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVDailyCompound;
			else
				cfm.Compounding = TValueEngineLib.TVCompoundPeriod.TVMonthlyCompound;


			// Use a 365 day year.
			if(tbSimple)
				cfm.YearLength = TValueEngineLib.TVYearLength.TVYearLength365;
			else
				cfm.YearLength = TValueEngineLib.TVYearLength.TVYearLength360;

			// Use Normal (compounded) compute method if NOT Simple Interest else Use US Rule Amortization
			//if (tbSimple)
				//cfm.ComputeMethod = TValueEngineLib.TVComputeMethod.TVUSRuleAmortization;
			//else
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
			DateTime eventDate;
			decimal[] dataArray;
			object varDataArray;
			double rateChangeRate; 
			TValueEngineLib.TVCompoundPeriod rateChangeCompounding;
			IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
			IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
			TVAmortTableAdapter.DeleteByCustonerNo(tcCustomer);
			Int32 AmortIndex = 0;
			TVAmortDT.Clear();
			CUSTOMERTableAdapter.Fill(CustomerDT, tcCustomer);
			for (Int32 index = 0; index < cfm.AmortizationScheduleSize; index++)
			{
				// Get the next amortization line
				cfm.GetAmortizationData(index, out lineType, out sequenceNumber, out eventDate, out varDataArray, out rateChangeRate, out rateChangeCompounding);

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
									break;
							}
						}
						AmortIndex += 1; 
						dr["Date"] = eventDate;
						dr["Interest"] = dataArray[TValueDefines.AmortInterestAccruedIndex];
						dr["Principal"] = dataArray[TValueDefines.AmortPrincipalPaidIndex];
						dr["Balance"] = dataArray[TValueDefines.AmortTotalBalanceIndex];
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
			tableAdapConn.ConnectionString = IAC2013SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
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
				if (CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "Y" ||
					CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "S")
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
					if (CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "Y" ||
						CustomerPostDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND").ToUpper() == "S")
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
				String lsConnect = IAC2013SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsFilePath = "";
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

			String lsConnect = IAC2013SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsFilePath = "";

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


		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MDIIAC2013());
		}
	}
}

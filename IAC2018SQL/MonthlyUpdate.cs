using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class frmMonthlyupdate : Form
    {
        String lsProgress = "";
        Decimal lnMonthToDateInterest = 0,lnLastBalance = 0;
        Decimal gnDeltaOSLoans = 0, gnDeltaInterest = 0;
        DateTime ldLastRun,ldNewRun;

        QueryProgress lfrm;

        BackgroundWorker worker;

        BindingSource CustomerBindingSource = new BindingSource();

        ClosedPaymentPosting CPaymentPost = new ClosedPaymentPosting();

        IACDataSetTableAdapters.SystemTableAdapter SystemTableAdapter = new IACDataSetTableAdapters.SystemTableAdapter();
        IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
        IACDataSetTableAdapters.TVAmortMonthlyTableAdapter TVAmortMonthlyTableAdapter = new IACDataSetTableAdapters.TVAmortMonthlyTableAdapter();

        BindingSource   CUSTHISTBindingSource = new BindingSource(),
                                DEALHISTBindingSource = new BindingSource(),
                                MASTERBindingSource = new BindingSource(),
                                MASTHISTBindingSource = new BindingSource();


        public frmMonthlyupdate()
        {
            InitializeComponent();
        }

        private void frmMonthlyupdate_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }

        private void PostMonthlyUpdate()
        {
            // Moses Newman 01/29/2015 Add Call to GetPartialPaymentandLateFeeBalance to correctly calculate PaidThroughs, Late Fees,
            // CUSTOMER_CONTRACT_STATUS etc.
            ClosedPaymentPosting CP = new ClosedPaymentPosting();
            // Moses Newman 04/02/2018 Use to update CUSTHIST last record later
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            DateTime ldTempLastRun;
            String lsLastRun = "";
            int lnProgress = 0,lnTotalSteps = 0;

            SystemTableAdapter.Fill(UpdateiacDataSet.System,1);

            ldLastRun = UpdateiacDataSet.System.Rows[0].Field<DateTime>("LastUpdateDate");

            // Was it run more than once in one month
            if (ldLastRun >= DateTime.Now.Date)
                return;

            lsLastRun = ldLastRun.ToShortDateString();
            lsLastRun = ldLastRun.Month.ToString().PadLeft(2, '0') + "/01/" +
                        ldLastRun.Year.ToString();

            ldTempLastRun = Convert.ToDateTime(lsLastRun);

            ldNewRun = ldTempLastRun.AddMonths(2);
            ldNewRun = ldNewRun.AddDays(-1).Date;

            CustomerBindingSource.DataSource = UpdateiacDataSet.CUSTOMER;

            // Moses Newman 07/17/2013 Changed Stored Procedure to include Inactive customers who became Inactive this period.
            customerTableAdapter.FillByUpdateable(UpdateiacDataSet.CUSTOMER, ldLastRun, ldNewRun);

            if (UpdateiacDataSet.CUSTOMER.Rows.Count == 0)
            {
                MessageBox.Show("There are no customers that need to be updated!");
                TVAmortTableAdapter.Dispose();
                return;
            }

            TVAmortTableAdapter.DeleteAll();
            TVAmortMonthlyTableAdapter.DeleteAllByMonthEnd(ldNewRun);

            lnTotalSteps = UpdateiacDataSet.CUSTOMER.Rows.Count + 2;
            for (int i = 0; i < UpdateiacDataSet.CUSTOMER.Rows.Count; i++)
            {
                // Moses Newman 11/29/2020 Removed top of job function and put contents here.
                // Moses Newman removed init date filter that was blocking new buisness.
                UpdateiacDataSet.CUSTOMER.Rows[i].SetField<Int32>("CUSTOMER_UPD_COUNT", UpdateiacDataSet.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_UPD_COUNT") + 1);
                // Moses Newman 2020/11/29 Make sure to store previous CUSTOMER_BALANCE!
                UpdateiacDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_PREV_BALANCE", UpdateiacDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
                CustomerHistory(i);

                TVAmortTableAdapter.FillByCustomerNo(UpdateiacDataSet.TVAmort, UpdateiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                for (Int32 j = 0; j < UpdateiacDataSet.TVAmort.Rows.Count; j++)
                {
                    TVAmortMonthlyTableAdapter.Insert(ldNewRun,
                        UpdateiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Int32>("RowNumber"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<String>("Event"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<DateTime>("Date"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("New"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("LateFee"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("ISF"),
                        // Moses Newman 07/31/2013 Add Non Cash Fees to Amort
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("NonCash"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("Payment"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("Interest"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("Principal"),
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("Balance"),
                        // Moses Newman 10/23/2013 Added new field for Rate Change Events
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Nullable<Decimal>>("RateChange") != null ? UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("RateChange") : (Nullable<Decimal>)null,
                        // Moses Newman 12/3/2014 Added LateFeeBalance, PaidThrough, and ExtensionMonths for history resets.
                        // Moses Newman 12/4/2014 Added Partial Payment
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Nullable<Decimal>>("PartialPayment") != null ? UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("PartialPayment") : (Nullable<Decimal>)null,
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Nullable<Decimal>>("LateFeeBalance") != null ? UpdateiacDataSet.TVAmort.Rows[j].Field<Decimal>("LateFeeBalance") : (Nullable<Decimal>)null,
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Nullable<DateTime>>("PaidThrough") != null ? UpdateiacDataSet.TVAmort.Rows[j].Field<DateTime>("PaidThrough") : (Nullable<DateTime>)null,
                        UpdateiacDataSet.TVAmort.Rows[j].Field<Nullable<Int32>>("ExtensionMonths") != null ? UpdateiacDataSet.TVAmort.Rows[j].Field<Int32>("ExtensionMonths") : (Nullable<Int32>)null);
                }
                // Moses Newman 01/29/2015 Add Call to GetPartialPaymentandLateFeeBalance to correctly calculate PaidThroughs, Late Fees,
                // CUSTOMER_CONTRACT_STATUS etc.
                lsProgress = "*** Working on customer number: " + UpdateiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO");
                try
                {
                    CP.GetPartialPaymentandLateFeeBalance(ref worker, UpdateiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), ref UpdateiacDataSet, i, false, -1, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Messaqge: " + ex.Message + "\nBlew up in GetPartialPaymentandLateFeeBalance customer#: " + UpdateiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                }
                // Moses Newman 04/02/2018 Update Last CUSTHIST record!
                CUSTHISTTableAdapter.UpdateLastRecord(UpdateiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                //CP.ResetHistoryPaidThroughandLateChargeBalance(ref worker, UpdateiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                lnProgress = (Int32)(Math.Round(((Double)i / (Double)lnTotalSteps), 2) * 100);
                worker.ReportProgress(lnProgress);
            }
            CUSTHISTBindingSource.DataSource = UpdateiacDataSet.System;
            UpdateiacDataSet.System.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("LastUpdateDate", ldNewRun);
            CUSTHISTBindingSource.EndEdit();
            MonthlyUpdateDealerPost();
            MonthlyUpdateMasterPost();
            MonthlyUpdateMASTHISTPost();
            TVAmortMonthlyTableAdapter.Dispose();
            TVAmortTableAdapter.Dispose();
            SystemTableAdapter.Update(UpdateiacDataSet.System.Rows[0]);
            CP.Dispose();
            CP = null;
        }

        private void WriteCustomer(Int32 CustomerPos)
        {
            UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_PT_UPDATE", DateTime.Now.Date.Year.ToString().Substring(2, 2) + DateTime.Now.Date.Month.ToString().TrimStart().PadLeft(2, '0'));
            if (UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<Int32>>("CUSTOMER_NUMBER_OF_MONTHS") != null)
                UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_NUMBER_OF_MONTHS", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_NUMBER_OF_MONTHS") + 1);
            else
                UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_NUMBER_OF_MONTHS", 1);
            CustomerBindingSource.EndEdit();
            customerTableAdapter.Update(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos]);
            UpdateiacDataSet.CUSTOMER.AcceptChanges();

        }

        private void UpdateStatus(Int32 CustomerPos)
        {
            // 12/9/2011 Moses Newman Changed to use the same NewContractStatus as ClosedPaymentPosting
            ClosedPaymentPosting CPPosting = new ClosedPaymentPosting();
            CPPosting.ClosedPaymentNewContractStatus(CustomerPos, ref UpdateiacDataSet);
        }

        private void CustomerHistory(Int32 CustomerPos)
        {
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            BindingSource CUSTHISTBindingSource = new BindingSource();

            Int32 lnSeq = 0;
            Object loCustHistSeq = null, loIntPaid = null, loPrincipalChange = null, loStartingBalance = null, loNewBusiness = null, loPayments = null, loISFFees = null, loLateFees = null,
                   loNonCashFees = null,
                   // Moses Newman 11/08/2020 Added Revised Balance to be used to calculate change in starting balance due to bounced check(S)
                   loRevisedBalance = null;
            Decimal lnPrincipalChange = 0, lnPayments = 0, lnNewBusiness= 0, lnLateFees = 0, lnISFFees = 0, lnNonCashFees = 0,lnRevisedBalance = 0,lnChangeDueToInsuf = 0;
            DateTime ldSeqDate;

            CUSTHISTBindingSource.DataSource = UpdateiacDataSet.CUSTHIST;

            CUSTHISTBindingSource.AddNew();
            CUSTHISTBindingSource.EndEdit();
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ADD_ON", "");
            // Moses Newman 07/18/2013 Make Pay Date Last Payment Date if deal payed off in the middle of this period.
            ldSeqDate = ldNewRun;
            if (UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT") == "A")
                UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", ldNewRun);
            else
            {
                UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<DateTime>("CUSTOMER_LAST_PAYMENT_DATE"));
                ldSeqDate = UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<DateTime>("CUSTOMER_LAST_PAYMENT_DATE");
            }
            // Moses Newman 03/15/2018 Add TransactionDate, Fee, FromIVR
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("TransactionDate",UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].Field<DateTime>("CUSTHIST_PAY_DATE"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("Fee",0);
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Boolean>("FromIVR",false);
            // Moses Newman 07/18/2013 Use unused ISF Date [not used in UPD records] to store actual month end date so that we have the same date even for mid month payoffs
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_ISF_DATE", ldNewRun);
            // Moses Newman 07/18/2013 use temdate ldSeqDate in case we are posting an update record to a mid month payoff otherwise a key violation will occur
            loCustHistSeq = CUSTHISTTableAdapter.SeqNoQuery(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), ldSeqDate);
            if (loCustHistSeq != null)
                lnSeq = (int)loCustHistSeq + 1;
            else
                lnSeq = 1;
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_IAC_TYPE", "C");
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", 0);
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", 0);
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "UPD");
            CUSTHISTBindingSource.EndEdit();
            CUSTHISTTableAdapter.Update(UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position]);
            // Moses Newman 07/01/2013 Changed date parameter to last month because buyout is at end of last month not end of new month Since we are closing as of the 1st!
            // Moses Newman 06/25/2014 Changed tbSave to false so saving TV5's does not slow down processing
            CPaymentPost.ClosedPaymentCalculatebuyout(-1, CustomerPos, ref UpdateiacDataSet, ref worker, ldNewRun.ToShortDateString(),false,true);
            UpdateStatus(CustomerPos);
            UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT"));
            // Moses Newman 06/25/2014 Make sure no of payments made, and remaining payments are not NULL!
            if (UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<Int32>>("CUSTOMER_PAY_REM_2") == null)
                UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_PAY_REM_2", 0);
            if (UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<Int32>>("CUSTOMER_NO_OF_PAYMENTS_MADE") == null)
                UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
            WriteCustomer(CustomerPos);
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU").TrimStart().TrimEnd().PadLeft(4,'0'));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_BUY_OUT", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_BUY_OUT"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_PAY_REM_2", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_PAY_REM_2"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));

            lnMonthToDateInterest = 0;                         
            loIntPaid =  TVAmortTableAdapter.InterestSinceLastUpdate(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), 
                                             ldLastRun, ldNewRun);

            // Moses Newman 07/12/2013 Created new StartingBalance stored procedure so that would not have issues with New business current period.
            // Moses Newman 12/10/2013 Never needed ldNewRun for starting balance so remove it from new stored procedure.
            // Moses Newman 12/10/2013 Rewrote TVAmortStartingBalance stored procedure to use TVAmortMonthly for last month, to fix issue with ISFs for checks posted last month.
            loStartingBalance  = TVAmortTableAdapter.StartingBalance(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), ldLastRun);
            loPrincipalChange = TVAmortTableAdapter.PrincipalSinceLastUpdate(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                             ldLastRun, ldNewRun);
            loNewBusiness = TVAmortTableAdapter.NewBusiness(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                             ldLastRun, ldNewRun);
            loPayments = TVAmortTableAdapter.Payments(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                             ldLastRun, ldNewRun);
            loLateFees = TVAmortTableAdapter.LateFees(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                             ldLastRun, ldNewRun);
            loISFFees = TVAmortTableAdapter.ISFFees(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                             ldLastRun, ldNewRun);
            // Moses Newman 07/31/2013 Add Non Cash Fees to Amort
            loNonCashFees = TVAmortTableAdapter.NonCashFees(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                             ldLastRun, ldNewRun);

            lnLastBalance = (loStartingBalance != null) ? (Decimal)loStartingBalance:0;

            // Moses Newman 11/08/2020 Add revised balance to be used to calculate change in starting balance due to bounced check(s).
            loRevisedBalance = TVAmortTableAdapter.RevisedBalance(UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), ldLastRun);
            lnRevisedBalance = (loRevisedBalance != null) ? (Decimal)loRevisedBalance : lnLastBalance;

            if (loIntPaid != null)
                lnMonthToDateInterest = (Decimal)loIntPaid;
            if (loNewBusiness != null)
                lnNewBusiness = (Decimal)loNewBusiness;
            else
                lnNewBusiness = 0;
            if (loPayments != null)
                lnPayments = (Decimal)loPayments;
            else
                lnPayments = 0;
            if (loLateFees != null)
                lnLateFees = (Decimal)loLateFees;
            else
                lnLateFees = 0;
            if (loISFFees != null)
                lnISFFees = (Decimal)loISFFees;
            else
                lnISFFees = 0;
            // Moses Newman 07/31/2013 Add Non Cash Fees to Amort
            if (loNonCashFees != null)
                lnNonCashFees = (Decimal)loNonCashFees;
            else
                lnNonCashFees = 0;

            // Moses Newman 11/08/2020 Add Change Due To INSUF
            lnChangeDueToInsuf = (lnRevisedBalance - lnLastBalance != 0) ? lnRevisedBalance - lnLastBalance : 0;

            // Moses Newman 07/12/2013 Created new StartingBalance stored procedure so that would not have issues with New business current period.
            //if (loPrincipalChange != null)
            //    lnPrincipalChange = (Decimal)loPrincipalChange;

            lnPrincipalChange = lnLastBalance - UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
            //lnLastBalance = UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") + lnPrincipalChange;
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_CHARGE", lnMonthToDateInterest);
            // Moses Newman 12/15/2020 Store REAL CUSTOMER_PREV_BALANCE into CUSTHIST_PREV_BALANCE!
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PREV_BALANCE", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PREV_BALANCE"));
            // Moses Newman 12/15/2020 Add LastMonthEndBalance
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("LastMonthEndBalance", lnLastBalance);
            // Moses Newman 12/15/2020 Add ChangeDueToISF No longer use CUSTHIST_PAID_DISCOUNT!
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("ChangeDueToISF", lnChangeDueToInsuf);
            // Moses Newman 12/15/2020 Store 211 card update amount in new MonthEndBalanceChange field!
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("MonthEndBalanceChange", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PREV_BALANCE"));

            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_TD_FINANCE_CHARGE", -1 * lnPrincipalChange);
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BUYOUT", UpdateiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT"));
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_PAID", lnNewBusiness);
            // Moses Newman 07/19/2013 Changed CUSTHIST_PAYMENT_RCV to CUSTHIST_PAID so that total months payments don't appear as a new payment in amort!
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID", lnPayments);
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", lnLateFees);
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CURR_INT", lnISFFees);
            // Moses Newman 07/31/2013 Add Non Cash Fees to Amort
            UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_YTD_LATE_CHARGE", lnNonCashFees);

            CUSTHISTBindingSource.EndEdit();
            CUSTHISTTableAdapter.Update(UpdateiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position]);
        }

        void MonthlyUpdateDealerPost()
        {

            int DEALERPos = 0;
            Decimal DeltaOSLoans = 0;
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.MonthlyUpdateTotalsByDealerTableAdapter MonthlyUpdateTotalsByDealerTableAdapter = new IACDataSetTableAdapters.MonthlyUpdateTotalsByDealerTableAdapter();

            DEALERTableAdapter.FillByUpdates(UpdateiacDataSet.DEALER,ldNewRun);
            for (Int32 dlrCount = 0; dlrCount < UpdateiacDataSet.DEALER.Rows.Count; dlrCount++)
            {
                DEALERPos = dlrCount;
                if (DEALERPos > -1)
                {
                    if (UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Nullable<Decimal>>("DEALER_CUR_OLOAN") == null)
                        UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLOAN", 0);
                    if (UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Nullable<Decimal>>("DEALER_YTD_OLOAN") == null)
                        UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_YTD_OLOAN", 0);
                    MonthlyUpdateTotalsByDealerTableAdapter.Fill(UpdateiacDataSet.MonthlyUpdateTotalsByDealer, UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<String>("DEALER_ACC_NO"));
                    if (UpdateiacDataSet.MonthlyUpdateTotalsByDealer.Rows.Count > 0)
                        DeltaOSLoans = UpdateiacDataSet.MonthlyUpdateTotalsByDealer.Rows[0].Field<Decimal>("Balance") - UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLOAN");
                    else
                        DeltaOSLoans = 0;
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_RSV", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_CONT", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLOAN", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_ADJ", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_BAD", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_LOSS", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_AMORT_INT", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_SIMPLE_INT", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLD_INT", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_AMORT_PDI", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_SIMPLE_PDI", 0);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLD_PDI", 0);

                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLOAN", DeltaOSLoans);
                    if(UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Nullable<Decimal>>("DEALER_YTD_OLOAN") != null)
                        UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_YTD_OLOAN", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLOAN") + DeltaOSLoans);
                    else
                        UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_YTD_OLOAN", DeltaOSLoans);
                    UpdateiacDataSet.DEALER.Rows[DEALERPos].SetField<DateTime>("DEALER_POST_DATE", ldNewRun);
                    DEALERTableAdapter.Update(UpdateiacDataSet.DEALER.Rows[DEALERPos]);
                    MonthlyUpdateDEALHISTPost(DEALERPos);
                }
            }
            worker.ReportProgress(12);
        }

        void MonthlyUpdateDEALHISTPost(int DEALERPos)
        {
            // Moses Newman 11/7/2013 Fix -1 Sequence NO issue 
            Int32 DEALHISTPos = 0,lnSeq = 0;
            Object loDealhistSeq = null;

            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.DEALHISTTableAdapter DEALHISTTableAdapter = new IACDataSetTableAdapters.DEALHISTTableAdapter();

            DEALHISTBindingSource.DataSource = UpdateiacDataSet.DEALHIST;

            DEALHISTBindingSource.AddNew();
            DEALHISTBindingSource.EndEdit();

            DEALHISTPos = DEALHISTBindingSource.Position;

            if (DEALHISTPos > -1)
            {
                // Set up the new history record key
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<String>("DEALHIST_ACC_NO", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<String>("DEALER_ACC_NO"));
                // Moses Newman 12/31/2013 Fix DEALHIST_LAST_POST_DATE to be the same as post date since other transactions most likely accured today!
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<DateTime>("DEALHIST_POST_DATE", ldNewRun);
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<DateTime>("DEALHIST_LAST_POST_DATE", ldNewRun);
                // Moses Newman 11/7/2013 add sequence number
                // Moses Newman 12/31/2013 Fix DEALHIST_LAST_POST_DATE to be the same as post date since other transactions most likely accured today!
                loDealhistSeq = DEALHISTTableAdapter.SeqNoQuery(UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].Field<String>("DEALHIST_ACC_NO"), ldNewRun, ldNewRun);
                if (loDealhistSeq != null)
                    lnSeq = (int)loDealhistSeq + 1;
                else
                    lnSeq = 0;
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
                // Moses Newman 11/7/2013 Add Sequence Number to fix Monthly Update Issue
                // End of DEALHIST KEY
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<String>("DEALHIST_NAME", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<String>("DEALER_NAME"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_ADJ", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_ADJ"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_CONT", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_CONT"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_BAD", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_BAD"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_RSV", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_RSV"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_LOSS", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_LOSS"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_OLOAN", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_OLOAN"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_ADJ", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_ADJ"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_CONT", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_CONT"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_BAD", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_BAD"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_RSV", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_RSV"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_LOSS", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_LOSS"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_OLOAN", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLOAN"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<String>("DEALHIST_POST_CODE", "U");
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_AMORT_INT", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_AMORT_INT"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_OLD_INT", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_OLD_INT"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_SIMPLE_INT", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_SIMPLE_INT"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_AMORT_INT", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_AMORT_INT"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_OLD_INT", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLD_INT"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_SIMPLE_INT", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_SIMPLE_INT"));

                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_AMORT_PDI", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_AMORT_PDI"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_OLD_PDI", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_OLD_PDI"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_SIMPLE_PDI", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_SIMPLE_PDI"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_AMORT_PDI", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_AMORT_PDI"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_OLD_PDI", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLD_PDI"));
                UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_SIMPLE_PDI", UpdateiacDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_SIMPLE_PDI"));
                DEALHISTBindingSource.EndEdit();
                DEALHISTTableAdapter.Update(UpdateiacDataSet.DEALHIST.Rows[DEALHISTPos]);
                worker.ReportProgress(16);
            }
        }

        void MonthlyUpdateMasterPost()
        {
            int MASTERPos = 0;
            Object loMasterKey,loTotalMonthEndInterest;
            String lsMasterKey = "";
            Decimal DeltaOSLoans = 0,DeltaInterest = 0;


            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MonthlyUpdateTotalsTableAdapter MonthlyUpdateTotalsTableAdapter = new IACDataSetTableAdapters.MonthlyUpdateTotalsTableAdapter();
            IACDataSetTableAdapters.MastHistTotalsTableAdapter MastHistTotalsTableAdapter = new IACDataSetTableAdapters.MastHistTotalsTableAdapter();

            MastHistTotalsTableAdapter.Fill(UpdateiacDataSet.MastHistTotals, "O");
            MonthlyUpdateTotalsTableAdapter.Fill(UpdateiacDataSet.MonthlyUpdateTotals);
            if (UpdateiacDataSet.MonthlyUpdateTotals.Rows.Count > 0)
            {
                DeltaOSLoans = UpdateiacDataSet.MonthlyUpdateTotals.Rows[0].Field<Decimal>("Balance");
                if (UpdateiacDataSet.MastHistTotals.Rows.Count > 0)
                    DeltaOSLoans += UpdateiacDataSet.MastHistTotals.Rows[0].Field<Decimal>("TotalOLoan");
                loTotalMonthEndInterest = TVAmortTableAdapter.TotalMonthEndInterest(ldNewRun);
                // Moses Newman let's get today's interest into the 213 card!
                DeltaInterest = loTotalMonthEndInterest != null ? (Decimal)loTotalMonthEndInterest *-1: 0;
                //DeltaInterest = lnMonthToDateInterest;
            }
            else
            {
                DeltaOSLoans = 0;
                DeltaInterest = 0;
            }
            gnDeltaInterest = DeltaInterest;
            MASTERTableAdapter.FillAllRecords(UpdateiacDataSet.MASTER);

            MASTERBindingSource.DataSource = UpdateiacDataSet.MASTER;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
            if (MASTERPos > -1)
            {
                DeltaOSLoans -= UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN");
                gnDeltaOSLoans = DeltaOSLoans;
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_OLOAN", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_NOTES", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_INT", 0);

                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", DeltaInterest *-1);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_OLOAN", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN") + (DeltaInterest * -1));

                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_OLOAN", DeltaInterest * -1);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Nullable<Decimal>>("MASTER_SIMPLE_YTD_OLOAN", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_OLOAN") + DeltaInterest * -1);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", ldNewRun);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(UpdateiacDataSet.MASTER.Rows[MASTERPos]);
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("INTEREST");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
            if (MASTERPos > -1)
            {
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", DeltaInterest);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_INT", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_INT") + DeltaInterest);

                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_INT", DeltaInterest);
                if (UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_INT") != null)
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_YTD_INT", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_SIMPLE_YTD_INT") + DeltaInterest);
                else
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_YTD_INT", DeltaInterest);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", ldNewRun);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(UpdateiacDataSet.MASTER.Rows[MASTERPos]);
            }


            loMasterKey = ACCOUNTTableAdapter.AccountNumber("SIMPLE_INT");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
            if (MASTERPos > -1)
            {
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", DeltaInterest);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_INT", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_INT") + DeltaInterest);

                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_INT", DeltaInterest);
                if (UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_INT") != null)
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_YTD_INT", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_SIMPLE_YTD_INT") + DeltaInterest);
                else
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_YTD_INT", DeltaInterest);
                UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", ldNewRun);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(UpdateiacDataSet.MASTER.Rows[MASTERPos]);
                MonthlyUpdateDailyInterest(DeltaInterest * -1); // Moses Newman 11/25/2020 Add record to DailyInterest Table
            }

            worker.ReportProgress(24);
        }

        // Moses Newman 11/25/2020 Add interest post to DailyInterest Table
        private void MonthlyUpdateDailyInterest(Decimal tnMonthInterest)
        {
            DailyDataSetTableAdapters.DailyInterestTableAdapter DailyInterestTableAdapter = new DailyDataSetTableAdapters.DailyInterestTableAdapter();
            DailyDataSet DailySet = new DailyDataSet();
            DailyInterestTableAdapter.Insert(ldNewRun, "M", tnMonthInterest, tnMonthInterest, 0,ldNewRun);
        }

        void MonthlyUpdateMASTHISTPost()
        {
            int lnSeq = 0, MASTHISTPos = 0, MASTERPos = 0;
            Object loMASTHISTSeq, loMasterKey;
            String lsMasterKey = "";

            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();

            MASTHISTBindingSource.DataSource = UpdateiacDataSet.MASTHIST;

            MASTHISTBindingSource.AddNew();
            MASTHISTBindingSource.EndEdit();

            MASTHISTPos = MASTHISTBindingSource.Position;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

            if (MASTHISTPos > -1)
            {
                loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, ldNewRun);
                if (loMASTHISTSeq != null)
                    lnSeq = (int)loMASTHISTSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", ldNewRun);
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "C");

                //  End of MASTHIST KEY

                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_OLOAN", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_OLOAN"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_OLOAN", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_NOTES", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_NOTES"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_NOTES", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_NOTES"));
                MASTHISTBindingSource.EndEdit();
                MASTHISTTableAdapter.Update(UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos]);

                // Moses Newman 12/31/2020 Post actual interest to 211 + new change due to ISF 
                MASTHISTBindingSource.AddNew();
                MASTHISTBindingSource.EndEdit();

                MASTHISTPos = MASTHISTBindingSource.Position;
                loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
                lsMasterKey = (String)loMasterKey;
                MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

                if (MASTHISTPos > -1)
                {
                    MASTHISTPos = MASTHISTBindingSource.Position;
                    loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, ldNewRun);
                    if (loMASTHISTSeq != null)
                        lnSeq = (int)loMASTHISTSeq + 1;
                    else
                        lnSeq = 1;
                    // Set up the new history record key
                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", ldNewRun);
                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "C");

                    //  End of MASTHIST KEY

                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_OLOAN", (gnDeltaOSLoans + gnDeltaInterest));
                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_OLOAN", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN") + gnDeltaOSLoans + gnDeltaInterest);
                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_NOTES", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_NOTES"));
                    UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_NOTES", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_NOTES"));
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos]);
                }
                // Moses Newman 12/31/2020 Modify last MASTER so that it reflects the new Change due to ISF
                MASTERTableAdapter.FillAllRecords(UpdateiacDataSet.MASTER);

                MASTERBindingSource.DataSource = UpdateiacDataSet.MASTER;

                loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
                lsMasterKey = (String)loMasterKey;
                MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
                if (MASTERPos > -1)
                {
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_OLOAN", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_NOTES", 0);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_INT", 0);

                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", gnDeltaOSLoans + gnDeltaInterest);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_OLOAN", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN") + gnDeltaOSLoans + gnDeltaInterest);

                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_OLOAN", gnDeltaOSLoans + gnDeltaInterest);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<Nullable<Decimal>>("MASTER_SIMPLE_YTD_OLOAN", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_OLOAN") + gnDeltaOSLoans + gnDeltaInterest);
                    UpdateiacDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", ldNewRun);
                    MASTERBindingSource.EndEdit();
                    MASTERTableAdapter.Update(UpdateiacDataSet.MASTER.Rows[MASTERPos]);
                }
            }

            MASTHISTBindingSource.AddNew();
            MASTHISTBindingSource.EndEdit();

            MASTHISTPos = MASTHISTBindingSource.Position;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("INTEREST");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

            if (MASTHISTPos > -1)
            {
                loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, ldNewRun);
                if (loMASTHISTSeq != null)
                    lnSeq = (int)loMASTHISTSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", ldNewRun);
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "C");

                //  End of MASTHIST KEY

                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_INT", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_INT"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_INT", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_INT"));
                MASTHISTBindingSource.EndEdit();
                MASTHISTTableAdapter.Update(UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos]);
            }

            MASTHISTBindingSource.AddNew();
            MASTHISTBindingSource.EndEdit();

            MASTHISTPos = MASTHISTBindingSource.Position;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("SIMPLE_INT");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

            if (MASTHISTPos > -1)
            {
                loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, ldNewRun);
                if (loMASTHISTSeq != null)
                    lnSeq = (int)loMASTHISTSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", ldNewRun);
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "C");

                //  End of MASTHIST KEY

                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_SIMPLE_CUR_INT", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_SIMPLE_CUR_INT"));
                UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_SIMPLE_YTD_INT", UpdateiacDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_SIMPLE_YTD_INT"));
                MASTHISTBindingSource.EndEdit();
                MASTHISTTableAdapter.Update(UpdateiacDataSet.MASTHIST.Rows[MASTHISTPos]);
            }

            worker.ReportProgress(48);
        }

        private void worker_PostMonthlyUpdate(object sender, DoWorkEventArgs e)
        {
            // Moses Newman 05/04/2015 PRevent other users system access here.
            if (Program.LockfileExclusive())
                PostMonthlyUpdate();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_PostMonthlyUpdate);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Closed Monthly Update";
            lfrm.lblProgress.Text = "Posting Montlhy Update";
            lfrm.ShowDialog();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            customerTableAdapter.Connection.Close();
            customerTableAdapter.Dispose();
            UpdateiacDataSet.Dispose();
            Close();
         }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            customerTableAdapter.Connection.Close();
            customerTableAdapter.Dispose();
            UpdateiacDataSet.Dispose();
            Close();
            // Moses Newman 05/04/2015 Release Lock on LOCKFILE and reset to ReadWrite Accesss for all
            Program.ReleaseExclusiveLock();
            Program.LockfileShare();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.lblProgress.Text = lsProgress;
            lfrm.lblProgress.Refresh();
            lfrm.QueryprogressBar.EditValue = e.ProgressPercentage;
        }

    }
}
 
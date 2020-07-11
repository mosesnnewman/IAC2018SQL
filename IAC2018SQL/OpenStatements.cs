using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class frmOpenStatements : Form
    {
        Int32   lnMoreStateCode = 0;
        Decimal lnMonthlyInterest = 0,lnPaymentDiff = 0,lnHoldRate1 = 0,lnHoldRate2 = 0,lnHoldRate3 = 0,lnPeriodic1 = 0,lnPeriodic2 = 0, lnPeriodic3 = 0,
                lnHoldInterest1 = 0, lnHoldInterest2 = 0, lnHoldInterest3 = 0,lnNewBalance = 0,lnHoldUpdateAmount = 0, lnHoldPrevBalance = 0,lnHoldBalance = 0,
                lnCustomerPrevBalance = 0,lnMasterOLOAN = 0,lnPreviousBalance = 0,lnPaymentDateDiff = 0,lnHoldISF = 0,lnHoldLate = 0,
                lnFirstPaymentDiff = 0, lnHoldContractStatus = 0, lnLastBalance = 0, lnStatementPayments =0,lnHistoryLate = 0;
        Boolean lbBypass = false, lbHoldLateISF = false, lbHoldISFFlag = false, lbPaymentFlag = false, lbFirstFlag = false;
        String lsStateCode = "";
        DateTime lnHoldPayDate;

        Double lnRate = 0,lnPayDate = 0;

        IACDataSetTableAdapters.OPN_WS_DEALER_STATEMENTSTableAdapter OPN_WS_DEALER_STATEMENTSTableAdapter = new IACDataSetTableAdapters.OPN_WS_DEALER_STATEMENTSTableAdapter();

        BindingSource OPN_WS_DEALER_STATEMENTSBindingSource = new BindingSource();

        QueryProgress lfrm;

        BackgroundWorker worker;

        public frmOpenStatements()
        {
            InitializeComponent();
        }

        private void frmOpenStatements_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            Object loDueDate = null;
            DateTime ldTempDate;

            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter StatementCustomerHeaderTableAdapter = new IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter();
            loDueDate = StatementCustomerHeaderTableAdapter.LastDueDate();
            if (loDueDate != null)
            {
                ldTempDate = (DateTime)loDueDate;
                LastClosingDatenullableDateTimePicker.Value = ldTempDate;
                LastClosingDatenullableDateTimePicker.Text = ldTempDate.ToShortDateString();
                ldTempDate = ldTempDate.AddMonths(1);
                ClosingDatenullableDateTimePicker.Value = ldTempDate;
                ClosingDatenullableDateTimePicker.Text = ldTempDate.ToShortDateString();
                ldTempDate = ldTempDate.AddMonths(1);
                StatementDatenullableDateTimePicker.Value = ldTempDate;
                StatementDatenullableDateTimePicker.Text = ldTempDate.ToShortDateString();
            }
            StatementCustomerHeaderTableAdapter.Dispose();
            ReportData.Dispose();
        }
        
        private void PostStatements()
        {

            int lnProgress = 0, lnTotalSteps = 0;

            opncustTableAdapter.CustomizeFill("SELECT * FROM OPNCUST WHERE CUSTOMER_ACT_STAT <> \'I\' AND CUSTOMER_POST_IND <> CHAR(255) AND CUSTOMER_DAY_DUE = " + ((DateTime)StatementDatenullableDateTimePicker.Value).Day.ToString().TrimStart().TrimEnd());
            opncustTableAdapter.CustomFillBy(StatementDataSet.OPNCUST);

            if (StatementDataSet.OPNCUST.Rows.Count == 0)
            {
                MessageBox.Show("There are no customers that qualify for statements!");
                return;
            }

            OPN_WS_DEALER_STATEMENTSTableAdapter.Fill(StatementDataSet.OPN_WS_DEALER_STATEMENTS, ((DateTime)StatementDatenullableDateTimePicker.Value).Day);
            OPN_WS_DEALER_STATEMENTSBindingSource.DataSource = StatementDataSet.OPN_WS_DEALER_STATEMENTS;

       
            lnTotalSteps = StatementDataSet.OPNCUST.Rows.Count + 2;
            for (int i = 0; i < StatementDataSet.OPNCUST.Rows.Count; i++)
            {
                TopOfJob(i);
                lnProgress = (Int32)(Math.Round(((Double)i / (Double)lnTotalSteps), 2) * 100);
                worker.ReportProgress(lnProgress);
            }
            ActDealerPost();
            worker.ReportProgress(88);
            UpdateMaster();
            worker.ReportProgress(98);
            CreateMastHist();
            worker.ReportProgress(100);
        }

        private void TopOfJob(Int32 CustomerPos)
        {
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            Int32 lnActDateDiff = 0;

            lnPaymentDiff = 0;
            lnMonthlyInterest = 0;
            lnPreviousBalance = 0;
            lnFirstPaymentDiff = 0;
            lnPaymentDateDiff = 0;
            lnHoldBalance = 0;
            lnPayDate = 0;
            lnHoldPrevBalance = 0;
            lnHoldInterest1 = 0;
            lnHoldInterest2 = 0;
            lnHoldInterest3 = 0;
            lnHoldISF = 0;
            lnHoldLate = 0;
            lnStatementPayments = 0;
            lnHistoryLate = 0;
            lbBypass = false;
            lbFirstFlag = false;
            lbHoldISFFlag = false;
            lbHoldLateISF = false;
            lbPaymentFlag = false;

            TimeSpan ltActDateDiff;
            DateTime ldFormDate = ((DateTime)StatementDatenullableDateTimePicker.Value).Date;
 
            ltActDateDiff = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<DateTime>("CUSTOMER_INIT_DATE").Date -ldFormDate;
            lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);

            if (lnActDateDiff > 0)
                lbBypass = true;
            else
                lbBypass = false;

            lbHoldLateISF = true;
            lbHoldISFFlag = true;

            lnCustomerPrevBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PREV_BALANCE");

            // Get all history for this customer where Payment Date is > Last Closing Date and <= Closing Date
            OPNHCUSTTableAdapter.FillByCustDateRange(StatementDataSet.OPNHCUST, StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                            (DateTime)LastClosingDatenullableDateTimePicker.Value, (DateTime)ClosingDatenullableDateTimePicker.Value);

            if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<DateTime>("CUSTOMER_INIT_DATE").Date >= ((DateTime)StatementDatenullableDateTimePicker.Value).Date)
            {
                lnMonthlyInterest = 0;
                lnPaymentDiff = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                NewCustomersinCycle(CustomerPos);
            }
            else
                if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE") == null)
                {
                    lnMonthlyInterest = 0;
                    lnPaymentDiff = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    // Moses Newman 12/26/2012 Added late charge sum if customer never paid but has late fees this period
                    for (Int32 i = 0; i < StatementDataSet.OPNHCUST.Rows.Count; i++)
                        lnHoldLate += StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_LATE_CHARGE");
                    // End of 12/26/2012 Late Charge Mod
                    NoPaymentsRcv(CustomerPos);
                }
                else
                    if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<DateTime>("CUSTOMER_LAST_PAYMENT_DATE").Date < ((DateTime)LastClosingDatenullableDateTimePicker.Value).Date)
                    {
                        lnMonthlyInterest = 0;
                        lnPaymentDiff = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PREV_BALANCE");
                        NoPaymentsRcv(CustomerPos);
                    }
                    else
                    {
                        lnMonthlyInterest = 0;
                        lbPaymentFlag = true;
                        lnPreviousBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PREV_BALANCE");
                        CheckforPaymentDate(CustomerPos);
                        if (lbPaymentFlag)
                        {
                            lbPaymentFlag = false;
                            lnPaymentDiff = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PREV_BALANCE");
                            NoPaymentsRcv(CustomerPos);
                        }
                        else
                            UpdateAmounts(CustomerPos);
                    }
            SumDealerTotals(CustomerPos);
            PopulateStatementFile(CustomerPos);
            UpdateCustomer(CustomerPos);
            CustomerHistory(CustomerPos);
        }

        private void CheckforPaymentDate(Int32 CustomerPos)
        {
            lbFirstFlag = true;

            for (int i = 0; i < StatementDataSet.OPNHCUST.Rows.Count; i++)
            {
                if (StatementDataSet.OPNHCUST.Rows[i].Field<String>("CUSTHIST_PAYMENT_TYPE") == "N")
                {
                    lnHoldISF += StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV") * -1;
                    lnPaymentDiff = 0;
                    lnPaymentDateDiff = 0;
                    lnPayDate = 0;
                    continue;
                }
                else
                    // Moses Newman 1/15/2014 Handle NULL CUSTHIST_LATE_CHARGE field.
                    if (StatementDataSet.OPNHCUST.Rows[i].Field<Nullable<Decimal>>("CUSTHIST_LATE_CHARGE") == null)
                        StatementDataSet.OPNHCUST.Rows[i].SetField<Nullable<Decimal>>("CUSTHIST_LATE_CHARGE", 0);
                    if (StatementDataSet.OPNHCUST.Rows[i].Field<Nullable<Decimal>>("CUSTHIST_LATE_CHARGE") > 0)
                    {
                        lnHoldLate += StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_LATE_CHARGE");
                        lnPaymentDiff = 0;
                        lnPaymentDateDiff = 0;
                        lnPayDate = 0;
                        continue;
                    }
                    else
                        if (StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV") == 0)
                        {
                            lnPaymentDiff = 0;
                            lnPaymentDateDiff = 0;
                            lnPayDate = 0;
                            continue;
                        }

                if(StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_LATE_CHARGE") == 0)
                    lnLastBalance = StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_BALANCE");

                if (StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV") != 0)
                    if (StatementDataSet.OPNHCUST.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE").Date < ((DateTime)ClosingDatenullableDateTimePicker.Value).Date &&
                        StatementDataSet.OPNHCUST.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE").Date > ((DateTime)LastClosingDatenullableDateTimePicker.Value).Date)
                    {
                        lbPaymentFlag = false;
                        lnFirstPaymentDiff = 0;
                        CheckForRates(CustomerPos, i);
                        lnPreviousBalance = StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_BALANCE");
                        lnMonthlyInterest += Math.Round(lnFirstPaymentDiff,2);
                        lnNewBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") + lnMonthlyInterest; 
                    }
                if (i == StatementDataSet.OPNHCUST.Rows.Count - 1)
                    lbFirstFlag = false;
                lnPaymentDiff = 0;
                lnPaymentDateDiff = 0;
                lnPayDate = 0;
            }
            if (!lbFirstFlag)
            {
                CheckForRates(CustomerPos, StatementDataSet.OPNHCUST.Rows.Count - 1, true);
                lnMonthlyInterest += Math.Round(lnFirstPaymentDiff, 2);
                lnNewBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") + lnMonthlyInterest;
            }
        
            lnPaymentDiff = 0;
            lnPaymentDateDiff = 0;
            lnPayDate = 0;
        }

        private void CheckForRates(Int32 CustomerPos, Int32 CusthistPos,Boolean IsLast = false)
        {
            Int32 lnActDateDiff = 0;
            TimeSpan ltActDateDiff;

            if (lbFirstFlag)
            {
                ltActDateDiff = StatementDataSet.OPNHCUST.Rows[CusthistPos].Field<DateTime>("CUSTHIST_PAY_DATE").Date - ((DateTime)LastClosingDatenullableDateTimePicker.Value).Date;
                lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);
                lnHoldPayDate = StatementDataSet.OPNHCUST.Rows[CusthistPos].Field<DateTime>("CUSTHIST_PAY_DATE").Date;
            }
            else
                if (IsLast) // Last history record
                {
                    ltActDateDiff = ((DateTime)ClosingDatenullableDateTimePicker.Value).Date - lnHoldPayDate;
                    lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);
                }
                else
                {
                    ltActDateDiff = StatementDataSet.OPNHCUST.Rows[CusthistPos].Field<DateTime>("CUSTHIST_PAY_DATE").Date - lnHoldPayDate;
                    lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);
                    lnHoldPayDate = StatementDataSet.OPNHCUST.Rows[CusthistPos].Field<DateTime>("CUSTHIST_PAY_DATE").Date;
                }
            if (lnActDateDiff > 0)
            {
                lnPaymentDateDiff = lnActDateDiff;
                if (lbFirstFlag)
                {
                    lbFirstFlag = false;
                    lnPaymentDiff = lnCustomerPrevBalance;
                }
                else
                    if (IsLast)
                        lnPaymentDiff = lnLastBalance;
                    else
                        lnPaymentDiff = lnPreviousBalance;
            }

            if (!lbHoldLateISF)
                if (lnHoldLate < 0)
                    lnHoldLate *= -1;
                else
                    lnPaymentDiff -= lnHoldLate;

            if (!lbHoldISFFlag)
                lnPaymentDiff -= lnHoldISF;

            if (lbHoldLateISF)
                lbHoldLateISF = false;

            if (lbHoldISFFlag)
                if (lnHoldISF != 0)
                    lbHoldISFFlag = false;

            if (lnActDateDiff > 0)
            {
                GetDailyPeriodictRates(CustomerPos, CusthistPos);
                lnPaymentDateDiff = lnActDateDiff;
            }
        }

        private void NewCustomersinCycle(Int32 CustomerPos)
        {
            Int32 lnActDateDiff = 0;

            lnFirstPaymentDiff = 0;

            // Check the difference between transmittal date and the present closing date
            TimeSpan ltActDateDiff;
            DateTime ldFormDate = ((DateTime)ClosingDatenullableDateTimePicker.Value).Date;
            ltActDateDiff = ldFormDate - StatementDataSet.OPNCUST.Rows[CustomerPos].Field<DateTime>("CUSTOMER_CONTRACT_DATE").Date;
            lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);

            if (lnActDateDiff > 30)
            {
                GetInterestRates(CustomerPos);
                return;
            }
            // Moses Newman 07/19/2018 changed lnPayDateDiff to lnPaymentDateDiff because it is needed for GetDailyPeriodicRates NOT lnPayDateDiff!
            lnPaymentDateDiff = lnActDateDiff;
            lnPaymentDiff = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
            GetDailyPeriodictRates(CustomerPos);
            if (lnActDateDiff > 0)
                lnMonthlyInterest = lnFirstPaymentDiff;
            else
                lnMonthlyInterest = 0;

            lnNewBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") + lnMonthlyInterest;
            UpdateAmounts(CustomerPos);
        }

        private void UpdateAmounts(Int32 CustomerPos)
        {
            // Daily breakdown for periodic table
            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_Y") != 0)
                lnPeriodic1 = StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_Y") / 365;
            else
                lnPeriodic1 = 0;

            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") != 0)
                lnPeriodic2 = StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") / 365;
            else
                lnPeriodic2 = 0;

            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") != 0)
                lnPeriodic3 = StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") / 365;
            else
                lnPeriodic3 = 0;

            lnMasterOLOAN += lnMonthlyInterest;
            NewContractStatus(CustomerPos);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_TOT_FINANCE_CHARGE", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_TOT_FINANCE_CHARGE") + lnMonthlyInterest);
            if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PREV_BALANCE") == 0)
                lnHoldPrevBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
            else
                lnHoldPrevBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PREV_BALANCE");
            lnHoldBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE",lnNewBalance);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LAST_FINANCE_CHARGE",lnMonthlyInterest);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_PREV_BALANCE",lnNewBalance);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_YTD_FINANCE_CHARGE", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_YTD_FINANCE_CHARGE") + lnMonthlyInterest);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_UPDATE_AMOUNT", 0);
            if (!lbBypass)
                UpdateBuckets(CustomerPos);
        }

        private void UpdateBuckets(Int32 CustomerPos)
        {
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_10", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_10") + StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_9"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_9", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_8"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_8", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_7"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_7", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_6"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_6", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_5"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_5", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_4"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_4", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_3"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_3", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_2"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_2", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_1"));
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_1", lnMonthlyInterest);
            // If No Interest Finance_Bucket_1 
            // This is to make paid through advance correctly even with zero interest customers
            if(StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_STATE1") == 99)
                StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_1", (Decimal)20.00);
        }

        private void NoPaymentsRcv(Int32 CustomerPos)
        {
            Int32 lnActDateDiff = 0;
            
            lnFirstPaymentDiff = 0;

            // Get # of Days Between Closing Date
            TimeSpan ltActDateDiff;
            ltActDateDiff = ((DateTime)ClosingDatenullableDateTimePicker.Value).Date - ((DateTime)LastClosingDatenullableDateTimePicker.Value).Date;
            lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);

            lnPaymentDateDiff = lnActDateDiff;

            // First One
            GetDailyPeriodictRates(CustomerPos);
            lnMonthlyInterest = lnFirstPaymentDiff;

            lnNewBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") + lnFirstPaymentDiff;
            UpdateAmounts(CustomerPos);
        }

        private void NewContractStatus(Int32 CustomerPos)
        {
            // 12/9/2011 Moses Newman Modified NewContractStatus to use routine from payment posting
            Decimal lnHoldStat = 0;
            OpenPaymentPosting OPPaypost = new OpenPaymentPosting();
            lnHoldStat = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");

            if (!lbBypass)
            {
                if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Nullable<Int32>>("CUSTOMER_STATUS_NO") == null)
                    StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Int32>("CUSTOMER_STATUS_NO", 0);
                StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Int32>("CUSTOMER_STATUS_NO", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_STATUS_NO") + 1);
            }
            OPPaypost.OpenNewContractStatus(CustomerPos, ref StatementDataSet);
            lnHoldContractStatus = lnHoldStat;
            // End 12/9/2--7 Mod
        }

        private void GetDailyPeriodictRates(Int32 CustomerPos,Int32 CusthistPos = -1)
        {
            IACDataSetTableAdapters.OPNRATETableAdapter OPNRATETableAdapter = new IACDataSetTableAdapters.OPNRATETableAdapter();
            lnHoldRate1 = 0;
            lnHoldRate2 = 0;
            lnHoldRate3 = 0;
            lnPeriodic1 = 0;
            lnPeriodic2 = 0;
            lnPeriodic3 = 0;
            lnHoldInterest1 = 0;
            lnHoldInterest2 = 0;
            lnHoldInterest3 = 0;
            lnNewBalance = 0;
            lnHoldUpdateAmount = 0;
            lnHoldPrevBalance = 0;
            lnHoldBalance = 0;
            lnRate = 0;

            lsStateCode = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_STATE");
            lnMoreStateCode = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_STATE1");

            OPNRATETableAdapter.FillByMoreStatecod(StatementDataSet.OPNRATE, lsStateCode, lnMoreStateCode);
            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") != 0)
                if (lnPaymentDiff > StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG2_Y"))
                {
                    lnHoldRate3 = lnPaymentDiff - StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG2_Y");
                    lnRate = Math.Round((Double)StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") / 36500,12);
                    lnPayDate = lnRate * (Double)lnPaymentDateDiff;
                    lnHoldInterest3 = (Decimal)Math.Round((Double)lnHoldRate3 * lnPayDate,2);
                }

            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") != 0)
                if (lnPaymentDiff > StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG1_Y"))
                {
                    lnHoldRate2 = lnPaymentDiff - (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG1_Y") + lnHoldRate3);
                    lnRate = Math.Round((Double)StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") / 36500,12);
                    lnPayDate = lnRate * (Double)lnPaymentDateDiff;
                    lnHoldInterest2 = (Decimal)Math.Round((Double)lnHoldRate2 * lnPayDate,2);
                }

            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_Y") != 0)
            {
                lnHoldRate1 = lnPaymentDiff - (lnHoldRate3 + lnHoldRate2);
                lnRate = Math.Round((Double)StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_Y") / 36500,12);
                lnPayDate = lnRate * (Double)lnPaymentDateDiff;
                lnHoldInterest1 = (Decimal)Math.Round((Double)lnHoldRate1 * lnPayDate,2);
            }
            lnFirstPaymentDiff = lnHoldInterest1 + lnHoldInterest2 + lnHoldInterest3;

            if (CusthistPos > -1)
                if (StatementDataSet.OPNHCUST.Rows[CusthistPos].Field<String>("CUSTHIST_PAYMENT_TYPE") == "W" &&
                    StatementDataSet.OPNHCUST.Rows[CusthistPos].Field<String>("CUSTHIST_PAYMENT_CODE") == "L" &&
                    lnHoldLate > 0)
                    lnHoldLate = 0;

            lnHoldInterest1 = 0;
            lnHoldInterest2 = 0;
            lnHoldInterest3 = 0;
            lnPaymentDateDiff = 0;
            lnPayDate = 0;
        }

        private void GetInterestRates(Int32 CustomerPos)
        {
            IACDataSetTableAdapters.OPNRATETableAdapter OPNRATETableAdapter = new IACDataSetTableAdapters.OPNRATETableAdapter();
            lnHoldRate1 = 0;
            lnHoldRate2 = 0;
            lnHoldRate3 = 0;
            lnPeriodic1 = 0;
            lnPeriodic2 = 0;
            lnPeriodic3 = 0;
            lnHoldInterest1 = 0;
            lnHoldInterest2 = 0;
            lnHoldInterest3 = 0;
            lnNewBalance = 0;
            lnMonthlyInterest = 0;
            lnHoldUpdateAmount = 0;
            lnHoldPrevBalance = 0;
            lnHoldBalance = 0;

            lsStateCode = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_STATE");
            lnMoreStateCode = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_STATE1");

            // Calculate Finance Charge
            OPNRATETableAdapter.FillByMoreStatecod(StatementDataSet.OPNRATE,lsStateCode, lnMoreStateCode);
            if(StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") != 0)
                if(StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") > StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG2_Y"))
                {
                    lnHoldRate3 = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG2_Y");
                    lnHoldInterest3 = (Decimal)Math.Round(((Double)lnHoldRate3 * (((Double)StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") / (Double)365.00) * (Double)30.42) / (Double)100.00),2);
                }

            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") != 0)
                if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") > StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG1_Y"))
                {
                    lnHoldRate2 = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG1_Y") + lnHoldRate3);
                    lnHoldInterest2 = (Decimal)Math.Round(((Double)lnHoldRate2 * (((Double)StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") / (Double)365.00) * (Double)30.42) / (Double)100.00), 2);
                }

            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_Y") != 0)
                if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") > StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG1_Y"))
                {
                    lnHoldRate1 = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - (lnHoldRate3 + lnHoldRate2);
                    lnHoldInterest1 = (Decimal)Math.Round(((Double)lnHoldRate1 * (((Double)StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") / (Double)365.00) * (Double)30.42) / (Double)100.00), 2);
                }
            // End of Finance charge calculation

            // Daily breakdown for periodic table
            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_Y") != 0)
                lnPeriodic1 = StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_Y") / 365;
            else
                lnPeriodic1 = 0;

            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") != 0)
                lnPeriodic2 = StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") / 365;
            else
                lnPeriodic2 = 0;

            if (StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") != 0)
                lnPeriodic3 = StatementDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") / 365;
            else
                lnPeriodic3 = 0;


            lnNewBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") + lnHoldInterest1 + lnHoldInterest2 + lnHoldInterest3;
            lnMonthlyInterest = lnHoldInterest1 + lnHoldInterest2 + lnHoldInterest3;
            lnMasterOLOAN += lnMonthlyInterest;

            NewContractStatus(CustomerPos);

            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_TOT_FINANCE_CHARGE", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_TOT_FINANCE_CHARGE") + lnMonthlyInterest);
            lnHoldUpdateAmount = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_UPDATE_AMOUNT");
            lnHoldPrevBalance = lnCustomerPrevBalance;
            lnHoldBalance = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE", lnNewBalance);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LAST_FINANCE_CHARGE", lnMonthlyInterest);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_PREV_BALANCE", lnNewBalance);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_YTD_FINANCE_CHARGE", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_YTD_FINANCE_CHARGE") + lnMonthlyInterest);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_UPDATE_AMOUNT",0);
        }

        private void CustomerHistory(Int32 CustomerPos)
        {
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            BindingSource CUSTHISTBindingSource = new BindingSource();

            Int32 lnSeq = 0;
            Object loCustHistSeq = null;

            CUSTHISTBindingSource.DataSource = StatementDataSet.OPNHCUST;

            CUSTHISTBindingSource.AddNew();
            CUSTHISTBindingSource.EndEdit();
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            // Moses Newman 03/08/2012 Added update of CUSTHIST_NUMBER
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_NUMBER", Convert.ToInt32(StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO")));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ADD_ON", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ADD_ON"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_IAC_TYPE", "O");
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", DateTime.Now.Date);
            loCustHistSeq = OPNHCUSTTableAdapter.SeqNoQuery(StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), DateTime.Now.Date);
            if (loCustHistSeq != null)
                lnSeq = (int)loCustHistSeq + 1;
            else
                lnSeq = 1;
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", 0);
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU").TrimStart().TrimEnd().PadLeft(4, '0'));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "STAT");
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE1", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE1"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE2", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE2"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE3", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE3"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PREV_BALANCE", lnHoldPrevBalance);
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LAST_FINANCE_CHARGE", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LAST_FINANCE_CHARGE"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_TOT_FINANCE_CHARGE", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_TOT_FINANCE_CHARGE"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_UPDATE_AMOUNT", 0);
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_CHARGE", lnMonthlyInterest);
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_DATE", DateTime.Now.Date);
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_1", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_1"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_2", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_2"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_3", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_3"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_4", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_4"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_5", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_5"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_6", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_6"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_7", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_7"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_8", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_8"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_9", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_9"));
            StatementDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_10", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_10"));

            CUSTHISTBindingSource.EndEdit();
            OPNHCUSTTableAdapter.Update(StatementDataSet.OPNHCUST);
            StatementDataSet.OPNHCUST.AcceptChanges();
        }

        private void ActDealerPost()
        {
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            BindingSource DEALERBindingSource = new BindingSource();

            Int32 lnProgress = 0, lnTotalWork = 0;

            DEALERBindingSource.DataSource = StatementDataSet.OPNDEALR;

            lnTotalWork = StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows.Count;
            for (Int32 i = 0; i < StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows.Count; i++)
            {
                OPNDEALRTableAdapter.Fill(StatementDataSet.OPNDEALR, StatementDataSet.OPN_WS_DEALER_STATEMENTS[i].Field<String>("KEY"));
                if (StatementDataSet.OPNDEALR.Rows.Count != 0)
                {
                    StatementDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_RSV", 0);
                    StatementDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_CONT", 0);
                    StatementDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_OLOAN", 0);
                    StatementDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_ADJ", 0);
                    StatementDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_BAD", 0);
                    StatementDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_LOSS", 0);

                    StatementDataSet.OPNDEALR.Rows[0].SetField<DateTime>("OPNDEALR_POST_DATE", DateTime.Now.Date);
                    StatementDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_OLOAN", StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[i].Field<Decimal>("OS_L"));
                    StatementDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_OLOAN", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN") + StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[i].Field<Decimal>("OS_L"));
                    DEALERBindingSource.EndEdit();
                    OPNDEALRTableAdapter.Update(StatementDataSet.OPNDEALR.Rows[0]);
                    StatementDataSet.OPNDEALR.AcceptChanges();
                    DealHistPost();
                    lnProgress = (Int32)Math.Round(((Double)i / (Double)lnTotalWork) * (Double)100, 2);
                    worker.ReportProgress(lnProgress);
                }
            }
        }

        private void DealHistPost()
        {
            Int32 lnSeq = 0;
            Object loDealerHistSeq = null;

            IACDataSetTableAdapters.OPNHDEALTableAdapter OPNHDEALTableAdapter = new IACDataSetTableAdapters.OPNHDEALTableAdapter();
            BindingSource DEALHISTBindingSource = new BindingSource();

            DEALHISTBindingSource.DataSource = StatementDataSet.OPNHDEAL;

            DEALHISTBindingSource.AddNew();
            DEALHISTBindingSource.EndEdit();

            // Start of DEALHIST KEY Fields
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_ACC_NO", StatementDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_POST_DATE", DateTime.Now.Date);
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_LAST_POST_DATE", StatementDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE"));
            loDealerHistSeq = OPNHDEALTableAdapter.SeqNoQuery(StatementDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"), DateTime.Now.Date, StatementDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE"));
            if (loDealerHistSeq != null)
                lnSeq = (int)loDealerHistSeq + 1;
            else
                lnSeq = 1;
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
            // End of DEALHIST KEY Fields
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_RSV", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_RSV"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_CONT", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_CONT"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLOAN", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_OLOAN"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_ADJ", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_ADJ"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_BAD", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_BAD"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_LOSS", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_LOSS"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_RSV", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_RSV"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_CONT", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_CONT"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLOAN", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_ADJ", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_ADJ"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_BAD", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_BAD"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_LOSS", StatementDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_LOSS"));
            StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_POST_CODE", "F");
            DEALHISTBindingSource.EndEdit();
            OPNHDEALTableAdapter.Update(StatementDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position]);
            StatementDataSet.OPNHDEAL.AcceptChanges();
        }


        private Int32 CheckFirstPayment(Int32 CustomerPos,DateTime ldACTDate)
        {
            DateTime ldFirstPayment;
            DateTime? ldFirstPaymentTemp = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<DateTime?>("CUSTOMER_INIT_DATE");

            if (ldFirstPaymentTemp == null)
                return 0;
            else
                ldFirstPayment = (DateTime)ldFirstPaymentTemp;
            Int32 lnNoYRS = 0, lnFirstPayMM = 0, lnFirstPayDD = 0, lnFirstPayYY = 0, lnActDateDiff = 0;

            lnFirstPayDD = ldFirstPayment.Day;
            lnFirstPayMM = ldFirstPayment.Month;
            lnFirstPayMM += StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM");

            lnFirstPayYY = ldFirstPayment.Year;

            if (lnFirstPayMM > 12)
            {
                lnNoYRS = lnFirstPayMM / 12;
                lnFirstPayYY += lnNoYRS;
                lnFirstPayMM -= (12 * lnNoYRS);
                if (lnFirstPayMM == 0)
                {
                    lnFirstPayYY -= 1;
                    lnFirstPayMM = 12;
                }
            }
            if (lnFirstPayMM == 2 && lnFirstPayDD == 30)
            {
                lnFirstPayMM = 3;
                lnFirstPayDD = 2;
            }
            ldFirstPayment = Convert.ToDateTime(lnFirstPayMM.ToString() + "/" + lnFirstPayDD.ToString() + "/" + lnFirstPayYY.ToString());
            TimeSpan ltActDateDiff;
            ltActDateDiff = ldFirstPayment - ldACTDate;
            lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);

            return lnActDateDiff;
        }


        private void UpdateMaster()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            BindingSource MASTERBindingSource = new BindingSource();

            MASTERBindingSource.DataSource = StatementDataSet.MASTER;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            String lsMasterKey = (String)loMasterKey;
            try
            {
                MASTERTableAdapter.Fill(StatementDataSet.MASTER, lsMasterKey);

                if (StatementDataSet.MASTER.Rows.Count != 0)
                {
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                    StatementDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", lnMasterOLOAN);
                    StatementDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_OLOAN", StatementDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN") + lnMasterOLOAN);
                    MASTERBindingSource.EndEdit();
                    MASTERTableAdapter.Update(StatementDataSet.MASTER.Rows[0]);
                    StatementDataSet.MASTER.AcceptChanges();
                }
            }
            catch
            {
                MessageBox.Show("*** There was an error posting to the MASTER table.  Statements did NOT post correctly ***");
            }
        }

        private void CreateMastHist()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
            BindingSource MASTHISTBindingSource = new BindingSource();

            MASTHISTBindingSource.DataSource = StatementDataSet.MASTHIST;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS"),loMasterHistSeq = null;
            String lsMasterKey = (String)loMasterKey;
            Int32 lnSeq = 0;

            MASTERTableAdapter.Fill(StatementDataSet.MASTER, lsMasterKey);
            if (StatementDataSet.MASTER.Rows.Count != 0)
            {
                MASTHISTBindingSource.AddNew();
                MASTHISTBindingSource.EndEdit();
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO",StatementDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", StatementDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(StatementDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), StatementDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                if (loMasterHistSeq != null)
                    lnSeq = (int)loMasterHistSeq + 1;
                else
                    lnSeq = 1;
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", StatementDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_OLOAN", StatementDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_OLOAN"));
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_OLOAN", StatementDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN"));
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_NOTES", 0);
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_NOTES", StatementDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES"));
                StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
                MASTHISTBindingSource.EndEdit();
                MASTHISTTableAdapter.Update(StatementDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                StatementDataSet.MASTHIST.AcceptChanges();
            }

        }

        private void UpdateCustomer(Int32 CustomerPos)
        {
            BindingSource CUSTOMERBindingSource = new BindingSource();

            CUSTOMERBindingSource.DataSource = StatementDataSet.OPNCUST;

            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);

            CUSTOMERBindingSource.EndEdit();
            opncustTableAdapter.Update(StatementDataSet.OPNCUST.Rows[CustomerPos]);
            StatementDataSet.OPNCUST.AcceptChanges();
        }


        private void SumDealerTotals(Int32 CustomerPos)
        {
            Int32 WSSTATEMENTDEALERPos = 0;
            IACDataSetTableAdapters.StatementDealerSummaryTableAdapter StatementDealerSummaryTableAdapter = new IACDataSetTableAdapters.StatementDealerSummaryTableAdapter();

            WSSTATEMENTDEALERPos = OPN_WS_DEALER_STATEMENTSBindingSource.Find("KEY", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_DEALER"));
            if (WSSTATEMENTDEALERPos > -1)
            {
                StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].SetField<Decimal>("OS_L",      StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Decimal>("OS_L")         + lnMonthlyInterest);
                StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].SetField<Decimal>("BALANCE",   StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Decimal>("BALANCE")      + lnHoldBalance);
                if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_WRONG_ADDRESS") != "Y") 
                    StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].SetField<Int32>("GOOD_ACCTS", StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Int32>("GOOD_ACCTS") + 1);
                else
                    StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].SetField<Int32>("WRONG_ACCTS", StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Int32>("WRONG_ACCTS")    + 1);
                StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].SetField<Int32>("NO_ACCTS",    StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Int32>("NO_ACCTS")       + 1);
                StatementDealerSummaryTableAdapter.Delete(StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_DEALER"),
                                                          ((DateTime)StatementDatenullableDateTimePicker.Value).Date);
                StatementDealerSummaryTableAdapter.Insert(StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_DEALER"),
                                                          ((DateTime)StatementDatenullableDateTimePicker.Value).Date,
                                                          StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Decimal>("OS_L"),
                                                          StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Decimal>("BALANCE"),
                                                          StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Int32>("GOOD_ACCTS"),
                                                          StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Int32>("WRONG_ACCTS"),
                                                          StatementDataSet.OPN_WS_DEALER_STATEMENTS.Rows[WSSTATEMENTDEALERPos].Field<Int32>("NO_ACCTS"));
            }
        }

        private void NoticeDatenullableDateTimePicker_Validated(object sender, EventArgs e)
        {
            DateTime? ldCurrentDate = (DateTime?)ClosingDatenullableDateTimePicker.Value;
            if (ldCurrentDate.Value != null)
                if (ldCurrentDate.Value.Month == 2 && ldCurrentDate.Value.Day == 30)
                    ClosingDatenullableDateTimePicker.Value = Convert.ToDateTime("02/28" + ldCurrentDate.Value.Year.ToString());
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_PostStatements);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Open Statement Posting";
            lfrm.lblProgress.Text = "Posting Open Statements";
            lfrm.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            opncustTableAdapter.Connection.Close();
            opncustTableAdapter.Dispose();
            StatementDataSet.Dispose();
            Close();
        }

        private void worker_PostStatements(object sender, DoWorkEventArgs e)
        {
            PostStatements();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            opncustTableAdapter.Connection.Close();
            opncustTableAdapter.Dispose();
            StatementDataSet.Dispose();
            Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.Value = e.ProgressPercentage;
        }

        private void PopulateStatementFile(Int32 CustomerPos)
        {
            IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter StatementCustomerHeaderTableAdapter = new IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter();
            BindingSource StatementCustomerHeaderBindingSource = new BindingSource();

            Decimal lnCheckStatus = 0, lnStatementBalance = 0;

            StatementCustomerHeaderBindingSource.DataSource = StatementDataSet.StatementCustomerHeader;

            // First row of boxes on statement
            StatementCustomerHeaderTableAdapter.Fill(StatementDataSet.StatementCustomerHeader,StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),((DateTime)StatementDatenullableDateTimePicker.Value).Date,false,false);
            if (StatementDataSet.StatementCustomerHeader.Rows.Count == 0)
            {
                StatementCustomerHeaderBindingSource.AddNew();
                StatementCustomerHeaderBindingSource.EndEdit();
            }
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<String>("AccountNumber", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<DateTime>("ScheduledPaymentDate", ((DateTime)StatementDatenullableDateTimePicker.Value).Date);
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("ScheduledPayment", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));            

            if(lbBypass)
                StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("PastDueAmount", 0);            
            else
                if(lnHoldContractStatus < 0)
                    StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("PastDueAmount", lnHoldContractStatus * -1); 
                else
                    StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("PastDueAmount", 0);

            if (lbBypass)
                StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("LateCharge", 0);
            else
                StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("LateCharge", lnHoldLate);

            lnCheckStatus = StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") * -1;

            if (lbBypass)
                StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("TotalDue", 0);
            else
                if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") < StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"))
                    StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("TotalDue", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
                else
                    if (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") >= 0 ||
                        (StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") > lnCheckStatus))
                        StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("TotalDue", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                    else
                        StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("TotalDue", StatementDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1);
            
            // Second Row of boxes non redundant fields
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("PreviousBalance",lnHoldPrevBalance);
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<DateTime>("ClosingDate", ((DateTime)ClosingDatenullableDateTimePicker.Value).Date);
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<DateTime>("LastClosingDate", ((DateTime)LastClosingDatenullableDateTimePicker.Value).Date);

            CheckPayments(CustomerPos);
            StatementDataSet.OPNCUST.Rows[CustomerPos].SetField<String>("CUSTOMER_PAY_REM_1", "STAT");

            //Fourth Row of boxes non redundant fields
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("NewLoans", lnHoldUpdateAmount);
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("FinanceCharge", lnMonthlyInterest);
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("Payments", lnStatementPayments);

            lnStatementBalance = (lnHoldPrevBalance + lnHoldUpdateAmount + lnMonthlyInterest + lnHoldLate) - lnStatementPayments;
            StatementDataSet.StatementCustomerHeader.Rows[0].SetField<Decimal>("NewBalance", lnStatementBalance);

            // New Busines and Add On Flags
            StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Boolean>("NewBusiness", false);
            StatementDataSet.StatementCustomerHeader.Rows[StatementCustomerHeaderBindingSource.Position].SetField<Boolean>("AddOn", false);

            StatementCustomerHeaderBindingSource.EndEdit();
            StatementCustomerHeaderTableAdapter.Update(StatementDataSet.StatementCustomerHeader.Rows[0]);
            StatementDataSet.StatementCustomerHeader.AcceptChanges();

            StatementCustomerHeaderTableAdapter.Dispose();
            StatementCustomerHeaderBindingSource.Dispose();
        }

        private void CheckPayments(Int32 CustomerPos)
        {
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();

            // Get all history for this customer where Payment Date is > Last Closing Date and <= Closing Date
            OPNHCUSTTableAdapter.FillByCustDateRange(StatementDataSet.OPNHCUST, StatementDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                                    (DateTime)LastClosingDatenullableDateTimePicker.Value, (DateTime)ClosingDatenullableDateTimePicker.Value);
            for (int i = 0; i < StatementDataSet.OPNHCUST.Rows.Count; i++)
            {
                // Insufficient Funds
                if(StatementDataSet.OPNHCUST.Rows[i].Field<String>("CUSTHIST_PAYMENT_TYPE") == "I")
                {
                    StatementDataSet.OPNHCUST.Rows[i].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV") * -1);
                    lnHoldUpdateAmount += StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV");
                    continue;
                }
                // Adjustments & Payments
                if (StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV") != 0 && StatementDataSet.OPNHCUST.Rows[i].Field<String>("CUSTHIST_PAY_REM_1").Trim() != "ADD")
                {
                    lnStatementPayments += StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV");
                    continue;
                }

                // Add Ons
                if (StatementDataSet.OPNHCUST.Rows[i].Field<String>("CUSTHIST_PAY_REM_1").Trim() == "ADD")
                {
                    lnHoldUpdateAmount = StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_PAYMENT_RCV");
                    continue;
                }

                // Late Charges
                if (StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_LATE_CHARGE") > 0)
                {
                    lnHistoryLate = StatementDataSet.OPNHCUST.Rows[i].Field<Decimal>("CUSTHIST_LATE_CHARGE");
                }
            }
        }
    }
}

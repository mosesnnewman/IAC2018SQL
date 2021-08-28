using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class frmOpnNotices : Form
    {
        Int32 lnFormNo = 0, lnPTDiff = 0, lnPaidMonth = 0, lnPaidYear = 0;
        // 12/13/2011 Moses Newman removed all references to lnTotLateCharge as we are no longer using an itterative add, using SQL Query instead 
        Decimal lnLateCharge = 0, lnCustTotLateCharge = 0, lnCustContractStat = 0, lnCustLCBal = 0, lnCustBalance = 0;
        // End of 12/13/2011 Mod

        IACDataSetTableAdapters.WS_OPNNOT_DEALERTableAdapter WS_OPNNOT_DEALERTableAdapter = new IACDataSetTableAdapters.WS_OPNNOT_DEALERTableAdapter();
        BindingSource WS_OPNNOT_DEALERBindingSource = new BindingSource();

        QueryProgress lfrm;

        BackgroundWorker worker;

        public frmOpnNotices()
        {
            InitializeComponent();
        }

        private void frmOpnNotices_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }
        
        private void PostLateNotices()
        {
            IACDataSetTableAdapters.SystemTableAdapter SystemTableAdapter = new IACDataSetTableAdapters.SystemTableAdapter();

            int lnProgress = 0, lnTotalSteps = 0;

            opncustTableAdapter.CustomizeFill("SELECT * FROM OPNCUST WHERE CUSTOMER_ACT_STAT <> \'I\' AND CUSTOMER_CREDIT_STATUS <> \'Y\'");
            opncustTableAdapter.CustomFillBy(NoticeiacDataSet.OPNCUST);

            if (NoticeiacDataSet.OPNCUST.Rows.Count == 0)
            {
                MessageBox.Show("There are no customers that qualify for notices!");
                return;
            }
            opnnotTableAdapter.DeleteAll();    // Delete all previously created notices!
            WS_OPNNOT_DEALERTableAdapter.Fill(NoticeiacDataSet.WS_OPNNOT_DEALER);
            WS_OPNNOT_DEALERBindingSource.DataSource = NoticeiacDataSet.WS_OPNNOT_DEALER;

            SystemTableAdapter.Fill(NoticeiacDataSet.System,1);

            if (NoticeiacDataSet.System.Rows.Count == 0)
            {
                SystemTableAdapter.Insert(Convert.ToDateTime("01/01/1900"), (DateTime)NoticeDatenullableDateTimePicker.Value, Convert.ToDateTime("12/31/2013"));
            }
            else
                SystemTableAdapter.Update(NoticeiacDataSet.System.Rows[0].Field<DateTime>("ClosedNoticeRunDate"), (DateTime)NoticeDatenullableDateTimePicker.Value, NoticeiacDataSet.System.Rows[0].Field<DateTime>("LastUpdateDate"),1);

            SystemTableAdapter.Connection.Close();
            SystemTableAdapter.Dispose();
       
            lnTotalSteps = NoticeiacDataSet.OPNCUST.Rows.Count + 2;
            for (int i = 0; i < NoticeiacDataSet.OPNCUST.Rows.Count; i++)
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
            Decimal lnAmountDifference = 0;
            String lsDueYY = "", lsDueMM = "",lsDueDD = "",lsRDFCust = "";
            Int32 lnDueDD = 0, lnDueYY = 0, lnDueMM = 0, lnActDateDiff = 0;

            // Initialize for each record
            lnFormNo = 0;
            lnLateCharge = 0;
            lnCustLCBal = 0;
            lnCustBalance = 0;
            lnCustContractStat = 0;

            if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT") == "I" ||
                NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_CREDIT_STATUS") == "Y")
                return;

            lnAmountDifference = NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - 10;
            if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") > lnAmountDifference)
                return;

            // Moses Newman 12/19/2013 CUSTOMER_PAID_THRU_MM and CUSTOMER_PAID_THRU_YY are now computed fields so no need to set!
            lnDueMM = Convert.ToInt32(NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_MM"));
            lnDueYY = Convert.ToInt32(NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
            lnDueDD = NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE");

            lnPaidMonth = lnDueMM;
            lnPaidYear = lnDueYY;

            lnDueMM += 1;
            if (lnDueMM > 12)
            {
                lnDueMM = 1;
                lnDueYY += 1;
            }
            lsDueMM = lnDueMM.ToString().TrimStart();
            lsDueYY = lnDueYY.ToString().TrimStart();
            lsDueDD = lnDueDD.ToString().TrimStart();


            DateTime ldNewPaidThru, ldFormDate = (DateTime)NoticeDatenullableDateTimePicker.Value;
            // Moses Newman 04/26/2012 make form date actual DUE Date if 2/28 or 2/29(Leap Year)
            if (ldFormDate.Month == 2 && ldFormDate.Day > 27)
                ldFormDate = Convert.ToDateTime("03/01/" + DateTime.Now.Date.Year.ToString().Substring(2, 2)).AddDays(-1);

            if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && lnDueMM == 2)
            {
                // Moses Newman 04/26/2012 Make sure that Leap Year and normal February return 0 if DE_DATE = 30
                lsRDFCust = "03/01/" + DateTime.Now.Year.ToString().Substring(0, 2) + lsDueYY;
                // Moses Newman  04/26/2012 force lnFormDay to 30 so that NO form is created if entered due date is NOT 30!
                ldNewPaidThru = Convert.ToDateTime(lsRDFCust).Date.AddDays(-1);
            }
            else
            {
                lsRDFCust = lsDueMM + "/" + lsDueDD + "/" + DateTime.Now.Year.ToString().Substring(0, 2) + lsDueYY;
                ldNewPaidThru = Convert.ToDateTime(lsRDFCust).Date;
            }

            TimeSpan ltActDateDiff;
            ldFormDate = (DateTime)NoticeDatenullableDateTimePicker.Value;
            ltActDateDiff = ldFormDate - ldNewPaidThru;
            lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);

            if (lnActDateDiff == 0)
                if (!((ldFormDate.Year == ldNewPaidThru.Year) && (ldFormDate.Month == ldNewPaidThru.Month)))
                    return;

            if (((ldFormDate.Month < ldNewPaidThru.Month) && (ldFormDate.Year == ldNewPaidThru.Year))||
                (ldFormDate.Year < ldNewPaidThru.Year))
                return;

            if ((ldFormDate.Month == ldNewPaidThru.Month) && (ldFormDate.Year == ldNewPaidThru.Year))
                if (ldFormDate.Month == 3 && ldFormDate.Day <= 2)
                    return;

            if (ldFormDate.Day != ldNewPaidThru.Day)
                return;

            if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_MILITARY") == "Y")
                lnLateCharge = 0;
            else
            {
                lnLateCharge = 10;
            }

            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE", Math.Round(NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") + lnLateCharge,2));
            lnCustBalance = NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");

            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", Math.Round(NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") + lnLateCharge, 2));
            lnCustLCBal = NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL");

            GetFormNo(CustomerPos, lnActDateDiff);

            NewContractStatus(CustomerPos);

            lnCustContractStat = NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");

            if (lnCustContractStat < (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") * -1))
            {
                lnCustContractStat = (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") * -1);
                NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", lnCustContractStat);
            }

            if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_MILITARY") != "Y")
            {
                CustomerHistory(CustomerPos);
            }
            CreateForm(CustomerPos, ldNewPaidThru);   // Update last added NOTICE record do not insert
        }

        private void CustomerHistory(Int32 CustomerPos)
        {
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            BindingSource CUSTHISTBindingSource = new BindingSource();

            Int32 lnSeq = 0;
            Object loCustHistSeq = null;

            CUSTHISTBindingSource.DataSource = NoticeiacDataSet.OPNHCUST;

            CUSTHISTBindingSource.AddNew();
            CUSTHISTBindingSource.EndEdit();
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            // Moses Newman 03/08/2012 Added update of CUSTHIST_NUMBER
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_NUMBER", Convert.ToInt32(NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO")));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ADD_ON", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ADD_ON"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", DateTime.Now.Date);
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_IAC_TYPE", "O");
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", lnLateCharge);
            loCustHistSeq = OPNHCUSTTableAdapter.SeqNoQuery(NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), DateTime.Now.Date);
            if (loCustHistSeq != null)
                lnSeq = (int)loCustHistSeq + 1;
            else
                lnSeq = 1;
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", 0);
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU").TrimStart().TrimEnd().PadLeft(4,'0'));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE1", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE1"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE2", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE2"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE3", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE3"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "LATE");
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_1", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_1"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_2", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_2"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_3", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_3"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_4", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_4"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_5", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_5"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_6", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_6"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_7", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_7"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_8", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_8"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_9", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_9"));
            NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_10", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_10"));

            CUSTHISTBindingSource.EndEdit();
            OPNHCUSTTableAdapter.Update(NoticeiacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position]);
            NoticeiacDataSet.OPNHCUST.AcceptChanges();
        }

        private void ActDealerPost()
        {
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            BindingSource DEALERBindingSource = new BindingSource();

            Int32 lnProgress = 0, lnTotalWork = 0;

            DEALERBindingSource.DataSource = NoticeiacDataSet.OPNDEALR;

            lnTotalWork = NoticeiacDataSet.WS_OPNNOT_DEALER.Rows.Count;
            for (Int32 i = 0; i < NoticeiacDataSet.WS_OPNNOT_DEALER.Rows.Count; i++)
            {
                OPNDEALRTableAdapter.Fill(NoticeiacDataSet.OPNDEALR, NoticeiacDataSet.WS_OPNNOT_DEALER[i].Field<String>("KEY"));
                if (NoticeiacDataSet.OPNDEALR.Rows.Count != 0)
                {
                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_RSV", 0);
                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_CONT", 0);
                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_OLOAN", 0);
                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_ADJ", 0);
                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_BAD", 0);
                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_LOSS", 0);

                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<DateTime>("OPNDEALR_POST_DATE", DateTime.Now.Date);
                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_OLOAN", NoticeiacDataSet.WS_OPNNOT_DEALER.Rows[i].Field<Decimal>("OS_L"));
                    NoticeiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_OLOAN", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN") + NoticeiacDataSet.WS_OPNNOT_DEALER.Rows[i].Field<Decimal>("OS_L"));
                    DEALERBindingSource.EndEdit();
                    OPNDEALRTableAdapter.Update(NoticeiacDataSet.OPNDEALR.Rows[0]);
                    NoticeiacDataSet.OPNDEALR.AcceptChanges();
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

            DEALHISTBindingSource.DataSource = NoticeiacDataSet.OPNHDEAL;

            DEALHISTBindingSource.AddNew();
            DEALHISTBindingSource.EndEdit();

            // Start of DEALHIST KEY Fields
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_ACC_NO", NoticeiacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_POST_DATE", DateTime.Now.Date);
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_LAST_POST_DATE", NoticeiacDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE"));
            loDealerHistSeq = OPNHDEALTableAdapter.SeqNoQuery(NoticeiacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"), DateTime.Now.Date, NoticeiacDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE"));
            if (loDealerHistSeq != null)
                lnSeq = (int)loDealerHistSeq + 1;
            else
                lnSeq = 0;
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
            // End of DEALHIST KEY Fields
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_RSV", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_RSV"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_CONT", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_CONT"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLOAN", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_OLOAN"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_ADJ", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_ADJ"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_BAD", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_BAD"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_LOSS", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_LOSS"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_RSV", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_RSV"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_CONT", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_CONT"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLOAN", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_ADJ", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_ADJ"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_BAD", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_BAD"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_LOSS", NoticeiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_LOSS"));
            NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_POST_CODE", "L");
            DEALHISTBindingSource.EndEdit();
            OPNHDEALTableAdapter.Update(NoticeiacDataSet.OPNHDEAL.Rows[DEALHISTBindingSource.Position]);
            NoticeiacDataSet.OPNHDEAL.AcceptChanges();
        }

        private void GetFormNo(Int32 CustomerPos,Int32 lnActDiff)
        {
            if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE") == 0)
            {
                lnFormNo = 0;
                return;
            }
            else
                if (lnActDiff == 0)
                {
                    lnFormNo = 1;
                    return;
                }
                else
                    if (lnActDiff < 1)
                        return;
            lnFormNo = (lnActDiff / 5) + 1;
            if (lnFormNo > 6)
                lnFormNo = 6;
        }

        private Int32 CheckFirstPayment(Int32 CustomerPos,DateTime ldACTDate)
        {
            DateTime ldFirstPayment;
            DateTime? ldFirstPaymentTemp = NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<DateTime?>("CUSTOMER_INIT_DATE");

            if (ldFirstPaymentTemp == null)
                return 0;
            else
                ldFirstPayment = (DateTime)ldFirstPaymentTemp;
            Int32 lnNoYRS = 0, lnFirstPayMM = 0, lnFirstPayDD = 0, lnFirstPayYY = 0, lnActDateDiff = 0;

            lnFirstPayDD = ldFirstPayment.Day;
            lnFirstPayMM = ldFirstPayment.Month;
            lnFirstPayMM += NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM");

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

        private void CreateForm(Int32 CustomerPos,DateTime ldNewDueDate)
        {
            NoticebindingSource.AddNew();
            NoticebindingSource.EndEdit();
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_NAME", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_FIRST_NAME") + NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_LAST_NAME"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_NO", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_ADD_ON", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ADD_ON"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_IAC_TYPE", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_IAC_TYPE"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_DEALER", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_DEALER"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<Int32>("NOTICE_DAY_DUE", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_STREET_1", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_STREET_1"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_PHONE_NO", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PHONE_NO"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_WORK_PHONE", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_WORK_PHONE"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_CITY", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_CITY"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_STATE", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_STATE"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_ZIP_CODE", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ZIP_1") + ((NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ZIP_2").TrimEnd() == "") ? "":"-" + NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ZIP_2")));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<Int32>("NOTICE_FORM_NO", lnFormNo);
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<DateTime>("NOTICE_LATE_DATE", ldNewDueDate);
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_CONTRACT_STATUS", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_REGULAR_AMOUNT", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_BALANCE", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_LATE_CHARGE", lnLateCharge);
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_LATE_CHARGE_BAL", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_WRONG_ADDRESS", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_WRONG_ADDRESS"));
            // Moses Newman 09/25/2013 fix crash when legth of customer_street_2 < 25
            if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_STREET_2").Length > 25)
                NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_CO_NAME", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_STREET_2").Substring(0, 25));
            else
                NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_CO_NAME", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_STREET_2"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_DISTRIBUTOR_NO", Convert.ToString(NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_DISTRIBUTOR_NO")));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_PAID_THRU", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<DateTime>("NOTICE_SYSTEM_DATE", DateTime.Now.Date);
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_ALLOTMENT_PROGRAM", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ALLOTMENT"));
            NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_AUTO_PAY", NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_AUTO_PAY"));
            if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_MILITARY") == "Y")
                NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_MILITARY", "Y");
            NoticebindingSource.EndEdit();
            opnnotTableAdapter.Update(NoticeiacDataSet.OPNNOT.Rows[NoticebindingSource.Position]);
            NoticeiacDataSet.OPNNOT.AcceptChanges();
            // 12/2/2011 Moses Newman no longer using SumDealerTotals.  WS_OPNNOT_DEALER.Fill sums automatically
            WS_OPNNOT_DEALERTableAdapter.Fill(NoticeiacDataSet.WS_OPNNOT_DEALER);
            // End of 12/2/2011 Mods
            update_customer(CustomerPos);
        }

        private void UpdateMaster()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            BindingSource MASTERBindingSource = new BindingSource();

            MASTERBindingSource.DataSource = NoticeiacDataSet.MASTER;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            String lsMasterKey = (String)loMasterKey;

            // 12/15/2011 Moses Newman added accumulator for OS_L sum
            Decimal lnOSL = 0;
            for(Int32 i = 0; i < NoticeiacDataSet.WS_OPNNOT_DEALER.Rows.Count; i++)
                lnOSL += NoticeiacDataSet.WS_OPNNOT_DEALER.Rows[i].Field<Decimal>("OS_L");

            MASTERTableAdapter.Fill(NoticeiacDataSet.MASTER, lsMasterKey);

            if (NoticeiacDataSet.MASTER.Rows.Count != 0)
            {
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                NoticeiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                // 12/13/2011 Moses Newman removed reference to lnTotLateCharge because we now use SQL query instead of itterative add "penny issue"
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", lnOSL);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_OLOAN", NoticeiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN") + lnOSL);
                // End of mod
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(NoticeiacDataSet.MASTER.Rows[0]);
                NoticeiacDataSet.MASTER.AcceptChanges();
            }
        }

        private void CreateMastHist()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
            BindingSource MASTHISTBindingSource = new BindingSource();

            MASTHISTBindingSource.DataSource = NoticeiacDataSet.MASTHIST;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS"),loMasterHistSeq = null;
            String lsMasterKey = (String)loMasterKey;
            Int32 lnSeq = 0;

            MASTERTableAdapter.Fill(NoticeiacDataSet.MASTER, lsMasterKey);
            if (NoticeiacDataSet.MASTER.Rows.Count != 0)
            {
                MASTHISTBindingSource.AddNew();
                MASTHISTBindingSource.EndEdit();
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO",NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", NoticeiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), NoticeiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                if (loMasterHistSeq != null)
                    lnSeq = (int)loMasterHistSeq + 1;
                else
                    lnSeq = 1;
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_OLOAN", NoticeiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_OLOAN"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_OLOAN", NoticeiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_NOTES", 0);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_NOTES", NoticeiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
                MASTHISTBindingSource.EndEdit();
                MASTHISTTableAdapter.Update(NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                NoticeiacDataSet.MASTHIST.AcceptChanges();
            }

        }

        private void update_customer(Int32 CustomerPos)
        {
            BindingSource CUSTOMERBindingSource = new BindingSource();

            CUSTOMERBindingSource.DataSource = NoticeiacDataSet.OPNCUST;

            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", lnLateCharge);
            //NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<DateTime>("CUSTOMER_LAST_LC_DATE", DateTime.Now.Date);
            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", lnCustContractStat);
            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE", lnCustTotLateCharge);
            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", lnCustLCBal);
            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE", lnCustBalance);
            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Int32>("CUSTOMER_FORM_NO", 0);

            CUSTOMERBindingSource.EndEdit();
            opncustTableAdapter.Update(NoticeiacDataSet.OPNCUST.Rows[CustomerPos]);
            NoticeiacDataSet.OPNCUST.AcceptChanges();
        }

        private void MonthDifference(Int32 CustomerPos,DateTime tdCustDate)
        {
            // Same year but current month
            if (tdCustDate.Year == DateTime.Now.Year && tdCustDate.Month > DateTime.Now.Month)
            {
                lnPTDiff = 0;
                return;
            }
            // Same year
            if (tdCustDate.Year == DateTime.Now.Year)
            {
                lnPTDiff = DateTime.Now.Month - tdCustDate.Month;
                if (NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") > DateTime.Now.Day)
                    lnPTDiff += 1;
                return;
            }
            // Different year
            if (tdCustDate.Year != DateTime.Now.Year)
            {
                lnPTDiff = ((12 - tdCustDate.Month) + DateTime.Now.Month);
                if (tdCustDate.Day > DateTime.Now.Day)
                    lnPTDiff -= 1;
            }
        }

        private void NewContractStatus(Int32 CustomerPos)
        {
            OpenPaymentPosting OPPaypost = new OpenPaymentPosting();
            
            NoticeiacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE", 
                NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE") + 10);
            // 12/9/2011 Moses Newman now call same OpenNewContractStatus as OpenPaymentPosting uses
            OPPaypost.OpenNewContractStatus(CustomerPos, ref NoticeiacDataSet);
            // End 12/9/2011 Mod
            lnCustContractStat = NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");
            lnCustTotLateCharge = NoticeiacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE");
        }

        private void NoticeDatenullableDateTimePicker_Validated(object sender, EventArgs e)
        {
            DateTime? ldCurrentDate = (DateTime?)NoticeDatenullableDateTimePicker.Value;
            if (ldCurrentDate.Value != null)
                if (ldCurrentDate.Value.Month == 2 && ldCurrentDate.Value.Day == 30)
                    NoticeDatenullableDateTimePicker.Value = Convert.ToDateTime("02/28" + ldCurrentDate.Value.Year.ToString());
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_PostLateNotices);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Open Notice Posting";
            lfrm.lblProgress.Text = "Posting Open Side Notices";
            lfrm.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            opncustTableAdapter.Connection.Close();
            opncustTableAdapter.Dispose();
            opnnotTableAdapter.Connection.Close();
            opnnotTableAdapter.Dispose();
            NoticeiacDataSet.Dispose();
            Close();
        }

        private void worker_PostLateNotices(object sender, DoWorkEventArgs e)
        {
            PostLateNotices();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            opncustTableAdapter.Connection.Close();
            opncustTableAdapter.Dispose();
            opnnotTableAdapter.Connection.Close();
            opnnotTableAdapter.Dispose();
            NoticeiacDataSet.Dispose();
            Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.Value = e.ProgressPercentage;
        }

    }
}

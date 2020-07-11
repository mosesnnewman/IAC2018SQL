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
    public partial class frmOpenAddOnPost : Form
    {
        Decimal lnMASTER_OS_LOANS = 0,lnBalance = 0;
        IACDataSetTableAdapters.OPNUPDATTableAdapter OPNUPDATTableAdapter = new IACDataSetTableAdapters.OPNUPDATTableAdapter();
        IACDataSetTableAdapters.ADD_ON_WS_DEALERTableAdapter ADD_ON_WS_DEALERTableAdapter = new IACDataSetTableAdapters.ADD_ON_WS_DEALERTableAdapter();
        BindingSource OPNUPDATBindingSource = new BindingSource();

        QueryProgress lfrm;

        BackgroundWorker worker;

        public frmOpenAddOnPost()
        {
            InitializeComponent();
        }

        private void frmOpenAddOnPost_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }

        private void PostAddOns()
        {
            lnMASTER_OS_LOANS = 0; 

            ADD_ON_WS_DEALERTableAdapter.Fill(AddOniacDataSet.ADD_ON_WS_DEALER);

            OPNUPDATTableAdapter.FillAll(AddOniacDataSet.OPNUPDAT);
            if (AddOniacDataSet.OPNUPDAT.Rows.Count == 0)
            {
                MessageBox.Show("There are no unposted dealer AddOn records!");
                return;
            }

            worker.ReportProgress(20);
            for (Int32 i = 0; i < AddOniacDataSet.OPNUPDAT.Rows.Count; i++)
            {
                lnBalance = 0;
                PostUpdateAmount(i);
                worker.ReportProgress((Int32)(i/AddOniacDataSet.OPNUPDAT.Rows.Count));
            }
            ActDealerPost();
            worker.ReportProgress(60);
            PostOloans();
            worker.ReportProgress(80);
            CreateMastHist();
            worker.ReportProgress(90);
            OPNUPDATTableAdapter.DeleteAll();
            worker.ReportProgress(100);
        }


        private void PostUpdateAmount(Int32 UpdatePos)
        {
            Int32 CustomerPos;
            BindingSource OPNCUSTBindingSource = new BindingSource();
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();

            OPNCUSTTableAdapter.Fill(AddOniacDataSet.OPNCUST,AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<String>("UPDATE_CUSTOMER"));

            if (AddOniacDataSet.OPNCUST.Rows.Count == 0)
                return;
            else
                CustomerPos = 0;

            OPNCUSTBindingSource.DataSource = AddOniacDataSet.OPNCUST;
            OPNCUSTBindingSource.Position = CustomerPos;

            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE",AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") + AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_AMOUNT_RCV"));
            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_UPDATE_AMOUNT", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_AMOUNT_RCV"));
            lnBalance += AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_AMOUNT_RCV");
            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<String>("CUSTOMER_PAY_REM_1", "ADD");
            // Moses Newman 01/31/2014 Fix UPDATE_NEW_REG_AMOUNT filed so it is populated with 0 and NOT NULL as default value.
            if (AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Nullable<Decimal>>("UPDATE_NEW_REG_AMOUNT") == null)
                AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].SetField<Decimal>("UPDATE_NEW_REG_AMOUNT", 0); 
            if(AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_NEW_REG_AMOUNT") != 0)
                if (AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") != AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_NEW_REG_AMOUNT"))
                    if(AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REG_AMOUNT1") == 0)
                    {
                        AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_REG_AMOUNT1", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                        AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Int32>("CUSTOMER_STAT1", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_STATUS_NO"));
                        AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Int32>("CUSTOMER_STATUS_NO", 0);
                        AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_NEW_REG_AMOUNT"));
                    }
                    else
                        if (AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REG_AMOUNT2") == 0)
                        {
                            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_REG_AMOUNT2", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Int32>("CUSTOMER_STAT2", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_STATUS_NO"));
                            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Int32>("CUSTOMER_STATUS_NO", 0);
                            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_NEW_REG_AMOUNT"));
                        }
                        else
                            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_NEW_REG_AMOUNT"));
            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Int32>("CUSTOMER_STATE1", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Int32>("UPDATE_STATE_CODE"));
            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_INTEREST_RATE1", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_INT1"));
            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_INTEREST_RATE2", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_INT2"));
            AddOniacDataSet.OPNCUST.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_INTEREST_RATE3", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_INT3"));
            lnMASTER_OS_LOANS += lnBalance;
            OPNCUSTBindingSource.EndEdit();
            OPNCUSTTableAdapter.Update(AddOniacDataSet.OPNCUST.Rows[CustomerPos]);
            AddOniacDataSet.OPNCUST.AcceptChanges();
            CustomerHistory(CustomerPos, UpdatePos);
        }

        private void CustomerHistory(Int32 CustomerPos,Int32 UpdatePos)
        {
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            BindingSource CUSTHISTBindingSource = new BindingSource();

            Int32 lnSeq = 0;
            Object loCustHistSeq = null;

            CUSTHISTBindingSource.DataSource = AddOniacDataSet.OPNHCUST;

            CUSTHISTBindingSource.AddNew();
            CUSTHISTBindingSource.EndEdit();
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<String>("UPDATE_CUSTOMER"));
            // Moses Newman 03/08/2012 Added Update of CUSTHIST_NUMBER
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_NUMBER", Convert.ToInt32(AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<String>("UPDATE_CUSTOMER")));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ADD_ON", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<String>("UPDATE_ADD_ON"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_IAC_TYPE", "O");
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", DateTime.Now.Date);
            // Moses Newman 03/08/2012 Added Update of CUSTHIST_DATE
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_DATE", DateTime.Now.Date);
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<Decimal>("UPDATE_AMOUNT_RCV"));
            loCustHistSeq = OPNHCUSTTableAdapter.SeqNoQuery(AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<String>("UPDATE_CUSTOMER"), DateTime.Now.Date);
            if (loCustHistSeq != null)
                lnSeq = (int)loCustHistSeq + 1;
            else
                lnSeq = 1;
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "ADD");
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE1", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE1"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE2", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE2"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_INTEREST_RATE3", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_INTEREST_RATE3"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_1", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_1"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_2", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_2"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_3", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_3"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_4", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_4"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_5", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_5"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_6", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_6"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_7", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_7"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_8", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_8"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_9", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_9"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_10", AddOniacDataSet.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_10"));
            AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_UPDATE_TYPE", AddOniacDataSet.OPNUPDAT.Rows[UpdatePos].Field<String>("UPDATE_TYPE"));

            CUSTHISTBindingSource.EndEdit();
            OPNHCUSTTableAdapter.Update(AddOniacDataSet.OPNHCUST.Rows[CUSTHISTBindingSource.Position]);
            AddOniacDataSet.OPNHCUST.AcceptChanges();
        }


        private void ActDealerPost()
        {
            Int32 lnProgress = 0,lnTotalWork = 0;
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            BindingSource OPNDEALRBindingSource = new BindingSource();

            OPNDEALRBindingSource.DataSource = AddOniacDataSet.OPNDEALR;

            lnTotalWork = AddOniacDataSet.ADD_ON_WS_DEALER.Rows.Count;
            for (Int32 i = 0; i < AddOniacDataSet.ADD_ON_WS_DEALER.Count; i++)
            {
                OPNDEALRTableAdapter.Fill(AddOniacDataSet.OPNDEALR, AddOniacDataSet.ADD_ON_WS_DEALER[i].Field<String>("KEY"));
                if (AddOniacDataSet.OPNDEALR.Rows.Count != 0)
                {
                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_RSV", 0);
                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_CONT", 0);
                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_OLOAN", 0);
                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_ADJ", 0);
                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_BAD", 0);
                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_LOSS", 0);

                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_OLOAN", AddOniacDataSet.ADD_ON_WS_DEALER.Rows[i].Field<Decimal>("OS_L"));
                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_OLOAN", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN") + AddOniacDataSet.ADD_ON_WS_DEALER.Rows[i].Field<Decimal>("OS_L"));
                    AddOniacDataSet.OPNDEALR.Rows[0].SetField<DateTime>("OPNDEALR_POST_DATE", DateTime.Now.Date);

                    OPNDEALRBindingSource.EndEdit();
                    OPNDEALRTableAdapter.Update(AddOniacDataSet.OPNDEALR.Rows[0]);
                    AddOniacDataSet.OPNDEALR.AcceptChanges();
                    DealHistPost();
                    lnProgress = (Int32)Math.Round(((Double)i / (Double)lnTotalWork) * (Double)100,2);
                    worker.ReportProgress(lnProgress);
                }
            }
        }

        private void DealHistPost()
        {
            Int32 lnSeq = 0;
            Object loDealerHistSeq = null;

            IACDataSetTableAdapters.OPNHDEALTableAdapter OPNHDEALTableAdapter = new IACDataSetTableAdapters.OPNHDEALTableAdapter();
            BindingSource OPNHDEALBindingSource = new BindingSource();

            OPNHDEALBindingSource.DataSource = AddOniacDataSet.OPNHDEAL;

            OPNHDEALBindingSource.AddNew();
            OPNHDEALBindingSource.EndEdit();

            // Start of DEALHIST KEY Fields
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<String>("DEALHIST_ACC_NO", AddOniacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<DateTime>("DEALHIST_POST_DATE", DateTime.Now.Date);
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<DateTime>("DEALHIST_LAST_POST_DATE", AddOniacDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE"));
            loDealerHistSeq = OPNHDEALTableAdapter.SeqNoQuery(AddOniacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"), DateTime.Now.Date, AddOniacDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE"));
            if (loDealerHistSeq != null)
                lnSeq = (int)loDealerHistSeq + 1;
            else
                lnSeq = 0;
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
            // End of DEALHIST KEY Fields
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_RSV", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_RSV"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_CONT", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_CONT"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLOAN", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_OLOAN"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_ADJ", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_ADJ"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_BAD", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_BAD"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_LOSS", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_LOSS"));

            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_RSV", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_RSV"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_CONT", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_CONT"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLOAN", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_ADJ", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_ADJ"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_BAD", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_BAD"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_LOSS", AddOniacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_LOSS"));
            AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<String>("DEALHIST_POST_CODE", "A");
            OPNHDEALBindingSource.EndEdit();
            OPNHDEALTableAdapter.Update(AddOniacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position]);
            AddOniacDataSet.OPNHDEAL.AcceptChanges();
        }

        private void PostOloans()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            BindingSource MASTERBindingSource = new BindingSource();
            Object loMasterKey = null;
            String lsMasterKey = "";

            MASTERBindingSource.DataSource = AddOniacDataSet.MASTER;


            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(AddOniacDataSet.MASTER, lsMasterKey);

            if (AddOniacDataSet.MASTER.Rows.Count != 0)
            {
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", lnMASTER_OS_LOANS);
                AddOniacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_OLOAN", AddOniacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN") + lnMASTER_OS_LOANS);
                AddOniacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(AddOniacDataSet.MASTER.Rows[0]);
                AddOniacDataSet.MASTER.AcceptChanges();
            }
        }

        private void CreateMastHist()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
            BindingSource MASTHISTBindingSource = new BindingSource();

            MASTHISTBindingSource.DataSource = AddOniacDataSet.MASTHIST;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS"),loMasterHistSeq = null;
            String lsMasterKey = (String)loMasterKey;
            Int32 lnSeq = 0;

            MASTERTableAdapter.Fill(AddOniacDataSet.MASTER, lsMasterKey);
            if (AddOniacDataSet.MASTER.Rows.Count != 0)
            {
                if (AddOniacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_OLOAN") != 0)
                {
                    MASTHISTBindingSource.AddNew();
                    MASTHISTBindingSource.EndEdit();
                    AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", AddOniacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", AddOniacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(AddOniacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), AddOniacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    if (loMasterHistSeq != null)
                        lnSeq = (int)loMasterHistSeq + 1;
                    else
                        lnSeq = 1;
                    AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", AddOniacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                    AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_OLOAN", AddOniacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_OLOAN"));
                    AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_OLOAN", AddOniacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN"));
                    AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_NOTES", AddOniacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES"));
                    AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(AddOniacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    AddOniacDataSet.MASTHIST.AcceptChanges();
                }
            }
        }

        private void worker_PostAddOns(object sender, DoWorkEventArgs e)
        {
            PostAddOns();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_PostAddOns);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Open Dealer AddOn Posting";
            lfrm.lblProgress.Text = "Posting Open Dealer AddOns";
            lfrm.ShowDialog();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OPNUPDATTableAdapter.Connection.Close();
            OPNUPDATTableAdapter.Dispose();
            ADD_ON_WS_DEALERTableAdapter.Connection.Close();
            ADD_ON_WS_DEALERTableAdapter.Dispose();
            AddOniacDataSet.Dispose();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            OPNUPDATTableAdapter.Connection.Close();
            OPNUPDATTableAdapter.Dispose();
            ADD_ON_WS_DEALERTableAdapter.Connection.Close();
            ADD_ON_WS_DEALERTableAdapter.Dispose();
            AddOniacDataSet.Dispose();
            Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.Value = e.ProgressPercentage;
        }

    }
}

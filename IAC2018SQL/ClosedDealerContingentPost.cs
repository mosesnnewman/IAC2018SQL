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
    public partial class frmClosedDealerContingentPost : DevExpress.XtraEditors.XtraForm
    {
        Decimal lnMASTER_LOSS = 0, lnMASTER_CONT = 0, lnMASTER_ADJ = 0, lnMASTER_BAD = 0, lnMASTER_RSV = 0, lnMASTER_OS_LOANS = 0, lnMASTER_NOTES = 0,
                lnMASTER_AMORT_INT = 0;
        IACDataSetTableAdapters.CONTINGTableAdapter CONTINGTableAdapter = new IACDataSetTableAdapters.CONTINGTableAdapter();
        IACDataSetTableAdapters.WSDEALERCONTTableAdapter WSDEALERCONTTableAdapter = new IACDataSetTableAdapters.WSDEALERCONTTableAdapter();
        BindingSource CONTINGBindingSource = new BindingSource();
        BindingSource WS_DEALER_CONTBindingSource = new BindingSource();

        QueryProgress lfrm;

        BackgroundWorker worker;

        public frmClosedDealerContingentPost()
        {
            InitializeComponent();
        }

        private void frmClosedDealerContingentPost_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }

        private void PostContingents()
        {
            WSDEALERCONTTableAdapter.Fill(ContingiacDataSet.WS_DEALER_CONT);

            if (ContingiacDataSet.WS_DEALER_CONT.Rows.Count == 0)
            {
                MessageBox.Show("There are no unposted dealer contingent records!");
                return;
            }

            try
            {
                // Moses Newman 05/3/2014 Get rid of SQL Pass Through!
                CONTINGTableAdapter.MarkPosted(); 
            }
            catch(Exception e)
            {
                MessageBox.Show("There is an error: " + e.Message);
            }


            worker.ReportProgress(20);

            ActDealerPost();
            worker.ReportProgress(60);
            UpdateMaster();
            worker.ReportProgress(80);
            CreateMastHist();
            worker.ReportProgress(100);
        }



        private void ActDealerPost()
        {
            Int32 lnProgress = 0,lnTotalWork = 0;
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            BindingSource DEALERBindingSource = new BindingSource();

            DEALERBindingSource.DataSource = ContingiacDataSet.DEALER;

            lnTotalWork = ContingiacDataSet.WS_DEALER_CONT.Rows.Count;
            for (Int32 i = 0; i < ContingiacDataSet.WS_DEALER_CONT.Rows.Count; i++)
            {
                DEALERTableAdapter.Fill(ContingiacDataSet.DEALER, ContingiacDataSet.WS_DEALER_CONT[i].Field<Int32>("KEY"));
                if (ContingiacDataSet.DEALER.Rows.Count != 0)
                {
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_LOSS",       ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("LOSS_RES"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_CONT",       ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("CONTRACT"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_ADJ",        ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("ADJUST"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_BAD",        ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("RECOV_BAD"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_RSV",        ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("RES_LOSS"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLOAN",      ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("OS_LOANS"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_AMORT_INT",  ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("AMORT_INT"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLD_INT",    ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("OLD_INT"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_AMORT_PDI",  ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("AMORT_PDI"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLD_PDI",    ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("OLD_PDI"));

                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_LOSS") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_LOSS", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_CONT") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_CONT", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_ADJ") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_ADJ", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_BAD") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_BAD", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_RSV") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_RSV", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_OLOAN") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLOAN", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_AMORT_INT") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_AMORT_INT", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_OLD_INT") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLD_INT", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_AMORT_PDI") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_AMORT_PDI", 0);
                    if (ContingiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_OLD_PDI") == null)
                        ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLD_PDI", 0);
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_LOSS",       ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_LOSS")      + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("LOSS_RES"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_CONT",       ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_CONT")      + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("CONTRACT"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_ADJ",        ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_ADJ")       + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("ADJUST"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_BAD",        ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_BAD")       + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("RECOV_BAD"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_RSV",        ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_RSV")       + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("RES_LOSS"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLOAN",      ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN")     + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("OS_LOANS"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_AMORT_INT",  ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_INT") + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("AMORT_INT"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLD_INT",    ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_INT")   + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("OLD_INT"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_AMORT_PDI",  ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_PDI") + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("AMORT_PDI"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLD_PDI",    ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_PDI")   + ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("OLD_PDI"));
                    ContingiacDataSet.DEALER.Rows[0].SetField<DateTime>("DEALER_POST_DATE", DateTime.Now.Date);

                    lnMASTER_LOSS       += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("LOSS_RES");
                    lnMASTER_CONT       += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("CONTRACT");
                    lnMASTER_ADJ        += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("ADJUST");
                    lnMASTER_BAD        += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("RECOV_BAD");
                    lnMASTER_RSV        += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("RES_LOSS");
                    lnMASTER_OS_LOANS   += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("OS_LOANS");
                    lnMASTER_NOTES      += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("NOTES");
                    lnMASTER_AMORT_INT  += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("AMORT_INT");
                    lnMASTER_AMORT_INT  += ContingiacDataSet.WS_DEALER_CONT.Rows[i].Field<Decimal>("OLD_INT");

                    DEALERBindingSource.EndEdit();
                    DEALERTableAdapter.Update(ContingiacDataSet.DEALER.Rows[0]);
                    ContingiacDataSet.DEALER.AcceptChanges();
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

            IACDataSetTableAdapters.DEALHISTTableAdapter DEALHISTTableAdapter = new IACDataSetTableAdapters.DEALHISTTableAdapter();
            BindingSource DEALHISTBindingSource = new BindingSource();

            DEALHISTBindingSource.DataSource = ContingiacDataSet.DEALHIST;

            DEALHISTBindingSource.AddNew();
            DEALHISTBindingSource.EndEdit();

            // Start of DEALHIST KEY Fields
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Int32>("DEALHIST_ACC_NO", ContingiacDataSet.DEALER.Rows[0].Field<Int32>("id"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_POST_DATE", DateTime.Now.Date);
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_LAST_POST_DATE", ContingiacDataSet.DEALER.Rows[0].Field<DateTime>("DEALER_POST_DATE"));
            loDealerHistSeq = DEALHISTTableAdapter.SeqNoQuery(ContingiacDataSet.DEALER.Rows[0].Field<Int32>("DEALER_ACC_NO"), DateTime.Now.Date, ContingiacDataSet.DEALER.Rows[0].Field<DateTime>("DEALER_POST_DATE").Date);
            if (loDealerHistSeq != null)
                lnSeq = (int)loDealerHistSeq + 1;
            else
                lnSeq = 0;
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
            // End of DEALHIST KEY Fields
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_RSV", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_RSV"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_CONT", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_CONT"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLOAN", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLOAN"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_ADJ", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_ADJ"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_BAD", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_BAD"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_LOSS", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_LOSS"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_AMORT_INT", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_AMORT_INT"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLD_INT", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLD_INT"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_AMORT_PDI", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_AMORT_PDI"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLD_PDI", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLD_PDI"));

            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_RSV", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_RSV"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_CONT", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_CONT"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLOAN", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_ADJ", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_ADJ"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_BAD", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_BAD"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_LOSS", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_LOSS"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_AMORT_INT", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_INT"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLD_INT", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_INT"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_AMORT_PDI", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_PDI"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLD_PDI", ContingiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_PDI"));
            ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_POST_CODE", "C");
            DEALHISTBindingSource.EndEdit();
            DEALHISTTableAdapter.Update(ContingiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position]);
            ContingiacDataSet.DEALHIST.AcceptChanges();
        }

        private void UpdateMaster()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            BindingSource MASTERBindingSource = new BindingSource();

            MASTERBindingSource.DataSource = ContingiacDataSet.MASTER;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("BAD_DEBTS");
            String lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);

            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", lnMASTER_BAD);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_BAD", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_BAD") + lnMASTER_BAD);
                ContingiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(ContingiacDataSet.MASTER.Rows[0]);
                ContingiacDataSet.MASTER.AcceptChanges();
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("RES_LOSS");
            lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);

            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", lnMASTER_RSV);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_RSV", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_RSV") + lnMASTER_RSV);
                ContingiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(ContingiacDataSet.MASTER.Rows[0]);
                ContingiacDataSet.MASTER.AcceptChanges();
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("LOSS_RES");
            lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);

            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", lnMASTER_LOSS);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_LOSS", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_LOSS") + lnMASTER_LOSS);
                ContingiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(ContingiacDataSet.MASTER.Rows[0]);
                ContingiacDataSet.MASTER.AcceptChanges();
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("ADJUST");
            lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);

            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", lnMASTER_ADJ);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_ADJ", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_ADJ") + lnMASTER_ADJ);
                ContingiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(ContingiacDataSet.MASTER.Rows[0]);
                ContingiacDataSet.MASTER.AcceptChanges();
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("CONTING");
            lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);

            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", lnMASTER_CONT);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_CONT", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_CONT") + lnMASTER_CONT);
                ContingiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(ContingiacDataSet.MASTER.Rows[0]);
                ContingiacDataSet.MASTER.AcceptChanges();
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);

            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", lnMASTER_NOTES);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_NOTES", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES") + lnMASTER_NOTES);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", lnMASTER_OS_LOANS);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_OLOAN", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN") + lnMASTER_OS_LOANS);
                ContingiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(ContingiacDataSet.MASTER.Rows[0]);
                ContingiacDataSet.MASTER.AcceptChanges();
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("AMORT_INT");
            lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);

            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", lnMASTER_AMORT_INT);
                ContingiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_YTD_INT", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_AMORT_YTD_INT") + lnMASTER_AMORT_INT);
                ContingiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(ContingiacDataSet.MASTER.Rows[0]);
                ContingiacDataSet.MASTER.AcceptChanges();
            }
        }

        public void CreateMastHist()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
            BindingSource MASTHISTBindingSource = new BindingSource();

            MASTHISTBindingSource.DataSource = ContingiacDataSet.MASTHIST;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS"),loMasterHistSeq = null;
            String lsMasterKey = (String)loMasterKey;
            Int32 lnSeq = 0;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);
            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                if (ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_OLOAN") != 0 || ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_NOTES") != 0)
                {
                    MASTHISTBindingSource.AddNew();
                    MASTHISTBindingSource.EndEdit();
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    if (loMasterHistSeq != null)
                        lnSeq = (int)loMasterHistSeq + 1;
                    else
                        lnSeq = 1;
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_OLOAN", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_OLOAN"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_OLOAN", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_NOTES", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_NOTES"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_NOTES", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    ContingiacDataSet.MASTHIST.AcceptChanges();
                }
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("CONTING");
            loMasterHistSeq = null;
            lsMasterKey = (String)loMasterKey;
            lnSeq = 0;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);
            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                if (ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_CONT") != 0)
                {
                    MASTHISTBindingSource.AddNew();
                    MASTHISTBindingSource.EndEdit();
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    if (loMasterHistSeq != null)
                        lnSeq = (int)loMasterHistSeq + 1;
                    else
                        lnSeq = 1;
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_CONT", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_CONT"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_CONT", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_CONT"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    ContingiacDataSet.MASTHIST.AcceptChanges();
                }
            }
            loMasterKey = ACCOUNTTableAdapter.AccountNumber("ADJUST");
            loMasterHistSeq = null;
            lsMasterKey = (String)loMasterKey;
            lnSeq = 0;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);
            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                if (ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_ADJ") != 0)
                {
                    MASTHISTBindingSource.AddNew();
                    MASTHISTBindingSource.EndEdit();
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    if (loMasterHistSeq != null)
                        lnSeq = (int)loMasterHistSeq + 1;
                    else
                        lnSeq = 1;
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_ADJ", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_ADJ"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_ADJ", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_ADJ"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    ContingiacDataSet.MASTHIST.AcceptChanges();
                }
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("LOSS_RES");
            loMasterHistSeq = null;
            lsMasterKey = (String)loMasterKey;
            lnSeq = 0;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);
            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                if (ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_LOSS") != 0)
                {
                    MASTHISTBindingSource.AddNew();
                    MASTHISTBindingSource.EndEdit();
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    if (loMasterHistSeq != null)
                        lnSeq = (int)loMasterHistSeq + 1;
                    else
                        lnSeq = 1;
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_LOSS", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_LOSS"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_LOSS", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_LOSS"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    ContingiacDataSet.MASTHIST.AcceptChanges();
                }
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("RES_LOSS");
            loMasterHistSeq = null;
            lsMasterKey = (String)loMasterKey;
            lnSeq = 0;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);
            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                if (ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_RSV") != 0)
                {
                    MASTHISTBindingSource.AddNew();
                    MASTHISTBindingSource.EndEdit();
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    if (loMasterHistSeq != null)
                        lnSeq = (int)loMasterHistSeq + 1;
                    else
                        lnSeq = 1;
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_RSV", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_RSV"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_RSV", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_RSV"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    ContingiacDataSet.MASTHIST.AcceptChanges();
                }
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("BAD_DEBTS");
            loMasterHistSeq = null;
            lsMasterKey = (String)loMasterKey;
            lnSeq = 0;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);
            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                if (ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_BAD") != 0)
                {
                    MASTHISTBindingSource.AddNew();
                    MASTHISTBindingSource.EndEdit();
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    if (loMasterHistSeq != null)
                        lnSeq = (int)loMasterHistSeq + 1;
                    else
                        lnSeq = 1;
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_BAD", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_BAD"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_BAD", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_BAD"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    ContingiacDataSet.MASTHIST.AcceptChanges();
                }
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("AMORT_INT");
            loMasterHistSeq = null;
            lsMasterKey = (String)loMasterKey;
            lnSeq = 0;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);
            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                if (ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_AMORT_CUR_INT") != 0)
                {
                    MASTHISTBindingSource.AddNew();
                    MASTHISTBindingSource.EndEdit();
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), ContingiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                    if (loMasterHistSeq != null)
                        lnSeq = (int)loMasterHistSeq + 1;
                    else
                        lnSeq = 1;
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", ContingiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_AMORT_CUR_INT", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_AMORT_CUR_INT"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_AMORT_YTD_INT", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_AMORT_YTD_INT"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    ContingiacDataSet.MASTHIST.AcceptChanges();
                }
            }
        }


        private void worker_PostContingents(object sender, DoWorkEventArgs e)
        {
            PostContingents();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_PostContingents);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Closed Dealer Contingent Posting";
            lfrm.lblProgress.Text = "Posting Dealer Contingents";
            lfrm.ShowDialog();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CONTINGTableAdapter.Connection.Close();
            CONTINGTableAdapter.Dispose();
            WSDEALERCONTTableAdapter.Connection.Close();
            WSDEALERCONTTableAdapter.Dispose();
            ContingiacDataSet.Dispose();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            CONTINGTableAdapter.Connection.Close();
            CONTINGTableAdapter.Dispose();
            WSDEALERCONTTableAdapter.Connection.Close();
            WSDEALERCONTTableAdapter.Dispose();
            ContingiacDataSet.Dispose();
            Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.EditValue = e.ProgressPercentage;
        }

    }
}

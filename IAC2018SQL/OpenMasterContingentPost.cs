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
    public partial class frmOpenMasterContingentPost : Form
    {
        IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();

        QueryProgress lfrm;

        BackgroundWorker worker;

        public frmOpenMasterContingentPost()
        {
            InitializeComponent();
        }

        private void frmOpenMasterContingentPost_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }

        private void PostContingents()
        {
            IACDataSetTableAdapters.OPNMCONTTableAdapter OPNMCONTTableAdapter = new IACDataSetTableAdapters.OPNMCONTTableAdapter();

            OPNMCONTTableAdapter.CustomizeFill("SELECT * FROM OPNMCONT");
            OPNMCONTTableAdapter.CustomFillBy(ContingiacDataSet.OPNMCONT);

            if (ContingiacDataSet.OPNMCONT.Rows.Count == 0)
            {
                MessageBox.Show("There are no unposted OPEN MASTER contingent records!");
                return;
            }

            OPNMCONTTableAdapter.CloseConnection();

            // Moses Newman 05/3/2014 Get rid of SQL Pass Through!
            MASTERTableAdapter.ClearCurrent();

            worker.ReportProgress(25);

            // Moses Newman 05/3/2014 Get rid of SQL Pass Through!
            MASTERTableAdapter.UpdateFromOPNMCONT(DateTime.Now.Date);
            worker.ReportProgress(50);

            CreateMastHist();
            worker.ReportProgress(75);

            OPNMCONTTableAdapter.DeleteAllRecords();
            OPNMCONTTableAdapter.Dispose();
            worker.ReportProgress(100);
        }

        private void CreateMastHist()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
            BindingSource MASTHISTBindingSource = new BindingSource();

            MASTHISTBindingSource.DataSource = ContingiacDataSet.MASTHIST;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS"), loMasterHistSeq = null;
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
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
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
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
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
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
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
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
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
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
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
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                    ContingiacDataSet.MASTHIST.AcceptChanges();
                }
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("INTEREST");
            loMasterHistSeq = null;
            lsMasterKey = (String)loMasterKey;
            lnSeq = 0;

            MASTERTableAdapter.Fill(ContingiacDataSet.MASTER, lsMasterKey);
            if (ContingiacDataSet.MASTER.Rows.Count != 0)
            {
                if (ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_INT") != 0)
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
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_INT", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_CUR_INT"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_INT", ContingiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_INT"));
                    ContingiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "O");
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
            lfrm.Text = "Open Master Contingent Posting";
            lfrm.lblProgress.Text = "Posting Open Master Contingents";
            lfrm.ShowDialog();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            MASTERTableAdapter.Connection.Close();
            MASTERTableAdapter.Dispose();
            ContingiacDataSet.Dispose();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            MASTERTableAdapter.Connection.Close();
            MASTERTableAdapter.Dispose();
            ContingiacDataSet.Dispose();
            Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.EditValue = e.ProgressPercentage;
        }

    }
}

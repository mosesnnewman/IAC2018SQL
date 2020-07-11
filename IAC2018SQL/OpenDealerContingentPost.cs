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
    public partial class frmOpenDealerContingentPost : Form
    {
        Decimal lnMASTER_LOSS = 0, lnMASTER_CONT = 0, lnMASTER_ADJ = 0, lnMASTER_BAD = 0, lnMASTER_RSV = 0, lnMASTER_OS_LOANS = 0, lnMASTER_NOTES = 0;

        IACDataSetTableAdapters.OPNCONTTableAdapter OPNCONTTableAdapter = new IACDataSetTableAdapters.OPNCONTTableAdapter();
        IACDataSetTableAdapters.WSOPNDEALRCONTTableAdapter WSOPNDEALRCONTTableAdapter = new IACDataSetTableAdapters.WSOPNDEALRCONTTableAdapter();
        BindingSource OPNCONTBindingSource = new BindingSource();
        BindingSource WS_OPNDEALR_CONTBindingSource = new BindingSource();

        QueryProgress lfrm;

        BackgroundWorker worker;

        public frmOpenDealerContingentPost()
        {
            InitializeComponent();
        }

        private void frmOpenDealerContingentPost_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }

        private void PostContingents()
        {
            WSOPNDEALRCONTTableAdapter.Fill(ContingiacDataSet.WS_OPNDEALR_CONT);

            if (ContingiacDataSet.WS_OPNDEALR_CONT.Rows.Count == 0)
            {
                MessageBox.Show("There are no unposted dealer contingent records!");
                return;
            }

            OPNCONTTableAdapter.CustomizeFill("UPDATE OPNCONT SET CONTING_POST_IND = \'D\' WHERE CONTING_POST_IND = CHAR(255)");
            OPNCONTTableAdapter.CustomUpdateQuery("");

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
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            BindingSource OPNDEALRBindingSource = new BindingSource();

            OPNDEALRBindingSource.DataSource = ContingiacDataSet.OPNDEALR;

            lnTotalWork = ContingiacDataSet.WS_OPNDEALR_CONT.Rows.Count;
            for (Int32 i = 0; i < ContingiacDataSet.WS_OPNDEALR_CONT.Rows.Count; i++)
            {
                OPNDEALRTableAdapter.Fill(ContingiacDataSet.OPNDEALR, ContingiacDataSet.WS_OPNDEALR_CONT[i].Field<String>("KEY"));
                if (ContingiacDataSet.OPNDEALR.Rows.Count != 0)
                {
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_LOSS",       ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("LOSS_RES"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_CONT",       ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("CONTRACT"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_ADJ",        ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("ADJUST"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_BAD",        ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("RECOV_BAD"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_RSV",        ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("RES_LOSS"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_CUR_OLOAN",      ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("OS_LOANS"));

                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_LOSS",       ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_LOSS")      + ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("LOSS_RES"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_CONT",       ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_CONT")      + ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("CONTRACT"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_ADJ",        ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_ADJ")       + ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("ADJUST"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_BAD",        ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_BAD")       + ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("RECOV_BAD"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_RSV",        ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_RSV")       + ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("RES_LOSS"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<Decimal>("OPNDEALR_YTD_OLOAN",      ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN")     + ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("OS_LOANS"));
                    ContingiacDataSet.OPNDEALR.Rows[0].SetField<DateTime>("OPNDEALR_POST_DATE", DateTime.Now.Date);

                    lnMASTER_LOSS       += ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("LOSS_RES");
                    lnMASTER_CONT       += ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("CONTRACT");
                    lnMASTER_ADJ        += ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("ADJUST");
                    lnMASTER_BAD        += ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("RECOV_BAD");
                    lnMASTER_RSV        += ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("RES_LOSS");
                    lnMASTER_OS_LOANS   += ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("OS_LOANS");
                    lnMASTER_NOTES      += ContingiacDataSet.WS_OPNDEALR_CONT.Rows[i].Field<Decimal>("NOTES");

                    OPNDEALRBindingSource.EndEdit();
                    OPNDEALRTableAdapter.Update(ContingiacDataSet.OPNDEALR.Rows[0]);
                    ContingiacDataSet.OPNDEALR.AcceptChanges();
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

            OPNHDEALBindingSource.DataSource = ContingiacDataSet.OPNHDEAL;

            OPNHDEALBindingSource.AddNew();
            OPNHDEALBindingSource.EndEdit();

            // Start of DEALHIST KEY Fields
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<String>("DEALHIST_ACC_NO", ContingiacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<DateTime>("DEALHIST_POST_DATE", DateTime.Now.Date);
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<DateTime>("DEALHIST_LAST_POST_DATE", ContingiacDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE"));
            loDealerHistSeq = OPNHDEALTableAdapter.SeqNoQuery(ContingiacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"), DateTime.Now.Date, ContingiacDataSet.OPNDEALR.Rows[0].Field<DateTime>("OPNDEALR_POST_DATE"));
            if (loDealerHistSeq != null)
                lnSeq = (int)loDealerHistSeq + 1;
            else
                lnSeq = 1;
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
            // End of DEALHIST KEY Fields
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_RSV", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_RSV"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_CONT", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_CONT"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLOAN", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_OLOAN"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_ADJ", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_ADJ"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_BAD", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_BAD"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_LOSS", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_CUR_LOSS"));

            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_RSV", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_RSV"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_CONT", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_CONT"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLOAN", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_ADJ", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_ADJ"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_BAD", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_BAD"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_LOSS", ContingiacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_LOSS"));
            ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position].SetField<String>("DEALHIST_POST_CODE", "C");
            OPNHDEALBindingSource.EndEdit();
            OPNHDEALTableAdapter.Update(ContingiacDataSet.OPNHDEAL.Rows[OPNHDEALBindingSource.Position]);
            ContingiacDataSet.OPNHDEAL.AcceptChanges();
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
        }

        private void CreateMastHist()
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
            lfrm.Text = "Open Dealer Contingent Posting";
            lfrm.lblProgress.Text = "Posting Open Dealer Contingents";
            lfrm.ShowDialog();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OPNCONTTableAdapter.Connection.Close();
            OPNCONTTableAdapter.Dispose();
            WSOPNDEALRCONTTableAdapter.Connection.Close();
            WSOPNDEALRCONTTableAdapter.Dispose();
            ContingiacDataSet.Dispose();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            OPNCONTTableAdapter.Connection.Close();
            OPNCONTTableAdapter.Dispose();
            WSOPNDEALRCONTTableAdapter.Connection.Close();
            WSOPNDEALRCONTTableAdapter.Dispose();
            ContingiacDataSet.Dispose();
            Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.Value = e.ProgressPercentage;
        }

    }
}

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
    public partial class frmClosedFirstPaymentDefaultReport : Form
    {
        BackgroundWorker worker;
        QueryProgress lfrm;
        MDIIAC2013 MDImain;

        public frmClosedFirstPaymentDefaultReport()
        {
            InitializeComponent();
        }

        private void frmClosedFirstPaymentDefaultReport_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            nullableDateTimePickerDueDate.Value = DateTime.Now.Date;
        }

        private void worker_PrintDelinquencyReport(object sender, DoWorkEventArgs e)
        {
            DoAmort();
        }

        private void DoAmort()
        {
            IACDataSet WorkSet = new IACDataSet();
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.Value)).Date;
            ClosedPaymentPosting CPaymentPost = new ClosedPaymentPosting();
            int lnProgress = 0;
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            CUSTOMERTableAdapter.FillByFirstPaymentDefault(WorkSet.CUSTOMER, ldCurrDate);
            for (Int32 CustomerPos = 0; CustomerPos < WorkSet.CUSTOMER.Rows.Count; CustomerPos++)
            {
                lnProgress = (Int32)(Math.Round(((Double)CustomerPos / (Double)WorkSet.CUSTOMER.Rows.Count), 2) * 100);
                worker.ReportProgress(lnProgress);
                CPaymentPost.ClosedPaymentCalculatebuyout(-1, CustomerPos, ref WorkSet, ref worker, ldCurrDate.ToShortDateString(), false, true);
            }
            WorkSet.Clear();
            WorkSet.Dispose();

            CUSTOMERTableAdapter.Dispose();

        }

        private void PrintDelinquencyReport()
        {
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.Value)).Date;

            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter ClosedDealerAgedSummarySelectTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectCOLTableAdapter ClosedDealerAgedSummarySelectCOLTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectCOLTableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();


            CUSTOMERTableAdapter.FillByFirstPaymentDefault(DelinquencyData.CUSTOMER, ldCurrDate);
            DEALERTableAdapter.FillByFirstPaymentDefault(DelinquencyData.DEALER, ldCurrDate);

            if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
            {
                Hide();
                MDImain.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                ClosedFirstPaymentDefault myReportObject = new ClosedFirstPaymentDefault();
                myReportObject.SetDataSource(DelinquencyData);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
            DelinquencyData.Clear();
            DelinquencyData.Dispose();

            CUSTOMERTableAdapter.Dispose();
            DEALERTableAdapter.Dispose();
            ClosedDealerAgedSummarySelectTableAdapter.Dispose();
            ClosedDealerAgedSummarySelectCOLTableAdapter.Dispose();
        }


        private void buttonPost_Click(object sender, EventArgs e)
        {
            MDImain = (MDIIAC2013)MdiParent;
            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_PrintDelinquencyReport);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Closed First Payment Default";
            lfrm.lblProgress.Text = "Reamortizing Customers";
            lfrm.ShowDialog();
            PrintDelinquencyReport();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.EditValue = e.ProgressPercentage;
        }
    }
}

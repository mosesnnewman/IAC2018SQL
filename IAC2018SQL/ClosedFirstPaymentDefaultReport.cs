using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace IAC2021SQL
{
    public partial class frmClosedFirstPaymentDefaultReport : DevExpress.XtraEditors.XtraForm
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
            nullableDateTimePickerDueDate.EditValue = DateTime.Now.Date;
        }

        private void worker_PrintDelinquencyReport(object sender, DoWorkEventArgs e)
        {
            DoAmort();
        }

        private void DoAmort()
        {
            IACDataSet WorkSet = new IACDataSet();
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.EditValue)).Date;
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
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.EditValue)).Date;

            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();


            CUSTOMERTableAdapter.FillByFirstPaymentDefault(DelinquencyData.CUSTOMER, ldCurrDate);

            if (DelinquencyData.CUSTOMER.Rows.Count != 0)
            {
                MDImain = (MDIIAC2013)MdiParent;
                Hide();

                // Moses Newman 09/08/2022 Covert to XtraReport
                var report = new XtraReportClosedFirstPaymentDefault();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdCurrentDate"].Value = ldCurrDate;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
            DelinquencyData.Clear();
            DelinquencyData.Dispose();

            CUSTOMERTableAdapter.Dispose();
        }


        private void buttonPost_Click(object sender, EventArgs e)
        {
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

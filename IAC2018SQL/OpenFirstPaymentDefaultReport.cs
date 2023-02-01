using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using System;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class frmOpenFirstPaymentDefaultReport : DevExpress.XtraEditors.XtraForm
    {
        public frmOpenFirstPaymentDefaultReport()
        {
            InitializeComponent();
        }

        private void frmOpenFirstPaymentDefaultReport_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            nullableDateTimePickerDueDate.EditValue = DateTime.Now.Date;
        }

        private void PrintDelinquencyReport()
        {
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.EditValue)).Date;

            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.OPNCUSTTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();

            CUSTOMERTableAdapter.FillByFirstPaymentDefault(DelinquencyData.OPNCUST, ldCurrDate);

            if (DelinquencyData.OPNCUST.Rows.Count != 0)
            {
                Hide();

                // Moses Newman 01/31/2022 Covert to XtraReport
                var report = new XtraReportOpenFirstPaymentDefault();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdCurrentDate"].Value = ldCurrDate;

                var tool = new ReportPrintTool(report);
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
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
            PrintDelinquencyReport();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

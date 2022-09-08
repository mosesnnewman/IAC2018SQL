using System;
using System.Windows.Forms;

using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;


namespace IAC2021SQL
{
    public partial class frmClosedPayedInAdvanceReport : DevExpress.XtraEditors.XtraForm
    {

        public frmClosedPayedInAdvanceReport()
        {
            InitializeComponent();
        }

        private void frmClosedPayedInAdvanceReport_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            nullableDateTimePickerDueDate.EditValue = DateTime.Now.Date;
        }

        private void PrintDelinquencyReport()
        {
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.EditValue)).Date;

            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;


            Hide();

            // Moses Newman 09/07/2022 Covert to XtraReport
            var report = new XtraReportClosedPaidInAdvance();
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

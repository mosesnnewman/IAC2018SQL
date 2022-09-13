using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace IAC2021SQL
{
    public partial class ClosedCustomerTierSummary : DevExpress.XtraEditors.XtraForm
    {
        public ClosedCustomerTierSummary()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //String deletePath = "";
            //SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            IACDataSet ReportDataSet = new IACDataSet();
            IACDataSetTableAdapters.ClosedCustomertTierSummaryTableAdapter ClosedCustomertTierSummaryTableAdapter = new IACDataSetTableAdapters.ClosedCustomertTierSummaryTableAdapter();

            ClosedCustomertTierSummaryTableAdapter.Fill(ReportDataSet.ClosedCustomertTierSummary,"A%","%");

            if (ReportDataSet.ClosedCustomertTierSummary.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Customers Selected! ***");
            else
            {
                // Moses Newman 09/12/2022 Covert to XtraReport
                var report = new XtraReportClosedTierSummary();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;


namespace IAC2021SQL
{
    public partial class CustomerShortBalanceReport : DevExpress.XtraEditors.XtraForm
    {
        public CustomerShortBalanceReport()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            IACDataSet ReportDataSet = new IACDataSet();
            IACDataSetTableAdapters.ClosedCustomerShortBalanceTableAdapter ClosedCustomerShortBalanceTableAdapter = new IACDataSetTableAdapters.ClosedCustomerShortBalanceTableAdapter();

            ClosedCustomerShortBalanceTableAdapter.Fill(ReportDataSet.ClosedCustomerShortBalance);

            if (ReportDataSet.ClosedCustomerShortBalance.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Customers with Short Balances! ***");
            else
            {
                // Moses Newman 05/09/2022 Covert to XtraReport
                var report = new XtraReportShortBalanceReport();
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

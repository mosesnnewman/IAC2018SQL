using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace IAC2021SQL
{
    public partial class frmOpenDealerSummaryReport : DevExpress.XtraEditors.XtraForm
    {

        public frmOpenDealerSummaryReport()
        {
            InitializeComponent();
        }

        private void frmOpenDealerSummaryReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            monthNamesTableAdapter.Fill(iACDataSet.MonthNames);
            monthNamesBindingSource.DataSource = iACDataSet.MonthNames;
            monthNamesBindingSource.MoveFirst();
            monthNamesBindingSource.Position = monthNamesBindingSource.Find("MonthNumber", lnRunMonth);
            textBoxRunYear.Text = lnRunYear.ToString();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            PrintDealerSummary();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintDealerSummary()
        {
            DateTime ldRunDate;
            String lsRunDate = "";
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OpenDealerSummaryTableAdapter OpenDealerSummaryTableAdapter = new IACDataSetTableAdapters.OpenDealerSummaryTableAdapter();


            lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/31/" + textBoxRunYear.Text;
            DateTime.TryParse(lsRunDate,out ldRunDate);
            if (ldRunDate == DateTime.MinValue)
            {
                lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/30/" + textBoxRunYear.Text;
                DateTime.TryParse(lsRunDate, out ldRunDate);
                if (ldRunDate == DateTime.MinValue)
                {
                    lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/28/" + textBoxRunYear.Text;
                    DateTime.TryParse(lsRunDate, out ldRunDate);
                    if (ldRunDate == DateTime.MinValue)
                    {
                        lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/27/" + textBoxRunYear.Text;   // Must be a leap year with February run date
                        DateTime.TryParse(lsRunDate, out ldRunDate);
                    }
                }
            }

            OpenDealerSummaryTableAdapter.Fill(ReportData.OpenDealerSummary, ldRunDate.Month, ldRunDate.Year);

            if (ReportData.OpenDealerSummary.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no dealer history records for the RUN MONTH AND YEAR you entered!!! ***");
            else
            {
                // Moses Newman 09/13/2022 Convert to XtraReport
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

                var report = new XtraReportOpenDealerSummary();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdCutOffDate"].Value = ldRunDate;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
        }
    }
}

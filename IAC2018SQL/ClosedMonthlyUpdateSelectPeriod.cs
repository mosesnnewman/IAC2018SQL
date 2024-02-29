using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using System.Data;

namespace IAC2021SQL
{
    public partial class frmClosedMonthlyUpdateSelectPeriod : DevExpress.XtraEditors.XtraForm
    {

        IACDataSet ReportData = new IACDataSet();
        public frmClosedMonthlyUpdateSelectPeriod()
        {
            InitializeComponent();
        }

        private void frmClosedDealerSummaryReport_Load(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.SystemTableAdapter SystemTableAdapter = new IACDataSetTableAdapters.SystemTableAdapter();

            SystemTableAdapter.Fill(ReportData.System, 1);

            DateTime TempDate = ReportData.System.Rows[0].Field<DateTime>("LastUpdateDate");

            Int32 lnRunMonth = TempDate.Month, lnRunYear = TempDate.Year;

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

            // Moses Newman 02/29/2024 Run date should be next month 1st day -1!
            lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/01/" + textBoxRunYear.Text;
            DateTime.TryParse(lsRunDate,out ldRunDate);
            ldRunDate = ldRunDate.AddMonths(1).AddDays(-1);


            ReportData = new IACDataSet();
            // Moses Newman 11/29/2020 add new Daily Interest Variance Sub Report
            DailyDataSet DailyData = new DailyDataSet();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            //IACDataSetTableAdapters.SystemTableAdapter SystemTableAdapter = new IACDataSetTableAdapters.SystemTableAdapter();

            //SystemTableAdapter.Fill(ReportData.System, 1);

            //DateTime ldLastRun = ReportData.System.Rows[0].Field<DateTime>("LastUpdateDate");
            DateTime ldLastRun = ldRunDate;

            CUSTHISTTableAdapter.FillByUpdatesOnly(ReportData.CUSTHIST, ldLastRun);
            if (ReportData.CUSTHIST.Rows.Count == 0)
            {
                MessageBox.Show("*** There are no UPDATES to report on! ***");
                return;
            }


            // Moses Newman 05/31/2022 Convert to XtraReport
            var report = new XtraReportMonthlyInterest();
            SqlDataSource ds = report.DataSource as SqlDataSource;

            /*ds.Queries[0].Parameters[0].Value = ldLastRun;
            ds.Queries[1].Parameters[0].Value = ldLastRun;
            ds.Queries[2].Parameters[0].Value = ldLastRun;*/

            report.DataSource = ds;
            report.RequestParameters = false;
            report.Parameters["gsUserID"].Value = Program.gsUserID;
            report.Parameters["gsUserName"].Value = Program.gsUserName;
            report.Parameters["gsFormTitle"].Value = "Monthly Interest Update Report";
            report.Parameters["gdLastRun"].Value = ldLastRun;

            var tool = new ReportPrintTool(report);

            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            tool.PreviewRibbonForm.MdiParent = MDImain;
            tool.AutoShowParametersPanel = false;
            tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
            tool.ShowRibbonPreview();

            ReportData.Clear();
            ReportData.Dispose();
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace IAC2021SQL
{
    public partial class frmClosedDealerHistoryReport : DevExpress.XtraEditors.XtraForm
    {

        public frmClosedDealerHistoryReport()
        {
            InitializeComponent();
        }

        private void frmClosedDealerHistoryReport_Load(object sender, EventArgs e)
        {
            this.stateTableAdapter.Fill(this.iACDataSet.state);
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.EditValue = DateTime.Now.AddMonths(-1).Date;
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;

            stateTableAdapter.Fill(iACDataSet.state);
            StatebindingSource.DataSource = iACDataSet.state;
            StatebindingSource.AddNew();
            StatebindingSource.EndEdit();
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("abbreviation", "");
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("name", "");
            StatebindingSource.EndEdit();

            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();

        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            PrintDealerHistory();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintDealerHistory()
        {
            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + '%';
            dealhistTableAdapter.FillByDealerDateRange(iACDataSet.DEALHIST, lsDealerNum, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
            if (iACDataSet.DEALHIST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no DEALHIST records for the DATES and /or DEALER you selected!!! ***");
            else
            {
                // Moses Newman 09/13/2022 Convert to XtraReport
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

                var report = new XtraReportDealerHistory();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdFromDate"].Value = (DateTime)nullableDateTimePickerStartDate.EditValue;
                report.Parameters["gdToDate"].Value = (DateTime)nullableDateTimePickerEndDate.EditValue;
                report.Parameters["gsDealerNo"].Value = lsDealerNum;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
        }
    }
}

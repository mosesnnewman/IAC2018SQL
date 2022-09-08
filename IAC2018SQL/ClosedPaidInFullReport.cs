using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;


namespace IAC2021SQL
{
    public partial class frmClosedPaidInFullReport : DevExpress.XtraEditors.XtraForm
    {

        public frmClosedPaidInFullReport()
        {
            InitializeComponent();
        }

        private void frmClosedPaidInFullReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;
            nullableDateTimePickerFrom.EditValue = DateTime.Now.Date;
            nullableDateTimePickerTo.EditValue = DateTime.Now.Date;
            stateTableAdapter.Fill(iACDataSet.state);
            StatebindingSource.DataSource = iACDataSet.state;
            StatebindingSource.AddNew();
            StatebindingSource.EndEdit();
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("abbreviation", "");
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("name", "");
            StatebindingSource.EndEdit();
            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            DLRLISTBYNUMbindingSource.DataSource = iACDataSet.DLRLISTBYNUM;
            DLRLISTBYNUMbindingSource.AddNew();
            DLRLISTBYNUMbindingSource.EndEdit();
            //iACDataSet.DLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField<Int32>("id",0);
            iACDataSet.DLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField<String>("DEALER_NAME", "                  ");
            DLRLISTBYNUMbindingSource.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            PrintClosedPaidInFullReport();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintClosedPaidInFullReport()
        {
            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim():"" + '%';
            String lsState;

            lsState = (lookUpEditState.EditValue != null) ? lookUpEditState.EditValue.ToString().TrimStart().TrimEnd() + "%" : "%";
            IACDataSetTableAdapters.PaidInFullTableAdapter  PaidInFullTableAdapter = new IACDataSetTableAdapters.PaidInFullTableAdapter();

            // This one actually populates the SQL Server PaidInFullTable
            PaidInFullTableAdapter.ClosedPaidInFullFill(lsState, lsDealerNum,((DateTime)(nullableDateTimePickerFrom.EditValue)).Date,((DateTime)(nullableDateTimePickerTo.EditValue)).Date);
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            // Moses Newman 09/07/2022 Covert to XtraReport
            var report = new XtraReportClosedPaidInFull();
            SqlDataSource ds = report.DataSource as SqlDataSource;

            report.DataSource = ds;
            report.RequestParameters = false;
            report.Parameters["gsUserID"].Value = Program.gsUserID;
            report.Parameters["gsUserName"].Value = Program.gsUserName;
            report.Parameters["gdFromDate"].Value = (DateTime)nullableDateTimePickerFrom.EditValue;
            report.Parameters["gdToDate"].Value = (DateTime)nullableDateTimePickerTo.EditValue;
            report.Parameters["gsState"].Value = lsState;
            report.Parameters["gsDealer"].Value = lsDealerNum;

            var tool = new ReportPrintTool(report);

            tool.PreviewRibbonForm.MdiParent = MDImain;
            tool.AutoShowParametersPanel = false;
            tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
            tool.ShowRibbonPreview();
        }
    }
}

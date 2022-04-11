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
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;
            PrintClosedPaidInFullReport(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintClosedPaidInFullReport(ReportViewer rptViewer)
        {
            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim():"" + '%';
            String lsState;

            lsState = (lookUpEditState.EditValue != null) ? lookUpEditState.EditValue.ToString().TrimStart().TrimEnd() + "%" : "%";
            IACDataSetTableAdapters.PaidInFullTableAdapter  PaidInFullTableAdapter = new IACDataSetTableAdapters.PaidInFullTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();

            BindingSource PaidInFullBindingSource = new BindingSource();
            PaidInFullBindingSource.DataSource = iACDataSet.PaidInFull;

            DEALERTableAdapter.FillByPaidInFull(iACDataSet.DEALER, lsState, lsDealerNum, ((DateTime)(nullableDateTimePickerFrom.EditValue)).Date, ((DateTime)(nullableDateTimePickerTo.EditValue)).Date);

            // This one actually populates the SQL Server PaidInFullTable
            PaidInFullTableAdapter.ClosedPaidInFullFill(lsState, lsDealerNum,((DateTime)(nullableDateTimePickerFrom.EditValue)).Date,((DateTime)(nullableDateTimePickerTo.EditValue)).Date);
            //Thist one brings the records back into the DataTable
            PaidInFullTableAdapter.FillByAllClosed(iACDataSet.PaidInFull);

            ClosedPaidInFullReport myReportObject = new ClosedPaidInFullReport();
            myReportObject.SetDataSource(iACDataSet);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gdFromDate", (DateTime)nullableDateTimePickerFrom.EditValue);
            myReportObject.SetParameterValue("gdToDate", (DateTime)nullableDateTimePickerTo.EditValue);
            rptViewer.crystalReportViewer.ReportSource = myReportObject;
            rptViewer.crystalReportViewer.Refresh();
            rptViewer.Show();
        }
    }
}

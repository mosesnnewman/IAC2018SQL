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
    public partial class frmOpenPaidInFullReport : Form
    {

        public frmOpenPaidInFullReport()
        {
            InitializeComponent();
        }

        private void frmOpenPaidInFullReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;
            nullableDateTimePickerFrom.Value = DateTime.Now.Date;
            nullableDateTimePickerTo.Value = DateTime.Now.Date;
            stateTableAdapter.Fill(iACDataSet.state);
            StatebindingSource.AddNew();
            StatebindingSource.EndEdit();
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("abbreviation", "");
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("name", "");
            StatebindingSource.EndEdit();
            opndlrlistbynumTableAdapter.Fill(iACDataSet.OPNDLRLISTBYNUM);
            DLRLISTBYNUMbindingSource.AddNew();
            DLRLISTBYNUMbindingSource.EndEdit();
            iACDataSet.OPNDLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField<String>("OPNDEALR_ACC_NO", "   ");
            iACDataSet.OPNDLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField<String>("OPNDEALR_NAME", "                  ");
            DLRLISTBYNUMbindingSource.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;
            PrintOpenPaidInFullReport(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintOpenPaidInFullReport(ReportViewer rptViewer)
        {
            String lsDealerNum = comboBoxDealer.Text.TrimEnd().TrimStart() + "%", lsState;

            lsState = (comboBoxState.SelectedValue != null) ? comboBoxState.SelectedValue.ToString().TrimStart().TrimEnd() + "%" : "%";
            IACDataSetTableAdapters.PaidInFullTableAdapter PaidInFullTableAdapter = new IACDataSetTableAdapters.PaidInFullTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();

            BindingSource PaidInFullBindingSource = new BindingSource();
            PaidInFullBindingSource.DataSource = iACDataSet.PaidInFull;

            OPNDEALRTableAdapter.FillByPaidInFull(iACDataSet.OPNDEALR, lsState, lsDealerNum, ((DateTime)(nullableDateTimePickerFrom.Value)).Date, ((DateTime)(nullableDateTimePickerTo.Value)).Date);

            // This one actually populates the SQL Server PaidInFullTable
            PaidInFullTableAdapter.OpenPaidInFullFill(lsState, lsDealerNum, ((DateTime)(nullableDateTimePickerFrom.Value)).Date, ((DateTime)(nullableDateTimePickerTo.Value)).Date);
            //Thist one brings the records back into the DataTable
            PaidInFullTableAdapter.FillByAllOpen(iACDataSet.PaidInFull);

            OpenPaidInFullReport myReportObject = new OpenPaidInFullReport();
            myReportObject.SetDataSource(iACDataSet);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gdFromDate", (DateTime)nullableDateTimePickerFrom.Value);
            myReportObject.SetParameterValue("gdToDate", (DateTime)nullableDateTimePickerTo.Value);
            rptViewer.crystalReportViewer.ReportSource = myReportObject;
            rptViewer.crystalReportViewer.Refresh();
            rptViewer.Show();
        }
    }
}

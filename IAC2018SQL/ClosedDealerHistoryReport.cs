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
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintDealerHistory(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintDealerHistory(ReportViewer rptViewer)
        {
            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + '%';
            dealhistTableAdapter.FillByDealerDateRange(iACDataSet.DEALHIST, lsDealerNum, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
            // Moses Newman 05/3/2014 get rid of SQL Pass Through!
            dealerTableAdapter.FillByDateRange(iACDataSet.DEALER, lsDealerNum, ((DateTime)nullableDateTimePickerStartDate.EditValue).Date, ((DateTime)nullableDateTimePickerEndDate.EditValue).Date);
            if (iACDataSet.DEALHIST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no DEALHIST records for the DATES and /or DEALER you selected!!! ***");
            else
            {
                ClosedDealerHistory myReportObject = new ClosedDealerHistory();
                myReportObject.SetDataSource(iACDataSet);
                myReportObject.SetParameterValue("gdFromDate", (DateTime)nullableDateTimePickerStartDate.EditValue);
                myReportObject.SetParameterValue("gdToDate", (DateTime)nullableDateTimePickerEndDate.EditValue);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
        }
    }
}

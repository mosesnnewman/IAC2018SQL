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
    public partial class frmMasterHistoryReport : DevExpress.XtraEditors.XtraForm
    {

        public frmMasterHistoryReport()
        {
            InitializeComponent();
        }

        private void frmMasterHistoryReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.EditValue = DateTime.Now.Date;
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
            masterlistTableAdapter.Fill(iACDataSet.MASTERLIST);
            bindingSourceMasterList.AddNew();
            bindingSourceMasterList.EndEdit();
            iACDataSet.MASTERLIST.Rows[bindingSourceMasterList.Position].SetField<String>("MASTER_ACC_NO", "   ");
            iACDataSet.MASTERLIST.Rows[bindingSourceMasterList.Position].SetField<String>("MASTER_NAME", "                  ");
            bindingSourceMasterList.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintMasterHistory(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintMasterHistory(ReportViewer rptViewer)
        {
            String lsAccountNum = lookUpEditAccount.EditValue != null ? lookUpEditAccount.EditValue.ToString().Trim() : "" + '%';

            masthistTableAdapter.FillByMasterDateRange(iACDataSet.MASTHIST, lsAccountNum, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
            // Moses Newman 10/13/2020 Replace Custom Query with Stored Procedure
            masterTableAdapter.FillByDateRange(iACDataSet.MASTER, lsAccountNum, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
            if (iACDataSet.MASTHIST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no MASTHIST records for the DATES and /or ACCOUNT you selected!!! ***");
            else
            {
                MasterHistory myReportObject = new MasterHistory();
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

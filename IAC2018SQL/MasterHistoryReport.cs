using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

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
            PrintMasterHistory();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintMasterHistory()
        {
            String lsAccountNum = lookUpEditAccount.EditValue != null ? lookUpEditAccount.EditValue.ToString().Trim() : "" + '%';

            masthistTableAdapter.FillByMasterDateRange(iACDataSet.MASTHIST, lsAccountNum, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
            if (iACDataSet.MASTHIST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no MASTHIST records for the DATES and /or ACCOUNT you selected!!! ***");
            else
            {
                // Moses Newman 09/13/2022 Convert to XtraReport
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

                var report = new XtraReportMasterHistory();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdFromDate"].Value = (DateTime)nullableDateTimePickerStartDate.EditValue;
                report.Parameters["gdToDate"].Value = (DateTime)nullableDateTimePickerEndDate.EditValue;
                report.Parameters["gsAccountNumber"].Value = lsAccountNum;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
        }
    }
}

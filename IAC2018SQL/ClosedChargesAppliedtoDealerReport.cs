using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using ProManApp;


namespace IAC2021SQL
{
    public partial class frmClosedChargesAppliedtoDealerReport : DevExpress.XtraEditors.XtraForm
    {
        private IACDataSetTableAdapters.ClosedChargesAppliedToDealerTableAdapter ClosedChargesAppliedToDealerTableAdapter = new IACDataSetTableAdapters.ClosedChargesAppliedToDealerTableAdapter();
        
        public frmClosedChargesAppliedtoDealerReport()
        {
            InitializeComponent();
        }

        private void frmClosedChargesAppliedtoDealerReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.EditValue = DateTime.Now.AddMonths(-1).Date;
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            PrintChargesAppliedtoDealer();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintChargesAppliedtoDealer()
        {
            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + '%';
            if (lsDealerNum.Length == 0)
                lsDealerNum = "%";
            if (nullableDateTimePickerStartDate.EditValue == null && nullableDateTimePickerEndDate.EditValue == null)
                // Dealer but no Date Range
                ClosedChargesAppliedToDealerTableAdapter.Fill(iACDataSet.ClosedChargesAppliedToDealer, lsDealerNum, null, null);
            else
               if (nullableDateTimePickerStartDate.EditValue != null && nullableDateTimePickerEndDate.EditValue != null)
                    // Dealer and Date Range
                    ClosedChargesAppliedToDealerTableAdapter.Fill(iACDataSet.ClosedChargesAppliedToDealer, lsDealerNum, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
            if (iACDataSet.ClosedChargesAppliedToDealer.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Charges Applied To Dealer records for the DATES and / or DEALER you selected!!! ***");
            else
            {
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

                // Moses Newman 09/07/2022 Covert to XtraReport
                var report = new XtraReportClosedChargesAppliedToDealer();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdFromDate"].Value = (nullableDateTimePickerStartDate.EditValue != null) ? (DateTime)nullableDateTimePickerStartDate.EditValue : Convert.ToDateTime("01/01/1900");
                report.Parameters["gdToDate"].Value = (nullableDateTimePickerEndDate.EditValue != null) ? (DateTime)nullableDateTimePickerEndDate.EditValue : Convert.ToDateTime("01/01/1900");
                report.Parameters["gsDealer"].Value = lsDealerNum;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
        }
    }
}

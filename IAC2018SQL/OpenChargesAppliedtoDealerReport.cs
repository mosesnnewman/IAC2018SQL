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


namespace IAC2021SQL
{
    public partial class frmOpenChargesAppliedtoDealerReport : DevExpress.XtraEditors.XtraForm
    {
        private IACDataSetTableAdapters.OpenChargesAppliedToDealerTableAdapter OpenChargesAppliedToDealerTableAdapter = new IACDataSetTableAdapters.OpenChargesAppliedToDealerTableAdapter();
        
        public frmOpenChargesAppliedtoDealerReport()
        {
            InitializeComponent();
        }

        private void frmOpenChargesAppliedtoDealerReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;
            nullableDateTimePickerStartDate.EditValue = null;
            nullableDateTimePickerEndDate.EditValue = null;
            opndlrlistbynumTableAdapter.Fill(iACDataSet.OPNDLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.OPNDLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("OPNDEALR_ACC_NO", "   ");
            iACDataSet.OPNDLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("OPNDEALR_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
            nullableDateTimePickerStartDate.EditValue = DateTime.Parse(DateTime.Now.Month.ToString().Trim() + "/01/" + DateTime.Now.Year.ToString()).AddMonths(-1);
            nullableDateTimePickerEndDate.EditValue = ((DateTime)nullableDateTimePickerStartDate.EditValue).AddMonths(2).AddDays(-1);

        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            PrintChargesAppliedtoDealer();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintChargesAppliedtoDealer()
        {
            String lsDealerNum = comboBoxDealer.Text.TrimEnd().TrimStart();

            if (lsDealerNum.Length == 0 && (nullableDateTimePickerStartDate.EditValue == null && nullableDateTimePickerEndDate.EditValue == null))
                // No Dealer or Date Range
                OpenChargesAppliedToDealerTableAdapter.Fill(iACDataSet.OpenChargesAppliedToDealer, null, null, null);
            else
                if (lsDealerNum.Length == 3 && (nullableDateTimePickerStartDate.EditValue == null && nullableDateTimePickerEndDate.EditValue == null))
                    // Dealer but no Date Range
                    OpenChargesAppliedToDealerTableAdapter.Fill(iACDataSet.OpenChargesAppliedToDealer, lsDealerNum, null, null);
                else
                    if (lsDealerNum.Length == 3 && (nullableDateTimePickerStartDate.EditValue != null && nullableDateTimePickerEndDate.EditValue != null))
                        // Dealer and Date Range
                        OpenChargesAppliedToDealerTableAdapter.Fill(iACDataSet.OpenChargesAppliedToDealer, lsDealerNum, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
                    else
                        if (lsDealerNum.Length == 0 && (nullableDateTimePickerStartDate.EditValue != null && nullableDateTimePickerEndDate.EditValue != null))
                          // No Dealer but Date Range
                            OpenChargesAppliedToDealerTableAdapter.Fill(iACDataSet.OpenChargesAppliedToDealer, null, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);

            if (iACDataSet.OpenChargesAppliedToDealer.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Charges Applied To Dealer records for the DATES and / or DEALER you selected!!! ***");
            else
            {
                Hide();
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

                // Moses Newman 05/11/2022 Covert to XtraReport
                var report = new XtraReportOpenChargesAppliedToDealer();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                ds.Queries[0].Parameters[0].Value = lsDealerNum;
                ds.Queries[0].Parameters[1].Value = (DateTime)nullableDateTimePickerStartDate.EditValue;
                ds.Queries[0].Parameters[2].Value = (DateTime)nullableDateTimePickerEndDate.EditValue;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdFromDate"].Value = (nullableDateTimePickerStartDate.EditValue != null) ? (DateTime)nullableDateTimePickerStartDate.EditValue : Convert.ToDateTime("01/01/1900");
                report.Parameters["gdToDate"].Value = (nullableDateTimePickerEndDate.EditValue != null) ? (DateTime)nullableDateTimePickerEndDate.EditValue : Convert.ToDateTime("01/01/1900");

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
        }
    }
}

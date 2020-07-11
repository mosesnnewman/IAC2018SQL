using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class frmOpenChargesAppliedtoDealerReport : Form
    {
        private IACDataSetTableAdapters.OpenChargesAppliedToDealerTableAdapter OpenChargesAppliedToDealerTableAdapter = new IACDataSetTableAdapters.OpenChargesAppliedToDealerTableAdapter();
        
        public frmOpenChargesAppliedtoDealerReport()
        {
            InitializeComponent();
        }

        private void frmOpenChargesAppliedtoDealerReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.Value = null;
            nullableDateTimePickerEndDate.Value = null;
            opndlrlistbynumTableAdapter.Fill(iACDataSet.OPNDLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.OPNDLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("OPNDEALR_ACC_NO", "   ");
            iACDataSet.OPNDLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("OPNDEALR_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintChargesAppliedtoDealer(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintChargesAppliedtoDealer(ReportViewer rptViewer)
        {
            String lsDealerNum = comboBoxDealer.Text.TrimEnd().TrimStart();

            if (lsDealerNum.Length == 0 && (nullableDateTimePickerStartDate.Value == null && nullableDateTimePickerEndDate.Value == null))
                // No Dealer or Date Range
                OpenChargesAppliedToDealerTableAdapter.Fill(iACDataSet.OpenChargesAppliedToDealer, null, null, null);
            else
                if (lsDealerNum.Length == 3 && (nullableDateTimePickerStartDate.Value == null && nullableDateTimePickerEndDate.Value == null))
                    // Dealer but no Date Range
                    OpenChargesAppliedToDealerTableAdapter.Fill(iACDataSet.OpenChargesAppliedToDealer, lsDealerNum, null, null);
                else
                    if (lsDealerNum.Length == 3 && (nullableDateTimePickerStartDate.Value != null && nullableDateTimePickerEndDate.Value != null))
                        // Dealer and Date Range
                        OpenChargesAppliedToDealerTableAdapter.Fill(iACDataSet.OpenChargesAppliedToDealer, lsDealerNum, (DateTime)nullableDateTimePickerStartDate.Value, (DateTime)nullableDateTimePickerEndDate.Value);
                    else
                        if (lsDealerNum.Length == 0 && (nullableDateTimePickerStartDate.Value != null && nullableDateTimePickerEndDate.Value != null))
                          // No Dealer but Date Range
                            OpenChargesAppliedToDealerTableAdapter.Fill(iACDataSet.OpenChargesAppliedToDealer, null, (DateTime)nullableDateTimePickerStartDate.Value, (DateTime)nullableDateTimePickerEndDate.Value);

            if (iACDataSet.OpenChargesAppliedToDealer.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Charges Applied To Dealer records for the DATES and / or DEALER you selected!!! ***");
            else
            {
                OpenChargesAppliedToDealer myReportObject = new OpenChargesAppliedToDealer();
                myReportObject.SetDataSource(iACDataSet);
                myReportObject.SetParameterValue("gdFromDate", (nullableDateTimePickerStartDate.Value != null) ? (DateTime)nullableDateTimePickerStartDate.Value : Convert.ToDateTime("01/01/1900"));
                myReportObject.SetParameterValue("gdToDate", (nullableDateTimePickerEndDate.Value != null) ? (DateTime)nullableDateTimePickerEndDate.Value : Convert.ToDateTime("01/01/1900"));
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
        }
    }
}

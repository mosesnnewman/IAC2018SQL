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
    public partial class frmClosedDealerHistoryReport : Form
    {

        public frmClosedDealerHistoryReport()
        {
            InitializeComponent();
        }

        private void frmClosedDealerHistoryReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.Value = DateTime.Now.Date;
            nullableDateTimePickerEndDate.Value = DateTime.Now.Date;
            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_ACC_NO", "   ");
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
            String lsDealerNum = comboBoxDealer.Text.TrimEnd().TrimStart() + "%";
            dealhistTableAdapter.FillByDealerDateRange(iACDataSet.DEALHIST, lsDealerNum, (DateTime)nullableDateTimePickerStartDate.Value, (DateTime)nullableDateTimePickerEndDate.Value);
            // Moses Newman 05/3/2014 get rid of SQL Pass Through!
            dealerTableAdapter.FillByDateRange(iACDataSet.DEALER, lsDealerNum, ((DateTime)nullableDateTimePickerStartDate.Value).Date, ((DateTime)nullableDateTimePickerEndDate.Value).Date);
            if (iACDataSet.DEALHIST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no DEALHIST records for the DATES and /or DEALER you selected!!! ***");
            else
            {
                ClosedDealerHistory myReportObject = new ClosedDealerHistory();
                myReportObject.SetDataSource(iACDataSet);
                myReportObject.SetParameterValue("gdFromDate", (DateTime)nullableDateTimePickerStartDate.Value);
                myReportObject.SetParameterValue("gdToDate", (DateTime)nullableDateTimePickerEndDate.Value);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
        }
    }
}

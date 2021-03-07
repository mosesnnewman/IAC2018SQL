using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class ClosedCustomerReceivedContractReport: Form
    {
        public ClosedCustomerReceivedContractReport()
        {
            InitializeComponent();
        }

        // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
        private void ClosedCustomerReceivedContractReport_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerStartDate.Value = DateTime.Parse("01/01/1980").Date;
            nullableDateTimePickerEndDate.Value = DateTime.Now.Date;
            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_ACC_NO", "   ");
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
            String lsDealer = comboBoxDealer.Text.TrimEnd() + "%", lsStatus = "%";
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

            IACDataSet VehicleDataSet = new IACDataSet();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();

            // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
            if (radioButtonActive.Checked)
                lsStatus = "A" + lsStatus;
            else
                if (radioButtonInactive.Checked)
                    lsStatus = "I" + lsStatus;
            // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
            CUSTOMERTableAdapter.ReceivedContract(VehicleDataSet.CUSTOMER, lsDealer, lsStatus,(DateTime)nullableDateTimePickerStartDate.Value,(DateTime)nullableDateTimePickerEndDate.Value);
            if (VehicleDataSet.CUSTOMER.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no received contracts for ACTIVE CUSTOMERS ***");
            else
            {
                ClosedReceivedContractReport myReportObject = new ClosedReceivedContractReport();
                myReportObject.SetDataSource(VehicleDataSet);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                // Moses Newman 02/05/2014 Add Selection Criteria to Report Heading
                myReportObject.SetParameterValue("gdStartDate", (DateTime)nullableDateTimePickerStartDate.Value);
                myReportObject.SetParameterValue("gdEndDate", (DateTime)nullableDateTimePickerEndDate.Value);
                switch (lsStatus)
                {
                    case "A%":
                        myReportObject.SetParameterValue("gsStatus", "Active");
                        break;
                    case "I%":
                        myReportObject.SetParameterValue("gsStatus", "Inactive");
                        break;
                    default:
                        myReportObject.SetParameterValue("gsStatus", "Both");
                        break;
                }
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

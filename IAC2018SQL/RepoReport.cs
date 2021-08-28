 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class FormRepoReport : Form
    {
        public FormRepoReport()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            DateTime ldStartDate = DateTime.Parse("01/01/1980"),ldEndDate = DateTime.Now;
            
            String lsRepoCode = cUSTOMER_REPO_CDEtextBox.Text.Trim() + "%",lsAgeCode = "%",lsStatus = "%";

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.VEHICLETableAdapter VEHICLETableAdapter = new IACDataSetTableAdapters.VEHICLETableAdapter();
            if (radioButtonY.Checked)
                lsAgeCode = "Y";
            if (radioButtonP.Checked)
                lsAgeCode = "P";
            if (radioButtonR.Checked)
                lsAgeCode = "R";
            if (radioButtonI.Checked)
                lsAgeCode = "I";
            // Moses Newman 12/03/2019 change lsStatus = "Z" to lsAgeCode = "Z" as it is a repo_ind not a status!
            if (radioButtonZ.Checked)
                lsAgeCode = "Z";
            if (radioButtonIndBoth.Checked)
                lsAgeCode = "%";
            if (radioButtonActive.Checked)
                lsStatus = "A";
            if (radioButtonInactive.Checked)
                lsStatus = "I";
            if (radioButtonStatusBoth.Checked)
                lsStatus = "%";
            if (nullableDateTimePickerStartDate.Value == null)
                ldStartDate = DateTime.Parse("01/01/1980");
            else
                ldStartDate = (DateTime)nullableDateTimePickerStartDate.Value;
            if (nullableDateTimePickerEndDate.Value == null)
                ldEndDate = DateTime.Now;
            else
                ldEndDate = (DateTime)nullableDateTimePickerEndDate.Value;
            CUSTOMERTableAdapter.FillByRepoCode(DelinquencyData.CUSTOMER, lsAgeCode, ldStartDate,ldEndDate,lsStatus,lsRepoCode);
            // Moses Newman 11/19/2013 Moses Newman added ldCurrDate as new parameter to DealerFillByDelinQuencies Query
            DEALERTableAdapter.FillByRepoCode(DelinquencyData.DEALER, lsAgeCode, ldStartDate, ldEndDate, lsStatus, lsRepoCode);
            //RepoCodesTableAdapter.Fill(DelinquencyData.RepoCodes);
            VEHICLETableAdapter.FillByRepo(DelinquencyData.VEHICLE, lsAgeCode, ldStartDate, ldEndDate, lsStatus, lsRepoCode);
            if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
            {
                Hide();
                MDImain.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                ClosedCustomerDelinquencyRepoReport myReportObject = new ClosedCustomerDelinquencyRepoReport();
                myReportObject.SetDataSource(DelinquencyData);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject.SetParameterValue("gsRepoInd",lsAgeCode);
                myReportObject.SetParameterValue("gnAgedMonths", 8);
                myReportObject.SetParameterValue("gdCurrentDate", ldStartDate);
                myReportObject.SetParameterValue("gdStartDate", ldStartDate);
                myReportObject.SetParameterValue("gdEndDate", ldEndDate);
                myReportObject.SetParameterValue("gsRepoCode", cUSTOMER_REPO_CDEtextBox.Text.Trim());
                myReportObject.SetParameterValue("gsCustStatus", lsStatus);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
                DelinquencyData.Clear();
                DelinquencyData.Dispose();

                VEHICLETableAdapter.Dispose();
                CUSTOMERTableAdapter.Dispose();
                DEALERTableAdapter.Dispose();
                Close();
            }
            else
            {
                MessageBox.Show("No records that match your selected criteria.  Please try again.");
            }
        }

        private void FormRepoReport_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerEndDate.Value = null;
            nullableDateTimePickerStartDate.Value = null;
            repoCodesTableAdapter.Fill(this.DelinquencyData.RepoCodes);
            radioButtonIndBoth.Checked = true;
            radioButtonStatusBoth.Checked = true;
            bindingSourceRepoCodes.Position = bindingSourceRepoCodes.Find("Code", "");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

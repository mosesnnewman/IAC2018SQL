using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;


namespace IAC2021SQL
{
    public partial class FormRepoReport : DevExpress.XtraEditors.XtraForm
    {
        public FormRepoReport()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            DateTime ldStartDate = DateTime.Now.Date.AddYears(-1),ldEndDate = DateTime.Now.Date;
            
            String lsRepoCode = cUSTOMER_REPO_CDEtextBox.Text.Trim() + "%",lsAgeCode = "%",lsStatus = "%";

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            if (radioButtonY.Checked)
                lsAgeCode = "Y%";
            if (radioButtonP.Checked)
                lsAgeCode = "P%";
            if (radioButtonR.Checked)
                lsAgeCode = "R%";
            if (radioButtonI.Checked)
                lsAgeCode = "I%";
            // Moses Newman 12/03/2019 change lsStatus = "Z" to lsAgeCode = "Z" as it is a repo_ind not a status!
            if (radioButtonZ.Checked)
                lsAgeCode = "Z%";
            if (radioButtonIndBoth.Checked)
                lsAgeCode = "%";
            if (radioButtonActive.Checked)
                lsStatus = "A%";
            if (radioButtonInactive.Checked)
                lsStatus = "I%";
            if (radioButtonStatusBoth.Checked)
                lsStatus = "%";
            if (nullableDateTimePickerStartDate.EditValue == null)
                ldStartDate = DateTime.Parse("01/01/1980");
            else
                ldStartDate = (DateTime)nullableDateTimePickerStartDate.EditValue;
            if (nullableDateTimePickerEndDate.EditValue == null)
                ldEndDate = DateTime.Now;
            else
                ldEndDate = (DateTime)nullableDateTimePickerEndDate.EditValue;
            CUSTOMERTableAdapter.FillByRepoCode(DelinquencyData.CUSTOMER, lsAgeCode, ldStartDate,ldEndDate,lsStatus,lsRepoCode);
            // Moses Newman 11/19/2013 Moses Newman added ldCurrDate as new parameter to DealerFillByDelinQuencies Query
            DEALERTableAdapter.FillByRepoCode(DelinquencyData.DEALER, lsAgeCode, ldStartDate, ldEndDate, lsStatus, lsRepoCode);
            if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
            {
                Hide();
                // Moses Newman 08/24/2022 Covert to XtraReport
                var report = new XtraReportClosedCustomerDelinquencyRepoReport();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gsRepoInd"].Value = lsAgeCode;
                report.Parameters["gnAgedMonths"].Value = 8;
                report.Parameters["gdCurrentDate"].Value = ldStartDate;
                report.Parameters["gdStartDate"].Value = ldStartDate;
                report.Parameters["gdEndDate"].Value = ldEndDate;
                report.Parameters["gsRepoCode"].Value = cUSTOMER_REPO_CDEtextBox.Text.Trim() + '%';
                report.Parameters["gsCustStatus"].Value = lsStatus;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();

                DelinquencyData.Clear();
                DelinquencyData.Dispose();

                DEALERTableAdapter.Dispose();
                CUSTOMERTableAdapter.Dispose();
                Close();
            }
            else
            {
                MessageBox.Show("No records that match your selected criteria.  Please try again.");
            }
        }

        private void FormRepoReport_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
            nullableDateTimePickerStartDate.EditValue = DateTime.Parse(DateTime.Now.Month.ToString()+"/"+DateTime.Now.Year.ToString());
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

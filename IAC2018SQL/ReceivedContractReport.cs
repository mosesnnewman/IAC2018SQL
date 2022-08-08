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
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;


namespace IAC2021SQL
{
    public partial class ClosedCustomerReceivedContractReport : DevExpress.XtraEditors.XtraForm
    {
        public ClosedCustomerReceivedContractReport()
        {
            InitializeComponent();
        }

        // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
        private void ClosedCustomerReceivedContractReport_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerStartDate.EditValue = DateTime.Parse("01/01/1980").Date;
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
            String lsDealer = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + '%',
                   lsStatus = "%";
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            IACDataSet VehicleDataSet = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();

            // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
            if (radioButtonActive.Checked)
                lsStatus = "A" + lsStatus;
            else
                if (radioButtonInactive.Checked)
                lsStatus = "I" + lsStatus;
            // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
            CUSTOMERTableAdapter.ReceivedContract(VehicleDataSet.CUSTOMER, lsDealer, lsStatus, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
            if (VehicleDataSet.CUSTOMER.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no received contracts for " + lsStatus == "A" ? "ACTIVE":"INACTIVE" + " CUSTOMERS ***");
            else
            {

                // Moses Newman 08/08/2022 Covert to XtraReport
                var report = new XtraReportClosedReceivedContract();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdStartDate"].Value = (DateTime)nullableDateTimePickerStartDate.EditValue;
                report.Parameters["gdEndDate"].Value = (DateTime)nullableDateTimePickerEndDate.EditValue;
                report.Parameters["gsStatus"].Value = lsStatus;
                report.Parameters["gsDealer"].Value = lsDealer;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

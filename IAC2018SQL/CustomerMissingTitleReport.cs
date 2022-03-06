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

namespace IAC2021SQL
{
    public partial class CustomerMissingTitleReport : DevExpress.XtraEditors.XtraForm
    {
        public CustomerMissingTitleReport()
        {
            InitializeComponent();
        }

        // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
        private void CustomerMissingTitleReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iACDataSet.state' table. You can move, or remove it, as needed.
            this.stateTableAdapter.Fill(this.iACDataSet.state);
            nullableDateTimePickerStartDate.EditValue = DateTime.Parse("01/01/1980").Date;
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
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
            // Moses Newman 03/03/2022 Add Dealer State
            String lsDealerState = lookUpEditState.EditValue.ToString().Trim() + "%";
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            IACDataSet VehicleDataSet = new IACDataSet();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
            IACDataSetTableAdapters.VehicleMissingTitleTableAdapter VehicleMissingTitleTableAdapter = new IACDataSetTableAdapters.VehicleMissingTitleTableAdapter();

            // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
            if (radioButtonActive.Checked)
                lsStatus = "A" + lsStatus;
            else
                if (radioButtonInactive.Checked)
                    lsStatus = "I" + lsStatus;
            // Moses Newman 02/02/2014 Add Date, Dealer, and Status selection criteria
            VehicleMissingTitleTableAdapter.Fill(VehicleDataSet.VehicleMissingTitle, lsDealer, lsDealerState,lsStatus,(DateTime)nullableDateTimePickerStartDate.EditValue,(DateTime)nullableDateTimePickerEndDate.EditValue);
            if (VehicleDataSet.VehicleMissingTitle.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Vehicle Missing Title records for ACTIVE CUSTOMERS ***");
            else
            {
                // Moses Newman 03/03/2022 Covert to XtraReport
                var report = new XtraReportVehicleMissingTitle();
                report.DataSource = VehicleDataSet;
                report.DataMember = "VehicleMissingTitle";
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdStartDate"].Value = (DateTime)nullableDateTimePickerStartDate.EditValue;
                report.Parameters["gdEndDate"].Value = (DateTime)nullableDateTimePickerEndDate.EditValue;

                switch (lsStatus)
                {
                    case "A%":
                        report.Parameters["gsStatus"].Value = "Active";
                        break;
                    case "I%":
                        report.Parameters["gsStatus"].Value = "Inactive";
                        break;
                    default:
                        report.Parameters["gsStatus"].Value = "Both";
                        break;
                }
                
                
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

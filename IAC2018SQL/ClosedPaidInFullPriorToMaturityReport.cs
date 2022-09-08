using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.DataAccess.Sql;


namespace IAC2021SQL
{
    public partial class frmClosedPaidInFullPriorToMaturityReport : DevExpress.XtraEditors.XtraForm
    {

        public frmClosedPaidInFullPriorToMaturityReport()
        {
            InitializeComponent();
        }

        private void frmClosedPaidInFullPriorToMaturityReport_Load(object sender, EventArgs e)
        {
            this.pAYCODETableAdapter.Fill(this.iACDataSet.PAYCODE);
            this.pAYMENTTYPETableAdapter.Fill(this.iACDataSet.PAYMENTTYPE);
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;
            nullableDateTimePickerFrom.EditValue = DateTime.Now.Date;
            nullableDateTimePickerTo.EditValue = DateTime.Now.Date;
            stateTableAdapter.Fill(iACDataSet.state);
            StatebindingSource.DataSource = iACDataSet.state;
            StatebindingSource.AddNew();
            StatebindingSource.EndEdit();
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("abbreviation", "");
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("name", "");
            StatebindingSource.EndEdit();
            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            DLRLISTBYNUMbindingSource.DataSource = iACDataSet.DLRLISTBYNUM;
            DLRLISTBYNUMbindingSource.AddNew();
            DLRLISTBYNUMbindingSource.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField<String>("DEALER_NAME", "                  ");
            DLRLISTBYNUMbindingSource.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            PrintClosedPaidInFullPriorToMaturityReport();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintClosedPaidInFullPriorToMaturityReport()
        {
            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + "%", lsState,
                    lsPaymentType = lookUpEditPaymentType.EditValue != null ? lookUpEditPaymentType.EditValue.ToString().Trim() : "" + "%",
                    lsPaymentCode = lookUpEditCodeType.EditValue != null ? lookUpEditCodeType.EditValue.ToString().Trim() : "" + "%",
                    lsDealer = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + "%";

            lsState = lookUpEditState.EditValue != null ? lookUpEditState.EditValue.ToString().Trim() : "" + "%";

            // Moses Newman 09/06/2022 Covert to XtraReport
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            var report = new XtraReportClosedPaidInFullPriorToMaturity();
            SqlDataSource ds = report.DataSource as SqlDataSource;

            report.DataSource = ds;
            report.RequestParameters = false;
            report.Parameters["gsUserID"].Value = Program.gsUserID;
            report.Parameters["gsUserName"].Value = Program.gsUserName;
            report.Parameters["gdFromDate"].Value = (DateTime)nullableDateTimePickerFrom.EditValue;
            report.Parameters["gdToDate"].Value = (DateTime)nullableDateTimePickerTo.EditValue;
            report.Parameters["gbGap"].Value = checkBoxGap.Checked;
            report.Parameters["gbWarranty"].Value = checkBoxWarranty.Checked;
            report.Parameters["gsState"].Value = lsState;
            report.Parameters["gsDealerNo"].Value = lsDealerNum;
            report.Parameters["gsPaymentType"].Value = lsPaymentType;
            report.Parameters["gsPaymentCode"].Value = lsPaymentCode;


            var tool = new ReportPrintTool(report);

            tool.PreviewRibbonForm.MdiParent = MDImain;
            tool.AutoShowParametersPanel = false;
            tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
            tool.ShowRibbonPreview();
        }
    }
}

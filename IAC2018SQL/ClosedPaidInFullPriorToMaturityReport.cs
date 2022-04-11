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
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;
            PrintClosedPaidInFullPriorToMaturityReport(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintClosedPaidInFullPriorToMaturityReport(ReportViewer rptViewer)
        {
            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + "%", lsState,
                    lsPaymentType = lookUpEditPaymentType.EditValue != null ? lookUpEditPaymentType.EditValue.ToString().Trim() : "" + "%",
                    lsPaymentCode = lookUpEditCodeType.EditValue != null ? lookUpEditCodeType.EditValue.ToString().Trim() : "" + "%",
                    lsDealer = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + "%";

            lsState = lookUpEditState.EditValue != null ? lookUpEditState.EditValue.ToString().Trim() : "" + "%";
            IACDataSetTableAdapters.PaidInFullPriorToMaturityTableAdapter PaidInFullPriorToMaturityTableAdapter = new IACDataSetTableAdapters.PaidInFullPriorToMaturityTableAdapter();


            PaidInFullPriorToMaturityTableAdapter.Fill(iACDataSet.PaidInFullPriorToMaturity,
                                                        (DateTime)nullableDateTimePickerFrom.EditValue,
                                                        (DateTime)nullableDateTimePickerTo.EditValue,
                                                        lsState,
                                                        lsDealerNum,
                                                        lsPaymentType,
                                                        lsPaymentCode,
                                                        checkBoxGap.Checked,
                                                        checkBoxWarranty.Checked);

            ClosedPaidInFullPriorToMaturityReport myReportObject = new ClosedPaidInFullPriorToMaturityReport();
            myReportObject.SetDataSource(iACDataSet);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gdFromDate", (DateTime)nullableDateTimePickerFrom.EditValue);
            myReportObject.SetParameterValue("gdToDate", (DateTime)nullableDateTimePickerTo.EditValue);
            rptViewer.crystalReportViewer.ReportSource = myReportObject;
            rptViewer.crystalReportViewer.Refresh();
            rptViewer.Show();
        }
    }
}

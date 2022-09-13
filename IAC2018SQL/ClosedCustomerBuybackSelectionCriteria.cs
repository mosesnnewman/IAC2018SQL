using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;


namespace IAC2021SQL
{
    public partial class frmClosedCustomerBuybackReport : DevExpress.XtraEditors.XtraForm
    {
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter = new IACDataSetTableAdapters.stateTableAdapter();

        public frmClosedCustomerBuybackReport()
        {
            InitializeComponent();
        }

        private void frmClosedCustomerBuybackReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iACDataSet.state' table. You can move, or remove it, as needed.
            this.stateTableAdapter1.Fill(this.iACDataSet.state);
            // Moses Newman 12/09/2018 Add Customer and Dealer State selection criteria
            stateTableAdapter.Fill(iACDataSet.state);

            CustomerStateBindingSource.DataSource = iACDataSet.state;
            CustomerStateBindingSource.AddNew();
            CustomerStateBindingSource.EndEdit();
            iACDataSet.state.Rows[CustomerStateBindingSource.Position].SetField<String>("abbreviation", "");
            iACDataSet.state.Rows[CustomerStateBindingSource.Position].SetField<String>("name", "");
            CustomerStateBindingSource.EndEdit();

            DealerStateBindingSource.DataSource = iACDataSet.state;
            DealerStateBindingSource.AddNew();
            DealerStateBindingSource.EndEdit();
            iACDataSet.state.Rows[DealerStateBindingSource.Position].SetField<String>("abbreviation", "");
            iACDataSet.state.Rows[DealerStateBindingSource.Position].SetField<String>("name", "");
            DealerStateBindingSource.EndEdit();

            lookUpEditDealerState.Properties.DataSource = DealerStateBindingSource;

            lookUpEditCustomerState.Properties.DataSource = CustomerStateBindingSource;

            this.pAYCODETableAdapter.Fill(this.iACDataSet.PAYCODE);
            this.pAYMENTTYPETableAdapter.Fill(this.iACDataSet.PAYMENTTYPE);
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.EditValue = DateTime.Now.Date;
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            PrintCustomerBuyback();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintCustomerBuyback()
        {
                    String  lsType = lookUpEditPaymentType.EditValue != null ? lookUpEditPaymentType.EditValue.ToString().Trim() : "" + "%", 
                    lsCode = lookUpEditCodeType.EditValue != null ? lookUpEditCodeType.EditValue.ToString().Trim() : "" + "%",
                    lsDealer    = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + "%",
                    lsDealerState = lookUpEditDealerState.EditValue != null ? lookUpEditDealerState.EditValue.ToString().Trim() : "" + "%", 
                    lsCustomerState = lookUpEditCustomerState.EditValue != null ? lookUpEditCustomerState.EditValue.ToString().Trim() : "" + "%";

            closedCustomerBuybackTableAdapter.Fill(iACDataSet.ClosedCustomerBuyback, ((DateTime)nullableDateTimePickerEndDate.EditValue).Date, ((DateTime)nullableDateTimePickerStartDate.EditValue).Date, lsType,lsCode,lsDealer,lsDealerState,lsCustomerState);
            
            if (iACDataSet.ClosedCustomerBuyback.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no CUSTOMER HISTORY records for the DATES and /or DEALER you selected!!! ***");
            else
            {
                Hide();
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

                // Moses Newman 09/12/2022 Covert to XtraReport
                var report = new XtraReportClosedCustomerBuyback();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gdStartDate"].Value = ((DateTime)nullableDateTimePickerStartDate.EditValue).Date;
                report.Parameters["gdEndDate"].Value = ((DateTime)nullableDateTimePickerEndDate.EditValue).Date;
                report.Parameters["gsType"].Value = lsType;
                report.Parameters["gsCode"].Value = lsCode;
                report.Parameters["gsDealer"].Value = lsDealer;
                report.Parameters["gsDealerState"].Value = lsDealerState;
                report.Parameters["gsState"].Value = lsCustomerState;


                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
        }

        private void lookUpEditPaymentType_EditValueChanged(object sender, EventArgs e)
        {
            iACDataSet.PAYCODE.Clear();
            pAYCODETableAdapter.FillByType(iACDataSet.PAYCODE, (String)lookUpEditPaymentType.EditValue);
            PaymentCodebindingSource.DataSource = iACDataSet.PAYCODE;
            PaymentCodebindingSource.MoveFirst();
            lookUpEditCodeType.EditValue = iACDataSet.PAYCODE.Rows[0].Field<String>("Code");
            lookUpEditCodeType.Refresh();
        }
    }
}

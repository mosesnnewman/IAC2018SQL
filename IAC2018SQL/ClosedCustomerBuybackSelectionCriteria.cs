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
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintCustomerBuyback(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintCustomerBuyback(ReportViewer rptViewer)
        {
            IACDataSetTableAdapters.ClosedCustomerBuybackSummaryTableAdapter ClosedCustomerBuybackSummaryTableAdapter = 
                                new IACDataSetTableAdapters.ClosedCustomerBuybackSummaryTableAdapter();
            String  lsType = lookUpEditPaymentType.EditValue != null ? lookUpEditPaymentType.EditValue.ToString().Trim() : "" + "%", 
                    lsCode = lookUpEditCodeType.EditValue != null ? lookUpEditCodeType.EditValue.ToString().Trim() : "" + "%",
                    lsDealer    = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + "%",
                    lsDealerState = lookUpEditDealerState.EditValue != null ? lookUpEditDealerState.EditValue.ToString().Trim() : "" + "%", 
                    lsCustomerState = lookUpEditCustomerState.EditValue != null ? lookUpEditCustomerState.EditValue.ToString().Trim() : "" + "%";

            closedCustomerBuybackTableAdapter.Fill(iACDataSet.ClosedCustomerBuyback, ((DateTime)nullableDateTimePickerEndDate.EditValue).Date, ((DateTime)nullableDateTimePickerStartDate.EditValue).Date, lsType,lsCode,lsDealer,lsDealerState,lsCustomerState);
            ClosedCustomerBuybackSummaryTableAdapter.Fill(iACDataSet.ClosedCustomerBuybackSummary, ((DateTime)nullableDateTimePickerEndDate.EditValue).Date, ((DateTime)nullableDateTimePickerStartDate.EditValue).Date, lsType, lsCode, lsDealer,lsDealerState,lsCustomerState);
            
            if (iACDataSet.ClosedCustomerBuyback.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no CUSTOMER HISTORY records for the DATES and /or DEALER you selected!!! ***");
            else
            {
                ClosedCustomerBuybackReport myReportObject = new ClosedCustomerBuybackReport();
                myReportObject.SetDataSource(iACDataSet);
                myReportObject.SetParameterValue("gdStartDate", ((DateTime)nullableDateTimePickerStartDate.EditValue).Date);
                myReportObject.SetParameterValue("gdEndDate", ((DateTime)nullableDateTimePickerEndDate.EditValue).Date);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
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

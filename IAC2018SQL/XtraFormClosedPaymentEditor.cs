using CrystalDecisions.ReportAppServer.DataDefModel;
using DevExpress.CodeParser;
using DevExpress.XtraEditors;
using IAC2021SQL.IACDataSetTableAdapters;
using IAC2021SQL.ListDataTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;
using Microsoft.Office.Interop.Outlook;

namespace IAC2021SQL
{
    public partial class XtraFormClosedPaymentEditor : DevExpress.XtraEditors.XtraForm
    {

        public Int32 CustomerID
        {
            get;
            set;
        }
        public DateTime PaymentDate
        {
            get;
            set;
        }
        public Int32 SeqNo
        {
            get;
            set;
        }

        public Boolean lbEdit
        { get; set; }

        public Boolean lbAddFlag
        { get; set; }

        public XtraFormClosedPaymentEditor()
        {
            InitializeComponent();
        }

        private Boolean _InFillIt = false;
        private void checkEditEFT_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            string val = e.Value.ToString();
            switch (val)
            {
                case "Y":
                    e.CheckState = CheckState.Checked;
                    break;
                case "N":
                    e.CheckState = CheckState.Unchecked;
                    break;
                default:
                    e.CheckState = CheckState.Unchecked;
                    break;
            }
            e.Handled = true;
        }

        private void checkEditEFT_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            object val = edit.EditValue;
            switch (e.CheckState)
            {
                case CheckState.Checked:
                    e.Value = "Y";
                    break;
                case CheckState.Unchecked:
                    e.Value = "N";
                    break;
                default:
                    e.Value = "N";
                    break;
            }
            e.Handled = true;
        }

        private void lookUpEditPaymentType_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            switch (lookUpEdit.EditValue.ToString())
            {
                case "I":
                    layoutControlISFDate.ContentVisible = true;
                    layoutControlChangeISFDateButton.ContentVisible = true;
                    break;
                case "E":
                    layoutControlExtensionCount.ContentVisible = true;
                    layoutControlExtensionCount.ContentVisible = true;
                    break;
            }

            if (!lbEdit & !lbAddFlag)
            {
                iacDataSet.PAYCODE.Clear();
                paycodeTableAdapter.FillByType(iacDataSet.PAYCODE, "*");
                bindingSourcePAYCODE.DataSource = iacDataSet.PAYCODE;
                return;
            }
            iacDataSet.PAYCODE.Clear();
            paycodeTableAdapter.FillByType(iacDataSet.PAYCODE, lookUpEdit.EditValue.ToString());
            bindingSourcePAYCODE.DataSource = iacDataSet.PAYCODE;
            bindingSourcePAYCODE.MoveFirst();
            lookUpEditPaymentCode.EditValue = iacDataSet.PAYCODE.Rows[0].Field<String>("Code");
            lookUpEditPaymentCode.Refresh();
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
            HandleISF();
        }

        private void XtraFormClosedPaymentEditor_Load(object sender, EventArgs e)
        {
            lookUpEditPaymentType.EditValue = "R";
            lookUpEditPaymentCode.EditValue = "N";
            dateEditPaymentDate.EditValue = PaymentDate;
            paycodeTableAdapter.Fill(iacDataSet.PAYCODE);
            paymenttypeTableAdapter.Fill(iacDataSet.PAYMENTTYPE);
            customerTableAdapter.FillByAllPosted(customerLookupDataSet.CUSTOMER);
            layoutControlOverPayment.ContentVisible = false;
            layoutControlIncome.ContentVisible = false;
            textEditCustomerID.EditValue = CustomerID;
        }
        public void FillIt()
        {
            customerTableAdapter.FillByID(iacDataSet.CUSTOMER, CustomerID);
            dealerTableAdapter.Fill(iacDataSet.DEALER, iacDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
            if(!lbAddFlag)
                paymentTableAdapter.FillByKey(iacDataSet.PAYMENT, iacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"), PaymentDate, SeqNo);
            else 
            {
                if (bindingSourcePAYMENT.Position == -1)
                {
                    IACDataSet.PAYMENTRow newRow = iacDataSet.PAYMENT.NewPAYMENTRow();
                    newRow.PAYMENT_CUSTOMER = textEditCustomerID.EditValue.ToString().PadLeft(6, '0');
                    newRow.PAYMENT_DATE = (DateTime)dateEditPaymentDate.EditValue;
                    newRow.PAYMENT_DEALER = (Int32)textEditDealerID.EditValue;
                    newRow.PAYMENT_TYPE = "R";
                    newRow.PAYMENT_CODE_2 = "N";
                    newRow.PAYMENT_AUTO_PAY = "N";
                    iacDataSet.PAYMENT.AddPAYMENTRow(newRow);
                }
                else
                    iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<String>("PAYMENT_CUSTOMER", textEditCustomerID.EditValue.ToString().PadLeft(6, '0'));
                bindingSourcePAYMENT.EndEdit();
            }
            Refresh();
        }


        private void HandleISF()
        {
            if (iacDataSet.PAYMENT.Rows.Count < 1 || bindingSourcePAYMENT.Position < 0)
                return;
            bindingSourcePAYMENT.EndEdit();
            if ((String)lookUpEditPaymentType.EditValue != "I" && iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Decimal>("PAYMENT_AMOUNT_RCV") >= 0)
            {
                if (lbAddFlag || lbEdit)
                    if (iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") != null)
                    {
                        iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<Nullable<DateTime>>("PAYMENT_ISF_DATE", null);
                        bindingSourcePAYMENT.EndEdit();
                    }
                layoutControlChangeISFDateButton.ContentVisible = false;
                layoutControlISFDate.ContentVisible = false;
                return;
            }
            else
            {
                if (iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") != null)
                {
                    layoutControlChangeISFDateButton.ContentVisible = true;
                    if (lbAddFlag || lbEdit)
                        layoutControlChangeISFDateButton.ContentVisible = true;
                    else
                        layoutControlChangeISFDateButton.ContentVisible = false;
                }
                else
                    layoutControlChangeISFDateButton.ContentVisible = false;
                layoutControlISFDate.ContentVisible = true;
            }

            if (!lbAddFlag && !lbEdit)
                return;
            if (iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") == null)
            {
                SelectCheck();
            }
            return;
        }

        private void SelectCheck()
        {
            FormSelectCheck frmSelectCheckInst;
            frmSelectCheckInst = new FormSelectCheck(iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_CUSTOMER"), true, (String)lookUpEditPaymentType.EditValue);
            if (!frmSelectCheckInst.DoNotShow)
            {
                frmSelectCheckInst.ShowDialog();
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<DateTime>("PAYMENT_ISF_DATE", frmSelectCheckInst.ldISFDate);
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<Decimal>("PAYMENT_CURR_INT", frmSelectCheckInst.lnCurrInt);
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<Decimal>("PAYMENT_LATE_CHARGE_PAID", frmSelectCheckInst.lnLateChargePaid);
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<Boolean>("IsSimple", frmSelectCheckInst.lbIsSimple);
                // Moses Newman 04/13/2018 Add ISFSeqNo, ISFPaymentType, and ISFPaymentCode so that excact reversed payment can be found.
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<Int32>("ISFSeqNo", frmSelectCheckInst.ISFSeqNo);
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<String>("ISFPaymentType", frmSelectCheckInst.ISFPaymentType);
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<String>("ISFPaymentCode", frmSelectCheckInst.ISFPaymentCode);
                // Moses Newman 10/10/2020
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<Int32>("ISFID", frmSelectCheckInst.ISFID);
                bindingSourcePAYMENT.EndEdit();
            }
            else
            {
                iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<DateTime?>("PAYMENT_ISF_DATE", null);
            }
            frmSelectCheckInst.Dispose();
        }

        private void buttonChangeISFDate_Click(object sender, EventArgs e)
        {
            SelectCheck();
        }

        private void textEditExtensionCount_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            textEdit.EditValue = textEdit.EditValue.ToString() != "" ? textEdit.EditValue : 0;
            if ((Int32)textEdit.EditValue == 0)
                layoutControlExtensionCount.ContentVisible = false;
            else
                layoutControlExtensionCount.ContentVisible = true;
        }

        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            switch (btn.Caption)
            {
                case "Search":
                    this.Hide();
                    frmCustomerLookup formCustomerLookup = new frmCustomerLookup();
                    formCustomerLookup.LookupFormType = "C";
                    formCustomerLookup.Visible = false;
                    formCustomerLookup.ShowDialog(this);
                    this.Show();
                    if (Program.gsKey != null)
                    {
                        CustomerID = Convert.ToInt32(Program.gsKey);
                        if (CustomerID != 0)
                            textEditCustomerID.EditValue = CustomerID;
                        Program.gsKey = null;
                    }
                    break;
                case "Save":
                    if (lbAddFlag)
                    {
                        iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<String>("PAYMENT_CUSTOMER", textEditCustomerID.EditValue.ToString().PadLeft(6, '0'));
                        iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<DateTime>("PAYMENT_DATE", (DateTime)dateEditPaymentDate.EditValue);
                        iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<Int32>("PAYMENT_DEALER", (Int32)textEditDealerID.EditValue);
                    }
                    bindingSourcePAYMENT.EndEdit();
                    paymentTableAdapter.Update(iacDataSet.PAYMENT);
                    iacDataSet.PAYMENT.AcceptChanges();
                    Close();
                    break;
                case "Close":
                    Close();
                    break;
            }
        }
        private void General_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            else
            {
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
            }
        }

        private void textEditCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            if (_InFillIt)
                return;
            _InFillIt = true;
            GridLookUpEdit gedit = sender as GridLookUpEdit;
            CustomerID = gedit.EditValue.ToString() != String.Empty ? (Int32)gedit.EditValue:0;
            if(CustomerID !=0)
            {
                FillIt();
            }
            _InFillIt = false;
        }
    }
}
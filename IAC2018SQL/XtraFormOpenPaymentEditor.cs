﻿using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;
using DevExpress.Utils.Html;
using DevExpress.Utils;
using DevExpress.CodeParser;
using static DevExpress.CodeParser.CodeStyle.Formatting.Rules;

namespace IAC2021SQL
{
    public partial class XtraFormOpenPaymentEditor : DevExpress.XtraEditors.XtraForm
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

        public XtraFormOpenPaymentEditor()
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
                default:
                    e.Value = "N";
                    break;
            }
            e.Handled = true;
        }

        private void lookUpEditPaymentType_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;
            if (lookUpEdit == null)
                return;
            switch (lookUpEdit.EditValue.ToString())
            {
                case "":
                    return;
                case "I":
                    Decimal lnCheckValue = !String.IsNullOrEmpty(textEditAmount.EditValue.ToString()) ? Convert.ToDecimal(textEditAmount.EditValue) : 0;
                    if (lnCheckValue > 0)
                    {
                        lnCheckValue *= -1;
                        textEditAmount.EditValue = lnCheckValue;
                    }
                    layoutControlISFDate.ContentVisible = true;
                    layoutControlChangeISFDateButton.ContentVisible = true;
                    break;
                case "E":
                    layoutControlExtensionCount.ContentVisible = true;
                    layoutControlExtensionCount.ContentVisible = true;
                    // Moses Newman 07/30/2024 If extension move straight to Extension Count.
                    textEditExtensionCount.Focus();
                    return;
            }
            lookUpEdit.Properties.Buttons[0].PerformClick();
            if (!lbEdit && !lbAddFlag)
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
            // Moses Newman 02/03/2024 handle index out of range possibility.
            if (iacDataSet.PAYCODE.Rows.Count > 0)
            {
                lookUpEditPaymentCode.EditValue = iacDataSet.PAYCODE.Rows[0].Field<String>("Code");
                if (lookUpEdit.EditValue.ToString() == "I" && lookUpEditPaymentCode.EditValue.ToString().Trim() == "")
                    lookUpEditPaymentCode.EditValue = "N";
            }
            lookUpEditPaymentCode.Refresh();
            ActiveControl = lookUpEditPaymentCode;
            HandleISF();
        }

        private void XtraFormClosedPaymentEditor_Load(object sender, EventArgs e)
        {
            lookUpEditPaymentType.EditValue = "R";
            lookUpEditPaymentCode.EditValue = "N";
            dateEditPaymentDate.EditValue = PaymentDate;
            paycodeTableAdapter.Fill(iacDataSet.PAYCODE);
            paymenttypeTableAdapter.Fill(iacDataSet.PAYMENTTYPE);
            oPNCUSTTableAdapter.FillByAllPosted(customerLookupDataSet.OPNCUST);
            layoutControlOverPayment.ContentVisible = false;
            layoutControlISFDate.ContentVisible = false;
            layoutControlChangeISFDateButton.ContentVisible = false;
            layoutControlExtensionCount.ContentVisible = false;
            textEditPaidThrough.Enabled = false;
            if (lbAddFlag || CustomerID == 0)
            {
                textEditPaidThrough.Enabled = false;
                dateEditPaymentDate.Enabled = false;
                textEditAmount.Enabled = false;
                lookUpEditPaymentType.Enabled = false;
                lookUpEditPaymentCode.Enabled = false;
                checkEditEFT.Enabled = false;
            }
            else
            {
                textEditCustomerID.Enabled = false;
                windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
            }
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            textEditCustomerID.EditValue = CustomerID;
            if (lbAddFlag)
                ActiveControl = textEditCustomerID;
            else
                ActiveControl = dateEditPaymentDate;
        }
        public void FillIt()
        {
            IACDataSet tempDataSet = new IACDataSet();
            oPNCUSTTableAdapter.FillByID(iacDataSet.OPNCUST, CustomerID);
            if (iacDataSet.OPNCUST.Rows.Count < 1) // Moses Newman 02/03/2024 return if the customer is not found.
                return;
            oPNDEALRTableAdapter.Fill(iacDataSet.OPNDEALR, iacDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_DEALER"));
            if(!lbAddFlag)
                oPNPAYTableAdapter.FillByKey(iacDataSet.OPNPAY, iacDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_NO"), PaymentDate);
            else 
            {
                oPNPAYTableAdapter.Fill(tempDataSet.OPNPAY, textEditCustomerID.EditValue.ToString().PadLeft(6, '0'));
                if (tempDataSet.OPNPAY.Rows.Count != 0)
                {
                    var msgArgs = new XtraMessageBoxArgs();
                    msgArgs.HtmlTemplate.Assign(htmlTemplate1);
                    msgArgs.HtmlImages = svgImageCollection1;
                    msgArgs.Caption = "Closed Payment Entry Duplicate";
                    msgArgs.Text = "*** There already is a payment for this customer. Do you want to add another ? ***";
                    var result = XtraMessageBox.Show(msgArgs);
                    if (result.ToString() != "OK")
                    {
                        this.ActiveControl = layoutControlCustomerHeader;
                        layoutControlCustomerHeader.ActiveControl = textEditCustomerID;
                        Control c = this.ActiveControl;
                        if (c is DevExpress.XtraLayout.LayoutControl)
                        {
                            if (!(((DevExpress.XtraLayout.LayoutControl)ActiveControl).ActiveControl == null))
                            {
                                c = ((DevExpress.XtraLayout.LayoutControl)ActiveControl).ActiveControl;
                            }
                        }
                        if (c is DevExpress.XtraEditors.TextBoxMaskBox)
                        {
                            c = c.Parent;
                        }
                        this.Text = c.Name;
                        iacDataSet.OPNPAY.Clear();
                        iacDataSet.OPNCUST.Clear();
                        iacDataSet.OPNDEALR.Clear();
                        dateEditPaymentDate.EditValue = DateTime.Now.Date;
                        ActiveControl = textEditCustomerID;
                        Refresh();
                        return;
                    }
                }
                if (bindingSourcePAYMENT.Position == -1)
                {
                    lookUpEditPaymentType.EditValue = "";
                    IACDataSet.OPNPAYRow newRow = iacDataSet.OPNPAY.NewOPNPAYRow();
                    newRow.PAYMENT_CUSTOMER = textEditCustomerID.EditValue.ToString().PadLeft(6, '0');
                    newRow.PAYMENT_DATE = (DateTime)dateEditPaymentDate.EditValue;
                    newRow.PAYMENT_DEALER = (String)textEditDealerID.EditValue;
                    newRow.PAYMENT_TYPE = " ";
                    newRow.PAYMENT_CODE_2 = "N";
                    newRow.PAYMENT_AUTO_PAY = "N";
                    iacDataSet.OPNPAY.AddOPNPAYRow(newRow);
                    lookUpEditPaymentType.EditValue = newRow.PAYMENT_TYPE;
                    lookUpEditPaymentCode.EditValue = newRow.PAYMENT_CODE_2;
                }
                else
                    iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].SetField<String>("PAYMENT_CUSTOMER", textEditCustomerID.EditValue.ToString().PadLeft(6, '0'));
            }
            Refresh();
        }


        private void HandleISF()
        {
            if (iacDataSet.OPNPAY.Rows.Count < 1 || bindingSourcePAYMENT.Position < 0)
                return;
            //bindingSourcePAYMENT.EndEdit();
            if (((String)lookUpEditPaymentType.EditValue != "I" && iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<Decimal>("PAYMENT_AMOUNT_RCV") >= 0) ||
                (checkEditNoAdjLookBack.Checked && (String)lookUpEditPaymentType.EditValue == "A") || (String)lookUpEditPaymentType.EditValue == "N")
            {
                if (lbAddFlag || lbEdit)
                    if (!String.IsNullOrEmpty(dateEditISFDate.EditValue.ToString()))
                        dateEditISFDate.EditValue = "";
                layoutControlChangeISFDateButton.ContentVisible = false;
                layoutControlISFDate.ContentVisible = false;
                return;
            }
            else
            {
                if (!String.IsNullOrEmpty(dateEditISFDate.EditValue.ToString()))
                {
                    layoutControlISFDate.ContentVisible = true;
                    layoutControlChangeISFDateButton.ContentVisible = true;
                }
                else
                {
                    layoutControlISFDate.ContentVisible = false;
                    layoutControlChangeISFDateButton.ContentVisible = false;
                }
            }

            if (!lbAddFlag && !lbEdit)
                return;
            if (String.IsNullOrEmpty(dateEditISFDate.EditValue.ToString()))
            {
                SelectCheck();
            }
            return;
        }

        private void SelectCheck()
        {
            FormSelectCheck frmSelectCheckInst;
            frmSelectCheckInst = new FormSelectCheck(iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_CUSTOMER"), false, (String)lookUpEditPaymentType.EditValue);
            if (!frmSelectCheckInst.DoNotShow) 
            {
                frmSelectCheckInst.ShowDialog();
                if (frmSelectCheckInst.ldISFDate != DateTime.Parse("01/01/0001"))
                {
                    dateEditISFDate.EditValue = frmSelectCheckInst.ldISFDate;
                    iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].SetField<DateTime>("PAYMENT_ISF_DATE", frmSelectCheckInst.ldISFDate);
                    layoutControlISFDate.ContentVisible = true;
                    layoutControlChangeISFDateButton.ContentVisible = true;
                }
                //bindingSourcePAYMENT.EndEdit();
            }
            else
            {
                if (iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<DateTime?>("PAYMENT_DATE") == null)
                {
                    layoutControlISFDate.ContentVisible = false;
                    layoutControlChangeISFDateButton.ContentVisible = false;
                }
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
            // Moses Newman 08/29/2023 Handle null values properly!
            textEdit.EditValue = !String.IsNullOrEmpty(textEdit.EditValue.ToString()) ? textEdit.EditValue : 0;
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
                    SendKeys.SendWait("{TAB}");  // Moses Newman 10/12/2023 save amount if not tabbed out.
                    if (lbAddFlag)
                    {
                        if (bindingSourcePAYMENT.Position == -1)
                        {
                            FillIt();
                        }
                        // Moses Newman 02/13/2024 Handle no payment record
                        if (bindingSourcePAYMENT.Position == -1)
                            return;
                        else
                        {
                            iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].SetField<String>("PAYMENT_CUSTOMER", textEditCustomerID.EditValue.ToString().PadLeft(6, '0'));
                            iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].SetField<DateTime>("PAYMENT_DATE", (DateTime)dateEditPaymentDate.EditValue);
                            iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].SetField<String>("PAYMENT_DEALER", (String)textEditDealerID.EditValue);
                        }
                    }
                    bindingSourcePAYMENT.EndEdit();
                    Int32? SeqNo = 0;
                    if (lbAddFlag)
                    {
                        oPNPAYTableAdapter.InsertReturnSeqNo(iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_CUSTOMER"), "", "O",
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<DateTime?>("PAYMENT_DATE"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_DEALER"),
                                                              "",
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<Decimal?>("PAYMENT_AMOUNT_RCV"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_TYPE"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<Int32?>("PAYMENT_THRU_UD"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_CODE_2"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_ALLOTMENT"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<DateTime?>("PAYMENT_ISF_DATE"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_AUTO_PAY"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_TSB_COMMENT_CODE"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<Boolean?>("IsLocked"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<String>("LockedBy"),
                                                              iacDataSet.OPNPAY.Rows[bindingSourcePAYMENT.Position].Field<DateTime?>("LockTime"),
                                                              ref SeqNo);
                    }
                    else
                    {
                        oPNPAYTableAdapter.Update(iacDataSet.OPNPAY);
                    }
                    iacDataSet.OPNPAY.AcceptChanges();
                    this.ActiveControl = layoutControlCustomerHeader;
                    layoutControlCustomerHeader.ActiveControl = textEditCustomerID;
                    Control c = this.ActiveControl;
                    if (c is DevExpress.XtraLayout.LayoutControl)
                    {
                        if (!(((DevExpress.XtraLayout.LayoutControl)ActiveControl).ActiveControl == null))
                        {
                            c = ((DevExpress.XtraLayout.LayoutControl)ActiveControl).ActiveControl;
                        }
                    }
                    if (c is DevExpress.XtraEditors.TextBoxMaskBox)
                    {
                        c = c.Parent;
                    }
                    this.Text = c.Name;
                    iacDataSet.OPNPAY.Clear();
                    iacDataSet.OPNCUST.Clear();
                    iacDataSet.OPNDEALR.Clear();
                    dateEditPaymentDate.EditValue = DateTime.Now.Date;
                    ActiveControl = textEditCustomerID;
                    if(!lbAddFlag)
                        Close();
                    break;
                case "Close":
                    Close();
                    break;
            }
        }
        private void textEditCustomerID_EditValueChanged(object sender, EventArgs e)
        {
            if (_InFillIt)
                return;
            _InFillIt = true;
            GridLookUpEdit gedit = sender as GridLookUpEdit;
            if (gedit.EditValue == null) // Moses Newman 03/27/2024 if gedit.EditValue is null set CustomerID = 0 so it does not blow up.
                CustomerID = 0;
            else
                CustomerID = gedit.EditValue.ToString() != String.Empty ? (Int32)gedit.EditValue:0;
            if(CustomerID !=0)
            {
                FillIt();
                if (iacDataSet.OPNCUST.Rows.Count > 0 && iacDataSet.OPNDEALR.Rows.Count > 0)
                {
                    dateEditPaymentDate.Enabled = true;
                    textEditAmount.Enabled = true;
                    lookUpEditPaymentType.Enabled = true;
                    lookUpEditPaymentCode.Enabled = true;
                    checkEditEFT.Enabled = true;
                    if (lbAddFlag)
                        windowsUIButtonPanel1.Buttons[0].Properties.Enabled = true;
                }
               
            }
            _InFillIt = false;
            gedit.Properties.Buttons[0].PerformClick();
            textEditAmount.Focus();
            //SendKeys.SendWait("{TAB}");
        }

        private void textEditAmount_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit textEditor = sender as TextEdit;
            Decimal lnCheckValue;
            Boolean _IsDecimal = Decimal.TryParse(textEditor.EditValue.ToString(), out lnCheckValue);
            if (!_IsDecimal || lnCheckValue == 0)
                return;
            String PaymentType = !String.IsNullOrEmpty(lookUpEditPaymentType.EditValue.ToString()) ? lookUpEditPaymentType.EditValue.ToString() : "";
            if (lnCheckValue > 0 && PaymentType == "I")
            {
                lnCheckValue *= -1;
                textEditor.EditValue = lnCheckValue;
            }
        }

        private void textEditAmount_Validated(object sender, EventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            Decimal lnCheckValue = 0, lnBalance = 0, lnOverPay;
            Boolean _IsDecimal = Decimal.TryParse(textEdit.EditValue.ToString(), out lnCheckValue);
            _IsDecimal = Decimal.TryParse(textEditBalance.EditValue.ToString(), out lnBalance);
            if (lnCheckValue > lnBalance && (lbEdit || lbAddFlag))
            {
                // 
                // OverPayment
                // 
                lnOverPay = lnCheckValue - lnBalance;
                layoutControlOverPayment.ContentVisible = true;
                textEditOverPayment.Enabled = false;
                textEditOverPayment.EditValue = lnOverPay;
                textEditOverPayment.Refresh();
            }
            else
            {
                lnOverPay = 0;
                layoutControlOverPayment.ContentVisible = false;
                textEditOverPayment.Enabled = false;
                textEditOverPayment.EditValue = lnOverPay;
                textEditOverPayment.Refresh();
            }
        }

        private void dateEditPaymentDate_Properties_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
        }

        private void textEditCustomerID_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled =true;
        }

        private void dateEditPaymentDate_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
        }

        private void textEditAmount_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
        }

        private void dateEditISFDate_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
        }

        private void lookUpEditPaymentType_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
        }

        private void lookUpEditPaymentCode_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
        }

        private void textEditExtensionCount_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
        }

        private void checkEditEFT_Modified(object sender, EventArgs e)
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
        }
    }
}
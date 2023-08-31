using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking2010;

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
            switch (lookUpEdit.EditValue.ToString())
            {

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
                    break;
            }

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
            lookUpEditPaymentCode.EditValue = iacDataSet.PAYCODE.Rows[0].Field<String>("Code");
            lookUpEditPaymentCode.Refresh();
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
            }
            Refresh();
        }


        private void HandleISF()
        {
            if (iacDataSet.PAYMENT.Rows.Count < 1 || bindingSourcePAYMENT.Position < 0)
                return;
            //bindingSourcePAYMENT.EndEdit();
            if (((String)lookUpEditPaymentType.EditValue != "I" && iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Decimal>("PAYMENT_AMOUNT_RCV") >= 0) ||
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
            frmSelectCheckInst = new FormSelectCheck(iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_CUSTOMER"), true, (String)lookUpEditPaymentType.EditValue);
            if (!frmSelectCheckInst.DoNotShow) 
            {
                frmSelectCheckInst.ShowDialog();
                if (frmSelectCheckInst.ldISFDate != DateTime.Parse("01/01/0001"))
                {
                    dateEditISFDate.EditValue = frmSelectCheckInst.ldISFDate;
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
                    layoutControlISFDate.ContentVisible = true;
                    layoutControlChangeISFDateButton.ContentVisible = true;
                }
                //bindingSourcePAYMENT.EndEdit();
            }
            else
            {
                if (iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<DateTime?>("PAYMENT_DATE") == null)
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
                    if (lbAddFlag)
                    {
                        iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<String>("PAYMENT_CUSTOMER", textEditCustomerID.EditValue.ToString().PadLeft(6, '0'));
                        iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<DateTime>("PAYMENT_DATE", (DateTime)dateEditPaymentDate.EditValue);
                        iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].SetField<Int32>("PAYMENT_DEALER", (Int32)textEditDealerID.EditValue);
                    }
                    bindingSourcePAYMENT.EndEdit();
                    Int32? SeqNo = 0;
                    if (lbAddFlag)
                    {
                        paymentTableAdapter.InsertReturnSeqNo(iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_CUSTOMER"), "", "C",
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<DateTime?>("PAYMENT_DATE"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Int32?>("PAYMENT_DEALER"),
                                                              "",
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Decimal?>("PAYMENT_AMOUNT_RCV"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_TYPE"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Int32?>("PAYMENT_THRU_UD"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_CODE_2"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_AUTO_PAY"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<DateTime?>("PAYMENT_ISF_DATE"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Decimal?>("PAYMENT_CURR_INT"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Decimal?>("PAYMENT_LATE_CHARGE_PAID"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("CreditCardType"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Boolean?>("IsSimple"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("PAYMENT_TSB_COMMENT_CODE"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Boolean?>("IsLocked"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("LockedBy"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<DateTime?>("LockTime"),
                                                              ref SeqNo,
                                                              DateTime.Now.Date,
                                                              0,
                                                              false,
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Int32?>("ISFSeqNo"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("ISFPAymentType"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<String>("ISFPAymentCode"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Int32?>("ISFID"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Int32?>("TicketID"),
                                                              iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Int32?>("TicketDetailID"));
                    }
                    else
                    {
                        paymentTableAdapter.Update(iacDataSet.PAYMENT);
                        SeqNo = iacDataSet.PAYMENT.Rows[bindingSourcePAYMENT.Position].Field<Int32>("SeqNo");
                    }
                    iacDataSet.PAYMENT.AcceptChanges();
                    Program.CreateSingleTempPayment(textEditCustomerID.EditValue.ToString().PadLeft(6, '0'), (DateTime)dateEditPaymentDate.EditValue, (Int32)SeqNo);
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
            CustomerID = gedit.EditValue.ToString() != String.Empty ? (Int32)gedit.EditValue:0;
            if(CustomerID !=0)
            {
                FillIt();
                if(iacDataSet.CUSTOMER.Rows.Count > 0 && iacDataSet.DEALER.Rows.Count > 0)
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
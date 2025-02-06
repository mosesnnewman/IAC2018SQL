using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Repository;
using DevExpress.XtraEditors;
using DevExpress.Data;
using DevExpress.XtraBars;
using Word = Microsoft.Office.Interop.Word;


namespace IAC2021SQL
{
    public partial class formClosedPayment : DevExpress.XtraEditors.XtraForm
    {
        System.Windows.Forms.Label labelOverPayment, lblIncome, lblPaidThrough, labelISFDate;

        private Microsoft.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private Microsoft.Data.SqlClient.SqlConnection tableAdapConn = null;

        private Boolean lbAddFlag = false, lbEdit = false, lbFormClosing = false, lbNewPayment = false, lbILockedIt = false,lbJustSaved = false;

        private Decimal gnCustomerBalance = 0, gnCustomerBuyout = 0;

        private int lnSeq = 0;
        

        public formClosedPayment()
        {
            InitializeComponent();
        }

        private void formClosedPayment_Load(object sender, EventArgs e)
        {
            this.specialCommentCodesTableAdapter.Fill(this.ClosedPaymentiacDataSet.SpecialCommentCodes);
            pAYCODETableAdapter.Fill(ClosedPaymentiacDataSet.PAYCODE);
            pAYMENTTYPETableAdapter.Fill(ClosedPaymentiacDataSet.PAYMENTTYPE);
            labelOverPayment = new Label();
            labelOverPayment.AutoSize = true;
            labelOverPayment.Location = new System.Drawing.Point(288, 52);
            labelOverPayment.Name = "labelOverPayment";
            labelOverPayment.Size = new System.Drawing.Size(95, 13);
            labelOverPayment.TabIndex = 150;
            labelOverPayment.Text = "OVER PAYMENT:";
            groupBox2.Controls.Add(labelOverPayment);
            // 
            // lblIncome
            // 
            lblIncome = new Label();
            lblIncome.AutoSize = true;
            lblIncome.Location = new System.Drawing.Point(310, 78);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new System.Drawing.Size(52, 13);
            lblIncome.TabIndex = 152;
            lblIncome.Text = "UE INCOME:";
            groupBox2.Controls.Add(lblIncome);
            // 
            // lblPaidThrough
            // 
            lblPaidThrough = new Label();
            lblPaidThrough.AutoSize = true;
            lblPaidThrough.Location = new System.Drawing.Point(383, 156);
            lblPaidThrough.Name = "lblPaidThrough";
            lblPaidThrough.Size = new System.Drawing.Size(157, 13);
            lblPaidThrough.TabIndex = 150;
            lblPaidThrough.Text = "UPDATE PAID THROUGH BY:";
            groupBox2.Controls.Add(lblPaidThrough);

            // ISF label
            labelISFDate = new Label();
            labelISFDate.AutoSize = true;
            labelISFDate.Location = new System.Drawing.Point(323, 104);
            labelISFDate.Name = "labelISFDate";
            labelISFDate.Size = new System.Drawing.Size(58, 13);
            labelISFDate.TabIndex = 155;
            labelISFDate.Text = "ISF DATE:";
            labelISFDate.Visible = false;
            labelISFDate.Enabled = true;
            groupBox2.Controls.Add(labelISFDate);
            buttonChangeISFDate.Visible = false;
            buttonChangeISFDate.Enabled = false;

            lookUpEditCodeType.Properties.DataSource = PAYCODEbindingSource;
            StartUpConfiguration();
            PerformAutoScale();
        }

        private void StartUpConfiguration()
        {
            if (!lbAddFlag)
            {
                Program.gsKey = null;
                lbAddFlag = false;
            }
            lookUpEditPaymentType.EditValue = "R";
            lookUpEditCodeType.EditValue = "N";
            EFTtextBox.Text = "N";
            txtPaymentDate.Text = DateTime.Today.ToShortDateString();
            labelOverPayment.Visible = false;
            labelOverPayment.Enabled = true;

            lblIncome.Visible = false;
            lblIncome.Enabled = true;

            lblPaidThrough.Visible = false;
            lblPaidThrough.Enabled = true;

            SetViewMode();

            ActiveControl = cUSTOMER_NOTextBox;
            cUSTOMER_NOTextBox.Select();
        }

        private void SetViewMode()
        {
            toolStripButtonAdd.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            txtCheckValue.ReadOnly = true;
            lookUpEditPaymentType.Enabled = false;
            lookUpEditCodeType.Enabled = false;
            EFTtextBox.ReadOnly = true;
            listBoxTSBCommentCode.Enabled = false;
            txtOverPayment.ReadOnly = true;
            txtIncome.ReadOnly = true;
            PaidThroughUDtextBox.ReadOnly = true;
            cOMMENTDataGridView.Enabled = true;
            cOMMENTgridView.OptionsBehavior.Editable = false;
            cUSTHISTDataGridView.Enabled = true;
            gridViewCustomerHistory.OptionsBehavior.Editable = false;
            bindingNavigator.Enabled = true;
            bindingNavigator.Visible = true;
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            checkBoxNoAdjLookBack.Visible = false;
            checkBoxNoAdjLookBack.Enabled = false;
        }

        private void SetEditMode()
        {
            Text = "Closed Payments (EDIT Mode)";
            txtCheckValue.ReadOnly = false;
            lookUpEditPaymentType.Enabled = true;
            lookUpEditCodeType.Enabled = true;
            EFTtextBox.ReadOnly = false;
            listBoxTSBCommentCode.Enabled = true;
            txtOverPayment.ReadOnly = false;
            txtIncome.ReadOnly = false;
            PaidThroughUDtextBox.ReadOnly = false;
            cOMMENTDataGridView.Enabled = true;
            cOMMENTgridView.OptionsBehavior.Editable = true;
            cUSTHISTDataGridView.Enabled = true;
            gridViewCustomerHistory.OptionsBehavior.Editable = false;
            toolStripButtonAdd.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            lbAddFlag = false;
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = false;
            setRelatedData();
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            checkBoxNoAdjLookBack.Visible = true;
            checkBoxNoAdjLookBack.Enabled = true;
            ActiveControl = txtCheckValue;
            txtCheckValue.SelectAll();
        }

        private void SetAddMode()
        {

            Text = "Closed Payments (ADD Mode)";
            txtCheckValue.ReadOnly = false;
            lookUpEditPaymentType.Enabled = true;
            lookUpEditCodeType.Enabled = true;
            EFTtextBox.ReadOnly = false;
            listBoxTSBCommentCode.Enabled = true;
            txtOverPayment.ReadOnly = false;
            txtIncome.ReadOnly = false;
            PaidThroughUDtextBox.ReadOnly = false;
            cOMMENTDataGridView.Enabled = true;
            cOMMENTgridView.OptionsBehavior.Editable = true;
            cUSTHISTDataGridView.Enabled = true;
            gridViewCustomerHistory.OptionsBehavior.Editable = false;
            toolStripButtonAdd.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            lbAddFlag = true;
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = false;
            toolStripButtonAdd.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            lbEdit = false;
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = false;
            toolStripButtonCancel.Visible = true;
            toolStripButtonCancel.Enabled = true;
            labelISFDate.Visible = false;
            textBoxISFDate.Visible = false;
            textBoxISFDate.Enabled = false;
            buttonChangeISFDate.Enabled = false;
            buttonChangeISFDate.Visible = false;
            toolStripButtonSave.Enabled = false;
            checkBoxNoAdjLookBack.Visible = true;
            checkBoxNoAdjLookBack.Enabled = true;
            ActiveControl = cUSTOMER_NOTextBox;
            cUSTOMER_NOTextBox.SelectAll();
        }

        private void setRelatedData()
        {
            string lPaidThroughMM, lPaidThroughYY, lPaidThrough;

            // Moses Newman 01/16/2014 Handle wrong balance issue if 1st payment in batch.
            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count != 0)
            {
                PaymentbindingSource.EndEdit();
                if (ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER") == "######")
                    return;
                if (PaymentbindingSource.Position == -1)
                    PaymentbindingSource.MoveFirst();
                if (PaymentbindingSource.Position > -1 && cUSTOMER_NOTextBox.EditValue.ToString().Trim().Length != 6)
                    cUSTOMER_NOTextBox.EditValue = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");
            }
            try
            {
                cUSTHISTTableAdapter.FillByCustomerNo(ClosedPaymentiacDataSet.CUSTHIST, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                cOMMENTTableAdapter.FillByCustNo(ClosedPaymentiacDataSet.COMMENT, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
            }
            catch
            {
            }

            gnCustomerBalance = 0;
            gnCustomerBuyout = 0;

            if (cUSTOMER_NOTextBox.EditValue.ToString().Trim().Length > 0)
                cUSTOMERTableAdapter.Fill(ClosedPaymentiacDataSet.CUSTOMER, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
            if (ClosedPaymentiacDataSet.CUSTOMER.Rows.Count > 0)
            {
                lPaidThroughMM = ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_PAID_THRU_MM");
                lPaidThroughYY = ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_PAID_THRU_YY");
                lPaidThrough = lPaidThroughMM.TrimEnd() + '/' + lPaidThroughYY.TrimEnd();
                txtPaidThrough.Text = lPaidThrough;
                dEALERTableAdapter.Fill(ClosedPaymentiacDataSet.DEALER,Convert.ToInt32(DealertextBox.Text));
                comment_TypesTableAdapter.Fill(ClosedPaymentiacDataSet.Comment_Types);
                PaymentbindingSource.EndEdit();
                // Moses Newman 08/02/2013 Save CUSTOMER_BALANCE so maintenance can NOT ALTER IT even though we display the current balance only posting routines may recalculate it and write the data.
                if (ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_BALANCE") != null)
                {
                    gnCustomerBalance = ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BALANCE");
                }
                else
                    gnCustomerBalance = 0;
                if (ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_BUYOUT") != null)
                {
                    gnCustomerBuyout = ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BUYOUT");
                }
                else
                    gnCustomerBuyout = ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BALANCE");
                if (gnCustomerBalance != 0)
                    ClosedPaymentiacDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_BALANCE", Program.TVSimpleGetBuyout(ClosedPaymentiacDataSet,
                                               DateTime.Now.Date,
                                               (Double)ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM"),
                                               (Double)(ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                               (Double)ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                               ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"),
                                               // 04/30/2017 Handle BOTH Simple Interest and Normal Daily Compounding
                                               ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true:false, true, false, false, -1, true));
                if (gnCustomerBuyout != 0)
                    ClosedPaymentiacDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_BUYOUT", Program.TVSimpleGetBuyout(ClosedPaymentiacDataSet,
                                                DateTime.Now.Date,
                                                (Double)ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM"),
                                                (Double)(ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                                (Double)ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                                ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"),
                                                // 04/30/2017 Handle BOTH Simple Interest and Normal Daily Compounding
                                                ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, true, true, false));
                if (PaymentbindingSource.Position > -1)
                {
                    if (ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_TYPE") == "I")
                    {
                        if (lbAddFlag || lbEdit)
                        {
                            buttonChangeISFDate.Visible = true;
                            buttonChangeISFDate.Enabled = true;
                            labelISFDate.Visible = true;
                            textBoxISFDate.Visible = true;
                            textBoxISFDate.Enabled = true;
                        }
                        else
                        {
                            buttonChangeISFDate.Visible = false;
                            buttonChangeISFDate.Enabled = false;
                            labelISFDate.Visible = true;
                            textBoxISFDate.Visible = true;
                            textBoxISFDate.Enabled = false;
                        }
                    }
                    else
                    {
                        buttonChangeISFDate.Visible = false;
                        buttonChangeISFDate.Enabled = false;
                        labelISFDate.Visible = false;
                        textBoxISFDate.Visible = false;
                        textBoxISFDate.Enabled = false;
                    }
                }
            }
            else
                return;
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
                if (ActiveControl == cUSTOMER_NOTextBox)
                    return;
                toolStripButtonSave.Enabled = true;
            }
        }

        private void cUSTOMER_NOTextBox_Validated(object sender, EventArgs e)
        {
            int lnPaymentPos = 0;
            String lsCustNo = "";

            // Moses Newman 10/16/2022
            if (cUSTOMER_NOTextBox.EditValue == null)
                return;
            if (lbFormClosing || cUSTOMER_NOTextBox.EditValue.ToString().Trim() == "" || lbEdit)
                return;

            if (cUSTOMER_NOTextBox.EditValue.ToString().Trim().Length < 6 && cUSTOMER_NOTextBox.EditValue.ToString().Trim().Length > 0)
                cUSTOMER_NOTextBox.EditValue = cUSTOMER_NOTextBox.EditValue.ToString().Trim().PadLeft(6, '0');

            lsCustNo = cUSTOMER_NOTextBox.EditValue.ToString().Trim();

            paymentTableAdapter.FillByAll(ClosedPaymentiacDataSet.PAYMENT);

            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count != 0)
            {
                lnPaymentPos = PaymentbindingSource.Find("PAYMENT_CUSTOMER", lsCustNo);
                if (lnPaymentPos > -1)
                {
                    if (!lbAddFlag)
                        PaymentbindingSource.Position = lnPaymentPos;
                    else
                    {
                        // Moses Newman 08/29/2018 Notify that there is at least one more payment already for this customer.
                        DialogResult Answer;
                        Answer = MessageBox.Show("*** There already is a payment for this customer.\n       Do you want to add another? ***",
                                        "Closed Payment Entry Duplicate", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (Answer != DialogResult.Yes)
                        {
                            toolStripButtonAdd_Click(sender, e);
                            return;
                        }
                    }
                }
                else
                {
                    if (!lbAddFlag)
                    {
                        lsCustNo = ClosedPaymentiacDataSet.PAYMENT.Rows[0].Field<String>("PAYMENT_CUSTOMER");
                        PaymentbindingSource.MoveFirst();
                    }
                }
            }
            else
            {
                if (!lbAddFlag)
                {
                    return;
                }
            }
            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count != 0 || lbAddFlag)
            {
                setRelatedData();
                if (lbAddFlag && ClosedPaymentiacDataSet.CUSTOMER.Rows.Count == 0 && cUSTOMER_NOTextBox.EditValue.ToString().Trim().Length != 0)
                {
                    cUSTOMERTableAdapter.Fill(ClosedPaymentiacDataSet.CUSTOMER, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                }
                if (ClosedPaymentiacDataSet.CUSTOMER.Rows.Count > 0 && lbAddFlag) // Moses Newman 10/26/2021 no more payments to Inactive accounts!
                    if (ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_ACT_STAT") == "I")
                    {
                        MessageBox.Show("*** SORRY ACCOUNT: " + cUSTOMER_NOTextBox.EditValue.ToString().Trim() + " " + ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_FIRST_NAME").Trim() + " " + ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_LAST_NAME").Trim() + " IS INACTIVE! ***");
                        ClosedPaymentiacDataSet.CUSTOMER.Clear();
                        cUSTOMER_NOTextBox.EditValue = "";
                        setRelatedData();
                        ActiveControl = cUSTOMER_NOTextBox;
                        cUSTOMER_NOTextBox.Select();
                        return;
                    }
            }
            if (ClosedPaymentiacDataSet.CUSTOMER.Rows.Count == 0 && cUSTOMER_NOTextBox.EditValue.ToString().Trim().Length != 0)
            {
                MessageBox.Show("Sorry no customers found that match your selected account number!");
                cUSTOMER_NOTextBox.EditValue = "";
                ActiveControl = cUSTOMER_NOTextBox;
                cUSTOMER_NOTextBox.Select();
            }
            else
            {
                // Moses Newman 05/12/2015 Reactivate handling of inactive ISFs ONLY!!!
                /*if (ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_ACT_STAT") != "A"
                    && ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_TYPE") != "I")
                {
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_TYPE", "I");
                    //MessageBox.Show("Sorry but customer must be active or payment must be an INSUF to post!");
                    //cUSTOMER_NOTextBox.EditValue = "";
                    //toolStripButtonAdd_Click(sender, e);
                    //return;
                }*/
                if (lbEdit)
                    if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count == 0)
                    {
                        MessageBox.Show("Sorry no existing payments found!");
                        ActiveControl = cUSTOMER_NOTextBox;
                        cUSTOMER_NOTextBox.Select();
                    }
                if (lbAddFlag && cUSTOMER_NOTextBox.EditValue.ToString().Trim() != "")
                {
                    PaymentbindingSource.AddNew();
                    PaymentbindingSource.EndEdit();

                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_CUSTOMER", cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_ADD_ON", " ");
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "C");
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<DateTime>("PAYMENT_DATE", DateTime.Now.Date);
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_POST_INDICATOR", " ");
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<Int32>("PAYMENT_DEALER", ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_TYPE", "R");
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_CODE_2", "N");
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_AUTO_PAY", ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AUTOPAY"));
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_TSB_COMMENT_CODE", ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_TSB_COMMENT_CODE"));
                    EFTtextBox.Text = ClosedPaymentiacDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AUTOPAY");

                    if (ClosedPaymentiacDataSet.CUSTOMER.Rows.Count != 0)
                    {
                        toolStripButtonSave.Enabled = true;
                    }
                }
                if (lbAddFlag || lbEdit)
                {
                    ActiveControl = txtCheckValue;
                    txtCheckValue.SelectAll();
                }
            }
        }

        private void txtCheckValue_Validated(object sender, EventArgs e)
        {
            Decimal lnOverPay = 0, lnIncome = 0,lnCheckValue = 0, lnBalance = 0;
            if (!lbEdit && !lbAddFlag)
                return;
            //if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count > 0)
               // ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].EndEdit();
            if (txtCheckValue.Text.ToString().TrimStart().Length > 0)
                Decimal.TryParse(txtCheckValue.Text,System.Globalization.NumberStyles.Currency,System.Globalization.CultureInfo.CreateSpecificCulture("en-US"),out lnCheckValue);
            else
                lnCheckValue = 0;
            if (txtBuyout.Text.ToString().TrimStart().Length > 0)
                Decimal.TryParse(txtBuyout.Text,System.Globalization.NumberStyles.Currency,System.Globalization.CultureInfo.CreateSpecificCulture("en-US"),out lnBalance);
            if (txtLoanBalance.Text.ToString().TrimStart().Length > 0)
                Decimal.TryParse(txtLoanBalance.Text,System.Globalization.NumberStyles.Currency,System.Globalization.CultureInfo.CreateSpecificCulture("en-US"),out lnBalance);
            else
                lnBalance = 0;

            if(PaymentbindingSource.Position > -1)
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<Decimal>("PAYMENT_AMOUNT_RCV", lnCheckValue);
            PaymentbindingSource.EndEdit();

            if (lnCheckValue > lnBalance && (lbEdit || lbAddFlag)) 
            {
                // 
                // labelOverPayment
                // 
                lnOverPay = lnCheckValue - lnBalance;
                lnIncome = 0;
                labelOverPayment.Visible = true;
                txtOverPayment.Enabled = false;
                txtOverPayment.Visible = true;
                txtOverPayment.Text = lnOverPay.ToString("C", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
                txtIncome.Text = "";
                txtIncome.Enabled = false;
                txtIncome.Visible = false;
            }
            else
                // Moses Newman 08/14/2013 NOT AN OVERPAYMENT UNLESS CHECK IS GREATER THAN THE BALANCE.
                if (lnCheckValue > lnBalance && (lbEdit || lbAddFlag))
                {
                    // 
                    // lblIncome
                    // 
                    lnOverPay = lnCheckValue - lnBalance;
                    lnIncome = lnBalance;
                    labelOverPayment.Visible = true;
                    lblIncome.Visible = true;
                    txtOverPayment.Enabled = false;
                    txtOverPayment.Visible = true;
                    txtOverPayment.Text = lnOverPay.ToString("C", new System.Globalization.CultureInfo("en-US"));
                    txtIncome.Enabled = false;
                    txtIncome.Visible = true;
                    txtIncome.Text = lnIncome.ToString("C", new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    lnIncome = 0;
                    lnOverPay = 0;
                    labelOverPayment.Visible = false;
                    lblIncome.Visible = false;
                    txtOverPayment.Text = "";
                    txtOverPayment.Enabled = false;
                    txtOverPayment.Visible = false;
                    txtIncome.Text = "";
                    txtIncome.Enabled = false;
                    txtIncome.Visible = false;
                }
        }

        private void PaidThroughtextBox_Validated(object sender, EventArgs e)
        {
            ActiveControl = lookUpEditCodeType;
            lookUpEditCodeType.SelectAll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmCustomerLookup form2inst;

            Visible = false;
            form2inst = new frmCustomerLookup();
            form2inst.ShowDialog();
            form2inst.Dispose();
            Visible = true;
            if (Program.gsKey != null)
            {
                cUSTOMER_NOTextBox.EditValue = Program.gsKey;
                System.Windows.Forms.SendKeys.Send("{TAB}");
                Program.gsKey = null;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            String lsCustomerNo = "";
            Object[] Keys = new Object[2];

            PaymentbindingSource.EndEdit();

            Validate();  //Validate form so all data sets are updated with field values
            lsCustomerNo = cUSTOMER_NOTextBox.EditValue.ToString().Trim();
            if (ClosedPaymentiacDataSet.CUSTOMER.Rows.Count == 0)
                return;
            tableAdapConn = new Microsoft.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            paymentTableAdapter.Connection = tableAdapConn;
            tableAdapTran = paymentTableAdapter.BeginTransaction();
            paymentTableAdapter.Transaction = tableAdapTran;
            ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "C");
            
            PaymentbindingSource.EndEdit();
            // Moses Newman 08/09/2022 if PAYMENT DATE is NULL for any reason default to now!
            if (ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime?>("PAYMENT_DATE") == null)
            {
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<DateTime>("PAYMENT_DATE", DateTime.Now.Date);
                PaymentbindingSource.EndEdit();
            }
            try
            {
                paymentTableAdapter.Update(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position]);
                //Program.UpdateComments(ref ClosedPaymentiacDataSet, ref cOMMENTBindingSource, true);
                tableAdapTran.Commit();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("There is a Microsoft SQL Server database error: " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("Error: " + ex.Message.ToString());
            }

            finally
            {
                ClosedPaymentiacDataSet.AcceptChanges();
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                toolStripButtonEdit.Enabled = true;
                toolStripButtonAdd.Enabled = true;
                toolStripButtonDelete.Enabled = true;
                lbNewPayment = false;
                if (lbAddFlag)
                {
                    lbJustSaved = true;
                    PaymentTypebindingSource.Position = PaymentbindingSource.Find("PAYMENT_CUSTOMER", lsCustomerNo);
                    toolStripButtonAdd_Click(sender, e);
                    toolStripButtonAdd.Enabled = false;
                    toolStripButtonEdit.Enabled = false;
                    toolStripButtonDelete.Enabled = true;
                }
                if (lbEdit)
                {
                    lbJustSaved = true;
                    lbEdit = false;
                    SetViewMode();
                }
            }
        }

        private void PaymentbindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (lbJustSaved || PaymentbindingSource.Position == -1)
            {
                lbJustSaved = false;
                return;
            }
            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count > 0)
            {
                if (!lbAddFlag && !lbEdit && bindingNavigator.Visible)
                {
                    cUSTOMER_NOTextBox.EditValue = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");
                }
                setRelatedData();
                ActiveControl = cUSTOMER_NOTextBox;
                cUSTOMER_NOTextBox.SelectAll();
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            cUSTOMER_NOTextBox.EditValue = "";
            lbEdit = false;
            lbAddFlag = true;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonAdd.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = false;
            Text = "Closed Payments (ADD Mode)";
            ClosedPaymentiacDataSet.PAYMENT.Clear();
            ClosedPaymentiacDataSet.CUSTOMER.Clear();
            ClosedPaymentiacDataSet.CUSTHIST.Clear();
            ClosedPaymentiacDataSet.COMMENT.Clear();
            ClosedPaymentiacDataSet.DEALER.Clear();
            txtPaidThrough.Text = "";
            SetAddMode();
            txtLoanBalance.Text = "";
            txtPaidThrough.Text = "";
            txtPaymentDate.Text = "";
            txtCheckValue.Text = "";
            txtPaymentDate.Text = "";
            txtIncome.Visible = false;
            txtOverPayment.Visible = false;
            lblIncome.Visible = false;
            labelOverPayment.Visible = false;


            ActiveControl = cUSTOMER_NOTextBox;
            cUSTOMER_NOTextBox.SelectAll();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            lbEdit = true;
            LockPaymentRecord();
            if (lbEdit)
                SetEditMode();
            else
                Refresh();        
        }

        private void LockPaymentRecord()
        {
            if (PaymentbindingSource.Position == -1)
                return;

            Object loLockedBy = paymentTableAdapter.LockedBy(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo")),
            loLockedTime = paymentTableAdapter.LockTime(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo"));

            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(ClosedPaymentiacDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** PAYMENT: " + cUSTOMER_NOTextBox.EditValue.ToString().Trim() + " WAS LOCKED BY USER: " +
                    loLockedBy + " " +
                    ClosedPaymentiacDataSet.ULIST.Rows[0].Field<String>("LIST_NAME") +
                    "\nON: " + ((DateTime)loLockedTime).ToLongDateString() + " " +
                    ((DateTime)loLockedTime).ToLongTimeString() + "\n" +
                    "YOU MUST WAIT UNTIL THEY RELEASE IT! ***", "RECORD LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripButtonSave.Enabled = false;
                ULISTTableAdapter.Dispose();
                loLockedBy = null;
                lbEdit = false;
                ClosedPaymentiacDataSet.Clear();
                StartUpConfiguration();
            }
            else
            {
                paymentTableAdapter.LockRecord(Program.gsUserID, ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo"));
                lbILockedIt = true;   //  Make sure other instances of form don't unlocke this record!
            }
        }

        private void cOMMENTDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            object loQuery = null;
            e.Row.Cells["ID"].Value = Program.gsUserID.TrimEnd();
            e.Row.Cells["Date"].Value = DateTime.Now;
            e.Row.Cells["COMMENT_NO"].Value = txtCommentNo.Text.ToString().TrimEnd();
            e.Row.Cells["COMMENT_HHMMSS"].Value = DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
            if (lnSeq == 0)
            {
                loQuery = cOMMENTTableAdapter.SeqNoQuery(txtCommentNo.Text.ToString().TrimEnd(), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq++;
        }

        private void cOMMENTDataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            toolStripButtonSave.Enabled = true;
        }

        private void cOMMENTDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            toolStripButtonSave.Enabled = true;
        }

        private void cOMMENTDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButtonSave.Enabled = true;
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {

            lbJustSaved = false;
            lbAddFlag = false;
            lbEdit = false;
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            if (lbNewPayment)
            {
                // Moses Newman 05/24/2022 c776edd8140d472b8891363108fc6168
                if (PaymentbindingSource.Position > -1 && PaymentbindingSource.Position < ClosedPaymentiacDataSet.PAYMENT.Rows.Count)
                {
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].CancelEdit();
                    PaymentbindingSource.RemoveCurrent();
                }
                lbNewPayment = false;
            }
            cUSTOMER_NOTextBox.EditValue = "";
            txtPaidThrough.Text = "";
            txtLoanBalance.Text = "";
            txtPaidThrough.Text = "";
            txtPaymentDate.Text = "";
            txtCheckValue.Text = "";
            txtPaymentDate.Text = "";

            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count > 0)
                ClosedPaymentiacDataSet.PAYMENT.Clear();
            paymentTableAdapter.FillByAll(ClosedPaymentiacDataSet.PAYMENT);
            PaymentbindingSource.MoveFirst();
            toolStripButtonAdd.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripButtonSave.Enabled = false;
            bindingNavigator.Enabled = true;
            bindingNavigator.Visible = true;
            txtCheckValue.Refresh();
            SetViewMode();
        }

        private void formClosedPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = paymentTableAdapter.LockedBy(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    paymentTableAdapter.UnlockRecord(ClosedPaymentiacDataSet.PAYMENT.Rows[0].Field<String>("PAYMENT_CUSTOMER"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo"));
            }
        }

        private void PaymentbindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            lbNewPayment = true;
        }

        private void lookUpEditPaymentType_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUpEdit = sender as LookUpEdit;

            if (!lbEdit & !lbAddFlag)
            {
                ClosedPaymentiacDataSet.PAYCODE.Clear();
                pAYCODETableAdapter.FillByType(ClosedPaymentiacDataSet.PAYCODE, "*");
                PAYCODEbindingSource.DataSource = ClosedPaymentiacDataSet.PAYCODE;
                return;
            }
            ClosedPaymentiacDataSet.PAYCODE.Clear();
            pAYCODETableAdapter.FillByType(ClosedPaymentiacDataSet.PAYCODE, lookUpEdit.EditValue.ToString());
            PAYCODEbindingSource.DataSource = ClosedPaymentiacDataSet.PAYCODE;
            PAYCODEbindingSource.MoveFirst();
            lookUpEditCodeType.EditValue = ClosedPaymentiacDataSet.PAYCODE.Rows[0].Field<String>("Code");
            lookUpEditCodeType.Refresh();
            toolStripButtonSave.Enabled = true;
        }

        private void lookUpEditPaymentType_Validated(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty((String)lookUpEditPaymentType.EditValue))
                return;
            if ((String)lookUpEditPaymentType.EditValue == "E")
            {
                lblPaidThrough.Enabled = true;
                lblPaidThrough.Visible = true;
                PaidThroughUDtextBox.Enabled = true;
                PaidThroughUDtextBox.Visible = true;
                ActiveControl = PaidThroughUDtextBox;
                PaidThroughUDtextBox.SelectAll();
            }
            else
            {
                lblPaidThrough.Enabled = false;
                lblPaidThrough.Visible = false;
                PaidThroughUDtextBox.Enabled = false;
                PaidThroughUDtextBox.Visible = false;
                // Moses Newman 04/13/2021 Fill Paycodes
                pAYCODETableAdapter.FillByType(ClosedPaymentiacDataSet.PAYCODE, (String)lookUpEditPaymentType.EditValue);
                // Moses Newman 04/28/2021 don't default code if one exists in payment already!
                if (ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CODE_2") == null || ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CODE_2") == "")
                {
                    switch ((String)lookUpEditPaymentType.EditValue)
                    {
                        // Moses Newman 04/13/2021 Default to first record in list
                        case "B":
                            lookUpEditCodeType.EditValue = "G";
                            break;
                        case "W":
                            lookUpEditCodeType.EditValue = "H";
                            break;
                        default:
                            lookUpEditCodeType.EditValue = " ";
                            break;
                    }
                }
                lookUpEditCodeType.Refresh();
                PAYCODEbindingSource.DataSource = ClosedPaymentiacDataSet.PAYCODE;
                if (lbEdit || lbAddFlag)
                {
                    ActiveControl = lookUpEditCodeType;
                    lookUpEditCodeType.SelectAll();
                }
            }
        }

        private void cOMMENTgridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "colThumb" && e.IsGetData)
                e.Value = getWordImage(view, e.ListSourceRowIndex);
        }

        // Return the WordImage for a specific row.
        private Bitmap getWordImage(GridView view, int listSourceRowIndex)
        {
            Bitmap img;
            img = new Bitmap(IAC2021SQL.Properties.Resources.WordDoc);
            if (!String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath"))) || !String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "SMSPath"))))
                return img;
            else
                return null;
        }

        private void cOMMENTgridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void cOMMENTgridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;

            object loQuery = null;
            view.SetRowCellValue(e.RowHandle, "COMMENT_USERID", Program.gsUserID.TrimEnd());
            view.SetRowCellValue(e.RowHandle, "COMMENT_DATE", DateTime.Now.Date);
            view.SetRowCellValue(e.RowHandle, "COMMENT_NO", txtCommentNo.Text.ToString().TrimEnd());
            view.SetRowCellValue(e.RowHandle, "COMMENT_HHMMSS",
                DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'));
            if (lnSeq == 0)
            {
                loQuery = cOMMENTTableAdapter.SeqNoQuery(txtCommentNo.Text.ToString().TrimEnd(), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;
            view.SetRowCellValue(e.RowHandle, "COMMENT_SEQ_NO", lnSeq);
            view.SetRowCellValue(e.RowHandle, "COMMENT_DEALER", Convert.ToInt32(DealertextBox.Text));
        }

        private void cOMMENTgridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && (lbEdit || lbAddFlag))
            {
                if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                GridView view = sender as GridView;
                view.DeleteRow(view.FocusedRowHandle);
                toolStripButtonSave.Enabled = true;
            }
        }

        private void cOMMENTgridView_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "colThumb")
            {
                String lsPath = getPath(view, view.GetDataSourceRowIndex(e.RowHandle));
                // If the LetterPath field is not empty open the word document.
                if (!String.IsNullOrEmpty(lsPath))
                {

                    if (System.IO.File.Exists(lsPath))
                    {
                        Word._Application application = new Word.Application();
                        Word._Document document = application.Documents.Open(lsPath);
                        // Old method to open using windows default editor for filetype.
                        //System.Diagnostics.Process.Start(lsPath);
                        document.Activate();
                        application.Visible = true;
                    }
                    else
                        MessageBox.Show("The document: " + lsPath + " seems to be missing!",
                                        "Specified Document Missing");
                }
            }
        }

        // Return the Path for a specific row.
        private String getPath(GridView view, int listSourceRowIndex)
        {
            return !String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath"))) ?
                    Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath")) :
                    Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "SMSPath"));
        }

        private void tabClosedPayments_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (tabClosedPayments.SelectedTabPageIndex)
            {
                case 2:
                    // Moses Newman 12/1/2021 order by id descending
                    GridColumn colID = cOMMENTgridView.Columns["id"];
                    cOMMENTgridView.BeginSort();
                    try
                    {
                        cOMMENTgridView.ClearSorting();
                        // Moses Newman 12/1/2021 order by id descending
                        colID.SortOrder = ColumnSortOrder.Descending;
                    }
                    finally
                    {
                        cOMMENTgridView.EndSort();
                    }
                    break;
            }
        }

        private void lookUpEditCodeType_Enter(object sender, EventArgs e)
        {
            HandleISF();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            tableAdapConn = new Microsoft.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            paymentTableAdapter.Connection = tableAdapConn;
            tableAdapTran = paymentTableAdapter.BeginTransaction();
            paymentTableAdapter.Transaction = tableAdapTran;
            try
            {
                paymentTableAdapter.Delete(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE").Date, ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo"));
                tableAdapTran.Commit();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("This record is in use by someone else, you must wait until they release it to make your changes " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("Error: " + ex.Message.ToString());
            }

            finally
            {
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonEdit.Enabled = false;
                Program.gsKey = null;
                paymentTableAdapter.FillByAll(ClosedPaymentiacDataSet.PAYMENT);
                if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count > 1)
                {
                    PaymentbindingSource.MoveFirst();
                }
                else
                {
                    cUSTOMER_NOTextBox.EditValue = "";
                    txtPaidThrough.Text = "";
                }
                if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count > 0)
                {
                    toolStripButtonDelete.Enabled = true;
                    toolStripButtonEdit.Enabled = true;
                    toolStripButtonSave.Enabled = false;
                }
                else
                {
                    toolStripButtonDelete.Enabled = false;
                    toolStripButtonEdit.Enabled = false;
                    toolStripButtonSave.Enabled = false;
                }
                lbEdit = false;
                lbAddFlag = false;
                lbJustSaved = false;
            }
        }

        private void EFTtextBox_Enter(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
            {
                return;
            }
        }

        private void toolStripButtonSave_EnabledChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbEdit && !lbAddFlag)
                toolStripButtonSave.Enabled = false;
        }

        private void SelectCheck()
        {
            FormSelectCheck frmSelectCheckInst;
            frmSelectCheckInst = new FormSelectCheck(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), true, (String)lookUpEditPaymentType.EditValue);
            if (!frmSelectCheckInst.DoNotShow)
            {
                frmSelectCheckInst.ShowDialog();
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<DateTime>("PAYMENT_ISF_DATE", frmSelectCheckInst.ldISFDate);
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<Decimal>("PAYMENT_CURR_INT", frmSelectCheckInst.lnCurrInt);
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<Decimal>("PAYMENT_LATE_CHARGE_PAID", frmSelectCheckInst.lnLateChargePaid);
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<Boolean>("IsSimple", frmSelectCheckInst.lbIsSimple);
                // Moses Newman 04/13/2018 Add ISFSeqNo, ISFPaymentType, and ISFPaymentCode so that excact reversed payment can be found.
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<Int32>("ISFSeqNo", frmSelectCheckInst.ISFSeqNo);
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("ISFPaymentType", frmSelectCheckInst.ISFPaymentType);
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("ISFPaymentCode", frmSelectCheckInst.ISFPaymentCode);
                // Moses Newman 10/10/2020
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<Int32>("ISFID", frmSelectCheckInst.ISFID);
                PaymentbindingSource.EndEdit();
            }
            else
            {
                ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<DateTime?>("PAYMENT_ISF_DATE", null);
            }
            frmSelectCheckInst.Dispose();
        }

        private void HandleISF()
        {
            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count < 1 || PaymentbindingSource.Position < 0)
                return;
            PaymentbindingSource.EndEdit();
            if ((String)lookUpEditPaymentType.EditValue != "I" && ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Decimal>("PAYMENT_AMOUNT_RCV") >= 0)
            {
                if (lbAddFlag || lbEdit)
                    if (ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") != null)
                    {
                        ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<Nullable<DateTime>>("PAYMENT_ISF_DATE", null);
                        PaymentbindingSource.EndEdit();
                    }
                buttonChangeISFDate.Visible = false;
                textBoxISFDate.Visible = false;
                labelISFDate.Visible = false;
                return;
            }
            else
            {
                if (ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") != null)
                {
                    buttonChangeISFDate.Visible = true;
                    if (lbAddFlag || lbEdit)
                        buttonChangeISFDate.Enabled = true;
                    else
                        buttonChangeISFDate.Enabled = false;
                }
                else
                    buttonChangeISFDate.Visible = false;
                labelISFDate.Visible = true;
                textBoxISFDate.Visible = true;
            }

            if (!lbAddFlag && !lbEdit)
                return;
            if (ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") == null)
            {
                SelectCheck();
            } 
            return;
        }

        private void buttonChangeISFDate_Click(object sender, EventArgs e)
        {
            SelectCheck();
            if (lbEdit || lbAddFlag)
                toolStripButtonSave.Enabled = true;
        }

        private void PaymentTypetextBox_TextChanged(object sender, EventArgs e)
        {
            // Moses Newman 04/17/2018 Move lnCheckValue population above exit check since now ANY negative payment triggers selectcheck.
            Decimal lnCheckValue = 0;
            Decimal.TryParse(txtCheckValue.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), out lnCheckValue);
            if(!lbAddFlag && !lbEdit)
                return;
            if(lookUpEditPaymentType.EditValue.ToString() != "I" && lnCheckValue >= 0) 
                return;
            // Moses Newman 04/29/2018 Do not call select check if payment is ADJ and checkboxNoAdjLookBack is checked!
            if (lnCheckValue < 0 && lookUpEditPaymentType.EditValue.ToString() == "A" && checkBoxNoAdjLookBack.Checked)
                return;
            PaymentbindingSource.EndEdit(); 
            if (PaymentbindingSource.Position > -1)
            {
                if (lnCheckValue > 0)
                {
                    lnCheckValue *= -1;
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_TYPE", "I");
                    txtCheckValue.Text = lnCheckValue.ToString().TrimStart();
                    PaymentbindingSource.EndEdit();               
                }
                else
                {
                    ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_TYPE", lookUpEditPaymentType.EditValue.ToString());
                    PaymentbindingSource.EndEdit();
                }
            }
        }

        private void listBoxTSBCommentCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        // Moses Newman 06/15/2015 User Draw TSB listbox so that it can be 3 lines wide PER ITEM!
        private void listBoxTSBCommentCode_DrawItem(object sender, DrawItemEventArgs e)
        {
            DataRowView TSBDataRow;

            if (e.Index == -1)
                return;
            TSBDataRow = (DataRowView)listBoxTSBCommentCode.Items[e.Index];
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
            }
            if (lbAddFlag || lbEdit)
                e.Graphics.DrawString(TSBDataRow["Description"].ToString(), e.Font, new SolidBrush(Color.Black), e.Bounds);
            else
                e.Graphics.DrawString(TSBDataRow["Description"].ToString(), e.Font, SystemBrushes.InfoText, e.Bounds);
        }
    }
}
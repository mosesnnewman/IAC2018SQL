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
    public partial class formOpenPayment : Form
    {
        System.Windows.Forms.Label labelOverPayment, lblIncome, lblPaidThrough, labelISFDate;

        private Microsoft.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private Microsoft.Data.SqlClient.SqlConnection tableAdapConn = null;

        private Boolean lbAddFlag = false, lbEdit = false, lbFormClosing = false, lbNewPayment = false, lbILockedIt = false, lbJustSaved = false;

        private DataGridViewComboBoxEditingControl editingControl;

        private int lnSeq = 0;

        public formOpenPayment()
        {
            InitializeComponent();
        }

        private void formOpenPayment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'OpenPaymentiacDataSet.SpecialCommentCodes' table. You can move, or remove it, as needed.
            this.specialCommentCodesTableAdapter.Fill(this.OpenPaymentiacDataSet.SpecialCommentCodes);
            pAYCODETableAdapter.Fill(OpenPaymentiacDataSet.PAYCODE);
            pAYMENTTYPETableAdapter.Fill(OpenPaymentiacDataSet.PAYMENTTYPE);
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
            lblIncome.Location = new System.Drawing.Point(331, 78);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new System.Drawing.Size(52, 13);
            lblIncome.TabIndex = 152;
            lblIncome.Text = "INCOME:";
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

            DataGridViewRow row = cOMMENTDataGridView.RowTemplate;
            row.Height = 45;
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.Bisque : Color.White;
            row.MinimumHeight = 20;

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
            PaymentTypetextBox.Text = "R";
            CodeTypetextBox.Text = "N";
            PAYCODEcomboBox.Text = "NONE";
            EFTtextBox.Text = "N";
            txtPaymentDate.Text = DateTime.Today.ToShortDateString();
            labelOverPayment.Visible = false;
            labelOverPayment.Enabled = true;

            lblIncome.Visible = false;
            lblIncome.Enabled = true;

            lblPaidThrough.Visible = false;
            lblPaidThrough.Enabled = true;

            PaymentTypecomboBox.Text = "";

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
            PaymentTypetextBox.ReadOnly = true;
            PaymentTypecomboBox.Enabled = false;
            CodeTypetextBox.ReadOnly = true;
            PAYCODEcomboBox.Enabled = false;
            EFTtextBox.ReadOnly = true;
            listBoxTSBCommentCode.Enabled = false;
            txtOverPayment.ReadOnly = true;
            txtIncome.ReadOnly = true;
            PaidThroughUDtextBox.ReadOnly = true;
            cOMMENTDataGridView.ReadOnly = true;
            bindingNavigator.Enabled = true;
            bindingNavigator.Visible = true;
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
        }

        private void SetEditMode()
        {
            Text = "Open Payments (EDIT Mode)";
            txtCheckValue.ReadOnly = false;
            PaymentTypetextBox.ReadOnly = false;
            PaymentTypecomboBox.Enabled = true;
            CodeTypetextBox.ReadOnly = false;
            PAYCODEcomboBox.Enabled = true;
            EFTtextBox.ReadOnly = false;
            listBoxTSBCommentCode.Enabled = true;
            txtOverPayment.ReadOnly = false;
            txtIncome.ReadOnly = false;
            PaidThroughUDtextBox.ReadOnly = false;
            cOMMENTDataGridView.ReadOnly = false;
            toolStripButtonAdd.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            lbAddFlag = false;
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = false;
            setRelatedData();
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            ActiveControl = txtCheckValue;
            txtCheckValue.SelectAll();
        }

        private void SetAddMode()
        {

            Text = "Open Payments (ADD Mode)";
            txtCheckValue.ReadOnly = false;
            PaymentTypetextBox.ReadOnly = false;
            PaymentTypecomboBox.Enabled = true;
            CodeTypetextBox.ReadOnly = false;
            PAYCODEcomboBox.Enabled = true;
            EFTtextBox.ReadOnly = false;
            listBoxTSBCommentCode.Enabled = true;
            txtOverPayment.ReadOnly = false;
            txtIncome.ReadOnly = false;
            PaidThroughUDtextBox.ReadOnly = false;
            cOMMENTDataGridView.ReadOnly = false;
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
            ActiveControl = cUSTOMER_NOTextBox;
            cUSTOMER_NOTextBox.SelectAll();
        }

        private void setRelatedData()
        {
            string lPaidThroughMM, lPaidThroughYY, lPaidThrough;
            DataRow FoundRow;

            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count == 0)
                return;
            PaymentbindingSource.EndEdit();
            if (OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER") == "######")
                return;
            if (PaymentbindingSource.Position == -1)
                PaymentbindingSource.MoveFirst();
            if (PaymentbindingSource.Position > -1 && cUSTOMER_NOTextBox.Text.Length != 6)
                cUSTOMER_NOTextBox.Text = OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");

            try
            {
                oPNHCUSTTableAdapter.FillByCustomerNo(OpenPaymentiacDataSet.OPNHCUST, cUSTOMER_NOTextBox.Text.TrimEnd());
                oPNCOMMTableAdapter.FillByCustNo(OpenPaymentiacDataSet.OPNCOMM, cUSTOMER_NOTextBox.Text.TrimEnd());
            }
            catch
            {
            }

            if (cUSTOMER_NOTextBox.Text.ToString().TrimEnd().Length > 0)
                oPNCUSTTableAdapter.Fill(OpenPaymentiacDataSet.OPNCUST, cUSTOMER_NOTextBox.Text.ToString());
            if (OpenPaymentiacDataSet.OPNCUST.Rows.Count > 0)
            {
                lPaidThroughMM = OpenPaymentiacDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PAID_THRU_MM");
                lPaidThroughYY = OpenPaymentiacDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PAID_THRU_YY");
                lPaidThrough = lPaidThroughMM.TrimEnd() + '/' + lPaidThroughYY.TrimEnd();
                txtPaidThrough.Text = lPaidThrough;
                oPNDEALRTableAdapter.Fill(OpenPaymentiacDataSet.OPNDEALR, DealertextBox.Text.ToString().TrimEnd());
                comment_TypesTableAdapter.Fill(OpenPaymentiacDataSet.Comment_Types);
                if (PaymentbindingSource.Position > -1)
                {
                    FoundRow = OpenPaymentiacDataSet.PAYMENTTYPE.FindByTYPE(OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_TYPE"));
                    if (FoundRow != null)
                        PaymentTypecomboBox.Text = FoundRow.Field<String>("Description");
                    if (OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_TYPE") == "I")
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

            if (lbFormClosing || cUSTOMER_NOTextBox.Text.TrimEnd() == "" || lbEdit)
                return;

            if (cUSTOMER_NOTextBox.Text.ToString().Trim().Length < 6 && cUSTOMER_NOTextBox.Text.ToString().Trim().Length > 0)
                cUSTOMER_NOTextBox.Text = cUSTOMER_NOTextBox.Text.PadLeft(6, '0');

            lsCustNo = cUSTOMER_NOTextBox.Text;

            opnpayTableAdapter.FillByAll(OpenPaymentiacDataSet.OPNPAY);
            PaymentbindingSource.DataSource = OpenPaymentiacDataSet.OPNPAY;
            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count != 0)
            {
                lnPaymentPos = PaymentbindingSource.Find("PAYMENT_CUSTOMER", lsCustNo);
                if (lnPaymentPos > -1)
                {
                    if (!lbAddFlag)
                        PaymentbindingSource.Position = lnPaymentPos;
                    else
                    {
                        MessageBox.Show("Warning! This Customer already exists in the payment file.  Only one payment per customer per batch!",
                                        "Open Payment Entry Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        toolStripButtonAdd_Click(sender, e);
                        return;
                    }
                }
                else
                {
                    if (!lbAddFlag)
                    {
                        lsCustNo = OpenPaymentiacDataSet.OPNPAY.Rows[0].Field<String>("PAYMENT_CUSTOMER");
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
            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count != 0 || lbAddFlag)
            {
                setRelatedData();
                if (lbAddFlag && OpenPaymentiacDataSet.OPNCUST.Rows.Count == 0 && cUSTOMER_NOTextBox.Text.ToString().Trim().Length != 0)
                    oPNCUSTTableAdapter.Fill(OpenPaymentiacDataSet.OPNCUST, cUSTOMER_NOTextBox.Text.ToString().Trim());
            }
            if (OpenPaymentiacDataSet.OPNCUST.Rows.Count == 0 && cUSTOMER_NOTextBox.Text.ToString().Trim().Length != 0)
            {
                MessageBox.Show("Sorry no customers found that match your selected account number!");
                cUSTOMER_NOTextBox.Text = "";
                ActiveControl = cUSTOMER_NOTextBox;
                cUSTOMER_NOTextBox.Select();
            }
            else
                if (OpenPaymentiacDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_ACT_STAT") != "A")
                {
                    MessageBox.Show("Sorry but customer must be active in order to make a payment!");
                    cUSTOMER_NOTextBox.Text = "";
                    toolStripButtonAdd_Click(sender, e);
                    return;
                }
                else
                {
                    if (lbEdit)
                        if (OpenPaymentiacDataSet.OPNPAY.Rows.Count == 0)
                        {
                            MessageBox.Show("Sorry no existing payments found!");
                            ActiveControl = cUSTOMER_NOTextBox;
                            cUSTOMER_NOTextBox.Select();
                        }
                    if (lbAddFlag && cUSTOMER_NOTextBox.Text.ToString().TrimEnd() != "")
                    {
                        PaymentbindingSource.AddNew();
                        PaymentbindingSource.EndEdit();

                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_CUSTOMER", cUSTOMER_NOTextBox.Text.ToString());
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_ADD_ON", " ");
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "O");
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<DateTime>("PAYMENT_DATE", DateTime.Now.Date);
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_POST_INDICATOR", " ");
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_DEALER", DealertextBox.Text.ToString().TrimEnd());
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_TYPE", "R");
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_CODE_2", "N");
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_AUTO_PAY", OpenPaymentiacDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_AUTO_PAY"));
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_TSB_COMMENT_CODE", OpenPaymentiacDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_TSB_COMMENT_CODE"));
                        PaymentTypecomboBox.Text = "Regular Payment";
                        CodeTypetextBox.Text = "N";
                        PAYCODEcomboBox.Text = "NONE";
                        EFTtextBox.Text = OpenPaymentiacDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_AUTO_PAY");

                        if (OpenPaymentiacDataSet.OPNCUST.Rows.Count != 0)
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



        private void PaymentTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenPaymentiacDataSet.PAYCODE.Clear();
            if (PaymentTypecomboBox.SelectedIndex > -1)
            {
                PaymentTypetextBox.Text = OpenPaymentiacDataSet.PAYMENTTYPE.Rows[PaymentTypecomboBox.SelectedIndex].Field<String>("TYPE");

                if (lbAddFlag || lbEdit)
                    toolStripButtonSave.Enabled = true;
            }
            if (PaymentTypetextBox.Text.ToString().ToUpper().TrimEnd() == "W")
            {
                if (OpenPaymentiacDataSet.PAYCODE.Rows.Count != 2)
                    pAYCODETableAdapter.FillByCodeW(OpenPaymentiacDataSet.PAYCODE);
            }
            else
            {
                if (OpenPaymentiacDataSet.PAYCODE.Rows.Count == 2)
                    pAYCODETableAdapter.Fill(OpenPaymentiacDataSet.PAYCODE);
            }
            toolStripButtonSave.Enabled = true;
            if (ActiveControl == PaymentTypecomboBox)
            {
                ActiveControl = CodeTypetextBox;
                CodeTypetextBox.SelectAll();
            }
        }


        private void PaymentTypetextBox_Validated(object sender = null, EventArgs e = null)
        {
            if (PaymentTypetextBox.Text.TrimEnd() == "")
                return;
            DataRow FoundRow;
            if (OpenPaymentiacDataSet.PAYMENTTYPE.Rows.Count == 0)
                pAYMENTTYPETableAdapter.Fill(OpenPaymentiacDataSet.PAYMENTTYPE);
            FoundRow = OpenPaymentiacDataSet.PAYMENTTYPE.Rows.Find(PaymentTypetextBox.Text.TrimEnd());

            if (FoundRow == null)
            {
                if (PaymentTypetextBox.Text.ToString().Trim().Length != 0)
                    MessageBox.Show("Incorrect Payment Type entered. Please respecify.");
                if (lbAddFlag || lbEdit)
                {
                    ActiveControl = PaymentTypecomboBox;
                    PaymentTypecomboBox.SelectAll();
                }
            }
            else
            {
                PaymentTypecomboBox.Text = FoundRow.Field<String>("DESCRIPTION");
                if (PaymentTypetextBox.Text.ToString().ToUpper().TrimEnd() == "E")
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
                    if (PaymentTypetextBox.Text.ToString().ToUpper().TrimEnd() == "W")
                        pAYCODETableAdapter.FillByCodeW(OpenPaymentiacDataSet.PAYCODE);
                    else
                        pAYCODETableAdapter.Fill(OpenPaymentiacDataSet.PAYCODE);
                    if (lbEdit || lbAddFlag)
                    {
                        ActiveControl = CodeTypetextBox;
                        CodeTypetextBox.SelectAll();
                    }
                }
            }
        }

        private void txtCheckValue_Validated(object sender, EventArgs e)
        {
            Decimal lnOverPay = 0, lnIncome = 0, lnCheckValue = 0, lnBalance = 0, lnBuyout = 0;
         
            if (!lbEdit && !lbAddFlag)
                return;
            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count > 0)
                OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].EndEdit();
            if (txtCheckValue.Text.ToString().TrimStart().Length > 0)
                Decimal.TryParse(txtCheckValue.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), out lnCheckValue);
            else
                lnCheckValue = 0;
            if (txtLoanBalance.Text.ToString().TrimStart().Length > 0)
                Decimal.TryParse(txtLoanBalance.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), out lnBalance);
            else
                lnBalance = 0;
            if(PaymentbindingSource.Position > -1)
                OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<Decimal>("PAYMENT_AMOUNT_RCV", lnCheckValue);
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
                txtOverPayment.Text = lnOverPay.ToString("C", new System.Globalization.CultureInfo("en-US"));
                txtIncome.Text = "";
                txtIncome.Enabled = false;
                txtIncome.Visible = false;
            }
            else
                if (lnCheckValue >= lnBuyout && (lbEdit || lbAddFlag))
                {
                    // 
                    // lblIncome
                    // 
                    lnOverPay = lnCheckValue - lnBuyout;
                    lnIncome = lnBalance - lnBuyout;
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

        private void PAYCODEcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OpenPaymentiacDataSet.PAYCODE.Rows.Count < 1)
                return;
            if (PAYCODEcomboBox.SelectedIndex > -1)
                CodeTypetextBox.Text = OpenPaymentiacDataSet.PAYCODE.Rows[PAYCODEcomboBox.SelectedIndex].Field<String>("CODE");
            else
            {
                if (PaymentTypetextBox.Text != "W")
                    if (CodeTypetextBox.Text.TrimEnd() == "")
                        CodeTypetextBox.Text = "N";
                    else
                        if (CodeTypetextBox.Text.TrimEnd() != "L" || CodeTypetextBox.Text.TrimEnd() != "H")
                            CodeTypetextBox.Text = "H";
                CodeTypetextBox_Validated();
            }
            if (lbEdit || lbAddFlag)
            {
                ActiveControl = EFTtextBox;
                EFTtextBox.SelectAll();
                toolStripButtonSave.Enabled = true;
            }
        }

        private void CodeTypetextBox_Validated(object sender = null, EventArgs e = null)
        {
            if (OpenPaymentiacDataSet.PAYCODE.Rows.Count < 1 || CodeTypetextBox.Text.TrimEnd() == "")
                return;

            DataRow FoundRow;

            if ((CodeTypetextBox.Text == "H" || CodeTypetextBox.Text == "L") && PaymentTypetextBox.Text != "W")
                PaymentTypetextBox.Text = "W";

            if (PaymentTypetextBox.Text == "W")
            {
                switch (CodeTypetextBox.Text.ToString().TrimEnd())
                {
                    case "L":
                    case "H":
                        break;
                    case "C":
                    default:
                        CodeTypetextBox.Text = "H";
                        break;
                }
            }

            if (PaymentTypetextBox.Text == "W" && OpenPaymentiacDataSet.PAYCODE.Rows.Count != 2)
                pAYCODETableAdapter.FillByCodeW(OpenPaymentiacDataSet.PAYCODE);
            FoundRow = OpenPaymentiacDataSet.PAYCODE.Rows.Find(CodeTypetextBox.Text.ToString().TrimEnd());

            if (FoundRow == null)
            {
                if (CodeTypetextBox.Text.ToString().Trim().Length != 0)
                {
                    MessageBox.Show("Sorry no payment code found that matches your selected payment code!");
                    CodeTypetextBox.Text = "";
                    ActiveControl = PAYCODEcomboBox;
                    CodeTypetextBox.SelectAll();
                }
            }
            else
            {
                PAYCODEcomboBox.Text = FoundRow.Field<String>("DESCRIPTION");
                if (lbEdit || lbAddFlag)
                {
                    ActiveControl = EFTtextBox;
                    EFTtextBox.SelectAll();
                }
            }
            if (lbEdit || lbAddFlag)
                toolStripButtonSave.Enabled = true;
            else
                toolStripButtonSave.Enabled = false;
        }

        private void PaidThroughtextBox_Validated(object sender, EventArgs e)
        {
            ActiveControl = CodeTypetextBox;
            CodeTypetextBox.SelectAll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmOpenCustomerLookup form2inst;

            Visible = false;
            form2inst = new frmOpenCustomerLookup();
            form2inst.ShowDialog();
            form2inst.Dispose();
            Visible = true;
            if (Program.gsKey != null)
            {
                cUSTOMER_NOTextBox.Text = Program.gsKey;
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
            lsCustomerNo = cUSTOMER_NOTextBox.Text.ToString().Trim();
            if (OpenPaymentiacDataSet.OPNCUST.Rows.Count == 0)
                return;
            tableAdapConn = new Microsoft.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            opnpayTableAdapter.Connection = tableAdapConn;
            tableAdapTran = opnpayTableAdapter.BeginTransaction();
            opnpayTableAdapter.Transaction = tableAdapTran;
            OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "O");
            PaymentbindingSource.EndEdit();
            try
            {
                opnpayTableAdapter.Update(OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position]);
                Program.UpdateComments(ref OpenPaymentiacDataSet, ref CommentbindingSource, true);
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
                OpenPaymentiacDataSet.AcceptChanges();
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

        private void cUSTHISTDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in cUSTHISTDataGridView.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;

        }

        private void cOMMENTDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in cOMMENTDataGridView.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void PaymentbindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (lbJustSaved || PaymentbindingSource.Position == -1)
            {
                lbJustSaved = false;
                return;
            }
            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count > 0)
            {
                if (!lbAddFlag && !lbEdit && bindingNavigator.Visible)
                {
                    cUSTOMER_NOTextBox.Text = OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");
                }
                setRelatedData();
                PaymentTypetextBox_Validated(sender, e);
                CodeTypetextBox_Validated(sender, e);
                ActiveControl = cUSTOMER_NOTextBox;
                cUSTOMER_NOTextBox.SelectAll();
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            cUSTOMER_NOTextBox.Text = "";
            lbEdit = false;
            lbAddFlag = true;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonAdd.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = false;
            Text = "Open Payments (ADD Mode)";
            OpenPaymentiacDataSet.OPNPAY.Clear();
            OpenPaymentiacDataSet.OPNCUST.Clear();
            OpenPaymentiacDataSet.OPNHCUST.Clear();
            OpenPaymentiacDataSet.OPNCOMM.Clear();
            OpenPaymentiacDataSet.OPNDEALR.Clear();
            txtPaidThrough.Text = "";
            SetAddMode();
            txtLoanBalance.Text = "";
            txtPaidThrough.Text = "";
            PaymentTypecomboBox.Text = "";
            txtPaymentDate.Text = "";
            CodeTypetextBox.Text = "";
            PAYCODEcomboBox.Text = "";
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
            Object loLockedBy = opnpayTableAdapter.LockedBy(cUSTOMER_NOTextBox.Text),
                   loLockedTime = opnpayTableAdapter.LockTime(cUSTOMER_NOTextBox.Text);

            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(OpenPaymentiacDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** PAYMENT: " + cUSTOMER_NOTextBox.Text + " WAS LOCKED BY USER: " +
                    loLockedBy + " " +
                    OpenPaymentiacDataSet.ULIST.Rows[0].Field<String>("LIST_NAME") +
                    "\nON: " + ((DateTime)loLockedTime).ToLongDateString() + " " +
                    ((DateTime)loLockedTime).ToLongTimeString() + "\n" +
                    "YOU MUST WAIT UNTIL THEY RELEASE IT! ***", "RECORD LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripButtonSave.Enabled = false;
                ULISTTableAdapter.Dispose();
                loLockedBy = null;
                lbEdit = false;
                OpenPaymentiacDataSet.Clear();
                StartUpConfiguration();
            }
            else
            {
                opnpayTableAdapter.LockRecord(Program.gsUserID, OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
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
                loQuery = oPNCOMMTableAdapter.SeqNoQuery(txtCommentNo.Text.ToString().TrimEnd(), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;
        }

        private void cOMMENTDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType().Name != "DataGridViewComboBoxEditingControl")
            {
                editingControl = null;
                return;
            }
            editingControl = (DataGridViewComboBoxEditingControl)e.Control;
            if (!lbEdit)
                editingControl.Enabled = false;
            editingControl.SelectedIndexChanged += new EventHandler(editingControl_SelectedIndexChanged);
        }

        private void editingControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editingControl == null)
                return;
            if (editingControl.SelectedIndex >= 0)
            {
                toolStripButtonSave.Enabled = true;
                cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["Comment"].Value = OpenPaymentiacDataSet.Comment_Types.Rows[editingControl.SelectedIndex].Field<String>("Description").ToString().TrimEnd().ToUpper();
                cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["COMMENT_SEQ_NO"].Value = lnSeq;
                cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["COMMENT_DEALER"].Value = DealertextBox.Text.ToString().TrimEnd();
                cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["COMMENT_ID_TYPE"].Value = cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["ID"].Value.ToString().TrimEnd() + OpenPaymentiacDataSet.Comment_Types.Rows[editingControl.SelectedIndex].Field<String>("Type").ToString().TrimEnd();
            }
        }

        private void cOMMENTDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (editingControl == null)
                return;
            editingControl.SelectedIndexChanged -= new EventHandler(editingControl_SelectedIndexChanged);
            editingControl = null;
        }

        private void cOMMENTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("The error is: " + e.Exception.ToString() + " The bad value is:" + cOMMENTDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + '\n' + e.Context.ToString());
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
                OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].CancelEdit();
                PaymentbindingSource.RemoveCurrent();
                lbNewPayment = false;
            }
            cUSTOMER_NOTextBox.Text = "";
            txtPaidThrough.Text = "";
            txtLoanBalance.Text = "";
            txtPaidThrough.Text = "";
            PaymentTypecomboBox.Text = "";
            txtPaymentDate.Text = "";
            CodeTypetextBox.Text = "";
            PAYCODEcomboBox.Text = "";
            txtCheckValue.Text = "";
            txtPaymentDate.Text = "";

            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count > 0)
                OpenPaymentiacDataSet.OPNPAY.Clear();
            opnpayTableAdapter.FillByAll(OpenPaymentiacDataSet.OPNPAY);
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

        private void formOpenPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = opnpayTableAdapter.LockedBy(OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    opnpayTableAdapter.UnlockRecord(OpenPaymentiacDataSet.OPNPAY.Rows[0].Field<String>("PAYMENT_CUSTOMER"));
            }
        }

        private void PaymentbindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            lbNewPayment = true;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            tableAdapConn = new Microsoft.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            opnpayTableAdapter.Connection = tableAdapConn;
            tableAdapTran = opnpayTableAdapter.BeginTransaction();
            opnpayTableAdapter.Transaction = tableAdapTran;
            try
            {
                opnpayTableAdapter.Delete(OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"), OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE").Date);
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
                opnpayTableAdapter.FillByAll(OpenPaymentiacDataSet.OPNPAY);
                if (OpenPaymentiacDataSet.OPNPAY.Rows.Count > 1)
                {
                    PaymentbindingSource.MoveFirst();
                }
                else
                {
                    cUSTOMER_NOTextBox.Text = "";
                    txtPaidThrough.Text = "";
                }
                if (OpenPaymentiacDataSet.OPNPAY.Rows.Count > 0)
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
            frmSelectCheckInst = new FormSelectCheck(cUSTOMER_NOTextBox.Text.TrimEnd());

            frmSelectCheckInst.ShowDialog();

            OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<DateTime>("PAYMENT_ISF_DATE", frmSelectCheckInst.ldISFDate);
            PaymentbindingSource.EndEdit();
            frmSelectCheckInst.Dispose();
        }

        private void HandleISF()
        {
            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count < 1 || PaymentbindingSource.Position < 0)
                return;
            if (PaymentTypetextBox.Text.ToString().ToUpper().TrimEnd() != "I")
            {
                if (lbAddFlag || lbEdit)
                    if (OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") != null)
                    {
                        OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<Nullable<DateTime>>("PAYMENT_ISF_DATE", null);
                        PaymentbindingSource.EndEdit();
                    }
                buttonChangeISFDate.Visible = false;
                textBoxISFDate.Visible = false;
                labelISFDate.Visible = false;
                return;
            }
            else
            {
                if (OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") != null)
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
            if (OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") == null)
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
            if ((!lbAddFlag && !lbEdit) || PaymentTypetextBox.Text.ToUpper() != "I")
                return;

            Decimal lnCheckValue = 0;
            Decimal.TryParse(txtCheckValue.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), out lnCheckValue);
            if (PaymentbindingSource.Position > -1)
                if (lnCheckValue > 0)
                {
                    lnCheckValue *= -1;
                    OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].SetField<String>("PAYMENT_TYPE", "I");
                    txtCheckValue.Text = lnCheckValue.ToString().TrimStart();
                    PaymentbindingSource.EndEdit();
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

            TSBDataRow = (DataRowView)listBoxTSBCommentCode.Items[e.Index];
            e.DrawBackground();
            if (lbAddFlag || lbEdit)
                e.Graphics.DrawString(TSBDataRow["Description"].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            else
                e.Graphics.DrawString(TSBDataRow["Description"].ToString(), e.Font, SystemBrushes.GrayText, e.Bounds);
        }
    }
}
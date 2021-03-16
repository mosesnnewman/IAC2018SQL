using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class FormReciept : Form
    {
        private ListData ListDataSet = new ListData();
        private String _CustomerNo;
        private String _OpenClose;

        public String gsCustomerNo
        {
            get { return _CustomerNo; }
            set { _CustomerNo = value; }
        }

        public String gsOpenClose
        {
            get { return _OpenClose; }
            set { _OpenClose = value; }
        }

        private Decimal lnAmountPaid = 0;

        public FormReciept()
        {
            InitializeComponent();
        }

        private void FormReciept_Load(object sender, EventArgs e)
        {
            setRelatedData();

            nullableDateTimePickerHoldDate.Value = null;

            textBoxCashTendered.Enabled = false;
            textBox100s.Enabled = false;
            textBox50s.Enabled = false;
            textBox20s.Enabled = false;
            textBox10s.Enabled = false;
            textBox5s.Enabled = false;
            textBox1s.Enabled = false;
            textBoxCoins.Enabled = false;

            textBoxCheckAmount.Enabled = false;
            textBoxCheckNumber.Enabled = false;
            checkBoxHold.Enabled = false;
            
            textBoxMoneyOrderAmount.Enabled = false;
            textBoxMoneyOrderNumber.Enabled = false;

            textBoxCreditCardAmount1.Enabled = false;
            textBoxCreditCardNumber1.Enabled = false;
            textBoxCreditCardSecurityCode1.Enabled = false;
            textBoxExpDateMonth1.Enabled = false;
            textBoxExpDateYear1.Enabled = false;
            textBoxCreditCardApproval1.Enabled = false;

            textBoxCreditCardAmount2.Enabled = false;
            textBoxCreditCardNumber2.Enabled = false;
            textBoxCreditCardSecurityCode2.Enabled = false;
            textBoxExpDateMonth2.Enabled = false;
            textBoxExpDateYear2.Enabled = false;
            textBoxCreditCardApproval2.Enabled = false;

            textBoxCreditCardAmount3.Enabled = false;
            textBoxCreditCardNumber3.Enabled = false;
            textBoxCreditCardSecurityCode3.Enabled = false;
            textBoxExpDateMonth3.Enabled = false;
            textBoxExpDateYear3.Enabled = false;
            textBoxCreditCardApproval3.Enabled = false;
            PerformAutoScale();
        }

        private void setRelatedData()
        {
            // Moses Newman 09/17/2013 Change so OPEN is OPEN ONLY and CLOSED is CLOSED ONLY!!!
            switch (_OpenClose)
            {
                case "C":
                    opnclscustomerTableAdapter.FillByClosed(ListDataSet.OPNCLSCUSTOMER, _CustomerNo);
                    dealerTableAdapter.Fill(iacDataSetReceipts.DEALER, ListDataSet.OPNCLSCUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER"));
                    textBoxDealerName.Text = iacDataSetReceipts.DEALER.Rows[0].Field<String>("DEALER_NAME");
                    break;
                case "O":
                    opnclscustomerTableAdapter.FillByOpen(ListDataSet.OPNCLSCUSTOMER, _CustomerNo);
                    opndealrTableAdapter.Fill(iacDataSetReceipts.OPNDEALR, ListDataSet.OPNCLSCUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER"));
                    textBoxDealerName.Text = iacDataSetReceipts.OPNDEALR.Rows[0].Field<String>("OPNDEALR_NAME");
                    break;
            }
            bindingSourceReceipt.AddNew();
            bindingSourceReceipt.EndEdit();
            bindingSourceORECEIPT.AddNew();
            bindingSourceORECEIPT.EndEdit();
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Decimal>("PaidAmount", ListDataSet.OPNCLSCUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Int32>>("Cash100", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Int32>>("Cash50", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Int32>>("Cash20", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Int32>>("Cash10", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Int32>>("Cash5", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Int32>>("Cash1", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Decimal>>("CashCoins", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Decimal>>("CashAmount", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Decimal>>("CheckAmount", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Decimal>>("MoneyOrderAmount", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Decimal>>("CreditCardAmount1", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Decimal>>("CreditCardAmount2", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Nullable<Decimal>>("CreditCardAmount3", 0);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Boolean>("Hold", false);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Boolean>("Posted", false);
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<String>("UserID", Program.gsUserID);

            textBoxUserID.Text = Program.gsUserID;
            textBoxUserName.Text = Program.gsUserName;
            ActiveControl = textBoxAmountPaid;
            textBoxAmountPaid.SelectAll();
        }

        private void buttonCash_Click(object sender, EventArgs e)
        {
            lnAmountPaid = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Decimal>("PaidAmount");
            if (lnAmountPaid == 0)
                return;
            textBoxCashTendered.Enabled = true;
            textBox100s.Enabled = true;
            textBox50s.Enabled = true;
            textBox20s.Enabled = true;
            textBox10s.Enabled = true;
            textBox5s.Enabled = true;
            textBox1s.Enabled = true;
            textBoxCoins.Enabled = true;
            ActiveControl = textBoxCashTendered;
            textBoxCashTendered.SelectAll();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            lnAmountPaid = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Decimal>("PaidAmount");
            if (lnAmountPaid == 0)
                return;

            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Decimal>("CheckAmount", lnAmountPaid);
            textBoxCheckAmount.Enabled = true;
            textBoxCheckNumber.Enabled = true;
            checkBoxHold.Enabled = true;
            ActiveControl = textBoxCheckAmount;
            textBoxCheckAmount.SelectAll();
        }

        private void buttonMoneyOrder_Click(object sender, EventArgs e)
        {
            lnAmountPaid = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Decimal>("PaidAmount");
            if (lnAmountPaid == 0)
                return;
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Decimal>("MoneyOrderAmount", lnAmountPaid);
            textBoxMoneyOrderAmount.Enabled = true;
            textBoxMoneyOrderNumber.Enabled = true;
            ActiveControl = textBoxMoneyOrderAmount;
            textBoxMoneyOrderAmount.SelectAll();
        }

        private void buttonCreditCard_Click(object sender, EventArgs e)
        {
            lnAmountPaid = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Decimal>("PaidAmount");
            if (lnAmountPaid == 0)
                return;
            if (!textBoxCreditCardAmount1.Enabled)
            {
                textBoxCreditCardAmount1.Enabled = true;
                textBoxCreditCardNumber1.Enabled = true;
                textBoxCreditCardSecurityCode1.Enabled = true;
                textBoxExpDateMonth1.Enabled = true;
                textBoxExpDateYear1.Enabled = true;
                textBoxCreditCardApproval1.Enabled = true;
                ActiveControl = textBoxCreditCardAmount1;
                textBoxCreditCardAmount1.SelectAll();
            }
            else
                if (!textBoxCreditCardAmount2.Enabled)
                {
                    textBoxCreditCardAmount2.Enabled = true;
                    textBoxCreditCardNumber2.Enabled = true;
                    textBoxCreditCardSecurityCode2.Enabled = true;
                    textBoxExpDateMonth2.Enabled = true;
                    textBoxExpDateYear2.Enabled = true;
                    textBoxCreditCardApproval2.Enabled = true;
                    ActiveControl = textBoxCreditCardAmount2;
                    textBoxCreditCardAmount2.SelectAll();
                }
                else
                    if (!textBoxCreditCardAmount3.Enabled)
                    {
                        textBoxCreditCardAmount3.Enabled = true;
                        textBoxCreditCardNumber3.Enabled = true;
                        textBoxCreditCardSecurityCode3.Enabled = true;
                        textBoxExpDateMonth3.Enabled = true;
                        textBoxExpDateYear3.Enabled = true;
                        textBoxCreditCardApproval3.Enabled = true;
                        ActiveControl = textBoxCreditCardAmount3;
                        textBoxCreditCardAmount3.SelectAll();
                    }
        }

        private void checkBoxHold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHold.Checked)
            {
                nullableDateTimePickerHoldDate.Enabled = true;
                if (nullableDateTimePickerHoldDate.Value == null)
                    nullableDateTimePickerHoldDate.Value = DateTime.Now.Date;
            }
            else
            {
                nullableDateTimePickerHoldDate.Value = null;
                nullableDateTimePickerHoldDate.Enabled = false;
            }
        }

        private void CalcualteCashTotal()
        {
            Decimal lnTotalCash = 0, lnChange = 0;
            Nullable <Int32> ln100s = 0, ln50s = 0, ln20s = 0, ln10s = 0, ln5s = 0, ln1s = 0;
            Nullable<Decimal> lnCoinTotal = 0;

            ln100s = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Int32>>("Cash100");
            ln50s = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Int32>>("Cash50");
            ln20s = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Int32>>("Cash20");
            ln10s = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Int32>>("Cash10");
            ln5s = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Int32>>("Cash5");
            ln1s = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Int32>>("Cash1");
            lnCoinTotal = iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Decimal>>("CashCoins");

            lnTotalCash  = (Decimal)(ln100s * 100) + (Decimal)(ln50s * 50) + (Decimal)(ln20s * 20) + (Decimal)(ln10s * 10);
            lnTotalCash += (Decimal)(ln5s * 5) + (Decimal)(ln1s) + (Decimal)lnCoinTotal;
                iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Decimal>("CashTendered",lnTotalCash);
            if (lnTotalCash > lnAmountPaid)
            {
                lnChange = lnTotalCash - lnAmountPaid;
                iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Decimal>("CashChange", lnChange);
            }
            iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Decimal>("CashAmount", lnTotalCash - lnChange);
            bindingSourceReceipt.EndEdit();
        }

        private void textBox100s_Validated(object sender, EventArgs e)
        {
            CalcualteCashTotal();
        }

        private void textBox50s_Validated(object sender, EventArgs e)
        {
            CalcualteCashTotal();
        }

        private void textBox20s_Validated(object sender, EventArgs e)
        {
            CalcualteCashTotal();
        }

        private void textBox10s_Validated(object sender, EventArgs e)
        {
            CalcualteCashTotal();
        }

        private void textBox5s_Validated(object sender, EventArgs e)
        {
            CalcualteCashTotal();
        }

        private void textBox1s_Validated(object sender, EventArgs e)
        {
            CalcualteCashTotal();
        }

        private void textBoxCoins_Validated(object sender, EventArgs e)
        {
            CalcualteCashTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Object loOldReceiptNo = null;
            Int32 lnReceiptNumber = 0;
            
            loOldReceiptNo = oRECEIPTTableAdapter.GetReceiptNo();
            if (loOldReceiptNo != null)
            {
                lnReceiptNumber = (Int32)loOldReceiptNo + 1;

                iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Int32>("OldReceipt", lnReceiptNumber);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<Int32>("ORECEIPT_NO", lnReceiptNumber);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_CUST_NO", textBoxCustomerNo.Text);
                iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<String>("CustomerNo", textBoxCustomerNo.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_ADD_ON", " ");
                iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<String>("Type", cUSTOMER_IAC_TypeTextBox.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_IAC_TYPE", cUSTOMER_IAC_TypeTextBox.Text); 
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_FIRST_NAME", cUSTOMER_FIRST_NAMETextBox.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_LAST_NAME", cUSTOMER_LAST_NAMETextBox.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_DEALER", textBoxDealerAccNo.Text);
                iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<String>("Dealer", textBoxDealerAccNo.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_STREET", cUSTOMER_STREET_1TextBox.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_CITY", cUSTOMER_CITYTextBox.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_STATE", cUSTOMER_STATETextBox.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_ZIP_CODE", cUSTOMER_ZIP_1TextBox.Text);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_ACCEPTED_BY", textBoxUserID.Text.TrimStart().TrimEnd());
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_COMMENT", textBoxComment.Text.TrimStart().TrimEnd());

                if (iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Decimal>>("CashAmount") != null)
                {
                    iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<Decimal>("ORECEIPT_CASH_AMOUNT", iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Decimal>("CashAmount"));
                }
                if (iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Decimal>>("CheckAmount") != null)
                {
                    iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<Decimal>("ORECEIPT_CHECK_AMOUNT", iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Decimal>("CheckAmount"));
                    iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_CHECK_NO", iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<String>("CheckNo"));
                }
                if (iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Decimal>>("MoneyOrderAmount") != null)
                {
                    iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<Decimal>("ORECEIPT_MONEY_ORDER_AMOUNT", iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Decimal>("MoneyOrderAmount"));
                    iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<String>("ORECEIPT_MONEY_ORDER_NO", iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<String>("MoneyOrderNo"));
                }
                if (iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Nullable<Decimal>>("PaidAmount") != null)
                    iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<Decimal>("ORECEIPT_PAID_AMOUNT", iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].Field<Decimal>("PaidAmount"));
                iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<DateTime>("Date", DateTime.Now.Date);
                iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position].SetField<DateTime>("ORECEIPT_PAID_DATE", DateTime.Now.Date);
                iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position].SetField<Boolean>("Posted", false);

                bindingSourceORECEIPT.EndEdit();
                oRECEIPTTableAdapter.Update(iacDataSetReceipts.ORECEIPT.Rows[bindingSourceORECEIPT.Position]);
                bindingSourceReceipt.EndEdit();
                receiptTableAdapter.Update(iacDataSetReceipts.Receipt.Rows[bindingSourceReceipt.Position]);

                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                MDImain.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewr = (ReportViewer)MDImain.frm;

                Receipt myReportObject = new Receipt();

                myReportObject.SetDataSource(iacDataSetReceipts);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject.SetParameterValue("gsDealerName", textBoxDealerName.Text);


                rptViewr.crystalReportViewer.ReportSource = myReportObject;
                rptViewr.crystalReportViewer.Refresh();
                rptViewr.Show();


                Close();
            }
        }

        private void textBoxCheckAmount_Validated(object sender, EventArgs e)
        {
        }
    }
}

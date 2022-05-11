using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using System.Globalization;
using DevExpress.XtraEditors;

namespace IAC2021SQL
{
    public partial class FormTickets : DevExpress.XtraEditors.XtraForm
    {
        private ListData listDataSet = new ListData();

        private ProductionMainTablesTableAdapters.ACCOUNTTableAdapter aCCOUNTTableAdapter = new ProductionMainTablesTableAdapters.ACCOUNTTableAdapter();

        private ListDataTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new ListDataTableAdapters.PAYCODETableAdapter();
        private ListDataTableAdapters.PAYMENTTYPETableAdapter PAYMENTTYPETableAdapter = new ListDataTableAdapters.PAYMENTTYPETableAdapter();
        private ProductionMainTablesTableAdapters.ULISTTableAdapter ULISTTableAdapter = new ProductionMainTablesTableAdapters.ULISTTableAdapter();
        private ProductionMainTablesTableAdapters.CONTINGTableAdapter CONTINGTableAdapter = new ProductionMainTablesTableAdapters.CONTINGTableAdapter();
        private ProductionMainTablesTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new ProductionMainTablesTableAdapters.PAYMENTTableAdapter();

        private BindingSource bindingSourcePaymentTypes = new BindingSource();
        private BindingSource bindingSourcePaymentCodes = new BindingSource();
       
        private Tickets.TicketHeaderRow NewTicketHeader;
        private Tickets.TicketDetailRow NewTicketDetail;

        private ProductionMainTables.CONTINGRow NewConting;
        private ProductionMainTables.PAYMENTRow NewPayment;

        public String CustomerNo
        {
            get;
            set;
        }

        private Boolean _AddMode; // Moses Newman 08/16/2021

        public FormTickets()
        {
            InitializeComponent();
        }

        private void FormTickets_Load(object sender, EventArgs e)
        {
            this.pAYCODETableAdapter1.Fill(this.listData.PAYCODE);
            this.pAYMENTTYPETableAdapter1.Fill(this.listData.PAYMENTTYPE);
            ResetAll();
            richTextBox1.Enabled = true;
            richTextBox1.Text = "";
            richTextBox1.Enabled = false;
            ticketAccountsTableAdapter.FillByAll(ticketsdataset.TicketAccounts);
            dEALERTableAdapter.FillByAll(lookupDataSet.DEALER);
            ProductionMainTables.DEALERRow newDealerRow = lookupDataSet.DEALER.NewDEALERRow();
            newDealerRow.id = 0;
            newDealerRow.DEALER_NAME = "";
            newDealerRow.DEALER_CITY = "";
            newDealerRow.DEALER_ACC_NO = "";
            lookupDataSet.DEALER.AddDEALERRow(newDealerRow);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (productionMainTables.CUSTOMER.Rows.Count == 0)
                return;
            bindingSourceTicketDetail.MoveLast();
            NewTicketDetail = ticketsdataset.TicketDetail.NewTicketDetailRow();
            NewTicketDetail.TicketID = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID");
            NewTicketDetail.DetailID = bindingSourceTicketDetail.Position + 2;
            ticketsdataset.TicketDetail.AddTicketDetailRow(NewTicketDetail);
            ticketsdataset.TicketDetail.Rows[bindingSourceTicketDetail.Position].SetField<Int32>("DetailID", bindingSourceTicketDetail.Position + 1);
            bindingSourceTicketDetail.MoveLast();
            gridControl1.Refresh();
            this.Refresh();
            buttonAdd.Enabled = true;
            buttonSaveTicket.Enabled = true;
            buttonClearDetail.Enabled = true;
            buttonDeleteEntry.Enabled = true;
        }

        private void Control_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void CbAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            //System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void CbPaymentCode_SelectedValueChanged(object sender, EventArgs e)
        {
            //System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void CbPaymentType_SelectedValueChanged(object sender, EventArgs e)
        {
            //System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void GetTrialBalance()
        {
            Int32? GLTest = null;
            Decimal Debits = 0, Credits = 0, OutofBalance = 0;
            for (int i = 0; i < ticketsdataset.TicketDetail.Rows.Count; i++)
            {
                if (ticketsdataset.TicketDetail.Rows[i].RowState != DataRowState.Deleted)
                {
                    Debits += ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit");
                    Credits += ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                }
            }
            for (int i = 0; i < ticketsdataset.TicketDetail.Rows.Count; i++)
            {
                if (ticketsdataset.TicketDetail.Rows[i].RowState != DataRowState.Deleted)
                {
                    GLTest = ticketsdataset.TicketDetail.Rows[i].Field<Int32?>("GLAccount");
                    if (GLTest != null)
                        if (ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") == 2)
                        {
                            ticketsdataset.TicketDetail.Rows[i].SetField<Decimal>("Credit", Debits);
                            Credits = Debits;
                        }
                }
            }
            if (Debits != Credits)
            {
                OutofBalance = Debits > Credits ? Debits - Credits : Credits - Debits;
            }

            else
                OutofBalance = 0;
            //colorTextBoxDebits.Debit = true;
            colorTextBoxDebits.ForeColor = Color.Red;
            colorTextBoxCredits.ForeColor = Color.Green;
            colorTextBoxDebits.Text = String.Format("{0:C}", Debits);
            colorTextBoxCredits.Text = String.Format("{0:C}", Credits);
            colorTextBoxOutofBalance.Text = String.Format("{0:C}", OutofBalance);
            if (OutofBalance != 0)
                colorTextBoxOutofBalance.ForeColor = Color.Red;
            else
                colorTextBoxOutofBalance.ForeColor = Color.Black;
        }

        private void textBoxAccount_Validated(object sender, EventArgs e)
        {
            productionMainTables.DEALER.Clear();
            ticketsdataset.TicketDetail.Clear();
            string lsCustomerNo;
            if (textBoxAccount.Text.ToString().Trim().Length < 6 && textBoxAccount.Text.ToString().Trim().Length > 0)
                textBoxAccount.Text = textBoxAccount.Text.Trim().PadLeft(6, '0');
            lsCustomerNo = textBoxAccount.Text.ToString().Trim();
            if (lsCustomerNo == "")  // Moses Newman 03/02/2012 previously only returned if in Add Mode!!!
                return;
            cUSTOMERTableAdapter.Fill(productionMainTables.CUSTOMER, lsCustomerNo);
            if (productionMainTables.CUSTOMER.Rows.Count == 0 && lsCustomerNo != "")
            {
                var ldlgAnswer = MessageBox.Show("Sorry no customers found that match your selected account number!", "Customer Not Found", MessageBoxButtons.OK);
                return;
            }
            else
            {
                richTextBox1.Enabled = true;
                gridControl1.Enabled = true;
                dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
                ticketAccountsTableAdapter.FillByAll(ticketsdataset.TicketAccounts);
                ticketAccountsBindingSource.DataSource = ticketsdataset;
                ticketAccountsBindingSource.DataMember = "TicketAccounts";
                NewTicketHeader = ticketsdataset.TicketHeader.NewTicketHeaderRow();

                NewTicketHeader.AccountNumber = productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CustomerID");
                NewTicketHeader.DealerNumber = productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER");
                NewTicketHeader.Date = DateTime.Now.Date;
                NewTicketHeader.MadeBy = Program.gsUserID.TrimEnd();
                NewTicketHeader.Explanation = "";  // Moses Newman 07/28/2021
                ticketsdataset.TicketHeader.AddTicketHeaderRow(NewTicketHeader);
                bindingSourceTicketHeader.MoveLast(); // Moses Newman 05/27/2021 Move to the new Header Record Just Created.

                aCCOUNTTableAdapter.FillByAll(productionMainTables.ACCOUNT);
                textBoxMadeBy.Text = Program.gsUserID + " " + Program.gsUserName;

                buttonReprint.Enabled = false;
                buttonAdd.Enabled = true;
                buttonCancelTicket.Enabled = true;
                textBoxTicketID.Text = "NEW TICKET";
                textBoxTicketID.Refresh();
                _AddMode = true; // Moses Newman 08/16/2021

                buttonEdit.Enabled = false; // Moses Newman 08/16/2021

                ActiveControl = buttonAdd;
                buttonAdd.Select();
            }

        }

        private void GeneralKeypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            else
            {
                //toolStripButtonSave.Enabled = true;
            }

        }

        private void buttonSaveTicket_Click(object sender, EventArgs e)
        {
            int? insertID = 0, lnSeq;
            Boolean MissingPayType = false, MissingPayCode = false;
            Object loContingentSeq = null;
            Char NotPosted = '\u00FF';

            System.Windows.Forms.SendKeys.Send("{TAB}"); // Moses Newman 06/13/2021 send tab to make sure if still in a field, field validation fires.
            if (checkBoxCloseOut.Checked)
            {
                for (int i = 0; i < ticketsdataset.TicketDetail.Rows.Count; i++)
                {
                    if (ticketsdataset.TicketDetail.Rows[i].RowState != DataRowState.Deleted)
                    {
                        if (ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") != 2)
                        {
                            switch (ticketsdataset.TicketDetail.Rows[i].Field<String>("PaymentType"))
                            {
                                case "":
                                case " ":
                                case null:
                                    MissingPayType = true;
                                    break;
                            }
                            switch (ticketsdataset.TicketDetail.Rows[i].Field<String>("PaymentCode"))
                            {
                                case "":
                                case " ":
                                case null:
                                    MissingPayCode = true;
                                    break;
                            }
                        }
                    }
                }
                if (MissingPayType || MissingPayCode)
                {
                    MessageBox.Show("*** All rows EXCEPT for NOTES RECEIVABLE MUST have a Paymtent Type and a Payment Code on a closeout ticket! ***",
                        "Payment Type and / or Code Missing", MessageBoxButtons.OK);
                    return;
                }
            }
            if (_AddMode)
            {
                ticketHeaderTableAdapter.Insert(ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber"),
                ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("DealerNumber"),
                ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<DateTime>("Date"),
                ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"),
                ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("ApprovedBy"),
                ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("Explanation"),
                ref insertID, false); // Moses Newman 08/15/2021 
            }
            else
                insertID = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID");
            if (!_AddMode)
            {
                PAYMENTTableAdapter.DeleteByTicketID(insertID);
                CONTINGTableAdapter.DeleteByTicketID(insertID);
            }
            for (int i = 0; i < ticketsdataset.TicketDetail.Rows.Count; i++)
            {
                if (ticketsdataset.TicketDetail.Rows[i].RowState != DataRowState.Deleted)
                {
                    if (_AddMode || ticketsdataset.TicketDetail.Rows[i].Field<Int32?>("TicketID") == null || ticketsdataset.TicketDetail.Rows[i].Field<Int32?>("TicketID") <= 0)
                        ticketsdataset.TicketDetail.Rows[i].SetField<Int32>("TicketID", (Int32)insertID);
                    if (ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") != 2) // Moses Newman 09/21/2021  && ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") != 7)
                    {
                        NewPayment = productionMainTables.PAYMENT.NewPAYMENTRow();
                        NewPayment.PAYMENT_CUSTOMER = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                        NewPayment.PAYMENT_ADD_ON = "";
                        NewPayment.PAYMENT_IAC_TYPE = "C";
                        NewPayment.PAYMENT_DATE = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<DateTime>("Date");
                        NewPayment.PAYMENT_DEALER = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("DealerNumber");
                        NewPayment.PAYMENT_POST_INDICATOR = "";
                        NewPayment.PAYMENT_AMOUNT_RCV = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                        NewPayment.PAYMENT_TYPE = ticketsdataset.TicketDetail.Rows[i].Field<String>("PaymentType");
                        NewPayment.PAYMENT_CODE_2 = ticketsdataset.TicketDetail.Rows[i].Field<String>("PaymentCode");
                        NewPayment.PAYMENT_THRU_UD = 0;
                        NewPayment.PAYMENT_CURR_INT = 0;
                        NewPayment.PAYMENT_LATE_CHARGE_PAID = 0;
                        NewPayment.IsSimple = true;
                        NewPayment.PAYMENT_AUTO_PAY = "N";
                        NewPayment.PAYMENT_TSB_COMMENT_CODE = "";
                        switch (NewPayment.PAYMENT_TYPE)
                        {
                            case "V":
                                NewPayment.CreditCardType = "CARD";
                                break;
                            case "P":
                                NewPayment.CreditCardType = "ACH";
                                break;
                            default:
                                NewPayment.CreditCardType = "";
                                break;
                        }
                        NewPayment.TransactionDate = NewPayment.PAYMENT_DATE;
                        NewPayment.Fee = 0;
                        NewPayment.FromIVR = false;
                        NewPayment.TicketDetailID = ticketsdataset.TicketDetail.Rows[i].Field<Int32>("DetailID");  // Moses Newman 08/17/2021 
                        NewPayment.TicketID = (Int32)insertID;

                        productionMainTables.PAYMENT.AddPAYMENTRow(NewPayment);
                        NewPayment = null;
                        PAYMENTTableAdapter.Update(productionMainTables.PAYMENT.Rows[productionMainTables.PAYMENT.Rows.Count - 1]);
                        if (ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") != 1 &&
                            ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") != 7 &&
                            ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") != 12)
                        {
                            NewConting = productionMainTables.CONTING.NewCONTINGRow();

                            NewConting.CONTING_DEALER = ticketsdataset.TicketDetail.Rows[i].Field<Int32>("SubDealer") != 0 ?
                                                                ticketsdataset.TicketDetail.Rows[i].Field<Int32>("SubDealer") : ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("DealerNumber");
                            NewConting.CONTING_POST_DATE = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<DateTime>("Date");
                            loContingentSeq = CONTINGTableAdapter.MaxSeqQuery(NewConting.CONTING_DEALER, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<DateTime>("Date"));
                            if (loContingentSeq != null)
                                lnSeq = (int)loContingentSeq + 1;
                            else
                                lnSeq = 0;   //Closed and Open contingents start with 0 for first sequence number
                            NewConting.CONTING_ENTRY_SEQ = (Int32)lnSeq;
                            NewConting.CONTING_POST_IND = "";
                            NewConting.CONTING_POST_IND += NotPosted;
                            NewConting.CONTING_LOSS_RES = 0;
                            NewConting.CONTING_LOSS_RES_COMMENT = "";
                            NewConting.CONTING_CONTRACT = 0;
                            NewConting.CONTING_CONTRACT_COMMENT = "";
                            NewConting.CONTING_ADJUST = 0;
                            NewConting.CONTING_ADJUST_COMMENT = "";
                            NewConting.CONTING_RECOV_BAD = 0;
                            NewConting.CONTING_RECOV_BAD_COMMENT = "";
                            NewConting.CONTING_RES_LOSS = 0;
                            NewConting.CONTING_RES_LOSS_COMMENT = "";
                            NewConting.CONTING_OS_LOANS = 0;
                            NewConting.CONTING_OS_LOANS_COMMENT = "";
                            NewConting.CONTING_NOTES_PAY = 0;
                            NewConting.CONTING_NOTES_PAY_COMMENT = "";
                            NewConting.CONTING_SIMPLE_INT = 0;
                            NewConting.CONTING_SIMPLE_INT_COMMENT = "";
                            NewConting.CONTING_AMORT_INT = 0;
                            NewConting.CONTING_AMORT_INT_COMMENT = "";
                            NewConting.CONTING_OLD_INT = 0;
                            NewConting.CONTING_OLD_INT_COMMENT = "";
                            NewConting.CONTING_SIMPLE_SW = "";
                            NewConting.CONTING_AMORT_SW = "";
                            NewConting.CONTING_OLD_SW = "";
                            NewConting.Islocked = false;
                            NewConting.TicketDetailID = ticketsdataset.TicketDetail.Rows[i].Field<Int32>("DetailID");  // Moses Newman 08/17/2021 
                            NewConting.TicketID = (Int32)insertID;

                            switch (ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount"))
                            {
                                case 3: // CONTINGENT RESERVE
                                    NewConting.CONTING_CONTRACT = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") * -1 : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                    NewConting.CONTING_CONTRACT_COMMENT = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                                    break;
                                case 4: // ADJUST ACCOUNT A/A
                                    NewConting.CONTING_ADJUST = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") * -1 : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                    NewConting.CONTING_ADJUST_COMMENT = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                                    break;
                                case 5: // DEALER ADJUST A/A REMOVE!
                                    NewConting.CONTING_ADJUST = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") * -1 : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                    NewConting.CONTING_ADJUST_COMMENT = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                                    break;
                                case 6: // DEALER LOSS RESERVE
                                    NewConting.CONTING_LOSS_RES = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") * -1 : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                    NewConting.CONTING_LOSS_RES_COMMENT = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                                    break;
                                /*case 7: // SUNDRY INCOME
                                    NewConting.CONTING_LOSS_RES = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                    NewConting.CONTING_LOSS_RES_COMMENT = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                                    break;*/
                                case 8: // RESERVE FOR LOSSES
                                    NewConting.CONTING_RES_LOSS = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") * -1 : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                    NewConting.CONTING_RES_LOSS_COMMENT = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                                    break;
                                case 9: // RECOVERY OF BAD DEBT
                                    NewConting.CONTING_RECOV_BAD = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") * -1 : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                    NewConting.CONTING_RECOV_BAD_COMMENT = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                                    break;
                            }
                            productionMainTables.CONTING.AddCONTINGRow(NewConting);
                            NewConting = null;
                            CONTINGTableAdapter.Update(productionMainTables.CONTING.Rows[productionMainTables.CONTING.Rows.Count - 1]);
                        }
                    }
                }
            }
            ticketDetailTableAdapter.Update(ticketsdataset.TicketDetail);
            //PAYMENTTableAdapter.Update(productionMainTables.PAYMENT);
            //CONTINGTableAdapter.Update(productionMainTables.CONTING);
            PrintTicket((Int32)insertID);
            MoveToTicket((Int32)insertID);
            ResetAll();
            /*// Moses Newman 08/16/2021 Mod starts
            _EditMode = false;
            _AddMode = false;
            _ViewMode = true;
            buttonEdit.Enabled = false; // Moses Newman 08/16/2021
            // End Mod 08/16/2021*/
        }

        private void MoveToTicket(Int32 tnTicketID)
        {
            gridControl1.Enabled = false;
            Int32 FoundIndex = 0;
            ticketHeaderTableAdapter.FillByAll(ticketsdataset.TicketHeader);
            FoundIndex = bindingSourceTicketHeader.Find("TicketID", tnTicketID);
            if (FoundIndex > -1)
                bindingSourceTicketHeader.Position = FoundIndex;
            buttonAdd.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonClearDetail.Enabled = false;
            buttonCancelTicket.Enabled = false;
            buttonReprint.Enabled = false;
            richTextBox1.Enabled = false;
            if (bindingSourceTicketHeader.Position > -1)
            {
                ticketDetailTableAdapter.FillByTicketID(ticketsdataset.TicketDetail, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            }
            else
                return;
            cUSTOMERTableAdapter.Fill(productionMainTables.CUSTOMER, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0'));
            dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
            GetTrialBalance();
            ULISTTableAdapter.FillById(productionMainTables.ULIST, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"));
            textBoxMadeBy.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy") + " " + productionMainTables.ULIST.Rows[0].Field<String>("LIST_NAME");
            buttonReprint.Enabled = true;
            textBoxTicketID.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID").ToString().Trim();
            textBoxTicketID.Refresh();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (buttonCancelTicket.Enabled)
                return;
            gridControl1.Enabled = false;
            Int32 lnTicketID = 0, FoundIndex = 0;
            if (ticketsdataset.TicketHeader.Rows.Count == 1)
            {
                lnTicketID = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID");
                ticketHeaderTableAdapter.FillByAll(ticketsdataset.TicketHeader);
                if (ticketsdataset.TicketHeader.Rows.Count > 1)
                {
                    FoundIndex = bindingSourceTicketHeader.Find("TicketID", lnTicketID);
                    if (FoundIndex > -1)
                        bindingSourceTicketHeader.Position = FoundIndex;
                }
            }
            buttonAdd.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonClearDetail.Enabled = false;
            buttonReprint.Enabled = false;
            buttonCancelTicket.Enabled = false;
            bindingSourceTicketHeader.MovePrevious();
            richTextBox1.Enabled = false;
            if (bindingSourceTicketHeader.Position > -1)
            {
                PAYCODETableAdapter.FillByType(listDataSet.PAYCODE, "*");
                pAYCODEBindingSource.DataSource = listDataSet.PAYCODE;
                ticketDetailTableAdapter.FillByTicketID(ticketsdataset.TicketDetail, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            }
            else
                return;
            cUSTOMERTableAdapter.Fill(productionMainTables.CUSTOMER, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0'));
            dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
            //CONTINGTableAdapter.FillByTicketID(productionMainTables.CONTING, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            //PAYMENTTableAdapter.FillByTicketID(productionMainTables.PAYMENT, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID")); // Moses Newman 08/17/2021
            GetTrialBalance();
            ULISTTableAdapter.FillById(productionMainTables.ULIST, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"));
            textBoxMadeBy.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy") + " " + productionMainTables.ULIST.Rows[0].Field<String>("LIST_NAME");
            buttonReprint.Enabled = true;
            textBoxTicketID.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID").ToString().Trim();
            textBoxTicketID.Refresh();
            //_ViewMode = true;
            buttonEdit.Enabled = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (buttonCancelTicket.Enabled)
                return;
            gridControl1.Enabled = false;
            buttonAdd.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonClearDetail.Enabled = false;
            buttonReprint.Enabled = false;
            buttonCancelTicket.Enabled = false;
            bindingSourceTicketHeader.MoveNext();
            richTextBox1.Enabled = false;
            if (bindingSourceTicketHeader.Position > -1)
            {
                PAYCODETableAdapter.FillByType(listDataSet.PAYCODE, "*");
                pAYCODEBindingSource.DataSource = listDataSet.PAYCODE;
                ticketDetailTableAdapter.FillByTicketID(ticketsdataset.TicketDetail, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            }
            else
                return;
            cUSTOMERTableAdapter.Fill(productionMainTables.CUSTOMER, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0'));
            dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
            //CONTINGTableAdapter.FillByTicketID(productionMainTables.CONTING, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            //PAYMENTTableAdapter.FillByTicketID(productionMainTables.PAYMENT, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID")); // Moses Newman 08/17/2021
            GetTrialBalance();
            ULISTTableAdapter.FillById(productionMainTables.ULIST, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"));
            textBoxMadeBy.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy") + " " + productionMainTables.ULIST.Rows[0].Field<String>("LIST_NAME");
            buttonReprint.Enabled = true;
            textBoxTicketID.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID").ToString().Trim();
            textBoxTicketID.Refresh();
            //_ViewMode = true;
            buttonEdit.Enabled = true;
        }

        private void PrintTicket(Int32 tnTicketID)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

            Ticket myReportObject = new Ticket();
            ListDataTableAdapters.DLRLISTBYNUMTableAdapter dLRLISTBYNUMTableAdapter = new ListDataTableAdapters.DLRLISTBYNUMTableAdapter();
            dLRLISTBYNUMTableAdapter.Fill(listDataSet.DLRLISTBYNUM);

            ticketHeaderTableAdapter.Fill(ticketsdataset.TicketHeader, tnTicketID);
            ticketDetailTableAdapter.FillByTicketID(ticketsdataset.TicketDetail, tnTicketID);
            ticketAccountsTableAdapter.FillByAll(ticketsdataset.TicketAccounts);

            myReportObject.Database.Tables[0].SetDataSource(productionMainTables);
            myReportObject.Database.Tables[1].SetDataSource(productionMainTables);
            myReportObject.Database.Tables[2].SetDataSource(ticketsdataset);
            myReportObject.Database.Tables[3].SetDataSource(ticketsdataset);

            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            rptViewer.crystalReportViewer.ReportSource = myReportObject;
            rptViewer.crystalReportViewer.Refresh();
            rptViewer.Show();

            rptViewer.Activate();
        }

        private void buttonReprint_Click(object sender, EventArgs e)
        {
            PrintTicket(ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
        }

        private void buttonClearDetail_Click(object sender, EventArgs e)
        {
            ticketsdataset.TicketDetail.Clear();
        }

        private void buttonCancelTicket_Click(object sender, EventArgs e)
        {
            ticketsdataset.TicketHeader.Clear();
            ticketsdataset.TicketDetail.Clear();
            productionMainTables.CUSTOMER.Clear();
            productionMainTables.DEALER.Clear();
            textBoxAccount.Text = "";
            ticketHeaderTableAdapter.FillByAll(ticketsdataset.TicketHeader);
            buttonCancelTicket.Enabled = false;
            buttonDeleteEntry.Enabled = false;
            textBoxTicketID.Text = "";
            textBoxTicketID.Refresh();
            richTextBox1.EditValue = "";
            ActiveControl = textBoxAccount;
            textBoxAccount.Select();
            // Moses Newman 08/16/2021 Mod starts
            //_EditMode = false;
            _AddMode = false;
            //_ViewMode = true;
            // End Mod 08/16/2021
        }

        // Moses Newman 08/16/2021
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Boolean>("IsPosted"))
                MessageBox.Show("*** This ticket or part of it, has already been posted.  You may not edit it. ***");
            if (productionMainTables.CUSTOMER.Rows.Count == 0 || ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Boolean>("IsPosted"))
                return;
            //_EditMode = true;
            //_ViewMode = false;
            _AddMode = false;
            richTextBox1.Enabled = true;
            gridControl1.Enabled = true;
            buttonEdit.Enabled = false;
            buttonReprint.Enabled = false;
            buttonAdd.Enabled = true;
            buttonCancelTicket.Enabled = true;
            buttonSaveTicket.Enabled = true;
            buttonClearDetail.Enabled = true;
            buttonDeleteEntry.Enabled = true;
            buttonDeleteTicket.Enabled = true; // Moses Newman 09/22/2021
        }

        private void buttonDeleteTicket_Click(object sender, EventArgs e)
        {
            if (productionMainTables.CUSTOMER.Rows.Count == 0 || ticketsdataset.TicketHeader.Rows.Count == 0)
                return;
            // Moses Newman 09/22/2021 Added full delete ticket functionality
            Int32 ThisTicket = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID");


            // Moses Newman stored procedures will only delete headers or details if not yet posted!
            ticketHeaderTableAdapter.Delete(ThisTicket);
            ticketDetailTableAdapter.DeleteALL(ThisTicket);
            PAYMENTTableAdapter.DeleteByTicketID(ThisTicket);
            CONTINGTableAdapter.DeleteByTicketID(ThisTicket);

            ticketHeaderTableAdapter.FillByAll(ticketsdataset.TicketHeader);
            ticketsdataset.TicketDetail.Clear();
            productionMainTables.CUSTOMER.Clear();
            buttonCancelTicket.Enabled = false;
            buttonDeleteTicket.Enabled = false;
            buttonFirst.PerformClick();
            buttonLast.PerformClick();
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            if (buttonCancelTicket.Enabled)
                return;
            gridControl1.Enabled = false;
            Int32 lnTicketID = 0, FoundIndex = 0;
            if (ticketsdataset.TicketHeader.Rows.Count == 1)
            {
                lnTicketID = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID");
                ticketHeaderTableAdapter.FillByAll(ticketsdataset.TicketHeader);
                if (ticketsdataset.TicketHeader.Rows.Count > 1)
                {
                    FoundIndex = bindingSourceTicketHeader.Find("TicketID", lnTicketID);
                    if (FoundIndex > -1)
                        bindingSourceTicketHeader.Position = FoundIndex;
                }
            }
            buttonAdd.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonClearDetail.Enabled = false;
            buttonReprint.Enabled = false;
            buttonCancelTicket.Enabled = false;
            bindingSourceTicketHeader.MoveFirst();
            richTextBox1.Enabled = false;
            if (bindingSourceTicketHeader.Position > -1)
            {
                PAYCODETableAdapter.FillByType(listDataSet.PAYCODE, "*");
                pAYCODEBindingSource.DataSource = listDataSet.PAYCODE;
                ticketDetailTableAdapter.FillByTicketID(ticketsdataset.TicketDetail, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            }
            else
                return;
            cUSTOMERTableAdapter.Fill(productionMainTables.CUSTOMER, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0'));
            dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
            //CONTINGTableAdapter.FillByTicketID(productionMainTables.CONTING, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            //PAYMENTTableAdapter.FillByTicketID(productionMainTables.PAYMENT, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID")); // Moses Newman 08/17/2021
            GetTrialBalance();
            ULISTTableAdapter.FillById(productionMainTables.ULIST, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"));
            textBoxMadeBy.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy") + " " + productionMainTables.ULIST.Rows[0].Field<String>("LIST_NAME");
            buttonReprint.Enabled = true;
            textBoxTicketID.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID").ToString().Trim();
            textBoxTicketID.Refresh();
            //_ViewMode = true;
            buttonEdit.Enabled = true;
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            if (buttonCancelTicket.Enabled)
                return;
            gridControl1.Enabled = false;
            buttonAdd.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonClearDetail.Enabled = false;
            buttonReprint.Enabled = false;
            buttonCancelTicket.Enabled = false;
            bindingSourceTicketHeader.MoveLast();
            richTextBox1.Enabled = false;
            if (bindingSourceTicketHeader.Position > -1)
            {
                PAYCODETableAdapter.FillByType(listDataSet.PAYCODE, "*");
                pAYCODEBindingSource.DataSource = listDataSet.PAYCODE;
                ticketDetailTableAdapter.FillByTicketID(ticketsdataset.TicketDetail, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            }
            else
                return;
            cUSTOMERTableAdapter.Fill(productionMainTables.CUSTOMER, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0'));
            dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
            //CONTINGTableAdapter.FillByTicketID(productionMainTables.CONTING, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            //PAYMENTTableAdapter.FillByTicketID(productionMainTables.PAYMENT, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID")); // Moses Newman 08/17/2021
            GetTrialBalance();
            ULISTTableAdapter.FillById(productionMainTables.ULIST, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"));
            textBoxMadeBy.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy") + " " + productionMainTables.ULIST.Rows[0].Field<String>("LIST_NAME");
            buttonReprint.Enabled = true;
            textBoxTicketID.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID").ToString().Trim();
            textBoxTicketID.Refresh();
            //_ViewMode = true;
            buttonEdit.Enabled = true;
        }

        private void buttonDeleteEntry_Click(object sender, EventArgs e)
        {
            if (productionMainTables.CUSTOMER.Rows.Count == 0)
                return;
            if (ticketsdataset.TicketDetail.Rows.Count > 0)
                ticketsdataset.TicketDetail.Rows[bindingSourceTicketDetail.Position].Delete();
            buttonDeleteEntry.Enabled = ticketsdataset.TicketDetail.Rows.Count > 0 ? true : false;
            for (int i = 0; i < ticketsdataset.TicketDetail.Rows.Count; i++)  // Moses Newman 08/19/2021
                if (ticketsdataset.TicketDetail.Rows[i].RowState != DataRowState.Deleted)
                    ticketsdataset.TicketDetail.Rows[i].SetField<Int32>("DetailID", i + 1);
            bindingSourceTicketDetail.MoveLast();
            gridControl1.Refresh();
            this.Refresh();
            buttonAdd.Enabled = true;
            buttonSaveTicket.Enabled = true;
            buttonClearDetail.Enabled = true;
        }

        private void ResetAll()
        {
            ticketsdataset.TicketHeader.Clear();
            ticketsdataset.TicketDetail.Clear();
            productionMainTables.CONTING.Clear();
            productionMainTables.PAYMENT.Clear();

            buttonEdit.Enabled = false; // Moses Newman 08/16/2021
            buttonDeleteTicket.Enabled = false; // Moses Newman 08/16/2021
            //_EditMode = false;
            _AddMode = false;
            //_ViewMode = true;

            NullableDateTimePickerDate.EditValue = null;
            NullableDateTimePickerDate.Refresh();
            buttonClearDetail.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonCancelTicket.Enabled = false;
            buttonAdd.Enabled = false;
            buttonDeleteEntry.Enabled = false; // Moses Newman 07/28/2021
            PAYMENTTYPETableAdapter.Fill(listDataSet.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(listDataSet.PAYCODE);

            bindingSourcePaymentTypes.DataSource = listDataSet;
            bindingSourcePaymentTypes.DataMember = "PAYMENTTYPE";
            bindingSourcePaymentCodes.DataSource = listDataSet;
            bindingSourcePaymentCodes.DataMember = "PAYCODE";

            ticketHeaderTableAdapter.FillByAll(ticketsdataset.TicketHeader);
            ticketAccountsTableAdapter.FillByAll(ticketsdataset.TicketAccounts);
            ticketAccountsBindingSource.DataSource = ticketsdataset;
            ticketAccountsBindingSource.DataMember = "TicketAccounts";

            colorTextBoxDebits.ForeColor = Color.Red;
            colorTextBoxCredits.ForeColor = Color.Green;
            richTextBox1.Text = "";
            richTextBox1.EditValue = ""; // Moses Newman 07/28/2021
            ActiveControl = textBoxAccount;
            textBoxAccount.Select();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.ListSourceRowIndex == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                return;
            
            Int32 AcctNumber,DealerID;
            ColumnView view = sender as ColumnView;
            switch(e.Column.FieldName)
            {
                case "GLAccount":
                    AcctNumber = e.Value != System.DBNull.Value ? (Int32)e.Value : 0;
                    Int32 FoundIndex = ticketAccountsBindingSource.Find("AcctID", AcctNumber);
                    e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    if (FoundIndex > -1)
                        e.DisplayText = ticketsdataset.TicketAccounts.Rows[FoundIndex].Field<String>("Account");
                    else
                        e.DisplayText = "";
                    break;
                case "SubDealer":
                    DealerID = e.Value != System.DBNull.Value ? (Int32)e.Value : 0;
                    if(DealerID == 0)
                        e.DisplayText = "";
                    break;
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            String cFieldName = e.Column.FieldName;
            switch (cFieldName)
            {
                case "Debit":
                case "Credit":
                    GetTrialBalance();
                    this.Refresh();
                    break;
            }
        }

        private void richTextBox1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxAccount.Text))
                e.DisplayText = String.Empty;
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            if (view.FocusedColumn.FieldName == "PaymentCode")
            {
                LookUpEdit editor = (LookUpEdit)view.ActiveEditor;
                string PayType = Convert.ToString(view.GetFocusedRowCellValue("PaymentType"));
                PAYCODETableAdapter.FillByType(listDataSet.PAYCODE, PayType);
                pAYCODEBindingSource.DataSource = listDataSet.PAYCODE;
                editor.Properties.DataSource = pAYCODEBindingSource;
            }
        }

        private void repositoryItemLookUpEdit4_EditValueChanged(object sender, EventArgs e)
        {
            this.gridView1.PostEditor();
            this.gridView1.SetFocusedRowCellValue("PaymentCode", null);
        }

        private void textBoxAccount_EditValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Refresh();
        }

        private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void gridView1_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            String cFieldName = e.FocusedColumn.FieldName;
            switch (cFieldName)
            {
                case "Debit":
                case "Credit":
                    GetTrialBalance();
                    this.Refresh();
                    break;
            }
        }
    }
}

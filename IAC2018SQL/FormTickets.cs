using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class FormTickets : Form
    {
        private ListData listDataSet = new ListData();

        private ProductionMainTablesTableAdapters.ACCOUNTTableAdapter aCCOUNTTableAdapter = new ProductionMainTablesTableAdapters.ACCOUNTTableAdapter();

        private TicketsTableAdapters.TicketAccountsTableAdapter ticketAccountsTableAdapter = new TicketsTableAdapters.TicketAccountsTableAdapter();
        private ListDataTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new ListDataTableAdapters.PAYCODETableAdapter();
        private ListDataTableAdapters.PAYMENTTYPETableAdapter PAYMENTTYPETableAdapter = new ListDataTableAdapters.PAYMENTTYPETableAdapter();
        private ProductionMainTablesTableAdapters.ULISTTableAdapter ULISTTableAdapter = new ProductionMainTablesTableAdapters.ULISTTableAdapter();
        private ProductionMainTablesTableAdapters.CONTINGTableAdapter CONTINGTableAdapter = new ProductionMainTablesTableAdapters.CONTINGTableAdapter();
        private ProductionMainTablesTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new ProductionMainTablesTableAdapters.PAYMENTTableAdapter();

        private BindingSource bindingSourceTicketAccounts = new BindingSource();
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

        public FormTickets()
        {
            InitializeComponent();
        }

        private void FormTickets_Load(object sender, EventArgs e)
        {
            NullableDateTimePickerDate.Value = null;
            NullableDateTimePickerDate.Refresh();
            buttonClearDetail.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonCancelTicket.Enabled = false;
            buttonAdd.Enabled = false;
            PAYMENTTYPETableAdapter.Fill(listDataSet.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(listDataSet.PAYCODE);

            bindingSourcePaymentTypes.DataSource = listDataSet;
            bindingSourcePaymentTypes.DataMember = "PAYMENTTYPE";
            bindingSourcePaymentCodes.DataSource = listDataSet;
            bindingSourcePaymentCodes.DataMember = "PAYCODE";

            ticketHeaderTableAdapter.FillByAll(ticketsdataset.TicketHeader);
            ticketAccountsTableAdapter.FillByAll(ticketsdataset.TicketAccounts);
            bindingSourceTicketAccounts.DataSource = ticketsdataset;
            bindingSourceTicketAccounts.DataMember = "TicketAccounts";
            this.Account.AspectToStringConverter = delegate (object x)
            {
                Int32 AcctNumber;
                //Int32.TryParse((String)x, out AcctNumber); // GLAccount is not a string anymore, it's an integer!
                AcctNumber = (x == System.DBNull.Value) ? 0 : (Int32)x;
                Int32 FoundIndex = bindingSourceTicketAccounts.Find("AcctID", AcctNumber);
                if (FoundIndex > -1)
                    return ticketsdataset.TicketAccounts.Rows[FoundIndex].Field<String>("Account");
                else
                    return "";
            };
            ActiveControl = textBoxAccount;
            textBoxAccount.Select();
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
            dataListView1.Refresh();
            this.Refresh();
            buttonAdd.Enabled = true;
            buttonSaveTicket.Enabled = true;
            buttonClearDetail.Enabled = true;
        }

        private void dataListView1_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            Int32 cindex = e.Column.Index,AccountID;
            var AcccountColumn = dataListView1.GetColumn(1);

            switch (cindex)
            {
                case 1:
                    bindingSourceTicketAccounts.MoveFirst();
                    ComboBox cbAccount = new ComboBox();
                    cbAccount.Bounds = e.CellBounds;
                    cbAccount.Font = ((BrightIdeasSoftware.DataListView)sender).Font;
                    cbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbAccount.DataSource = bindingSourceTicketAccounts;
                    cbAccount.ValueMember = "AcctID";
                    cbAccount.DisplayMember = "Account";
                    cbAccount.SelectedValue = "AcctID"; // should select the entry that reflects the currentvalue
                    cbAccount.KeyPress += GeneralKeypress;
                    //cbAccount.SelectedValueChanged += CbAccount_SelectedValueChanged;
                    e.Control = cbAccount;
                    break;
                /*case 2:
                case 3:
                case 4:
                    //e.Control.KeyPress += GeneralKeypress;
                    //e.Control.TextChanged += Control_TextChanged;
                    break;*/
                case 5:
                    AccountID = (Int32)AcccountColumn.GetValue(e.RowObject);
                    if (AccountID == 2)
                    {
                        e.Control.Enabled = false;
                        break;
                    }
                    else
                        e.Control.Enabled = true;
                    listDataSet.PAYCODE.Clear();
                    bindingSourceTicketAccounts.MoveFirst();
                    ComboBox cbPaymentType = new ComboBox();
                    cbPaymentType.Bounds = e.CellBounds;
                    cbPaymentType.Width = 200;
                    cbPaymentType.Font = ((BrightIdeasSoftware.DataListView)sender).Font;
                    cbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
                    cbPaymentType.DataSource = bindingSourcePaymentTypes;
                    cbPaymentType.ValueMember = "TYPE";
                    cbPaymentType.DisplayMember = "DESCRIPTION";
                    cbPaymentType.SelectedValue = "TYPE"; // should select the entry that reflects the currentvalue
                    //cbPaymentType.SelectedValueChanged += CbPaymentType_SelectedValueChanged;
                    cbPaymentType.KeyPress += GeneralKeypress;
                    e.Control = cbPaymentType;
                    break;
                case 6:
                    AccountID = (Int32)AcccountColumn.GetValue(e.RowObject);
                    if (AccountID == 2)
                    {
                        e.Control.Enabled = false;
                        break;
                    }
                    else
                        e.Control.Enabled = true;
                    if (listDataSet.PAYCODE.Rows.Count > 0)
                    {
                        bindingSourceTicketAccounts.MoveFirst();
                        ComboBox cbPaymentCode = new ComboBox();
                        cbPaymentCode.Bounds = e.CellBounds;
                        cbPaymentCode.Width = 200;
                        cbPaymentCode.Font = ((BrightIdeasSoftware.DataListView)sender).Font;
                        cbPaymentCode.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbPaymentCode.DataSource = bindingSourcePaymentCodes;
                        cbPaymentCode.ValueMember = "CODE";
                        cbPaymentCode.DisplayMember = "DESCRIPTION";
                        cbPaymentCode.SelectedValue = "CODE"; // should select the entry that reflects the currentvalue
                        //cbPaymentCode.SelectedValueChanged += CbPaymentCode_SelectedValueChanged;
                        cbPaymentCode.KeyPress += GeneralKeypress;
                        e.Control = cbPaymentCode;
                    }
                    break;
            }
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
            Decimal Debits = 0, Credits = 0, OutofBalance = 0;
            for (int i = 0; i < ticketsdataset.TicketDetail.Rows.Count; i++)
            {
                Debits += ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit");
                Credits += ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
            }
            if (Debits != Credits)
            {
                OutofBalance = Debits > Credits ? Debits - Credits:Credits - Debits;
            }

            else
                OutofBalance = 0;
            colorTextBoxDebits.Text = String.Format("{0:C}", Debits);
            colorTextBoxCredits.Text = String.Format("{0:C}", Credits);
            colorTextBoxOutofBalance.Text = String.Format("{0:C}", OutofBalance);
        }

        private void dataListView1_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            Int32 cindex = e.Column.Index;
            switch (cindex)
            {
                case 3:
                case 4:
                    GetTrialBalance();
                    this.Refresh();
                    break;
                case 5:
                    PAYCODETableAdapter.FillByType(listDataSet.PAYCODE, e.NewValue.ToString());
                    //System.Windows.Forms.SendKeys.Send("{TAB}");
                    break;
            }

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
                var ldlgAnswer = MessageBox.Show("Sorry no customers found that match your selected account number!", "Customer Not Found",MessageBoxButtons.OK);
                return;
            }
            else
            {
                richTextBox1.Enabled = true;
                dataListView1.Enabled = true;
                dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER"));
                ticketAccountsTableAdapter.FillByAll(ticketsdataset.TicketAccounts);
                bindingSourceTicketAccounts.DataSource = ticketsdataset;
                bindingSourceTicketAccounts.DataMember = "TicketAccounts";
                NewTicketHeader = ticketsdataset.TicketHeader.NewTicketHeaderRow();

                NewTicketHeader.AccountNumber = productionMainTables.CUSTOMER.Rows[0].Field<Int32>("CustomerID");
                NewTicketHeader.DealerNumber = productionMainTables.CUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER");
                NewTicketHeader.Date = DateTime.Now.Date;
                NewTicketHeader.MadeBy = Program.gsUserID.TrimEnd();
                ticketsdataset.TicketHeader.AddTicketHeaderRow(NewTicketHeader);
                bindingSourceTicketHeader.MoveLast(); // Moses Newman 05/27/2021 Move to the new Header Record Just Created.

                aCCOUNTTableAdapter.FillByAll(productionMainTables.ACCOUNT);
                textBoxMadeBy.Text = Program.gsUserID + " " + Program.gsUserName;

                buttonReprint.Enabled = false;
                buttonAdd.Enabled = true;
                buttonCancelTicket.Enabled = true;
                textBoxTicketID.Text = "NEW TICKET";
                textBoxTicketID.Refresh();

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
            int? insertID = 0,lnSeq;
            Boolean MissingPayType = false, MissingPayCode = false;
            Object loContingentSeq = null;
            Char NotPosted = '\u00FF';

            if (checkBoxCloseOut.Checked)
            {
                for (int i = 0; i < ticketsdataset.TicketDetail.Rows.Count; i++)
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
                if (MissingPayType || MissingPayCode)
                {
                    MessageBox.Show("*** All rows EXCEPT for NOTES RECEIVABLE MUST have a Paymtent Type and a Payment Code on a closeout ticket! ***",
                        "Payment Type and / or Code Missing", MessageBoxButtons.OK);
                    return;
                }
            }
            ticketHeaderTableAdapter.Insert(ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber"),
            ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("DealerNumber").PadLeft(3,'0'),
            ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<DateTime>("Date"),
            ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"),
            ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("ApprovedBy"),
            ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("Explanation"),
            ref insertID);

            for (int i = 0;i < ticketsdataset.TicketDetail.Rows.Count; i++)
            {
                ticketsdataset.TicketDetail.Rows[i].SetField<Int32>("TicketID", (Int32)insertID);
                if (ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") != 2 && ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount")!=7)
                {
                    NewPayment = productionMainTables.PAYMENT.NewPAYMENTRow();
                    NewPayment.PAYMENT_CUSTOMER = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0');
                    NewPayment.PAYMENT_ADD_ON = "";
                    NewPayment.PAYMENT_IAC_TYPE = "C";
                    NewPayment.PAYMENT_DATE = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<DateTime>("Date");
                    NewPayment.PAYMENT_DEALER = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("DealerNumber");
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
                    productionMainTables.PAYMENT.AddPAYMENTRow(NewPayment);

                    if (ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount") != 1)
                    {
                        NewConting = productionMainTables.CONTING.NewCONTINGRow();
                        NewConting.CONTING_DEALER = ticketsdataset.TicketDetail.Rows[i].Field<String>("SubDealer") != "" &&
                                                        ticketsdataset.TicketDetail.Rows[i].Field<String>("SubDealer") != null ?
                                                            ticketsdataset.TicketDetail.Rows[i].Field<String>("SubDealer") : NewPayment.PAYMENT_DEALER;
                        NewConting.CONTING_POST_DATE = NewPayment.PAYMENT_DATE;
                        loContingentSeq = CONTINGTableAdapter.MaxSeqQuery(NewConting.CONTING_DEALER, NewPayment.PAYMENT_DATE);
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

                        switch (ticketsdataset.TicketDetail.Rows[i].Field<Int32>("GLAccount"))
                        {
                            case 3: // CONTINGENT RESERVE
                                NewConting.CONTING_CONTRACT = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                NewConting.CONTING_CONTRACT_COMMENT = NewPayment.PAYMENT_CUSTOMER;
                                break;
                            case 4: // ADJUST ACCOUNT A/A
                                NewConting.CONTING_ADJUST = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                NewConting.CONTING_ADJUST_COMMENT = NewPayment.PAYMENT_CUSTOMER;
                                break;
                            case 5: // DEALER ADJUST A/A REMOVE!
                                NewConting.CONTING_ADJUST = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                NewConting.CONTING_ADJUST_COMMENT = NewPayment.PAYMENT_CUSTOMER;
                                break;
                            case 6: // DEALER LOSS RESERVE
                                NewConting.CONTING_LOSS_RES = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                NewConting.CONTING_LOSS_RES_COMMENT = NewPayment.PAYMENT_CUSTOMER;
                                break;
                            /*case 7: // SUNDRY INCOME
                                NewConting.CONTING_LOSS_RES = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                NewConting.CONTING_LOSS_RES_COMMENT = NewPayment.PAYMENT_CUSTOMER;
                                break;*/
                            case 8: // RESERVE FOR LOSSES
                                NewConting.CONTING_RES_LOSS = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                NewConting.CONTING_RES_LOSS_COMMENT = NewPayment.PAYMENT_CUSTOMER;
                                break;
                            case 9: // RECOVERY OF BAD DEBT
                                NewConting.CONTING_RECOV_BAD = ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") != 0 ? ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Debit") : ticketsdataset.TicketDetail.Rows[i].Field<Decimal>("Credit");
                                NewConting.CONTING_RECOV_BAD_COMMENT = NewPayment.PAYMENT_CUSTOMER;
                                break;
                        }
                        productionMainTables.CONTING.AddCONTINGRow(NewConting);
                    }
                }
            }
            ticketDetailTableAdapter.Update(ticketsdataset.TicketDetail);
            PAYMENTTableAdapter.Update(productionMainTables.PAYMENT);
            CONTINGTableAdapter.Update(productionMainTables.CONTING);
            PrintTicket((Int32)insertID);
            MoveToTicket((Int32)insertID);
        }

        private void dataListView1_MouseClick(object sender, MouseEventArgs e)
        {
            //System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void MoveToTicket(Int32 tnTicketID)
        {
            dataListView1.Enabled = false;
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
            dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER"));
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
            dataListView1.Enabled = false;
            Int32 lnTicketID = 0,FoundIndex = 0;
            if(ticketsdataset.TicketHeader.Rows.Count == 1)
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
                ticketDetailTableAdapter.FillByTicketID(ticketsdataset.TicketDetail, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            }
            else
                return;
            cUSTOMERTableAdapter.Fill(productionMainTables.CUSTOMER, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0'));
            dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER"));
            GetTrialBalance();
            ULISTTableAdapter.FillById(productionMainTables.ULIST, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"));
            textBoxMadeBy.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy") + " " + productionMainTables.ULIST.Rows[0].Field<String>("LIST_NAME");
            buttonReprint.Enabled = true;
            textBoxTicketID.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID").ToString().Trim();
            textBoxTicketID.Refresh();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (buttonCancelTicket.Enabled)
                return;
            dataListView1.Enabled = false;
            buttonAdd.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonClearDetail.Enabled = false;
            buttonReprint.Enabled = false;
            buttonCancelTicket.Enabled = false;
            bindingSourceTicketHeader.MoveNext();
            richTextBox1.Enabled = false;
            if (bindingSourceTicketHeader.Position > -1)
            {
                ticketDetailTableAdapter.FillByTicketID(ticketsdataset.TicketDetail, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID"));
            }
            else
                return;
            cUSTOMERTableAdapter.Fill(productionMainTables.CUSTOMER, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("AccountNumber").ToString().PadLeft(6, '0'));
            dEALERTableAdapter.Fill(productionMainTables.DEALER, productionMainTables.CUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER"));
            GetTrialBalance();
            ULISTTableAdapter.FillById(productionMainTables.ULIST, ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy"));
            textBoxMadeBy.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<String>("MadeBy") + " " + productionMainTables.ULIST.Rows[0].Field<String>("LIST_NAME");
            buttonReprint.Enabled = true;
            textBoxTicketID.Text = ticketsdataset.TicketHeader.Rows[bindingSourceTicketHeader.Position].Field<Int32>("TicketID").ToString().Trim();
            textBoxTicketID.Refresh();
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
            textBoxTicketID.Text = "";
            textBoxTicketID.Refresh();
            ActiveControl = textBoxAccount;
            textBoxAccount.Select();
        }
    }
}

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

        private BindingSource bindingSourceTicketAccounts = new BindingSource();
        private BindingSource bindingSourcePaymentTypes = new BindingSource();
        private BindingSource bindingSourcePaymentCodes = new BindingSource();

        private Tickets.TicketHeaderRow NewTicketHeader;
        private Tickets.TicketDetailRow NewTicketDetail;

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
            buttonClearDetail.Enabled = false;
            buttonSaveTicket.Enabled = false;
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

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (productionMainTables.CUSTOMER.Rows.Count == 0)
                return;
            bindingSourceTicketDetail.MoveLast();
            NewTicketDetail = ticketsdataset.TicketDetail.NewTicketDetailRow();
            NewTicketDetail.TicketID = ticketsdataset.TicketHeader.Rows[0].Field<Int32>("TicketID");
            NewTicketDetail.DetailID = bindingSourceTicketDetail.Position + 2;
            ticketsdataset.TicketDetail.AddTicketDetailRow(NewTicketDetail);
            ticketsdataset.TicketDetail.Rows[bindingSourceTicketDetail.Position].SetField<Int32>("DetailID", bindingSourceTicketDetail.Position + 1);
            bindingSourceTicketDetail.MoveLast();
            dataListView1.Refresh();
            this.Refresh();
            buttonAdd.Enabled = true;
            buttonClearDetail.Enabled = true;
        }

        private void dataListView1_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            Int32 cindex = e.Column.Index;

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
                aCCOUNTTableAdapter.FillByAll(productionMainTables.ACCOUNT);
                textBoxMadeBy.Text = Program.gsUserID + " " + Program.gsUserName;

                buttonReprint.Enabled = false;
                buttonAdd.Enabled = true;

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
            int? insertID = 0;

            ticketHeaderTableAdapter.Insert(ticketsdataset.TicketHeader.Rows[0].Field<Int32>("AccountNumber"),
                ticketsdataset.TicketHeader.Rows[0].Field<String>("DealerNumber"),
                ticketsdataset.TicketHeader.Rows[0].Field<DateTime>("Date"),
                ticketsdataset.TicketHeader.Rows[0].Field<String>("MadeBy"),
                ticketsdataset.TicketHeader.Rows[0].Field<String>("ApprovedBy"),
                ticketsdataset.TicketHeader.Rows[0].Field<String>("Explanation"),
                ref insertID);

            for (int i = 0; i < ticketsdataset.TicketDetail.Rows.Count; i++)
                ticketsdataset.TicketDetail.Rows[i].SetField<Int32>("TicketID",(Int32)insertID);
            ticketDetailTableAdapter.Update(ticketsdataset.TicketDetail);

            PrintTicket((Int32)insertID);

            ticketsdataset.TicketHeader.Clear();
            ticketsdataset.TicketDetail.Clear();
            productionMainTables.CUSTOMER.Clear();
            productionMainTables.DEALER.Clear();
            textBoxAccount.Text = "";
            ActiveControl = textBoxAccount;
            textBoxAccount.Select();
            this.Close();
        }

        private void dataListView1_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {

        }

        private void dataListView1_MouseClick(object sender, MouseEventArgs e)
        {
            //System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
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
            bindingSourceTicketHeader.MovePrevious();
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
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
            buttonSaveTicket.Enabled = false;
            buttonClearDetail.Enabled = false;
            buttonReprint.Enabled = false;
            bindingSourceTicketHeader.MoveNext();
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

            //myReportObject.SetDataSource(ticketsdataset);

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
    }
}

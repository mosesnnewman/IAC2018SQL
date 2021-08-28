using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace IAC2021SQL
{
    public partial class frmClosedImportPCPAYFile : Form
    {

        private Object loISFDate = null;
        private DateTime ldISFDate = DateTime.Now.Date;

        public frmClosedImportPCPAYFile()
        {
            InitializeComponent();
        }        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ReadPCPAYFILE(IACDataSet PCPAY)
        {
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            IACDataSetTableAdapters.PCPAYTableAdapter PCPAYTableAdapter = new IACDataSetTableAdapters.PCPAYTableAdapter();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
            IACDataSetTableAdapters.InternetPaymentsTableAdapter InternetPaymentsTableAdapter = new IACDataSetTableAdapters.InternetPaymentsTableAdapter();
            IACDataSetTableAdapters.InternetPayRejectsTableAdapter InternetPayRejectsTableAdapter = new IACDataSetTableAdapters.InternetPayRejectsTableAdapter();

            BindingSource InternetPaymentsBindingsource = new BindingSource();
            InternetPaymentsBindingsource.DataSource = PCPAY.InternetPayments;
            BindingSource PCPAYBindingSource = new BindingSource();

            BindingSource InternetPayRejectsBindingSource = new BindingSource();
            BindingSource PAYMENTBindingSource = new BindingSource();

            InternetPayRejectsBindingSource.DataSource = PCPAY.InternetPayRejects;

            InternetPayRejectsTableAdapter.DeleteAll(); PCPAYTableAdapter.DeleteAll();
            if (SQLBR.RunJob("ClosedPCPAY", "Closed PCPAY"))
            {
                Thread.Sleep(5000);
                PCPAYTableAdapter.UpdateFromCustomer();
                try
                {
                    PCPAYTableAdapter.FillByAll(PCPAY.PCPAY);
                }
                catch
                {
                    PCPAYTableAdapter.FillByAll(PCPAY.PCPAY);
                }
                PCPAYBindingSource.DataSource = PCPAY.PCPAY;
                InternetPaymentsTableAdapter.DeleteAll();
                InternetPayRejectsTableAdapter.DeleteAll();
                for (Int32 i = 0; i < PCPAY.PCPAY.Rows.Count; i++)
                {
                    if (InternetPaymentsBindingsource.Find("CustomerNo", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER")) == -1)
                    {
                        InternetPaymentsBindingsource.AddNew();
                        InternetPaymentsBindingsource.EndEdit();
                        PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("CustomerNo", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER"));
                        PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("IACType", "C");
                        PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("SocialSecurityNo",
                            PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_SS_1").TrimEnd() + PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_SS_2").TrimEnd() + PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_SS_3").TrimEnd());
                        if (PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").LastIndexOf(',') >= 0)
                        {
                            PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("LastName",
                                PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(0, PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").TrimEnd().TrimEnd().LastIndexOf(',')));
                            PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("FirstName",
                                PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").TrimEnd().LastIndexOf(',') + 1).TrimEnd());
                        }
                        else
                        {
                            PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("FirstName",
                                PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(0, PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").TrimEnd().LastIndexOf(' ')));
                            PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("LastName",
                                PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").TrimEnd().LastIndexOf(' ') + 1).TrimEnd());
                        }
                        PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<Decimal>("Amount", PCPAY.PCPAY.Rows[i].Field<Decimal>("PCPAY_AMOUNT_RCV"));
                        PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("Source", "I");
                        PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<DateTime>("CreateDate", PCPAY.PCPAY.Rows[i].Field<DateTime>("PCPAY_DATE"));
                        switch (PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_TYPE").ToUpper().TrimEnd())
                        {
                            case "CREDIT":
                                PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("PaymentType", "P");
                                break;
                            case "DEBIT":
                                PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("PaymentType", "I");
                                break;
                            case "SALE":
                                PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("PaymentType", "V");
                                break;
                        }
                        switch (PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].Field<String>("PaymentType"))
                        {
                            case "P":
                                PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("PaymentCode", "N");
                                break;
                            case "I":
                                PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("PaymentCode", "N");
                                break;
                            case "V":
                                PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("PaymentCode", "V");
                                break;
                        }
                        // Moses Newman 04/10/2014 add email address 
                        PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].SetField<String>("EmailAddress", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_EMAIL").TrimEnd());
                    }
                    else
                    {
                       
                            InternetPayRejectsBindingSource.AddNew();
                            InternetPayRejectsBindingSource.EndEdit();
                            PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("CustomerNo", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER"));
                            PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("IACType", "C");
                            PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Status", "A");
                            if (PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").LastIndexOf(',') >= 0)
                            {
                                PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("FirstName", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(0, PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").TrimEnd().LastIndexOf(' ')));
                                PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("LastName", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(0, PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").TrimEnd().TrimEnd().LastIndexOf(',')));
                            }
                            else
                            {
                                PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("FirstName", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(0, PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").TrimEnd().LastIndexOf(' ')));
                                PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("LastName", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").TrimEnd().LastIndexOf(' ') + 1).TrimEnd());
                            }
                            PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<Decimal>("Amount", PCPAY.PCPAY.Rows[i].Field<Decimal>("PCPAY_AMOUNT_RCV"));
                            switch (PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_TYPE").ToUpper().TrimEnd())
                            {
                                case "CREDIT":
                                    PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentType", "P");
                                    break;
                                case "DEBIT":
                                    PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentType", "I");
                                    break;
                                case "SALE":
                                    PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentType", "V");
                                    break;
                            }
                            switch (PCPAY.InternetPayments.Rows[InternetPaymentsBindingsource.Position].Field<String>("PaymentType"))
                            {
                                case "P":
                                    PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentCode", "D");
                                    break;
                                case "I":
                                    PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentCode", "D");
                                    break;
                                case "V":
                                    PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentCode", "D");
                                    break;
                            }
                            PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Source", "I");
                            PCPAY.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Reason", "*** CUSTOMER MADE MUTLIPLE PAYMENTS! ***");
                            InternetPayRejectsBindingSource.EndEdit();
                    }
                }
                InternetPayRejectsTableAdapter.Update(PCPAY.InternetPayRejects);
                InternetPaymentsBindingsource.EndEdit();
                InternetPaymentsTableAdapter.Update(PCPAY.InternetPayments);
            }
            PCPAY.PCPAY.Clear();
            PCPAY.InternetPayments.Clear();
            PCPAYTableAdapter.Dispose();
            DataPathTableAdapter.Dispose();
            PCPAYBindingSource.Dispose();
            PCPAY.Dispose();
            InternetPaymentsTableAdapter.Dispose();
            InternetPaymentsBindingsource.Dispose();
            InternetPayRejectsTableAdapter.Dispose();
            InternetPayRejectsBindingSource.Dispose();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            IACDataSet AUTOBANK = new IACDataSet();
            ReadPCPAYFILE(AUTOBANK);

            Int32 PaymentPos = 0;

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            IACDataSetTableAdapters.InternetPaymentsTableAdapter InternetPaymentsTableAdapter = new IACDataSetTableAdapters.InternetPaymentsTableAdapter();
            IACDataSetTableAdapters.InternetPayRejectsTableAdapter InternetPayRejectsTableAdapter = new IACDataSetTableAdapters.InternetPayRejectsTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            IACDataSetTableAdapters.EmailTableAdapter EmailTableAdapter = new IACDataSetTableAdapters.EmailTableAdapter();

            BindingSource InternetPayRejectsBindingSource = new BindingSource();
            BindingSource PAYMENTBindingSource  = new BindingSource();

            InternetPayRejectsBindingSource.DataSource       = AUTOBANK.InternetPayRejects;
            PAYMENTBindingSource.DataSource  = AUTOBANK.PAYMENT;

            InternetPaymentsTableAdapter.FillByAllClosedPayments(AUTOBANK.InternetPayments);
            if (AUTOBANK.InternetPayments.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO Payments in payment file! ***");
                return;
            }

            PAYMENTTableAdapter.FillByAll(AUTOBANK.PAYMENT);
            for (Int32 i = 0; i < AUTOBANK.InternetPayments.Rows.Count; i++)
            {
                PaymentPos = PAYMENTBindingSource.Find("PAYMENT_CUSTOMER", AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"));
                if (PaymentPos != -1)
                {
                    InternetPayRejectsBindingSource.AddNew();
                    InternetPayRejectsBindingSource.EndEdit();
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"));
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("IACType", "C");
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Status", "A");
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("FirstName", AUTOBANK.InternetPayments.Rows[i].Field<String>("FirstName"));
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("LastName", AUTOBANK.InternetPayments.Rows[i].Field<String>("LastName"));
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<Decimal>("Amount", AUTOBANK.InternetPayments.Rows[i].Field<Decimal>("Amount"));
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentType", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentType"));
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentCode", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentCode"));
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Source", AUTOBANK.InternetPayments.Rows[i].Field<String>("Source"));
                    AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Reason", "*** CUSTOMER ALREADY HAS A PAYMENT! ***");
                    InternetPayRejectsBindingSource.EndEdit();
                    InternetPaymentsTableAdapter.Delete(AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"), "C", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentCode"),
                        "R", "E");
                    continue;
                }

                CUSTOMERTableAdapter.Fill(AUTOBANK.CUSTOMER, AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"));
                if (AUTOBANK.CUSTOMER.Rows.Count == 0)
                {
                        InternetPayRejectsBindingSource.AddNew();
                        InternetPayRejectsBindingSource.EndEdit();
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("IACType", "C");
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Status", "D");
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("FirstName", AUTOBANK.InternetPayments.Rows[i].Field<String>("FirstName"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("LastName", AUTOBANK.InternetPayments.Rows[i].Field<String>("LastName"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<Decimal>("Amount", AUTOBANK.InternetPayments.Rows[i].Field<Decimal>("Amount"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentType", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentType"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentCode", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentCode"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Source", AUTOBANK.InternetPayments.Rows[i].Field<String>("Source"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Reason", "*** CUSTOMER IS NOT ON FILE! ***");
                        InternetPayRejectsBindingSource.EndEdit();
                        continue;
                }
                if(AUTOBANK.CUSTOMER.Rows[0].Field<String>("CUSTOMER_ACT_STAT") == "I")
                {
                        InternetPayRejectsBindingSource.AddNew();
                        InternetPayRejectsBindingSource.EndEdit();
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("IACType", "C");
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Status", "I");
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("FirstName", AUTOBANK.InternetPayments.Rows[i].Field<String>("FirstName"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("LastName", AUTOBANK.InternetPayments.Rows[i].Field<String>("LastName"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<Decimal>("Amount", AUTOBANK.InternetPayments.Rows[i].Field<Decimal>("Amount"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentType", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentType"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("PaymentCode", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentCode"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Source", AUTOBANK.InternetPayments.Rows[i].Field<String>("Source"));
                        AUTOBANK.InternetPayRejects.Rows[InternetPayRejectsBindingSource.Position].SetField<String>("Reason", "*** CUSTOMER IS NOT ACTIVE! ***");
                        InternetPayRejectsBindingSource.EndEdit();
                        continue;
                }
                PAYMENTBindingSource.AddNew();
                PAYMENTBindingSource.EndEdit();
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_CUSTOMER", AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"));
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_ADD_ON", " ");
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "C");
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<DateTime>("PAYMENT_DATE", DateTime.Now.Date);
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_DEALER", AUTOBANK.CUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER"));
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<Decimal>("PAYMENT_AMOUNT_RCV", AUTOBANK.InternetPayments.Rows[i].Field<Decimal>("Amount"));
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_TYPE", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentType"));
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_CODE_2", AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentCode"));
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_AUTO_PAY", "N");
                AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_TSB_COMMENT_CODE", AUTOBANK.CUSTOMER.Rows[0].Field<String>("CUSTOMER_TSB_COMMENT_CODE"));
                // Moses Newman 03/26/2014 handle bounced checks with proper ISF date of original check.
                if(AUTOBANK.InternetPayments.Rows[i].Field<String>("PaymentType") == "I")
                {
                    loISFDate = CUSTHISTTableAdapter.LastPowerCheckDate(AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"));
                    if(loISFDate != null)
                        ldISFDate = ((DateTime)loISFDate);
                    else
                        ldISFDate = DateTime.Now.Date;
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<DateTime>("PAYMENT_ISF_DATE", ldISFDate);
                }
                PAYMENTBindingSource.EndEdit();
                EmailTableAdapter.Fill(AUTOBANK.Email,AUTOBANK.InternetPayments.Rows[i].Field<String>("CustomerNo"));
                // Moses Newman 04/10/2014 Add email address if included in InternetTransactions file and NOT yet in the EMAIL table.
                if (AUTOBANK.Email.Rows.Count > 0)
                    if (AUTOBANK.InternetPayments.Rows[i].Field<String>("EmailAddress").TrimEnd() != "")
                    {
                        if (AUTOBANK.Email.Rows[0].Field<String>("EmailAddress") == null)
                            AUTOBANK.Email.Rows[0].SetField<String>("EmailAddress", "");
                        if (AUTOBANK.Email.Rows[0].Field<String>("EmailAddress").TrimEnd().IndexOf(AUTOBANK.InternetPayments.Rows[i].Field<String>("EmailAddress").TrimEnd()) == -1)
                        {
                            if (AUTOBANK.Email.Rows[0].Field<String>("EmailAddress").TrimEnd() != "")
                                AUTOBANK.Email.Rows[0].SetField<String>("EmailAddress", AUTOBANK.Email.Rows[0].Field<String>("EmailAddress").TrimEnd() + ";" + AUTOBANK.InternetPayments.Rows[i].Field<String>("EmailAddress").TrimEnd());
                            else
                                AUTOBANK.Email.Rows[0].SetField<String>("EmailAddress", AUTOBANK.InternetPayments.Rows[i].Field<String>("EmailAddress").TrimEnd());
                            EmailTableAdapter.Update(AUTOBANK.Email.Rows[0]);
                        }
                    }

            }
            try
            {
                InternetPayRejectsTableAdapter.Update(AUTOBANK.InternetPayRejects);
                PAYMENTTableAdapter.Update(AUTOBANK.PAYMENT);
            }
            finally
            {
                MessageBox.Show("*** Closed PCPAY transfer completed successfully! ***");

                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                if (AUTOBANK.InternetPayRejects.Rows.Count != 0)
                {
                    Hide();
                    MDImain.CreateFormInstance("ReportViewer", false);
                    ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                    InternetPaymentRejects myReportObject = new InternetPaymentRejects();
                    myReportObject.SetDataSource(AUTOBANK);
                    myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                    myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                    myReportObject.SetParameterValue("gsTitle", "CLOSED END INTERNET PAYMENT REJECTS REPORT");
                    rptViewer.crystalReportViewer.ReportSource = myReportObject;
                    rptViewer.crystalReportViewer.Refresh();
                    rptViewer.Show();
                }

                Close();
                InternetPaymentsTableAdapter.DeleteAll();
            }
            InternetPaymentsTableAdapter.Dispose();
            InternetPayRejectsTableAdapter.Dispose();
            CUSTOMERTableAdapter.Dispose();
            PAYMENTTableAdapter.Dispose();
            InternetPayRejectsBindingSource.Dispose();
            PAYMENTBindingSource.Dispose();
            AUTOBANK.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace IAC2018SQL
{
    public partial class frmImportPCPAYFile : Form
    {

        public frmImportPCPAYFile()
        {
            InitializeComponent();
        }

        private void frmImportPCPAYFile_Load(object sender, EventArgs e)
        {
        }
        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ReadPCPAYFILE(IACDataSet PCPAY)
        {
            IACDataSetTableAdapters.PCPAYTableAdapter PCPAYTableAdapter = new IACDataSetTableAdapters.PCPAYTableAdapter();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
            IACDataSetTableAdapters.AutomaticPaymentsTableAdapter AutomaticPaymentsTableAdapter = new IACDataSetTableAdapters.AutomaticPaymentsTableAdapter();

            BindingSource AutomaticPaymentsBindingsource = new BindingSource();
            AutomaticPaymentsBindingsource.DataSource = PCPAY.AutomaticPayments;

            BindingSource PCPAYBindingSource = new BindingSource();
            PCPAYBindingSource.DataSource = PCPAY.PCPAY;


            OpenFileDialog OFD = new OpenFileDialog();

            DataPathTableAdapter.Fill(PCPAY.DataPath);

            String  sourcePath = PCPAY.DataPath.Rows[0].Field<String>("Path").TrimEnd(),
                    InputRow = "";
            DateTime ldPayDate;

            sourcePath += @"comp1000\";
            OFD.AddExtension = false;
            OFD.CheckFileExists = true;
            OFD.DefaultExt = "";
            OFD.CheckPathExists = true;
            OFD.InitialDirectory = sourcePath;
            OFD.ShowDialog();
            // Moses Newman 05/1/2014 use path chosen by user as well as file name! 
            sourcePath = OFD.FileName;

            StreamReader strmrd = new StreamReader(sourcePath, false);

            PCPAYTableAdapter.DeleteAll();
            while ((InputRow = strmrd.ReadLine()) != null)
            {
                if (InputRow.Substring(0, 9) == "999999999")
                    break;
                else
                {
                    // Moses Newman PCPAY_DATE was converted to an actual DateTime field for closed PCPAY program
                    DateTime.TryParse(InputRow.Substring(57, 6), out ldPayDate);
                    if (ldPayDate.Year < 2014)
                        ldPayDate = DateTime.Now.Date;
                    PCPAYBindingSource.AddNew();
                    PCPAYBindingSource.EndEdit();
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<String>("PCPAY_SS_1",InputRow.Substring(0,3));
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<String>("PCPAY_SS_2",InputRow.Substring(3,2));
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<String>("PCPAY_SS_3",InputRow.Substring(5,4));
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<String>("PCPAY_CUSTOMER",InputRow.Substring(9,6));
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<String>("PCPAY_COMPANY_NO", InputRow.Substring(24, 8).TrimEnd());
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<String>("PCPAY_CUSTOMER_NAME", InputRow.Substring(37, 20));
                    // Moses Newman PCPAY_DATE was converted to an actual DateTime field for closed PCPAY program
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<DateTime>("PCPAY_DATE", ldPayDate);
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<Decimal>("PCPAY_AMOUNT_RCV", Convert.ToDecimal(InputRow.Substring(64, 6))/100);
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<Decimal>("PCPAY_LOAN_BALANCE", Convert.ToDecimal(InputRow.Substring(70, 8))/100);
                    PCPAY.PCPAY.Rows[PCPAYBindingSource.Position].SetField<String>("PCPAY_TYPE", InputRow.Substring(79, 1));
                    PCPAYBindingSource.EndEdit();
                }
            }
            PCPAYTableAdapter.Update(PCPAY.PCPAY);
            PCPAY.PCPAY.AcceptChanges();
            AutomaticPaymentsTableAdapter.DeleteAllAllotments();
            for (Int32 i = 0; i < PCPAY.PCPAY.Rows.Count; i++)
            {
                AutomaticPaymentsBindingsource.AddNew();
                AutomaticPaymentsBindingsource.EndEdit();
                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<String>("CustomerNo", PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER"));
                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<String>("IACType", "O");
                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<String>("SocialSecurityNo",
                    PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_SS_1") + PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_SS_2") + PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_SS_3"));
                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<String>("FirstName", 
                    PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(0,PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").LastIndexOf(" ")));

                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<String>("LastName",
                    PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").Substring(PCPAY.PCPAY.Rows[i].Field<String>("PCPAY_CUSTOMER_NAME").LastIndexOf(" ")+1));

                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<Decimal>("Amount", PCPAY.PCPAY.Rows[i].Field<Decimal>("PCPAY_AMOUNT_RCV"));
                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<String>("Source", "A");
                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<DateTime>("CreateDate", DateTime.Now.Date);
                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<String>("PaymentType", "R");
                PCPAY.AutomaticPayments.Rows[AutomaticPaymentsBindingsource.Position].SetField<String>("PaymentCode", "A");
            }
            AutomaticPaymentsBindingsource.EndEdit();
            AutomaticPaymentsTableAdapter.Update(PCPAY.AutomaticPayments);
            strmrd.Close();
            PCPAY.PCPAY.Clear();
            PCPAY.AutomaticPayments.Clear();
            OFD.Dispose();
            PCPAYTableAdapter.Dispose();
            DataPathTableAdapter.Dispose();
            PCPAYBindingSource.Dispose();
            PCPAY.Dispose();
            AutomaticPaymentsTableAdapter.Dispose();
            AutomaticPaymentsBindingsource.Dispose();
        }

        public virtual void buttonTransfer_Click(object sender, EventArgs e)
        {
            IACDataSet AUTOBANK = new IACDataSet();
            ReadPCPAYFILE(AUTOBANK);

            Int32 PaymentPos = 0;
           
            IACDataSetTableAdapters.OPNCUSTTableAdapter  OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.AutomaticPaymentsTableAdapter AutomaticPaymentsTableAdapter = new IACDataSetTableAdapters.AutomaticPaymentsTableAdapter();
            IACDataSetTableAdapters.AutoPayRejectsTableAdapter AutoPayRejectsTableAdapter = new IACDataSetTableAdapters.AutoPayRejectsTableAdapter();
            IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();

            BindingSource AutoPayRejectsBindingSource = new BindingSource();
            BindingSource OPNPAYBindingSource  = new BindingSource();

            AutoPayRejectsBindingSource.DataSource       = AUTOBANK.AutoPayRejects;
            AutoPayRejectsTableAdapter.DeleteAll();
            OPNPAYBindingSource.DataSource  = AUTOBANK.OPNPAY;

            AutomaticPaymentsTableAdapter.FillByAllAllotments(AUTOBANK.AutomaticPayments);
            if (AUTOBANK.AutomaticPayments.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO Allotment Payments in payment file! ***");
                return;
            }
            OPNPAYTableAdapter.CustomizeFill("SELECT * FROM OPNPAY");
            OPNPAYTableAdapter.CustomFillBy(AUTOBANK.OPNPAY);
            for (Int32 i = 0; i < AUTOBANK.AutomaticPayments.Rows.Count; i++)
            {
                PaymentPos = OPNPAYBindingSource.Find("PAYMENT_CUSTOMER", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                if (PaymentPos != -1)
                {
                    AutoPayRejectsBindingSource.AddNew();
                    AutoPayRejectsBindingSource.EndEdit();
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("IACType", "O");
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Status", "A");
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("FirstName", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("FirstName"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("LastName", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("LastName"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<Decimal>("Amount", AUTOBANK.AutomaticPayments.Rows[i].Field<Decimal>("Amount"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("PaymentType", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentType"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("PaymentCode", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentCode"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Source", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("Source"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Reason", "*** CUSTOMER ALREADY HAS A PAYMENT! ***");
                    AutoPayRejectsBindingSource.EndEdit();
                    AutomaticPaymentsTableAdapter.Delete(AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"), "O", "E",
                        "R", "E");
                    continue;
                }

                OPNCUSTTableAdapter.Fill(AUTOBANK.OPNCUST, AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                if (AUTOBANK.OPNCUST.Rows.Count == 0)
                {
                        AutoPayRejectsBindingSource.AddNew();
                        AutoPayRejectsBindingSource.EndEdit();
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("IACType", "O");
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Status", "D");
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("FirstName", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("FirstName"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("LastName", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("LastName"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<Decimal>("Amount", AUTOBANK.AutomaticPayments.Rows[i].Field<Decimal>("Amount"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("PaymentType", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentType"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("PaymentCode", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentCode"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Source", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("Source"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Reason", "*** CUSTOMER IS NOT ON FILE! ***");
                        AutoPayRejectsBindingSource.EndEdit();
                        continue;
                }
                if(AUTOBANK.OPNCUST.Rows[0].Field<String>("CUSTOMER_ACT_STAT") == "I")
                {
                        AutoPayRejectsBindingSource.AddNew();
                        AutoPayRejectsBindingSource.EndEdit();
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("IACType", "O");
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Status", "I");
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("FirstName", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("FirstName"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("LastName", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("LastName"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<Decimal>("Amount", AUTOBANK.AutomaticPayments.Rows[i].Field<Decimal>("Amount"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("PaymentType", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentType"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("PaymentCode", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentCode"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Source", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("Source"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Reason", "*** CUSTOMER IS NOT ACTIVE! ***");
                        AutoPayRejectsBindingSource.EndEdit();
                        continue;
                }
                OPNPAYBindingSource.AddNew();
                OPNPAYBindingSource.EndEdit();
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_CUSTOMER", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_ADD_ON", " ");
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "O");
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<DateTime>("PAYMENT_DATE", DateTime.Now.Date);
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_DEALER", AUTOBANK.OPNCUST.Rows[0].Field<String>("CUSTOMER_DEALER"));
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<Decimal>("PAYMENT_AMOUNT_RCV", AUTOBANK.AutomaticPayments.Rows[i].Field<Decimal>("Amount"));
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_TYPE", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentType"));
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_CODE_2", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentCode"));
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_AUTO_PAY", "N");
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_ALLOTMENT", "Y");
                AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_TSB_COMMENT_CODE", AUTOBANK.OPNCUST.Rows[0].Field<String>("CUSTOMER_TSB_COMMENT_CODE"));
                OPNPAYBindingSource.EndEdit();
            }
            try
            {
                AutoPayRejectsTableAdapter.Update(AUTOBANK.AutoPayRejects);
                OPNPAYTableAdapter.Update(AUTOBANK.OPNPAY);
            }
            finally
            {
                MessageBox.Show("*** PCPAY transfer completed successfully! ***");

                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                if (AUTOBANK.AutoPayRejects.Rows.Count != 0)
                {
                    Hide();
                    MDImain.CreateFormInstance("ReportViewer", false);
                    ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                    AutoPaymentRejects myReportObject = new AutoPaymentRejects();
                    myReportObject.SetDataSource(AUTOBANK);
                    myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                    myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                    myReportObject.SetParameterValue("gsTitle", "PCPAY REJECTS REPORT");
                    rptViewer.crystalReportViewer.ReportSource = myReportObject;
                    rptViewer.crystalReportViewer.Refresh();
                    rptViewer.Show();
                }

                Close();
                AutomaticPaymentsTableAdapter.DeleteAllEFT();
            }
            AutomaticPaymentsTableAdapter.Dispose();
            AutoPayRejectsTableAdapter.Dispose();
            OPNCUSTTableAdapter.Dispose();
            OPNPAYTableAdapter.Dispose();
            AutoPayRejectsBindingSource.Dispose();
            OPNPAYBindingSource.Dispose();
            AUTOBANK.Dispose();
        }
    }
}

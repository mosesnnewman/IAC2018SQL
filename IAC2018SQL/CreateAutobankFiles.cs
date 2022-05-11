using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace IAC2021SQL
{
    public partial class frmCreateAutoBankFiles : DevExpress.XtraEditors.XtraForm
    {

        public frmCreateAutoBankFiles()
        {
            InitializeComponent();
        }

        private void frmCreateAutoBankFiles_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerBsnkTranDate.EditValue = null;
            labelBankTranDate.Visible = false;
            nullableDateTimePickerBsnkTranDate.Visible = false;
            nullableDateTimePickerCutOffDate.EditValue = DateTime.Now.Date;
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintEFTList(rptViewr);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintEFTList(ReportViewer rptViewer)
        {
            IACDataSet ReportData = new IACDataSet();

            IACDataSetTableAdapters.EFTListTableAdapter EFTListTableAdapter = new IACDataSetTableAdapters.EFTListTableAdapter();
            IACDataSetTableAdapters.AutoPayRejectsTableAdapter AutoPayRejectsTableAdapter = new IACDataSetTableAdapters.AutoPayRejectsTableAdapter();
            AutoPayRejectsTableAdapter.FillByAll(ReportData.AutoPayRejects);

            Int32 lnDueDay = (textBoxDayDue.Text.TrimEnd() != "") ? Convert.ToInt32(textBoxDayDue.Text.TrimEnd()):0;

            if (nullableDateTimePickerCutOffDate.EditValue != null)
                if (lnDueDay != 0)
                    EFTListTableAdapter.FillByDayDuewithCutOff(ReportData.EFTList, lnDueDay, (DateTime)nullableDateTimePickerCutOffDate.EditValue);
                else
                     EFTListTableAdapter.FillByCutOff(ReportData.EFTList, (DateTime)nullableDateTimePickerCutOffDate.EditValue);
            else
                if (lnDueDay != 0)
                    EFTListTableAdapter.FillByDayDue(ReportData.EFTList, lnDueDay);
                else
                    EFTListTableAdapter.FillByAll(ReportData.EFTList);

            if (ReportData.EFTList.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no EFT Customers for the criteria you entered!!! ***");
            else
            {
                CustomerEFTListing myReportObject = new CustomerEFTListing();
                myReportObject.SetDataSource(ReportData);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject.SetParameterValue("gdCutOff", (Nullable<DateTime>)nullableDateTimePickerCutOffDate.EditValue);
                myReportObject.SetParameterValue("gnDayDue", lnDueDay);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
            if (checkBoxAutobank.Checked)
                CreateAUTOBANKFile(ReportData);
        }

        private void checkBoxAutobank_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutobank.Checked)
            {
                labelBankTranDate.Visible = true;
                nullableDateTimePickerBsnkTranDate.Visible = true;
                nullableDateTimePickerBsnkTranDate.EditValue = DateTime.Now.Date;
            }
            else
            {
                labelBankTranDate.Visible = false;
                nullableDateTimePickerBsnkTranDate.Visible = false;
            }
        }

        private void CreateAUTOBANKFile(IACDataSet AUTOBANK)
        {
            IACDataSetTableAdapters.AutomaticPaymentsTableAdapter AutomaticPaymentsTableAdapter = new IACDataSetTableAdapters.AutomaticPaymentsTableAdapter();
            IACDataSetTableAdapters.AutoPayRejectsTableAdapter  AutoPayRejectsTableAdapter = new IACDataSetTableAdapters.AutoPayRejectsTableAdapter();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();

            BindingSource AutomaticPaymentsBindingSource = new BindingSource();
            AutomaticPaymentsBindingSource.DataSource = AUTOBANK.AutomaticPayments;

            DataPathTableAdapter.Fill(AUTOBANK.DataPath);
            Int32 lnTotalDebit = 0,lnTotalCredit = 0,lnBlockingPercent = 0,lnBlockingFactor = 0;
            Int64 lnHashCount = 0;
            DateTime    ldEffectiveDate = ((DateTime)nullableDateTimePickerBsnkTranDate.EditValue).Date,
                        ldDescriptiveDate = DateTime.Now.Date;
            String sourcePath = AUTOBANK.DataPath.Rows[0].Field<String>("Path").TrimEnd(),
              lsDescriptiveDate = ldDescriptiveDate.Year.ToString().Substring(2, 2) +
                                    ldDescriptiveDate.Month.ToString().PadLeft(2, '0') +
                                    ldDescriptiveDate.Day.ToString().PadLeft(2, '0'),

              lsEffectiveDate = ldEffectiveDate.Year.ToString().Substring(2, 2) +
                                    ldEffectiveDate.Month.ToString().PadLeft(2, '0') +
                                    ldEffectiveDate.Day.ToString().PadLeft(2, '0'),

              lsTime = DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                                    DateTime.Now.Minute.ToString().PadLeft(2, '0'),

              lsABANumber = "221172186",
              lsBankAccount = "6500355242",
              lsBankName = @"PEOPLE'S UNITED BANK";
 


            sourcePath += @"comp1000\AUTOBANK";

            StreamWriter strm = new StreamWriter(sourcePath,false);

            // Create HEADER record for AUTOBANK file
            strm.Write("1");
            strm.Write("1".PadLeft(2,'0'));
            strm.Write(lsABANumber.PadLeft(10));
            //strm.Write("1");
            strm.Write("061278157 ");
            // Moses Newman 04/11/2012 changed Effective Date here to Descriptive Date
            strm.Write(lsDescriptiveDate);
            strm.Write(lsTime);
            strm.Write("A");
            strm.Write("094");
            strm.Write("10");
            strm.Write("1");
            strm.Write((lsBankName).PadRight(23,' '));
            strm.WriteLine("INDUSTRIAL ACCEP".PadRight(31));

            // Create BATCH header record for AUTOBANK file
            strm.Write("5");
            strm.Write("200");
            strm.Write(("INDUSTRIAL ACCEP").PadRight(16));
            strm.Write(" ".PadRight(20));
            //strm.Write("1");
            strm.Write("061278157 ");
            strm.Write("PPD");
            strm.Write("AUTOPAY".PadRight(10));
            strm.Write(lsDescriptiveDate);                     //DESCRIPTIVE-DATE
            strm.Write(lsEffectiveDate);                       //EFFECTIVE-DATE
            strm.Write(" ".PadRight(3));
            strm.Write("1");
            strm.Write(lsABANumber);
            strm.WriteLine("1".PadLeft(6,'0'));

            // Delete last EFT cycle Payments
            AutomaticPaymentsTableAdapter.DeleteAllEFT();
            AutoPayRejectsTableAdapter.DeleteAll();

            for (Int32 i = 0; i < AUTOBANK.EFTList.Rows.Count; i++)
            {
                // Add Records to AutomaticPayments file
                AutomaticPaymentsBindingSource.AddNew();
                AutomaticPaymentsBindingSource.EndEdit();

                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_NO"));
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<String>("IACType", AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_IAC_TYPE"));
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<String>("FirstName", AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_FIRST_NAME"));
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<String>("LastName", AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_LAST_NAME"));
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<String>("SocialSecurityNo", 
                     AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_SS_1") + 
                     AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_SS_2") + 
                     AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_SS_3"));
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<Decimal>("Amount", AUTOBANK.EFTList.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<String>("Source", "E");
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<String>("PaymentType", "R");
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<String>("PaymentCode", "E");
                AUTOBANK.AutomaticPayments.Rows[AutomaticPaymentsBindingSource.Position].SetField<DateTime>("CreateDate", DateTime.Now.Date);
                AutomaticPaymentsBindingSource.EndEdit();

                // Create records for AUTOBANK file                    
                strm.Write("6");
                strm.Write("27");
                strm.Write(AUTOBANK.EFTList.Rows[i].Field<String>("OPNBANK_TRAN_CODE"));
                strm.Write(AUTOBANK.EFTList.Rows[i].Field<String>("OPNBANK_CHECK_DIGIT"));
                strm.Write(AUTOBANK.EFTList.Rows[i].Field<String>("OPNBANK_ACCOUNT_NO").PadRight(17));
                // Moses Newman 10/24/2013 Change CUSTOMER_REGUAR_AMOUNT to OPNBANK_MONTHLY_PAYMENT
                strm.Write(((Int32)(AUTOBANK.EFTList.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT")*100)).ToString().TrimStart().PadLeft(10, '0'));
                strm.Write( (AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_SS_1") + 
                            AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_SS_2") + 
                            AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_SS_3")).PadRight(15));
                // Moses Newman 10/26/2013 Make sure always a space between first and last name!
                strm.Write(((AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_FIRST_NAME").TrimEnd() + " " +AUTOBANK.EFTList.Rows[i].Field<String>("CUSTOMER_LAST_NAME"))).PadRight(22).Substring(0,22));
                strm.Write(" ".PadRight(2));
                strm.Write("0");
                strm.WriteLine(lsABANumber + (i+1).ToString().TrimStart().PadLeft(6, '0'));

                lnHashCount += Convert.ToInt32(AUTOBANK.EFTList.Rows[i].Field<String>("OPNBANK_TRAN_CODE"));
                // Moses Newman 10/24/2013 Change CUSTOMER_REGUAR_AMOUNT to OPNBANK_MONTHLY_PAYMENT
                lnTotalDebit += (Int32)(AUTOBANK.EFTList.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") * 100);
                lnTotalCredit += (Int32)(AUTOBANK.EFTList.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") * 100);
            }

            // Offsetting Record Required by People's Bank
            strm.Write("6");
            strm.Write("22");
            strm.Write(lsABANumber);
            strm.Write(lsBankAccount.PadRight(17));
            strm.Write(lnTotalCredit.ToString().TrimStart().PadLeft(10, '0'));
            strm.Write(" ".PadRight(15));
            strm.Write(("INDUSTRIAL ACCEP").PadRight(24));
            strm.Write("0");
            strm.WriteLine(lsABANumber + AUTOBANK.EFTList.Rows.Count.ToString().TrimStart().PadLeft(6, '0'));
            lnHashCount += Convert.ToInt32(lsABANumber.Substring(0,8));
            AutomaticPaymentsTableAdapter.Update(AUTOBANK.AutomaticPayments);
            AUTOBANK.AutomaticPayments.AcceptChanges();
            // Create BATCH TRAILER record for AUTOBANK file
            strm.Write("8");
            strm.Write("200");
            strm.Write((AUTOBANK.EFTList.Rows.Count + 1).ToString().TrimStart().PadLeft(6,'0'));          // BATCH-RECORD-COUNT +1  to cover offsett entry
            strm.Write(lnHashCount.ToString().TrimStart().PadLeft(10,'0'));                       // BATCH-HASH-NUMBER
            strm.Write(lnTotalDebit.ToString().TrimStart().PadLeft(12,'0'));                        // BATCH-TOTAL-DEBIT
            strm.Write(lnTotalCredit.ToString().TrimStart().PadLeft(12, '0'));                      // BATCH-TOTAL-CREDIT
            strm.Write("061278157 ");
            strm.Write(" ".PadLeft(25));
            strm.Write(lsABANumber);
            strm.WriteLine("1".PadLeft(6,'0'));

            // Create TRAILER record for AUTOBANK file
            // CALCULATE BLOCKING FACTOR
            lnBlockingPercent = ((AUTOBANK.EFTList.Rows.Count + 1) + 4) / 10;
            lnBlockingFactor = lnBlockingPercent;
            if(lnBlockingPercent > 0)
                lnBlockingFactor += 1;
            strm.Write("9");
            strm.Write("1".PadLeft(6,'0'));
            strm.Write(lnBlockingFactor.ToString().TrimStart().PadLeft(6,'0'));                              // TRAILER-BLOCKING
            strm.Write((AUTOBANK.EFTList.Rows.Count +1).ToString().TrimStart().PadLeft(8, '0')); // TRAILER-RECORD-COUNT + 1  for credit offset record
            strm.Write(lnHashCount.ToString().TrimStart().PadLeft(10, '0'));                                // TRAILER-HASH-NUMBER
            strm.Write(lnTotalDebit.ToString().TrimStart().PadLeft(12, '0'));                                 // TRAILER-TOTAL-DEBIT
            strm.WriteLine(lnTotalCredit.ToString().TrimStart().PadLeft(12, '0') + " ".PadRight(39));     // TRAILER-TOTAL-CREDIT
            strm.Flush();
            strm.Close();
            AUTOBANK.AutomaticPayments.Clear();
            AUTOBANK.AutoPayRejects.Clear();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            Int32 PaymentPos = 0;
            IACDataSet AUTOBANK = new IACDataSet();

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.OPNCUSTTableAdapter  OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.AutomaticPaymentsTableAdapter AutomaticPaymentsTableAdapter = new IACDataSetTableAdapters.AutomaticPaymentsTableAdapter();
            IACDataSetTableAdapters.AutoPayRejectsTableAdapter AutoPayRejectsTableAdapter = new IACDataSetTableAdapters.AutoPayRejectsTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();

            BindingSource AutoPayRejectsBindingSource = new BindingSource();
            BindingSource PAYMENTBindingSource = new BindingSource();
            BindingSource OPNPAYBindingSource  = new BindingSource();

            AutoPayRejectsBindingSource.DataSource       = AUTOBANK.AutoPayRejects;
            AutoPayRejectsTableAdapter.DeleteAll();
            PAYMENTBindingSource.DataSource = AUTOBANK.PAYMENT;
            OPNPAYBindingSource.DataSource  = AUTOBANK.OPNPAY;

            AutomaticPaymentsTableAdapter.FillByAllEFT(AUTOBANK.AutomaticPayments);
            if (AUTOBANK.AutomaticPayments.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO EFT Payments in payment file! ***");
                return;
            }
            PAYMENTTableAdapter.FillByAll(AUTOBANK.PAYMENT);
            OPNPAYTableAdapter.FillByAll(AUTOBANK.OPNPAY);
            for (Int32 i = 0; i < AUTOBANK.AutomaticPayments.Rows.Count; i++)
            {
                PaymentPos = PAYMENTBindingSource.Find("PAYMENT_CUSTOMER",AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                if (PaymentPos != -1)
                {
                    AutoPayRejectsBindingSource.AddNew();
                    AutoPayRejectsBindingSource.EndEdit();
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("IACType", "C");
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Status", "A");
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("FirstName", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("FirstName"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("LastName", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("LastName"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<Decimal>("Amount", AUTOBANK.AutomaticPayments.Rows[i].Field<Decimal>("Amount"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("PaymentType", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentType"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("PaymentCode", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentCode"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Source", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("Source"));
                    AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("Reason", "*** CUSTOMER ALREADY HAS A PAYMENT! ***");
                    AutoPayRejectsBindingSource.EndEdit();
                    AutomaticPaymentsTableAdapter.Delete(AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"), "C", "E",
                        "R", "E");
                    continue;
                }
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

                if (AUTOBANK.AutomaticPayments.Rows[i].Field<String>("IACType") == "C")
                {
                    CUSTOMERTableAdapter.Fill(AUTOBANK.CUSTOMER, AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                    if (AUTOBANK.CUSTOMER.Rows.Count == 0)
                    {
                        AutoPayRejectsBindingSource.AddNew();
                        AutoPayRejectsBindingSource.EndEdit();
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("IACType", "C");
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
                    if(AUTOBANK.CUSTOMER.Rows[0].Field<String>("CUSTOMER_ACT_STAT") == "I")
                    {
                        AutoPayRejectsBindingSource.AddNew();
                        AutoPayRejectsBindingSource.EndEdit();
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("CustomerNo", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                        AUTOBANK.AutoPayRejects.Rows[AutoPayRejectsBindingSource.Position].SetField<String>("IACType", "C");
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
                    PAYMENTBindingSource.AddNew();
                    PAYMENTBindingSource.EndEdit();
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_CUSTOMER", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("CustomerNo"));
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_ADD_ON", " ");
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "C");
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<DateTime>("PAYMENT_DATE", DateTime.Now.Date);
                    // Moses Newman 05/02/2022 Dealer Number is now Int32
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<Int32>("PAYMENT_DEALER", AUTOBANK.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<Decimal>("PAYMENT_AMOUNT_RCV", AUTOBANK.AutomaticPayments.Rows[i].Field<Decimal>("Amount"));
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_TYPE", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentType"));
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_CODE_2", AUTOBANK.AutomaticPayments.Rows[i].Field<String>("PaymentCode"));
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_AUTO_PAY", "Y");
                    AUTOBANK.PAYMENT.Rows[PAYMENTBindingSource.Position].SetField<String>("PAYMENT_TSB_COMMENT_CODE", AUTOBANK.CUSTOMER.Rows[0].Field<String>("CUSTOMER_TSB_COMMENT_CODE"));
                    PAYMENTBindingSource.EndEdit();
                }
                else
                {
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
                    AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_AUTO_PAY", "Y");
                    AUTOBANK.OPNPAY.Rows[OPNPAYBindingSource.Position].SetField<String>("PAYMENT_TSB_COMMENT_CODE", AUTOBANK.OPNCUST.Rows[0].Field<String>("CUSTOMER_TSB_COMMENT_CODE"));
                    OPNPAYBindingSource.EndEdit();
                }
            }
            try
            {
                AutoPayRejectsTableAdapter.Update(AUTOBANK.AutoPayRejects);
                PAYMENTTableAdapter.Update(AUTOBANK.PAYMENT);
                OPNPAYTableAdapter.Update(AUTOBANK.OPNPAY);
            }
            finally
            {
                MessageBox.Show("*** EFT Payment transfer completed successfully! ***");

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
                    myReportObject.SetParameterValue("gsTitle", "EFT PAYMENT REJECTS REPORT");
                    rptViewer.crystalReportViewer.ReportSource = myReportObject;
                    rptViewer.crystalReportViewer.Refresh();
                    rptViewer.Show();
                }
                //MDImain.paymentReceiptsBalanceJurnalToolStripMenuItem_Click(sender, e);  //Closed IACRPT7
                //MDImain.paymentReceiptsBalanceJournalToolStripMenuItem1_Click(sender, e); // Open IACRPT7

                Close();
                AutomaticPaymentsTableAdapter.DeleteAllEFT();
            }
            AutomaticPaymentsTableAdapter.Dispose();
            AutoPayRejectsTableAdapter.Dispose();
            CUSTOMERTableAdapter.Dispose();
            OPNCUSTTableAdapter.Dispose();
            OPNPAYTableAdapter.Dispose();
            PAYMENTTableAdapter.Dispose();
            AutoPayRejectsBindingSource.Dispose();
            OPNPAYBindingSource.Dispose();
            PAYMENTBindingSource.Dispose();
            AUTOBANK.Dispose();
        }
    }
}

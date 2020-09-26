using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace IAC2018SQL
{
    public partial class frmCreateTSBExtract : Form
    {
        private Int32 lnACollectionCnt = 0, lnACurrent = 0, lnA30 = 0, lnA60 = 0, lnA90 = 0, lnA120 = 0, lnA150 = 0, lnA180 = 0, lnAOther = 0,
                      lnCollectionAcct = 0, lnDateDiff = 0;
        private Decimal lnACollectionBalance = 0, lnACurrentBalance = 0, lnA30Balance = 0, lnA60Balance = 0, lnA90Balance = 0, lnA120Balance = 0,
                        lnA150Balance = 0, lnA180Balance = 0;

        private Boolean lbBureau = false, CreateFile = false;
        public String lsAcctStatusCode = "", lsAcctPaymentRating = " ", lsTSBCommentCode = "";

        private BackgroundWorker worker = new BackgroundWorker();
        private String lsProgMessage = "";

        public frmCreateTSBExtract()
        {
            InitializeComponent();
        }

        private void frmCreateTSBExtract_Load(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            PaymentDataSet PaySet = new PaymentDataSet();
            IACDataSet TempData = new IACDataSet();
            String lsControlDate = DateTime.Now.Date.ToShortDateString();
            DateTime ldControlDate = DateTime.Now.Date;

            PaymentDataSetTableAdapters.ControlDateTableAdapter ControlDatesTableAdapter = new PaymentDataSetTableAdapters.ControlDateTableAdapter();

            ldControlDate = ((DateTime)ControlDatesTableAdapter.TSB()).Date;

            nullableDateTimePickerControlDate.Value = ldControlDate;
            nullableDateTimePickerFrom.Value = ldControlDate.AddDays(1);
            nullableDateTimePickerTo.Value = ((DateTime)CUSTHISTTableAdapter.LastUPDDate()).Date;
            TempData.Dispose();
            PaySet.Dispose();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateTSBDATAFile(IACDataSet TSBDATA)
        {
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            SQLBR.RunJob("TSBXMLImport", "Create TSB Import XML", false);
            Thread.Sleep(5000);
            SQLBR.Dispose();
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            PaymentDataSetTableAdapters.ControlDateTableAdapter ControlDatesTableAdapter = new PaymentDataSetTableAdapters.ControlDateTableAdapter();
            MDIIAC2013 MDIMain = (MDIIAC2013)MdiParent;
            MDIMain.CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_LoadCustomerCreditManager);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_FillExtractProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Create TSB CUSTOMER Extract File (ICMEXTR)";
            lfrm.lblProgress.Text = "Creating TSB Customer Extract File";
            lfrm.ShowDialog();
            lfrm.Close();
            // Moses Newmn 09/01/2020 Update ControlDate!
            ControlDatesTableAdapter.TSBUpdateControlDate((DateTime)nullableDateTimePickerTo.Value);
            Close();
        }

        private void worker_LoadCustomerCreditManager(object sender, DoWorkEventArgs e)
        {
            IACDataSet TSBDATA = new IACDataSet();
            TSBDataSet tsbSet = new TSBDataSet();
            String lsCreditBureau = (!checkBoxIgnoreBureauSwitch.Checked) ? "Y%" : "%";   // Get all Active customers if Ignore Credit Bureau Switch checkbox is checked

            DateTime ldControlDate = (DateTime)nullableDateTimePickerControlDate.Value;
            IACDataSetTableAdapters.ClosedWSHISTTableAdapter ClosedWSHISTTableAdapter = new IACDataSetTableAdapters.ClosedWSHISTTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            IACDataSetTableAdapters.OpenWSHISTTableAdapter OpenWSHISTTableAdapter = new IACDataSetTableAdapters.OpenWSHISTTableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            TSBDataSetTableAdapters.ClosedCreditManagerTableAdapter ClosedCreditManagerTableAdapter = new TSBDataSetTableAdapters.ClosedCreditManagerTableAdapter();

            BindingSource ClosedCreditManagerBindingSource = new BindingSource();
            // Moses Newman 08/24/2020 Stop clearing CreditManagerTable!
            //ClosedCreditManagerTableAdapter.DeleteAll(); 
            // Moses Newman 05/3/2014 Get rid of SQL Pass Through!
            CUSTOMERTableAdapter.FillByPaidInLast5Years(TSBDATA.CUSTOMER, lsCreditBureau, (DateTime)nullableDateTimePickerTo.Value);
            if (TSBDATA.CUSTOMER.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO CUSTOMERS to transfer! ***");
                return;
            }


            Decimal lnProg = 0;
            ClosedCreditManagerTableAdapter.FillByAll(tsbSet.ClosedCreditManager);
            String AccountNumber;
            Boolean NewAccount = false;
            for (Int32 i = 0; i < TSBDATA.CUSTOMER.Rows.Count; i++)
            {
                NewAccount = false;
                lnProg = ((Decimal)(i + 1) / (Decimal)TSBDATA.CUSTOMER.Rows.Count) * (Decimal)100;
                lsProgMessage = "Inserting Closed Customer Records Into ClosedCustomerCreditManager" + "\n" + "Record: " + (i + 1).ToString().TrimStart() + " of " + TSBDATA.CUSTOMER.Rows.Count.ToString() + ".";
                worker.ReportProgress((Int32)lnProg);

                ProcessCustomer(TSBDATA, i);
                AccountNumber = TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO");
                ClosedCreditManagerTableAdapter.FillByPortfolioType(tsbSet.ClosedCreditManager, AccountNumber,"I");
                ClosedCreditManagerBindingSource.DataSource = tsbSet.ClosedCreditManager;
                ClosedCreditManagerBindingSource.MoveFirst();

                // Moses Newman 08/24/2020 Since no more delete of CreditManager table ONLY add new if not found!
                if (ClosedCreditManagerBindingSource.Position == -1)
                {
                    ClosedCreditManagerBindingSource.AddNew();
                    ClosedCreditManagerBindingSource.EndEdit();
                    NewAccount = true;
                }
                // Strip apostrophes from first and last name if they exist
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_FIRST_NAME", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_FIRST_NAME").Replace(@"'", ""));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_LAST_NAME", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_LAST_NAME").Replace(@"'", ""));
                // Moses Newman 06/05/2020 Add MiddleName
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("MiddleName", (TSBDATA.CUSTOMER.Rows[i].Field<String>("MiddleName") != null) ? TSBDATA.CUSTOMER.Rows[i].Field<String>("MiddleName").Replace(@"'", "") : "");
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_SS_NUMBER",
                   TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_SS_1") +
                   TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_SS_2") +
                   TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_SS_3"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_PHONE_NO",
                    (Program.IsInteger(TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PHONE_NO"))) ? TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PHONE_NO") : " ".PadRight(10));
                // Zero pad Birth date to 8 0's if no birth date.
                if (TSBDATA.CUSTOMER.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_DOB") != null)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime>("CRDMGR_DATE_OF_BIRTH_MMDDYYYY", TSBDATA.CUSTOMER.Rows[i].Field<DateTime>("CUSTOMER_DOB"));
                // Strip ,s from STREET_1 AND STREET_2 if they exist
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_STREET_1", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_STREET_1").Replace(",", " ").Replace("#", " "));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_STREET_2", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_STREET_2").PadRight(20).Substring(0, 20).Replace(",", " "));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_CITY", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CITY"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_STATE", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_STATE"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_ZIP_1", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ZIP_1"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_ZIP_2", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ZIP_2"));
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_FIRST_NAME") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_FIRST_NAME", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_LAST_NAME") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_LAST_NAME", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("MiddleName") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("MiddleName", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_JUNIOR") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_JUNIOR", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_JUNIOR") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_JUNIOR", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_HOME_PHONE") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_HOME_PHONE", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_WORK_PHONE") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_WORK_PHONE", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_CELL_PHONE") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_CELL_PHONE", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_SS1") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_SS1", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_SS2") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_SS2", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_SS3") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_SS3", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_ADDRESS1") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_ADDRESS1", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_CITY") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_CITY", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_STATE") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_STATE", "");
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_ZIP_CODE") == null)
                    TSBDATA.CUSTOMER.Rows[i].SetField<String>("COSIGNER_ZIP_CODE", "");
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_FIRST_NAME", TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_FIRST_NAME").Replace(@"'", ""));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_LAST_NAME", TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_LAST_NAME").Replace(@"'", ""));
                switch (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_JUNIOR").TrimStart().TrimEnd().ToUpper())
                {
                    case "SR":
                    case "I":
                    case "1":
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_JUNIOR", "S");
                        break;
                    case "JR":
                    case "II":
                    case "2":
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_JUNIOR", "J");
                        break;
                    case "III":
                    case "3":
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_JUNIOR", "3");
                        break;
                    default:
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_JUNIOR",
                            TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_JUNIOR").TrimStart().TrimEnd().ToUpper());
                        break;

                }
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_HOME_PHONE", (Program.IsInteger(TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_HOME_PHONE"))) ? TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_HOME_PHONE") : " ".PadRight(10));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_WORK_PHONE", (Program.IsInteger(TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_WORK_PHONE"))) ? TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_WORK_PHONE") : " ".PadRight(10));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_CELL_PHONE", (Program.IsInteger(TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_CELL_PHONE"))) ? TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_CELL_PHONE") : " ".PadRight(10));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_SS_NUMBER", TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_SS1") +
                    TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_SS2") + TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_SS3"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_ADDRESS1", TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_ADDRESS1").Replace(",", " ").Replace("#", " "));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_CITY", TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_CITY"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_STATE", TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_STATE"));
                // Replace - with space from zip+4 if it is there
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_ZIP_CODE", TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_ZIP_CODE").Replace("-", " "));
                // Zero pad Birth date to 8 0's if no birth date.
                if (TSBDATA.CUSTOMER.Rows[i].Field<Nullable<DateTime>>("COSIGNER_DOB_DATE") != null)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime>("CRDMGR_COSIGN_DOB_DATE",
                        TSBDATA.CUSTOMER.Rows[i].Field<DateTime>("COSIGNER_DOB_DATE"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_COUNTRY", "US");
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_ADDRESS_IND", " ");
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCOUNT_NUMBER", TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_RESIDENCE_CODE", " ");
                // Moses Newman 08/26/2020
                if (!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("AccountTypeOverride"))
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_TYPE_CODE", (TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_INSURANCE").ToUpper() == "Y") ? "00" : "01");
                // Moses Newman 08/26/2020
                if(!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("AccountStatusOverride"))
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_STATUS_CODE", lsAcctStatusCode);
                // Moses Newman 06/05/2015 Handle blank payment rating
                if (lsAcctStatusCode == "11" || lsAcctStatusCode == "64" || lsAcctStatusCode == "71" || lsAcctStatusCode == "78" || lsAcctStatusCode == "80" ||
                    lsAcctStatusCode == "82" || lsAcctStatusCode == "83" || lsAcctStatusCode == "84" || lsAcctStatusCode == "93" || lsAcctStatusCode == "97")
                    lsAcctPaymentRating = " ";
                if (!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("PaymentRatingOverride") || lsAcctPaymentRating == " ")
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_PAYMENT_RATING", lsAcctPaymentRating);

                if (lsAcctStatusCode == "93" &&
                     TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ACT_STAT") == "I" &&
                     TSBDATA.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE") == 0 &&
                     TSBDATA.CUSTOMER.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_PREV_BALANCE") != null)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_CURRENT_BAL", TSBDATA.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_PREV_BALANCE"));
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_CURRENT_BAL", TSBDATA.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
                // Moses Newman 12/11/2018 set Amount Past Due to 0 IF account balance is 0 even if the Status is NOT 0!
                if (TSBDATA.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") < 0 && lsAcctStatusCode != "11" && TSBDATA.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE") > 0)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_AMOUNT_PAST_DUE", TSBDATA.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1);
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_AMOUNT_PAST_DUE", 0);

                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Int32>("CRDMGR_ACCT_BILLING_DAY",
                    TSBDATA.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_DAY_DUE"));
                // Moses Newman 06/8/2015 Start history from contract date!
                ClosedWSHISTTableAdapter.Fill(TSBDATA.ClosedWSHIST, TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
                    TSBDATA.CUSTOMER.Rows[i].Field<DateTime>("ContractDate"), (DateTime)nullableDateTimePickerTo.Value);
                //ClosedWSHISTTableAdapter.Fill(TSBDATA.ClosedWSHIST, TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
                // (DateTime)nullableDateTimePickerFrom.Value, (DateTime)nullableDateTimePickerTo.Value);
                if (TSBDATA.ClosedWSHIST.Rows.Count > 0)
                {
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_ACCT_DATE_OPENED",
                        TSBDATA.ClosedWSHIST.Rows[0].Field<Nullable<DateTime>>("HIST_DATE_OPENED"));
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_DATE_LAST_PAYMENT",
                        TSBDATA.ClosedWSHIST.Rows[0].Field<Nullable<DateTime>>("HIST_DATE_LAST_PAYMENT"));
                    if (TSBDATA.ClosedWSHIST.Rows[0].Field<Nullable<Decimal>>("HIST_PAYMENT_AMOUNT") != null)
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACTUAL_PAYMENT_AMOUNT",
                            TSBDATA.ClosedWSHIST.Rows[0].Field<Decimal>("HIST_PAYMENT_AMOUNT"));
                    else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACTUAL_PAYMENT_AMOUNT", 0);
                    if (TSBDATA.ClosedWSHIST.Rows[0].Field<Nullable<Decimal>>("HIST_HIGHEST_CREDIT") == null ||
                        (Decimal)TSBDATA.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_CREDIT_LIMIT") > TSBDATA.ClosedWSHIST.Rows[0].Field<Decimal>("HIST_HIGHEST_CREDIT"))
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_HIGHEST_CREDIT",
                            (Decimal)TSBDATA.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_CREDIT_LIMIT"));
                    else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_HIGHEST_CREDIT",
                            TSBDATA.ClosedWSHIST.Rows[0].Field<Decimal>("HIST_HIGHEST_CREDIT"));
                    // Moses Newman 06/09/2015 Set Date of first Delinquent = null if status is 11 (paid 0-29 days past due);
                    // Moses Newman 12/13/2018 Only put a date in if the charge off is due to delinquency!
                    if (TSBDATA.ClosedWSHIST.Rows[0].Field<DateTime?>("HIST_DATE_OF_FIRST_DELINQUENT") != null && lsAcctStatusCode != "11" && lsAcctStatusCode != "13")
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime?>("CRDMGR_DATE_FIRST_DELINQUENT",
                            TSBDATA.ClosedWSHIST.Rows[0].Field<DateTime?>("HIST_DATE_OF_FIRST_DELINQUENT") < (DateTime?)nullableDateTimePickerTo.Value ? TSBDATA.ClosedWSHIST.Rows[0].Field<DateTime?>("HIST_DATE_OF_FIRST_DELINQUENT") : null);
                    else
                        // 03/20/2016 Moses Newman if Hist_Date_First_delinqueny is NULL then leave it null!
                        //if(lsAcctStatusCode == "97")
                        //tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_DATE_FIRST_DELINQUENT",
                        //TSBDATA.ClosedWSHIST.Rows[0].Field<Nullable<DateTime>>("HIST_DATE_LAST_PAYMENT"));
                        //else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_DATE_FIRST_DELINQUENT", null);
                }
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_ACCT_DATE_CLOSED",
                    null);
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ACT_STAT") == "I")
                    // Moses Newman 06/05/2020 pass closed date even if AFTER reporting date
                    if (lsAcctStatusCode != "11") //&& TSBDATA.CUSTOMER.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE") <= (DateTime)nullableDateTimePickerTo.Value)
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_ACCT_DATE_CLOSED",
                             TSBDATA.CUSTOMER.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE"));
                if (lsAcctStatusCode == "13" &&
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Nullable<DateTime>>("CRDMGR_DATE_LAST_PAYMENT") == null)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime>("CRDMGR_DATE_LAST_PAYMENT",
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<DateTime>("CRDMGR_ACCT_DATE_CLOSED"));
                if (tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Nullable<DateTime>>("CRDMGR_DATE_FIRST_DELINQUENT") != null)
                {
                    if (tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<DateTime>("CRDMGR_DATE_FIRST_DELINQUENT") <=
                         tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<DateTime>("CRDMGR_ACCT_DATE_OPENED"))
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_DATE_FIRST_DELINQUENT",
                            null);
                }
                // Moses Newman 06/04/2015 Set scheduled monthly payment to 0 for closed PAID accounts!
                // Moses Newman 02/23/2016 test for paid in full is status == "I" and CUSTOMER_BALANCE == 0
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ACT_STAT") == "I" && (TSBDATA.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE") <= 0) || lsAcctStatusCode == "13")
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_SCHED_MONTHLY_PAYMENT", 0);
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_SCHED_MONTHLY_PAYMENT",
                         TSBDATA.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_CREDIT_LIMIT", 0);

                // Moses Newman 08/26/2020
                if (tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<String>("CRDMGR_ACCT_ECOA_CODE").Trim() == "")
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_ECOA_CODE", "1");
                // Must have ECOA code of 2 if there is a cosinger period!
                if (TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_FIRST_NAME").TrimEnd() != "" || TSBDATA.CUSTOMER.Rows[i].Field<String>("COSIGNER_LAST_NAME").TrimEnd() != "")
                {
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_ECOA_CODE", "2");
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_ECOA_CODE", "2");
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_COSIGN_COUNTRY_CODE", "US");
                }
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_PORTFOLIO_TYPE", "I");
                if (TSBDATA.ClosedWSHIST.Rows.Count > 0)
                {
                    // Moses Newman 12/11/2018 set current balance AND amount past due = charge off amount!
                    if ((lsAcctStatusCode == "64" || lsAcctStatusCode == "97") &&
                        TSBDATA.ClosedWSHIST.Rows[0].Field<Nullable<Decimal>>("HIST_CHARGE_OFF_AMOUNT") != null)
                    {
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ORIGINAL_CHARGE_OFF_AMT",
                            TSBDATA.ClosedWSHIST.Rows[0].Field<Decimal>("HIST_CHARGE_OFF_AMOUNT"));
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_AMOUNT_PAST_DUE",
                            TSBDATA.ClosedWSHIST.Rows[0].Field<Decimal>("HIST_CHARGE_OFF_AMOUNT"));
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_CURRENT_BAL",
                            TSBDATA.ClosedWSHIST.Rows[0].Field<Decimal>("HIST_CHARGE_OFF_AMOUNT"));
                    }
                    else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ORIGINAL_CHARGE_OFF_AMT", 0);
                }
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ORIGINAL_CHARGE_OFF_AMT", 0);
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_TERMS_FREQUENCY", "M");
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Int32>("CRDMGR_ACCT_TERMS_DURATION",
                    TSBDATA.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM"));
                // Moses Newman 08/26/2020
                if (!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("SpecialCommentOverride"))
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_SPECIAL_COMMENT_CODE", lsTSBCommentCode.PadRight(2, ' '));
                /*
                if (lsTSBCommentCode == "A" || lsTSBCommentCode == "D" || lsTSBCommentCode == "E" || lsTSBCommentCode == "H" || lsTSBCommentCode == "I" ||
                    lsTSBCommentCode == "L" || lsTSBCommentCode == "M" || lsTSBCommentCode == "P")
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CONSUMER_INDICATOR", lsTSBCommentCode);
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CONSUMER_INDICATOR", " ");*/
                // Moses Newman 08/26/2020
                // Moses Newman 09/23/2020 Only update the newsest month in the history profile if NOT a new account!
                //if (!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("PaymentHistoryOverride"))
                if(NewAccount)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("PaymentProfile",
                     (String)CUSTHISTTableAdapter.PaymentProfile(TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), (DateTime)nullableDateTimePickerTo.Value));
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("PaymentProfile",
                        UpdateCurrentMonthOnly(tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<String>("PaymentProfile"),
                        (String)CUSTHISTTableAdapter.PaymentProfile(TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), (DateTime)nullableDateTimePickerTo.Value)));

                // Moses Newman 06/11/2020 added Report 
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Boolean>("Report", (TSBDATA.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CREDIT_BUREAU") == "Y") ? true : false);
                // Moses Newman 08/31/2020 Add DateOfAccountInformation
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime>("DateOfAccountInformation", DateTime.Now.Date.AddDays(1));
                ClosedCreditManagerBindingSource.EndEdit();
                try
                {
                    ClosedCreditManagerTableAdapter.Update(tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a genereal error: " + ex.Message);
                }
            }
            CUSTOMERTableAdapter.Dispose();
            CUSTHISTTableAdapter.Dispose();
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            // Moses Newman 05/3/2014 Get rid of SQL Pass Through!
            OPNCUSTTableAdapter.FillByPaidInLast5Years(TSBDATA.OPNCUST, lsCreditBureau, (DateTime)nullableDateTimePickerTo.Value);
            if (TSBDATA.OPNCUST.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO OPEN CUSTOMERS to transfer! ***");
                return;
            }
            lnProg = 0;
            Object loPastDue = null;
            Decimal lnOpenPastDue = 0;
            for (Int32 i = 0; i < TSBDATA.OPNCUST.Rows.Count; i++)
            {
                NewAccount = false;
                lnProg = ((Decimal)(i + 1) / (Decimal)TSBDATA.OPNCUST.Rows.Count) * (Decimal)100;
                lsProgMessage = "Inserting Open Customer Records Into ClosedCustomerCreditManager" + "\n" + "Record: " + (i + 1).ToString().TrimStart() + " of " + TSBDATA.OPNCUST.Rows.Count.ToString() + ".";
                worker.ReportProgress((Int32)lnProg);

                ProcessCustomer(TSBDATA, i, true);
                AccountNumber = TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO");
                // Moses Newman 09/25/2020 No more R revolving for Open End, must be C for Credit Line!
                ClosedCreditManagerTableAdapter.FillByPortfolioType(tsbSet.ClosedCreditManager, AccountNumber, "C");
                ClosedCreditManagerBindingSource.DataSource = tsbSet.ClosedCreditManager;
                ClosedCreditManagerBindingSource.MoveFirst();

                // Moses Newman 08/24/2020 Since no more delete of CreditManager table ONLY add new if not found!
                if (ClosedCreditManagerBindingSource.Position == -1)
                {
                    ClosedCreditManagerBindingSource.AddNew();
                    ClosedCreditManagerBindingSource.EndEdit();
                    NewAccount = true;
                }
                // Strip apostrophes from first and last name if they exist
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_FIRST_NAME", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_FIRST_NAME").Replace(@"'", ""));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_LAST_NAME", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_LAST_NAME").Replace(@"'", ""));
                // Moses Newman 06/05/2020 No Middle Name yet in Open End.
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("MiddleName", "");
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_SS_NUMBER",
                    TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_SS_1") +
                    TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_SS_2") +
                    TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_SS_3"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_PHONE_NO",
                   (Program.IsInteger(TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_PHONE_NO"))) ? TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_PHONE_NO") : " ".PadRight(10));
                // Zero pad Birth date to 8 0's if no birth date.
                if (TSBDATA.OPNCUST.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_DOB_DATE") != null)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime>("CRDMGR_DATE_OF_BIRTH_MMDDYYYY", TSBDATA.OPNCUST.Rows[i].Field<DateTime>("CUSTOMER_DOB_DATE"));
                // Strip ,s from STREET_1 AND STREET_2 if they exist
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_STREET_1", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_STREET_1").Replace(",", " ").Replace("#", " "));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_STREET_2", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_STREET_2").PadRight(20).Substring(0, 20).Replace(",", " "));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_CITY", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_CITY"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_STATE", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_STATE"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_ZIP_1", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_ZIP_1"));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_ZIP_2", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_ZIP_2"));

                //Not enough consigner info on Open side, so NO cosigner infor carried over.
                //if(TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_ALT_FLAG") == "Y")
                //  tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_ECOA_CODE", "2");

                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_COUNTRY", "US");
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_ADDRESS_IND", " ");
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCOUNT_NUMBER", TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO").PadRight(30, ' '));
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CUST_RESIDENCE_CODE", " ");
                // Moses Newman 06/04/2015 Account_type must be 07 for Revolving portfolio type (Open End)
                // Moses Newman 09/25/2020 No more account type 07, must be 15
                if (!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("AccountTypeOverride"))
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_TYPE_CODE", "15");
                // Moses Newman 08/26/2020
                if (!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("AccountStatusOverride"))
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_STATUS_CODE", lsAcctStatusCode);
                // Moses Newman 06/05/2015 Handle blank payment rating
                if (lsAcctStatusCode == "11" || lsAcctStatusCode == "64" || lsAcctStatusCode == "71" || lsAcctStatusCode == "78" || lsAcctStatusCode == "80" ||
                    lsAcctStatusCode == "82" || lsAcctStatusCode == "83" || lsAcctStatusCode == "84" || lsAcctStatusCode == "93" || lsAcctStatusCode == "97")
                    lsAcctPaymentRating = " ";
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_PAYMENT_RATING", lsAcctPaymentRating);
                if (lsAcctStatusCode == "93" && TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_ACT_STAT") == "I" && TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_BALANCE") == 0)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_CURRENT_BAL", TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_PREV_BALANCE"));
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_CURRENT_BAL", TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
                // Moses Newman 07/07/2015 Customer Status is flaky on Open Side so calcualte REAL past due.
                lnOpenPastDue = 0;
                loPastDue = ClosedCreditManagerTableAdapter.OpenPastDue(TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"), DateTime.Now.Date, TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAID_THRU"));
                if (loPastDue != null)
                    lnOpenPastDue = Math.Round((Int32)loPastDue * TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"), 2);
                if (TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") <= 0)
                    lnOpenPastDue = TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1;
                // Moses Newman 12/11/2018 set Amount Past Due to 0 IF account balance is 0 even if the Status is NOT 0!
                if (TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") < 0 && lsAcctStatusCode != "11" && TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_BALANCE") > 0)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_AMOUNT_PAST_DUE", lnOpenPastDue);
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_AMOUNT_PAST_DUE", 0);
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Int32>("CRDMGR_ACCT_BILLING_DAY",
                    TSBDATA.OPNCUST.Rows[i].Field<Int32>("CUSTOMER_DAY_DUE"));
                // Moses Newman 06/08/2015 Start History from Contract Date!
                OpenWSHISTTableAdapter.Fill(TSBDATA.OpenWSHIST, TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"),
                    TSBDATA.OPNCUST.Rows[i].Field<DateTime>("CUSTOMER_CONTRACT_DATE"), (DateTime)nullableDateTimePickerTo.Value);
                //OpenWSHISTTableAdapter.Fill(TSBDATA.OpenWSHIST, TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"),
                //  (DateTime)nullableDateTimePickerFrom.Value, (DateTime)nullableDateTimePickerTo.Value);
                String tempCust = TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO");
                if (TSBDATA.OpenWSHIST.Rows.Count > 0)
                {
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_ACCT_DATE_OPENED",
                        TSBDATA.OpenWSHIST.Rows[0].Field<Nullable<DateTime>>("HIST_DATE_OPENED"));
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_DATE_LAST_PAYMENT",
                        TSBDATA.OpenWSHIST.Rows[0].Field<Nullable<DateTime>>("HIST_DATE_LAST_PAYMENT"));
                    if (TSBDATA.OpenWSHIST.Rows[0].Field<Nullable<Decimal>>("HIST_PAYMENT_AMOUNT") != null)
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACTUAL_PAYMENT_AMOUNT",
                            TSBDATA.OpenWSHIST.Rows[0].Field<Decimal>("HIST_PAYMENT_AMOUNT"));
                    else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACTUAL_PAYMENT_AMOUNT", 0);
                    if (TSBDATA.OpenWSHIST.Rows[0].Field<Nullable<Decimal>>("HIST_HIGHEST_CREDIT") == null ||
                        (Decimal)TSBDATA.OPNCUST.Rows[i].Field<Int32>("CUSTOMER_CREDIT_LIMIT") > TSBDATA.OpenWSHIST.Rows[0].Field<Decimal>("HIST_HIGHEST_CREDIT"))
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_HIGHEST_CREDIT",
                            (Decimal)TSBDATA.OPNCUST.Rows[i].Field<Int32>("CUSTOMER_CREDIT_LIMIT"));
                    else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_HIGHEST_CREDIT",
                            TSBDATA.OpenWSHIST.Rows[0].Field<Decimal>("HIST_HIGHEST_CREDIT"));
                    // Moses Newman 06/09/2015 Set Date of first Delinquent = null if status is 11 (paid 0-29 days past due);
                    // Moses Newman 12/13/2018 Only put a date in if the charge off is due to delinquency!
                    // Moses Newman 12/13/2018 Only put a date in if the charge off is due to delinquency!

                    if (TSBDATA.OpenWSHIST.Rows[0].Field<Nullable<DateTime>>("HIST_DATE_OF_FIRST_DELINQUENT") != null && lsAcctStatusCode != "11" && lsAcctStatusCode != "13")
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime?>("CRDMGR_DATE_FIRST_DELINQUENT",
                            TSBDATA.OpenWSHIST.Rows[0].Field<DateTime?>("HIST_DATE_OF_FIRST_DELINQUENT") < (DateTime?)nullableDateTimePickerTo.Value ? TSBDATA.OpenWSHIST.Rows[0].Field<DateTime?>("HIST_DATE_OF_FIRST_DELINQUENT") : null);
                    else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_DATE_FIRST_DELINQUENT", null);
                }
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_ACCT_DATE_CLOSED",
                    null);
                if (TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_ACT_STAT") == "I")
                    if (lsAcctStatusCode != "11" && TSBDATA.OPNCUST.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE") <= (DateTime)nullableDateTimePickerTo.Value)
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_ACCT_DATE_CLOSED",
                            TSBDATA.OPNCUST.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE"));
                    else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_ACCT_DATE_CLOSED", null);
                if (lsAcctStatusCode == "13" &&
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Nullable<DateTime>>("CRDMGR_DATE_LAST_PAYMENT") == null &&
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Nullable<DateTime>>("CRDMGR_ACCT_DATE_OPENED") != null)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime>("CRDMGR_DATE_LAST_PAYMENT",
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<DateTime>("CRDMGR_ACCT_DATE_OPENED"));
                if (tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Nullable<DateTime>>("CRDMGR_DATE_FIRST_DELINQUENT") != null)
                {
                    if (tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<DateTime>("CRDMGR_DATE_FIRST_DELINQUENT") <=
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<DateTime>("CRDMGR_ACCT_DATE_OPENED"))
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Nullable<DateTime>>("CRDMGR_DATE_FIRST_DELINQUENT",
                            null);
                }
                // Moses Newman 06/04/2015 Set scheduled monthly payment to 0 for closed PAID accounts!
                // Moses Newman 02/23/2016 Now closed test is simplified.
                if (TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_ACT_STAT") == "I" && TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_BALANCE") <= 0) //&&
                    //(lsAcctStatusCode == "11" || lsAcctStatusCode == "13" || lsAcctStatusCode == "61" || lsAcctStatusCode == "62" ||
                    //lsAcctStatusCode == "63" || lsAcctStatusCode == "64"))
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_SCHED_MONTHLY_PAYMENT", 0);
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_SCHED_MONTHLY_PAYMENT",
                         TSBDATA.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));

                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_CREDIT_LIMIT",
                    (Decimal)TSBDATA.OPNCUST.Rows[i].Field<Int32>("CUSTOMER_CREDIT_LIMIT"));

                lsTSBCommentCode = TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_TSB_COMMENT_CODE").TrimEnd();
                // Moses Newman 08/26/2020
                if (tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<String>("CRDMGR_ACCT_ECOA_CODE").Trim() == "")
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_ECOA_CODE", "1");

                //if (TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_ALT_FLAG") == "Y")
                //    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_ECOA_CODE", "2");
                // Portfolio type for Open End is "R" (Revolving)
                // Moses Newman 09/25/2020 No more R for revolving, must be C for Credit Line!
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_PORTFOLIO_TYPE", "C");

                if (TSBDATA.OpenWSHIST.Rows.Count > 0)
                {
                    // Moses Newman 12/11/2018 set current balance AND amount past due = charge off amount!
                    if ((lsAcctStatusCode == "64" || lsAcctStatusCode == "97") &&
                        TSBDATA.OpenWSHIST.Rows[0].Field<Nullable<Decimal>>("HIST_CHARGE_OFF_AMOUNT") != null)
                    {
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ORIGINAL_CHARGE_OFF_AMT",
                            TSBDATA.OpenWSHIST.Rows[0].Field<Decimal>("HIST_CHARGE_OFF_AMOUNT"));
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_AMOUNT_PAST_DUE",
                            TSBDATA.OpenWSHIST.Rows[0].Field<Decimal>("HIST_CHARGE_OFF_AMOUNT"));
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ACCT_CURRENT_BAL",
                            TSBDATA.OpenWSHIST.Rows[0].Field<Decimal>("HIST_CHARGE_OFF_AMOUNT"));
                    }
                    else
                        tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ORIGINAL_CHARGE_OFF_AMT", 0);
                }
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Decimal>("CRDMGR_ORIGINAL_CHARGE_OFF_AMT", 0);
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_TERMS_FREQUENCY", "M");
                // Moses Newman 09/25/2020 No More REV for banks, must be LOC
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_ACCT_TERMS_DURATION", "LOC");
                // Moses Newman 08/26/2020
                if (!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("SpecialCommentOverride"))
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_SPECIAL_COMMENT_CODE", lsTSBCommentCode.PadRight(2, ' '));
                /*if (lsTSBCommentCode == "A" || lsTSBCommentCode == "D" || lsTSBCommentCode == "E" || lsTSBCommentCode == "H" || lsTSBCommentCode == "I" ||
                    lsTSBCommentCode == "L" || lsTSBCommentCode == "M" || lsTSBCommentCode == "P")
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CONSUMER_INDICATOR", lsTSBCommentCode);
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("CRDMGR_CONSUMER_INDICATOR", " ");*/
                // Moses Newman 06/12/2020 Add Open Payment Profile
                // Moses Newman 08/26/2020
                // Moses Newman 09/23/2020 Only update the newsest month in the history profile if NOT a new account!
                //if (!tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<Boolean>("PaymentHistoryOverride"))
                if (NewAccount)
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("PaymentProfile",
                     (String)CUSTHISTTableAdapter.PaymentProfile(TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"), (DateTime)nullableDateTimePickerTo.Value));
                else
                    tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<String>("PaymentProfile",
                        UpdateCurrentMonthOnly(tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].Field<String>("PaymentProfile"),
                        (String)OPNHCUSTTableAdapter.PaymentProfile(TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"), (DateTime)nullableDateTimePickerTo.Value)));
                // Moses Newman 06/11/2020 added Report
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<Boolean>("Report", (TSBDATA.OPNCUST.Rows[i].Field<String>("CUSTOMER_CREDIT_BUREAU") == "Y") ? true : false);
                // Moses Newman 08/31/2020 Add DateOfAccountInformation
                tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position].SetField<DateTime>("DateOfAccountInformation", DateTime.Now.Date.AddDays(1));
                ClosedCreditManagerBindingSource.EndEdit();
                try
                {
                    ClosedCreditManagerTableAdapter.Update(tsbSet.ClosedCreditManager.Rows[ClosedCreditManagerBindingSource.Position]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a genereal error: " + ex.Message);
                }
            }
            if (checkBoxCreateBoth.Checked)
                CreateTSBDATAFile(TSBDATA);
            TSBDATA.Dispose();
            MessageBox.Show("*** TSB CUSTOMER transfer completed successfully! ***");
        }

        private void worker_FillExtractProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)MdiParent;
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.QueryprogressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : 100;
            if (CreateFile)
                lfrm.lblProgress.Text = "Creating ICMEXTR File" + "\n" + lsProgMessage;
            else
                lfrm.lblProgress.Text = lsProgMessage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)MdiParent;
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Close();
        }


        private void ProcessCustomer(IACDataSet TSBDATA, Int32 CustomerPos, Boolean tbOpen = false)
        {

            if (lbBureau)
                return;
            if (!tbOpen)
            {
                if (TSBDATA.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT") == "I")
                {
                    if (TSBDATA.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_CREDIT_STATUS") == "Y")
                    {
                        lnCollectionAcct += 1;
                        lsAcctStatusCode = "93";
                    }
                    else
                        switch (TSBDATA.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAYMENT_TYPE"))
                        {
                            case "B":
                                if (TSBDATA.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_TSB_COMMENT_CODE") == "BN")
                                    lsAcctStatusCode = "64";
                                else
                                    lsAcctStatusCode = "97";
                                break;
                            case "C":
                                lsAcctStatusCode = "DA";
                                break;
                            default:
                                lsAcctStatusCode = "13";
                                break;

                        }
                    if (lsAcctStatusCode != "DA")
                        lsAcctPaymentRating = AcctPaymentRating(TSBDATA, CustomerPos);
                    else
                        lsAcctPaymentRating = " ";
                }
                else
                    lsAcctStatusCode = WhatsTheDiff(TSBDATA, (DateTime)nullableDateTimePickerControlDate.Value, CustomerPos);
            }
            else
            {
                if (TSBDATA.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT") == "I")
                {
                    if (TSBDATA.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_CREDIT_STATUS") == "Y")
                    {
                        lnCollectionAcct += 1;
                        lsAcctStatusCode = "93";
                    }
                    else
                        switch (TSBDATA.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAY_TYPE"))
                        {
                            case "B":
                                if (TSBDATA.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_TSB_COMMENT_CODE") == "BN")
                                    lsAcctStatusCode = "64";
                                else
                                    lsAcctStatusCode = "97";
                                break;
                            case "C":
                                lsAcctStatusCode = "DA";
                                break;
                            default:
                                lsAcctStatusCode = "13";
                                break;

                        }
                    if (lsAcctStatusCode != "DA")
                        lsAcctPaymentRating = AcctPaymentRating(TSBDATA, CustomerPos, 0, true);
                    else
                        lsAcctPaymentRating = " ";
                }
                else
                    lsAcctStatusCode = WhatsTheDiff(TSBDATA, (DateTime)nullableDateTimePickerControlDate.Value, CustomerPos, true);
            }
        }

        private String AcctPaymentRating(IACDataSet TSBDATA, Int32 CustomerPos, Int32 tnDateDiff = 0, Boolean tbOpen = false)
        {
            DateTime ldNextDue, ldPaidThrough;

            if (!tbOpen)
            {
                if (TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE") == 0)
                    ldNextDue = TSBDATA.CUSTOMER.Rows[CustomerPos].Field<DateTime>("CUSTOMER_INIT_DATE");
                else
                    ldNextDue = Program.NextDueDate(CustomerPos, TSBDATA);

                ldPaidThrough = Program.NextDueDate(CustomerPos, TSBDATA).AddMonths(-1);
                tnDateDiff = ldNextDue.Subtract(ldPaidThrough).Days - 31;
                if ((ldNextDue.Month >= DateTime.Now.Date.Month && ldNextDue.Year == DateTime.Now.Date.Year) || ldNextDue.Year > DateTime.Now.Date.Year)
                    tnDateDiff = 0;
                if (TSBDATA.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_CREDIT_STATUS") == "Y")
                    return "G";
                else
                    if (TSBDATA.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAYMENT_TYPE") == "B")
                    return "L";
                else
                        if (tnDateDiff < 30)
                    return "0";
                else
                            if (tnDateDiff >= 30 && tnDateDiff < 60)
                    return "1";
                else
                                if (tnDateDiff >= 60 && tnDateDiff < 90)
                    return "2";
                else
                                    if (tnDateDiff >= 90 && tnDateDiff < 120)
                    return "3";
                else
                                        if (tnDateDiff >= 120 && tnDateDiff < 150)
                    return "4";
                else
                                            if (tnDateDiff >= 150 && tnDateDiff < 180)
                    return "5";
                else
                                                if (tnDateDiff > 179)
                    return "6";
                else
                    return "?";
            }
            else
            {
                if (TSBDATA.OPNCUST.Rows[CustomerPos].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE") == 0)
                    ldNextDue = TSBDATA.OPNCUST.Rows[CustomerPos].Field<DateTime>("CUSTOMER_INIT_DATE");
                else
                    ldNextDue = Program.OpenNextDueDate(CustomerPos, TSBDATA);

                ldPaidThrough = Program.OpenNextDueDate(CustomerPos, TSBDATA).AddMonths(-1);
                tnDateDiff = ldNextDue.Subtract(ldPaidThrough).Days - 31;
                if ((ldNextDue.Month >= DateTime.Now.Date.Month && ldNextDue.Year == DateTime.Now.Date.Year) || ldNextDue.Year > DateTime.Now.Date.Year)
                    tnDateDiff = 0;
                if (TSBDATA.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_CREDIT_STATUS") == "Y")
                    return "G";
                else
                    if (TSBDATA.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_PAY_TYPE") == "B")
                    return "L";
                else
                        if (tnDateDiff < 30)
                    return "0";
                else
                            if (tnDateDiff >= 30 && tnDateDiff < 60)
                    return "1";
                else
                                if (tnDateDiff >= 60 && tnDateDiff < 90)
                    return "2";
                else
                                    if (tnDateDiff >= 90 && tnDateDiff < 120)
                    return "3";
                else
                                        if (tnDateDiff >= 120 && tnDateDiff < 150)
                    return "4";
                else
                                            if (tnDateDiff >= 150 && tnDateDiff < 180)
                    return "5";
                else
                                                if (tnDateDiff > 179)
                    return "6";
                else
                    return "?";
            }
        }

        private String WhatsTheDiff(IACDataSet TSBDATA, DateTime tdTestDate, Int32 CustomerPos, Boolean tbOpen = false)
        {
            DateTime ldNextDue, ldPaidThrough;

            lnDateDiff = 0;

            if (!tbOpen)
            {
                if (TSBDATA.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_CREDIT_STATUS") == "Y")
                {
                    lnACollectionCnt += 1;
                    lnACollectionBalance += TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "93";
                }
                ldNextDue = DateTime.Now.Date;

                // Moses Newman 11/19/2013 substract 1 from days late so 30 days even not late yet, and 31 is 30 days late
                // Change datefiff = current date - (paid_Thru + one month)
                ldPaidThrough = Program.NextDueDate(CustomerPos, TSBDATA);
                lnDateDiff = ldNextDue.Subtract(ldPaidThrough).Days - 31;
                if (lnDateDiff <= 0)
                    lnDateDiff = 0;
                if (lnDateDiff < 30)
                {
                    lnACurrent += 1;
                    lnACurrentBalance += TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "11";
                }
                else
                    if (lnDateDiff >= 30 && lnDateDiff < 60)
                {
                    lnA30 += 1;
                    lnA30Balance += TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "71";
                }
                else
                    if (lnDateDiff >= 60 && lnDateDiff < 90)
                {
                    lnA60 += 1;
                    lnA60Balance += TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "78";
                }
                else
                    if (lnDateDiff >= 90 && lnDateDiff < 120)
                {
                    lnA90 += 1;
                    lnA90Balance += TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "80";
                }
                else
                    if (lnDateDiff >= 120 && lnDateDiff < 150)
                {
                    lnA120 += 1;
                    lnA120Balance += TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "82";
                }
                else
                    if (lnDateDiff >= 150 && lnDateDiff < 180)
                {
                    lnA150 += 1;
                    lnA150Balance += TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "83";
                }
                else
                    if (lnDateDiff >= 180)
                {
                    lnA180 += 1;
                    lnA180Balance += TSBDATA.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "84";
                }
                else
                {
                    lnAOther += 1;
                    return "??";
                }
            }
            else
            {
                if (TSBDATA.OPNCUST.Rows[CustomerPos].Field<String>("CUSTOMER_CREDIT_STATUS") == "Y")
                {
                    lnACollectionCnt += 1;
                    lnACollectionBalance += TSBDATA.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "93";
                }
                ldNextDue = DateTime.Now.Date;

                // Moses Newman 11/19/2013 substract 1 from days late so 30 days even not late yet, and 31 is 30 days late
                // Change datefiff = current date - (paid_Thru + one month)
                ldPaidThrough = Program.OpenNextDueDate(CustomerPos, TSBDATA);
                lnDateDiff = ldNextDue.Subtract(ldPaidThrough).Days - 31;
                if (lnDateDiff <= 0)
                    lnDateDiff = 0;
                if (lnDateDiff < 30)
                {
                    lnACurrent += 1;
                    lnACurrentBalance += TSBDATA.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "11";
                }
                else
                    if (lnDateDiff >= 30 && lnDateDiff < 60)
                {
                    lnA30 += 1;
                    lnA30Balance += TSBDATA.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "71";
                }
                else
                        if (lnDateDiff >= 60 && lnDateDiff < 90)
                {
                    lnA60 += 1;
                    lnA60Balance += TSBDATA.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "78";
                }
                else
                            if (lnDateDiff >= 90 && lnDateDiff < 120)
                {
                    lnA90 += 1;
                    lnA90Balance += TSBDATA.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "80";
                }
                else
                                if (lnDateDiff >= 120 && lnDateDiff < 150)
                {
                    lnA120 += 1;
                    lnA120Balance += TSBDATA.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "82";
                }
                else
                                    if (lnDateDiff >= 150 && lnDateDiff < 180)
                {
                    lnA150 += 1;
                    lnA150Balance += TSBDATA.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "83";
                }
                else
                                        if (lnDateDiff >= 180)
                {
                    lnA180 += 1;
                    lnA180Balance += TSBDATA.OPNCUST.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                    return "84";
                }
                else
                {
                    lnAOther += 1;
                    return "??";
                }
            }
        }

        // Moses Newman 09/23/2020 Create a new HistoryProfile with only the current month changed.
        private String UpdateCurrentMonthOnly(String OldHistString,String NewHistString)
        {
            String DatePart, OldDatePart, HistPart;

            DatePart = NewHistString.Substring(0, 7);
            OldDatePart = OldHistString.Substring(0, 7);
            HistPart = NewHistString.Substring(7,1) + OldHistString.Substring(7, 23);

            return (DatePart == OldDatePart) ? OldHistString:DatePart + HistPart;
        }
    }
}

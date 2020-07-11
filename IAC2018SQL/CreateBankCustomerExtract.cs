using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
//using RestSharp.Extensions;
using System.Threading;

namespace IAC2018SQL
{
    public partial class frmCreateBankCustomerExtract : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private Boolean Open = false,CreateTabs = false;
        private String lsProgMessage = "",lsDealer = "%",lsStat = "%",lsRepo ="%", lsDealerState = "%";
        private DateTime ldStart = DateTime.Parse("01/01/1980"), ldEnd = DateTime.Now.Date,
                         // Moses Newman 03/30/2016 add seperate paid interest range dates.
                         ldPIStart = DateTime.Parse("01/01/1980"), ldPIEnd = DateTime.Now.Date;
        // Moses Newman 01/28/2020 Add field picker tab.

        public struct Fld
        {
            public String FldName { get; set; }
            public String EXCELColumnName { get; set; }
            public Int32 FldNumber { get; set; }
            // Moses Newman 03/28/2020 Add New Business Field Selection
            public Boolean NBField { get; set; }
            public Int32 NBOrder { get; set; }
            // Moses Newman 06/25/2020 Add Extension Field Selection
            public Boolean ExtField {get; set;}
            public Int32 ExtOrder { get; set; }
        }

        private List<Fld> FullFieldList = new List<Fld>(),SelectedFields = new List<Fld>();
        
        private PaymentDataSet FieldListData = new PaymentDataSet(); // Moses Newman 01/28/2020 New Field List Selection

        private PaymentDataSetTableAdapters.ExtractFieldListTableAdapter ExtractFieldListTableAdapter = new PaymentDataSetTableAdapters.ExtractFieldListTableAdapter();

        private Fld ExField = new Fld();
        private Int32 lnControlMonthStart = 0, lnControlYearStart = 0, lnControlMonthEnd = 0, lnControlYearEnd;

        public frmCreateBankCustomerExtract()
        {
            InitializeComponent();
        }

        private void frmCreateBankCustomerExtract_Load(object sender, EventArgs e)
        {
            // Moses Newman 04/20/2014 Add Active Inactive or Both, Dealer choice, and date range.
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;
            IACDataSet Bank = new IACDataSet();
            IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter DLRLISTBYNUMTableAdapter = new IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            IACDataSetTableAdapters.stateTableAdapter stateTableAdapter = new IACDataSetTableAdapters.stateTableAdapter();
            // Moses Newman 01/28/2020 Add field picker tab.

            BindingSource bindingSourceDLRLISTBYNUM = new BindingSource();
            BindingSource bindingSourceState = new BindingSource();
            radioButtonActive.Checked = true;
            nullableDateTimePickerStartDate.Value = DateTime.Parse("01/01/1980");
            nullableDateTimePickerEndDate.Value = DateTime.Now.Date;
            // Moses Newman 03/30/2016 add seperate paid interest date range selection.
            nullableDateTimePickerPIStartDate.Value = DateTime.Parse("01/01/1980");
            nullableDateTimePickerPIEndDate.Value = DateTime.Now.Date;
            // 03/25/2016 Moses Newman add buyout date field 
            nullableDateTimePickerBuyoutDate.Value = DateTime.Now.Date;
            bindingSourceDLRLISTBYNUM.DataSource = Bank.DLRLISTBYNUM;
            DLRLISTBYNUMTableAdapter.Fill(Bank.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            Bank.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_ACC_NO", "   ");
            Bank.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
            comboBoxDealer.DataSource = bindingSourceDLRLISTBYNUM;
            textBoxDealerName.DataBindings.Add("Text", bindingSourceDLRLISTBYNUM, "DEALER_NAME");
            //Moses Newman 03/11/2020 Add Funding Date Search default to unchecked
            checkBoxFundingDate.Checked = false;

            stateTableAdapter.Fill(Bank.state);
            bindingSourceState.DataSource = Bank.state;
          
            bindingSourceState.AddNew();
            bindingSourceState.EndEdit();
            Bank.state.Rows[bindingSourceState.Position].SetField("abbreviation", "");
            Bank.state.Rows[bindingSourceState.Position].SetField("name", "");
            bindingSourceState.EndEdit();
           
            comboBoxState.DataSource = bindingSourceState;
            comboBoxState.DisplayMember = "name";
            comboBoxState.ValueMember = "abbreviation";
            Bank.Dispose();

            // Moses Newman 01/28/2020 Add field picker tab.
            ExtractFieldListTableAdapter.FillByIncluded(FieldListData.ExtractFieldList);

            for(int i=0;i < FieldListData.ExtractFieldList.Rows.Count;i++)
            {
                ExField.FldName = FieldListData.ExtractFieldList.Rows[i].Field<String>("FieldName");
                ExField.EXCELColumnName = FieldListData.ExtractFieldList.Rows[i].Field<String>("EXCELColumnName");
                ExField.NBField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("NewBusinessField");
                ExField.NBOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("NBOrder");
                ExField.ExtField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("ExtensionField");
                ExField.ExtOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("ExtOrder");
                ExField.FldNumber = i+1;
                FullFieldList.Add(ExField);
            }
            listBoxFieldList.DataSource = FullFieldList;
            listBoxFieldList.DisplayMember = "EXCELColumnName";
            listBoxFieldList.ValueMember = "EXCELColumnName";
            listBoxFieldList.Refresh();
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateTextFile(IACDataSet Bank,PaymentDataSet Extensions)
        {
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
            PaymentDataSetTableAdapters.CustomerExtractTableAdapter CustomerExtractTableAdapter = new PaymentDataSetTableAdapters.CustomerExtractTableAdapter();

            DataPathTableAdapter.Fill(Bank.DataPath);
            String sourcePath = Bank.DataPath.Rows[0].Field<String>("Path").TrimEnd(),
                   lsExcelFileOut = sourcePath + @"comp1000\Bank.xlsx",
                   lsTemplate = sourcePath + @"comp1000\TemplateCustomerExtract.xlsx";

              //lsTime = DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                //                    DateTime.Now.Minute.ToString().PadLeft(2, '0');
              
              //lsTabChar         =   "\t";

            try
            {
                if (File.Exists(lsExcelFileOut))
                    File.Delete(lsExcelFileOut);
            }
            catch
            {
                MessageBox.Show("Could Not Open Bank.xlsx because someone has it open!", "EXCEL File In Use",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (File.Exists(lsTemplate))
            {
                File.Copy(lsTemplate, lsExcelFileOut);
                File.SetAttributes(lsExcelFileOut, FileAttributes.Normal);
            }
            sourcePath += @"comp1000\Bank.xlsx";
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            SQLBR.RunJob("CustomerBankExtract", "Create Customer Bank Excel Ouput", false);
            Thread.Sleep(5000);
            SQLBR.Dispose();

            /*
                        StreamWriter strm = new StreamWriter(sourcePath,false);

                        CustomerExtractTableAdapter.FillByAll(Extensions.CustomerExtract);
                        // Create HEADER record for AUTOBANK file
                        CreateTabs = true;
                        Decimal lnProg = 0;

                        // Create Header
                        // Profile Information
                        strm.Write("CUSTOMER_FIRST_NAME" + lsTabChar);
                        strm.Write("CUSTOMER_LAST_NAME" + lsTabChar);
                        strm.Write("CUSTOMER_STREET_1" + lsTabChar);
                        strm.Write("CUSTOMER_STREET_2" + lsTabChar);
                        strm.Write("CUSTOMER_CITY"  + lsTabChar);
                        strm.Write("CUSTOMER_STATE" + lsTabChar);
                        strm.Write("ZipCode" + lsTabChar);
                        strm.Write("SSN" + lsTabChar); 
                        strm.Write("CUSTOMER_DOB" + lsTabChar);
                        strm.Write("CUSTOMER_IAC_TYPE" + lsTabChar);
                        // 03/22/2016 Moses Newman Remove unused INTEREST_TYPE_INDICATOR
                        //strm.Write("INTEREST_TYPE_INDICATOR" + lsTabChar);
                        // 03/22/2016 Moses Newman Remove unused field branch number
                        //strm.Write("BRANCH_NUMBER" + lsTabChar);
                        strm.Write("CUSTOMER_NO" + lsTabChar);
                        // 03/22/2016 Moses Newman Remove unused LOAN_SEQUENCE#
                        //strm.Write("LOAN_SEQUENCE_NUMBER" + lsTabChar);
                        strm.Write("LEGAL_STATE_CODE" + lsTabChar);
                        strm.Write("CUSTOMER_ORIGINAL_AMOUNT" + lsTabChar);
                        strm.Write("CUSTOMER_REGULAR_AMOUNT" + lsTabChar);
                        // 03/22/2016 Moses Newman Remove unused Payment_Frequency
                        //strm.Write("PAYMENT_FREQUENCY" + lsTabChar);
                        strm.Write("CUSTOMER_LOAN_AMOUNT" + lsTabChar);
                        strm.Write("CUSTOMER_LOAN_CASH" + lsTabChar);
                        strm.Write("CUSTOMER_TERM" + lsTabChar);
                        strm.Write("CUSTOMER_FINANCE_CHARGE" + lsTabChar);
                        strm.Write("CUSTOMER_LOAN_INTEREST" + lsTabChar);
                        strm.Write("PaidInterest" + lsTabChar);
                        strm.Write("CUSTOMER_UE_INTEREST" + lsTabChar);
                        strm.Write("CUSTOMER_BALANCE" + lsTabChar);
                        strm.Write("CUSTOMER_BUYOUT" + lsTabChar);
                        strm.Write("CUSTOMER_LATE_CHARGE_BAL" + lsTabChar);
                        strm.Write("CUSTOMER_ANNUAL_PERCENTAGE_RATE" + lsTabChar);
                        strm.Write("CUSTOMER_CONTRACT_DATE" + lsTabChar);
                        strm.Write("CUSTOMER_INIT_DATE" + lsTabChar);
                        strm.Write("CUSTOMER_MATURITY_DATE" + lsTabChar);
                        strm.Write("CUSTOMER_NEXT_DUE_DATE" + lsTabChar);
                        strm.Write("CUSTOMER_LAST_PAYMENT_DATE" + lsTabChar);
                        // Moses Newman 01/09/2018 added CUSTOMER_PAID_THRU
                        strm.Write("CUSTOMER_PAID_THRU" + lsTabChar);
                        // Moses Newman 01/09/2018 added CUSTOMER_NO_OF_PAYMENTS_MADE
                        strm.Write("CUSTOMER_NO_OF_PAYMENTS_MADE" + lsTabChar);
                        strm.Write("CUSTOMER_MONTHS_EXTENDED" + lsTabChar);
                        // Moses Newman 01/09/2018 added CUSTOMER_CREDIT_SCORE_N
                        strm.Write("CUSTOMER_CREDIT_SCORE_N" + lsTabChar);
                        // Moses Newman 01/09/2018 added AnnualIncome
                        strm.Write("AnnualIncome" + lsTabChar);
                        // Moses Newman 01/09/2018 added Tier
                        strm.Write("Tier" + lsTabChar);
                        // Moses Newman 01/09/2018 added Co-Buyer Credit Score and Anual Income
                        strm.Write("CosignerAnnualIncome" + lsTabChar);
                        strm.Write("CosignerCreditScore" + lsTabChar);
                        strm.Write("VEHICLE_VIN"  + lsTabChar);
                        strm.Write("VEHICLE_YEAR" + lsTabChar);
                        strm.Write("VEHICLE_MAKE" + lsTabChar);
                        strm.Write("VEHICLE_MODEL" + lsTabChar);
                        // Moses Newman 01/09/2018 added Mileage
                        strm.Write("Mileage" + lsTabChar);
                        strm.Write("CUSTOMER_DEALER" + lsTabChar);
                        strm.Write("DEALER_NAME" + lsTabChar);
                        strm.Write("DEALER_STATE" + lsTabChar);
                        strm.Write("VEHICLE_INS_COMPANY" + lsTabChar);
                        strm.Write("VEHICLE_POLICY_NO" + lsTabChar);
                        strm.Write("VEHICLE_EFF_DATE" + lsTabChar);
                        strm.Write("VEHICLE_EXP_DATE" + lsTabChar);
                        strm.Write("CUSTOMER_REPO_IND" + lsTabChar);
                        strm.Write("CUSTOMER_ACT_STAT" + lsTabChar);
                        // Moses Newman 01/30/2019 Added new fields
                        strm.Write("Tier Points" + lsTabChar);
                        strm.Write("COS Tier Points" + lsTabChar);
                        strm.Write("Funding Date" + lsTabChar);
                        strm.Write("DLR Cash Price" + lsTabChar);
                        strm.Write("Partial Payment" + lsTabChar);
                        strm.Write("LTV" + lsTabChar);
                        strm.Write("Control Date" + lsTabChar);
                        strm.Write("Full Recourse" + lsTabChar);
                        strm.Write("Gap Ins" + lsTabChar);
                        strm.Write("Warranty" + lsTabChar);
                        strm.WriteLine("Last Pay Code");
                        for (Int32 i = 0; i < Extensions.CustomerExtract.Rows.Count; i++)
                        {
                            lnProg = ((Decimal)(i + 1) / (Decimal)Extensions.CustomerExtract.Rows.Count) * (Decimal)100;
                            lsProgMessage = "Record: " + i.ToString().TrimStart() + " of " + Extensions.CustomerExtract.Rows.Count.ToString() + ".";
                            worker.ReportProgress((Int32)lnProg);

                            // Profile Information
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_FIRST_NAME") + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_LAST_NAME") + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_STREET_1") +lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_STREET_2") + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_CITY") + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_STATE") + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_ZIP_1").PadLeft(5,'0') + (Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_ZIP_2") != "" ?  "-" + Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_ZIP_2").PadLeft(4,'0') : "") + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_SS_1") + Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_SS_2") + Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_SS_3"));
                            strm.Write(lsTabChar);
                            if (Extensions.CustomerExtract.Rows[RowCount].Field<Nullable<DateTime>>("CUSTOMER_DOB") != null)
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("CUSTOMER_DOB").ToShortDateString());
                            else
                                strm.Write("          ");
                            strm.Write(lsTabChar);

                            //Contract Information
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_IAC_TYPE") + lsTabChar);
                            // Moses Newman 03/26/2016 Remove Interest Type Indicator
                            //if (Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_IAC_TYPE") == "C")
                              //  strm.Write("Pre-computed Interest" + lsTabChar);
                            //else
                              //  strm.Write("Interest Bearing" + lsTabChar);
                            //strm.Write("   " + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_NO") + lsTabChar);
                            //strm.Write("   " + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_STATE") + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_ORIGINAL_AMOUNT").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT").ToString() + lsTabChar);
                            // Moses Newman 03/26/2016 Removed Payment Frequency 
                            //strm.Write("Monthly" + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_LOAN_AMOUNT").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_LOAN_CASH").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Int32>("CUSTOMER_TERM").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_TD_FINANCE_CHARGE").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_LOAN_INTEREST").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("PaidInterest").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_UE_INTEREST").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_BALANCE").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_BUYOUT").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("CUSTOMER_CONTRACT_DATE").ToShortDateString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("CUSTOMER_INIT_DATE").ToShortDateString() + lsTabChar);
                            if (Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_IAC_TYPE") == "C")
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("CUSTOMER_MATURITY_DATE").ToShortDateString() + lsTabChar);
                            else
                                strm.Write("          " + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("CUSTOMER_NEXT_DUE_DATE").ToShortDateString() + lsTabChar);
                            if (Extensions.CustomerExtract.Rows[RowCount].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE") != null)
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("CUSTOMER_LAST_PAYMENT_DATE").ToShortDateString() + lsTabChar);
                            else
                                strm.Write("          " + lsTabChar);
                            // Moses Newman 01/09/2018 Added CUSTOMER_PAID_THRU
                            //strm.Write(((Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_IAC_TYPE") == "C") ? ClosedPaidThrough(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_NO")).ToShortDateString() : OpenPaidThrough(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_NO")).ToShortDateString()) + lsTabChar);
                            // Moses Newman 06/22/2020 write normal paid thru
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_PAID_THRU") + lsTabChar);
                            // Moses Newman 01/09/2018 New Fields CUSTOMER_NO_OF_PAYMENTS_MADE
                            // Moses Newman 01/09/2018 New Fields CUSTOMER_NO_OF_PAYMENTS_MADE
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE").ToString() + lsTabChar);
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Int32>("CUSTOMER_MONTHS_EXTENDED").ToString() + lsTabChar);
                            // Moses Newman 01/09/2018 Added CUSTOMER_CREDIT_SCORE_N
                            strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Int32>("CUSTOMER_CREDIT_SCORE_N").ToString() + lsTabChar);
                            if (Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_IAC_TYPE") == "C")
                            {
                                // Moses Newman 01/09/2018 Added AnnualIncome
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("AnnualIncome").ToString() + lsTabChar);
                                // Moses Newman 01/09/2018 Added Tier
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_CREDIT_SCORE_A").ToString() + lsTabChar);
                                // Moses Newman 01/09/2018 added Co-Buyer Credit Score and Anual Income
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CosignerAnnualIncome").ToString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CosignerCreditScore").ToString() + lsTabChar);
                                // Collateral Information
                                //strm.Write(lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("VEHICLE_VIN").Trim() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Int32>("VEHICLE_YEAR").ToString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("VEHICLE_MAKE") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("VEHICLE_MODEL") + lsTabChar);
                                // Moses Newman 01/09/2018 added Mileage
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("Mileage").ToString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_DEALER") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("DEALER_NAME") + lsTabChar);
                                // Moses Newman 04/21/2014 Add DEALER_STATE
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("DEALER_STATE") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("VEHICLE_INS_COMPANY") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("VEHICLE_POLICY_NO") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("VEHICLE_EFF_DATE").ToShortDateString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("VEHICLE_EXP_DATE").ToShortDateString() + lsTabChar);
                                // Moses Newman 03/25/2016 Add Repo Ind
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_REPO_IND") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_ACT_STAT") + lsTabChar);
                                // Moses Newman 01/29/202 Added new fields
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("TierPoints").ToString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("CosignerTierPoints").ToString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("FundingDate").ToShortDateString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("DealerCashPrice").ToString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("PartialPayment").ToString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<Decimal>("Ltv").ToString() + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("ControlDate").ToShortDateString() + lsTabChar);
                                strm.Write((Extensions.CustomerExtract.Rows[RowCount].Field<Boolean>("IsFullRecourse") ? "Yes" : "No") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("GapIns").PadRight(10,' ') + lsTabChar);
                                strm.Write((Extensions.CustomerExtract.Rows[RowCount].Field<Boolean>("Warranty") ? "Yes" : "No") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("LastPostingCode") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_PAYMENT_TYPE") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_PAYMENT_CODE") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime?>("PaymentDate") != null ?
                                    Extensions.CustomerExtract.Rows[RowCount].Field <DateTime> ("PaymentDate").ToShortDateString():new String(' ',10) + lsTabChar);
                                strm.WriteLine(Extensions.CustomerExtract.Rows[RowCount].Field<String>("PREVIOUS_PAID_THRU"));
                            }
                            else
                            {
                                // Moses Newman 01/09/2018 Added AnnualIncome
                                strm.Write(" ".PadRight(15) + lsTabChar);
                                // Moses Newman 01/09/2018 Added Tier
                                strm.Write(" ".PadRight(1) + lsTabChar);
                                // Moses Newman 01/09/2018 Added CosignerAnnualIncome
                                strm.Write(" ".PadRight(15) + lsTabChar);
                                // Moses Newman 01/09/2018 Added CosignerCreditScore
                                strm.Write(" ".PadRight(3) + lsTabChar);
                                strm.Write(lsTabChar);
                                strm.Write(" ".PadRight(25) + lsTabChar);
                                strm.Write(" ".PadRight(4) + lsTabChar);
                                strm.Write(" ".PadRight(15) + lsTabChar);
                                strm.Write(" ".PadRight(15) + lsTabChar);
                                // Moses Newman 01/09/2018 Added mileage
                                strm.Write(" ".PadRight(6) + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_DEALER") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("DEALER_NAME") + lsTabChar);
                                // Moses Newman 04/21/2014 Add DEALER_STATE
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("DEALER_STATE") + lsTabChar);
                                strm.Write(" ".PadRight(25) + lsTabChar);
                                strm.Write(" ".PadRight(15) + lsTabChar);
                                strm.Write(" ".PadRight(10) + lsTabChar);
                                strm.Write(" ".PadRight(10) + lsTabChar);
                                // Moses Newman 03/25/2016 Add Repo Ind
                                strm.Write(" ".PadRight(1) + lsTabChar);
                                strm.Write(" ".PadRight(1) + lsTabChar);
                                // Moses Newman 01/29/2020 Added new fields
                                strm.Write(" ".PadRight(3) + lsTabChar);
                                strm.Write(" ".PadRight(3) + lsTabChar);
                                strm.Write(" ".PadRight(8) + lsTabChar);
                                strm.Write(" ".PadRight(13) + lsTabChar);
                                strm.Write(" ".PadRight(13) + lsTabChar);
                                strm.Write(" ".PadRight(7) + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("ControlDate").ToShortDateString() + lsTabChar);
                                strm.Write(" ".PadRight(3) + lsTabChar);
                                strm.Write(" ".PadRight(5) + lsTabChar);
                                strm.Write(" ".PadRight(3) + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("LastPostingCode") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_PAYMENT_TYPE") + lsTabChar);
                                strm.Write(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_PAYMENT_CODE") + lsTabChar);
                                strm.Write((Extensions.CustomerExtract.Rows[RowCount].Field<DateTime?>("PaymentDate") != null ?
                                            Extensions.CustomerExtract.Rows[RowCount].Field<DateTime>("PaymentDate").ToShortDateString() : new String(' ', 10)) + lsTabChar);
                                strm.WriteLine(Extensions.CustomerExtract.Rows[RowCount].Field<String>("PREVIOUS_PAID_THRU"));
                            }
                        }
                        strm.Flush();
                        strm.Close();
                        */
            // Moses Newman 11/14/2019 Add Excel Automation column and page formatting
            //Create an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            excelApp.Visible = true;
            excelApp.WindowState = Excel.XlWindowState.xlMinimized;
            excelApp.WindowState = Excel.XlWindowState.xlMaximized;

            //excelApp.Workbooks.Open(sourcePath);
            //open excel workbook
            Excel.Workbook excelWorkBook;
            //Excel.Workbook excelWorkBook = excelApp.Workbooks[1];

            //excelWorkBook.SaveAs(lsExcelFileOut,Excel.XlFileFormat.xlWorkbookDefault);
            //excelApp.Workbooks.Close();
            //if (File.Exists(sourcePath))
                //File.Delete(sourcePath);
            excelApp.Workbooks.Open(lsExcelFileOut);

            Excel.Worksheet excelWorkSheet;
            excelWorkBook = excelApp.Workbooks[1];
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[1];

            excelWorkSheet.PageSetup.CenterHeader = "&\"Arial\"&B&12&KFF0000" + "Customer Bank Extract";
            excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;

            Excel.Range Fname = excelWorkSheet.get_Range("A:A");
            Fname.Columns.EntireColumn.AutoFit();
            Fname.Columns.ColumnWidth = 13;
            excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("A1:A1").Value = "First Name";

            Excel.Range Lname = excelWorkSheet.get_Range("B:B");
            Lname.Columns.EntireColumn.AutoFit();
            Lname.Columns.ColumnWidth = 19;
            excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("B1:B1").Value = "Last Name";

            Excel.Range Address1 = excelWorkSheet.get_Range("C:C");
            Address1.Columns.EntireColumn.AutoFit();
            Address1.Columns.ColumnWidth = 30;
            excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("C1:C1").Value = "Address 1";

            Excel.Range Address2 = excelWorkSheet.get_Range("D:D");
            Address2.Columns.EntireColumn.AutoFit();
            Address2.Columns.ColumnWidth = 13;
            excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("D1:D1").Value = "Address 2";

            Excel.Range City = excelWorkSheet.get_Range("E:E");
            City.Columns.EntireColumn.AutoFit();
            City.Columns.ColumnWidth = 15;
            excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("E1:E1").Value = "City";

            Excel.Range State = excelWorkSheet.get_Range("F:F");
            State.Columns.EntireColumn.AutoFit();
            State.Columns.ColumnWidth = 6;
            excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("F1:F1").Value = "State";

            Excel.Range ZipCode = excelWorkSheet.get_Range("G:G");
            ZipCode.Columns.EntireColumn.AutoFit();
            ZipCode.Columns.ColumnWidth = 11;
            ZipCode.Columns.NumberFormat = "00000-0000";
            excelWorkSheet.get_Range("G1:G1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("G1:G1").Value = "Zip Code";

            Excel.Range SSN = excelWorkSheet.get_Range("H:H");
            SSN.Columns.EntireColumn.AutoFit();
            SSN.Columns.ColumnWidth = 12;
            SSN.Columns.NumberFormat = "000-00-0000";
            excelWorkSheet.get_Range("H1:H1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("H1:H1").Value = "SSN";

            Excel.Range DOB = excelWorkSheet.get_Range("I:I");
            DOB.Columns.EntireColumn.AutoFit();
            DOB.Columns.ColumnWidth = 11;
            DOB.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("I1:I1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("I1:I1").Value = "DOB";

            Excel.Range Type = excelWorkSheet.get_Range("J:J");
            Type.Columns.EntireColumn.AutoFit();
            Type.Columns.ColumnWidth = 5;
            excelWorkSheet.get_Range("J1:J1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("J1:J1").Value = "Type";

            Excel.Range CustomerNo = excelWorkSheet.get_Range("K:K");
            CustomerNo.Columns.EntireColumn.AutoFit();
            CustomerNo.Columns.ColumnWidth = 12;
            CustomerNo.Columns.NumberFormat = "000000";
            excelWorkSheet.get_Range("K1:K1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("K1:K1").Value = "Account No.";

            Excel.Range LegalState = excelWorkSheet.get_Range("L:L");
            LegalState.Columns.EntireColumn.AutoFit();
            LegalState.Columns.ColumnWidth = 10;
            excelWorkSheet.get_Range("L1:L1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("L1:L1").Value = "Legal St.";

            Excel.Range OriginalMonthly = excelWorkSheet.get_Range("M:M");
            OriginalMonthly.Columns.EntireColumn.AutoFit();
            OriginalMonthly.Columns.ColumnWidth = 12;
            OriginalMonthly.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("M1:M1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("M1:M1").Value = "Org. Monthly";

            Excel.Range Monthly = excelWorkSheet.get_Range("N:N");
            Monthly.Columns.EntireColumn.AutoFit();
            Monthly.Columns.ColumnWidth = 10;
            Monthly.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("N1:N1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("N1:N1").Value = "Monthly";

            Excel.Range LoanAmount = excelWorkSheet.get_Range("O:O");
            LoanAmount.Columns.EntireColumn.AutoFit();
            LoanAmount.Columns.ColumnWidth = 16;
            LoanAmount.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("O1:O1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("O1:O1").Value = "Loan Amount";

            Excel.Range Cash = excelWorkSheet.get_Range("P:P");
            Cash.Columns.EntireColumn.AutoFit();
            Cash.Columns.ColumnWidth = 12;
            Cash.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("P1:P1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("P1:P1").Value = "Cash";

            Excel.Range Term = excelWorkSheet.get_Range("Q:Q");
            Term.Columns.EntireColumn.AutoFit();
            Term.Columns.ColumnWidth = 5;
            Term.Columns.NumberFormat = "00";
            excelWorkSheet.get_Range("Q1:Q1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("Q1:Q1").Value = "Term";

            Excel.Range FC = excelWorkSheet.get_Range("R:R");
            FC.Columns.EntireColumn.AutoFit();
            FC.Columns.ColumnWidth = 6;
            FC.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("R1:R1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("R1:R1").Value = "FC";

            Excel.Range LoanInterest = excelWorkSheet.get_Range("S:S");
            LoanInterest.Columns.EntireColumn.AutoFit();
            LoanInterest.Columns.ColumnWidth = 10;
            LoanInterest.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("S1:S1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("S1:S1").Value = "Loan Int.";

            Excel.Range PaidInterest = excelWorkSheet.get_Range("T:T");
            PaidInterest.Columns.EntireColumn.AutoFit();
            PaidInterest.Columns.ColumnWidth = 10;
            PaidInterest.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("T1:T1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("T1:T1").Value = "Paid Int.";

            Excel.Range UEI = excelWorkSheet.get_Range("U:U");
            UEI.Columns.EntireColumn.AutoFit();
            UEI.Columns.ColumnWidth = 6;
            UEI.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("U1:U1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("U1:U1").Value = "UEI";

            Excel.Range Balance = excelWorkSheet.get_Range("V:V");
            Balance.Columns.EntireColumn.AutoFit();
            Balance.Columns.ColumnWidth = 10;
            Balance.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("V1:V1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("V1:V1").Value = "Balance";

            Excel.Range Buyout = excelWorkSheet.get_Range("W:W");
            Buyout.Columns.EntireColumn.AutoFit();
            Buyout.Columns.ColumnWidth = 10;
            Buyout.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("W1:W1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("W1:W1").Value = "Buyout";

            Excel.Range LCBal = excelWorkSheet.get_Range("X:X");
            LCBal.Columns.EntireColumn.AutoFit();
            LCBal.Columns.ColumnWidth = 12;
            LCBal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("X1:X1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("X1:X1").Value = "L/C Balance";

            Excel.Range APR = excelWorkSheet.get_Range("Y:Y");
            APR.Columns.EntireColumn.AutoFit();
            APR.Columns.ColumnWidth = 10;
            APR.Columns.NumberFormat = "##0.000";
            excelWorkSheet.get_Range("Y1:Y1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("Y1:Y1").Value = "APR";

            Excel.Range ContractDate = excelWorkSheet.get_Range("Z:Z");
            ContractDate.Columns.EntireColumn.AutoFit();
            ContractDate.Columns.ColumnWidth = 14;
            ContractDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("Z1:Z1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("Z1:Z1").Value = "Contract Date";

            Excel.Range FirstPayDate = excelWorkSheet.get_Range("AA:AA");
            FirstPayDate.Columns.EntireColumn.AutoFit();
            FirstPayDate.Columns.ColumnWidth = 14;
            FirstPayDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("AA1:AA1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AA1:AA1").Value = "1st Pay Date";


            Excel.Range MaturityDate = excelWorkSheet.get_Range("AB:AB");
            MaturityDate.Columns.EntireColumn.AutoFit();
            MaturityDate.Columns.ColumnWidth = 14;
            MaturityDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("AB1:AB1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AB1:AB1").Value = "Maturity Date";

            Excel.Range NextDueDate = excelWorkSheet.get_Range("AC:AC");
            NextDueDate.Columns.EntireColumn.AutoFit();
            NextDueDate.Columns.ColumnWidth = 14;
            NextDueDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("AC1:AC1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AC1:AC1").Value = "Nxt Due Date";

            Excel.Range LastPayDate = excelWorkSheet.get_Range("AD:AD");
            LastPayDate.Columns.EntireColumn.AutoFit();
            LastPayDate.Columns.ColumnWidth = 14;
            LastPayDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("AD1:AD1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AD1:AD1").Value = "Last Pay Date";

            Excel.Range Ext = excelWorkSheet.get_Range("AE:AE");
            Ext.Columns.EntireColumn.AutoFit();
            Ext.Columns.ColumnWidth = 4;
            Ext.Columns.NumberFormat = "###";
            excelWorkSheet.get_Range("AE1:AE1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AE1:AE1").Value = "Ext";

            Excel.Range PaidThrough = excelWorkSheet.get_Range("AF:AF");
            PaidThrough.Columns.EntireColumn.AutoFit();
            PaidThrough.Columns.ColumnWidth = 14;
            PaidThrough.Columns.NumberFormat = "00/00";
            excelWorkSheet.get_Range("AF1:AF1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AF1:AF1").Value = "Paid Through";

            Excel.Range NumPay = excelWorkSheet.get_Range("AG:AG");
            NumPay.Columns.EntireColumn.AutoFit();
            NumPay.Columns.ColumnWidth = 7;
            NumPay.Columns.NumberFormat = "###";
            excelWorkSheet.get_Range("AG1:AG1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AG1:AG1").Value = "Num Pay";

            Excel.Range CreditScore = excelWorkSheet.get_Range("AH:AH");
            CreditScore.Columns.EntireColumn.AutoFit();
            CreditScore.Columns.ColumnWidth = 11;
            CreditScore.Columns.NumberFormat = "###";
            excelWorkSheet.get_Range("AH1:AH1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AH1:AH1").Value = "Credit Score";

            Excel.Range AnnualIncome = excelWorkSheet.get_Range("AI:AI");
            AnnualIncome.Columns.EntireColumn.AutoFit();
            AnnualIncome.Columns.ColumnWidth = 13;
            AnnualIncome.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("AI1:AI1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AI1:AI1").Value = "Annual Income";

            Excel.Range Tier = excelWorkSheet.get_Range("AJ:AJ");
            Tier.Columns.EntireColumn.AutoFit();
            Tier.Columns.ColumnWidth = 5;
            Tier.Columns.NumberFormat = "#";
            excelWorkSheet.get_Range("AJ1:AJ1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AJ1:AJ1").Value = "Tier";

            Excel.Range CosAnnualIncome = excelWorkSheet.get_Range("AK:AK");
            CosAnnualIncome.Columns.EntireColumn.AutoFit();
            CosAnnualIncome.Columns.ColumnWidth = 17;
            CosAnnualIncome.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("AK1:AK1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AK1:AK1").Value = "COS Annual Income";

            Excel.Range COSCreditScore = excelWorkSheet.get_Range("AL:AL");
            COSCreditScore.Columns.EntireColumn.AutoFit();
            COSCreditScore.Columns.ColumnWidth = 16;
            COSCreditScore.Columns.NumberFormat = "###";
            excelWorkSheet.get_Range("AL1:AL1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AL1:AL1").Value = "COS Credit Score";

            Excel.Range VIN = excelWorkSheet.get_Range("AM:AM");
            VIN.Columns.EntireColumn.AutoFit();
            VIN.Columns.ColumnWidth = 26;
            excelWorkSheet.get_Range("AM1:AM1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AM1:AM1").Value = "VIN";

            Excel.Range Year = excelWorkSheet.get_Range("AN:AN");
            Year.Columns.EntireColumn.AutoFit();
            Year.Columns.ColumnWidth = 5;
            Year.Columns.NumberFormat = "####";
            excelWorkSheet.get_Range("AN1:AN1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AN1:AN1").Value = "Year";

            Excel.Range Make = excelWorkSheet.get_Range("AO:AO");
            Make.Columns.EntireColumn.AutoFit();
            Make.Columns.ColumnWidth = 18;
            excelWorkSheet.get_Range("AO1:AO1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AO1:AO1").Value = "Make";

            Excel.Range Model = excelWorkSheet.get_Range("AP:AP");
            Model.Columns.EntireColumn.AutoFit();
            Model.Columns.ColumnWidth = 16;
            excelWorkSheet.get_Range("AP1:AP1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AP1:AP1").Value = "Model";

            Excel.Range Mileage = excelWorkSheet.get_Range("AQ:AQ");
            Mileage.Columns.EntireColumn.AutoFit();
            Mileage.Columns.ColumnWidth = 8;
            Mileage.Columns.NumberFormat = "#,##0";
            excelWorkSheet.get_Range("AQ1:AQ1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AQ1:AQ1").Value = "Mileage";

            Excel.Range DealerNum = excelWorkSheet.get_Range("AR:AR");
            DealerNum.Columns.EntireColumn.AutoFit();
            DealerNum.Columns.ColumnWidth = 7;
            DealerNum.Columns.NumberFormat = "###";
            excelWorkSheet.get_Range("AR1:AR1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AR1:AR1").Value = "Dealer";

            Excel.Range DealerName = excelWorkSheet.get_Range("AS:AS");
            DealerName.Columns.EntireColumn.AutoFit();
            DealerName.Columns.ColumnWidth = 26;
            excelWorkSheet.get_Range("AS1:AS1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AS1:AS1").Value = "Dealer Name";

            Excel.Range DealerState = excelWorkSheet.get_Range("AT:AT");
            DealerState.Columns.EntireColumn.AutoFit();
            DealerState.Columns.ColumnWidth = 11;
            excelWorkSheet.get_Range("AT1:AT1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AT1:AT1").Value = "Dealer St.";

            Excel.Range InsCo = excelWorkSheet.get_Range("AU:AU");
            InsCo.Columns.EntireColumn.AutoFit();
            InsCo.Columns.ColumnWidth = 26;
            excelWorkSheet.get_Range("AU1:AU1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AU1:AU1").Value = "Insurance Company";

            Excel.Range PolicyNo = excelWorkSheet.get_Range("AV:AV");
            PolicyNo.Columns.EntireColumn.AutoFit();
            PolicyNo.Columns.ColumnWidth = 16;
            excelWorkSheet.get_Range("AV1:AV1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AV1:AV1").Value = "Policy Number";

            Excel.Range EFFDate = excelWorkSheet.get_Range("AW:AW");
            EFFDate.Columns.EntireColumn.AutoFit();
            EFFDate.Columns.ColumnWidth = 10.57;
            EFFDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("AW1:AW1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AW1:AW1").Value = "EFF Date";

            Excel.Range ExpDate = excelWorkSheet.get_Range("AX:AX");
            ExpDate.Columns.EntireColumn.AutoFit();
            ExpDate.Columns.ColumnWidth = 10.57;
            ExpDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("AX1:AX1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AX1:AX1").Value = "EXP Date";

            Excel.Range RepoInd = excelWorkSheet.get_Range("AY:AY");
            RepoInd.Columns.EntireColumn.AutoFit();
            RepoInd.Columns.ColumnWidth = 9;
            excelWorkSheet.get_Range("AY1:AY1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AY1:AY1").Value = "Repo IND";

            Excel.Range ActStat = excelWorkSheet.get_Range("AZ:AZ");
            ActStat.Columns.EntireColumn.AutoFit();
            ActStat.Columns.ColumnWidth = 9;
            excelWorkSheet.get_Range("AZ1:AZ1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AZ1:AZ1").Value = "Act Stat";

            Excel.Range TierPoints = excelWorkSheet.get_Range("BA:BA");
            TierPoints.Columns.EntireColumn.AutoFit();
            TierPoints.Columns.ColumnWidth = 11;
            TierPoints.Columns.NumberFormat = "###";
            excelWorkSheet.get_Range("BA1:BA1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BA1:BA1").Value = "Tier Points";

            Excel.Range COSTierPoints = excelWorkSheet.get_Range("BB:BB");
            COSTierPoints.Columns.EntireColumn.AutoFit();
            COSTierPoints.Columns.ColumnWidth = 11;
            COSTierPoints.Columns.NumberFormat = "###";
            excelWorkSheet.get_Range("BB1:BB1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BB1:BB1").Value = "COS Tier Points";

            Excel.Range FundingDate = excelWorkSheet.get_Range("BC:BC");
            FundingDate.Columns.EntireColumn.AutoFit();
            FundingDate.Columns.ColumnWidth = 10.57;
            FundingDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("BC1:BC1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BC1:BC1").Value = "Funding Date";

            Excel.Range DealerCashPrice = excelWorkSheet.get_Range("BD:BD");
            DealerCashPrice.Columns.EntireColumn.AutoFit();
            DealerCashPrice.Columns.ColumnWidth = 12;
            DealerCashPrice.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("BD1:BD1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BD1:BD1").Value = "DLR Cash Price";

            Excel.Range PartialPayment = excelWorkSheet.get_Range("BE:BE");
            PartialPayment.Columns.EntireColumn.AutoFit();
            PartialPayment.Columns.ColumnWidth = 12;
            PartialPayment.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("BE1:BE1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BE1:BE1").Value = "Partial Payment";

            Excel.Range Ltv = excelWorkSheet.get_Range("BF:BF");
            Ltv.Columns.EntireColumn.AutoFit();
            Ltv.Columns.ColumnWidth = 10;
            Ltv.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("BF1:BF1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BF1:BF1").Value = "LTV";

            Excel.Range ControlDate = excelWorkSheet.get_Range("BG:BG");
            ControlDate.Columns.EntireColumn.AutoFit();
            ControlDate.Columns.ColumnWidth = 10.57;
            ControlDate.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("BG1:BG1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BG1:BG1").Value = "Control Date";

            Excel.Range FullRecourse = excelWorkSheet.get_Range("BH:BH");
            FullRecourse.Columns.EntireColumn.AutoFit();
            FullRecourse.Columns.ColumnWidth = 9;
            excelWorkSheet.get_Range("BH1:BH1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BH1:BH1").Value = "Full Recourse";

            Excel.Range GapIns = excelWorkSheet.get_Range("BI:BI");
            GapIns.Columns.EntireColumn.AutoFit();
            GapIns.Columns.ColumnWidth = 11;
            excelWorkSheet.get_Range("BI1:BI1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BI1:BI1").Value = "Gap Ins";

            Excel.Range Warranty = excelWorkSheet.get_Range("BJ:BJ");
            Warranty.Columns.EntireColumn.AutoFit();
            Warranty.Columns.ColumnWidth = 9;
            excelWorkSheet.get_Range("BJ1:BJ1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BJ1:BJ1").Value = "Warranty";

            Excel.Range LastPostCode = excelWorkSheet.get_Range("BK:BK");
            LastPostCode.Columns.EntireColumn.AutoFit();
            LastPostCode.Columns.ColumnWidth = 9;
            excelWorkSheet.get_Range("BK1:BK1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BK1:BK1").Value = "Last Post CD";

            // Moses Newman 06/25/2020 Add Payment Type
            Excel.Range PaymentType = excelWorkSheet.get_Range("BL:BL");
            PaymentType.Columns.EntireColumn.AutoFit();
            PaymentType.Columns.ColumnWidth = 9;
            excelWorkSheet.get_Range("BL1:BL1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BL1:BL1").Value = "Pay Type";

            // Moses Newman 06/25/2020 Add Payment Code
            Excel.Range PaymentCode = excelWorkSheet.get_Range("BM:BM");
            PaymentCode.Columns.EntireColumn.AutoFit();
            PaymentCode.Columns.ColumnWidth = 9;
            excelWorkSheet.get_Range("BM1:BM1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BM1:BM1").Value = "Pay Code";

            // Moses Newman 06/25/2020 Add Payment Date
            Excel.Range PaymentDate = excelWorkSheet.get_Range("BN:BN");
            PaymentDate.Columns.EntireColumn.AutoFit();
            PaymentDate.Columns.NumberFormat = "mm/dd/yyyy";
            PaymentDate.Columns.ColumnWidth = 10.57;
            excelWorkSheet.get_Range("BN1:BN1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BN1:BN1").Value = "Payment Date";

            // Moses Newman 06/25/2020 Add Previous Paid Thru
            Excel.Range PrevPaidThru = excelWorkSheet.get_Range("BO:BO");
            PrevPaidThru.Columns.EntireColumn.AutoFit();
            PrevPaidThru.Columns.ColumnWidth = 14;
            PrevPaidThru.NumberFormat = "@";
            PrevPaidThru.Columns.NumberFormat = "00/00";
            excelWorkSheet.get_Range("BO1:BO1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BO1:BO1").Value = "Prev Paid Through";

            Excel.Range TotalPayments = excelWorkSheet.get_Range("BP:BP");
            TotalPayments.Columns.EntireColumn.AutoFit();
            TotalPayments.Columns.ColumnWidth = 14;
            TotalPayments.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("BP1:BP1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BP1:BP1").Value = "Ext. Tot Payments";

            Excel.Range Status = excelWorkSheet.get_Range("BQ:BQ");
            Status.Columns.EntireColumn.AutoFit();
            Status.Columns.ColumnWidth = 14;
            Status.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("BQ1:BQ1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("BQ1:BQ1").Value = "Ext. Contract Status";

            excelWorkSheet.get_Range("A:BQ").Font.Size = 11;
            // Moses Newman 08/01/2018 Freeze header row.
            Excel.Range firstRow = (Excel.Range)excelWorkSheet.Rows[1];
            excelWorkSheet.Activate();
            excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
            firstRow.Application.ActiveWindow.FreezePanes = true;

            Excel.Range U1 = excelWorkSheet.get_Range("A1:BQ1");
            Excel.Range r = excelWorkSheet.get_Range("A2:BQ" + (excelWorkSheet.Rows.Count).ToString());

            U1.Font.Bold = true;
            U1.Font.Color = Excel.XlRgbColor.rgbWhite;
            U1.Interior.Color = Excel.XlRgbColor.rgbGreen;

            Excel.FormatCondition format = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
            format.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206);
            /*Excel.FormatCondition formatodd = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) <> 0");
            formatodd.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206); */
            r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            U1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            if(SelectedFields.Count > 0)
            {
                foreach (Fld SField in FullFieldList.Reverse<Fld>())
                {
                    switch (SField.FldNumber)
                    {
                        case 1:
                            Fname.Delete();
                            break;
                        case 2:
                            Lname.Delete();
                            break;
                        case 3:
                            Address1.Delete();
                            break;
                        case 4:
                            Address2.Delete();
                            break;
                        case 5:
                            City.Delete();
                            break;
                        case 6:
                            State.Delete();
                            break;
                        case 7:
                            ZipCode.Delete();
                            break;
                        case 8:
                            SSN.Delete();
                            break;
                        case 9:
                            DOB.Delete();
                            break;
                        case 10:
                            Type.Delete();
                            break;
                        case 11:
                            CustomerNo.Delete();
                            break;
                        case 12:
                            LegalState.Delete();
                            break;
                        case 13:
                            OriginalMonthly.Delete();
                            break;
                        case 14:
                            Monthly.Delete();
                            break;
                        case 15:
                            LoanAmount.Delete();
                            break;
                        case 16:
                            Cash.Delete();
                            break;
                        case 17:
                            Term.Delete();
                            break;
                        case 18:
                            FC.Delete();
                            break;
                        case 19:
                            LoanInterest.Delete();
                            break;
                        case 20:
                            PaidInterest.Delete();
                            break;
                        case 21:
                            UEI.Delete();
                            break;
                        case 22:
                            Balance.Delete();
                            break;
                        case 23:
                            Buyout.Delete();
                            break;
                        case 24:
                            LCBal.Delete();
                            break;
                        case 25:
                            APR.Delete();
                            break;
                        case 26:
                            ContractDate.Delete();
                            break;
                        case 27:
                            FirstPayDate.Delete();
                            break;
                        case 28:
                            MaturityDate.Delete();
                            break;
                        case 29:
                            NextDueDate.Delete();
                            break;
                        case 30:
                            LastPayDate.Delete();
                            break;
                        case 31:
                            Ext.Delete();
                            break;
                        case 32:
                            PaidThrough.Delete();
                            break;
                        case 33:
                            NumPay.Delete();
                            break;
                        case 34:
                            CreditScore.Delete();
                            break;
                        case 35:
                            AnnualIncome.Delete();
                            break;
                        case 36:
                            Tier.Delete();
                            break;
                        case 37:
                            CosAnnualIncome.Delete();
                            break;
                        case 38:
                            COSCreditScore.Delete();
                            break;
                        case 39:
                            VIN.Delete();
                            break;
                        case 40:
                            Year.Delete();
                            break;
                        case 41:
                            Make.Delete();
                            break;
                        case 42:
                            Model.Delete();
                            break;
                        case 43:
                            Mileage.Delete();
                            break;
                        case 44:
                            DealerNum.Delete();
                            break;
                        case 45:
                            DealerName.Delete();
                            break;
                        case 46:
                            DealerState.Delete();
                            break;
                        case 47:
                            InsCo.Delete();
                            break;
                        case 48:
                            PolicyNo.Delete();
                            break;
                        case 49:
                            EFFDate.Delete();
                            break;
                        case 50:
                            ExpDate.Delete();
                            break;
                        case 51:
                            RepoInd.Delete();
                            break;
                        case 52:
                            ActStat.Delete();
                            break;
                        case 53:
                            TierPoints.Delete();
                            break;
                        case 54:
                            COSTierPoints.Delete();
                            break;
                        case 55:
                            FundingDate.Delete();
                            break;
                        case 56:
                            DealerCashPrice.Delete();
                            break;
                        case 57:
                            PartialPayment.Delete();
                            break;
                        case 58:
                            Ltv.Delete();
                            break;
                        case 59:
                            ControlDate.Delete();
                            break;
                        case 60:
                            FullRecourse.Delete();
                            break;
                        case 61:
                            GapIns.Delete();
                            break;
                        case 62:
                            Warranty.Delete();
                            break;
                        case 63:
                            LastPostCode.Delete();
                            break;
                        case 64:
                            PaymentType.Delete();
                            break;
                        case 65:
                            PaymentCode.Delete();
                            break;
                        case 66:
                            PaymentDate.Delete();
                            break;
                        case 67:
                            PrevPaidThru.Delete();
                            break;
                        case 68:
                            TotalPayments.Delete();
                            break;
                        case 69:
                            Status.Delete();
                            break;
                    }
                }
            }
            if(checkBoxExtensions.Checked)
            {
                Excel.Range last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                for (int i = 2; i < last.Row + 1; i++)
                {
                    excelWorkSheet.Cells[i, 5].Value = Convert.ToInt32(excelWorkSheet.Cells[i, 5].Value);
                    excelWorkSheet.Cells[i, 13].Value = Convert.ToDecimal(excelWorkSheet.Cells[i, 13].Value);
                    excelWorkSheet.Cells[i, 14].Value = Convert.ToDecimal(excelWorkSheet.Cells[i, 14].Value);
                }
            }
            if (checkBoxMatchNBFields.Checked)
            {
                int ClosedCusts = Extensions.CustomerExtract.Select("CUSTOMER_IAC_TYPE = 'C'").Length;
                int OpenCusts = Extensions.CustomerExtract.Select("CUSTOMER_IAC_TYPE = 'O'").Length;
                Excel.Range last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                for (int i = 2; i <= last.Row; i++)
                {
                    excelWorkSheet.Cells[i, 2].Value = Convert.ToDecimal(excelWorkSheet.Cells[i, 2].Value);
                    excelWorkSheet.Cells[i, 8].Value = Convert.ToInt32(excelWorkSheet.Cells[i, 8].Value);
                }


                Excel.Range ClosedTypeCountTotalRange = excelWorkSheet.get_Range("A1:M" + (ClosedCusts + OpenCusts + 2).ToString());
                ClosedTypeCountTotalRange.Subtotal(1, Excel.XlConsolidationFunction.xlCount, new int[] { 1 }, true, false, Excel.XlSummaryRow.xlSummaryBelow);
                Excel.Range ClosedSubTotalRange = excelWorkSheet.get_Range("A1:N" + (ClosedCusts + OpenCusts + 2).ToString());
                ClosedSubTotalRange.Subtotal(9, Excel.XlConsolidationFunction.xlSum, new int[] { 3 }, false, false, Excel.XlSummaryRow.xlSummaryBelow);
                ClosedSubTotalRange.Subtotal(2, Excel.XlConsolidationFunction.xlCount, new int[] { 2 }, false, false, Excel.XlSummaryRow.xlSummaryBelow);

                last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                Excel.Range ARange = excelWorkSheet.get_Range("A1:A" + last.Row.ToString());

                int GrandCount = 0;
                for (int i = last.Row; i > 0; i--)
                {
                    if (excelWorkSheet.Cells[i, 1].Value == "O Count")
                    {
                        excelWorkSheet.Cells[i, 1].Value = "Total Units Open";
                        excelWorkSheet.Cells[i, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i, 2].Font.FontStyle = "Bold";
                    }
                    if (excelWorkSheet.Cells[i, 1].Value == "Grand Count")
                    {
                        GrandCount++;
                        if (GrandCount == 1)
                        {
                            excelWorkSheet.Cells[i, 1].Value = "Grand Total Units";
                            excelWorkSheet.Cells[i, 1].Font.FontStyle = "Bold";
                            excelWorkSheet.Cells[i, 2].Font.FontStyle = "Bold";
                        }
                        if (GrandCount == 2)
                        {
                            excelWorkSheet.Rows[i].Delete();
                            break;
                        }
                    }
                }

                last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                ARange = excelWorkSheet.get_Range("A1:A" + last.Row.ToString());

                for (int i = last.Row; i > 0; i--)
                {
                    if (excelWorkSheet.Cells[i, 1].Value == "C Count")
                    {
                        excelWorkSheet.Cells[i, 1].Value = "Total Units Closed";
                        excelWorkSheet.Cells[i, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i, 2].Font.FontStyle = "Bold";
                        break;
                    }
                }

                for (int i = last.Row; i > 0; i--)
                {
                    if (excelWorkSheet.Cells[i, 1].Value == "C Count" || excelWorkSheet.Cells[i, 1].Value == "O Count")
                    {
                        excelWorkSheet.Cells[i, 1].Value = "Units";
                        excelWorkSheet.Cells[i, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i, 2].Font.FontStyle = "Bold";
                    }
                }
                ARange.ColumnWidth = 17;
                last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                ARange = excelWorkSheet.get_Range("A1:A" + last.Row.ToString());

                Decimal TotalClosedLoans = 0, TotalOpenLoans = 0;
                Int32 TotalUnitsClosed = 0, TotalUnitsOpen = 0;
                for (int i = 1; i <= last.Row; i++)
                {
                    if (excelWorkSheet.Cells[i, 1].Value == "Units")
                    {
                        excelWorkSheet.Cells[i, 1].Value = "Totals DLR# " + excelWorkSheet.Cells[i - 1, 9].Text;
                        excelWorkSheet.Cells[i, 3].Value = Convert.ToDecimal(excelWorkSheet.Cells[i + 1, 3].Value);
                        if (excelWorkSheet.Cells[i - 1, 2].Value == "C")
                            TotalClosedLoans += excelWorkSheet.Cells[i + 1, 3].Value;
                        else
                            TotalOpenLoans += excelWorkSheet.Cells[i + 1, 3].Value;   
                        excelWorkSheet.Cells[i + 1, 3].Value = "";
                        excelWorkSheet.Cells[i + 1, 9].Value = "";
                        excelWorkSheet.Cells[i, 3].Font.FontStyle = "Bold";
                    }
                    if (excelWorkSheet.Cells[i, 1].Value == "Total Units Closed")
                    {
                        TotalUnitsClosed = Convert.ToInt32(excelWorkSheet.Cells[i, 2].Value);
                        excelWorkSheet.Cells[i, 3].Value = TotalClosedLoans;
                        excelWorkSheet.Cells[i, 3].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i, 1].Value = "Totals Closed";
                    }
                    if (excelWorkSheet.Cells[i, 9].Text == "Grand Total")
                    {
                        excelWorkSheet.Rows[i].Delete();
                        break;
                    }
                }
                last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                ARange = excelWorkSheet.get_Range("A1:A" + last.Row.ToString());

                for (int i = last.Row; i > 0; i--)
                {
                    if (excelWorkSheet.Cells[i, 1].Value == "Total Units Open")
                    {
                        TotalUnitsOpen = Convert.ToInt32(excelWorkSheet.Cells[i, 2].Value);
                        excelWorkSheet.Cells[i, 3].Value = TotalOpenLoans;
                        excelWorkSheet.Cells[i, 3].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i, 1].Value = "Totals Open";
                    }
                }
                last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                ARange = excelWorkSheet.get_Range("A1:A" + last.Row.ToString());

                for (int i = last.Row; i > 0; i--)
                {
                    if (excelWorkSheet.Cells[i, 1].Value == "Totals Closed")
                        excelWorkSheet.Rows[i + 1].Insert();
                }
                last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                ARange = excelWorkSheet.get_Range("A1:A" + last.Row.ToString());
                for (int i = last.Row; i > 0; i--)
                {
                    if (excelWorkSheet.Cells[i, 1].Value == "Grand Total Units")
                    {
                        excelWorkSheet.Cells[i, 1].Value = "Total Closed+Open";
                        excelWorkSheet.Cells[i, 3].Value = TotalClosedLoans + TotalOpenLoans;
                        excelWorkSheet.Cells[i, 3].Font.FontStyle = "Bold";
                        excelWorkSheet.Rows[i + 1].Insert();
                        excelWorkSheet.Rows[i + 1].Insert();
                        excelWorkSheet.Rows[i + 1].Insert();
                        excelWorkSheet.Rows[i + 1].Insert();
                        excelWorkSheet.Rows[i + 1].Insert();
                        excelWorkSheet.Rows[i + 1].Insert();
                        excelWorkSheet.Rows[i + 1].Insert();
                        break;
                    }
                }
                last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
                ARange = excelWorkSheet.get_Range("A1:A" + last.Row.ToString());
                for (int i = last.Row; i > 0; i--)
                {
                    if (excelWorkSheet.Cells[i, 1].Value == "Total Closed+Open")
                    {
                        excelWorkSheet.Cells[i + 3, 1].Value = "Total Closed Units";
                        excelWorkSheet.Cells[i + 3, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 3, 2].Value = TotalUnitsClosed;
                        excelWorkSheet.Cells[i + 3, 2].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 4, 1].Value = "Total Open Units";
                        excelWorkSheet.Cells[i + 4, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 4, 2].Value = TotalUnitsOpen;
                        excelWorkSheet.Cells[i + 4, 2].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 5, 1].Value = "Grand Total Units";
                        excelWorkSheet.Cells[i + 5, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 5, 2].Value = TotalUnitsClosed+TotalUnitsOpen;
                        excelWorkSheet.Cells[i + 5, 2].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 6, 1].Value = "Total Closed Loans";
                        excelWorkSheet.Cells[i + 6, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 6, 3].Value = TotalClosedLoans;
                        excelWorkSheet.Cells[i + 6, 3].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 7, 1].Value = "Total Open Loans";
                        excelWorkSheet.Cells[i + 7, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 7, 3].Value = TotalOpenLoans;
                        excelWorkSheet.Cells[i + 7, 3].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 8, 1].Value = "Grand Total Loans";
                        excelWorkSheet.Cells[i + 8, 1].Font.FontStyle = "Bold";
                        excelWorkSheet.Cells[i + 8, 3].Value = TotalClosedLoans +TotalOpenLoans;
                        excelWorkSheet.Cells[i + 8, 3].Font.FontStyle = "Bold";

                        break;
                    }
                }
            }
            excelWorkBook.Save();
            excelWorkBook.Close();
            excelApp.Quit();
            MessageBox.Show("*** CUSTOMER BANK extract file created successfully! ***");
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            // Moses Newman 03/25/2020 Add Control Date
            if(txtControlDateStart.Text.Trim() != "" && txtControlDateStart.Text.Length == 4 && txtControlDateEnd.Text.Trim() != "" && txtControlDateEnd.Text.Length == 4)
            {
                DateTime ldCtrlDateStart, ldCtrlDateEnd;

                lnControlMonthStart = Convert.ToInt32(txtControlDateStart.Text.Substring(0, 2));
                lnControlYearStart   = Convert.ToInt32(txtControlDateStart.Text.Substring(2, 2));
                lnControlMonthEnd = Convert.ToInt32(txtControlDateEnd.Text.Substring(0, 2));
                lnControlYearEnd = Convert.ToInt32(txtControlDateEnd.Text.Substring(2, 2));

                ldCtrlDateStart = DateTime.Parse(lnControlMonthStart.ToString().PadLeft(2,'0')+"/01/"+DateTime.Now.Year.ToString().Substring(0, 2) + lnControlYearStart.ToString());
                ldCtrlDateEnd = DateTime.Parse(lnControlMonthEnd.ToString().PadLeft(2, '0') + "/01/" + DateTime.Now.Year.ToString().Substring(0, 2) + lnControlYearEnd.ToString());
                ldCtrlDateEnd = ldCtrlDateEnd.AddMonths(1).AddDays(-1);
                if (!checkBoxMatchNBFields.Checked)  // Moses Newman 07/01/2020
                {
                    ldStart = ldCtrlDateStart;
                    ldEnd = ldCtrlDateEnd;
                    nullableDateTimePickerStartDate.Value = ldStart;
                    nullableDateTimePickerEndDate.Value = ldEnd;
                    nullableDateTimePickerStartDate.Refresh();
                    nullableDateTimePickerEndDate.Refresh();
                    lnControlMonthStart = 0;
                    lnControlMonthEnd = 0;
                    lnControlYearStart = 0;
                    lnControlYearEnd = 0;
                }
            }
            else
            {
                lnControlMonthStart = 0;
                lnControlYearStart = 0;
                lnControlMonthEnd = 0;
                lnControlYearEnd = 0;
            }
            ldStart = ((DateTime)nullableDateTimePickerStartDate.Value).Date;
            ldEnd = ((DateTime)nullableDateTimePickerEndDate.Value).Date;
            // Moses Newman 03/30/2016 add seperate paid interest date range selection.
            ldPIStart = ((DateTime)nullableDateTimePickerPIStartDate.Value).Date;
            ldPIEnd = ((DateTime)nullableDateTimePickerPIEndDate.Value).Date;
            if (radioButtonActive.Checked)
                lsStat = "A%";
            else
                if (radioButtonInactive.Checked)
                    lsStat = "I%";
            if (comboBoxDealer.Text.TrimEnd().Length == 3)
                lsDealer = comboBoxDealer.Text.TrimEnd() + lsDealer;
            // Moses Newman 03/26/2015 Added Repo and Dealer State Filters
            if (checkBoxRepos.Checked)
                lsRepo = "Y%";
            else
                lsRepo = "%";
            lsDealerState = (comboBoxState.SelectedValue != null) ? comboBoxState.SelectedValue.ToString().TrimStart().TrimEnd() + "%" : "%";
            MDIIAC2013 MDIMain = (MDIIAC2013)MdiParent;
            MDIMain.CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_FillExtract);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_FillExtractProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Create Bank CUSTOMER Extract File (Bank";
            lfrm.lblProgress.Text = "Creating Bank Customer Extract File";
            lfrm.ShowDialog();
            lfrm.Close();
            Close();
        }

        private void RefreshFieldListBoxes()
        {
            listBoxFieldList.DataSource = null;
            listBoxFieldList.Items.Clear();
            listBoxSelectedFields.DataSource = null;
            listBoxSelectedFields.Items.Clear();
            var SortedList = FullFieldList.OrderBy(x => x.FldNumber);
            FullFieldList = SortedList.ToList();
            SortedList = SelectedFields.OrderBy(x => x.FldNumber);
            SelectedFields = SortedList.ToList(); 
            listBoxFieldList.DataSource = FullFieldList;
            listBoxSelectedFields.DataSource = SelectedFields;
            listBoxFieldList.DisplayMember = "EXCELColumnName";
            listBoxFieldList.ValueMember = "EXCELColumnName";
            listBoxSelectedFields.DisplayMember = "EXCELColumnName";
            listBoxSelectedFields.ValueMember = "EXCELColumnName";
            listBoxSelectedFields.Refresh();
            listBoxFieldList.Refresh();
        }
        private void buttonMoveSelectedFieldsRight_Click(object sender, EventArgs e)
        {
            if(listBoxFieldList.SelectedItems.Count > 0)
            {
                foreach(Fld Selection in listBoxFieldList.SelectedItems)
                {
                    if (!SelectedFields.Contains(Selection))
                    {
                        SelectedFields.Add(Selection);
                        FullFieldList.Remove(Selection);
                    }
                }
                RefreshFieldListBoxes();
            }
        }

        private void checkBoxMatchNBFields_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxMatchNBFields.Checked)
            {
                if (checkBoxExtensions.Checked)
                    checkBoxExtensions.Checked = false;
                if (checkBoxTrialBalance.Checked)
                    checkBoxTrialBalance.Checked = false;

                FullFieldList.Clear();
                if (FullFieldList.Count != FieldListData.ExtractFieldList.Rows.Count)
                {
                    for (int i = 0; i < FieldListData.ExtractFieldList.Rows.Count; i++)
                    {
                        ExField.FldName = FieldListData.ExtractFieldList.Rows[i].Field<String>("FieldName");
                        ExField.EXCELColumnName = FieldListData.ExtractFieldList.Rows[i].Field<String>("EXCELColumnName");
                        ExField.NBField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("NewBusinessField");
                        ExField.NBOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("NBOrder");
                        ExField.ExtField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("ExtensionField");
                        ExField.ExtOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("ExtOrder");
                        ExField.FldNumber = i + 1;
                        FullFieldList.Add(ExField);
                    }
                }
                SelectedFields.Clear();
                foreach (Fld Selection in listBoxFieldList.Items)
                    if (Selection.NBField)
                    {
                        SelectedFields.Add(Selection);
                        FullFieldList.Remove(Selection);
                    }
                RefreshFieldListBoxes();
            }
            else
            {
                if (FullFieldList.Count != FieldListData.ExtractFieldList.Rows.Count)
                {
                    FullFieldList.Clear();
                    for (int i = 0; i < FieldListData.ExtractFieldList.Rows.Count; i++)
                    {
                        ExField.FldName = FieldListData.ExtractFieldList.Rows[i].Field<String>("FieldName");
                        ExField.EXCELColumnName = FieldListData.ExtractFieldList.Rows[i].Field<String>("EXCELColumnName");
                        ExField.NBField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("NewBusinessField");
                        ExField.NBOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("NBOrder");
                        ExField.ExtField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("ExtensionField");
                        ExField.ExtOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("ExtOrder");
                        ExField.FldNumber = i + 1;
                        FullFieldList.Add(ExField);
                    }
                }
                SelectedFields.Clear();
                listBoxFieldList.DataSource = FullFieldList;
                listBoxSelectedFields.DataSource = SelectedFields;
                RefreshFieldListBoxes();
            }
        }

        private void checkBoxMatchNBFields_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxTrialBalance_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxExtensions.Checked)
                checkBoxExtensions.Checked = false;
            if(checkBoxMatchNBFields.Checked)
                checkBoxMatchNBFields.Checked = false;

        }

        private void checkBoxExtensions_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxExtensions.Checked)
            {
                if (checkBoxTrialBalance.Checked)
                    checkBoxTrialBalance.Checked = false;
                if (checkBoxMatchNBFields.Checked)
                    checkBoxMatchNBFields.Checked = false;

                FullFieldList.Clear();
                if (FullFieldList.Count != FieldListData.ExtractFieldList.Rows.Count)
                {
                    for (int i = 0; i < FieldListData.ExtractFieldList.Rows.Count; i++)
                    {
                        ExField.FldName = FieldListData.ExtractFieldList.Rows[i].Field<String>("FieldName");
                        ExField.EXCELColumnName = FieldListData.ExtractFieldList.Rows[i].Field<String>("EXCELColumnName");
                        ExField.NBField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("NewBusinessField");
                        ExField.NBOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("NBOrder");
                        ExField.ExtField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("ExtensionField");
                        ExField.ExtOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("ExtOrder");
                        ExField.FldNumber = i + 1;
                        FullFieldList.Add(ExField);
                    }
                }
                SelectedFields.Clear();
                foreach (Fld Selection in listBoxFieldList.Items)
                    if (Selection.ExtField)
                    {
                        SelectedFields.Add(Selection);
                        FullFieldList.Remove(Selection);
                    }
                RefreshFieldListBoxes();
            }
            else
            {
                if (FullFieldList.Count != FieldListData.ExtractFieldList.Rows.Count)
                {
                    FullFieldList.Clear();
                    for (int i = 0; i < FieldListData.ExtractFieldList.Rows.Count; i++)
                    {
                        ExField.FldName = FieldListData.ExtractFieldList.Rows[i].Field<String>("FieldName");
                        ExField.EXCELColumnName = FieldListData.ExtractFieldList.Rows[i].Field<String>("EXCELColumnName");
                        ExField.NBField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("NewBusinessField");
                        ExField.NBOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("NBOrder");
                        ExField.ExtField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("ExtensionField");
                        ExField.ExtOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("ExtOrder");
                        ExField.FldNumber = i + 1;
                        FullFieldList.Add(ExField);
                    }
                }
                SelectedFields.Clear();
                listBoxFieldList.DataSource = FullFieldList;
                listBoxSelectedFields.DataSource = SelectedFields;
                RefreshFieldListBoxes();
            }
        }

        private void buttonMoveAllFieldsRight_Click(object sender, EventArgs e)
        {
            if (FullFieldList.Count != FieldListData.ExtractFieldList.Rows.Count)
            {
                FullFieldList.Clear();
                for (int i = 0; i < FieldListData.ExtractFieldList.Rows.Count; i++)
                {
                    ExField.FldName = FieldListData.ExtractFieldList.Rows[i].Field<String>("FieldName");
                    ExField.EXCELColumnName = FieldListData.ExtractFieldList.Rows[i].Field<String>("EXCELColumnName");
                    ExField.NBField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("NewBusinessField");
                    ExField.NBOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("NBOrder");
                    ExField.ExtField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("ExtensionField");
                    ExField.ExtOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("ExtOrder");
                    ExField.FldNumber = i + 1;
                    FullFieldList.Add(ExField);
                }
            }
            SelectedFields.Clear();
            SelectedFields.AddRange(FullFieldList);
            FullFieldList.Clear();
            RefreshFieldListBoxes();
        }

        private void buttonMoveSelectedFieldsLeft_Click(object sender, EventArgs e)
        {
            if (listBoxSelectedFields.SelectedItems.Count > 0)
            {
                foreach (Fld Selection in listBoxSelectedFields.SelectedItems)
                {
                    if (!FullFieldList.Contains(Selection))
                    {
                        FullFieldList.Add(Selection);
                        SelectedFields.Remove(Selection);
                    }
                }
                listBoxFieldList.DataSource = FullFieldList;
                listBoxSelectedFields.DataSource = SelectedFields;
                RefreshFieldListBoxes();
            }
        }

        private void buttonMoveAllFieldsLeft_Click(object sender, EventArgs e)
        {
            if (FullFieldList.Count != FieldListData.ExtractFieldList.Rows.Count)
            {
                FullFieldList.Clear();
                for (int i = 0; i < FieldListData.ExtractFieldList.Rows.Count; i++)
                {
                    ExField.FldName = FieldListData.ExtractFieldList.Rows[i].Field<String>("FieldName");
                    ExField.EXCELColumnName = FieldListData.ExtractFieldList.Rows[i].Field<String>("EXCELColumnName");
                    ExField.NBField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("NewBusinessField");
                    ExField.NBOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("NBOrder");
                    ExField.ExtField = FieldListData.ExtractFieldList.Rows[i].Field<Boolean>("ExtensionField");
                    ExField.ExtOrder = FieldListData.ExtractFieldList.Rows[i].Field<Int32>("ExtOrder");
                    ExField.FldNumber = i + 1;
                    FullFieldList.Add(ExField);
                }
            }
            SelectedFields.Clear();
            listBoxFieldList.DataSource = FullFieldList;
            listBoxSelectedFields.DataSource = SelectedFields;
            RefreshFieldListBoxes();
        }

        private void worker_FillExtract(object sender, DoWorkEventArgs e)
        {
            object loContractDate = null;
            
            IACDataSet Bank = new IACDataSet();
            // Moses Newman 06/26/2020 add New Extension functionality.
            PaymentDataSet Extensions = new PaymentDataSet();

            PaymentDataSetTableAdapters.CustomerExtractTableAdapter CustomerExtractTableAdapter = new PaymentDataSetTableAdapters.CustomerExtractTableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            // Moses Newman 03/28/2020 Add Open Customer History Table Adapter to use ContractDate function.
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            IACDataSetTableAdapters.VEHICLETableAdapter VEHICLETableAdapter = new IACDataSetTableAdapters.VEHICLETableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            // Moses Newman 06/26/2020 add New Extension functionality.
            PaymentDataSetTableAdapters.ExtensionsTableAdapter ExtensionsTableAdapter = new PaymentDataSetTableAdapters.ExtensionsTableAdapter();
            PaymentDataSetTableAdapters.OpenExtensionsTableAdapter OpenExtensionsTableAdapter = new PaymentDataSetTableAdapters.OpenExtensionsTableAdapter();

            // Moses Newman 01/17/2020 Add checkBoxTrialBalance to match Trial Balance.
            // Moses Newman 03/25/2020 Add ControlDate
            // Moses Newman 06/26/2020 add New Extension functionality.
            if (!checkBoxExtensions.Checked)
                CUSTOMERTableAdapter.FillBySelection(Bank.CUSTOMER,
                                            lsStat, ldStart, ldEnd, lsDealer, lsDealerState, lsRepo,
                                            checkBoxTrialBalance.Checked, checkBoxFundingDate.Checked,
                                            lnControlMonthStart, lnControlYearStart, lnControlMonthEnd, lnControlYearEnd);
            else
                CUSTOMERTableAdapter.FillByExtensions(Bank.CUSTOMER, lsStat, ldStart, ldEnd, lsDealer, lsDealerState, lsRepo,
                                                      checkBoxTrialBalance.Checked, checkBoxFundingDate.Checked,
                                                      lnControlMonthStart, lnControlYearStart, lnControlMonthEnd, lnControlYearEnd);
            // Moses Newman 06/26/2020 add New Extension functionality.
            if (!checkBoxExtensions.Checked)
                OPNCUSTTableAdapter.FillBySelection(Bank.OPNCUST, lsStat, ldStart, ldEnd, lsDealer, lsDealerState, checkBoxTrialBalance.Checked,
                                                lnControlMonthStart, lnControlYearStart, lnControlMonthEnd, lnControlYearEnd);
            else
                OPNCUSTTableAdapter.FillByExtensions(Bank.OPNCUST, lsStat, ldStart, ldEnd, lsDealer, lsDealerState,
                                                      checkBoxTrialBalance.Checked, checkBoxFundingDate.Checked,
                                                      lnControlMonthStart, lnControlYearStart, lnControlMonthEnd, lnControlYearEnd);

            if (Bank.CUSTOMER.Rows.Count < 1 && Bank.OPNCUST.Rows.Count < 1)
            {
                MessageBox.Show("*** THERE ARE NO CUSTOMERS SELECTED FOR EXTRACT! ***");
                return;
            }
            CustomerExtractTableAdapter.DeleteAll();
            Decimal lnProg = 0, lnPaidInterest = 0;
            Object loPaidInterest = null;  // 03/25/2016 Moses Newman 

            PaymentDataSet.CustomerExtractRow TempRec;

            int RowCount = 0;
            for (Int32 i = 0; i < Bank.CUSTOMER.Rows.Count; i++)
            {
                lnProg = ((Decimal)(i + 1) / (Decimal)Bank.CUSTOMER.Rows.Count) * (Decimal)100;
                lsProgMessage = "Record: " + i.ToString().TrimStart() + " of " + Bank.CUSTOMER.Rows.Count.ToString() + ".";
                worker.ReportProgress((Int32)lnProg);

                TempRec = Extensions.CustomerExtract.NewCustomerExtractRow();
                TempRec.CUSTOMER_IAC_TYPE = "C";
                TempRec.CUSTOMER_NO = "";
                TempRec.CUSTOMER_ADD_ON = "";

                Extensions.CustomerExtract.Rows.Add(TempRec);
                DEALERTableAdapter.Fill(Bank.DEALER, Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_DEALER"));
                // Moses Newman 01/29/2020 
                CUSTHISTTableAdapter.FillByGetNewRecord(Bank.CUSTHIST, Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));

                // Required Fields
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_NO", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_ADD_ON", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ADD_ON"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_IAC_TYPE", "C");
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_DEALER", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_DEALER"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("DEALER_NAME", Bank.DEALER.Rows[0].Field<String>("DEALER_NAME"));
                // Moses Newman 04/21/2014 Add DEALER_STATE
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("DEALER_STATE", Bank.DEALER.Rows[0].Field<String>("DEALER_ST"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_FIRST_NAME", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_FIRST_NAME"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_LAST_NAME", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_LAST_NAME"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_STREET_1", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_STREET_1"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_STREET_2", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_STREET_2"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_CITY", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CITY"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_STATE", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_STATE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("ZipCode", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ZIP_1")+ Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ZIP_2"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("SSN", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_SS_1")+ "-" +Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_SS_2")+ "-" +Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_SS_3"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_DOB", Bank.CUSTOMER.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_DOB"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_ORIGINAL_AMOUNT", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_LOAN_AMOUNT", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_AMOUNT"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_LOAN_CASH", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_CASH"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_TERM", Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_TD_FINANCE_CHARGE", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_LOAN_INTEREST", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LOAN_INTEREST"));
                // 03/25/2016 Moses Newman Get buyout as of buyout date entered
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_BALANCE", Program.TVSimpleGetBuyout(Bank,
                    (DateTime)nullableDateTimePickerBuyoutDate.Value,
                    (Double)Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM"),
                    (Double)(Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                    (Double)Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                    Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
                // Moses Newman 04/30/2017 Handle S for simple interest, or N for Normal Daily Compounding
                Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, false, false, false, -1, true));
                // 03/25/2016 Moses Newman add Paid Interest field summed for date range passed.
                loPaidInterest = CUSTOMERTableAdapter.GetPaidInterest(Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), ldPIStart, ldPIEnd);
                if (loPaidInterest != null)
                    lnPaidInterest = (Decimal)loPaidInterest;
                else
                    lnPaidInterest = 0;
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("PaidInterest", lnPaidInterest);  // 03/25/2016 Moses Newman add paid interest
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_BUYOUT", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BUYOUT"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_UE_INTEREST", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_UE_INTEREST"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_CONTRACT_DATE", ClosedContractDate(Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO")));
                Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("CUSTOMER_INIT_DATE", Bank.CUSTOMER.Rows[i].Field<DateTime>("CUSTOMER_INIT_DATE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_MATURITY_DATE", Bank.CUSTOMER.Rows[i].Field<DateTime>("CUSTOMER_INIT_DATE").AddMonths(Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM") - 1));
                // Moses Newman 04/15/2014 Changed to use AddMonth Method instead of VisualBasic DateAdd!
                //Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_MATURITY_DATE", DateAndTime.DateAdd(DateInterval.Month, ((Double)Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM")) - 1, Bank.CUSTOMER.Rows[i].Field<DateTime>("CUSTOMER_INIT_DATE")));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_NEXT_DUE_DATE", Program.NextDueDate(i, Bank));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE", Bank.CUSTOMER.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_MONTHS_EXTENDED", ClosedExtension(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_NO")));
                // Moses Newman 01/09/2018 Added CUSTOMER_NO_OF_PAYMENTS_MADE and CUSTOMER_CREDIT_SCORE_N, CUSTOMER_PAID_THRU
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_PAID_THRU", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PAID_THRU").Substring(0,2) + "/" + Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PAID_THRU").Substring(2, 2));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_CREDIT_SCORE_N", Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_CREDIT_SCORE_N"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_CREDIT_SCORE_A", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CREDIT_SCORE_A"));

                // Collateral Information
                VEHICLETableAdapter.FillByCustomerNo(Bank.VEHICLE, Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_NO"));
                if (Bank.VEHICLE.Rows.Count > 0)  // Moses Newman 03/11/2020 handle NULL VIN or MAKE.
                {
                    // Moses Newman 03/11/2020 
                    if (Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_VIN") == null)
                    {
                        Bank.VEHICLE.Rows[0].SetField<String>("VEHICLE_VIN", "Missing VIN#!!!");
                        VEHICLETableAdapter.Update(Bank.VEHICLE.Rows[0]);
                    }
                    if (Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_MAKE") == null)
                    {
                        Bank.VEHICLE.Rows[0].SetField<String>("VEHICLE_MAKE", "Missing MAKE!!!");
                        VEHICLETableAdapter.Update(Bank.VEHICLE.Rows[0]);
                    }
                    if (Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_MAKE").Length > 0 || Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_MAKE").Length > 0)
                    {
                        Extensions.CustomerExtract.Rows[RowCount].SetField<String>("VEHICLE_VIN", Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_VIN"));
                        Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("VEHICLE_YEAR", Bank.VEHICLE.Rows[0].Field<Int32>("VEHICLE_YEAR"));
                        Extensions.CustomerExtract.Rows[RowCount].SetField<String>("VEHICLE_MAKE", Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_MAKE"));
                        Extensions.CustomerExtract.Rows[RowCount].SetField<String>("VEHICLE_MODEL", Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_MODEL"));
                        Extensions.CustomerExtract.Rows[RowCount].SetField<String>("VEHICLE_INS_COMPANY", Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_INS_COMPANY"));
                        Extensions.CustomerExtract.Rows[RowCount].SetField<String>("VEHICLE_POLICY_NO", Bank.VEHICLE.Rows[0].Field<String>("VEHICLE_POLICY_NO"));
                        if (Bank.VEHICLE.Rows[0].Field<Nullable<DateTime>>("VEHICLE_EFF_DATE") != null && Bank.VEHICLE.Rows[0].Field<DateTime>("VEHICLE_EFF_DATE").Year > 2000)
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("VEHICLE_EFF_DATE", Bank.VEHICLE.Rows[0].Field<Nullable<DateTime>>("VEHICLE_EFF_DATE"));
                        else
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("VEHICLE_EFF_DATE", Convert.ToDateTime("01/01/1980"));
                        if (Bank.VEHICLE.Rows[0].Field<Nullable<DateTime>>("VEHICLE_EXP_DATE") != null && Bank.VEHICLE.Rows[0].Field<DateTime>("VEHICLE_EXP_DATE").Year > 2000)
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("VEHICLE_EXP_DATE", Bank.VEHICLE.Rows[0].Field<Nullable<DateTime>>("VEHICLE_EXP_DATE"));
                        else
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("VEHICLE_EXP_DATE", Convert.ToDateTime("01/01/1980"));
                    }
                }
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_REPO_IND", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_REPO_IND"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_ACT_STAT", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ACT_STAT"));
                // Moses Newman 01/09/2018 Added AnnualIncome, Tier, CosignerCreditScore, CosignerAnnualIncome, Mileage
                if (Bank.CUSTOMER.Rows[i].Field<Decimal?>("AnnualIncome") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("AnnualIncome", Bank.CUSTOMER.Rows[i].Field<Decimal>("AnnualIncome"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("AnnualIncome",0);
                if (Bank.CUSTOMER.Rows[i].Field<Decimal?>("Tier") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Tier", Bank.CUSTOMER.Rows[i].Field<Decimal>("Tier"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Tier", 0);
                if (Bank.CUSTOMER.Rows[i].Field<Decimal?>("CosignerCreditScore") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerCreditScore", Bank.CUSTOMER.Rows[i].Field<Decimal>("CosignerCreditScore"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerCreditScore", 0);
                if (Bank.CUSTOMER.Rows[i].Field<Decimal?>("CosignerAnnualIncome") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerAnnualIncome", Bank.CUSTOMER.Rows[i].Field<Decimal>("CosignerAnnualIncome"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerAnnualIncome", 0);
                // Moses Newman 04/29/2019 Initialize Mileage to 0 and only change if there is a matching vehicle record and the Vehicle.Mileage field is not null!
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Mileage", 0);
                if (Bank.VEHICLE.Rows.Count > 0)
                {
                    if (Bank.VEHICLE.Rows[0].Field<Decimal?>("Mileage") != null)
                        Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Mileage", Bank.VEHICLE.Rows[0].Field<Decimal>("Mileage"));
                }
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Mileage", 0);
                // Moses Newman 01/29/2020 Add New Fields
                if (Bank.CUSTOMER.Rows[i].Field<Decimal?>("TierPoints") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("TierPoints", Bank.CUSTOMER.Rows[i].Field<Decimal>("TierPoints"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("TierPoints", 0);
                if (Bank.CUSTOMER.Rows[i].Field<Decimal?>("CosignerTierPoints") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerTierPoints", Bank.CUSTOMER.Rows[i].Field<Decimal>("CosignerTierPoints"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerTierPoints", 0);
                if (Bank.CUSTOMER.Rows[i].Field<DateTime?>("FundingDate") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("FundingDate", Bank.CUSTOMER.Rows[i].Field<DateTime>("FundingDate"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("FundingDate", Convert.ToDateTime("01/01/1980"));
                if (Bank.VEHICLE.Rows.Count > 0)
                {
                    if (Bank.VEHICLE.Rows[0].Field<Decimal?>("DealerCashPrice") != null)
                        Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("DealerCashPrice", Bank.VEHICLE.Rows[0].Field<Decimal>("DealerCashPrice"));
                    else
                        Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("DealerCashPrice", 0);
                }
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("DealerCashPrice", 0);
                if (Bank.CUSTOMER.Rows[i].Field<Decimal?>("PartialPayment") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("PartialPayment", Bank.CUSTOMER.Rows[i].Field<Decimal>("PartialPayment"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("PartialPayment", 0);
                if (Bank.VEHICLE.Rows.Count > 0)
                {
                    if (Bank.VEHICLE.Rows[0].Field<Decimal?>("Ltv") != null)
                        Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Ltv", Bank.VEHICLE.Rows[0].Field<Decimal>("Ltv"));
                    else
                        Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Ltv", 0);
                }
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Ltv", 0);
                if (Bank.CUSTHIST.Rows.Count > 0)
                    // Moses Newman 03/28/2020 Just use full Transaction Date from NEW History Record
                    Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("ControlDate",
                        Bank.CUSTHIST.Rows[0].Field<DateTime>("TransactionDate"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("ControlDate", Convert.ToDateTime("01/01/1980"));
                if (Bank.CUSTOMER.Rows[i].Field<Boolean?>("IsFullRecourse") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("IsFullRecourse", Bank.CUSTOMER.Rows[i].Field<Boolean>("IsFullRecourse"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("IsFullRecourse", false);
                if (Bank.CUSTOMER.Rows[i].Field<String>("GapIns") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<String>("GapIns", Bank.CUSTOMER.Rows[i].Field<String>("GapIns"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<String>("GapIns", "");
                if (Bank.CUSTOMER.Rows[i].Field<Boolean?>("Warranty") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("Warranty", Bank.CUSTOMER.Rows[i].Field<Boolean>("Warranty"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("Warranty", false);
                if (Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PAYMENT_TYPE") != null && Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PAYMENT_CODE") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<String>("LastPostingCode", 
                        Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PAYMENT_TYPE") + Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PAYMENT_CODE"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<String>("LastPostingCode", "");
                if (checkBoxExtensions.Checked)
                {
                    ExtensionsTableAdapter.FillByCustomerNo(Extensions.Extensions, Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), ldStart, ldEnd, lnControlMonthStart, lnControlYearStart, lnControlMonthStart, lnControlMonthEnd);
                    if (Extensions.Extensions.Rows.Count > 0)
                    {
                        int tempID;
                        for (int hcount = 0; hcount < Extensions.Extensions.Rows.Count; hcount++)
                        {
                            if (hcount != 0)
                            {
                                TempRec = Extensions.CustomerExtract.NewCustomerExtractRow();
                                tempID = TempRec.ID;
                                TempRec.ItemArray = Extensions.CustomerExtract.Rows[RowCount].ItemArray;
                                TempRec.ID = tempID;
                                 
                                Extensions.CustomerExtract.Rows.Add(TempRec);
                                RowCount++;
                            }
                            Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_PAYMENT_TYPE", "E");
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_MONTHS_EXTENDED",
                                Extensions.Extensions.Rows[hcount].Field<Int32?>("CUSTHIST_THRU_UD") != null ? Extensions.Extensions.Rows[hcount].Field<Int32>("CUSTHIST_THRU_UD") : 0);
                            Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_PAYMENT_CODE",
                                Extensions.Extensions.Rows[hcount].Field<String>("CUSTHIST_PAYMENT_CODE"));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_PAID_THRU",
                                Extensions.Extensions.Rows[hcount].Field<String>("CUSTHIST_PAID_THRU").Substring(0, 2)+"/"+ Extensions.Extensions.Rows[hcount].Field<String>("CUSTHIST_PAID_THRU").Substring(2, 2));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<String>("PREVIOUS_PAID_THRU",
                                Extensions.Extensions.Rows[hcount].Field<String>("PREVIOUS_PAID_THRU").Substring(0, 2)+"/"+ Extensions.Extensions.Rows[hcount].Field<String>("PREVIOUS_PAID_THRU").Substring(2, 2));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("PaymentDate",
                                Extensions.Extensions.Rows[hcount].Field<DateTime>("CUSTHIST_PAY_DATE"));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("TotalPayments",
                                (Extensions.Extensions.Rows[hcount].Field<Decimal?>("TotalPayments") != null ? Extensions.Extensions.Rows[hcount].Field<Decimal>("TotalPayments"):0));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Status",
                                (Extensions.Extensions.Rows[hcount].Field<Decimal?>("ContractStatus") != null ? Extensions.Extensions.Rows[hcount].Field<Decimal>("ContractStatus") : 0));
                            CustomerExtractTableAdapter.Update(Extensions.CustomerExtract.Rows[RowCount]);
                        }
                    }
                }
                else
                {
                    Extensions.CustomerExtract.Rows[RowCount].SetField<String>("PREVIOUS_PAID_THRU", "");
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("TotalPayments",0);
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Status",0);
                    CustomerExtractTableAdapter.Update(Extensions.CustomerExtract.Rows[RowCount]);
                }
                RowCount++;
            }
            
            Open = true;
            for (Int32 i = 0; i < Bank.OPNCUST.Rows.Count; i++)
            {
                lnProg = ((Decimal)(i + 1) / (Decimal)Bank.OPNCUST.Rows.Count) * (Decimal)100;
                lsProgMessage = "Record: " + i.ToString().TrimStart() + " of " + Bank.OPNCUST.Rows.Count.ToString() + ".";
                worker.ReportProgress((Int32)lnProg);

                TempRec = Extensions.CustomerExtract.NewCustomerExtractRow();
                TempRec.CUSTOMER_IAC_TYPE = "O";
                TempRec.CUSTOMER_NO = "";
                TempRec.CUSTOMER_ADD_ON = "";

                Extensions.CustomerExtract.Rows.Add(TempRec);

                OPNDEALRTableAdapter.Fill(Bank.OPNDEALR, Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_DEALER"));

                // Required Fields
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_NO", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_ADD_ON", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_ADD_ON"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_IAC_TYPE", "O");
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_DEALER", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_DEALER"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("DEALER_NAME", Bank.OPNDEALR.Rows[0].Field<String>("OPNDEALR_NAME"));
                // Moses Newman 04/21/2014 Add DEALER_STATE
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("DEALER_STATE", Bank.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ST"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_FIRST_NAME", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_FIRST_NAME"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_LAST_NAME", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_LAST_NAME"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_STREET_1", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_STREET_1"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_STREET_2", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_STREET_2"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_CITY", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_CITY"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_STATE", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_STATE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("ZipCode", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_ZIP_1")+ Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_ZIP_2"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("SSN", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_SS_1")+ "-" + Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_SS_2")+ "-" + Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_SS_3"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_DOB", Bank.OPNCUST.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_DOB_DATE"));
    // Moses Newman 09/11/2013 make sure no null values!
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_REG_AMOUNT1") == null)
                    Bank.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_REG_AMOUNT1", 0);
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_REGULAR_AMOUNT") == null)
                    Bank.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", 0);
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_LOAN_AMOUNT") == null)
                    Bank.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_LOAN_AMOUNT", 0);
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_LOAN_CASH") == null)
                    Bank.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_LOAN_CASH", 0);
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Int32>>("CUSTOMER_TERM") == null)
                    Bank.OPNCUST.Rows[i].SetField<Int32>("CUSTOMER_TERM", 0);
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_TOT_FINANCE_CHARGE") == null)
                    Bank.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_TOT_FINANCE_CHARGE", 0);
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_BALANCE") == null)
                    Bank.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_BALANCE", 0);
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_LATE_CHARGE_BAL") == null)
                    Bank.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
                if (Bank.OPNCUST.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_INTEREST_RATE1") == null)
                    Bank.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_INTEREST_RATE1", 0);

                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_ORIGINAL_AMOUNT", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_REG_AMOUNT1"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_LOAN_AMOUNT", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_LOAN_AMOUNT"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_LOAN_CASH", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_LOAN_CASH"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_TERM", Bank.OPNCUST.Rows[i].Field<Int32>("CUSTOMER_TERM"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_TD_FINANCE_CHARGE", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_TOT_FINANCE_CHARGE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_LOAN_INTEREST", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_UE_INTEREST", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_BALANCE", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_BUYOUT", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE", Bank.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_INTEREST_RATE1"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("CUSTOMER_CONTRACT_DATE", Bank.OPNCUST.Rows[i].Field<DateTime>("CUSTOMER_CONTRACT_DATE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("CUSTOMER_INIT_DATE", Bank.OPNCUST.Rows[i].Field<DateTime>("CUSTOMER_INIT_DATE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_NEXT_DUE_DATE", Program.OpenNextDueDate(i, Bank));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE", Bank.OPNCUST.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_MONTHS_EXTENDED", OpenExtension(Extensions.CustomerExtract.Rows[RowCount].Field<String>("CUSTOMER_NO")));
                // Moses Newman 01/09/2018 Added CUSTOMER_NO_OF_PAYMENTS_MADE and CUSTOMER_CREDIT_SCORE_N
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_CREDIT_SCORE_N", Bank.OPNCUST.Rows[i].Field<Int32>("CUSTOMER_CREDIT_SCORE_N"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_CREDIT_SCORE_A", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_CREDIT_SCORE_A"));
                // Moses Newman 01/09/2018 Init AnnualIncome, Tier, CosingerCreditScore, CosignerAnnualIncome,Mileage to 0 because not on Open loans
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("AnnualIncome", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Tier", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerCreditScore", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerAnnualIncome", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Mileage", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_PAID_THRU", Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAID_THRU").Substring(0,2)+"/"+ Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAID_THRU").Substring(2, 2));
                // Moses Newman 01/29/2020 Add New Fields
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("TierPoints", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CosignerTierPoints", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("FundingDate", Convert.ToDateTime("01/01/1980"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("DealerCashPrice", 0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("PartialPayment",0);
                Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Ltv", 0);

                // Moses Newman 03/28/2020 Add Real ControlDate
                loContractDate = OPNHCUSTTableAdapter.ControlDate(Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"));
                if (loContractDate != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("ControlDate", (DateTime)loContractDate); 
                    
                Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("IsFullRecourse", false);
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("GapIns", "");
                Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("Warranty", false);
                if (Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAY_TYPE") != null && Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAY_CODE") != null)
                    Extensions.CustomerExtract.Rows[RowCount].SetField<String>("LastPostingCode",
                        Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAY_TYPE") + Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_PAY_CODE"));
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<String>("LastPostingCode", "");
                if (checkBoxExtensions.Checked)
                {
                    OpenExtensionsTableAdapter.FillByCustomerNo(Extensions.OpenExtensions, Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"), ldStart, ldEnd, lnControlMonthStart, lnControlYearStart, lnControlMonthStart, lnControlMonthEnd);
                    if (Extensions.OpenExtensions.Rows.Count > 0)
                    {
                        int tempID;
                        for (int hcount = 0; hcount < Extensions.OpenExtensions.Rows.Count; hcount++)
                        {
                            if (hcount != 0)
                            {
                                TempRec = Extensions.CustomerExtract.NewCustomerExtractRow();
                                tempID = TempRec.ID;
                                TempRec.ItemArray = Extensions.CustomerExtract.Rows[RowCount].ItemArray;
                                TempRec.ID = tempID;

                                Extensions.CustomerExtract.Rows.Add(TempRec);
                                RowCount++;
                            }

                            Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_PAY_TYPE", "E");
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_MONTHS_EXTENDED",
                                Extensions.OpenExtensions.Rows[hcount].Field<Int32?>("CUSTHIST_THRU_UD") != null ? Extensions.OpenExtensions.Rows[hcount].Field<Int32>("CUSTHIST_THRU_UD") : 0);
                            Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_PAY_CODE",
                                Extensions.OpenExtensions.Rows[hcount].Field<String>("CUSTHIST_PAYMENT_CODE"));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_PAID_THRU",
                                Extensions.OpenExtensions.Rows[hcount].Field<String>("CUSTHIST_PAID_THRU").Substring(0, 2) + "/" + Extensions.OpenExtensions.Rows[hcount].Field<String>("CUSTHIST_PAID_THRU").Substring(2, 2));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<String>("PREVIOUS_PAID_THRU",
                                Extensions.OpenExtensions.Rows[hcount].Field<String>("PREVIOUS_PAID_THRU").Substring(0, 2) + "/" + Extensions.OpenExtensions.Rows[hcount].Field<String>("PREVIOUS_PAID_THRU").Substring(2, 2));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("PaymentDate",
                                Extensions.OpenExtensions.Rows[hcount].Field<DateTime>("CUSTHIST_PAY_DATE"));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("TotalPayments",
                                (Extensions.OpenExtensions.Rows[hcount].Field<Decimal?>("TotalPayments") != null ? Extensions.OpenExtensions.Rows[hcount].Field<Decimal>("TotalPayments") : 0));
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Status",
                                (Extensions.OpenExtensions.Rows[hcount].Field<Decimal?>("ContractStatus") != null ? Extensions.OpenExtensions.Rows[hcount].Field<Decimal>("ContractStatus") : 0));

                            CustomerExtractTableAdapter.Update(Extensions.CustomerExtract.Rows[RowCount]);
                        }
                    }
                }
                else
                {
                    Extensions.CustomerExtract.Rows[RowCount].SetField<String>("PREVIOUS_PAID_THRU", "");
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("TotalPayments", 0);
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("Status", 0);
                    CustomerExtractTableAdapter.Update(Extensions.CustomerExtract.Rows[RowCount]);
                }
                RowCount++;
            }
            Open = false;
            CreateTextFile(Bank,Extensions);
            Bank.Dispose();
        }

        private void worker_FillExtractProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)MdiParent;
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.QueryprogressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : 100;
            if (CreateTabs)
                lfrm.lblProgress.Text = "Creating TAB Delimited File Bank" + "\n"+ lsProgMessage;
            else
                if (!Open)
                    lfrm.lblProgress.Text = "Inserting Closed Customer Records Into CustomerExtract SQL Server Table" + "\n" + lsProgMessage;
                else
                    lfrm.lblProgress.Text = "Inserting Open Customer Records Into CustomerExtract SQL Server Table" + "\n" + lsProgMessage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)MdiParent;
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Close();
        }

        private Int32 ClosedExtension(String CustomerNo)
        {
            Object loExtension = null;
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();

            loExtension = CUSTHISTTableAdapter.Extension(CustomerNo);
            CUSTHISTTableAdapter.Dispose();
            if (loExtension != null)
                return Convert.ToInt32(loExtension);
            else
                return (Int32)0;
        }

        private DateTime ClosedPaidThrough(String CustomerNo)
        {
            Object loPaidThrough = null;
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();

            loPaidThrough = CUSTOMERTableAdapter.FullPaidThroughDate(CustomerNo);
            CUSTOMERTableAdapter.Dispose();
            if (loPaidThrough != null)
                return Convert.ToDateTime(loPaidThrough);
            else
                return DateTime.Parse("01/01/1980");
        }

        private DateTime OpenPaidThrough(String CustomerNo)
        {
            Object loPaidThrough = null;
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();

            loPaidThrough = OPNCUSTTableAdapter.FullPaidThroughDate(CustomerNo);
            OPNCUSTTableAdapter.Dispose();
            if (loPaidThrough != null)
                return Convert.ToDateTime(loPaidThrough);
            else
                return DateTime.Parse("01/01/1980");
        }

        private Nullable<DateTime> ClosedContractDate(String CustomerNo)
        {
            Object loContractDate = null;
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();

            loContractDate = CUSTHISTTableAdapter.ContractDate(CustomerNo);
            CUSTHISTTableAdapter.Dispose();
                   
            if (loContractDate != null)
                return (DateTime)loContractDate;
            else
                return null;
        }

        private Int32 OpenExtension(String CustomerNo)
        {
            Object loExtension = null;
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();

            loExtension = OPNHCUSTTableAdapter.Extension(CustomerNo);
            OPNHCUSTTableAdapter.Dispose();
            if (loExtension != null)
                return Convert.ToInt32(loExtension);
            else
                return (Int32)0;
        }
    }
}

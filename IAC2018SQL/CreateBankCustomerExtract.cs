using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DevExpress.Export.Xl;
using System.Net;
using System.Text;
using DevExpress.Spreadsheet;


namespace IAC2021SQL
{
    public partial class frmCreateBankCustomerExtract : DevExpress.XtraEditors.XtraForm
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
            this.aCCOUNTTableAdapter.Fill(this.Bank.ACCOUNT);
            radioGroupMatch.SelectedIndex = -1;
            // Moses Newman 04/20/2014 Add Active Inactive or Both, Dealer choice, and date range.
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            // Moses Newman 01/28/2020 Add field picker tab.
            radioButtonActive.Checked = true;
            nullableDateTimePickerStartDate.EditValue = DateTime.Parse("01/01/1980");
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
            // Moses Newman 03/30/2016 add seperate paid interest date range selection.
            nullableDateTimePickerPIStartDate.EditValue = DateTime.Parse("01/01/1980");
            nullableDateTimePickerPIEndDate.EditValue = DateTime.Now.Date;
            // 03/25/2016 Moses Newman add buyout date field 
            nullableDateTimePickerBuyoutDate.EditValue = DateTime.Now.Date;
            bindingSourceDLRLISTBYNUM.DataSource = Bank.DLRLISTBYNUM;
            DLRLISTBYNUMTableAdapter.Fill(Bank.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            Bank.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
            lookUpEditDealer.Properties.DataSource = bindingSourceDLRLISTBYNUM;
            //Moses Newman 03/11/2020 Add Funding Date Search default to unchecked
            checkBoxFundingDate.Checked = false;

            stateTableAdapter.Fill(Bank.state);
            bindingSourceState.DataSource = Bank.state;
          
            bindingSourceState.AddNew();
            bindingSourceState.EndEdit();
            Bank.state.Rows[bindingSourceState.Position].SetField("abbreviation", "");
            Bank.state.Rows[bindingSourceState.Position].SetField("name", "");
            bindingSourceState.EndEdit();
           
            lookUpEditState.Properties.DataSource = bindingSourceState;
            lookUpEditState.Properties.DisplayMember = "name";
            lookUpEditState.Properties.ValueMember = "abbreviation";
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
            // Moses Newman 07/18/2024
            FullFieldList.Sort((f1,f2) => f1.EXCELColumnName.CompareTo(f2.EXCELColumnName));
            listBoxFieldList.DataSource = FullFieldList;
            listBoxFieldList.DisplayMember = "EXCELColumnName";
            listBoxFieldList.ValueMember = "EXCELColumnName";
            listBoxFieldList.Refresh();
            layoutControlSelectionCriteria.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            layoutControlSelectionCriteria.LookAndFeel.UseDefaultLookAndFeel = false;
            layoutControlSelectionCriteria.OptionsView.ShareLookAndFeelWithChildren = false;
            layoutControlFieldSelection.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            layoutControlFieldSelection.LookAndFeel.UseDefaultLookAndFeel = false;
            layoutControlFieldSelection.OptionsView.ShareLookAndFeelWithChildren = false;
        }

        private Decimal GetBalance(String tsCustomerNo, DateTime tdDateIn)
        {
            String lsDateIn = tdDateIn.Month.ToString() + "-" + tdDateIn.Day.ToString() + "-" + tdDateIn.Year.ToString();
            String requestURL = "https://payments.iaccredit.com/WCFHost/Services/PhonePayServiceRest.svc/rest/GetBalanceWithDate/" + tsCustomerNo + "/" +lsDateIn;

            HttpWebRequest msgrequest = HttpWebRequest.Create(requestURL) as HttpWebRequest;
            msgrequest.Method = "GET";
            msgrequest.ContentType = "application/xml";
            // Moses Newman 05/06/2024 No more hard coded passwords and usernames.
            Credentials credentials = new Credentials();
            CredentialsTableAdapters.SSHCredTableAdapter sSHCredTableAdapter = new CredentialsTableAdapters.SSHCredTableAdapter();
            sSHCredTableAdapter.Fill(credentials.SSHCred, 6);
            String username = credentials.SSHCred.Rows[0].Field<String>("Username"),
            password = credentials.SSHCred.Rows[0].Field<String>("Password");

            
            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                                           .GetBytes(username + ":" + password));

            msgrequest.Headers.Add("Authorization", "Basic " + encoded); 
            HttpWebResponse msgresponse = (HttpWebResponse)msgrequest.GetResponse();
            WebHeaderCollection msgheader = msgresponse.Headers;

            var encoding = ASCIIEncoding.ASCII;
            String responseText;
            using (var reader = new System.IO.StreamReader(msgresponse.GetResponseStream(), encoding))
            {
                responseText = reader.ReadLine();
            }
            return Convert.ToDecimal(responseText);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreateTextFile(IACDataSet Bank, PaymentDataSet Extensions)
        {
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
            PaymentDataSetTableAdapters.CustomerExtractTableAdapter CustomerExtractTableAdapter = new PaymentDataSetTableAdapters.CustomerExtractTableAdapter();

            DataPathTableAdapter.Fill(Bank.DataPath);
            String sourcePath = Bank.DataPath.Rows[0].Field<String>("Path").TrimEnd(),
                   lsExcelFileOut = sourcePath + @"comp1000\Bank.xlsx",
                   lsTemplate = sourcePath + @"comp1000\TemplateCustomerExtract.xlsx";

            try
            {
                if (File.Exists(lsExcelFileOut))
                    File.Delete(lsExcelFileOut);
            }
            catch
            {
                MessageBox.Show("Could Not Open Bank.xlsx because someone has it open!", "EXCEL File In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            sourcePath = lsExcelFileOut;
            Int32 RowCount = Extensions.CustomerExtract.Rows.Count;

            // Create an exporter instance. 
            IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xlsx);
            // Create the FileStream object with the specified file path.
            using (FileStream stream = new FileStream(sourcePath, FileMode.Create, FileAccess.ReadWrite))
            {
                // Create a new document and begin to write it to the specified stream.
                using (IXlDocument document = exporter.CreateDocument(stream))
                {
                    // Add a new worksheet to the document. 
                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        // Specify the worksheet name.
                        sheet.Name = "Customer Bank Extract";
                        sheet.OutlineProperties.SummaryBelow = true;
                        // Create an instance of the XlConditionalFormatting class.
                        XlConditionalFormatting formatting = new XlConditionalFormatting();
                        //formatting.Ranges.Add(XlCellRange.RowInterval(0, Extensions.CustomerExtract.Rows.Count));
                        //XlCondFmtRuleExpression rule = new XlCondFmtRuleExpression("=MOD(ROW(),2) = 0");
                        //rule.Formatting = XlFill.SolidFill(System.Drawing.Color.FromArgb(198, 239, 206));
                        //formatting.Rules.Add(rule);
                        //sheet.ConditionalFormattings.Add(formatting);
                        // Freeze the first row in the worksheet.
                        sheet.SplitPosition = new XlCellPosition(0, 1);
                        // Open the XLSX document using the default application.
                        sheet.HeaderFooter.DifferentOddEven = false;
                        sheet.HeaderFooter.EvenHeader = XlHeaderFooter.FromLCR(null, XlHeaderFooter.Bold + XlHeaderFooter.BookName, null);
                        // Specify cell font attributes.
                        XlCellFormatting cellFormatting = new XlCellFormatting();
                        cellFormatting.Font = new XlFont();
                        cellFormatting.Font.Name = "Calibri";
                        cellFormatting.Font.SchemeStyle = XlFontSchemeStyles.None;
                        cellFormatting.Font.Size = 11;
                        cellFormatting.Border = XlBorder.OutlineBorders(XlColor.FromArgb(0x47, 0x7B, 0xD1), XlBorderLineStyle.Thick);

                        // Specify formatting settings for the header row.
                        XlCellFormatting headerRowFormatting = new XlCellFormatting();
                        headerRowFormatting.CopyFrom(cellFormatting);
                        headerRowFormatting.Font.Bold = true;
                        headerRowFormatting.Font.Size = 11;
                        headerRowFormatting.Font.Name = "Calibri";
                        headerRowFormatting.Font.Color = XlColor.FromTheme(XlThemeColor.Light1, 0.0);
                        headerRowFormatting.Fill = XlFill.SolidFill(System.Drawing.Color.Blue);

                        // Create the First Name column and set its width. 
                        if (SelectedFields.Count == 0)
                        {
                            SelectedFields.AddRange(FullFieldList);
                        }
                        var SortedList = SelectedFields.OrderBy(x => x.FldNumber);
                        foreach (Fld SField in SortedList)
                        {
                            switch (SField.FldNumber)
                            {
                                case 1:

                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 13;
                                    }
                                    break;
                                case 2:
                                    // Create the Last Name column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 19;
                                    }
                                    break;
                                case 3:
                                    // Create the Address 1 column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 30;
                                    }
                                    break;
                                case 4:
                                    // Create the Address 2 column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 13;
                                    }
                                    break;
                                case 5:
                                    // Create the City column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 15;
                                    }
                                    break;
                                case 6:
                                    // Create the State column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 6;
                                    }
                                    break;
                                case 7:
                                    // Create the Zip Code column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 11;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "00000-0000";
                                    }
                                    break;
                                case 8:
                                    // Create the SSN column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 12;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "000-00-0000";
                                    }
                                    break;
                                case 9:
                                    // Create the DOB column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 11;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 10:
                                    // Create the Type column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 5;
                                    }
                                    break;
                                case 11:
                                    // Create the Account No. column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 12;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "000000";
                                    }
                                    break;
                                case 12:
                                    // Create the Legal St. column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 10;
                                    }
                                    // Create the Org. Monthly column and set its width. 
                                    break;
                                case 13:
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 12;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 14:
                                    // Create the Monthly column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 10;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 15:
                                    // Create the Loan Amount column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 16;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 16:
                                    // Create the Cash column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 12;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 17:
                                    // Create the Term column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 5;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "00";
                                    }
                                    break;
                                case 18:
                                    // Create the FC column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 6;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 19:
                                    // Create the Loan Int. column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 10;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 20:
                                    // Create the Paid Int. column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 10;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 21:
                                    // Create the UEI column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 6;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 22:
                                    // Create the Balance column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 10;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 23:
                                    // Create the Buyout column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 10;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 24:
                                    // Create the L/C Balance column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 12;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 25:
                                    // Create the APR column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 10;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "##0.000#%;[Red]-##0.000#%";
                                    }
                                    break;
                                case 26:
                                    // Create the Contract Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 27:
                                    // Create the 1st Pay Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 28:
                                    // Create the Maturity Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 29:
                                    // Create the Nxt Due Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 30:
                                    // Create the Last Pay Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 31:
                                    // Create the Ext column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 4;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "####";
                                    }
                                    break;
                                case 32:
                                    // Create the Paid Through column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "00/00";
                                    }
                                    break;
                                case 33:
                                    // Create the Num Pay column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 7;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "###";
                                    }
                                    break;
                                case 34:
                                    // Create the Credit Score column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 11;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "###";
                                    }
                                    break;
                                case 35:
                                    // Create the Annual Income column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 13;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 36:
                                    // Create the Tier column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 5;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "#";
                                    }
                                    break;
                                case 37:
                                    // Create the COS Annual Income column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 17;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 38:
                                    // Create the COS Credit Score column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 16;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "###";
                                    }
                                    break;
                                case 39:
                                    // Create the VIN column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 26;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 40:
                                    // Create the Year column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 5;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "####";
                                    }
                                    break;
                                case 41:
                                    // Create the Make column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 18;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 42:
                                    // Create the Model column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 16;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 43:
                                    // Create the Mileage column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 8;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "#,##0";
                                    }
                                    break;
                                case 44:
                                    // Create the Dealer column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 7;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "####";
                                    }
                                    break;
                                case 45:
                                    // Create the Dealer Name column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 26;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 46:
                                    // Create the Dealer St. column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 11;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 47:
                                    // Create the Insurance Company column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 26;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 48:
                                    // Create the Policy Number column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 16;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 49:
                                    // Create the EFF Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = (float)10.57;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 50:
                                    // Create the EXP Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = (float)10.57;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 51:
                                    // Create the Repo IND column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 9;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 52:
                                    // Create the Act Stat column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 9;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 53:
                                    // Create the Tier Points and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 11;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "###";
                                    }
                                    break;
                                case 54:
                                    // Create the COS Tier Points and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 11;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "###";
                                    }
                                    break;
                                case 55:
                                    // Create the Funding Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 12;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 56:
                                    // Create the DLR Cash Payment column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 12;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 57:
                                    // Create the Partial Payment column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 12;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 58:
                                    // Create the LTV column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 10;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "##0.00##%;[Red]-##0.00##%";
                                    }
                                    break;
                                case 59:
                                    // Create the Control Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = (float)10.57;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 60:
                                    // Create the Full Recourse column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 9;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 61:
                                    // Create the Gap Ins column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 11;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 62:
                                    // Create the Warranty column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 9;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 63:
                                    // Create the Last Post CD column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 9;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 64:
                                    // Create the Pay Type column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 9;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 65:
                                    // Create the Pay Code column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 9;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 66:
                                    // Create the Payment Date column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = (float)10.57;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 67:
                                    // Create the Prev Paid Through column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "00/00";
                                    }
                                    break;
                                case 68:
                                    // Create the Ext. Total Payments column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 69:
                                    // Create the Ext. Contract Status column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                                    }
                                    break;
                                case 70:
                                    // Create the Title Received column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 14;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 71:
                                    // Create the Date Title Received column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 19;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                                case 72:
                                    // Create the Electronic Lien column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 15;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 73:
                                    // Create the Received Contract column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = 15;
                                        column.Formatting = new XlCellFormatting();
                                    }
                                    break;
                                case 74:
                                    // Create the Date Contract Received column and set its width. 
                                    using (IXlColumn column = sheet.CreateColumn())
                                    {
                                        column.WidthInCharacters = (float)10.57;
                                        column.Formatting = new XlCellFormatting();
                                        column.Formatting.IsDateTimeFormatString = true;
                                        column.Formatting.NetFormatString = "d";
                                    }
                                    break;
                            }
                        }
                        using (IXlRow row = sheet.CreateRow())
                        {
                            foreach (Fld SField in SortedList)
                            {
                                // Create the header row.
                                switch (SField.FldNumber)
                                {
                                    case 1:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "First Name";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 2:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Last Name";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 3:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Address 1";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 4:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Address 2";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 5:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "City";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 6:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "State";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 7:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Zip+4";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 8:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "SSN";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 9:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "DOB";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 10:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Type";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 11:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Account No.";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 12:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Legal St.";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 13:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Org. Monthly";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 14:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Monthly";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 15:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Loan Amount";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 16:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Cash";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 17:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Term";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 18:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "FC";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 19:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Loan Int.";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 20:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Paid Int.";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 21:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "UEI";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 22:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Balance";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 23:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Buyout";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 24:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "L/C Balance";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 25:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "APR";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 26:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Contract Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 27:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "1st Pay Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 28:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Maturity Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 29:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Nxt Due Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 30:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Last Pay Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 31:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Ext";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 32:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Paid Through";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 33:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Num Pay";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 34:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Credit Score";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 35:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Annual Income";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 36:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Tier";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 37:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "COS Annual Income";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 38:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "COS Credit Score";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 39:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "VIN";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 40:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Year";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 41:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Make";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 42:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Model";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 43:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Mileage";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 44:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Dealer";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 45:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Dealer Name";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 46:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Dealer St.";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 47:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Insurance Company";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 48:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Policy Number";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 49:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "EFF Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 50:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "EXP Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 51:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Repo IND";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 52:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Act Stat";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 53:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Tier Points";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 54:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "COS Tier Points";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 55:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Funding Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 56:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "DLR Cash Price";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 57:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Partial Payment";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 58:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "LTV";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 59:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Control Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 60:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Full Recourse";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 61:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Gap Ins";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 62:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Warranty";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 63:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Last Post CD";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 64:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Pay Type";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 65:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Pay Code";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 66:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Payment Date";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 67:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Prev Paid Through";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 68:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Ext. Tot Payments";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 69:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Ext. Contract Status";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 70:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Title Received";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 71:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Date Title Received";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 72:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Electronic Lien";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 73:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Received Contract";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                    case 74:
                                        using (IXlCell cell = row.CreateCell())
                                        {
                                            cell.Value = "Date Contract Received";
                                            cell.ApplyFormatting(headerRowFormatting);
                                        }
                                        break;
                                }
                            }
                        }
                        // Create Data Rows

                        for (int i = 0; i < RowCount; i++)
                        {
                            using (IXlRow row = sheet.CreateRow())
                            {
                                foreach (Fld sfield in SortedList)
                                {
                                    switch (sfield.FldNumber)
                                    {
                                        case 1:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_FIRST_NAME");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 2:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_LAST_NAME");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 3:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_STREET_1");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 4:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_STREET_2");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 5:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_CITY");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 6:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_STATE");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 7:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("ZipCode");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 8:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("SSN");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 9:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("CUSTOMER_DOB") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("CUSTOMER_DOB") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 10:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_IAC_TYPE");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 11:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_NO"); ;
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 12:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_STATE");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 13:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_REGULAR_AMOUNT") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 14:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_REGULAR_AMOUNT") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 15:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_LOAN_AMOUNT") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 16:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_LOAN_CASH") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 17:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("CUSTOMER_TERM") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 18:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_FINANCE_CHARGE") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 19:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_LOAN_INTEREST") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 20:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("PaidInterest") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 21:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_UE_INTEREST") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 22:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_BALANCE") ?? (Decimal)0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 23:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_BUYOUT") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 24:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_LATE_CHARGE_BAL") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 25:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                Double tempAPR = (Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") ?? (Decimal)000.0000);
                                                tempAPR = tempAPR / (Double)100.0000;
                                                cell.Value = (XlVariantValue)tempAPR;
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 26:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("CUSTOMER_CONTRACT_DATE") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("CUSTOMER_CONTRACT_DATE") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 27:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("CUSTOMER_INIT_DATE") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("CUSTOMER_INIT_DATE") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 28:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("CUSTOMER_MATURITY_DATE") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("CUSTOMER_MATURITY_DATE") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 29:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("CUSTOMER_NEXT_DUE_DATE") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("CUSTOMER_NEXT_DUE_DATE") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 30:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("CUSTOMER_LAST_PAYMENT_DATE") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("CUSTOMER_LAST_PAYMENT_DATE") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 31:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("CUSTOMER_MONTHS_EXTENDED") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 32:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_PAID_THRU");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 33:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("CUSTOMER_NO_OF_PAYMENTS_MADE") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 34:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("CUSTOMER_CREDIT_SCORE_N") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 35:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("AnnualIncome") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 36:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("Tier") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 37:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("CosignerAnnualIncome") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 38:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("CosignerCreditScore") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 39:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("VEHICLE_VIN");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 40:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("VEHICLE_YEAR") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 41:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("VEHICLE_MAKE");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 42:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("VEHICLE_MODEL");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 43:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("Mileage") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 44:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("CUSTOMER_DEALER") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 45:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("DEALER_NAME");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 46:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("DEALER_STATE");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 47:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("VEHICLE_INS_COMPANY");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 48:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("VEHICLE_POLICY_NO");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 49:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("VEHICLE_EFF_DATE") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("VEHICLE_EFF_DATE") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 50:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("VEHICLE_EXP_DATE") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("VEHICLE_EXP_DATE") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 51:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_REPO_IND");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 52:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_ACT_STAT");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 53:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("TierPoints") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 54:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Int32?>("CosignerTierPoints") ?? 0);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 55:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("FundingDate") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("FundingDate") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 56:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("DealerCashPrice") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 57:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("PartialPayment") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 58:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                Double tempLTV = (Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("Ltv") ?? (Decimal)000.0000);
                                                tempLTV = tempLTV / (Double)100.000;
                                                cell.Value = (XlVariantValue)tempLTV;
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 59:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("ControlDate") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("ControlDate") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 60:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Boolean?>("IsFullRecourse") ?? false);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 61:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("GapIns");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 62:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Boolean?>("Warranty") ?? false);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 63:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("LastPostingCode");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 64:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_PAYMENT_TYPE");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 65:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("CUSTOMER_PAYMENT_CODE");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 66:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("PaymentDate") != null ?
                                                    (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("PaymentDate") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 67:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<String>("PREVIOUS_PAID_THRU");
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 68:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("TotalPayments") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 69:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Double)(Extensions.CustomerExtract.Rows[i].Field<Decimal?>("Status") ?? (Decimal)0.00);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 70:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Boolean?>("TitleReceived") ?? false);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 71:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("TitleDateReceived") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("TitleDateReceived") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 72:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Boolean?>("ElectronicLien") ?? false);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 73:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = (XlVariantValue)(Extensions.CustomerExtract.Rows[i].Field<Boolean?>("ReceivedContract") ?? false);
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                        case 74:
                                            using (IXlCell cell = row.CreateCell())
                                            {
                                                cell.Value = Extensions.CustomerExtract.Rows[i].Field<DateTime?>("DateContractReceived") != null ?
                                                               (XlVariantValue)Extensions.CustomerExtract.Rows[i].Field<DateTime>("DateContractReceived") : (XlVariantValue)"";
                                                cell.ApplyFormatting(cellFormatting);
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //Process.Start(new ProcessStartInfo(sourcePath) { UseShellExecute = true });

            if (radioGroupMatch.SelectedIndex == 0)
            {
                Workbook workbook = new Workbook();
                workbook.LoadDocument(sourcePath);

                WorksheetCollection worksheets = workbook.Worksheets;

                Worksheet excelWorkSheet = workbook.Worksheets["Customer Bank Extract"];

                excelWorkSheet.Columns["J"].Insert();
                excelWorkSheet.Columns["F"].MoveTo(excelWorkSheet.Columns["J"]);
                excelWorkSheet.Columns.Remove("F");
                excelWorkSheet.Columns["B"].Insert();
                excelWorkSheet.Columns["G"].MoveTo(excelWorkSheet.Columns["B"]);
                excelWorkSheet.Columns.Remove("G");
                int ClosedCusts = Extensions.CustomerExtract.Select("CUSTOMER_IAC_TYPE = 'C'").Length,
                    OpenCusts = Extensions.CustomerExtract.Select("CUSTOMER_IAC_TYPE = 'O'").Length,
                    SubCount =0;
                
                CellRange ClosedSubTotalRange = excelWorkSheet["A2:N" + (ClosedCusts + OpenCusts + 1).ToString()];
                // Specify that subtotals should be calculated for the column "D". 
                List<int> subtotalColumnsList = new List<int>();

                // Moses Newman 02/03/2024 Count total Closed vs. Open!
                subtotalColumnsList.Add(0);
                excelWorkSheet.Subtotal(ClosedSubTotalRange, 0, subtotalColumnsList, 3, "Count");

                SubCount = excelWorkSheet.GetUsedRange().RowCount;
                SubCount -= OpenCusts - 2;
                ClosedSubTotalRange = excelWorkSheet["A2:N" + SubCount.ToString()];
                subtotalColumnsList.Clear();
                subtotalColumnsList.Add(3);
                subtotalColumnsList.Add(5);
                excelWorkSheet.Subtotal(ClosedSubTotalRange, 2, subtotalColumnsList, 1, "Average");
                
                //ClosedSubTotalRange.Subtotal(7, Excel.XlConsolidationFunction.xlAverage, new int[] { 3 }, false, false, Excel.XlSummaryRow.xlSummaryBelow);
                // Dealer Total
                SubCount = excelWorkSheet.GetUsedRange().RowCount;
                SubCount -= OpenCusts - 3;
                ClosedSubTotalRange = excelWorkSheet["A2:N" + SubCount.ToString()];
                subtotalColumnsList.Clear();
                subtotalColumnsList.Add(3);
                excelWorkSheet.Subtotal(ClosedSubTotalRange, 2, subtotalColumnsList, 9, "Total Loan Amount");
                //ClosedSubTotalRange.Subtotal(7, Excel.XlConsolidationFunction.xlSum, new int[] { 3 }, false, false, Excel.XlSummaryRow.xlSummaryBelow);
                
                SubCount++;
                subtotalColumnsList.Clear();
                subtotalColumnsList.Add(1);
                SubCount = excelWorkSheet.GetUsedRange().RowCount;
                SubCount -= OpenCusts -4;
                ClosedSubTotalRange = excelWorkSheet["A2:N" + SubCount.ToString()];

                excelWorkSheet.Subtotal(ClosedSubTotalRange, 2, subtotalColumnsList, 3, "Count");
                //ClosedTypeCountTotalRange.Subtotal(1, Excel.XlConsolidationFunction.xlCount, new int[] { 1 }, true, false, Excel.XlSummaryRow.xlSummaryBelow);
                

                SearchOptions options = new SearchOptions();
                options.SearchBy = SearchBy.Columns;
                options.SearchIn = SearchIn.Values;
                options.MatchEntireCellContents = true;

                //IEnumerable<Cell> searchResult = excelWorkSheet.Search("O Count", options);
                IEnumerable<Cell>  searchResult = excelWorkSheet["A2:A" + excelWorkSheet.GetUsedRange().RowCount.ToString()];
                String ClosedFormula = "", OpenFormula = "";
                Int32 GC = 0;
                foreach (Cell cell in searchResult)
                {
                    switch (cell.Value.ToString().Trim())
                    {
                        case "C Count":
                            cell.Value = "Total Closed Loans";
                            cell.Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 1].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].Formula = "=SUMIF(B2..B" + (cell.RowIndex - 1).ToString() + ",\"C\",D2..D" +
                                (cell.RowIndex - 1).ToString() + ")";
                            ClosedFormula = excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].Formula;
                            break;
                        case "O Count":
                            cell.Value = "Total Open Loans";
                            cell.Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 1].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].Formula = "=SUMIF(B2..B" + (cell.RowIndex - 1).ToString() + ",\"O\",D2..D" +
                                (cell.RowIndex - 1).ToString() + ")";
                            OpenFormula = "SUMIF(B2..B" + (cell.RowIndex - 1).ToString() + ",\"O\",D2..D" +
                                (cell.RowIndex - 1).ToString() + ")";
                            break;
                        case "Grand Count":
                            cell.Value = "Total Closed+Open";
                            cell.Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 1].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].Formula = ClosedFormula + " + " + OpenFormula;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 2].NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            excelWorkSheet[cell.RowIndex + 2, cell.ColumnIndex + 3].Value = null;
                            excelWorkSheet.Columns[0].ColumnWidth *= 4;
                            break;
                    }
                }
                searchResult = excelWorkSheet["C2:C" + excelWorkSheet.GetUsedRange().RowCount.ToString()];
                foreach (Cell cell in searchResult)
                {
                    switch (cell.Value.ToString().Trim())
                    {
                        case "Grand Average":
                            cell.Value = null;
                            cell.Font.FontStyle = SpreadsheetFontStyle.Regular;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex - 2].Value = "Grand Average Loan Amount / APR";
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex - 2].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 1].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 3].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            break;
                        case "Grand Count":
                            cell.Value = null;
                            cell.Font.FontStyle = SpreadsheetFontStyle.Regular;
                            excelWorkSheet[cell.RowIndex, cell.ColumnIndex - 1].Value = null;
                            break;
                        case "Grand Total Loan Amount":
                            cell.Value = null;
                            cell.Font.FontStyle = SpreadsheetFontStyle.Regular;
                            break;
                    }
                    if (string.Join(" ", cell.Value.ToString().Split(' ').Skip(1)) == "Count" && cell.Value.ToString().Split(' ')[0] != "Grand")
                    {
                        excelWorkSheet[cell.RowIndex, cell.ColumnIndex - 2].Value = "Totals DLR# " + cell.Value.ToString().Split(' ')[0];
                        excelWorkSheet[cell.RowIndex, cell.ColumnIndex - 2].Font.FontStyle = SpreadsheetFontStyle.Bold;
                        excelWorkSheet[cell.RowIndex, cell.ColumnIndex - 1].Font.FontStyle = SpreadsheetFontStyle.Bold;
                        excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 1].Formula = excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex + 1].Formula;
                        excelWorkSheet[cell.RowIndex, cell.ColumnIndex + 1].Font.FontStyle = SpreadsheetFontStyle.Bold;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex + 1].Value = null;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex].Value = null;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex].Font.FontStyle = SpreadsheetFontStyle.Regular;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex - 2].Value = "Average Loan Amount / APR DLR# " + cell.Value.ToString().Split(' ')[0];
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex - 2].Font.FontStyle = SpreadsheetFontStyle.Bold;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex].Value = null;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex].Font.FontStyle = SpreadsheetFontStyle.Regular;
                        excelWorkSheet[cell.RowIndex + 2, cell.ColumnIndex].Value = null;
                        excelWorkSheet[cell.RowIndex + 2, cell.ColumnIndex].Font.FontStyle = SpreadsheetFontStyle.Regular;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex + 1].Formula = excelWorkSheet[cell.RowIndex + 2, cell.ColumnIndex + 1].Formula;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex + 1].Font.FontStyle = SpreadsheetFontStyle.Bold;
                        excelWorkSheet[cell.RowIndex + 2, cell.ColumnIndex + 1].Value = null;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex + 3].Formula = excelWorkSheet[cell.RowIndex + 2, cell.ColumnIndex + 3].Formula;
                        excelWorkSheet[cell.RowIndex + 1, cell.ColumnIndex + 3].Font.FontStyle = SpreadsheetFontStyle.Bold;
                        excelWorkSheet[cell.RowIndex + 2, cell.ColumnIndex + 3].Value = null;
                        cell.Value = null;
                        cell.Font.FontStyle = SpreadsheetFontStyle.Regular;
                    }
                }
                // Create the rule to shade alternate rows without applying a new style.
                FormulaExpressionConditionalFormatting cfRule = excelWorkSheet.ConditionalFormattings.AddFormulaExpressionConditionalFormatting(excelWorkSheet.Range["$A$2:$N$"+ (excelWorkSheet.GetUsedRange().RowCount-5).ToString()], "=MOD(ROW(),2)=1");
                CellRange cellRange = excelWorkSheet.Range["$A$2:$N$" + (excelWorkSheet.GetUsedRange().RowCount - 5).ToString()];
                cellRange.Borders.SetAllBorders(System.Drawing.Color.Blue, BorderLineStyle.Thin);

                // Specify formatting options to be applied to cells if the condition is true.
                // Set the background color to light blue.
                cfRule.Formatting.Fill.BackgroundColor = System.Drawing.Color.FromArgb(255, 0xBC, 0xDA, 0xF7);
                excelWorkSheet["A1:N1"].FillColor = System.Drawing.Color.Blue;
                workbook.SaveDocument(sourcePath, DocumentFormat.Xlsx);

                MessageBox.Show("*** CUSTOMER BANK extract file created successfully! ***");
            }
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            if (txtControlDateStart.EditValue == null)
                txtControlDateStart.EditValue = "";
            if (txtControlDateEnd.EditValue == null)
                txtControlDateEnd.EditValue = "";
            // Moses Newman 03/25/2020 Add Control Date
            if (txtControlDateStart.EditValue.ToString().Trim() != "" && txtControlDateStart.EditValue.ToString().Length == 4 && txtControlDateEnd.EditValue.ToString().Trim() != "" && txtControlDateEnd.EditValue.ToString().Length == 4)
            {
                DateTime ldCtrlDateStart, ldCtrlDateEnd;

                lnControlMonthStart = Convert.ToInt32(txtControlDateStart.EditValue.ToString().Substring(0, 2));
                lnControlYearStart   = Convert.ToInt32(txtControlDateStart.EditValue.ToString().Substring(2, 2));
                lnControlMonthEnd = Convert.ToInt32(txtControlDateEnd.EditValue.ToString().Substring(0, 2));
                lnControlYearEnd = Convert.ToInt32(txtControlDateEnd.EditValue.ToString().Substring(2, 2));

                ldCtrlDateStart = DateTime.Parse(lnControlMonthStart.ToString().PadLeft(2,'0')+"/01/"+DateTime.Now.Year.ToString().Substring(0, 2) + lnControlYearStart.ToString());
                ldCtrlDateEnd = DateTime.Parse(lnControlMonthEnd.ToString().PadLeft(2, '0') + "/01/" + DateTime.Now.Year.ToString().Substring(0, 2) + lnControlYearEnd.ToString());
                ldCtrlDateEnd = ldCtrlDateEnd.AddMonths(1).AddDays(-1);
                if (radioGroupMatch.SelectedIndex != 0)  // Moses Newman 07/01/2020
                {
                    ldStart = ldCtrlDateStart;
                    ldEnd = ldCtrlDateEnd;
                    nullableDateTimePickerStartDate.DateTime = ldStart;
                    nullableDateTimePickerEndDate.DateTime = ldEnd;
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
            ldStart = nullableDateTimePickerStartDate.DateTime.Date;
            ldEnd = nullableDateTimePickerEndDate.DateTime.Date;
            // Moses Newman 03/30/2016 add seperate paid interest date range selection.
            ldPIStart = nullableDateTimePickerPIStartDate.DateTime.Date;
            ldPIEnd = nullableDateTimePickerPIEndDate.DateTime.Date;
            if (radioButtonActive.Checked)
                lsStat = "A%";
            else
                if (radioButtonInactive.Checked)
                    lsStat = "I%";
            lsDealer = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + '%';
            // Moses Newman 03/26/2015 Added Repo and Dealer State Filters
            if (checkBoxRepos.Checked)
                lsRepo = "Y%";
            else
                lsRepo = "%";
            lsDealerState = (lookUpEditState.EditValue != null) ? lookUpEditState.EditValue.ToString().TrimStart().TrimEnd() + "%" : "%";
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
            //Close();
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
            // Moses Newman 07/18/2024
            FullFieldList.Sort((f1, f2) => f1.EXCELColumnName.CompareTo(f2.EXCELColumnName));
            SelectedFields.Sort((f1, f2) => f1.EXCELColumnName.CompareTo(f2.EXCELColumnName));
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

        private void radioGroupMatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroupMatch.SelectedIndex)
            {
                case 0:
                        ClearPreviousSelection();
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
                        SelectedFields.Clear();
                        foreach (Fld Selection in FullFieldList.ToList())
                        {
                            if (Selection.NBField)
                            {
                                SelectedFields.Add(Selection);
                                FullFieldList.Remove(Selection);
                            }
                        }
                        RefreshFieldListBoxes();
                        break;
                case 1:
                        ClearPreviousSelection();
                        break;
                case 2:
                        ClearPreviousSelection();
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
                        SelectedFields.Clear();
                        foreach (Fld Selection in FullFieldList.ToList())
                        {
                            if (Selection.ExtField)
                            {
                                SelectedFields.Add(Selection);
                                FullFieldList.Remove(Selection);
                            }
                        }
                        RefreshFieldListBoxes();
                        break;
            }
        }

        private void ClearPreviousSelection()
        {
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
            listBoxFieldList.DataSource = FullFieldList;
            listBoxSelectedFields.DataSource = SelectedFields;
            RefreshFieldListBoxes();
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButtonClearRadioButtons_Click(object sender, EventArgs e)
        {
            radioGroupMatch.SelectedIndex = -1;
            ClearPreviousSelection();
        }

        /*private void checkBoxExtensions_CheckStateChanged(object sender, EventArgs e)
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
        }*/

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
            
            if (radioGroupMatch.SelectedIndex != 2)
                CUSTOMERTableAdapter.FillBySelection(Bank.CUSTOMER,
                                            lsStat, ldStart, ldEnd, lsDealer, lsDealerState, lsRepo,
                                            radioGroupMatch.SelectedIndex == 1, checkBoxFundingDate.Checked,
                                            lnControlMonthStart, lnControlYearStart, lnControlMonthEnd, lnControlYearEnd);
            else
                CUSTOMERTableAdapter.FillByExtensions(Bank.CUSTOMER, lsStat, ldStart, ldEnd, lsDealer, lsDealerState, lsRepo,
                                                      radioGroupMatch.SelectedIndex == 1, checkBoxFundingDate.Checked,
                                                      lnControlMonthStart, lnControlYearStart, lnControlMonthEnd, lnControlYearEnd);

            // Moses Newman 06/26/2020 add New Extension functionality.
            if (radioGroupMatch.SelectedIndex != 2)
                OPNCUSTTableAdapter.FillBySelection(Bank.OPNCUST, lsStat, ldStart, ldEnd, lsDealer, lsDealerState, radioGroupMatch.SelectedIndex == 1,
                                                    lnControlMonthStart, lnControlYearStart, lnControlMonthEnd, lnControlYearEnd);
            else
                OPNCUSTTableAdapter.FillByExtensions(Bank.OPNCUST, lsStat, ldStart, ldEnd, lsDealer, lsDealerState,
                                                     radioGroupMatch.SelectedIndex == 1, checkBoxFundingDate.Checked,
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
                DEALERTableAdapter.Fill(Bank.DEALER, Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_DEALER"));
                // Moses Newman 01/29/2020 
                CUSTHISTTableAdapter.FillByGetNewRecord(Bank.CUSTHIST, Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));

                // Required Fields
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_NO", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_ADD_ON", Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ADD_ON"));
                Extensions.CustomerExtract.Rows[RowCount].SetField<String>("CUSTOMER_IAC_TYPE", "C");
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_DEALER", Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_DEALER"));
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
                // 01/28/2021 Moses Newman if match trial balance selected DO NOT AMORT!
                if (Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ACT_STAT") == "A")
                {
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_BALANCE", radioGroupMatch.SelectedIndex != 1 ? Program.TVSimpleGetBuyout(Bank,
                        nullableDateTimePickerBuyoutDate.DateTime,
                        (Double)Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM"),
                        (Double)(Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                        (Double)Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                        Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
                    // Moses Newman 04/30/2017 Handle S for simple interest, or N for Normal Daily Compounding
                    Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, false, false, false, -1, true) :
                    Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
                }
                else
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_BALANCE", Bank.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
               //Extensions.CustomerExtract.Rows[RowCount].SetField<Decimal>("CUSTOMER_BALANCE", GetBalance(Bank.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), nullableDateTimePickerBuyoutDate.DateTime));
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
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_CREDIT_SCORE_N", Bank.CUSTOMER.Rows[i].Field<Int32?>("CUSTOMER_CREDIT_SCORE_N") != null ? Bank.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_CREDIT_SCORE_N"):0);
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
                   // Moses Newman 11/18/2023 Make sure both Title Received and Electronic lien are not null before assingment.
                    // Moses Newman 10/26/2020 Title received Title Date Received
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean?>("TitleReceived", Bank.VEHICLE.Rows[0].Field<Boolean?>("TitleReceived"));
                    if (Bank.VEHICLE.Rows[0].Field<Nullable<DateTime>>("TitleDateReceived") != null) 
                        Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("TitleDateReceived", Bank.VEHICLE.Rows[0].Field<Nullable<DateTime>>("TitleDateReceived"));
                    else
                        Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("TitleDateReceived", Convert.ToDateTime("01/01/1980"));
                    // Moses Newman 10/27/2020 Add Electronic Lien
                    Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("ElectronicLien", Bank.VEHICLE.Rows[0].Field<Boolean?>("ElectronicLien") != null ? 
                        Bank.VEHICLE.Rows[0].Field<Boolean>("ElectronicLien"):false);
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
                    Extensions.CustomerExtract.Rows[RowCount].SetField<DateTime>("FundingDate", Bank.CUSTOMER.Rows[i].Field<DateTime>("FundingDate").Date);
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
                if (radioGroupMatch.SelectedIndex == 2)
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
                            // Moses Newman 08/01/2024 Don't blow up prebiously grabbed extension count
                            //Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_MONTHS_EXTENDED",
                                //Extensions.Extensions.Rows[hcount].Field<Int32?>("CUSTHIST_THRU_UD") != null ? Extensions.Extensions.Rows[hcount].Field<Int32>("CUSTHIST_THRU_UD") : 0);
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
                Extensions.CustomerExtract.Rows[RowCount].SetField<Int32>("CUSTOMER_DEALER", Convert.ToInt32(Bank.OPNCUST.Rows[i].Field<String>("CUSTOMER_DEALER")));
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
                // Moses Newman 01/09/2018 Init AnnualIncome, Tier, CosignerCreditScore, CosignerAnnualIncome,Mileage to 0 because not on Open loans
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
                if (radioGroupMatch.SelectedIndex == 2)
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
                            // Moses Newman 10/26/2020 Title received Title Date Received
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("TitleReceived", false);
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Nullable<DateTime>>("TitleDateReceived", Convert.ToDateTime("01/01/1980"));
                            // Moses Newman 10/27/2020 ElectronicLien
                            Extensions.CustomerExtract.Rows[RowCount].SetField<Boolean>("ElectronicLien", false);

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
            CustomerExtractTableAdapter.FillByAll(Extensions.CustomerExtract);
            CreateTextFile(Bank,Extensions);
            Bank.Dispose();
        }

        private void worker_FillExtractProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)MdiParent;
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.QueryprogressBar.EditValue = (e.ProgressPercentage < 101) ? e.ProgressPercentage : 100;
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using RestSharp;
using S9API.Models;
using RestSharp.Authenticators;


// Moses Newman 04/29/2020 Create Global Search PDF file uploader
namespace IAC2021SQL
{
    public partial class GlobalCapturePDFUploader : Form
    {

        private Boolean IsFound = false;

        private IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
        private IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();

        private IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
        private IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();

        private IACDataSet gsData = new IACDataSet();

        private String lsCustomerNo = "";

        private MatchCollection matches;

        public GlobalCapturePDFUploader()
        {
            InitializeComponent();
        }

        private void buttonSelectPDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            String lsFilter = "";
            // Moses Newman 05/06/2020 Add ALL GlobalSearch supported document types to filters
            dialog.InitialDirectory = @"\\DC-IAC\Public\GlobalSearchPDFUploads";
            lsFilter = "PDF files | *.pdf|Text files (*.txt;.rtf;.csv)|*.txt;*.rtf;*csv|";
            lsFilter += "Image Files(*.BMP;*.JPG;*.GIF;*.PCX;*.PNG;*.PSD;*.TGA;*.TIF;*.WBMP;*.WMF)|*.BMP;*.JPG;*.GIF;*.PCX;*.PNG;*.PSD;*.TGA;*.TIF;*.WBMP;*.WMF|";
            lsFilter += "Office Documents (*.DOC;*.DOCX) | *.DOC;*.DOCX|";
            lsFilter += "Spreadsheet (*.xls;*.xlsx)|*.xls;*.xlsx|";
            lsFilter += "Email (*.eml;*.msg)|*.eml;*.msg|";
            lsFilter += "Presentation (*.ppt;*.pptx)|*.ppt;*.pptx|";
            lsFilter += "CAD (*.dwg;*.dxf)|*.dwg;*.dxf"; // file types, that will be allowed to upload
            dialog.Filter = lsFilter;
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                textBoxFileName.Text = path;
                textBoxFileName.Refresh();

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader r = new StreamReader(fs);
                string pdfText = r.ReadToEnd();

                Regex rx1 = new Regex(@"/Type\s*/Page[^s]");
                matches = rx1.Matches(pdfText);
                textBoxPageCount.Text = matches.Count.ToString().Trim();
                textBoxPageCount.Refresh();

                textBoxFileType.Text = path.Substring(path.Length - 4,4);  // Get extension
                textBoxFileType.Refresh();

                buttonImportToGlobalSearch.Enabled = true;
            }
            else
                buttonImportToGlobalSearch.Enabled = false;
        }

        private void TextBoxCutomerNo_Validated(object sender, EventArgs e)
        {
            if (TextBoxCutomerNo.Text.ToString().Trim().Length < 6 && TextBoxCutomerNo.Text.ToString().Trim().Length > 0)
                TextBoxCutomerNo.Text = TextBoxCutomerNo.Text.Trim().PadLeft(6, '0');
            lsCustomerNo = TextBoxCutomerNo.Text.ToString().Trim();
            if (lsCustomerNo == "")  // Moses Newman 03/02/2012 previously only returned if in Add Mode!!!
                return;
            CUSTOMERTableAdapter.Fill(gsData.CUSTOMER, lsCustomerNo);
            if (gsData.CUSTOMER.Rows.Count > 0)
            {
                TextBoxFirstName.Text = gsData.CUSTOMER.Rows[0].Field<String>("CUSTOMER_FIRST_NAME");
                TextBoxFirstName.Refresh();

                TextBoxLastName.Text = gsData.CUSTOMER.Rows[0].Field<String>("CUSTOMER_LAST_NAME");
                TextBoxLastName.Refresh();

                textBoxSSNLast4.Text = gsData.CUSTOMER.Rows[0].Field<String>("CUSTOMER_SS_3");
                textBoxSSNLast4.Refresh();

                comboBoxSide.Text = "CLOSED";
                comboBoxSide.Refresh();

                nullableDateTimePickerArchivedDate.Value = DateTime.Now;
                nullableDateTimePickerArchivedDate.Refresh();

                textBoxDealerNo.Text = gsData.CUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER");
                textBoxDealerNo.Refresh();

                DEALERTableAdapter.Fill(gsData.DEALER, gsData.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
                if (gsData.DEALER.Rows.Count > 0)
                {
                    textBoxDealerName.Text = gsData.DEALER.Rows[0].Field<String>("DEALER_NAME");
                    textBoxDealerName.Refresh();
                }
                IsFound = true;
            }
            else
            {
                OPNCUSTTableAdapter.Fill(gsData.OPNCUST, lsCustomerNo);
                if (gsData.OPNCUST.Rows.Count > 0)
                {
                    TextBoxFirstName.Text = gsData.OPNCUST.Rows[0].Field<String>("CUSTOMER_FIRST_NAME");
                    TextBoxFirstName.Refresh();

                    TextBoxLastName.Text = gsData.OPNCUST.Rows[0].Field<String>("CUSTOMER_LAST_NAME");
                    TextBoxLastName.Refresh();

                    textBoxSSNLast4.Text = gsData.OPNCUST.Rows[0].Field<String>("CUSTOMER_SS_3");
                    textBoxSSNLast4.Refresh();

                    comboBoxSide.Text = "OPEN";
                    comboBoxSide.Refresh();

                    nullableDateTimePickerArchivedDate.Value = DateTime.Now;
                    nullableDateTimePickerArchivedDate.Refresh();

                    textBoxDealerNo.Text = gsData.OPNCUST.Rows[0].Field<String>("CUSTOMER_DEALER");
                    textBoxDealerNo.Refresh();

                    OPNDEALRTableAdapter.Fill(gsData.OPNDEALR, gsData.OPNCUST.Rows[0].Field<String>("CUSTOMER_DEALER"));
                    if (gsData.OPNDEALR.Rows.Count > 0)
                    {
                        textBoxDealerName.Text = gsData.OPNDEALR.Rows[0].Field<String>("OPNDEALR_NAME");
                        textBoxDealerName.Refresh();
                    }
                    IsFound = true;
                }
            }
        }

        private void TextBoxCutomerNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            // Moses Newman 05/05/2020 Numeric digits ONLY in CUSTOMER_NO!
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonImportToGlobalSearch_Click(object sender, EventArgs e)
        {
            DialogResult MessageResult= new DialogResult();
           
            String MissingFields = "";
            if (!IsFound && TextBoxCutomerNo.Text == "")
                MessageBox.Show("You Must Select an Account for Indexing!");
            else
            {
                if (TextBoxFirstName.Text == "")
                    MissingFields += "First Name";
                if (TextBoxLastName.Text == "")
                {
                    if (MissingFields != "")
                        MissingFields += ", ";
                    MissingFields += "Last Name";
                }
                if (textBoxDealerNo.Text == "")
                { 
                    if (MissingFields != "")
                        MissingFields += ", ";
                    MissingFields += "Dealer Number";
                }
                if (textBoxSSNLast4.Text == "")
                {
                    if (MissingFields != "")
                        MissingFields += ", ";
                    MissingFields += "SSN Last 4";
                }

                if (comboBoxSide.Text == "")
                {
                    if (MissingFields != "")
                        MissingFields += ", ";
                    MissingFields += "Side";
                }

                if (MissingFields != "")
                    MessageResult = MessageBox.Show("You are missing the following index field(s): " + MissingFields + " would you like to import the pdf anyway?", "Global Search Import Warning", MessageBoxButtons.YesNoCancel);
                if (MessageResult == DialogResult.Yes || MissingFields == "")
                {
                    //basic authentication
                    Program.ApiClient.Authenticator = new HttpBasicAuthenticator(@"IAC\Administrator", "IACadmin99");

                    var databaseID = 2;  //Database ID
                    var archiveID = 9;  //Archive ID

                    var localFileName = textBoxFileName.Text; //file to be uploaded

                    var token = "";
                    try
                    {
                        //upload file
                        string uploadedFileName = Program.PostFile(localFileName); //api returns the name of the file on the server for indexing

                        //token = Program.GetLicense(); //valid SS license
                                                      // Set index field data
                        List<FieldItem> fieldData = new List<FieldItem>()
                            { new FieldItem(1, TextBoxCutomerNo.Text)
                            , new FieldItem(2, TextBoxFirstName.Text)
                            , new FieldItem(9, TextBoxLastName.Text)
                            , new FieldItem(5, textBoxDealerNo.Text)
                            , new FieldItem(4, textBoxSSNLast4.Text)
                            , new FieldItem(12,comboBoxSide.Text) };


                        //index file
                        Program.IndexDocument(databaseID, archiveID, fieldData, uploadedFileName, token);

                        MessageBox.Show(localFileName + " Uploaded Successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to upload file:\n " + ex.Message);
                    }
                    finally
                    {
                        if (!String.IsNullOrEmpty(token))
                        {
                            Program.ReleaseLicense(token);
                        }
                    }
                }
            }
        }

        private void GlobalCapturePDFUploader_Load(object sender, EventArgs e)
        {
            comboBoxSide.SelectedIndex = 0;
            comboBoxSide.Refresh();
        }
    }
}

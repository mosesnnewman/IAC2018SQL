using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using RestSharp;
using S9API.Models;
using Acrobat;
using RestSharp.Extensions;
using System.Threading;

namespace IAC2018SQL
{
    public partial class frmImportDefiPDFs : System.Windows.Forms.Form
    {
        //Acrobat application as a private member variable of the class
        private CAcroApp mApp;

        public frmImportDefiPDFs()
        {
            InitializeComponent();
        }


        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            ImportPDFs();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ImportPDFs()
        {
            //IAC objects
            CAcroPDDoc pdDocIn;
            CAcroPDDoc pdDocOut;

            byte[] bytes;

            String Filename, FullPath = @"\\SQL-IAC\e\PDFTemp\", ProcessedPath = @"\\SQL-IAC\e\PDFTemp\Processed\";
            IACDataSet ImportData = new IACDataSet();
            PaymentDataSet PDFData = new PaymentDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            PaymentDataSetTableAdapters.DEFIPDFImagesTableAdapter DEFIPDFImagesTableAdapter = new PaymentDataSetTableAdapters.DEFIPDFImagesTableAdapter();

            //Int32 progress = 0;
            CustomerTableAdapter.ImportDEFIPDFs();
            CustomerTableAdapter.FillByDefiImages(ImportData.CUSTOMER);
            if (ImportData.CUSTOMER.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO CUSTOMERS IN DEFI PDF IMAGE FILE! ***");
            }
            else
            {

                for (int i = 0; i < ImportData.CUSTOMER.Rows.Count; i++)
                {
                    //Initialize Acrobat by creating App object
                    mApp = new AcroAppClass();
                    //Show Acrobat
                    //mApp.Show();

                    //set PDDoc objectS
                    pdDocIn = new AcroPDDocClass();
                    pdDocOut = new AcroPDDocClass();

                    List<String> files = new List<String>();
                    labelProgress.Text = "Working on Account Number: " + ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + " " + (i + 1).ToString() +
                                         " of " + ImportData.CUSTOMER.Rows.Count.ToString();
                    labelProgress.Refresh();
                    TextBoxCutomerNo.Text = ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO");
                    TextBoxCutomerNo.Refresh();

                    TextBoxFirstName.Text = ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_FIRST_NAME");
                    TextBoxFirstName.Refresh();

                    TextBoxLastName.Text = ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_LAST_NAME");
                    TextBoxLastName.Refresh();

                    textBoxDealerNo.Text = ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_DEALER");
                    textBoxDealerNo.Refresh();

                    textBoxSSNLast4.Text = ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_SS_3");
                    textBoxSSNLast4.Refresh();

                    textBoxSide.Text = "CLOSED";
                    textBoxSide.Refresh();

                    progressBarStatus.Value = ((i + 1) / ImportData.CUSTOMER.Rows.Count) * 100;

                    DEFIPDFImagesTableAdapter.FillByCustomerNo(PDFData.DEFIPDFImages, ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));

                    for (int imgCount = 0; imgCount < PDFData.DEFIPDFImages.Rows.Count; imgCount++)
                    {
                        // Moses Newman 06/12/2020 Skip if failed pdf conversion at DEFI
                        if (PDFData.DEFIPDFImages.Rows[imgCount].Field<String>("conversionStatus") == "Failure")
                            continue;
                        bytes = Convert.FromBase64String(PDFData.DEFIPDFImages.Rows[imgCount].Field<String>("binaryContent"));
                        // Moses Newman 06/12/2020 Rename image file to ApplicationNumber+imageID to handle idiot file naming stupidity.
                        //Filename = PDFData.DEFIPDFImages.Rows[imgCount].Field<String>("fileName");
                        Filename = PDFData.DEFIPDFImages.Rows[imgCount].Field<Int32>("ApplicationNumber").ToString() + '-' + PDFData.DEFIPDFImages.Rows[imgCount].Field<Int32>("imageID").ToString() + ".pdf";
                        labelProgress.Text = "Creating File: " + Filename + " for Account: " + ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + (imgCount + 1).ToString() +
                                         " of " + PDFData.DEFIPDFImages.Rows.Count.ToString();
                        labelProgress.Refresh();
                        System.IO.File.WriteAllBytes(FullPath + Filename, bytes);

                        files.Add(FullPath + Filename);
                    }

                    string filename = FullPath + ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + "-combined.pdf"; ;
                    pdDocOut.Create();
                    foreach (String file in files)
                    {

                        if (pdDocIn.Open(file))
                        {
                            int NumPagesOut = pdDocOut.GetNumPages(),
                                NumPagesIn = pdDocIn.GetNumPages();

                            labelProgress.Text = "Adding Pages for Account: " + ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") +
                                                 " " + NumPagesIn.ToString() + " pages to concatinated PDF.";
                            labelProgress.Refresh();
                            // ...and add it to the output document.
                            pdDocOut.InsertPages(NumPagesOut - 1, pdDocIn, 0, NumPagesIn, 1);

                            pdDocIn.Close();
                        }
                    }
                    // Save the document...
                    pdDocOut.Save((short)PDSaveFlags.PDSaveFull,filename);
                    pdDocOut.Close();

                    if (mApp != null)
                    {
                        mApp.CloseAllDocs();
                        mApp.Exit();
                    }

                    for (int imgCount = 0; imgCount < PDFData.DEFIPDFImages.Rows.Count; imgCount++)
                    {
                        // Moses Newman 06/12/2020 Skip if failed pdf conversion at DEFI
                        if (PDFData.DEFIPDFImages.Rows[imgCount].Field<String>("conversionStatus") == "Failure")
                            continue;
                        labelProgress.Text = "Moving pdf " + PDFData.DEFIPDFImages.Rows[imgCount].Field<String>("fileName") + " for Account: " + ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + " to " + ProcessedPath;
                        labelProgress.Refresh();
                        //Filename = PDFData.DEFIPDFImages.Rows[imgCount].Field<String>("fileName");
                        Filename = PDFData.DEFIPDFImages.Rows[imgCount].Field<Int32>("ApplicationNumber").ToString() + '-' + PDFData.DEFIPDFImages.Rows[imgCount].Field<Int32>("imageID").ToString() + ".pdf";
                        if (!System.IO.File.Exists(ProcessedPath + Filename))
                            System.IO.File.Move(FullPath + Filename, ProcessedPath + Filename);
                    }
                    //basic authentication
                    Program.ApiClient.Authenticator = new HttpBasicAuthenticator(@"IAC\Administrator", "IACadmin99");

                    var databaseID = 2;  //Database ID
                    var archiveID = 9;  //Archive ID

                    var localFileName = filename; //file to be uploaded

                    var token = "";
                    try
                    {
                        //upload file
                        string uploadedFileName = Program.PostFile(localFileName); //api returns the name of the file on the server for indexing

                        token = Program.GetLicense(); //valid SS license
                                                      // Set index field data
                        List<FieldItem> fieldData = new List<FieldItem>()
                            { new FieldItem(1, ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"))
                            , new FieldItem(2, ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_FIRST_NAME"))
                            , new FieldItem(9, ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_LAST_NAME"))
                            , new FieldItem(5, ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_DEALER"))
                            , new FieldItem(4, ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_SS_3"))
                            , new FieldItem(12,"CLOSED") };

                        //index file
                        labelProgress.Text = "Indexing consolidate image file: " + uploadedFileName + " for Account: " + ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO");
                        labelProgress.Refresh();
                        Program.IndexDocument(databaseID, archiveID, fieldData, uploadedFileName, token);
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
                        System.IO.File.Delete(localFileName);
                        labelProgress.Text = "Completed upload and indexing for Account: " + ImportData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO");
                        labelProgress.Refresh();
                    }
                }
            }
            labelProgress.Text = "DONE!";
            labelProgress.Refresh();
            progressBarStatus.Value = 100;
            progressBarStatus.Refresh();
        }

        private void frmImportDefiPDFs_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mApp != null)
            {
                mApp.CloseAllDocs();
                mApp.Exit();
            }
        }
    }
}

  

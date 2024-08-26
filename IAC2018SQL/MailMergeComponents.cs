using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Net;
using System.Windows.Forms;
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Outlook = Microsoft.Office.Interop.Outlook;
using Word = Microsoft.Office.Interop.Word;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Threading;
using TelAPI;

namespace IAC2021SQL
{
    class MailMergeComponents
    {
        private struct WholeComment
        {
            public String Field1,
                          Field2,
                          Field3;
        }

        private Object oMissing = System.Reflection.Missing.Value,
                       oTrue = false,
                       oFalse = true;

        // Moses Newman 01/02/2013 Add option to send as an outlook attachment
        public void CreateMailMerge(IACDataSet PassedDataSet, Boolean lbLetter = false, String lsLetterName = "", String lsBalanceType = "S", Boolean tbSendAsEmail = false, String tsmailToText = "", String tsSaveAs = "", Boolean tbEnvelope = false)
        {
            IACDataSet MergeDataSet;
            MergeDataSet = (IACDataSet)PassedDataSet.Copy();

            // Moses Newman 02/14/2018 Handle New Business Envelopes now too.
            String lsDocType = lbLetter ? "Letter" : tbEnvelope ? "Envelope" : "NewBusiness";
            Object oFalse = false;
            BindingSource BookLetter = new BindingSource();
            IACDataSetTableAdapters.CustBankTableAdapter CustBankTableAdapter = new IACDataSetTableAdapters.CustBankTableAdapter();
            IACDataSetTableAdapters.CustTempTableAdapter CustTempTableAdapter = new IACDataSetTableAdapters.CustTempTableAdapter();
            IACDataSetTableAdapters.VEHICLETableAdapter VEHICLETableAdapter = new IACDataSetTableAdapters.VEHICLETableAdapter();
            BookLetter.DataSource = MergeDataSet.CUSTOMER;

            DataTable CustTemp = MergeDataSet.CustTemp;
            CustTempTableAdapter.DeleteAll();
            CustBankTableAdapter.DeleteAll();

            MergeDataSet.CUSTOMER.CUSTOMER_NOColumn.MaxLength = 9; // Temporary add 3 Characters in length to store UserID
            // Moses Newman 07/14/2016 Need to add DEALER_NAME so custtemp update does not fail!
            if (!MergeDataSet.CUSTOMER.Columns.Contains("DEALER_NAME"))
            {
                MergeDataSet.CUSTOMER.Columns.Add("DEALER_NAME", typeof(String));
                foreach (DataRow row in MergeDataSet.CUSTOMER.Rows)
                {
                    row["DEALER_NAME"] = "";
                }
            }
            // End of add new column 07/14/2016
            // Moses Newman 09/09/2019 Add Year, Make, Model, Vin
            if (!MergeDataSet.CUSTOMER.Columns.Contains("Year"))
            {
                MergeDataSet.CUSTOMER.Columns.Add("Year", typeof(Int32));
                foreach (DataRow row in MergeDataSet.CUSTOMER.Rows)
                {
                    row["Year"] = 0;
                }
            }
            if (!MergeDataSet.CUSTOMER.Columns.Contains("Make"))
            {
                MergeDataSet.CUSTOMER.Columns.Add("Make", typeof(String));
                foreach (DataRow row in MergeDataSet.CUSTOMER.Rows)
                {
                    row["Make"] = "";
                }
            }
            if (!MergeDataSet.CUSTOMER.Columns.Contains("Model"))
            {
                MergeDataSet.CUSTOMER.Columns.Add("Model", typeof(String));
                foreach (DataRow row in MergeDataSet.CUSTOMER.Rows)
                {
                    row["Model"] = "";
                }
            }
            if (!MergeDataSet.CUSTOMER.Columns.Contains("Vin"))
            {
                MergeDataSet.CUSTOMER.Columns.Add("Vin", typeof(String));
                foreach (DataRow row in MergeDataSet.CUSTOMER.Rows)
                {
                    row["Vin"] = "";
                }
            }
            // End of add new vehicle columns 09/09/2019
            VEHICLETableAdapter.FillByCustomerNo(MergeDataSet.VEHICLE, MergeDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
            for (Int32 i = 0; i < MergeDataSet.CUSTOMER.Rows.Count; i++)
            {
                // Moses Newman 07/26/2017 add CustBank records in case letter needs that table. (ie. Autoletter#9)
                try
                {
                    CustBankTableAdapter.CustBankLoadAll(MergeDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + Program.gsUserID, 0, Program.NextDueDate(i, MergeDataSet), false, false, "Y");
                }
                catch(Exception e)
                {
                    MessageBox.Show("The Error Message Is:" + e.Message);
                }
                MergeDataSet.CUSTOMER.Rows[i].SetField<String>("CUSTOMER_NO", MergeDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + Program.gsUserID);
                if (MergeDataSet.CUSTOMER.Rows[i].Field<Nullable<Decimal>>("CUSTOMER_CONTRACT_STATUS") == null)
                    MergeDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", 0);
                if (MergeDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PHONE_NO").TrimEnd() == "")
                    MergeDataSet.CUSTOMER.Rows[i].SetField<String>("CUSTOMER_PHONE_NO", "0000000000");
                if (lsBalanceType != "B")
                    MergeDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", MergeDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1);
                else
                    MergeDataSet.CUSTOMER.Rows[i].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", MergeDataSet.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
                // Moses Newman 09/09/2019 Add in Year, Make, Model, Vin
                if (MergeDataSet.VEHICLE.Rows.Count > 0)
                {
                    if (MergeDataSet.VEHICLE.Rows[0].Field<Int32?>("VEHICLE_YEAR") != null)
                        MergeDataSet.CUSTOMER.Rows[i].SetField<Int32>("Year", MergeDataSet.VEHICLE.Rows[0].Field<Int32>("VEHICLE_YEAR"));
                    if (MergeDataSet.VEHICLE.Rows[0].Field<String>("VEHICLE_MAKE") != null)
                        MergeDataSet.CUSTOMER.Rows[i].SetField<String>("Make", MergeDataSet.VEHICLE.Rows[0].Field<String>("VEHICLE_MAKE"));
                    if (MergeDataSet.VEHICLE.Rows[0].Field<String>("VEHICLE_MODEL") != null)
                        MergeDataSet.CUSTOMER.Rows[i].SetField<String>("Model", MergeDataSet.VEHICLE.Rows[0].Field<String>("VEHICLE_MODEL"));
                    if (MergeDataSet.VEHICLE.Rows[0].Field<String>("VEHICLE_VIN") != null)
                        MergeDataSet.CUSTOMER.Rows[i].SetField<String>("Vin", MergeDataSet.VEHICLE.Rows[0].Field<String>("VEHICLE_VIN"));
                }
                MergeDataSet.CUSTOMER.Rows[i].AcceptChanges();  // Commit changes to DataTable so that we can force SetAdded
                MergeDataSet.CUSTOMER.Rows[i].SetAdded();       // Makes Update use Insert Query as there is NO update query
                CustTempTableAdapter.Update(MergeDataSet.CUSTOMER.Rows[i]);
            }
            CustTempTableAdapter.Fill(MergeDataSet.CustTemp, MergeDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO") + Program.gsUserID);
            //CustBankTableAdapter.Fill(MergeDataSet.CustBank, MergeDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO") + Program.gsUserID);
            Word._Application oWord = new Word.Application();
            Word._Document oWordDoc = new Word.Document();
            Object oTemplatePath = "";

            // Moses Newman 02/14/2014 add Envelopes to New Business
            switch (lsDocType)
            {
                case "NewBusiness":
                    oTemplatePath = Program.GsDataPath + @"\MailMerge\CouponBookLetter.docx";
                    break;
                case "Letter":
                    oTemplatePath = Program.GsDataPath + @"\MailMerge\" + lsLetterName + ".docx";
                    break;
                case "Envelope":
                    oTemplatePath = Program.GsDataPath + @"\MailMerge\EnvelopeTemplate.docx";
                    break;

            }

            oWord.Visible = true;
            oWord.Activate();
            oWord.WindowState = Word.WdWindowState.wdWindowStateMaximize;
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oTrue);
            Word.MailMerge wrdMailMerge;

            String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsDataPath = Program.GsDataPath + @"\MailMerge\DataSources\",
                   lsCatalog = "", lsServerName = "";

            lsServerName = lsConnect.Substring(lsConnect.IndexOf("DATA SOURCE=") + 12, lsConnect.IndexOf(";") - (lsConnect.IndexOf("DATA SOURCE=") + 12));
            lsServerName = lsServerName.Replace('\\', '_');
            lsDataPath += lsServerName;
            lsCatalog = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16, lsConnect.IndexOf(";INTEGRATED") - (lsConnect.IndexOf("INITIAL CATALOG=") + 16));
            if (lsLetterName.Length >= 12)
                if (lsLetterName.Contains("COS#"))
                {
                    // Moses Newman 03/12/2020 #9 uses CusteTemp Now
                    // Moses Newman 09/09/2019 change COS letter 10 to use CustTemp INSTEAD of CustBank
                    if (Int32.Parse(lsLetterName.Substring(14)) > 8 && !lsLetterName.Contains("COS#10") && !lsLetterName.Contains("COS#9"))
                        lsCatalog += " custbank.odc";
                    else
                        lsCatalog += " CustTemp.odc";
                }
                else
                    // Moses Newman 03/12/2020 #9 uses CusteTemp Now
                    // Moses Newman 09/09/2019 change letter 10 to use CustTemp INSTEAD of CustBank
                    if (Int32.Parse(lsLetterName.Substring(11)) > 8 && !lsLetterName.Contains("#10") && !lsLetterName.Contains("#9"))
                    lsCatalog += " custbank.odc";
                else
                    lsCatalog += " CustTemp.odc";
            else
                lsCatalog += " CustTemp.odc";
            lsDataPath += " " + lsCatalog;

            wrdMailMerge = oWordDoc.MailMerge;
            wrdMailMerge.OpenDataSource(lsDataPath, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
            wrdMailMerge.Execute(ref oFalse);

            if (tbSendAsEmail)
            {
                Object mailitem;
                String CurrentUserEmail = UserPrincipal.Current.EmailAddress;
                Word.Selection wordSelection;

                Outlook.Application outlookApp = new Outlook.Application();

                wordSelection = oWord.Selection;
                wordSelection.SetRange(0, oWordDoc.Characters.Count);
                mailitem = oWordDoc.MailEnvelope.Item;
                mailitem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.MailItem mailItem = (Outlook.MailItem)mailitem;
                mailItem.Subject = "*** ATTENTION: MESSAGE FROM INDUSTRIAL ACCEPTANCE CORPORATION. ***";
                mailItem.SentOnBehalfOfName = CurrentUserEmail;
                mailItem.To = tsmailToText;
                mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
                mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatRichText;
                mailItem.Body = wordSelection.Text;
                mailItem.Display();
            }
            // Moses Newman 10/18/2017 added a tsSaveAs filename parameter so file will be saved if it is included.
            if (tsSaveAs != "")
            {
                Object FileName = tsSaveAs;
                // Save merged document NOT template!!!

                oWord.Application.ActiveDocument.SaveAs2(FileName,
                                                         Word.WdSaveFormat.wdFormatDocumentDefault,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oFalse,            // DO NOT ADD TO MOST RECENT FILES!
                                                         ref oMissing,
                                                         ref oMissing,
                                                         oTrue,
                                                         ref oMissing,
                                                         oTrue,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing);
            }
            oWordDoc.Saved = true;
            oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
            oWordDoc = null;
            oWord = null;
            wrdMailMerge = null;
            CustTempTableAdapter.DeleteAll();
            CustTempTableAdapter.Dispose();
            MergeDataSet.Dispose();
            BookLetter.Dispose();
        }

        public void OpenCreateMailMerge(IACDataSet PassedDataSet, String lsLetterName = "", String lsBalanceType = "S")
        {
            IACDataSet MergeDataSet;
            MergeDataSet = (IACDataSet)PassedDataSet.Copy();

            Object oFalse = false;
            BindingSource BookLetter = new BindingSource();
            IACDataSetTableAdapters.OpenCustTempTableAdapter CustTempTableAdapter = new IACDataSetTableAdapters.OpenCustTempTableAdapter();
            BookLetter.DataSource = MergeDataSet.OPNCUST;

            DataTable CustTemp = MergeDataSet.OpenCustTemp;
            CustTempTableAdapter.DeleteAll();
            MergeDataSet.OPNCUST.CUSTOMER_NOColumn.MaxLength = 9; // Temporary add 3 Characters in length to store UserID
            for (Int32 i = 0; i < MergeDataSet.OPNCUST.Rows.Count; i++)
            {
                MergeDataSet.OPNCUST.Rows[i].SetField<String>("CUSTOMER_NO", MergeDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO") + Program.gsUserID);
                if (MergeDataSet.OPNCUST.Rows[i].Field<String>("CUSTOMER_PHONE_NO").TrimEnd() == "")
                    MergeDataSet.OPNCUST.Rows[i].SetField<String>("CUSTOMER_PHONE_NO", "0000000000");
                if (lsBalanceType != "B")
                    MergeDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", MergeDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1);
                else
                    MergeDataSet.OPNCUST.Rows[i].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", MergeDataSet.OPNCUST.Rows[i].Field<Decimal>("CUSTOMER_BALANCE"));
                MergeDataSet.OPNCUST.Rows[i].AcceptChanges();  // Commit changes to DataTable so that we can force SetAdded
                MergeDataSet.OPNCUST.Rows[i].SetAdded();       // Makes Update use Insert Query as there is NO update query
                CustTempTableAdapter.Update(MergeDataSet.OPNCUST.Rows[i]);
            }
            CustTempTableAdapter.Fill(MergeDataSet.OpenCustTemp, MergeDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_NO") + Program.gsUserID);
            Word._Application oWord = new Word.Application();
            Word._Document oWordDoc = new Word.Document();
            Object oTemplatePath = "";

            oTemplatePath = Program.GsDataPath + @"\MailMerge\" + lsLetterName + ".docx";

            oWord.Visible = true;

            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oTrue);
            Word.MailMerge wrdMailMerge;

            String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsDataPath = Program.GsDataPath + @"MailMerge\DataSources\",
                   lsCatalog = "", lsServerName = "";

            lsServerName = lsConnect.Substring(lsConnect.IndexOf("DATA SOURCE=") + 12, lsConnect.IndexOf(";") - (lsConnect.IndexOf("DATA SOURCE=") + 12));
            lsServerName = lsServerName.Replace('\\', '_');
            lsDataPath += lsServerName;
            lsCatalog = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16, lsConnect.IndexOf(";INTEGRATED") - (lsConnect.IndexOf("INITIAL CATALOG=") + 16));
            lsCatalog += " OpenCustTemp.odc";
            lsDataPath += " " + lsCatalog;

            wrdMailMerge = oWordDoc.MailMerge;
            wrdMailMerge.OpenDataSource(lsDataPath, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
            wrdMailMerge.Execute(ref oFalse);
            oWordDoc.Saved = true;
            oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
            oWordDoc = null;
            oWord = null;
            wrdMailMerge = null;
            CustTempTableAdapter.DeleteAll();
            CustTempTableAdapter.Dispose();
            MergeDataSet.Dispose();
            BookLetter.Dispose();
        }

        public void CreateNotices(Int32 tnLetterNo, Boolean tbMakeComments, ref BackgroundWorker worker, ref String tsProgMessage)
        {
            String lsCommentText = "";
            IACDataSet MergeDataSet = new IACDataSet();

            Object oFalse = false;

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.ClosedNoticeTempTableAdapter ClosedNoticeTempTableAdapter = new IACDataSetTableAdapters.ClosedNoticeTempTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.NOTICETableAdapter NOTICETableAdapter = new IACDataSetTableAdapters.NOTICETableAdapter();
            BindingSource DEALERBindingSource = new BindingSource();
            DEALERBindingSource.DataSource = MergeDataSet.DEALER;

            DataTable NoticeTemp = MergeDataSet.ClosedNoticeTemp;
            ClosedNoticeTempTableAdapter.DeleteAll();
            Word._Application oWord = new Word.Application();
            Word._Document oWordDoc = new Word.Document();
            Object oTemplatePath = "";

            DEALERTableAdapter.FillByNotice(MergeDataSet.DEALER);
            NOTICETableAdapter.FillAll(MergeDataSet.NOTICE);
            ClosedNoticeTempTableAdapter.DeleteAll();
            // Moses Newman 05/22/2018 make generic to use ALL FORM NUMBERS AND 7 INSTANCES OF WORD!!!
            oTemplatePath = Program.GsDataPath + @"\MailMerge\CLOSEDNOTICE0" + tnLetterNo.ToString().Trim() + ".docx";
            MergeDataSet.NOTICE.Columns.Add("DEALER_NAME", System.Type.GetType("System.String"));
            // Moses Newman 11/25/2018 add CosignerNotice flag to signify if this is a notice to to coborrower address.
            MergeDataSet.NOTICE.Columns.Add("CosignerNotice", System.Type.GetType("System.Boolean"));
            for (Int32 i = 0; i < MergeDataSet.NOTICE.Rows.Count; i++)
            {
                if (MergeDataSet.NOTICE.Rows[i].Field<Int32>("NOTICE_FORM_NO") == tnLetterNo && MergeDataSet.NOTICE.Rows[i].Field<String>("NOTICE_WRONG_ADDRESS") != "Y")
                {
                    DEALERBindingSource.Position = DEALERBindingSource.Find("id", MergeDataSet.NOTICE.Rows[i].Field<Int32>("NOTICE_DEALER"));
                    MergeDataSet.NOTICE.Rows[i].SetField<String>("DEALER_NAME", MergeDataSet.DEALER.Rows[DEALERBindingSource.Position].Field<String>("DEALER_NAME"));
                    MergeDataSet.NOTICE.Rows[i].SetField<Decimal>("NOTICE_CONTRACT_STATUS", MergeDataSet.NOTICE.Rows[i].Field<Decimal>("NOTICE_CONTRACT_STATUS") * -1);
                    // Moses Newman 11/25/2018 add CosignerNotice flag to signify if this is a notice to to coborrower address.
                    MergeDataSet.NOTICE.Rows[i].SetField<Boolean>("CosignerNotice", false);
                    MergeDataSet.NOTICE.Rows[i].AcceptChanges();                        // Clear modified status
                    MergeDataSet.NOTICE.Rows[i].SetAdded();                             // Force Added Status so Update method INSERTs it
                    ClosedNoticeTempTableAdapter.Update(MergeDataSet.NOTICE.Rows[i]);

                    // Moses Newman 11/25/2018 add extra record for cosigner address if the cosigner address is different than the primary address.
                    CUSTOMERTableAdapter.CosignerDifferentAddress(MergeDataSet.CUSTOMER, MergeDataSet.NOTICE.Rows[i].Field<String>("NOTICE_NO"));
                    if (MergeDataSet.CUSTOMER.Count > 0)
                    {
                        MergeDataSet.NOTICE.Rows[i].SetField<String>("NOTICE_NAME",
                            MergeDataSet.CUSTOMER.Rows[0].Field<String>("COSIGNER_FIRST_NAME").TrimEnd() +
                            ' ' + MergeDataSet.CUSTOMER.Rows[0].Field<String>("COSIGNER_LAST_NAME").TrimEnd());
                        MergeDataSet.NOTICE.Rows[i].SetField<String>("NOTICE_STREET_1", MergeDataSet.CUSTOMER.Rows[0].Field<String>("COSIGNER_ADDRESS1").TrimEnd());
                        MergeDataSet.NOTICE.Rows[i].SetField<String>("NOTICE_CITY", MergeDataSet.CUSTOMER.Rows[0].Field<String>("COSIGNER_CITY").TrimEnd());
                        MergeDataSet.NOTICE.Rows[i].SetField<String>("NOTICE_STATE", MergeDataSet.CUSTOMER.Rows[0].Field<String>("COSIGNER_STATE").TrimEnd());
                        MergeDataSet.NOTICE.Rows[i].SetField<String>("NOTICE_ZIP_CODE", MergeDataSet.CUSTOMER.Rows[0].Field<String>("COSIGNER_ZIP_CODE").TrimEnd());
                        MergeDataSet.NOTICE.Rows[i].SetField<Boolean>("CosignerNotice", true);
                        MergeDataSet.NOTICE.Rows[i].AcceptChanges();                        // Clear modified status
                        MergeDataSet.NOTICE.Rows[i].SetAdded();                             // Force Added Status so Update method INSERTs it
                        ClosedNoticeTempTableAdapter.Update(MergeDataSet.NOTICE.Rows[i]);
                    }
                }
            }

            ClosedNoticeTempTableAdapter.FillByAll(MergeDataSet.ClosedNoticeTemp);
            if (MergeDataSet.ClosedNoticeTemp.Rows.Count > 0)
            {
                Boolean lbCosigner = false;

                oWord.Visible = true;

                oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oTrue);
                Word.MailMerge wrdMailMerge, NewMailMerge;

                String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsDataPath = Program.GsDataPath + @"\MailMerge\DataSources\",
                       lsCatalog = "", lsServerName = "";

                lsServerName = lsConnect.Substring(lsConnect.IndexOf("DATA SOURCE=") + 12, lsConnect.IndexOf(";") - (lsConnect.IndexOf("DATA SOURCE=") + 12));
                lsServerName = lsServerName.Replace('\\', '_');
                lsDataPath += lsServerName;
                lsCatalog = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16, lsConnect.IndexOf(";INTEGRATED") - (lsConnect.IndexOf("INITIAL CATALOG=") + 16));
                lsCatalog += " ClosedNoticeTemp.odc";
                lsDataPath += " " + lsCatalog;

                wrdMailMerge = oWordDoc.MailMerge;
                wrdMailMerge.OpenDataSource(lsDataPath, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
                wrdMailMerge.Execute(ref oFalse);
                oWordDoc.Saved = true;
                oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                oWordDoc = null;
                oWord = null;
                wrdMailMerge = null;

                // Moses Newman 06/25/2018 make comment records for notices 00,01,06,09, but only if run from LateCharge program!
                // Moses Newman 08/21/2018 add 02,03 also.
                // Moses Newman 02/26/2019 04 and 05 now too.
                //if ((tnLetterNo == 0 || tnLetterNo == 1 || tnLetterNo == 2 || tnLetterNo == 3 || tnLetterNo == 6 || tnLetterNo == 9) && tbMakeComments)
                if (tbMakeComments)
                {
                    String FileName = "", lsCustNo = "";
                    Int32 lnDealer;
                    oWord = new Word.Application();
                    oWordDoc = new Word.Document();
                    oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oTrue);
                    oWord.Visible = false;

                    NewMailMerge = oWordDoc.MailMerge;
                    NewMailMerge.OpenDataSource(lsDataPath, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                          ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    int lnProgress = 0;
                    for (Int32 CustomerCount = 0; CustomerCount < NewMailMerge.DataSource.RecordCount; CustomerCount++)
                    {
                        NewMailMerge.DataSource.FirstRecord = (int)NewMailMerge.DataSource.ActiveRecord;
                        NewMailMerge.DataSource.LastRecord = (int)NewMailMerge.DataSource.ActiveRecord;
                        lsCustNo = NewMailMerge.DataSource.DataFields["NOTICE_NO"].Value;
                        lnDealer = Convert.ToInt32(NewMailMerge.DataSource.DataFields["NOTICE_DEALER"].Value);
                        // Moses Newman 11/25/2018 Handle cosigner notices.
                        lbCosigner = NewMailMerge.DataSource.DataFields["CosignerNotice"].Value == "False" ? false : true;
                        lsCommentText = "";

                        // Moses Newman 10/08/2018 add new notice comment text.
                        switch (tnLetterNo)
                        {
                            case 0:
                                lsCommentText = lbCosigner ? "(Cosigner) Created Late Charge Notice 00 – First Payment Default" : "Created Late Charge Notice 00 – First Payment Default";
                                break;
                            case 1:
                                lsCommentText = lbCosigner ? "(Cosigner) Created Late Charge Notice 01 – Late Payment Notice" : "Created Late Charge Notice 01 – Late Payment Notice";
                                break;
                            case 2:
                                lsCommentText = lbCosigner ? "(Cosigner) Created Collection Letter 02  - Mass (21) Days" : "Created Collection Letter 02  - Mass (21) Days";
                                break;
                            case 3:
                                lsCommentText = lbCosigner ? "(Cosigner) Created Collection Letter 03 – All States (10) Days" : "Created Collection Letter 03 – All States (10) Days";
                                break;
                            // Moses Newman 02/26/2019 add notice 4 (Mass 50 day) and notice 5 (All State 55 day)
                            case 4:
                                lsCommentText = lbCosigner ? "(Cosigner) Created Collection Letter 04  - Mass (50) Days" : "Created Collection Letter 04  - Mass (50) Days";
                                break;
                            case 5:
                                lsCommentText = lbCosigner ? "(Cosigner) Created Collection Letter 05 – All States (55) Days" : "Created Collection Letter 05 – All States (55) Days";
                                break;
                            case 6:
                                lsCommentText = lbCosigner ? "(Cosigner) Created Late Charge Notice 06 – Delinquency Notice" : "Created Late Charge Notice 06 – Delinquency Notice";
                                break;
                            case 9:
                                lsCommentText = lbCosigner ? "(Cosigner) Created Late Charge Notice 09 – Default Notice" : "Created Late Charge Notice 09 – Default Notice";
                                break;
                        }

                        FileName = MakeNoticeComment(lsCustNo, lnDealer, lsCommentText);
                        tsProgMessage = "*** Creating attachement for Notice Number: " + tnLetterNo + " for Customer: " + lsCustNo + " " + (CustomerCount + 1).ToString() + " of " + NewMailMerge.DataSource.RecordCount.ToString();
                        lnProgress = (Int32)(Math.Round(((Double)(CustomerCount + 1) / (Double)NewMailMerge.DataSource.RecordCount), 2) * 100);
                        worker.ReportProgress(lnProgress);

                        NewMailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
                        NewMailMerge.Execute(ref oFalse);
                        oWordDoc.Application.ActiveDocument.SaveAs2(FileName,
                                              Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault,
                                              ref oMissing,
                                              ref oMissing,
                                              ref oMissing,
                                              ref oMissing,
                                              ref oMissing,
                                              oTrue,
                                              ref oMissing,
                                              oTrue,
                                              ref oMissing,
                                              ref oMissing,
                                              ref oMissing,
                                              ref oMissing,
                                              ref oMissing,
                                              ref oMissing,
                                              ref oMissing);
                        if ((CustomerCount + 1) < NewMailMerge.DataSource.RecordCount)
                            NewMailMerge.DataSource.ActiveRecord = Word.WdMailMergeActiveRecord.wdNextRecord;
                    }
                    oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                    oWordDoc = null;
                    oWord.Quit();
                    oWord = null;
                    NewMailMerge = null;
                }
            }
            ClosedNoticeTempTableAdapter.DeleteAll();
            ClosedNoticeTempTableAdapter.Dispose();
            MergeDataSet.Dispose();
        }

        private String MakeNoticeComment(String CustomerNo, Int32 Dealer, String CommentMessage)
        {
            IACDataSetTableAdapters.COMMENTTableAdapter cOMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();

            Object loQuery = null;

            Int32 lnSeq = 0;
            String FileName = "", lsCommentKey = "", lsFullComment = "";

            if (lnSeq == 0)
            {
                loQuery = cOMMENTTableAdapter.SeqNoQuery(CustomerNo, DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;
            // Moses Newman 10/18/2017 create string unique key that will become word filename!
            lsCommentKey = CustomerNo + DateTime.Now.Date.ToString("yyyyMMdd") + lnSeq.ToString().Trim() + "SYS";
            // Moses Newman 11/21/2017 Remove hard coded UNC Pathing.
            FileName = Program.GsDataPath + @"CommentAttachments\Notices\" + lsCommentKey + ".docx";

            WholeComment loTempComment;

            loTempComment = SplitComments(CommentMessage);
            // Moses Newman 02/22/2019 Add Full Comment
            lsFullComment = loTempComment.Field1 + loTempComment.Field2 + loTempComment.Field3;
            cOMMENTTableAdapter.Insert(CustomerNo,
                                        DateTime.Now.Date, lnSeq,
                                        "SYS",
                                        lsFullComment,
                                        //loTempComment.Field1,
                                        //loTempComment.Field2,
                                        //loTempComment.Field3,
                                        "",
                                        Dealer,
                                        "SYS" + "  ",
                                        DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'),
                                        false, "", "",
                                        0, @"WordDoc.bmp", FileName.ToString(), null);
            return FileName;
        }

        private WholeComment SplitComments(String tsComment)
        {
            WholeComment loReturn;

            String lsComment1, lsComment2, lsComment3;
            Int32 lnCommentLength = 0;

            lsComment1 = "";
            lsComment2 = "";
            lsComment3 = "";
            lnCommentLength = tsComment.Length;
            if (lnCommentLength <= 60)
                lsComment1 = tsComment;
            else
            {
                lsComment1 = tsComment.Substring(0, 60);
                if (lnCommentLength <= 120)
                    lsComment2 = tsComment.Substring(60, lnCommentLength - 60);
                else
                {
                    lsComment2 = tsComment.Substring(60, 60);
                    lsComment3 = tsComment.Substring(120, lnCommentLength - 120);
                }
            }

            loReturn.Field1 = lsComment1;
            loReturn.Field2 = lsComment2;
            loReturn.Field3 = lsComment3;

            return loReturn;
        }

        public void ScrnPrnt(String tsFileName)
        {
            Object fileName = "", readOnly = false, isVisible = true;
            Word._Application oWord = new Word.Application();
            Word._Document oWordDoc = new Word.Document();
            oWord.Visible = true;


            fileName = Program.GsDataPath + @"\MailMerge\TEMPSCRN.docx";
            oWordDoc = oWord.Documents.Open(ref fileName, ref oMissing, ref readOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref isVisible);

            oWordDoc.Activate();
            oWordDoc.InlineShapes.AddPicture(tsFileName);
            oWordDoc.Saved = true;
            oWordDoc.PrintOut();
            Thread.Sleep(5000);
            oWordDoc.Close(ref readOnly);
            oWordDoc = null;
            oWord.Quit(ref readOnly, ref oMissing, ref oMissing);
            oWord = null;
        }

        public void SaveJpeg(string path, Image img, int quality)
        {
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            ImageCodecInfo jpegCodec;
            jpegCodec = GetEncoderInfo(@"image/jpeg");
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            System.IO.MemoryStream mss = new System.IO.MemoryStream();
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite);
            img.Save(mss, jpegCodec, encoderParams);
            byte[] matriz = mss.ToArray();
            fs.Write(matriz, 0, matriz.Length);
            mss.Close();
            fs.Close();
        }

        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        public void CreateECHNotice(IACDataSet PassedDataSet, Int32 tnDayDue, DateTime tdDateDue, String tsMailToText, ref BackgroundWorker worker, ref String tsProgMessage, Boolean tbSendAsEmail = true, Boolean tbAutoPay = true, Boolean tbTestMode = false, String tsMergeFileName = "")
        {
            String[] EmailAddresses = { };
            String SqlQuery = "";
            int lnProgress = 0, lnTotalSteps = 0, NoServerCount = 0;
            Object oFalse = false;
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CustBankTableAdapter CustBankTableAdapter = new IACDataSetTableAdapters.CustBankTableAdapter();
            IACDataSetTableAdapters.EmailTableAdapter EmailTableAdapter = new IACDataSetTableAdapters.EmailTableAdapter();
            CUSTOMERTableAdapter.FillByActiveDayDue(PassedDataSet.CUSTOMER, tnDayDue, tbAutoPay, !tbSendAsEmail);

            Object oTemplatePath = "",loConnect = null;

            if (tsMergeFileName == "")
                oTemplatePath = Program.GsDataPath + @"\MailMerge\ElectronicClearingHousePayment.docx";
            else
                oTemplatePath = Program.GsDataPath + @"\MailMerge\" + tsMergeFileName.TrimStart().TrimEnd();
            Word.MailMerge wrdMailMerge;

            String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsDataPath = Program.GsDataPath + @"\MailMerge\DataSources\",
                   lsCatalog = "", lsServerName = "", lsSMSMessage = "", lsCellPhone = "",lsNewFileName = "";

            lsServerName = lsConnect.Substring(lsConnect.IndexOf("DATA SOURCE=") + 12, lsConnect.IndexOf(";") - (lsConnect.IndexOf("DATA SOURCE=") + 12));
            lsServerName = lsServerName.Replace('\\', '_');
            lsDataPath += lsServerName;
            lsCatalog = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16, lsConnect.IndexOf(";INTEGRATED") - (lsConnect.IndexOf("INITIAL CATALOG=") + 16));
            lsCatalog += " TEMPCUSTBANK.odc";
            lsDataPath += " " + lsCatalog;
            lnTotalSteps = PassedDataSet.CUSTOMER.Rows.Count + 2;
            loConnect = lsConnect;
            SqlQuery = "IACSQLPRODUCTION.dbo." + "EMPTY" + Program.gsUserID; //Moses Newman 06/08/2021 Create User Specific ODC
            lsNewFileName = Program.GsDataPath + @"\MailMerge\DataSources\EMPTY" + Program.gsUserID + ".ODC";
            CreateODC(lsNewFileName, SqlQuery); //Moses Newman 06/08/2021 Create User Specific ODC
            object lsSQL = "SELECT * FROM IACSQLPRODUCTION.dbo.EMPTYMNN";
          
            for (Int32 CustomerIndex = 0; CustomerIndex < PassedDataSet.CUSTOMER.Rows.Count; CustomerIndex++)
            {
                CustBankTableAdapter.TempLoadAll(PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"), tnDayDue, tdDateDue, tbAutoPay, !tbSendAsEmail, "EMPTY" + Program.gsUserID,(String)null);
                if (tbSendAsEmail)
                {
                    // Moses Newman 09/22/2014 make sure customer has an email address if not in test mode!
                    EmailTableAdapter.Fill(PassedDataSet.Email, PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"));
                    if (PassedDataSet.Email.Rows.Count < 1 && !tbTestMode)
                        continue;
                    if (!tbTestMode)
                        if (PassedDataSet.Email.Rows[0].Field<String>("EmailAddress").TrimEnd() == "")
                            continue;
                    // Moses Newman 11/19/2014 handle multiple email addresses seperated by ;s
                    // Moses Newman 11/19/2014 add comma as a email address sepeartor also!
                    if (tbTestMode)
                        EmailAddresses = PassedDataSet.Email.Rows[0].Field<String>("TestEmail").Split(new char[] { ';', ',' });
                    else
                        EmailAddresses = PassedDataSet.Email.Rows[0].Field<String>("EmailAddress").Split(new char[] { ';', ',' });
                    if (EmailAddresses.Length != 0)
                    {
                        foreach (string addr in EmailAddresses)
                        {
                            EmailTableAdapter.UpdateTestEmailbyAccount(PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"), addr);

                            //CustBankTableAdapter.CustBankLoadAll(PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"), tnDayDue, tdDateDue, tbAutoPay, !tbSendAsEmail,(String)null);
                            Word._Application oWord = new Word.Application();
                            Word._Document oWordDoc = new Word.Document();

                            oWord.Visible = false;

                            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oTrue);

                            wrdMailMerge = oWordDoc.MailMerge;
                            wrdMailMerge.OpenDataSource(lsNewFileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                            // Moses Newman 11/09/2014 change Destination to Email instead of new word document,
                            // so now HTML formatted email can be sent instead of text based MailItem and seperate Outlook load.
                            wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToEmail;
                            if(!tbTestMode)
                                wrdMailMerge.MailAddressFieldName = "EmailAddress";
                            else
                                wrdMailMerge.MailAddressFieldName = "TestEmail";
                            wrdMailMerge.MailAsAttachment = false;
                            wrdMailMerge.MailSubject = "*** " + PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO") + " ATTENTION: MESSAGE FROM INDUSTRIAL ACCEPTANCE CORPORATION. ***";
                            wrdMailMerge.MailFormat = Word.WdMailMergeMailFormat.wdMailFormatHTML;
                            wrdMailMerge.Execute(ref oFalse);

                            tsProgMessage = "";
                            oWordDoc.Saved = true;
                            oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                            oWordDoc = null;
                            oWord.Quit(ref oFalse, ref oMissing, ref oMissing);
                            oWord = null;
                            wrdMailMerge = null;
                        }
                    }
                    else
                    {
                        // Moses Newman 06/09/2021 Why load customer twice?
                        Word._Application oWord = new Word.Application();
                        Word._Document oWordDoc = new Word.Document();

                        //oWord.Visible = true;


                        oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oTrue);

                        wrdMailMerge = oWordDoc.MailMerge;
                        // Moses Newman 06/09/2021 ONLY USE NEW USER SPECIFIC ODC!
                        wrdMailMerge.OpenDataSource(lsNewFileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                        // Moses Newman 11/09/2014 change Destination to Email instead of new word document,
                        // so now HTML formatted email can be sent instead of text based MailItem and seperate Outlook load.
                        wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToEmail;
                        if (tbTestMode)
                            wrdMailMerge.MailAddressFieldName = "TestEmail";
                        else
                            wrdMailMerge.MailAddressFieldName = "EmailAddress";
                        wrdMailMerge.MailAsAttachment = false;
                        // Moses Newman 03/20/2015 Change Urgent Message to ATTENTION: MESSSAGE"
                        wrdMailMerge.MailSubject = "*** " + PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO") + " ATTENTION: MESSAGE FROM INDUSTRIAL ACCEPTANCE CORPORATION. ***";
                        wrdMailMerge.MailFormat = Word.WdMailMergeMailFormat.wdMailFormatHTML;
                        wrdMailMerge.Execute(ref oFalse);

                        tsProgMessage = "";
                        oWordDoc.Saved = true;
                        oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                        oWordDoc = null;
                        oWord.Quit(ref oFalse, ref oMissing, ref oMissing);
                        oWord = null;
                        wrdMailMerge = null;
                    }
                }
                else
                {
                    CustBankTableAdapter.Fill(PassedDataSet.CustBank, PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"));
                    // Moses Newman if no Customer Bank Record goto next customer!
                    if (PassedDataSet.CustBank.Rows.Count < 1)
                        continue;
                    tsProgMessage = "";
                    lsSMSMessage = "ATTENTION: " + PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_NO") + " " +
                        PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_FIRST_NAME").TrimEnd() +
                        " " + PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_LAST_NAME").TrimEnd() +
                        " On " + PassedDataSet.CustBank.Rows[0].Field<DateTime>("DueDate").ToShortDateString() +
                        " your Monthly EFT Payment of: " + PassedDataSet.CustBank.Rows[0].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT").ToString("C", new System.Globalization.CultureInfo("en-US")) + "\n" +
                        " from IAC will be debited from your checking account ending in: " +
                        PassedDataSet.CustBank.Rows[0].Field<String>("OPNBANK_ACCOUNT_NO").TrimEnd().Substring(PassedDataSet.CustBank.Rows[0].Field<String>("OPNBANK_ACCOUNT_NO").TrimEnd().Length - 4, 4);

                    // Create a request for the URL. 	
                    if (tbTestMode)
                        lsCellPhone = "+1(203) 804-9935";
                    else
                    {
                        lsCellPhone = "+1(" + PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_CELL_PHONE").Substring(0, 3) + ") ";
                        lsCellPhone += PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_CELL_PHONE").Substring(3, 3) + "-";
                        lsCellPhone += PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_CELL_PHONE").Substring(6, 4);
                    }
                    var client = new TelAPIRestClient("AC4c889084ae5c6f5a2c6a45f9ba09fa24",
                                                        "9ef0b0b07799480db0364c463d06765b");
                    if (lsSMSMessage.Length > 160)
                        lsSMSMessage = lsSMSMessage.Substring(0, 159);
                    try
                    {
                        NoServerCount = 0;
                        var sms = client.SendSmsMessage(
                               "+1(203) 680-3840",
                               lsCellPhone,
                               lsSMSMessage);
                        if (sms != null)
                        {
                            // Moses Newman 06/13/2019 Retry if SID is null due to internet 503 error.
                            while (sms.Sid == null && NoServerCount < 100)
                            {
                                sms = client.SendSmsMessage(
                                    "+1(203) 680-3840",
                                    lsCellPhone,
                                    lsSMSMessage);
                                NoServerCount++;
                            }

                            tsProgMessage = "\nSms Sid : {0}" + sms.Sid.ToString() + "\n";
                        }
                    }
                    catch (TelAPIException ex)
                    {
                        Console.WriteLine("{0}", ex.Message);
                    }
                }
                lnProgress = (Int32)(Math.Round(((Double)CustomerIndex / (Double)lnTotalSteps), 2) * 100);
                tsProgMessage += CustomerIndex.ToString().TrimStart() + " of " + PassedDataSet.CUSTOMER.Rows.Count.ToString() + ".\n" +
                                 PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO") + " " +
                                 PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_FIRST_NAME").TrimEnd() + " " +
                                 PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_LAST_NAME").TrimEnd();

                worker.ReportProgress(lnProgress);
            }
            wrdMailMerge = null;
            CUSTOMERTableAdapter.Dispose();
            CustBankTableAdapter.Dispose();
        }

        public void CreateBULKSMS(IACDataSet PassedDataSet, Int32 tnDayDue, DateTime tdDateDue, String tsMailToText, ref BackgroundWorker worker, ref String tsProgMessage, Boolean tbSendAsEmail = true, Boolean tbAutoPay = true, Boolean tbTestMode = false, String tsMergeFileName = "")
        {
            String[] EmailAddresses = { };
            int lnProgress = 0, lnTotalSteps = 0;
            Object oFalse = false;
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CustBankTableAdapter CustBankTableAdapter = new IACDataSetTableAdapters.CustBankTableAdapter();
            IACDataSetTableAdapters.EmailTableAdapter EmailTableAdapter = new IACDataSetTableAdapters.EmailTableAdapter();
            CUSTOMERTableAdapter.FillByActiveDayDue(PassedDataSet.CUSTOMER, tnDayDue, tbAutoPay, !tbSendAsEmail);

            Object oTemplatePath = "";

            if (tsMergeFileName == "")
                oTemplatePath = Program.GsDataPath + @"\MailMerge\ElectronicClearingHousePayment.docx";
            else
                oTemplatePath = Program.GsDataPath + @"\MailMerge\" + tsMergeFileName.TrimStart().TrimEnd();
            Word.MailMerge wrdMailMerge;

            String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), lsDataPath = Program.GsDataPath + @"\MailMerge\DataSources\",
                   lsCatalog = "", lsServerName = "", lsSMSMessage = "", lsCellPhone = "";

            lsServerName = lsConnect.Substring(lsConnect.IndexOf("DATA SOURCE=") + 12, lsConnect.IndexOf(";") - (lsConnect.IndexOf("DATA SOURCE=") + 12));
            lsServerName = lsServerName.Replace('\\', '_');
            lsDataPath += lsServerName;
            lsCatalog = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16, lsConnect.IndexOf(";INTEGRATED") - (lsConnect.IndexOf("INITIAL CATALOG=") + 16));
            lsCatalog += " CustBank.odc";
            lsDataPath += " " + lsCatalog;
            lnTotalSteps = PassedDataSet.CUSTOMER.Rows.Count + 2;
            String SqlQuery = "IACSQLPRODUCTION.dbo." + "EMPTY" + Program.gsUserID; //Moses Newman 06/08/2021 Create User Specific ODC
            String lsNewFileName = Program.GsDataPath + @"\MailMerge\DataSources\EMPTY" + Program.gsUserID + ".ODC";
            CreateODC(lsNewFileName, SqlQuery); //Moses Newman 06/08/2021 Create User Specific ODC
            for (Int32 CustomerIndex = 0; CustomerIndex < PassedDataSet.CUSTOMER.Rows.Count; CustomerIndex++)
            {
                // Moses Newman 06/10/2021
                //CustBankTableAdapter.CustBankLoadAll(PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"), tnDayDue, tdDateDue, tbAutoPay, !tbSendAsEmail, (String)null);
                CustBankTableAdapter.TempLoadAll(PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"), tnDayDue, tdDateDue, tbAutoPay, !tbSendAsEmail, "EMPTY" + Program.gsUserID, (String)null);
                if (tbSendAsEmail)
                {
                    // Moses Newman 09/22/2014 make sure customer has an email address if not in test mode!
                    EmailTableAdapter.Fill(PassedDataSet.Email, PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"));
                    if (PassedDataSet.Email.Rows.Count < 1 && !tbTestMode)
                        continue;
                    if (!tbTestMode)
                        if (PassedDataSet.Email.Rows[0].Field<String>("EmailAddress").TrimEnd() == "")
                            continue;
                    // Moses Newman 11/19/2014 handle multiple email addresses seperated by ;s
                    // Moses Newman 11/19/2014 add comma as a email address sepeartor also!
                    if (tbTestMode)
                        EmailAddresses = PassedDataSet.Email.Rows[0].Field<String>("TestEmail").Split(new char[] { ';', ',' });
                    else
                        EmailAddresses = PassedDataSet.Email.Rows[0].Field<String>("EmailAddress").Split(new char[] { ';', ',' });
                    if (EmailAddresses.Length != 0)
                    {
                        foreach (string addr in EmailAddresses)
                        {
                            EmailTableAdapter.UpdateTestEmailbyAccount(PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"), addr);
                            // Moses Newman this is already loaded no need to do it again!
                            //CustBankTableAdapter.CustBankLoadAll(PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"), tnDayDue, tdDateDue, tbAutoPay, !tbSendAsEmail, (String)null);
                            Word._Application oWord = new Word.Application();
                            Word._Document oWordDoc = new Word.Document();

                            //oWord.Visible = true;

                            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oTrue);

                            wrdMailMerge = oWordDoc.MailMerge;
                            // Moses Newman 06/10/2021 Use new user specific ODC
                            wrdMailMerge.OpenDataSource(lsNewFileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                            // Moses Newman 11/09/2014 change Destination to Email instead of new word document,
                            // so now HTML formatted email can be sent instead of text based MailItem and seperate Outlook load.
                            wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToEmail;
                            wrdMailMerge.MailAddressFieldName = "TestEmail";
                            wrdMailMerge.MailAsAttachment = false;
                            wrdMailMerge.MailSubject = "*** " + PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO") + " ATTENTION: MESSAGE FROM INDUSTRIAL ACCEPTANCE CORPORATION. ***";
                            wrdMailMerge.MailFormat = Word.WdMailMergeMailFormat.wdMailFormatHTML;
                            wrdMailMerge.Execute(ref oFalse);

                            tsProgMessage = "";
                            oWordDoc.Saved = true;
                            oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                            oWordDoc = null;
                            oWord.Quit(ref oFalse, ref oMissing, ref oMissing);
                            oWord = null;
                            wrdMailMerge = null;

                        }
                    }
                    else
                    {
                        // Moses Newman 06/10/2021 been there done that!
                        //CustBankTableAdapter.CustBankLoadAll(PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"), tnDayDue, tdDateDue, tbAutoPay, !tbSendAsEmail, (String)null);
                        Word._Application oWord = new Word.Application();
                        Word._Document oWordDoc = new Word.Document();

                        //oWord.Visible = true;


                        oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oTrue);

                        wrdMailMerge = oWordDoc.MailMerge;
                        // Moses Newman 06/10/2021 Use new user specific ODC
                        wrdMailMerge.OpenDataSource(lsNewFileName, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                        // Moses Newman 11/09/2014 change Destination to Email instead of new word document,
                        // so now HTML formatted email can be sent instead of text based MailItem and seperate Outlook load.
                        wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToEmail;
                        if (tbTestMode)
                            wrdMailMerge.MailAddressFieldName = "TestEmail";
                        else
                            wrdMailMerge.MailAddressFieldName = "EmailAddress";
                        wrdMailMerge.MailAsAttachment = false;
                        // Moses Newman 03/20/2015 Change Urgent Message to ATTENTION: MESSSAGE"
                        wrdMailMerge.MailSubject = "*** " + PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO") + " ATTENTION: MESSAGE FROM INDUSTRIAL ACCEPTANCE CORPORATION. ***";
                        wrdMailMerge.MailFormat = Word.WdMailMergeMailFormat.wdMailFormatHTML;
                        wrdMailMerge.Execute(ref oFalse);

                        tsProgMessage = "";
                        oWordDoc.Saved = true;
                        oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                        oWordDoc = null;
                        oWord.Quit(ref oFalse, ref oMissing, ref oMissing);
                        oWord = null;
                        wrdMailMerge = null;
                    }
                }
                else
                {
                    CustBankTableAdapter.Fill(PassedDataSet.CustBank, PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO"));
                    // Moses Newman if no Customer Bank Record goto next customer!
                    if (PassedDataSet.CustBank.Rows.Count < 1)
                        continue;
                    tsProgMessage = "";
                    lsSMSMessage = "ATTENTION: " + PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_NO") + " " +
                        PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_FIRST_NAME").TrimEnd() +
                        " " + PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_LAST_NAME").TrimEnd() +
                        " On " + PassedDataSet.CustBank.Rows[0].Field<DateTime>("DueDate").ToShortDateString() +
                        " your Monthly EFT Payment of: " + PassedDataSet.CustBank.Rows[0].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT").ToString("C", new System.Globalization.CultureInfo("en-US")) + "\n" +
                        " from IAC will be debited from your checking account ending in: " +
                        PassedDataSet.CustBank.Rows[0].Field<String>("OPNBANK_ACCOUNT_NO").TrimEnd().Substring(PassedDataSet.CustBank.Rows[0].Field<String>("OPNBANK_ACCOUNT_NO").TrimEnd().Length - 4, 4);

                    // Create a request for the URL. 	
                    if (tbTestMode)
                        lsCellPhone = "+1(203) 804-9935";
                    else
                    {
                        lsCellPhone = "+1(" + PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_CELL_PHONE").Substring(0, 3) + ") ";
                        lsCellPhone += PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_CELL_PHONE").Substring(3, 3) + "-";
                        lsCellPhone += PassedDataSet.CustBank.Rows[0].Field<String>("CUSTOMER_CELL_PHONE").Substring(6, 4);
                    }
                    var client = new TelAPIRestClient("AC4c889084ae5c6f5a2c6a45f9ba09fa24",
                                                        "9ef0b0b07799480db0364c463d06765b");
                    if (lsSMSMessage.Length > 160)
                        lsSMSMessage = lsSMSMessage.Substring(0, 159);
                    try
                    {
                        var sms = client.SendSmsMessage(
                               "+1(203) 680-3840",
                               lsCellPhone,
                               lsSMSMessage);
                        if (sms != null)
                            tsProgMessage = "\nSms Sid : {0}" + sms.Sid.ToString() + "\n";
                    }
                    catch (TelAPIException ex)
                    {
                        Console.WriteLine("{0}", ex.Message);
                    }
                }
                lnProgress = (Int32)(Math.Round(((Double)CustomerIndex / (Double)lnTotalSteps), 2) * 100);
                tsProgMessage += CustomerIndex.ToString().TrimStart() + " of " + PassedDataSet.CUSTOMER.Rows.Count.ToString() + ".\n" +
                                 PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_NO") + " " +
                                 PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_FIRST_NAME").TrimEnd() + " " +
                                 PassedDataSet.CUSTOMER.Rows[CustomerIndex].Field<String>("CUSTOMER_LAST_NAME").TrimEnd();

                worker.ReportProgress(lnProgress);
            }
            wrdMailMerge = null;
            CUSTOMERTableAdapter.Dispose();
            CustBankTableAdapter.Dispose();
        }

        void CreateODC(String tsFileName, String tsCommand)
        {
            if (File.Exists(tsFileName))
                File.Delete(tsFileName);
            String RealFileName = tsFileName.Substring(tsFileName.LastIndexOf(@"\")+1);
            RealFileName = RealFileName.Substring(0, RealFileName.Length - 4);

            StreamWriter strm = new StreamWriter(tsFileName, false);

            strm.WriteLine("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            strm.WriteLine("xmlns=\"http://www.w3.org/TR/REC-html40\">");
            strm.WriteLine("");
            strm.WriteLine("<head>");
            strm.WriteLine("<meta http-equiv=Content-Type content=\"text/x-ms-odc; charset=utf-8\">");
            strm.WriteLine("<meta name=ProgId content=ODC.Table>");
            strm.WriteLine("<meta name=SourceType content=OLEDB>");
            strm.WriteLine("<meta name=Catalog content=IACSQLPRODUCTION>");
            strm.WriteLine("<meta name=Schema content=dbo>");
            strm.WriteLine("<meta name=Table content="+RealFileName+">");
            strm.WriteLine("<title>" + RealFileName + "</title>");
            strm.WriteLine("<xml id=docprops><o:DocumentProperties");
            strm.WriteLine("xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            strm.WriteLine("xmlns=\"http://www.w3.org/TR/REC-html40\">");
            strm.WriteLine("<o:Name>" + tsFileName + "</o:Name>");
            strm.WriteLine("</o:DocumentProperties>");
            strm.WriteLine("</xml><xml id=msodc><odc:OfficeDataConnection");
            strm.WriteLine("xmlns:odc=\"urn:schemas-microsoft-com:office:odc\"");
            strm.WriteLine("xmlns=\"http://www.w3.org/TR/REC-html40\">");
            strm.WriteLine("<odc:Connection odc:Type=\"OLEDB\">");
            strm.WriteLine("   <odc:ConnectionString>Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=True;Data Source=SQL-IAC;Use Procedure for Prepare=1;Auto Translate=True;Packet ");
            strm.WriteLine("    Size=4096;Workstation ID=SQL;Use Encryption for Data=False;Tag with column collation when possible=False;Initial Catalog=IACSQLPRODUCTION</odc:ConnectionString>");
            strm.WriteLine("<odc:CommandType>Table</odc:CommandType>");
            strm.WriteLine("<odc:CommandText>&quot;IACSQLPRODUCTION&quot;.&quot;dbo&quot;.&quot;" + RealFileName + "&quot;</odc:CommandText>");
            strm.WriteLine("<odc:AlwaysUseConnectionFile/>");
            strm.WriteLine("</odc:Connection>");
            strm.WriteLine("</odc:OfficeDataConnection>");
            strm.WriteLine("</xml>");
            strm.WriteLine("<style>");
            strm.WriteLine("<!--");
            strm.WriteLine(".ODCDataSource");
            strm.WriteLine("{");
            strm.WriteLine("behavior: url(dataconn.htc);");
            strm.WriteLine("}");
            strm.WriteLine("-->");
            strm.WriteLine("</style>");
            strm.WriteLine("</head>");
            strm.WriteLine("<body onload = 'init()' scroll = no leftmargin = 0 topmargin = 0 rightmargin = 0 style = 'border: 0px'>");
            strm.WriteLine("<table style = 'border: solid 1px threedface; height: 100%; width: 100%' cellpadding = 0 cellspacing = 0 width = '100%'>");
            strm.WriteLine("<tr>");
            strm.WriteLine("<td id = tdName style = 'font-family:arial; font-size:medium; padding: 3px; background-color: threedface'>");
            strm.WriteLine("&nbsp;");
            strm.WriteLine("</td>");
            strm.WriteLine("<td id = tdTableDropdown style = 'padding: 3px; background-color: threedface; vertical-align: top; padding-bottom: 3px'>");
            strm.WriteLine("");
            strm.WriteLine("&nbsp;");
            strm.WriteLine("</td>");
            strm.WriteLine("</tr>");
            strm.WriteLine("<tr>");
            strm.WriteLine("<td id = tdDesc colspan = '2' style = 'border-bottom: 1px threedshadow solid; font-family: Arial; font-size: 1pt; padding: 2px; background-color: threedface'>");
            strm.WriteLine("");
            strm.WriteLine("&nbsp;");
            strm.WriteLine("</td>");
            strm.WriteLine("</tr>");
            strm.WriteLine("<tr>");
            strm.WriteLine("<td colspan = '2' style = 'height: 100%; padding-bottom: 4px; border-top: 1px threedhighlight solid;'>");
            strm.WriteLine("<div id = 'pt' style = 'height: 100%' class='ODCDataSource'></div>");
            strm.WriteLine("</td> ");
            strm.WriteLine("</tr> ");
            strm.WriteLine("</table> ");
            strm.WriteLine("");
            strm.WriteLine("");
            strm.WriteLine("<script language = 'javascript'>");
            strm.WriteLine("");
            strm.WriteLine("function init() {");
            strm.WriteLine("  var sName, sDescription;");
            strm.WriteLine("  var i, j;");
            strm.WriteLine("");
            strm.WriteLine("try {");
            strm.WriteLine("  sName = unescape(location.href)");
            strm.WriteLine("");
            strm.WriteLine("  i = sName.lastIndexOf(\".\")");
            strm.WriteLine("  if (i>=0) { sName = sName.substring(1, i); }");
            strm.WriteLine("");
            strm.WriteLine("  i = sName.lastIndexOf(\"/\")");
            strm.WriteLine("  if (i>=0) { sName = sName.substring(i+1, sName.length); }");
            strm.WriteLine("");
            strm.WriteLine("  document.title = sName;");
            strm.WriteLine("  document.getElementById(\"tdName\").innerText = sName;");
            strm.WriteLine("");
            strm.WriteLine("  sDescription = document.getElementById(\"docprops\").innerHTML;");
            strm.WriteLine("");
            strm.WriteLine("  i = sDescription.indexOf(\"escription>\")");
            strm.WriteLine("  if (i>=0) { j = sDescription.indexOf(\"escription>\", i + 11); }");
            strm.WriteLine("");
            strm.WriteLine("  if (i>=0 && j >= 0) {");
            strm.WriteLine("    j = sDescription.lastIndexOf(\"</\", j);");
            strm.WriteLine("");
            strm.WriteLine("    if (j>=0) {");
            strm.WriteLine("        sDescription = sDescription.substring(i + 11, j)");
            strm.WriteLine("      if (sDescription != \"\") {");
            strm.WriteLine("          document.getElementById(\"tdDesc\").style.fontSize = \"x-small\";");
            strm.WriteLine("        document.getElementById(\"tdDesc\").innerHTML = sDescription;");
            strm.WriteLine("      }");
            strm.WriteLine("    }");
            strm.WriteLine("  }");
            strm.WriteLine(" }");
            strm.WriteLine("catch(e) {");
            strm.WriteLine("");
            strm.WriteLine("  }");
            strm.WriteLine("}");
            strm.WriteLine("</script>");
            strm.WriteLine("");
            strm.WriteLine("</body>");
            strm.WriteLine("");
            strm.WriteLine("</html>");
            strm.Flush();
            strm.Close();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IAC2021SQL.GeneralWSProxy;
using IAC2021SQL.LoginWSProxy;
using IAC2021SQL.MessageWSProxy;
using IAC2021SQL.SubscriberWSProxy;
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Outlook = Microsoft.Office.Interop.Outlook;
using Word = Microsoft.Office.Interop.Word;

namespace IAC2021SQL
{
    public partial class FormBULKSMSMessage : Form
    {
        private struct WholeComment
        {
            public String Field1,
                          Field2,
                          Field3;
        }
        private int tempID = -1;
        private String _Message_Sent = "", _APIMessage = "";
        public String CellPhone { get; set; }
        public String securityToken;
        
        public int TempID
        {
            get
            {
                return this.tempID;
            }
            set
            {
                this.tempID = value;
            }
        }

        public String MessageSent
        {
            get
            {
                return this._Message_Sent;
            }
            set
            {
                this._Message_Sent = value;
            }
        }

        public String APIMessage
        {
            get
            {
                return this._APIMessage;
            }
            set
            {
                this._APIMessage = value;
            }
        }

        private String sbtLogin()
        {
            LoginAPIClient login = new LoginAPIClient("LoginAPIServiceHttpEndpoint");

            // Create loginRequestDetails
            LoginRequestDetails loginRequestDetails = new LoginRequestDetails();
            loginRequestDetails.APIKey = "Arm7TJLjZmsxS3NZm3cxkltVhUFnjjyJImm4sG62P9KhUj0p0r6p9rYHXBwxoU1E";

            WSLoginResponse wSLoginResponse = login.AuthenticateAPIKey(loginRequestDetails);

            //process response
            if (!wSLoginResponse.Result)
            {
                //handle error
                // txtToken.Text = wSLoginResponse.Message;

                return "BadKey";
            }
            else
            {
                return wSLoginResponse.SecurityToken;
            }
        }

        public FormBULKSMSMessage()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(tempID < 0)
            {
                MessageBox.Show("*** You MUST select a template in order to send bulk messages! ***");
                return;
            }
            Int32 lnDayDue = 0;
            IACDataSet msgData = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();

            MessageClient messageResult = new MessageClient("MessageWSServiceHttpEndpoint");

            // Moses Newman 05/31/2019 remove from loop to prevent meory leaks.

            WSMessageResponse wSMessageResponse;

            string message = textBoxMessage.Text,lsPaidThru = txtPaidThrough.Text.Trim() + "%";

            Int32.TryParse(comboBoxDayDue.Text, out lnDayDue);
            // Moses Newman 05/11/2018 Add handling for contract date range selection
            // Moses Newman 12/30/2019 Add Funding Date Range
            if (nullableDateTimePickerContractFrom.Value == null && nullableDateTimePickerContractTo.Value == null && 
                nullableDateTimePickerFundingFrom.Value == null && nullableDateTimePickerFundingTo.Value == null)
                if (checkBoxGracePeriod.Checked)
                    CUSTOMERTableAdapter.FillByIsPassedGrace(msgData.CUSTOMER, lnDayDue, (DateTime)nullableDateTimePickerDebitDate.Value, checkBoxNoEFT.Checked, lsPaidThru);
                else
                    CUSTOMERTableAdapter.FillBySBTActiveDayDue(msgData.CUSTOMER, lnDayDue, checkBoxNoEFT.Checked, lsPaidThru);
            else
                if(nullableDateTimePickerContractFrom.Value != null)
                    CUSTOMERTableAdapter.FillByContractDates(msgData.CUSTOMER, ((DateTime)nullableDateTimePickerContractFrom.Value).Date,
                                                            ((DateTime)nullableDateTimePickerContractTo.Value).Date, checkBoxNoEFT.Checked);
                else
                    CUSTOMERTableAdapter.FillBySBTFundingDates(msgData.CUSTOMER, ((DateTime)nullableDateTimePickerFundingFrom.Value).Date,
                                                            ((DateTime)nullableDateTimePickerFundingTo.Value).Date, checkBoxNoEFT.Checked);

            string orgCode = "e83o045";  // Accounting Group 
            
            string note = textBoxNote.Text;

            if (msgData.CUSTOMER.Rows.Count > 0)
            {
                for (int i = 0; i < msgData.CUSTOMER.Rows.Count; i++)
                {


                    string statusUrl = "", lsTmpCust = "";
                    lsTmpCust = msgData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO");
                    //WSMessageResponse wSMessageResponse;
                    List<WSRecipient> recipients = new List<WSRecipient>();
                    List<CustomField> customFields = new List<CustomField>();
                    //Create custom fields             

                    CustomField customField = new CustomField();
                    customField.Key = "MISC$";
                    customField.Value = msgData.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT").ToString("C", new CultureInfo("en-US"));
                    customFields.Add(customField);

                    customField = new CustomField();
                    customField.Key = "MISC1";
                    customField.Value = Program.NextDueDate(i, msgData).ToString("d", new CultureInfo("en-US"));
                    customFields.Add(customField);

                    //Create recipients   
                    WSRecipient recipient = new WSRecipient();
                    recipient.SendTo = msgData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CELL_PHONE");
                    recipient.CustomFields = customFields.ToArray();
                    recipients.Add(recipient);
                    labelStatus.Text = "Creating comment for Account Number: " + msgData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + "\nRecord# " + (i + 1).ToString().Trim() + " of " + msgData.CUSTOMER.Rows.Count.ToString().Trim();
                    labelStatus.Refresh();
                    MakeComment(msgData, i, message, "", tempID, true);

                    if (msgData.CUSTOMER.Rows[i].Field<Boolean>("COSTConfirmed"))
                    {
                        //Add Cosigner   
                        recipient = new WSRecipient();
                        recipient.SendTo = msgData.CUSTOMER.Rows[i].Field<String>("COSIGNER_CELL_PHONE");
                        recipient.CustomFields = customFields.ToArray();
                        recipients.Add(recipient);
                        labelStatus.Text = "Creating comment for Account Number Cosigner: " + msgData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + "\nRecord# " + (i + 1).ToString().Trim() + " of " + msgData.CUSTOMER.Rows.Count.ToString().Trim();
                        labelStatus.Refresh();
                        MakeComment(msgData, i, message, "", tempID, true, true);
                    }

                    securityToken = sbtLogin();
                    if (tempID < 0)
                        wSMessageResponse = messageResult.SendMessage(securityToken, "IAC Inc: " + message, recipients.ToArray(), orgCode, note, statusUrl);
                    else
                        wSMessageResponse = messageResult.SendTemplateMessage(securityToken, tempID, recipients.ToArray(), orgCode, note, statusUrl);
                    //process response  
                    if (!wSMessageResponse.Result)
                    {
                        //handle error      
                        //MessageBox.Show(wSMessageResponse.Message);
                    }
                    else
                    {
                        _Message_Sent = message;
                        //MessageBox.Show("Message to CUSTOMERS where sent successfully!");
                        //this.Close();
                    }
                    _APIMessage = wSMessageResponse.Message;
                }
                MessageBox.Show("Messages to CUSTOMERS and COSIGNERS where sent successfully!");
            }
            else
                MessageBox.Show("No CUSTOMER found that match your selection criteria.  NO MESSAGES WILL BE SENT!");
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormTemplates newtemplateform = new FormTemplates();
            newtemplateform.securityToken = sbtLogin();
            newtemplateform.ShowDialog();
            this.textBoxMessage.Text = newtemplateform.TemplateText;
            this.tempID = newtemplateform.TempID;
            newtemplateform.Dispose();
            this.Show();
        }

        private void MakeComment(IACDataSet iACDataSet,Int32 custrow,String CommentMessage, String APIMessage, Int32 tnTemplateNo = 0, Boolean tbAddTextSent = true, Boolean tbCosginerTextSent = false)
        {
            IACDataSetTableAdapters.COMMENTTableAdapter cOMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();

            CommentMessage = CommentMessage.Replace("{MISC$}", iACDataSet.CUSTOMER.Rows[custrow].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT").ToString("C", new CultureInfo("en-US")));
            CommentMessage = CommentMessage.Replace("{MISC1}", Program.NextDueDate(custrow, iACDataSet).ToString("d", new CultureInfo("en-US")));
            Object oMissing = System.Reflection.Missing.Value,
                   oTrue = false,
                   oFalse = true,
                   loQuery = null,
                   start = 0,
                   end = 0, FileName = "";

            Int32 lnSeq = 0;
            String lsCommentKey = "",lsFullComment = "";

            Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word._Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
            oWord.Visible = false;

            oWordDoc = oWord.Documents.Add();
            Microsoft.Office.Interop.Word.Range rng = oWordDoc.Range(ref start, ref end);

            Object oTemplatePath = "";

            if (lnSeq == 0)
            {
                loQuery = cOMMENTTableAdapter.SeqNoQuery(iACDataSet.CUSTOMER.Rows[custrow].Field<String>("CUSTOMER_NO"), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;
            // Moses Newman 10/18/2017 create string unique key that will become word filename!
            lsCommentKey = iACDataSet.CUSTOMER.Rows[custrow].Field<String>("CUSTOMER_NO") + DateTime.Now.Date.ToString("yyyyMMdd") + lnSeq.ToString().Trim() + Program.gsUserID;
            // Moses Newman 11/21/2017 Remove hard coded UNC Pathing.
            FileName = Program.GsDataPath + @"CommentAttachments\SMS\" + lsCommentKey + ".docx";
            rng.Text = CommentMessage;
            rng.Select();
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
            oWordDoc.Saved = true;
            oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
            oWordDoc = null;
            oWord.Quit();
            oWord = null;
            WholeComment loTempComment;

            CommentMessage = (tbAddTextSent) ? (!tbCosginerTextSent ? "TEXT SENT: " : "COSIGNER TEXT SENT: ") + CommentMessage : CommentMessage;
            loTempComment = SplitComments(CommentMessage + " API MSG: " + APIMessage);
            // Moses Newman 02/22/2019 Add Full Comment
            lsFullComment = loTempComment.Field1 + loTempComment.Field2 + loTempComment.Field3;
            cOMMENTTableAdapter.Insert(iACDataSet.CUSTOMER.Rows[custrow].Field<String>("CUSTOMER_NO"),
                                        DateTime.Now.Date, lnSeq,
                                        Program.gsUserID,
                                        lsFullComment,
                                        //loTempComment.Field1,
                                        //loTempComment.Field2,
                                        //loTempComment.Field3,
                                        "",
                                        iACDataSet.CUSTOMER.Rows[custrow].Field<String>("CUSTOMER_DEALER"),
                                        Program.gsUserID + "  ",
                                        DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'),
                                        false, "", "",
                                        0, @"WordDoc.bmp", FileName.ToString(), tnTemplateNo);

            cOMMENTTableAdapter.FillByCustNo(iACDataSet.COMMENT, iACDataSet.CUSTOMER.Rows[custrow].Field<String>("CUSTOMER_NO"));
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

        // Moses Newman 12/30/2019 Handle Funding Date
        private void nullableDateTimePickerContractFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nullableDateTimePickerContractFrom.Value != null)
            {
                nullableDateTimePickerFundingFrom.Enabled = false;
                nullableDateTimePickerFundingFrom.Value = null;
                nullableDateTimePickerFundingTo.Enabled = false;
                nullableDateTimePickerFundingTo.Value = null;
            }
            else
                if (nullableDateTimePickerContractTo.Value == null)
                {
                    nullableDateTimePickerFundingFrom.Enabled = true;
                    nullableDateTimePickerFundingTo.Enabled = true;
                }
        }

        private void nullableDateTimePickerContractTo_ValueChanged(object sender, EventArgs e)
        {
            if (nullableDateTimePickerContractTo.Value != null)
            {
                nullableDateTimePickerFundingFrom.Enabled = false;
                nullableDateTimePickerFundingFrom.Value = null;
                nullableDateTimePickerFundingTo.Enabled = false;
                nullableDateTimePickerFundingTo.Value = null;
            }
            else
                if (nullableDateTimePickerContractFrom.Value == null)
                {
                    nullableDateTimePickerFundingFrom.Enabled = true;
                    nullableDateTimePickerFundingTo.Enabled = true;
                }
        }

        private void nullableDateTimePickerFundingFrom_ValueChanged(object sender, EventArgs e)
        {
            if (nullableDateTimePickerFundingFrom.Value != null)
            {
                nullableDateTimePickerContractFrom.Enabled = false;
                nullableDateTimePickerContractFrom.Value = null;
                nullableDateTimePickerContractTo.Enabled = false;
                nullableDateTimePickerContractTo.Value = null;
            }
            else
                if (nullableDateTimePickerFundingTo.Value == null)
                {
                    nullableDateTimePickerContractFrom.Enabled = true;
                    nullableDateTimePickerContractTo.Enabled = true;
                }
        }

        private void nullableDateTimePickerFundingTo_ValueChanged(object sender, EventArgs e)
        {
            if (nullableDateTimePickerFundingTo.Value != null)
            {
                nullableDateTimePickerContractFrom.Enabled = false;
                nullableDateTimePickerContractFrom.Value = null;
                nullableDateTimePickerContractTo.Enabled = false;
                nullableDateTimePickerContractTo.Value = null;
            }
            else
                if (nullableDateTimePickerFundingFrom.Value == null)
                {
                    nullableDateTimePickerContractFrom.Enabled = true;
                    nullableDateTimePickerContractTo.Enabled = true;
                }
        }

        private void checkBoxGracePeriod_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormBULKSMSMessage_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerContractFrom.Value = null;
            nullableDateTimePickerContractTo.Value = null;
            nullableDateTimePickerFundingFrom.Value = null;
            nullableDateTimePickerFundingTo.Value = null;
            nullableDateTimePickerDebitDate.Value = DateTime.Now.Date; // Moses Newman 09/10/2021
        }
    }
}

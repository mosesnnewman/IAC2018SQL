using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IAC2021SQL.GeneralWSProxy;
using IAC2021SQL.LoginWSProxy;using IAC2021SQL.SubscriberWSProxy;

using IAC2021SQL.MessageWSProxy;

namespace IAC2021SQL
{
    public partial class FormValidateCellPhones : Form
    {
        IACDataSet IACData = new IACDataSet();
        IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
        IACDataSetTableAdapters.COMMENTTableAdapter COMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();
        IACDataSetTableAdapters.EmailTableAdapter EmailTableAdapter = new IACDataSetTableAdapters.EmailTableAdapter();
        public FormValidateCellPhones()
        {
            InitializeComponent();
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

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            GroupClient generalService = new GroupClient("ReportWSServiceHttpEndpoint2");
            WSCarrierLookupResponse wSCarrierLookupResponse;
            string securityToken;
            string orgCode = "wt63419";




            // Moses Newman 06/01/2020 replace with SBTNonValid
            //CUSTOMERTableAdapter.FillByActiveDayDue(IACData.CUSTOMER, 0, false, true);
            CUSTOMERTableAdapter.FillBySBTNonValidDefi(IACData.CUSTOMER);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = IACData.CUSTOMER.Rows.Count;

            for (Int32 i = 0; i < IACData.CUSTOMER.Rows.Count; i++)
            {
                labelStatus.Text = "Working on customer " + IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + " " + i.ToString().TrimStart() + " of " + (IACData.CUSTOMER.Rows.Count - 1).ToString().TrimStart();
                labelStatus.Refresh();
                // Moses Newman 07/21/2020 Only Force Validate people who have not opted out
                string[] phone = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CELL_PHONE").Split(',');
                if (GetSubscriberStatus(phone[0]) != "Inactive" && phone[0] != "")
                {
                    securityToken = sbtLogin();

                    wSCarrierLookupResponse = generalService.GetCarrierLookup(securityToken, phone, orgCode);

                    if (!wSCarrierLookupResponse.Result)
                    {
                        MakeComment("*** Failed to VALIDATE cell phone number! ***", wSCarrierLookupResponse.Message, i);
                        IACData.CUSTOMER.Rows[i].SetField<Boolean>("CellValid", false);
                    }
                    else
                    {
                        if (wSCarrierLookupResponse.Result && !wSCarrierLookupResponse.Response[0].Landline)
                        {
                            string VBTError = "", gsVBTPin = "";
                            MessageClient messageResult = new MessageClient("MessageWSServiceHttpEndpoint");
                            securityToken = sbtLogin();
                            string phoneNo = phone[0];

                            WSVerificationResponse wSVerificationResponse = messageResult.RequestVBT(securityToken, orgCode, phoneNo);
                            if (!wSVerificationResponse.Result)
                            {
                                gsVBTPin = "";

                                VBTError = wSVerificationResponse.Message;
                                if (VBTError.TrimEnd() != "Subscriber information already exists")
                                {
                                    IACData.CUSTOMER.Rows[i].SetField<Boolean>("TAcct", false);
                                    MakeComment("*** VBT PIN NOT CREATED! ***", VBTError, i);
                                    MessageBox.Show(VBTError);
                                }
                            }
                            else
                            {
                                gsVBTPin = "AUTO";
                                IACData.CUSTOMER.Rows[i].SetField<Boolean>("DNTAcct", false);
                                IACData.CUSTOMER.Rows[i].SetField<Boolean>("TAcct", true);
                                MakeComment("VBT AUTO CREATED.", wSVerificationResponse.Message, i);
                            }

                            if (gsVBTPin == "AUTO")
                            {
                                SubscriberClient subscriberService = new SubscriberClient("SubscriberWSServiceHttpEndpoint");



                                SubscriberInfo subscriber = new SubscriberInfo();
                                SubscriberDetails subdetails = new SubscriberDetails();

                                subscriber.MobilePhone = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CELL_PHONE");

                                subscriber.FName = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_FIRST_NAME");
                                subscriber.LName = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_LAST_NAME");
                                EmailTableAdapter.Fill(IACData.Email, IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                                subscriber.Email = IACData.Email.Rows[0].Field<String>("EmailAddress");
                                subscriber.City = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CITY");
                                subscriber.Street = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_STREET_1");
                                subscriber.Street2 = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_STREET_2");
                                subscriber.ZipCode = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ZIP_1") + IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_ZIP_2");
                                subscriber.CustomField1 = "";
                                subscriber.CustomField2 = "";
                                subscriber.CustomField3 = "";
                                subscriber.PrivateCode = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PURCHASE_ORDER");
                                subscriber.UniqueID = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO");


                                securityToken = sbtLogin();
                                WSSubscriberResponse wSSubscriberResponse = subscriberService.UpdateSubscriber(securityToken, subscriber);

                                if (!wSSubscriberResponse.Result)
                                {
                                    MakeComment("*** SBT SUBSCRIBER FIELDS UPDATE FAILED! ***", wSSubscriberResponse.Message, i);
                                    MessageBox.Show(wSSubscriberResponse.Message);
                                }
                                else
                                {
                                    MakeComment("SBT SUBSCRIBER FIELDS UPDATED.", wSSubscriberResponse.Message, i);
                                }

                                MakeComment("Cell Phone Number VALIDATED. AUTO VBT", wSCarrierLookupResponse.Message, i);
                                IACData.CUSTOMER.Rows[i].SetField<Boolean>("CellValid", true);
                                IACData.CUSTOMER.Rows[i].SetField<Boolean>("DNTAcct", false);
                                IACData.CUSTOMER.Rows[i].SetField<Boolean>("TAcct", true);
                                IACData.CUSTOMER.Rows[i].SetField<Boolean>("TConfirmed", true);
                                IACData.CUSTOMER.Rows[i].SetField<String>("TPin", "AUTO");
                            }
                        }
                        else
                        {
                            MakeComment("*** Cell Phone Number will not VALIDATE because it is a LANDLINE! ***", wSCarrierLookupResponse.Message, i);
                            IACData.CUSTOMER.Rows[i].SetField<Boolean>("CellValid", false);
                        }
                    }
                    phone = IACData.CUSTOMER.Rows[i].Field<String>("COSIGNER_CELL_PHONE").Split(',');
                    if (GetSubscriberStatus(phone[0]) != "Inactive" && phone[0] != "")
                    {
                        securityToken = sbtLogin();

                        wSCarrierLookupResponse = generalService.GetCarrierLookup(securityToken, phone, orgCode);

                        if (!wSCarrierLookupResponse.Result)
                        {
                            MakeComment("*** Failed to VALIDATE COSINGER cell phone number! ***", wSCarrierLookupResponse.Message, i);
                            IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSCellValid", false);
                        }
                        else
                        {
                            if (wSCarrierLookupResponse.Result && !wSCarrierLookupResponse.Response[0].Landline)
                            {
                                string VBTError = "", gsVBTPin = "";
                                MessageClient messageResult = new MessageClient("MessageWSServiceHttpEndpoint");
                                securityToken = sbtLogin();
                                string phoneNo = phone[0];

                                WSVerificationResponse wSVerificationResponse = messageResult.RequestVBT(securityToken, orgCode, phoneNo);
                                if (!wSVerificationResponse.Result)
                                {
                                    gsVBTPin = "";

                                    VBTError = wSVerificationResponse.Message;
                                    if (VBTError.TrimEnd() != "Cosigner Subscriber information already exists")
                                    {
                                        IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSTAcct", false);
                                        MakeComment("*** COSIGNER VBT PIN NOT CREATED! ***", VBTError, i);
                                        MessageBox.Show(VBTError);
                                    }
                                }
                                else
                                {
                                    gsVBTPin = "AUTO";
                                    IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSDNTAcct", false);
                                    IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSTAcct", true);
                                    MakeComment("COSIGNER VBT AUTO CREATED.", wSVerificationResponse.Message, i);
                                }

                                if (gsVBTPin == "AUTO")
                                {
                                    SubscriberClient subscriberService = new SubscriberClient("SubscriberWSServiceHttpEndpoint");



                                    SubscriberInfo subscriber = new SubscriberInfo();
                                    SubscriberDetails subdetails = new SubscriberDetails();

                                    subscriber.MobilePhone = IACData.CUSTOMER.Rows[i].Field<String>("COSIGNER_CELL_PHONE");

                                    subscriber.FName = IACData.CUSTOMER.Rows[i].Field<String>("COSIGNER_FIRST_NAME");
                                    subscriber.LName = IACData.CUSTOMER.Rows[i].Field<String>("COSIGNER_LAST_NAME");
                                    subscriber.Email = IACData.CUSTOMER.Rows[i].Field<String>("CosignerEmail");
                                    subscriber.City = IACData.CUSTOMER.Rows[i].Field<String>("COSIGNER_CITY");
                                    subscriber.Street = IACData.CUSTOMER.Rows[i].Field<String>("COSIGNER_ADDRESS1");
                                    subscriber.Street2 = "";
                                    subscriber.ZipCode = IACData.CUSTOMER.Rows[i].Field<String>("COSIGNER_ZIP_CODE");
                                    subscriber.CustomField1 = "";
                                    subscriber.CustomField2 = "";
                                    subscriber.CustomField3 = "";
                                    subscriber.PrivateCode = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_PURCHASE_ORDER") + "COS";
                                    subscriber.UniqueID = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + "COS";


                                    securityToken = sbtLogin();
                                    WSSubscriberResponse wSSubscriberResponse = subscriberService.UpdateSubscriber(securityToken, subscriber);

                                    if (!wSSubscriberResponse.Result)
                                    {
                                        MakeComment("*** SBT COSIGNER SUBSCRIBER FIELDS UPDATE FAILED! ***", wSSubscriberResponse.Message, i);
                                        MessageBox.Show(wSSubscriberResponse.Message);
                                    }
                                    else
                                    {
                                        MakeComment("SBT COSIGNER SUBSCRIBER FIELDS UPDATED.", wSSubscriberResponse.Message, i);
                                    }

                                    MakeComment("Cosigner Cell Phone Number VALIDATED. AUTO VBT", wSCarrierLookupResponse.Message, i);
                                    IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSCellValid", true);
                                    IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSDNTAcct", false);
                                    IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSTAcct", true);
                                    IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSTConfirmed", true);
                                    IACData.CUSTOMER.Rows[i].SetField<String>("COSTPin", "AUTO");
                                }
                            }
                            else
                            {
                                MakeComment("*** Cosinger Cell Phone Number will not VALIDATE because it is a LANDLINE! ***", wSCarrierLookupResponse.Message, i);
                                IACData.CUSTOMER.Rows[i].SetField<Boolean>("COSCellValid", false);
                            }
                        }
                    }
                    CUSTOMERTableAdapter.Update(IACData.CUSTOMER.Rows[i]);
                    progressBar1.Value = i;
                }
            }
            MessageBox.Show("*** Completed cell phone validation! ***", "Validate Cell Phones", MessageBoxButtons.OK);
        }

        private void MakeComment(String CommentMessage, String APIMessage, int i)
        {
            Int32 lnSeq = 0;
            object loQuery = null;
            String lsFullComment = "";


            if (lnSeq == 0)
            {
                loQuery = COMMENTTableAdapter.SeqNoQuery(IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;

            // Moses Newman 02/22/2019 Add Full Comment
            lsFullComment = CommentMessage + " " + APIMessage;
            COMMENTTableAdapter.Insert(IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
                                        DateTime.Now.Date, lnSeq,
                                        Program.gsUserID,
                                        lsFullComment,
                                        //CommentMessage + " ",
                                        //APIMessage,
                                        //" ",
                                        "  ",
                                        IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_DEALER"),
                                        Program.gsUserID + "  ",
                                        DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'),
                                        false, "", @"", 0, "", "", 0);

        }

        private String GetSubscriberStatus(String mobileNumber)
        {
            SubscriberClient subscriberService = new SubscriberClient("SubscriberWSServiceHttpEndpoint");
            string securityToken = sbtLogin();
            string orgCode = "wt63419";
            List<string> phone = new List<string>();

            phone.Add(mobileNumber);
            WSSubscribersStatusResponse wSSubscribersStatusResponse;

            // Moses Newman 07/12/2019 catch EndpointNotFound errors.
            try
            {
                wSSubscribersStatusResponse = subscriberService.GetSubscribersStatus(securityToken, orgCode, phone.ToArray());
            }
            catch (System.ServiceModel.EndpointNotFoundException e)
            {
                return e.Message;
            }
            if (!wSSubscribersStatusResponse.Result)
            {
                return wSSubscribersStatusResponse.Message;
            }
            else
            {
                return wSSubscribersStatusResponse.Response[0].Status;
            }
        }
    }
}

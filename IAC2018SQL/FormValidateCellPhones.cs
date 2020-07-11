using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IAC2018SQL.GeneralWSProxy;
using IAC2018SQL.LoginWSProxy;
using IAC2018SQL.MessageWSProxy;
using IAC2018SQL.SubscriberWSProxy;

namespace IAC2018SQL
{
    public partial class FormValidateCellPhones : Form
    {
        IACDataSet IACData = new IACDataSet();
        IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
        IACDataSetTableAdapters.COMMENTTableAdapter COMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();
        public FormValidateCellPhones()
        {
            InitializeComponent();
        }

        private String sbtLogin()
        {
            LoginAPIClient login = new LoginAPIClient("LoginAPIServiceHttpEndpoint");

            // Create loginRequestDetails
            LoginRequestDetails loginRequestDetails = new LoginRequestDetails();
            loginRequestDetails.APIKey = "5sak6Ed9XvXUT7CqfsEwUBNttwOto81jRPsdqewa8UYKk3mJA8GfAyALmXhHJ81f";

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
            Int32 lnSeq = 0;
            object loQuery = null;
            GroupClient generalService = new GroupClient("ReportWSServiceHttpEndpoint2");
            WSCarrierLookupResponse wSCarrierLookupResponse;
            string securityToken = sbtLogin();
            string orgCode = "wt63419";
            



            // Moses Newman 06/01/2020 replace with SBTNonValid
            //CUSTOMERTableAdapter.FillByActiveDayDue(IACData.CUSTOMER, 0, false, true);
            CUSTOMERTableAdapter.FillBySBTNonValidDefi(IACData.CUSTOMER);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = IACData.CUSTOMER.Rows.Count;

            for (Int32 i = 0; i < IACData.CUSTOMER.Rows.Count; i++)
            {
                lnSeq = 0;
                loQuery = null;
                labelStatus.Text = "Working on customer " + IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + " " + i.ToString().TrimStart() + " of " + (IACData.CUSTOMER.Rows.Count -1).ToString().TrimStart();
                labelStatus.Refresh();

                string[] phone = IACData.CUSTOMER.Rows[i].Field<String>("CUSTOMER_CELL_PHONE").Split(',');

                wSCarrierLookupResponse = generalService.GetCarrierLookup(securityToken, phone, orgCode);

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
                if (!wSCarrierLookupResponse.Result)
                {
                    MakeComment("*** Failed to VALIDATE cell phone number! ***", wSCarrierLookupResponse.Message,i);
                    IACData.CUSTOMER.Rows[i].SetField<Boolean>("CellValid", false);
                }
                else
                {
                    if (wSCarrierLookupResponse.Result && !wSCarrierLookupResponse.Response[0].Landline)
                    {
                        MakeComment("Cell Phone Number VALIDATED.",wSCarrierLookupResponse.Message,i);
                        IACData.CUSTOMER.Rows[i].SetField<Boolean>("CellValid", true);
                    }
                    else
                    {
                        MakeComment("*** Cell Phone Number will not VALIDATE because it is a LANDLINE! ***", wSCarrierLookupResponse.Message,i);
                        IACData.CUSTOMER.Rows[i].SetField<Boolean>("CellValid", false);
                    }
                }
                CUSTOMERTableAdapter.Update(IACData.CUSTOMER.Rows[i]);
                progressBar1.Value = i;
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
    }
}

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
using IAC2018SQL.MessageWSProxy;

namespace IAC2018SQL
{
    public partial class FormSMSMessage : Form
    {
        private int tempID = -1;
        private String _Message_Sent = "NONE", _APIMessage = "";
        public String CellPhone { get; set; }
        public String securityToken { get;set; }
        public String CustomerNo {get;set;}
       
 
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


        public FormSMSMessage()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(textBoxMessage.Text == "")
            {
                MessageBox.Show("*** Message can NOT be blank! ***");
                _Message_Sent = "NONE";
            }
            IACDataSet msgData = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();

            MessageClient messageResult = new MessageClient("MessageWSServiceHttpEndpoint");
            
            string message = textBoxMessage.Text;

            CUSTOMERTableAdapter.Fill(msgData.CUSTOMER,CustomerNo);
            //Create custom fields             
            List<CustomField> customFields = new List<CustomField>();
            CustomField customField = new CustomField();
            customField.Key = "MISC$";
            customField.Value = msgData.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT").ToString("C", new CultureInfo("en-US"));
            customFields.Add(customField);

            customField = new CustomField();
            customField.Key = "MISC1";
            customField.Value = NextDueDate(0, msgData).ToString("d", new CultureInfo("en-US"));
            customFields.Add(customField);

            //Create recipients  
            List<WSRecipient> recipients = new List<WSRecipient>();
            WSRecipient recipient = new WSRecipient();
            recipient.SendTo = CellPhone;
            recipient.CustomFields = customFields.ToArray();
            recipients.Add(recipient);

            string orgCode = "e83o045";  // Accounting Group 


            string note = textBoxNote.Text;
            string statusUrl = "";

            WSMessageResponse wSMessageResponse;
            if(tempID < 0)
                wSMessageResponse = messageResult.SendMessage(securityToken, "IAC Inc: "+message, recipients.ToArray(), orgCode, note, statusUrl);
            else
                wSMessageResponse = messageResult.SendTemplateMessage(securityToken, tempID, recipients.ToArray(), orgCode, note, statusUrl);
            //process response  
            if (!wSMessageResponse.Result)
            {
                //handle error      
                MessageBox.Show(wSMessageResponse.Message);
                //txtResult.Text = Newtonsoft.Json.JsonConvert.SerializeObject(wSMessageResponse);
            }
            else
            {
                _Message_Sent = message;
                
                MessageBox.Show("Message to cell phone number:" + CellPhone + " was sent successfully!");
                this.Close();
            }
            _APIMessage = wSMessageResponse.Message;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormTemplates newtemplateform = new FormTemplates();
            newtemplateform.securityToken = securityToken;
            newtemplateform.ShowDialog();
            this.textBoxMessage.Text = newtemplateform.TemplateText;
            this.tempID = newtemplateform.TempID;
            newtemplateform.Dispose();
            this.Show();
        }

        private DateTime NextDueDate(int CustomerPos, IACDataSet Bank)
        {
            DateTime ldNewPaidThru;
            // Moses Newman 12/19/2013 CUSTOMER_PAID_THRU_MM and CUSTOMER_PAID_THRU_YY are now computed fields so no need to set!
            if (Bank.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && Convert.ToInt32(Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_MM")) == 2)
            {
                ldNewPaidThru = Convert.ToDateTime("03/1/" + DateTime.Now.Year.ToString().Substring(0, 2) + Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
                ldNewPaidThru = ldNewPaidThru.AddDays(-1); // Force Date to proper February Date!
            }
            else
                ldNewPaidThru = Convert.ToDateTime(Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_MM") + "/" + Bank.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE").ToString().TrimStart() + "/" + DateTime.Now.Year.ToString().Substring(0, 2) + Bank.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
            ldNewPaidThru = ldNewPaidThru.AddMonths(1);     // Add 1 to get next Due Date.
            return ldNewPaidThru;
        }
    }
}

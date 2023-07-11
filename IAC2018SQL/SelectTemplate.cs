using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IAC2021SQL.TemplateWSProxy;

namespace IAC2021SQL
{
    public partial class FormTemplates : DevExpress.XtraEditors.XtraForm
    {
        private WSTemplateListResponse wSTemplateResponse;
        private int tempID = -1;
        private String templateText = "";
        public String securityToken { get; set; }
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

        public String TemplateText
        {
            get
            {
                return this.templateText;
            }
            set
            {
                this.templateText = value;
            }
        }

        private static KeyValuePair<int, string>[] KvpSource;
        public FormTemplates()
        {
            InitializeComponent();
        }

        private void FormTemplates_Load(object sender, EventArgs e)
        {
            string orgCode = "e83o045";  // Accounting Group
            
            TemplateClient templateService = new TemplateClient("TemplateWSServiceHttpEndpoint");

            wSTemplateResponse = templateService.GetTemplates(securityToken, orgCode);
            if (!wSTemplateResponse.Result)
                return;

            KvpSource = new KeyValuePair<int, string>[wSTemplateResponse.Response.Length];
            Int32 i = 0;
            foreach (TemplateDetail Template in wSTemplateResponse.Response)
            {
                KvpSource[i++]=(new KeyValuePair<int, string>(Template.TemplateID, Template.Title));
            }
            comboBoxTemplates.Properties.ValueMember = "Key";
            comboBoxTemplates.Properties.DisplayMember = "Value";
            comboBoxTemplates.Properties.DataSource = KvpSource;
            comboBoxTemplates.Properties.ForceInitialize();
            comboBoxTemplates.Properties.PopulateColumns();
            comboBoxTemplates.Properties.Columns["Key"].Visible = true;
            comboBoxTemplates.ItemIndex = 0;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if(wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].TemplateID != 6)
                templateText = wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Text;
            else
                // Moses Newman 06/28/2018 Add Subject for welcome message.
                templateText = wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Subject + " " +
                               wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Text;
            tempID = wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].TemplateID;
            this.Close();
        }

        private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].TemplateID != 6)
                textBoxMessage.EditValue = wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Text;
            else
                // Moses Newman 06/28/2018 Add Subject for welcome message.
                textBoxMessage.EditValue = wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Subject + " " +
                               wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Text;
        }

        private void comboBoxTemplates_EditValueChanged(object sender, EventArgs e)
        {
            if (wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].TemplateID != 6)
                textBoxMessage.EditValue = wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Text;
            else
                // Moses Newman 06/28/2018 Add Subject for welcome message.
                textBoxMessage.EditValue = wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Subject + " " +
                               wSTemplateResponse.Response[comboBoxTemplates.ItemIndex].Text;
        }
    }
}

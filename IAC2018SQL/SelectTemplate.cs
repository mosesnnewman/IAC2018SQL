using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IAC2018SQL.TemplateWSProxy;

namespace IAC2018SQL
{
    public partial class FormTemplates : Form
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

            comboBoxTemplates.ValueMember = "Key";
            comboBoxTemplates.DisplayMember = "Value";

            foreach (TemplateDetail Template in wSTemplateResponse.Response)
            {
                comboBoxTemplates.Items.Add(new KeyValuePair<int, string>(Template.TemplateID, Template.Title));
            }
            comboBoxTemplates.SelectedIndex = 0;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if(wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].TemplateID != 6)
                templateText = wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].Text;
            else
                // Moses Newman 06/28/2018 Add Subject for welcome message.
                templateText = wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].Subject + " " +
                               wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].Text;
            tempID = wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].TemplateID;
            this.Close();
        }

        private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].TemplateID != 6)
                textBoxMessage.Text = wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].Text;
            else
                // Moses Newman 06/28/2018 Add Subject for welcome message.
                textBoxMessage.Text = wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].Subject + " " +
                               wSTemplateResponse.Response[comboBoxTemplates.SelectedIndex].Text;
        }
    }
}

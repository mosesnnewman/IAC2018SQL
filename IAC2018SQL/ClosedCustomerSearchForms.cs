using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IAC2021SQL;


namespace IAC2021SQL
{
    public partial class frmCustomerLookup : Form
    {
        private String _LookupType = "B"; 
        public String LookupFormType
        {
            get
            {
                return this._LookupType;
            }
            set
            {
                this._LookupType = value;
            }
        }

        public frmCustomerLookup()
        {
            this.Font = new Font(FontFamily.GenericSansSerif,
            8.25F, FontStyle.Regular);
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.CustomerMailTableAdapter CustomerMailTableAdapter = new IACDataSetTableAdapters.CustomerMailTableAdapter();

            String lcLastName = "%", lcFirstName = "%", lcContact = "%", lcStreet1 = "%", lcStreet2 = "%";
            String lcCity = "%", lcState = "%", lcZip1 = "%", lcZip2 = "%", lcHomePhone = "%", lcWorkPhone = "%";
            String lcCellPhone = "%", lcSS1 = "%", lcSS2 = "%", lcSS3 = "%";

            String lcCOSLastName = "%", lcCOSFirstName = "%", lcCOSStreet = "%", lcCOSCity = "%", lcCOSState = "%", lcCOSZip = "%";
            String lcCOSHomePhone = "%", lcCOSWorkPhone = "%", lcCOSWorkEXT = "%";
            String lcCOSCellPhone = "%", lcCOSSS1 = "%", lcCOSSS2 = "%", lcCOSSS3 = "%", lcPONum = "%", lsEmail = "%";

            DateTime? ldDOB = null, ldCOSDOB = null;


            iacDataSet1.CustomerMail.Clear();
            iacDataSet1.Customer_Vehicle.Clear();
            bindingNavigator1.BindingSource = CustomerbindingSource;


            if (cUSTOMER_LAST_NAMESrschTextBox.Text.ToString().TrimEnd().Length > 0)
                lcLastName = cUSTOMER_LAST_NAMESrschTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (cUSTOMER_FIRST_NAMESRCHTextBox.Text.ToString().TrimEnd().Length > 0)
                lcFirstName = cUSTOMER_FIRST_NAMESRCHTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (cUSTOMER_CONTACTSrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcContact = cUSTOMER_CONTACTSrchTextBox.ToString().TrimEnd().ToUpper() + "%";
            if (cUSTOMER_STREET_1SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcStreet1 = cUSTOMER_STREET_1SrchTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (cUSTOMER_STREET_2SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcStreet2 = cUSTOMER_STREET_2SrchTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (cUSTOMER_CITYSrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcCity = cUSTOMER_CITYSrchTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (cUSTOMER_STATESrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcState = cUSTOMER_STATESrchTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (cUSTOMER_ZIP_1SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcZip1 = cUSTOMER_ZIP_1SrchTextBox.Text.ToString().TrimEnd() + "%";
            if (cUSTOMER_ZIP_2SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcZip2 = cUSTOMER_ZIP_2SrchTextBox.Text.ToString().TrimEnd() + "%";
            if (NullableDateTimePickerSrchDOB.Value == null)
                ldDOB = null;
            else
                ldDOB = (DateTime)NullableDateTimePickerSrchDOB.Value;
            lcHomePhone = cUSTOMER__PHONE_NOSrchTextBox.Text.ToString();
            lcHomePhone = lcHomePhone.Substring(1, 3).Trim() + lcHomePhone.Substring(6, 3).Trim() + ((cUSTOMER__PHONE_NOSrchTextBox.Text.ToString().Length > 9) ? lcHomePhone.Substring(10).Trim() : "") + "%";
            lcWorkPhone = cUSTOMER_WORK_PHONESrchTextBox.Text.ToString();
            lcWorkPhone = lcWorkPhone.Substring(1, 3).Trim() + lcWorkPhone.Substring(6, 3).Trim() + ((cUSTOMER_WORK_PHONESrchTextBox.Text.ToString().Length > 9) ? lcWorkPhone.Substring(10).Trim() : "") + "%";
            lcCellPhone = cUSTOMER_CELL_PHONESrchTextBox.Text.ToString();
            lcCellPhone = lcCellPhone.Substring(1, 3).Trim() + lcCellPhone.Substring(6, 3).Trim() + ((cUSTOMER_CELL_PHONESrchTextBox.Text.ToString().Length > 9) ? lcCellPhone.Substring(10).Trim() : "") + "%";
            if (cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcSS1 = cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd() + "%";
            if (cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcSS2 = cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd() + "%";
            if (cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcSS3 = cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd() + "%";
            // Moses Newman 03/01/2012 Added Purchase Order Number
            if (cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().TrimEnd().Length > 0)
                lcPONum = cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().TrimEnd() + "%";
            // Cosigner information
            if (COSIGNER_LAST_NAMESrschTextBox.Text.ToString().TrimEnd().Length > 0)
                lcCOSLastName = COSIGNER_LAST_NAMESrschTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (COSIGNER_FIRST_NAMESRCHTextBox.Text.ToString().TrimEnd().Length > 0)
                lcCOSFirstName = COSIGNER_FIRST_NAMESRCHTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (COSIGNER_STREETSrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcCOSStreet = COSIGNER_STREETSrchTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (COSIGNER_CITYSrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcCOSCity = COSIGNER_CITYSrchTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (COSIGNER_STATESrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcCOSState = COSIGNER_STATESrchTextBox.Text.ToString().TrimEnd().ToUpper() + "%";
            if (COSIGNER_ZIPSrchTextBox.Text.ToString().TrimEnd().Length > 0)
                lcCOSZip = COSIGNER_ZIPSrchTextBox.Text.ToString().TrimEnd() + "%";
            lcCOSHomePhone = COSIGNER__PHONE_NOSrchTextBox.Text.ToString();
            lcCOSHomePhone = lcCOSHomePhone.Substring(1, 3).Trim() + lcCOSHomePhone.Substring(6, 3).Trim() + ((COSIGNER__PHONE_NOSrchTextBox.Text.ToString().Length > 9) ? lcCOSHomePhone.Substring(10).Trim() : "") + "%";
            lcCOSWorkPhone = COSIGNER_WORK_PHONESrchTextBox.Text.ToString();
            lcCOSWorkPhone = lcCOSWorkPhone.Substring(1, 3).Trim() + lcCOSWorkPhone.Substring(6, 3).Trim() + ((COSIGNER_WORK_PHONESrchTextBox.Text.ToString().Length > 9) ? lcCOSWorkPhone.Substring(10).Trim() : "") + "%";
            lcCOSCellPhone = COSIGNER_CELL_PHONESrchTextBox.Text.ToString();
            lcCOSCellPhone = lcCOSCellPhone.Substring(1, 3).Trim() + lcCOSCellPhone.Substring(6, 3).Trim() + ((COSIGNER_CELL_PHONESrchTextBox.Text.ToString().Length > 9) ? lcCOSCellPhone.Substring(10).Trim() : "") + "%";
            if (cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd().Length == 3 && cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd().Length == 2 && cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd().Length == 4)
            {
                lcSS1 = cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd();
                lcSS2 = cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd();
                lcSS3 = cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd();
            }
            else
            {
                if (COSIGNER_SS_1SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                    lcCOSSS1 = COSIGNER_SS_1SrchTextBox.Text.ToString().TrimEnd() + "%";
                if (COSIGNER_SS_2SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                    lcCOSSS2 = COSIGNER_SS_2SrchTextBox.Text.ToString().TrimEnd() + "%";
                if (COSIGNER_SS_3SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                    lcCOSSS3 = COSIGNER_SS_3SrchTextBox.Text.ToString().TrimEnd() + "%";
            }
            if (nullableDateTimePickerCOSDOB.Value == null)
                ldCOSDOB = null;
            else
                ldCOSDOB = (DateTime)nullableDateTimePickerCOSDOB.Value;

            //End of Cosigner Info

            if (richTextBoxEmailAddress.Text.TrimEnd().Length > 0)
                lsEmail = richTextBoxEmailAddress.Text.TrimEnd() + "%";

            iacDataSet1.EnforceConstraints = false;
            // Moses Newman 02/21/2018 finally removed legacy dynamic SQL passthrough and replaced with stored procedure
            CustomerMailTableAdapter.SearchFill(iacDataSet1.CustomerMail, lcLastName, lcFirstName, lcContact, lcStreet1, lcStreet2, lcCity, lcState,
                                                lcZip1, lcZip2, lcHomePhone, lcWorkPhone, lcCellPhone, lcSS1, lcSS2, lcSS3, lcPONum, ldDOB, lcCOSFirstName,
                                                lcCOSLastName, lcCOSStreet, lcCOSCity, lcCOSState, lcCOSZip, lcCOSHomePhone, lcCOSWorkPhone, lcCOSWorkEXT,
                                                lcCOSCellPhone, lcCOSSS1, lcCOSSS2, lcCOSSS3, ldCOSDOB, lsEmail, lsEmail, _LookupType);
            if (iacDataSet1.CustomerMail.Count > 0)
            {
                ActiveControl = dataGridViewCustLookup;
                dataGridViewCustLookup.Select();
            }
            else
                MessageBox.Show("Sorry no customers found that match your selected criteria!");
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string lsCustomer_Type = "";
            if (iacDataSet1.CustomerMail.Count > 0 && dataGridViewCustLookup.SelectedRows.Count > 0)
            {
                Program.gsKey = dataGridViewCustLookup.SelectedRows[0].Cells["cUSTOMERNODataGridViewTextBoxColumn"].Value.ToString().TrimEnd();
                switch (_LookupType)
                {
                    case "C":
                    case "O":
                        customerMailTableAdapter.Connection.Close();
                        Close();
                        break;
                    case "B":
                        lsCustomer_Type = dataGridViewCustLookup.SelectedRows[0].Cells["CustomerActType"].Value.ToString().TrimEnd();
                        MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                        if (lsCustomer_Type == "O")
                            MDImain.CreateFormInstance("frmOpenCustMaint", false);
                        else
                            MDImain.CreateFormInstance("frmNewCustMaint", false);
                        iacDataSet1.Clear();
                        ClearAllFields();
                        Refresh();
                        Show();
                        break;
                }
            }
        }

        private void ClearAllFields()
        {
            //textBoxCustomerNo.Text = "";
            //textBoxDealerNo.Text = "";
            cUSTOMER_LAST_NAMESrschTextBox.Text = "";
            cUSTOMER_FIRST_NAMESRCHTextBox.Text = "";
            cUSTOMER_FIRST_NAMESRCHTextBox.Text = "";
            cUSTOMER_CONTACTSrchTextBox.Text = "";
            cUSTOMER_STREET_1SrchTextBox.Text = "";
            cUSTOMER_STREET_2SrchTextBox.Text = "";
            cUSTOMER_STREET_2SrchTextBox.Text = "";
            cUSTOMER_CITYSrchTextBox.Text = "";
            cUSTOMER_STATESrchTextBox.Text = "";
            cUSTOMER_ZIP_1SrchTextBox.Text = "";
            cUSTOMER_ZIP_1SrchTextBox.Text = "";
            cUSTOMER_ZIP_2SrchTextBox.Text = "";
            cUSTOMER_ZIP_2SrchTextBox.Text = "";
            
            cUSTOMER_PURCHASE_ORDERTextBox.Text = "";
            cUSTOMER__PHONE_NOSrchTextBox.Text = "";
            cUSTOMER_WORK_PHONESrchTextBox.Text = "";
            cUSTOMER_CELL_PHONESrchTextBox.Text = "";
            cUSTOMER_SS_1SrchTextBox.Text = "";
            cUSTOMER_SS_1SrchTextBox.Text = "";
            cUSTOMER_SS_2SrchTextBox.Text = "";
            cUSTOMER_SS_3SrchTextBox.Text = "";
            
            txtVehicleYear.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtVIN.Text = "";
            txtInsuranceCompany.Text = "";
        }
        private void dataGridViewVehicleLookup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (iacDataSet1.Customer_Vehicle.Count > 0 && dataGridViewVehicleLookup.SelectedRows.Count > 0)
            {
                Program.gsKey = dataGridViewVehicleLookup.SelectedRows[0].Cells["vEHICLECUSTNODataGridViewTextBoxColumn"].Value.ToString().TrimEnd();
                switch (_LookupType)
                {
                    case "C":
                    case "O":
                        customerTableAdapter1.Connection.Close();
                        Close();
                        break;
                    case "B":
                        iacDataSet1.Clear();
                        ClearAllFields();
                        Refresh();
                        frmNewCustMaint newMDIChild2 = new frmNewCustMaint();
                        newMDIChild2.MdiParent = ParentForm;
                        newMDIChild2.Show();
                        Show();
                        break;
                }
            }
        }

        private void buttonVehicleSearch_Click(object sender, EventArgs e)
        {
            string lcVehicleYear = "%", lcMake = "%", lcModel = "%", lcVIN = "%", lcInsuranceCompany = "%";

            iacDataSet1.CUSTOMER.Clear();
            iacDataSet1.Customer_Vehicle.Clear();

            bindingNavigator1.BindingSource = Vehicle_CustomerbindingSource;
            // Moses Newman 11/12/2013 Since Vehicle table fields changed, it was a good time to remove dynamic query and go with stored procedure
            if (txtVehicleYear.Text.ToString().TrimEnd().Length > 0)
                lcVehicleYear = txtVehicleYear.Text.ToString().TrimEnd() + "%";
            if (txtMake.Text.ToString().TrimEnd().Length > 0)
                lcMake = txtMake.Text.ToString().TrimEnd().ToUpper() + "%";
            if (txtModel.Text.ToString().TrimEnd().Length > 0)
                lcModel = txtModel.Text.ToString().TrimEnd().ToUpper() + "%";
            if (txtVIN.Text.ToString().TrimEnd().Length > 0)
                lcVIN = txtVIN.Text.ToString().TrimEnd().ToUpper() + "%";
            if (txtInsuranceCompany.Text.ToString().TrimEnd().Length > 0)
                lcInsuranceCompany = txtInsuranceCompany.Text.ToString().TrimEnd().ToUpper() + "%";
            customer_VehicleTableAdapter.FillByVehicleSearch(iacDataSet1.Customer_Vehicle, lcVIN, lcVehicleYear, lcMake, lcModel, lcInsuranceCompany);
            if (iacDataSet1.Customer_Vehicle.Count > 0)
            {
                ActiveControl = dataGridViewVehicleLookup;
                dataGridViewVehicleLookup.Select();
            }
            else
                MessageBox.Show("Sorry no vehicles found that match your selected criteria!");

        }

        private void General_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void frmCustomerLookup_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            NullableDateTimePickerSrchDOB.Value = null;
            nullableDateTimePickerCOSDOB.Value = null;
            NullableDateTimePickerSrchDOB.Refresh();
            nullableDateTimePickerCOSDOB.Refresh();
            ActiveControl = cUSTOMER_SS_1SrchTextBox;
            cUSTOMER_SS_1SrchTextBox.Select();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ActiveControl = cUSTOMER_SS_1SrchTextBox;
                cUSTOMER_SS_1SrchTextBox.Select();
            }
            else
            {
                ActiveControl = txtVIN;
                txtVIN.Select();
            }
        }

        private void dataGridViewCustLookup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridViewCustLookup.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void dataGridViewVehicleLookup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridViewVehicleLookup.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void cUSTOMER_SS_1SrchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cUSTOMER_SS_1SrchTextBox.Text.Length == 3)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cUSTOMER_SS_2SrchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cUSTOMER_SS_2SrchTextBox.Text.Length == 2)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cUSTOMER_SS_3SrchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (cUSTOMER_SS_3SrchTextBox.Text.Length == 4)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Data.CONNX;
using IAC2018SQL;


namespace IAC2018SQL
{
    public partial class frmGeneralCustomerLookup : Form
    {

        public frmGeneralCustomerLookup()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string lcQuery = "", lcCustomerNo = "%", lcDealerNo = "%", lcLastName = "%", lcFirstName = "%", lcContact = "%", lcStreet1 = "%", lcStreet2 = "%";
            string lcCity = "%", lcState = "%", lcZip1 = "%", lcZip2 = "%", lcDOB = "%", lcHomePhone = "%", lcWorkPhone = "%";
            string lcCellPhone = "%", lcSS1 = "%", lcSS2 = "%", lcSS3 = "%", lcDOBYY, lcDOBMM, lcDOBDD, lcPONum = "%"; // Moses Newman 03/01/2011 added PONumber
            int lnDOB = 0;

            iacDataSet1.OPNCLSCUSTOMER.Clear();
            iacDataSet1.Customer_Vehicle.Clear();

            bindingNavigator1.BindingSource = CustomerbindingSource;


            if (cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd().Length == 3 && cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd().Length == 2 && cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd().Length == 4)
            {
                lcSS1 = cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd();
                lcSS2 = cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd();
                lcQuery = @"SELECT CUSTOMER_NO, CUSTOMER_IAC_TYPE, CUSTOMER_ACT_STAT, CUSTOMER_FIRST_NAME, CUSTOMER_LAST_NAME, CUSTOMER_CONTACT, CUSTOMER_STREET_1, CUSTOMER_STREET_2, CUSTOMER_CITY, CUSTOMER_STATE, CUSTOMER_ZIP_1, CUSTOMER_ZIP_2, CUSTOMER_SS_1, CUSTOMER_SS_2, CUSTOMER_SS_3, CUSTOMER_DEALER, CUSTOMER_SUFFIX, CUSTOMER_REGULAR_AMOUNT,Email.*,CosignerEmail FROM CUSTOMER,Email WHERE Email.CustomerNo = CUSTOMER_NO AND CUSTOMER_SS_1 = \'" + cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd() + @"' AND CUSTOMER_SS_2 = '" + cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd() + @"' AND CUSTOMER_SS_3 = '" + cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd() + @"'";
                lcQuery += @" UNION SELECT CUSTOMER_NO, CUSTOMER_IAC_TYPE, CUSTOMER_ACT_STAT, CUSTOMER_FIRST_NAME, CUSTOMER_LAST_NAME, CUSTOMER_CONTACT,CUSTOMER_STREET_1, CUSTOMER_STREET_2, CUSTOMER_CITY, CUSTOMER_STATE, CUSTOMER_ZIP_1, CUSTOMER_ZIP_2, CUSTOMER_SS_1, CUSTOMER_SS_2, CUSTOMER_SS_3, CUSTOMER_DEALER, CUSTOMER_SUFFIX, CUSTOMER_REGULAR_AMOUNT,CUSTOMER_NO CustomerNo,1 EmailNumber,'' EmailAddress,'' TestAddress,'' CosingerEmail FROM OPNCUST";
                lcQuery += @" WHERE CUSTOMER_SS_1 = '" + cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd() + @"' AND CUSTOMER_SS_2 = '" + cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd() + @"' AND CUSTOMER_SS_3 = '" + cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd() + @"'";
                if (textBoxCustomerNo.Text.TrimEnd().TrimStart().Length > 0)
                {
                    lcCustomerNo = textBoxCustomerNo.Text.TrimEnd().TrimStart();
                    if (checkBoxCustPad.Checked)
                        if (lcCustomerNo.Length < 6)
                            lcCustomerNo = lcCustomerNo.PadLeft(6, '0'); ;
                    lcCustomerNo += "%";

                }
                if (textBoxDealerNo.Text.TrimEnd().TrimStart().Length > 0)
                {
                    lcDealerNo = textBoxDealerNo.Text.TrimEnd().TrimStart();
                    if (checkBoxDealerPad.Checked)
                        if (lcDealerNo.Length < 3)
                            lcDealerNo = lcDealerNo.PadLeft(3, '0'); ;
                    lcDealerNo += "%";
                }
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
                if (txtSrchDOB.Text.ToString().TrimEnd().Length > 0)
                    lcDOB = txtSrchDOB.Text.ToString().TrimEnd() + "%";
                // Moses Newman 03/01/2012 Added Purchase Order Number lookup
                if (cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().TrimEnd().Length > 0)
                    lcPONum = cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().TrimEnd() + "%";
                lcHomePhone = cUSTOMER__PHONE_NOSrchTextBox.Text.ToString();
                lcHomePhone = lcHomePhone.Substring(1, 3).Trim() + lcHomePhone.Substring(6, 3).Trim() + ((cUSTOMER__PHONE_NOSrchTextBox.Text.ToString().Length > 9) ? lcHomePhone.Substring(10).Trim() : "") + "%";
                lcWorkPhone = cUSTOMER_WORK_PHONESrchTextBox.Text.ToString();
                lcWorkPhone = lcWorkPhone.Substring(1, 3).Trim() + lcWorkPhone.Substring(6, 3).Trim() + ((cUSTOMER_WORK_PHONESrchTextBox.Text.ToString().Length > 9) ? lcWorkPhone.Substring(10).Trim() : "") + "%";
                lcCellPhone = cUSTOMER_CELL_PHONESrchTextBox.Text.ToString();
                lcCellPhone = lcCellPhone.Substring(1, 3).Trim() + lcCellPhone.Substring(6, 3).Trim() + ((cUSTOMER_CELL_PHONESrchTextBox.Text.ToString().Length > 9) ? lcCellPhone.Substring(10).Trim() : "") + "%";
                if (cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd().Length == 3 && cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd().Length == 2 && cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd().Length == 4)
                {
                    lcSS1 = cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd();
                    lcSS2 = cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd();
                    lcSS3 = cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd();
                }
                else
                {
                    if (cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                        lcSS1 = cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd() + "%";
                    if (cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                        lcSS2 = cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd() + "%";
                    if (cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                        lcSS3 = cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd() + "%";
                }
                if (txtSrchDOB.Text.ToString().TrimStart().TrimEnd().Length > 5)
                {
                    lcDOBMM = txtSrchDOB.Text.ToString().Substring(0, 2);
                    if (lcDOBMM.Substring(0, 1) == "0")
                        lcDOBMM = lcDOBMM.Substring(1, 1);
                    lcDOBDD = txtSrchDOB.Text.ToString().Substring(3, 2);
                    lcDOBYY = txtSrchDOB.Text.ToString().Substring(6, 4);
                    lcDOB = lcDOBMM + lcDOBDD + lcDOBYY;
                    lnDOB = Convert.ToInt32(lcDOB);
                    if (lcDOB.Length < 7)
                        lnDOB = 0;
                }

                lcQuery = @"SELECT CUSTOMER_NO, CUSTOMER_IAC_TYPE, CUSTOMER_ACT_STAT, CUSTOMER_FIRST_NAME, CUSTOMER_LAST_NAME, CUSTOMER_STREET_1, CUSTOMER_CITY, CUSTOMER_STATE, CUSTOMER_SS_1,CUSTOMER_SS_2,CUSTOMER_SS_3,CUSTOMER_DEALER FROM CUSTOMER WHERE CUSTOMER_LAST_NAME LIKE '" + lcLastName + @"'";
                lcQuery += @" AND CUSTOMER_NO LIKE '" + lcCustomerNo + @"'";
                lcQuery += @" AND CUSTOMER_DEALER LIKE '" + lcDealerNo + @"'";
                lcQuery += @" AND CUSTOMER_FIRST_NAME LIKE '" + lcFirstName + @"'";
                lcQuery += @" AND CUSTOMER_CONTACT LIKE '" + lcContact + @"'";
                lcQuery += @" AND CUSTOMER_STREET_1 LIKE '" + lcStreet1 + @"'";
                lcQuery += @" AND CUSTOMER_STREET_2 LIKE '" + lcStreet2 + @"'";
                lcQuery += @" AND CUSTOMER_CITY LIKE '" + lcCity + @"'";
                lcQuery += @" AND CUSTOMER_STATE LIKE '" + lcState + @"'";
                lcQuery += @" AND CUSTOMER_ZIP_1 LIKE '" + lcZip1 + @"'";
                lcQuery += @" AND CUSTOMER_ZIP_2 LIKE '" + lcZip2 + @"'";
                lcQuery += @" AND CUSTOMER_PHONE_NO LIKE '" + lcHomePhone + @"'";
                lcQuery += @" AND CUSTOMER_WORK_PHONE LIKE '" + lcWorkPhone + @"'";
                lcQuery += @" AND CUSTOMER_CELL_PHONE LIKE '" + lcCellPhone + @"'";
                lcQuery += @" AND CUSTOMER_SS_1 LIKE '" + lcSS1 + @"'";
                lcQuery += @" AND CUSTOMER_SS_2 LIKE '" + lcSS2 + @"'";
                lcQuery += @" AND CUSTOMER_SS_3 LIKE '" + lcSS3 + @"'";
                // Moses Newman 03/01/2012 Added Purchase Order Number
                lcQuery += @" AND CUSTOMER_PURCHASE_ORDER LIKE '" + lcPONum + @"'";
                if (lnDOB != 0)
                    lcQuery += " AND CUSTOMER_DOB = " + lcDOB;


                lcQuery += @" UNION SELECT CUSTOMER_NO, CUSTOMER_IAC_TYPE, CUSTOMER_ACT_STAT, CUSTOMER_FIRST_NAME, CUSTOMER_LAST_NAME, CUSTOMER_STREET_1, CUSTOMER_CITY, CUSTOMER_STATE, CUSTOMER_SS_1,CUSTOMER_SS_2,CUSTOMER_SS_3,CUSTOMER_DEALER FROM OPNCUST WHERE CUSTOMER_LAST_NAME LIKE '" + lcLastName + @"'";
                lcQuery += @" AND CUSTOMER_NO LIKE '" + lcCustomerNo + @"'";
                lcQuery += @" AND CUSTOMER_DEALER LIKE '" + lcDealerNo + @"'";
                lcQuery += @" AND CUSTOMER_FIRST_NAME LIKE '" + lcFirstName + @"'";
                lcQuery += @" AND CUSTOMER_CONTACT LIKE '" + lcContact + @"'";
                lcQuery += @" AND CUSTOMER_STREET_1 LIKE '" + lcStreet1 + @"'";
                lcQuery += @" AND CUSTOMER_STREET_2 LIKE '" + lcStreet2 + @"'";
                lcQuery += @" AND CUSTOMER_CITY LIKE '" + lcCity + @"'";
                lcQuery += @" AND CUSTOMER_STATE LIKE '" + lcState + @"'";
                lcQuery += @" AND CUSTOMER_ZIP_1 LIKE '" + lcZip1 + @"'";
                lcQuery += @" AND CUSTOMER_ZIP_2 LIKE '" + lcZip2 + @"'";
                lcQuery += @" AND CUSTOMER_PHONE_NO LIKE '" + lcHomePhone + @"'";
                lcQuery += @" AND CUSTOMER_WORK_PHONE LIKE '" + lcWorkPhone + @"'";
                lcQuery += @" AND CUSTOMER_CELL_PHONE LIKE '" + lcCellPhone + @"'";
                lcQuery += @" AND CUSTOMER_SS_1 LIKE '" + lcSS1 + @"'";
                lcQuery += @" AND CUSTOMER_SS_2 LIKE '" + lcSS2 + @"'";
                lcQuery += @" AND CUSTOMER_SS_3 LIKE '" + lcSS3 + @"'";
                // Moses Newman 03/01/2012 Added Purchase Order Number
                lcQuery += @" AND CUSTOMER_PURCHASE_ORDER LIKE '" + lcPONum + @"'";
                if (lnDOB != 0)
                    lcQuery += " AND CUSTOMER_DOB = " + lcDOB;
            }
            iacDataSet1.EnforceConstraints = false; 
            oPNCLSCUSTOMERTableAdapter.CustomizeFill(lcQuery);
            oPNCLSCUSTOMERTableAdapter.CustomFillBy(iacDataSet1.OPNCLSCUSTOMER);
            if (iacDataSet1.OPNCLSCUSTOMER.Count > 0)
            {
                ActiveControl = dataGridViewCustLookup;
                dataGridViewCustLookup.Select();
            }
            else
                MessageBox.Show("Sorry no customers found that match your selected criteria!");
        }

        private void dataGridViewVehicleLookup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (iacDataSet1.Customer_Vehicle.Count > 0 && dataGridViewVehicleLookup.SelectedRows.Count > 0)
            {
                Program.gsKey = dataGridViewVehicleLookup.SelectedRows[0].Cells["vEHICLECUSTNODataGridViewTextBoxColumn"].Value.ToString().TrimEnd();
                // Moses Newman 11/27/2012 Why not keep deep search open until user wants to close it!
                //Close();
                iacDataSet1.Clear();
                ClearAllFields();
                Refresh();
                frmCustMaint newMDIChild2 = new frmCustMaint();
                newMDIChild2.MdiParent = ParentForm;
                newMDIChild2.Show();
                Show();
            }
        }

        private void buttonVehicleSearch_Click(object sender, EventArgs e)
        {
            string lcVehicleYear = "%", lcMake = "%", lcModel = "%", lcVIN = "%", lcInsuranceCompany = "%";

            iacDataSet1.OPNCLSCUSTOMER.Clear();
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
            ActiveControl = textBoxCustomerNo;
            textBoxCustomerNo.Select();
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

        private void dataGridViewCustLookup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string lsCustomer_Type = "";

            if (iacDataSet1.OPNCLSCUSTOMER.Count > 0 && dataGridViewCustLookup.SelectedRows.Count > 0)
            {
                Program.gsKey = dataGridViewCustLookup.SelectedRows[0].Cells["cUSTOMERNODataGridViewTextBoxColumn"].Value.ToString().TrimEnd();
                lsCustomer_Type = dataGridViewCustLookup.SelectedRows[0].Cells["cUSTOMERIACTYPEDataGridViewTextBoxColumn"].Value.ToString().TrimEnd();
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                if (lsCustomer_Type == "O")
                    MDImain.CreateFormInstance("frmOpenCustMaint", false);
                else
                    MDImain.CreateFormInstance("frmCustMaint", false);
            }
            // Moses Newman 11/27/2012 Why not keep deep search open until user wants to exit it!
            //Close();
            iacDataSet1.Clear();
            ClearAllFields();
            Refresh();
            Show();
        }

        private void ClearAllFields()
        {
            textBoxCustomerNo.Text = "";
            textBoxDealerNo.Text = "";
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
            txtSrchDOB.Text = "";
            cUSTOMER_PURCHASE_ORDERTextBox.Text = "";
            cUSTOMER__PHONE_NOSrchTextBox.Text = "";
            cUSTOMER_WORK_PHONESrchTextBox.Text = "";
            cUSTOMER_CELL_PHONESrchTextBox.Text = "";
            cUSTOMER_SS_1SrchTextBox.Text = "";
            cUSTOMER_SS_1SrchTextBox.Text = "";
            cUSTOMER_SS_2SrchTextBox.Text = "";
            cUSTOMER_SS_3SrchTextBox.Text = "";
            txtSrchDOB.Text = "";
            txtVehicleYear.Text = "";
            txtMake.Text = "";
            txtModel.Text = "";
            txtVIN.Text = "";
            txtInsuranceCompany.Text = "";
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

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
    public partial class frmOpenCustomerLookup : Form
    {

        public frmOpenCustomerLookup()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string lcQuery = "",lcLastName = "%",lcFirstName = "%",lcContact = "%",lcStreet1 = "%",lcStreet2 = "%";
            string lcCity = "%",lcState = "%",lcZip1 = "%",lcZip2 = "%",lcDOB = "%",lcHomePhone = "%",lcWorkPhone = "%";
            string lcCellPhone = "%",lcSS1 = "%",lcSS2 = "%",lcSS3 = "%",lcDOBYY, lcDOBMM, lcDOBDD,lcPONum = "%";  // Moses Newman 03/01/2012 Added PO Number
            int lnDOB = 0;

            iacDataSet1.OPNCUST.Clear();
            if (cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd().Length == 3 && cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd().Length == 2 && cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd().Length == 4)
            {
                lcQuery = "SELECT * FROM OPNCUST WHERE CUSTOMER_SS_1 = \'" + cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd() + "\' AND CUSTOMER_SS_2 = \'" + cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd() + "\' AND CUSTOMER_SS_3 = \'" + cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd() + "\'";
            }
            else
            {
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
                lcHomePhone = cUSTOMER__PHONE_NOSrchTextBox.Text.ToString();
                lcHomePhone = lcHomePhone.Substring(1, 3).Trim() + lcHomePhone.Substring(6, 3).Trim() + ((cUSTOMER__PHONE_NOSrchTextBox.Text.ToString().Length > 9)  ? lcHomePhone.Substring(10).Trim():"")+"%";
                lcWorkPhone = cUSTOMER_WORK_PHONESrchTextBox.Text.ToString();
                lcWorkPhone = lcWorkPhone.Substring(1, 3).Trim() + lcWorkPhone.Substring(6, 3).Trim() + ((cUSTOMER_WORK_PHONESrchTextBox.Text.ToString().Length > 9) ? lcWorkPhone.Substring(10).Trim():"")+"%";
                lcCellPhone = cUSTOMER_CELL_PHONESrchTextBox.Text.ToString();
                lcCellPhone = lcCellPhone.Substring(1, 3).Trim() + lcCellPhone.Substring(6, 3).Trim() + ((cUSTOMER_CELL_PHONESrchTextBox.Text.ToString().Length > 9) ? lcCellPhone.Substring(10).Trim():"")+"%";
                if (cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                    lcSS1 = cUSTOMER_SS_1SrchTextBox.Text.ToString().TrimEnd() + "%";
                if (cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                    lcSS2 = cUSTOMER_SS_2SrchTextBox.Text.ToString().TrimEnd() + "%";
                if (cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd().Length > 0)
                    lcSS3 = cUSTOMER_SS_3SrchTextBox.Text.ToString().TrimEnd() + "%";
                if (cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().TrimEnd().Length > 0)
                    lcPONum = cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().TrimEnd() + "%";

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

                lcQuery = "SELECT * FROM OPNCUST WHERE CUSTOMER_LAST_NAME LIKE \'" + lcLastName + "\'";
                lcQuery += " AND CUSTOMER_FIRST_NAME LIKE \'" + lcFirstName + "\'";
                lcQuery += " AND CUSTOMER_CONTACT LIKE \'" + lcContact + "\'";
                lcQuery += " AND CUSTOMER_STREET_1 LIKE \'" + lcStreet1 + "\'";
                lcQuery += " AND CUSTOMER_STREET_2 LIKE \'" + lcStreet2 + "\'";
                lcQuery += " AND CUSTOMER_CITY LIKE \'" + lcCity + "\'";
                lcQuery += " AND CUSTOMER_STATE LIKE \'" + lcState + "\'";
                lcQuery += " AND CUSTOMER_ZIP_1 LIKE \'" + lcZip1 + "\'";
                lcQuery += " AND CUSTOMER_ZIP_2 LIKE \'" + lcZip2 + "\'";
                lcQuery += " AND CUSTOMER_PHONE_NO LIKE \'" + lcHomePhone + "\'";
                lcQuery += " AND CUSTOMER_WORK_PHONE LIKE \'" + lcWorkPhone + "\'";
                lcQuery += " AND CUSTOMER_CELL_PHONE LIKE \'" + lcCellPhone + "\'";
                lcQuery += " AND CUSTOMER_SS_1 LIKE \'" + lcSS1 + "\'";
                lcQuery += " AND CUSTOMER_SS_2 LIKE \'" + lcSS2 + "\'";
                lcQuery += " AND CUSTOMER_SS_3 LIKE \'" + lcSS3 + "\'";
                // Moses Newman 03/01/2012 Added Purchase Order Number
                lcQuery += @" AND CUSTOMER_PURCHASE_ORDER LIKE '" + lcPONum + @"'";
                if (lnDOB != 0)
                    lcQuery += " AND CUSTOMER_DOB = " + lcDOB;
            }
            oPNCUSTTableAdapter.CustomizeFill(lcQuery);
            oPNCUSTTableAdapter.CustomFillBy(iacDataSet1.OPNCUST);
            if (iacDataSet1.OPNCUST.Count > 0)
            {
                ActiveControl = dataGridViewCustLookup;
                dataGridViewCustLookup.Select();
            }
            else
                MessageBox.Show("Sorry no customers found that match your selected criteria!");    
            // Not using CONNX classes directly anymore
            //CONNX.RunQuery(lcQuery, iacDataSet1.CUSTOMER);
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (iacDataSet1.OPNCUST.Count > 0 && dataGridViewCustLookup.SelectedRows.Count > 0)
            {
                Program.gsKey = dataGridViewCustLookup.SelectedRows[0].Cells["cUSTOMERNODataGridViewTextBoxColumn"].Value.ToString().TrimEnd();
                Close();
            }
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
            ActiveControl = cUSTOMER_SS_1SrchTextBox;
            cUSTOMER_SS_1SrchTextBox.Select();
        }


        private void dataGridViewCustLookup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridViewCustLookup.Rows)
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

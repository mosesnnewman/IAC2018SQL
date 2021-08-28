using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class formOpenLoanBalanceAddOn : Form
    {
        System.Windows.Forms.Label labelOverPayment, lblIncome,lblPaidThrough;

        private Boolean lbNewAddOn = false;

        public formOpenLoanBalanceAddOn()
        {
            InitializeComponent();
        }

        private void formOpenLoanBalanceAddOn_Load(object sender, EventArgs e)
        {
            addOnTypeTableAdapter.Fill(AddOnDataSet.AddOnType);

            if (!Modal && !Program.gbOpenPaymentJustSaved && !Program.gbOpenPaymentAdd)
            {
                Program.gsKey = null;
                Program.gbOpenPaymentEdit = false;
                Program.gbOpenPaymentAdd = false;
                Program.goOpenPaymentKeys = null;
            }

            TextAddOnDate.Value = DateTime.Today;

            if (Modal)
            {
                if (Program.gbOpenPaymentEdit)
                    Text = "Open Loan Balance Add On (EDIT Mode)";
                else
                    Text = "Open Loan Balance Add On (ADD Mode)";
                cUSTOMER_NOTextBox.Text = (Program.goOpenPaymentKeys != null) ? Program.goOpenPaymentKeys[0].ToString() : "";
                Program.gsKey = null;
                cUSTOMER_NOTextBox.Enabled = false;
            }
            else
                Text = "Open Loan Balance Add On (VIEW Mode)";             
            labelOverPayment = new Label();
            labelOverPayment.AutoSize = true;
            labelOverPayment.Location = new System.Drawing.Point(288, 52);
            labelOverPayment.Name = "labelOverPayment";
            labelOverPayment.Size = new System.Drawing.Size(95, 13);
            labelOverPayment.TabIndex = 150;
            labelOverPayment.Text = "OVER PAYMENT:";
            labelOverPayment.Visible = false;
            labelOverPayment.Enabled = true;
            groupBox2.Controls.Add(labelOverPayment);

            // 
            // lblIncome
            // 
            lblIncome = new Label();
            lblIncome.AutoSize = true;
            lblIncome.Location = new System.Drawing.Point(331, 78);
            lblIncome.Name = "lblIncome";
            lblIncome.Size = new System.Drawing.Size(52, 13);
            lblIncome.TabIndex = 152;
            lblIncome.Text = "INCOME:";
            lblIncome.Visible = false;
            lblIncome.Enabled = true;
            groupBox2.Controls.Add(lblIncome);

            // 
            // lblPaidThrough
            // 
            lblPaidThrough = new Label();
            lblPaidThrough.AutoSize = true;
            lblPaidThrough.Location = new System.Drawing.Point(383, 156);
            lblPaidThrough.Name = "lblPaidThrough";
            lblPaidThrough.Size = new System.Drawing.Size(157, 13);
            lblPaidThrough.TabIndex = 150;
            lblPaidThrough.Text = "UPDATE PAID THROUGH BY:";
            lblPaidThrough.Visible = false;
            lblPaidThrough.Enabled = true;
            groupBox2.Controls.Add(lblPaidThrough);

            toolStripButtonDelete.Enabled = true;
            toolStripButtonSave.Enabled = false;

            DefaultSettings();
            PerformAutoScale();
        }

        private void DefaultSettings()
        {
            if (!Modal && !Program.gbOpenPaymentAdd)
            {
                toolStripButtonDelete.Enabled = true;
                txtCheckValue.ReadOnly = true;
                AddOnTypetextBox.ReadOnly = false;
                AddOntyeDescriptioncomboBox.Enabled = true;
                toolStripButtonCancel.Visible = false;
                toolStripButtonCancel.Enabled = false;
                setRelatedData();
            }
            else
            {
                txtCheckValue.ReadOnly = false;
                AddOnTypetextBox.ReadOnly = false;
                AddOntyeDescriptioncomboBox.Enabled = true;
            }
            if (Program.gbOpenPaymentEdit)
            {
                toolStripButtonDelete.Enabled = false;
                Program.gbOpenPaymentAdd = false;
                setRelatedData();
                toolStripButtonCancel.Visible = false;
                toolStripButtonCancel.Enabled = false;
                ActiveControl = txtCheckValue;
                txtCheckValue.SelectAll();
            }
            if (Program.gbOpenPaymentAdd)
            {
                toolStripButtonDelete.Enabled = false;
                Program.gbOpenPaymentEdit = false;
                setRelatedData();
                toolStripButtonCancel.Visible = true;
                toolStripButtonCancel.Enabled = true;
                ActiveControl = cUSTOMER_NOTextBox;
                cUSTOMER_NOTextBox.SelectAll();
            }

            if (!Modal && !Program.gbOpenPaymentAdd)
            {
                ActiveControl = cUSTOMER_NOTextBox;
                cUSTOMER_NOTextBox.Select();
            }
        }

        private void General_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            else
            {
                if (ActiveControl == cUSTOMER_NOTextBox)
                    return;
                toolStripButtonSave.Enabled = true;
            }
        }

        private void setRelatedData()
        {
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNUPDATTableAdapter OPNUPDATTableAdapter = new IACDataSetTableAdapters.OPNUPDATTableAdapter();

            OPNCUSTTableAdapter.Fill(AddOnDataSet.OPNCUST, cUSTOMER_NOTextBox.Text);
            if(AddOnDataSet.OPNCUST.Rows.Count == 0)
                return;
            OPNDEALRTableAdapter.Fill(AddOnDataSet.OPNDEALR, cUSTOMER_NOTextBox.Text);
            OPNUPDATTableAdapter.Fill(AddOnDataSet.OPNUPDAT, cUSTOMER_NOTextBox.Text);
            if (AddOnDataSet.OPNUPDAT.Rows.Count == 0)
            {
                AddOnTypetextBox.Text = "";
                AddOntyeDescriptioncomboBox.Text = "";
                AddOntyeDescriptioncomboBox.SelectedIndex = -1;
                OPNUPDATbindingSource.AddNew();
                OPNUPDATbindingSource.EndEdit();
                lbNewAddOn = true;
                StateCodetextBox.Text = Convert.ToString(AddOnDataSet.OPNCUST.Rows[0].Field<Int32>("CUSTOMER_STATE1"));
                Text = "Open Loan Balance Add On (ADD Mode)";
            }
            else
                Text = "Open Loan Balance Add On (EDIT Mode)";
            if (AddOnDataSet.OPNCUST.Rows.Count > 0)
                txtPaidThrough.Text = AddOnDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PAID_THRU_MM") + "/" + AddOnDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PAID_THRU_YY");
        }

        private void PaidThroughtextBox_Validated(object sender, EventArgs e)
        {
            ActiveControl = AddOnTypetextBox;
            AddOnTypetextBox.SelectAll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmOpenCustomerLookup form2inst;

            Visible = false;
            form2inst = new frmOpenCustomerLookup();

            form2inst.ShowDialog();
            Visible = true;
            if (Program.gsKey != null)
            {
                cUSTOMER_NOTextBox.Text = Program.gsKey;
                setRelatedData();
                ActiveControl = AddOnLoanAmounttextBox;
                AddOnLoanAmounttextBox.SelectAll();
            }
            Program.gsKey = null;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (AddOnTypetextBox.Text.TrimEnd() == "" || Convert.ToInt32(AddOnTypetextBox.Text) > 5)
            {
                MessageBox.Show("You must enter a valid Add-On Type in order to save!");
                return;
            }
            else
            {
                AddOnDataSet.OPNUPDAT.Rows[0].SetField<String>("UPDATE_CUSTOMER", cUSTOMER_NOTextBox.Text);
                AddOnDataSet.OPNUPDAT.Rows[0].SetField<String>("UPDATE_DEALER", DealertextBox.Text);
                AddOnDataSet.OPNUPDAT.Rows[0].SetField<Nullable<DateTime>>("UPDATE_DATE", (Nullable<DateTime>)TextAddOnDate.Value);
                AddOnDataSet.OPNUPDAT.Rows[0].SetField<Int32>("UPDATE_TYPE", Convert.ToInt32(AddOnTypetextBox.Text));
                AddOnDataSet.OPNUPDAT.Rows[0].SetField<Decimal>("UPDATE_INT1",Convert.ToDecimal(txtAPR1.Text));
                AddOnDataSet.OPNUPDAT.Rows[0].SetField<Decimal>("UPDATE_INT2",Convert.ToDecimal(txtAPR2.Text));
                AddOnDataSet.OPNUPDAT.Rows[0].SetField<Decimal>("UPDATE_INT3",Convert.ToDecimal(txtAPR3.Text));
                OPNUPDATbindingSource.EndEdit();
                oPNUPDATTableAdapter.Update(AddOnDataSet.OPNUPDAT.Rows[0]);
                AddOnDataSet.Clear();
                toolStripButtonSave.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                cUSTOMER_NOTextBox.Text = "";
                Program.gsKey = null;
                txtPaidThrough.Text = "";
                TextAddOnDate.Value = null;
                formOpenLoanBalanceAddOn_Load(sender, e);
            }
        }


        private void FillPaymentsWithLock()
        {
        }


        private void movetokey()
        {
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            Program.gbOpenPaymentAdd = false;
            Program.gbOpenPaymentEdit = false;
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            if (lbNewAddOn)
            {
                lbNewAddOn = false;
            }
            movetokey();
            toolStripButtonDelete.Enabled = true;
            toolStripButtonSave.Enabled = false;
            txtCheckValue.Refresh();
            Text = "Open Loan Balance Add On (VIEW Mode)";
        }

        private void formOpenLoanBalanceAddOn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Modal)
            {
                Program.gsKey = null;
            }
        }


        private void openPaymentiacDataSetBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            lbNewAddOn = true;
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (AddOnDataSet.OPNUPDAT.Rows.Count == 0 || AddOnDataSet.OPNCUST.Rows.Count == 0)
                return;
            OPNUPDATbindingSource.EndEdit();
            oPNUPDATTableAdapter.Delete(cUSTOMER_NOTextBox.Text);
            AddOnDataSet.Clear();
            toolStripButtonSave.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            cUSTOMER_NOTextBox.Text = "";
            Program.gsKey = null;
            txtPaidThrough.Text = "";
            TextAddOnDate.Value = null;
            formOpenLoanBalanceAddOn_Load(sender, e);
        }

        private void cUSTOMER_NOTextBox_Validated(object sender, EventArgs e)
        {
            string lsCustomerNo;

            if (Modal)
                return;  // Do not requery data on an edit!!!
            if (cUSTOMER_NOTextBox.Text.ToString().Trim().Length < 6 && cUSTOMER_NOTextBox.Text.ToString().Trim().Length > 0)
                cUSTOMER_NOTextBox.Text = cUSTOMER_NOTextBox.Text.PadLeft(6, '0');
            lsCustomerNo = cUSTOMER_NOTextBox.Text.ToString().Trim();
            if (lsCustomerNo == "")
                return;
            //if (!lbAddFlag)
                setRelatedData();
            if (AddOnDataSet.OPNCUST.Rows.Count == 0 && lsCustomerNo != "")
                MessageBox.Show("Sorry no customers found that match your selected account number!");
            else
                StateCodetextBox_Validated(sender, e);
        }

        private void AddOntyeDescriptioncomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(AddOnTypebindingSource.Position > -1)
                AddOnTypetextBox.Text = AddOnDataSet.AddOnType.Rows[AddOnTypebindingSource.Position].Field<String>("Type");
        }

        private void StateCodetextBox_Validated(object sender, EventArgs e)
        {
            if(AddOnDataSet.OPNCUST.Rows.Count == 0)
                return;
                opnrateTableAdapter.FillByMoreStatecod(AddOnDataSet.OPNRATE, AddOnDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_STATE"),Convert.ToInt32(StateCodetextBox.Text));
                if (AddOnDataSet.OPNRATE.Rows.Count != 0)
                {
                    txtAPR1.DataBindings.Clear();
                    txtAPR2.DataBindings.Clear();
                    txtAPR3.DataBindings.Clear();
                    txtAPR1.DataBindings.Add("Text", OPNRATEbindingSource, "OPFRATE1_Y");
                    txtAPR2.DataBindings.Add("Text", OPNRATEbindingSource, "OPFRATE2_Y");
                    txtAPR3.DataBindings.Add("Text", OPNRATEbindingSource, "OPFRATE3_Y");
                }
                else
                    MessageBox.Show("You must enter an existing code for the state of " + AddOnDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_STATE"));
        }
    }
}



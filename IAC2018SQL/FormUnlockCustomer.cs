using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class FormUnlock : Form
    {
        private Boolean lbClosed = false;
        private IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
        private IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();

        public FormUnlock()
        {
            InitializeComponent();
        }

        private void listBoxOpenClose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOpenClose.SelectedIndex == 0)
                lbClosed = true;
            else
                lbClosed = false;
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            if (lbClosed)
                CUSTOMERTableAdapter.UnlockRecord(textBoxCustomerNo.Text);
            else
                OPNCUSTTableAdapter.UnlockRecord(textBoxCustomerNo.Text);
            MessageBox.Show("Customer Number: " + textBoxCustomerNo.Text + " Unlocked");
            textBoxCustomerNo.Text = "";
        }

        private void FormUnlock_Load(object sender, EventArgs e)
        {
            listBoxOpenClose.SelectedIndex = 0;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxCustomerNo_Validated(object sender, EventArgs e)
        {
            if (textBoxCustomerNo.Text.ToString().Trim().Length < 6 && textBoxCustomerNo.Text.ToString().Trim().Length > 0)
                textBoxCustomerNo.Text = textBoxCustomerNo.Text.PadLeft(6, '0');
        }
    }
}

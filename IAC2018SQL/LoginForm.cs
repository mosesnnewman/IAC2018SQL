using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class LoginForm : Form
    {
        public bool gbLoginCorrect = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            uLISTTableAdapter.Fill(iACDataSet.ULIST, txtUserID.Text.ToString().TrimEnd(), txtPassword.Text.ToString().TrimEnd());
            if (iACDataSet.ULIST.Rows.Count == 0)
            {
                var ldlgAnswer = MessageBox.Show("No match found for that username and password combination.  Would you like to try again?", "Login Warning", MessageBoxButtons.YesNo);
                if (ldlgAnswer == DialogResult.No)                 
                {
                    gbLoginCorrect = false;
                    Close();
                }
                else
                {
                    txtPassword.Text = "";
                    ActiveControl = txtUserID;
                    txtUserID.SelectAll();
                }

            }
            else
            {
                IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
                DataPathTableAdapter.Fill(iACDataSet.DataPath);
                Program.GsDataPath = iACDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd().Substring(0, 2);
                if(Program.GsDataPath == @"\\")
                    Program.GsDataPath = iACDataSet.DataPath.Rows[0].Field<String>("UNCROOT").TrimEnd();
                gbLoginCorrect = true;
                Program.gsUserID = txtUserID.Text.ToString().TrimEnd();  
                Program.gsUserName = iACDataSet.ULIST.Rows[0].Field<String>("LIST_NAME").ToString().TrimEnd();
                iACDataSet.ULIST.Clear();
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbLoginCorrect = false;
            Close();
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}\r");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }
    }
}

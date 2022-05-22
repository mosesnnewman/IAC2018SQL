using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sentry;

namespace IAC2021SQL
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public bool gbLoginCorrect = false;

        public LoginForm()
        {
            InitializeComponent();
            uLISTTableAdapter.FillAll(iACDataSet.ULIST);
            bindingSourceULIST.DataSource = iACDataSet.ULIST;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IACDataSet lookupSet = new IACDataSet();
            uLISTTableAdapter.Fill(lookupSet.ULIST, txtUserID.Text.ToString().TrimEnd(), txtPassword.Text.ToString().TrimEnd());
            if (lookupSet.ULIST.Rows.Count == 0)
            {
                var ldlgAnswer = MessageBox.Show("No match found for that username and password combination.  Would you like to try again?", "Login Warning", MessageBoxButtons.YesNo);
                if (ldlgAnswer == DialogResult.No)                 
                {
                    gbLoginCorrect = false;
                    Close();
                }
                else
                {
                    txtPassword.EditValue = "";
                    ActiveControl = txtPassword;
                    txtPassword.SelectAll();
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
                Program.gsUserName = lookupSet.ULIST.Rows[0].Field<String>("LIST_NAME").ToString().TrimEnd();
                // Moses Newman 05/21/2022 Add User to Sentry for error reporting by user/
                SentrySdk.ConfigureScope(scope =>
                {
                    scope.User = new User
                    {
                        Id = Program.gsUserID,
                        Username = Program.gsUserName,
                        IpAddress = "{{auto}}",
                        Email = lookupSet.ULIST.Rows[0].Field<String>("Email").ToString().TrimEnd()
                    };
                });

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
            txtUserID.Focus();
            ActiveControl = txtUserID;
        }

        private void txtUserID_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            txtUserID.Focus();
        }
    }
}

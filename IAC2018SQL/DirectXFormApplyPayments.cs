using DevExpress.Utils.Html;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
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
    public partial class DirectXFormApplyPayments : DevExpress.XtraEditors.DirectXForm
    {

        private IACDataSetTableAdapters.CUSTOMERTableAdapter cUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
        private IACDataSet ClosedPaymentiacDataSet = new IACDataSet();

        public DirectXFormApplyPayments()
        {
            InitializeComponent();
        }

        private void windowsUIButtonPanelApplyPayments_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            String buttonChoice = btn.Caption;
            switch (buttonChoice)
            {
                case "Apply Payments":
                    DoProgress();
                    break;
                case "Exit":
                    Close();
                    break;

            }
        }

        private void DoProgress()
        {
            cUSTOMERTableAdapter.Fill(ClosedPaymentiacDataSet.CUSTOMER,"201501");
            progressBarControl1.Properties.Maximum = ClosedPaymentiacDataSet.CUSTOMER.Rows.Count;
            progressBarControl1.Visible = true;
            progressBarControl1.Enabled = true;
            progressBarControl1.Properties.ShowTitle = true;
            progressBarControl1.Properties.PercentView = false;
            for (int i = 0; i < ClosedPaymentiacDataSet.CUSTOMER.Rows.Count; i++)
            {
                Program.ApplyAllPayments(ClosedPaymentiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
            }
        }

        private void progressBarControl1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            var progressBarControl = sender as DevExpress.XtraEditors.ProgressBarControl;
            e.DisplayText = $"{e.Value}/{progressBarControl.Properties.Maximum}";
        }
    }
}
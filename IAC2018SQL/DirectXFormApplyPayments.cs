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
using IAC2021SQL.PaymentDataSetTableAdapters;

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
                    Close();
                    break;
                case "Exit":
                    Close();
                    break;
            }
        }

        private void DoProgress()
        {
            PaymentDataSetTableAdapters.PaymentHistoryTableAdapter paymentHistoryTableAdapter = new PaymentHistoryTableAdapter();

            //cUSTOMERTableAdapter.FillByBad05(ClosedPaymentiacDataSet.CUSTOMER);
            cUSTOMERTableAdapter.Fill(ClosedPaymentiacDataSet.CUSTOMER, "200988");

            progressBarControl1.Visible = true;
            progressBarControl1.Enabled = true;
            progressBarControl1.Properties.ShowTitle = true;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.Minimum = 0;
            progressBarControl1.Properties.Maximum = ClosedPaymentiacDataSet.CUSTOMER.Rows.Count;

            labelControl1.Visible = true;
            // Moses Newman 01/19/2023 Do not delete NULL Payments because no need, and if the arent unapplied before they are deleted phantom invoice payments will exist. (Deleted that line here)
            ClosedPaymentPosting cp = new ClosedPaymentPosting();
            for (int i = 0; i < ClosedPaymentiacDataSet.CUSTOMER.Rows.Count; i++)
            {
                Program.ApplyAllPayments(ClosedPaymentiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                cp.NewGetPartialPaymentandLateFeeBalance(ClosedPaymentiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
                                                         ref ClosedPaymentiacDataSet, i, false, -1,true, true);
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
                labelControl1.Text = ClosedPaymentiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + " " +
                                     ClosedPaymentiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_FIRST_NAME") + " " +
                                     ClosedPaymentiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_LAST_NAME") + " " +
                                     (i+1).ToString() + " of " + ClosedPaymentiacDataSet.CUSTOMER.Rows.Count.ToString();
                labelControl1.Refresh();
            }
            labelControl1.Visible = false;
        }

        private void progressBarControl1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            var progressBarControl = sender as DevExpress.XtraEditors.ProgressBarControl;
            e.DisplayText = $"{e.Value}/{progressBarControl.Properties.Maximum}";
        }
    }
}
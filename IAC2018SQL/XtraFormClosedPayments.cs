using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Repository;
using DevExpress.XtraEditors;
using DevExpress.Data;
using DevExpress.DataAccess.Sql.DataApi;
using DevExpress.XtraBars.Docking2010;
using Word = Microsoft.Office.Interop.Word;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DevExpress.Utils.Html;
using Microsoft.Office.Core;

namespace IAC2021SQL
{
    public partial class XtraFormClosedPayments : DevExpress.XtraEditors.XtraForm
    {
        System.Windows.Forms.Label labelOverPayment, lblIncome, lblPaidThrough, labelISFDate;

        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection tableAdapConn = null;

        private Boolean lbAddFlag = false, lbEdit = false, lbFormClosing = false, lbNewPayment = false, lbILockedIt = false,lbJustSaved = false;

        private Decimal gnCustomerBalance = 0, gnCustomerBuyout = 0;

        private int lnSeq = 0;


        public XtraFormClosedPayments()
        {
            InitializeComponent();
            sqlDataSourceClosedPayments.FillAsync();
        }

        private void XtraFormClosedPayments_Load(object sender, EventArgs e)
        {
            this.specialCommentCodesTableAdapter.Fill(this.ClosedPaymentiacDataSet.SpecialCommentCodes);
            //paymentTableAdapter.FillByAll(ClosedPaymentiacDataSet.PAYMENT);
            pAYCODETableAdapter.Fill(ClosedPaymentiacDataSet.PAYCODE);
            pAYMENTTYPETableAdapter.Fill(ClosedPaymentiacDataSet.PAYMENTTYPE);
            PerformAutoScale();
        }


        private void General_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void PaymentbindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count == 0)
            {
                FillPayments();
                if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count == 0)
                    return;
            }
            sqlDataSourceClosedPayments.Queries[0].Parameters[0].Value = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");
            sqlDataSourceClosedPayments.Queries[1].Parameters[0].Value = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("PAYMENT_DEALER");
            sqlDataSourceClosedPayments.Queries[5].Parameters[0].Value = Convert.ToInt32(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
            sqlDataSourceClosedPayments.Queries[6].Parameters[0].Value = Convert.ToInt32(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
            sqlDataSourceClosedPayments.Queries[6].Parameters[1].Value = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE");
            sqlDataSourceClosedPayments.Fill();
            ClosedPaymentiacDataSet.CUSTOMER.Clear();
            ClosedPaymentiacDataSet.DEALER.Clear();
            ClosedPaymentiacDataSet.PAYCODE.Clear();
            ClosedPaymentiacDataSet.PAYMENTTYPE.Clear();
            ITable srcCUSTOMER = sqlDataSourceClosedPayments.Result[0];
            foreach (IRow row in srcCUSTOMER)
                ClosedPaymentiacDataSet.CUSTOMER.Rows.Add(row.ToArray());
            ITable srcDEALER = sqlDataSourceClosedPayments.Result[1];
            foreach (IRow row in srcDEALER)
                ClosedPaymentiacDataSet.DEALER.Rows.Add(row.ToArray());
            ITable srcPAYCODE = sqlDataSourceClosedPayments.Result[2];
            foreach (IRow row in srcPAYCODE)
                ClosedPaymentiacDataSet.PAYCODE.Rows.Add(row.ToArray());
            ITable srcPAYMENTTYPE = sqlDataSourceClosedPayments.Result[4];
            foreach (IRow row in srcPAYMENTTYPE)
                ClosedPaymentiacDataSet.PAYMENTTYPE.Rows.Add(row.ToArray());
        }

        private void DoProgress()
        {
            /*cUSTOMERTableAdapter.Fill(ClosedPaymentiacDataSet.CUSTOMER,"211507");
            progressBarControl1.Properties.Maximum = ClosedPaymentiacDataSet.CUSTOMER.Rows.Count;
            progressBarControl1.Visible = true;
            progressBarControl1.Enabled = true;
            progressBarControl1.Properties.PercentView = false;
            for (int i = 0; i < ClosedPaymentiacDataSet.CUSTOMER.Rows.Count; i++)
            {
                Program.ApplyAllPayments(ClosedPaymentiacDataSet.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"));
                progressBarControl1.PerformStep();
                progressBarControl1.Update();
            }*/
        }

        private void XtraFormClosedPayments_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = paymentTableAdapter.LockedBy(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    paymentTableAdapter.UnlockRecord(ClosedPaymentiacDataSet.PAYMENT.Rows[0].Field<String>("PAYMENT_CUSTOMER"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE"), ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo"));
            }
        }

        private void PaymentbindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            lbNewPayment = true;
        }

        private void gridView2_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "PAYMENT_THRU_UD":
                    if ((int)e.Value == 0)
                    {
                        e.DisplayText = "";
                    }
                    break;
                case "PAYMENT_AMOUNT_RCV":
                    if ((Decimal)e.Value == 0)
                    {
                        e.DisplayText = "";
                    }
                    break;
            }
        }

        // Return the WordImage for a specific row.
        private Bitmap getWordImage(GridView view, int listSourceRowIndex)
        {
            Bitmap img;
            img = new Bitmap(IAC2021SQL.Properties.Resources.WordDoc);
            if (!String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath"))) || !String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "SMSPath"))))
                return img;
            else
                return null;
        }

        // Return the Path for a specific row.
        private String getPath(GridView view, int listSourceRowIndex)
        {
            return !String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath"))) ?
                    Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath")) :
                    Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "SMSPath"));
        }

        private void tabClosedPayments_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (tabClosedPayments.SelectedTabPageIndex)
            {
                case 0:
                    sqlDataSourceClosedPayments.Fill();
                    break;
            }
        }

        private void progressBarControl1_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            var progressBarControl = sender as DevExpress.XtraEditors.ProgressBarControl;
            e.DisplayText = $"{e.Value}/{progressBarControl.Properties.Maximum}";
        }

        private void repositoryItemCheckEdit1_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            string val = e.Value.ToString();
            switch (val)
            {
                case "Y":
                    e.CheckState = CheckState.Checked;
                    break;
                case "N":
                    e.CheckState = CheckState.Unchecked;
                    break;
                default:
                    e.CheckState = CheckState.Unchecked;
                    break;
            }
            e.Handled = true;
        }

        private void repositoryItemCheckEdit1_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            object val = edit.EditValue;
            switch (e.CheckState)
            {
                case CheckState.Checked:
                    e.Value = "Y";
                    break;
                case CheckState.Unchecked:
                    e.Value = "N";
                    break;
                default:
                    e.Value = "N";
                    break;
            }
            e.Handled = true;
        }


        private void windowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            String buttonChoice = btn.Caption;
            switch (buttonChoice)
            {                
                case "Add":
                case "Edit":
                    this.Hide();
                    XtraFormClosedPaymentEditor frmPaymentEdit = new XtraFormClosedPaymentEditor();
                    switch (buttonChoice)
                    {
                        case "Edit":
                            frmPaymentEdit.CustomerID = (Int32)textEditCustomerID.EditValue;
                            frmPaymentEdit.PaymentDate = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE");
                            frmPaymentEdit.SeqNo = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo");
                            frmPaymentEdit.lbEdit = true;
                            frmPaymentEdit.lbAddFlag = false;
                            break;
                        case "Add":
                            frmPaymentEdit.PaymentDate = DateTime.Now.Date;
                            frmPaymentEdit.lbAddFlag = true;
                            frmPaymentEdit.lbEdit = false;
                            break;
                    }
                    frmPaymentEdit.Visible = false;
                    frmPaymentEdit.ShowDialog(this);
                    this.Show();
                    frmPaymentEdit.Dispose();
                    ClosedPaymentiacDataSet.PAYMENT.Clear();
                    FillPayments();
                    break;
                case "Delete":
                    HtmlTemplateCollection htmlTemplates = new HtmlTemplateCollection();
                    var msgArgs = new XtraMessageBoxArgs();
                    msgArgs.HtmlTemplate.Assign(htmlTemplate1);
                    msgArgs.HtmlImages = svgImageCollection1;
                    msgArgs.Caption = "Delete payment for account#: "+ 
                        ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER") +
                        "?";  
                    msgArgs.Text = "This will permanently delete this payment! Do you want to delete it?"; 
                    var result = XtraMessageBox.Show(msgArgs);
                    if (result.ToString() == "OK")
                    {
                        paymentTableAdapter.Delete(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"),
                                                   ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE"),
                                                   ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo"));
                        ClosedPaymentiacDataSet.PAYMENT.Clear();
                        FillPayments();
                    }
                    break;
                case "Exit":
                    Close();
                    break;
            }
        }


        private void EFTtextBox_Enter(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
            {
                return;
            }
        }
        
        private void FillPayments()
        {
            sqlDataSourceClosedPayments.Fill();
            ITable srcPAYMENTS = sqlDataSourceClosedPayments.Result[3];
            foreach (IRow row in srcPAYMENTS)
                ClosedPaymentiacDataSet.PAYMENT.Rows.Add(row.ToArray());
        }
    }
}
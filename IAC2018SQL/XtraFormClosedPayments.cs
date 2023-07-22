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
using DevExpress.XtraGrid;
using IAC2021SQL.PaymentDataSetTableAdapters;
using DevExpress.Drawing;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils;
using DevExpress.XtraGauges.Core;
using DevExpress.LookAndFeel;

namespace IAC2021SQL
{
    public partial class XtraFormClosedPayments : DevExpress.XtraEditors.XtraForm
    {
        System.Windows.Forms.Label labelOverPayment, lblIncome, lblPaidThrough, labelISFDate;

        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection tableAdapConn = null;

        private Boolean lbAddFlag = false, lbEdit = false, lbFormClosing = false, lbNewPayment = false, lbILockedIt = false,lbJustSaved = false;

        private Decimal gnCustomerBalance = 0, gnCustomerBuyout = 0,TotalContractStatus = 0,TotalLateChargeBalance = 0,TotalPartialPayment = 0;
        private String FinalPaidThru = "";
        private DateTime FinalPaidThroughDate = DateTime.Now.Date;

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
                //Program.CreateTempPayments();
                FillPayments();
                if (ClosedPaymentiacDataSet.PAYMENT.Rows.Count == 0)
                    return;
            }
            sqlDataSourceClosedPayments.Queries[0].Parameters[0].Value = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");
            sqlDataSourceClosedPayments.Queries[1].Parameters[0].Value = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("PAYMENT_DEALER");
            sqlDataSourceClosedPayments.Queries[5].Parameters[0].Value = Convert.ToInt32(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
            sqlDataSourceClosedPayments.Queries[6].Parameters[0].Value = Convert.ToInt32(ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
            sqlDataSourceClosedPayments.Fill();
            ClosedPaymentiacDataSet.CUSTOMER.Clear();
            ClosedPaymentiacDataSet.CUSTHIST.Clear();
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
            invoicesBindingSource.DataSource = sqlDataSourceClosedPayments.Result[6];
            gridControlInvoices.DataSource = invoicesBindingSource;
            gridControlInvoices.RefreshDataSource();
            gridControlInvoices.Refresh();
            cUSTHISTTableAdapter.FillByCustomerNo(ClosedPaymentiacDataSet.CUSTHIST, ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
        }

        private void gridViewInvoices_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            int dx = e.Bounds.Height;
            Brush brush = e.Cache.GetSolidBrush(DXSkinColors.ForeColors.Information);
            Rectangle r = e.Bounds;
            r.Inflate(-1, -1);
            e.Cache.FillRectangle(brush, r);
            r.Inflate(-6, 0);
            e.Appearance.ForeColor = Color.White;
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, r);
            e.Handled = true;
        }

        private void gridView2_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            int dx = e.Bounds.Height;
            Brush brush = e.Cache.GetSolidBrush(DXSkinColors.ForeColors.Information);
            Rectangle r = e.Bounds;
            r.Inflate(-1, -1);
            e.Cache.FillRectangle(brush, r);
            r.Inflate(-6, 0);
            e.Appearance.ForeColor = Color.White;
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, r);
            e.Handled = true;
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

        private void gridViewInvoices_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            // Get the summary ID. 
            int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);
            PaymentDataSetTableAdapters.InvoicesTableAdapter invoicesTableAdapter = new InvoicesTableAdapter();
            // Initialization. 
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                switch (summaryID)
                {
                    case 1: // The total summary calculated against the 'UnitPrice' column. 
                        Object loContractStatus = invoicesTableAdapter.ContractStatus((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"), DateTime.Now.Date);
                        TotalContractStatus = loContractStatus != null ? (Decimal)loContractStatus : 0;
                        e.TotalValue = TotalContractStatus;
                        break;
                    case 2:
                        Object loLateFeeBalance = invoicesTableAdapter.LateChargeBalance((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        TotalLateChargeBalance = loLateFeeBalance != null ? (Decimal)loLateFeeBalance : 0;
                        e.TotalValue = TotalLateChargeBalance;
                        break;
                    case 3:
                        Object loPartialPayment = invoicesTableAdapter.PartialPayment((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        TotalPartialPayment = loPartialPayment != null ? (Decimal)loPartialPayment : 0;
                        e.TotalValue = TotalPartialPayment;
                        break;
                    case 4:
                        Object loPaidThrough = invoicesTableAdapter.PaidThru((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        FinalPaidThru = loPaidThrough != null ? ((String)loPaidThrough).Substring(0,2) + "/" + ((String)loPaidThrough).Substring(2, 2) : "";
                        e.TotalValue = FinalPaidThru;
                        break;
                    case 5:
                        Object loPaidThroughDate = invoicesTableAdapter.PaidThroughDate((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        FinalPaidThroughDate = loPaidThroughDate != null ? (DateTime)loPaidThroughDate : DateTime.Parse("01/01/1900");
                        e.TotalValue = FinalPaidThroughDate;
                        break;
                }
            }
            /*
            // Calculation.
            if (e.SummaryProcess == CustomSummaryProcess.Calculate)
            {
                switch (summaryID)
                {
                    case 1: // The total summary calculated against the 'UnitPrice' column. 
                        Object loContractStatus = invoicesTableAdapter.ContractStatus((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"), DateTime.Now.Date);
                        TotalContractStatus = loContractStatus != null ? (Decimal)loContractStatus : 0;
                        break;
                    case 2:
                        Object loLateFeeBalance = invoicesTableAdapter.LateChargeBalance((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        TotalLateChargeBalance = loLateFeeBalance != null ? (Decimal)loLateFeeBalance : 0;
                        break;
                    case 3:
                        Object loPartialPayment = invoicesTableAdapter.PartialPayment((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        TotalPartialPayment = loPartialPayment != null ? (Decimal)loPartialPayment : 0;
                        break;
                    case 4:
                        Object loPaidThrough = invoicesTableAdapter.PaidThru((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        FinalPaidThru = loPaidThrough != null ? (String)loPaidThrough : "";
                        e.TotalValue = FinalPaidThru;
                        break;
                    case 5:
                        Object loPaidThroughDate = invoicesTableAdapter.PaidThroughDate((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        FinalPaidThroughDate = loPaidThroughDate != null ? (DateTime)loPaidThroughDate : DateTime.Parse("01/01/1900");
                        break;
                }
            }
            // Finalization. 
            if (e.SummaryProcess == CustomSummaryProcess.Finalize)
            {
                switch (summaryID)
                {
                    case 1:
                        e.TotalValue = TotalContractStatus;
                        break;
                    case 2:
                        e.TotalValue = TotalLateChargeBalance;
                        break;
                    case 3:
                        e.TotalValue = TotalPartialPayment;
                        break;
                    case 4:
                        e.TotalValue = FinalPaidThru;
                        break;
                    case 5:
                        e.TotalValue = FinalPaidThroughDate;
                        break;
                }
            }*/
        }

        /*private void gridView2_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            Int32 sum = 0;
            GridView view = sender as GridView;
            List<String> idList = new List<String>();
            if (e.IsTotalSummary && (e.Item as GridSummaryItem).FieldName == "PAYMENT_CUSTOMER")
            {
                GridSummaryItem item = e.Item as GridSummaryItem;
                if (item.FieldName == "PAYMENT_CUSTOMER")
                {
                    bool shouldSum = !idList.Contains((String)view.GetRowCellValue(e.RowHandle, item.FieldName));
                    if(shouldSum)
                        idList.Add((String)view.GetRowCellValue(e.RowHandle, item.FieldName));
                    switch (e.SummaryProcess)
                    {
                        case CustomSummaryProcess.Start:
                            sum = 0;
                            break;
                        case CustomSummaryProcess.Calculate:
                            if (shouldSum)
                                sum += 1;
                            break;
                        case CustomSummaryProcess.Finalize:
                            e.TotalValue = sum;
                            break;
                    }
                }
            }
        }*/

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
                    String CustomerNo = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");
                    DateTime PayDate = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE");
                    Int32 SeqNo = ClosedPaymentiacDataSet.PAYMENT.Rows[PaymentbindingSource.Position].Field<Int32>("SeqNo");
                    HtmlTemplateCollection htmlTemplates = new HtmlTemplateCollection();
                    var msgArgs = new XtraMessageBoxArgs();
                    msgArgs.HtmlTemplate.Assign(htmlTemplate1);
                    msgArgs.HtmlImages = svgImageCollection1;
                    msgArgs.Caption = "Delete payment for account#: "+ CustomerNo + "?";  
                    msgArgs.Text = "This will permanently delete this payment! Do you want to delete it?"; 
                    var result = XtraMessageBox.Show(msgArgs);
                    if (result.ToString() == "OK")
                    {
                        PaymentDataSet paymentDataSet = new PaymentDataSet();
                        PaymentHistoryTableAdapter paymentHistoryTableAdapter = new PaymentHistoryTableAdapter();
                        paymentHistoryTableAdapter.FillByPAYMENTKey(paymentDataSet.PaymentHistory, Convert.ToInt32(CustomerNo), PayDate, SeqNo);
                        if (paymentDataSet.PaymentHistory.Rows.Count > 0)
                        {
                            Program.RemoveSinglePayment(paymentDataSet.PaymentHistory.Rows[0].Field<Int32>("id"));
                            paymentHistoryTableAdapter.Delete(paymentDataSet.PaymentHistory.Rows[0].Field<Int32>("id"));
                        }
                        paymentTableAdapter.Delete(CustomerNo,PayDate,SeqNo);
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
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.Data;
using DevExpress.DataAccess.Sql.DataApi;
using DevExpress.XtraBars.Docking2010;
using DevExpress.Utils.Html;
using DevExpress.XtraGrid;
using IAC2021SQL.PaymentDataSetTableAdapters;
using DevExpress.LookAndFeel;
using IAC2021SQL.IACDataSetTableAdapters;
using DevExpress.Utils.Behaviors.Common;
using DevExpress.XtraReports.Native.PrintingAsync;
using Microsoft.VisualStudio.OLE.Interop;

namespace IAC2021SQL
{
    public partial class XtraFormOpenPayments : DevExpress.XtraEditors.XtraForm
    {
        private Boolean lbAddFlag = false, lbEdit = false, lbILockedIt = false;

        private Decimal TotalContractStatus = 0,TotalLateChargeBalance = 0,TotalPartialPayment = 0;
        private String FinalPaidThru = "";
        private DateTime FinalPaidThroughDate = DateTime.Now.Date;

        public XtraFormOpenPayments()
        {
            InitializeComponent();
            _ = sqlDataSourceClosedPayments.FillAsync();
        }

        private void XtraFormOpenPayments_Load(object sender, EventArgs e)
        {
            this.specialCommentCodesTableAdapter.Fill(this.OpenPaymentiacDataSet.SpecialCommentCodes);
            pAYCODETableAdapter.Fill(OpenPaymentiacDataSet.PAYCODE);
            pAYMENTTYPETableAdapter.Fill(OpenPaymentiacDataSet.PAYMENTTYPE);
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
            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count == 0)
            {
                //Program.CreateTempPayments();
                FillPayments();
                if (OpenPaymentiacDataSet.OPNPAY.Rows.Count == 0)
                    return;
            }
            sqlDataSourceClosedPayments.Queries[0].Parameters[0].Value = OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");
            sqlDataSourceClosedPayments.Queries[1].Parameters[0].Value = OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_DEALER");
            sqlDataSourceClosedPayments.Fill();
            OpenPaymentiacDataSet.OPNCUST.Clear();
            OpenPaymentiacDataSet.OPNHCUST.Clear();
            OpenPaymentiacDataSet.OPNDEALR.Clear();
            OpenPaymentiacDataSet.PAYCODE.Clear();
            OpenPaymentiacDataSet.PAYMENTTYPE.Clear();
            ITable srcCUSTOMER = sqlDataSourceClosedPayments.Result[0];
            oPNCUSTTableAdapter.Fill(OpenPaymentiacDataSet.OPNCUST,OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
            /* foreach (IRow row in srcCUSTOMER)
            {
                OpenPaymentiacDataSet.OPNCUST.Rows.Add((OpenPaymentiacDataSet.OPNCUST)row.ToArray());

                oPNCUSTTableAdapter.Insert((String)row["CUSTOMER_NO"], (String)row["CUSTOMER_ADD_ON"], (String)row["CUSTOMER_IAC_TYPE"], (Boolean)row[`sArchive"], (String)row["CUSTOMER_FIRST_NAME"], 
                                           (String)row["CUSTOMER_LAST_NAME"], (String)row["CUSTOMER_DEALER"], (Int32)row["CUSTOMER_DAY_DUE"],
                                           (String)row["CUSTOMER_POST_IND"], (String)row["CUSTOMER_STREET_1"], (String)row["CUSTOMER_STREET_2"], (String)row["CUSTOMER_CITY"], (String)row["CUSTOMER_STATE"], 
                                           (String)row["CUSTOMER_ZIP_1"], (String)row["CUSTOMER_ZIP_2"], (String)row["CUSTOMER_REBATE_CDE"],
                                           (Int32)row["CUSTOMER_STATE1"], (String)row["CUSTOMER_COMMENT_FLAG"], (String)row["CUSTOMER_CONTROL_MONTH"], (String)row["CUSTOMER_CONTROL_YEART"], 
                                           (String)row["CUSTOMER_CLOSED_OUT"], (String)row["CUSTOMER_WRONG_ADDRESS"], (String)row["CUSTOMER_FULL_PAYMENT_FLAG"],
                                           (String)row["CUSTOMER_CONTACT"], (String)row["CUSTOMER_PHONE_NO"], (String)row["CUSTOMER_WORK_PHONE"], (String)row["CUSTOMER_WORK_EXT"], (String)row["CUSTOMER_COS_NAME"], 
                                           (String)row["CUSTOMER_COS_PHONE"], (DateTime)row["CUSTOMER_INIT_DATE"], (String)row["CUSTOMER_PAY_CODE"],
                                           (String)row["CUSTOMER_PAY_TYPE"], (String)row["CUSTOMER_CREDIT_STATUS"], (Int32)row["CUSTOMER_PT_UPDATE"], (String)row["CUSTOMER_ACT_STAT"], (String)row["CUSTOMER_FINANCE_CHARGE_FLAG"], (Decimal)row["CUSTOMER_BALANCE"], 
                                           (Int32)row["CUSTOMER_CREDIT_AVAILABLE"], (String)row["CUSTOMER_HOME_EXT"], (String)row["CUSTOMER_CREDIT_BUREAU"], (DateTime)row["CUSTOMER_HIGHEST_BALANCE_DATE"], 
                                           (Decimal)row["CUSTOMER_LAST_PAYMENT_MADE"], (DateTime)row["CUSTOMER_LAST_PAYMENT_DATE"], (DateTime)row["CUSTOMER_LAST_LC_DATE"],
                                           (Int32)row["CUSTOMER_NO_OF_PAYMENTS_MADE"], (Int32)row["CUSTOMER_TERM"], (Decimal)row["CUSTOMER_REGULAR_AMOUNT"], (Decimal)row["CUSTOMER_LOAN_AMOUNT"], 
                                           (Decimal)row["CUSTOMER_LOAN_INT"], (Decimal)row["CUSTOMER_LOAN_CASH"], (Decimal)row["CUSTOMER_LATE_CHARGE"], (Decimal)row["CUSTOMER_LATE_CHARGE_BAL"], (Decimal)row["CUSTOMER_PAID_INTEREST"],
                                           (Int32)row["CUSTOMER_FORM_NO"], (String)row["CUSTOMER_PAID_THRU"], (String)row["CUSTOMER_PAY_REM_1"], (Int32)row["CUSTOMER_PAY_REM_2"],
                                           (Decimal)row["CUSTOMER_CONTRACT_STATUS"], (Decimal)row["CUSTOMER_INTEREST_RATE1"], (Decimal)row["CUSTOMER_INTEREST_RATE2"], (Decimal)row["CUSTOMER_INTEREST_RATE3"], (Decimal)row["CUSTOMER_PREV_BALANCE_FILLER"],
                                           (Decimal)row["CUSTOMER_PAID"], (Decimal)row["CUSTOMER_TOT_FINANCE_CHARGE"], (Decimal)row["CUSTOMER_UPDATE_AMOUNT"], (Decimal)row["CUSTOMER_LAST_FINANCE_CHARGE"], (Decimal)row["CUSTOMER_LOAN_INTEREST"],
                                           (String)row["CUSTOMER_COMMENT_1"], (String)row["CUSTOMER_COMMENT_2"], (Decimal)row["CUSTOMER_YTD_FINANCE_CHARGE"], (DateTime)row["CUSTOMER_CONTRACT_DATE"], (String)row["CUSTOMER_PIF_INDICATOR"],
                                           (Int32)row["CUSTOMER_STATUS_NO"], (Decimal)row["CUSTOMER_TOTAL_PAYMENTS"], (Decimal)row["CUSTOMER_TOTAL_LATE_CHARGE"], (Decimal)row["CUSTOMER_PARTIAL_PAY"], (Int32)row["CUSTOMER_DISTRIBUTOR_NO"],
                                           (String)row["CUSTOMER_PURCHASE_ORDER"], (Int32)row["CUSTOMER_CONTROL_NUMBER"], (String)row["CUSTOMER_INSURANCE"], (String)row["CUSTOMER_AUTO_PAY"], (Int32)row["CUSTOMER_STAT1"], (Decimal)row["CUSTOMER_REG_AMOUNT1"],
                                           (Int32)row["CUSTOMER_STAT2"], (Decimal)row["CUSTOMER_REG_AMOUNT2"], (Decimal)row["CUSTOMER_ADD_ON_AMOUNT"], (DateTime)row["CUSTOMER_ADD_ON_DATE"], (Decimal)row["CUSTOMER_STATUS_AMOUNT"],
                                           (String)row["CUSTOMER_SS_1"], (String)row["CUSTOMER_SS_2"], (String)row["CUSTOMER_SS_3"], (String)row["CUSTOMER_ALLOTMENT"], (String)row["CUSTOMER_MILITARY"], (String)row["CUSTOMER_PRODUCT_CODE"], 
                                           (Decimal)row["CUSTOMER_TOTAL_ISF"],
                                           (Decimal)row["CUSTOMER_FINANCE_BUCKET_1"], (Decimal)row["CUSTOMER_FINANCE_BUCKET_2"], (Decimal)row["CUSTOMER_FINANCE_BUCKET_3"], (Decimal)row["CUSTOMER_FINANCE_BUCKET_4"], (Decimal)row["CUSTOMER_FINANCE_BUCKET_5"],
                                           (Decimal)row["CUSTOMER_FINANCE_BUCKET_6"], (Decimal)row["CUSTOMER_FINANCE_BUCKET_7"], (Decimal)row["CUSTOMER_FINANCE_BUCKET_8"], (Decimal)row["CUSTOMER_FINANCE_BUCKET_9"], (Decimal)row["CUSTOMER_FINANCE_BUCKET_10"],
                                           (String)row["CUSTOMER_SUFFIX"], (Int32)row["CUSTOMER_ABA_NUMBER"], (String)row["CUSTOMER_COUNTRY_CODE"], 
                                           (Int32)row["CUSTOMER_CREDIT_SCORE_N"], (String)row["CUSTOMER_CREDIT_SCORE_A"], (String)row["CUSTOMER_CREDIT_INFO"], (String)row["CUSTOMER_PHONE_EXT"], 
                                           (String)row["CUSTOMER_COS_EXT"], (String)row["CUSTOMER_NO_CONTACT"], (Int32)row["CUSTOMER_CREDIT_LIMIT"], (String)row["CUSTOMER_ALT_FLAG"], (Decimal)row["CUSTOMER_AMOUNT_1"],
                                           (Decimal)row["CUSTOMER_PERCENT_1"], (Decimal)row["CUSTOMER_ORIG_AMOUNT_1"], (Decimal)row["CUSTOMER_AMOUNT_2"], (Decimal)row["CUSTOMER_PERCENT_2"], (Decimal)row["CUSTOMER_ORIG_AMOUNT_2"], 
                                           (Decimal)row["CUSTOMER_AMOUNT_3"], (Decimal)row["CUSTOMER_PERCENT_3"], (Decimal)row["CUSTOMER_ORIG_AMOUNT_3"], (Decimal)row["CUSTOMER_AMOUNT_4"], (Decimal)row["CUSTOMER_PERCENT_4"], (Decimal)row["CUSTOMER_ORIG_AMOUNT_4"], (Decimal)row["CUSTOMER_AMOUNT_5"],
                                           (Decimal)row["CUSTOMER_PERCENT_5"], (Decimal)row["CUSTOMER_ORIG_AMOUNT_5"], (DateTime)row["CUSTOMER_PROMO_DATE_1"], (DateTime)row["CUSTOMER_PROMO_DATE_2"], (DateTime)row["CUSTOMER_PROMO_DATE_3"],
                                           (DateTime)row["CUSTOMER_PROMO_DATE_4"], (DateTime)row["CUSTOMER_PROMO_DATE_5"], (String)row["CUSTOMER_PROMO_CODE"], (Decimal)row["CUSTOMER_PREV_BALANCE"], (String)row["CUSTOMER_TSB_COMMENT_CODE"],
                                           (DateTime)row["CUSTOMER_DOB_DATE"], (Decimal)row["CUSTOMER_ANNUAL_PERCENTAGE_RATE"], (String)row["CUSTOMER_CELL_PHONE"], (String)row["CUSTOMER_COSIGNER_CELL_PHONE"],
                                           (Boolean)row["IsLocked"], (String)row["LockedBy"], (DateTime)row["LockTime"], (DateTime)row["PaidThrough"], (Boolean)row["TSBCodeOverride"], (String)row["TSBPaymentRating"]);
            } */
            ITable srcDEALER = sqlDataSourceClosedPayments.Result[1];
            foreach (IRow row in srcDEALER)
                OpenPaymentiacDataSet.OPNDEALR.Rows.Add(row.ToArray());
            ITable srcPAYCODE = sqlDataSourceClosedPayments.Result[2];
            foreach (IRow row in srcPAYCODE)
                OpenPaymentiacDataSet.PAYCODE.Rows.Add(row.ToArray());
            ITable srcPAYMENTTYPE = sqlDataSourceClosedPayments.Result[4];
            foreach (IRow row in srcPAYMENTTYPE)
                OpenPaymentiacDataSet.PAYMENTTYPE.Rows.Add(row.ToArray());
            oPNHCUSTTableAdapter.FillByCustomerNo(OpenPaymentiacDataSet.OPNHCUST, OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
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

        private void XtraFormOpenPayments_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (OpenPaymentiacDataSet.OPNPAY.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = opnpayTableAdapter.LockedBy(OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    opnpayTableAdapter.UnlockRecord(OpenPaymentiacDataSet.OPNPAY.Rows[0].Field<String>("PAYMENT_CUSTOMER"));
            }
        }

        private void gridView2_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if(e.Value == null)
            {
                e.DisplayText = "";
                return;
            }
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
            if (e.Value == null)
                return;
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
                    XtraFormOpenPaymentEditor frmPaymentEdit = new XtraFormOpenPaymentEditor();
                    switch (buttonChoice)
                    {
                        case "Edit":
                            frmPaymentEdit.CustomerID = Convert.ToInt32(textEditCustomerID.EditValue);
                            frmPaymentEdit.PaymentDate = OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE");
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
                    OpenPaymentiacDataSet.OPNPAY.Clear();
                    FillPayments();
                    break;
                case "Delete":
                    String CustomerNo = OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<String>("PAYMENT_CUSTOMER");
                    DateTime PayDate = OpenPaymentiacDataSet.OPNPAY.Rows[PaymentbindingSource.Position].Field<DateTime>("PAYMENT_DATE");
                    
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
                        opnpayTableAdapter.Delete(CustomerNo,PayDate);
                        OpenPaymentiacDataSet.OPNPAY.Clear();
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
                OpenPaymentiacDataSet.OPNPAY.Rows.Add(row.ToArray());
        }
    }
}
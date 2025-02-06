using DevExpress.DataAccess.Sql.DataApi;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using DevExpress.XtraPrinting.Native;
using System.DirectoryServices.AccountManagement;
using DevExpress.XtraPrinting;

namespace IAC2021SQL
{
    public partial class PrintCoupons : DevExpress.XtraEditors.XtraForm
    {
        public PrintCoupons()
        {
            InitializeComponent();
        }

        private void cUSTOMER_NOTextBox_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit textEdit = (TextEdit)sender;
            if (textEdit.EditValue.ToString().Trim().Length < 6 && textEdit.EditValue.ToString().Trim().Length > 0)
                textEdit.EditValue = textEdit.EditValue.ToString().Trim().PadLeft(6, '0');
            sqlDataSource1.Queries[0].Parameters[0].Value = (String)textEdit.EditValue;
            sqlDataSource1.Fill();
            ITable src = sqlDataSource1.Result[0];
            DataTable dest = new DataTable("CUSTOMER");
            foreach (IColumn column in src.Columns)
                dest.Columns.Add(column.Name, column.Type);
            foreach (IRow row in src)
                dest.Rows.Add(row.ToArray());
            if (dest.Rows.Count > 0)
            {
                DateEditNextPayDate.EditValue = dest.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE");
                textEditName.EditValue = dest.Rows[0].Field<String>("CUSTOMER_FIRST_NAME") + " " + dest.Rows[0].Field<String>("CUSTOMER_LAST_NAME");
                textEditAddress.EditValue = dest.Rows[0].Field<String>("CUSTOMER_STREET_1");
                textEditCity.EditValue = dest.Rows[0].Field<String>("CUSTOMER_CITY");
                textEditState.EditValue = dest.Rows[0].Field<String>("CUSTOMER_STATE");
                textEditZip.EditValue = dest.Rows[0].Field<String>("CUSTOMER_ZIP_1");
                textEditBalance.EditValue = dest.Rows[0].Field<Decimal>("CUSTOMER_BALANCE");
                textEditRegularPayment.EditValue = dest.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT");
                textEditTotalPayments.EditValue = dest.Rows[0].Field<Int32>("CUSTOMER_TERM");
                textEditPaymentsLeft.EditValue = dest.Rows[0].Field<Int32>("CUSTOMER_TERM") -
                    dest.Rows[0].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE");
                spinEditTicketCount.Value = dest.Rows[0].Field<Int32>("CUSTOMER_TERM");
                spinEditStartTicket.Value = 1;
            }
            else
            {
                DateEditNextPayDate.EditValue = null;
                textEditName.EditValue = "";
                textEditAddress.EditValue = "";
                textEditCity.EditValue = "";
                textEditState.EditValue = "";
                textEditZip.EditValue = "";
                textEditBalance.EditValue = "";
                textEditRegularPayment.EditValue = "";
                textEditTotalPayments.EditValue = "";
                textEditPaymentsLeft.EditValue = "";
                spinEditTicketCount.Value = 0;
                spinEditStartTicket.Value = 1;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            // Moses Newman 01/19/2023 Create Coupon Records For New Business
            SqlConnection CouponConnection = new SqlConnection(IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper());

            using (SqlCommand cmd = new SqlCommand("CreateCoupons"))
            {
                Int32 lnCustomerID = 0;
                if ((String)cUSTOMER_NOTextBox.EditValue != "")
                    lnCustomerID = Convert.ToInt32(cUSTOMER_NOTextBox.EditValue);
                cmd.Connection = CouponConnection;
                cmd.CommandTimeout = 300; //in seconds
                                          //etc...
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerNUM", SqlDbType.Int).Value = lnCustomerID;
                cmd.Parameters.AddWithValue("@StartTerm", SqlDbType.Int).Value = (Int32)spinEditStartTicket.Value;
                cmd.Parameters.AddWithValue("@TicketCount", SqlDbType.Int).Value = (Int32)spinEditTicketCount.Value;
                cmd.Parameters.AddWithValue("@PurgeNB", SqlDbType.Int).Value = 0;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            if (!checkEditEmail.Checked)
            {
                progressBarControlEmail.Enabled = false;
                progressBarControlEmail.Visible = false;
                var report = new XtraReportCouponBook();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                var tool = new ReportPrintTool(report);
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }
            else
            {
                progressBarControlEmail.Visible = true;
                progressBarControlEmail.Enabled = true;
                progressBarControlEmail.Properties.Step = 1;
                progressBarControlEmail.Properties.PercentView = true;
                progressBarControlEmail.Properties.Minimum = 0;
                Object mailitem;
                String CurrentUserEmail = UserPrincipal.Current.EmailAddress;

                Outlook.Application outlookApp = new Outlook.Application();
                sqlDataSource2.Fill();
                ITable srcCUSTOMER = sqlDataSource2.Result[0];
                DataTable destCUSTOMER = new DataTable("CUSTOMER");
                foreach (IColumn column in srcCUSTOMER.Columns)
                    destCUSTOMER.Columns.Add(column.Name, column.Type);
                foreach (IRow row in srcCUSTOMER)
                    destCUSTOMER.Rows.Add(row.ToArray());

                ITable srcCUSTOMEREmail = sqlDataSource2.Result[1];
                DataTable destCUSTOMEREmail = new DataTable("CUSTOMEREmail");
                foreach (IColumn column in srcCUSTOMEREmail.Columns)
                    destCUSTOMEREmail.Columns.Add(column.Name, column.Type);
                foreach (IRow row in srcCUSTOMEREmail)
                    destCUSTOMEREmail.Rows.Add(row.ToArray());
                progressBarControlEmail.Properties.Maximum = destCUSTOMEREmail.Rows.Count;
                for (int i = 0; i < destCUSTOMEREmail.Rows.Count; i++)
                {
                    using (SqlCommand cmd = new SqlCommand("CreateCoupons"))
                    {
                        cmd.Connection = CouponConnection;
                        cmd.CommandTimeout = 300; //in seconds
                                                  //etc...
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerNUM", SqlDbType.Int).Value = destCUSTOMEREmail.Rows[i].Field<String>("CustomerNo");
                        cmd.Parameters.AddWithValue("@StartTerm", SqlDbType.Int).Value = (Int32)spinEditStartTicket.Value;
                        cmd.Parameters.AddWithValue("@TicketCount", SqlDbType.Int).Value = (Int32)spinEditTicketCount.Value;
                        cmd.Parameters.AddWithValue("@PurgeNB", SqlDbType.Int).Value = 0;
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    XtraReportCouponBook report = new XtraReportCouponBook();
                    SqlDataSource ds = report.DataSource as SqlDataSource;
                    report.DataSource = ds;
                    report.RequestParameters = false;
                    String lsFileName = @"\\DC-IAC\Public\Coupons\" + destCUSTOMEREmail.Rows[i].Field<String>("CustomerNo") + "Coupons.pdf";
                    report.ExportToPdf(lsFileName);

                    mailitem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                    Outlook.MailItem mailItem = (Outlook.MailItem)mailitem;
                    mailItem.Subject = "*** LOAN PAYMENT COUPONS FROM IAC, INC. ***";
                    mailItem.SentOnBehalfOfName = CurrentUserEmail;
                    mailItem.To = destCUSTOMEREmail.Rows[i].Field<String>("EmailAddress");
                    mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
                    mailItem.BodyFormat = Outlook.OlBodyFormat.olFormatRichText;
                    mailItem.Body = "Attached please find the PDF of your loan payment coupons. IAC, INC.";
                    mailItem.Attachments.Add(lsFileName, Outlook.OlAttachmentType.olByValue, 1, lsFileName);
                    mailItem.Send();
                    progressBarControlEmail.PerformStep();
                    progressBarControlEmail.Update();
                }
                //outlookApp.Quit();
                progressBarControlEmail.Properties.Step = 1;
                progressBarControlEmail.Properties.PercentView = true;
                progressBarControlEmail.Properties.Minimum = 0;
                progressBarControlEmail.Visible = false;
            }
        }
        private void PrintCoupons_Load(object sender, EventArgs e)
        {
            cUSTOMER_NOTextBox.EditValue = "";
            checkEditAllNewBusiness.Checked = false;
            progressBarControlEmail.Enabled = false;
            progressBarControlEmail.Visible = false;
            checkEditLimitToYear.Visible = false;
            checkEditLimitToYear.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkEditAllNewBusiness_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditAllNewBusiness.Checked)
            {
                cUSTOMER_NOTextBox.EditValue = "";
                DateEditNextPayDate.EditValue = null;
                textEditName.EditValue = "";
                textEditAddress.EditValue = "";
                textEditCity.EditValue = "";
                textEditState.EditValue = "";
                textEditZip.EditValue = "";
                textEditBalance.EditValue = "";
                textEditRegularPayment.EditValue = "";
                spinEditTicketCount.Value = 0;
                spinEditStartTicket.Value = 1;
                textEditPaymentsLeft.EditValue = "";
                textEditTotalPayments.EditValue = "";
                cUSTOMER_NOTextBox.Enabled = false;
                checkEditLimitToYear.Visible = true;
                checkEditLimitToYear.Enabled = true;
            }
            else
            {
                cUSTOMER_NOTextBox.Enabled = true;
                checkEditLimitToYear.Visible = false;
                checkEditLimitToYear.Enabled = false;
            }
        }

        // Moses Newman 01/26/2023 Add limit to one year option for new business print
        private void checkEditLimitToYear_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEditLimitToYear.Checked)
            {
                spinEditTicketCount.Value = 12;
            }
            else
            {
                spinEditTicketCount.Value = 0;
            }
        }
    }
}
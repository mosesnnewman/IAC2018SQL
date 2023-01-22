using DevExpress.DataAccess.Sql.DataApi;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

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
            SqlConnection CouponConnection = new SqlConnection("Data Source=SQL-IAC;Initial Catalog=IACSQLPRODUCTION;Integrated Security=SSPI;TrustServerCertificate=True");
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
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            var report = new XtraReportCouponBook();
            SqlDataSource ds = report.DataSource as SqlDataSource;

            report.DataSource = ds;
            report.RequestParameters = false;

            var tool = new ReportPrintTool(report);

            tool.PreviewRibbonForm.MdiParent = MDImain;
            tool.AutoShowParametersPanel = false;
            tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
            tool.ShowRibbonPreview();
        }

        private void PrintCoupons_Load(object sender, EventArgs e)
        {
            cUSTOMER_NOTextBox.EditValue = "";
            checkEditAllNewBusiness.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkEditAllNewBusiness_CheckedChanged(object sender, EventArgs e)
        {
            if(checkEditAllNewBusiness.Checked)
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
            }
            else
                cUSTOMER_NOTextBox.Enabled = true;
        }
    }
}
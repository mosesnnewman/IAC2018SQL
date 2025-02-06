using System;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;

namespace IAC2021SQL
{
    public partial class frmImportDefi : DevExpress.XtraEditors.XtraForm
    {
        public frmImportDefi()
        {
            InitializeComponent();
        }

        
        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            SqlConnection PDFConnection = new SqlConnection("Data Source=SQL-IAC;Initial Catalog=IACSQLPRODUCTION;Integrated Security=SSPI;TrustServerCertificate=True");

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            // Moses Newman 09/16/2022 change to SqlCommand with timeout so that stored procedure does not timeout!

            using (SqlCommand cmd = new SqlCommand("ImportFromDEFI"))
            {
                cmd.Connection = PDFConnection;
                cmd.CommandTimeout = 300; //in seconds
                                          //etc...
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            //CUSTOMERTableAdapter.ImportFromDEFI();
            PrintIt();

            MessageBox.Show("*** Finished importing Defi XML Applications! ***");
            if(checkBoxImages.Checked)
            {
                frmImportDefiPDFs ImportPDFs = new frmImportDefiPDFs();
                Visible = false;
                ImportPDFs.Show();
                ImportPDFs.ImportPDFs();
                Visible = true; 
            }
            Close();
        }

        
        private void frmImportDefi_Load(object sender, EventArgs e)
        {
             
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintIt();
        }

        private void PrintIt()
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent, MDImain2 = (MDIIAC2013)MdiParent;
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DuplicatesDefiTableAdapter DuplicatesDefiTableAdapter = new IACDataSetTableAdapters.DuplicatesDefiTableAdapter();


            CustomerTableAdapter.FillByNonPostedDefi(ReportData.CUSTOMER);
            if (ReportData.CUSTOMER.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO CUSTOMERS IN NEW BUSINESS! ***");
            }
            else
            {
                // Moses Newman 09/21/2022 Covert to XtraReport
                var report = new XtraReportClosedCustomerEditList();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gbDEFI"].Value = true;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();

            }
            DuplicatesDefiTableAdapter.FillByAll(ReportData.DuplicatesDefi);
            if (ReportData.DuplicatesDefi.Rows.Count > 0)
            {
                // Moses Newman 09/21/2022 Covert to XtraReport
                var report = new XtraReportDefiDuplicates();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gsTitle"].Value = "Defi - Rejected Duplicate Accounts";

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }   
        }
    }
}

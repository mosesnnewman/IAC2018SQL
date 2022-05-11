using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;


namespace IAC2021SQL
{
    public partial class CustomerRepossessionReport : DevExpress.XtraEditors.XtraForm
    {
        public CustomerRepossessionReport()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            String deletePath = "";
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            IACDataSet VehicleDataSet = new IACDataSet(); 
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();

            DataPathTableAdapter.Fill(VehicleDataSet.DataPath);

            CUSTOMERTableAdapter.FillByVehicle(VehicleDataSet.CUSTOMER);

            if (VehicleDataSet.CUSTOMER.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no VEHICLE records for ACTIVE CUSTOMERS ***");
            else
            {
                deletePath = VehicleDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();

                deletePath += @"EXCLDATA\CustomerRepoExtract.xls";

                if(System.IO.File.Exists(deletePath))
                    System.IO.File.Delete(deletePath);

                // Moses Newman 04/25/2022 Covert to XtraReport
                var report = new XtraReportVehicleReposession();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
                SQLBR.CustomerRepoExtractJob();
            }
            SQLBR.Dispose();
            SQLBR = null;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

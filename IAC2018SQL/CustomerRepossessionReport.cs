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

namespace IAC2018SQL
{
    public partial class CustomerRepossessionReport : Form
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
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

            IACDataSet VehicleDataSet = new IACDataSet(); 
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CreditCodesTableAdapter CreditCodesTableAdapter = new IACDataSetTableAdapters.CreditCodesTableAdapter();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.RepoCodesTableAdapter RepoCodesTableAdapter = new IACDataSetTableAdapters.RepoCodesTableAdapter();
            IACDataSetTableAdapters.VEHICLETableAdapter VEHICLETableAdapter = new IACDataSetTableAdapters.VEHICLETableAdapter();

            DataPathTableAdapter.Fill(VehicleDataSet.DataPath);

            CUSTOMERTableAdapter.FillByVehicle(VehicleDataSet.CUSTOMER);
            CreditCodesTableAdapter.Fill(VehicleDataSet.CreditCodes);
            DEALERTableAdapter.FillByVehicle(VehicleDataSet.DEALER);
            RepoCodesTableAdapter.Fill(VehicleDataSet.RepoCodes);
            VEHICLETableAdapter.FillByAllActive(VehicleDataSet.VEHICLE);

            if (VehicleDataSet.CUSTOMER.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no VEHICLE records for ACTIVE CUSTOMERS ***");
            else
            {
                deletePath = VehicleDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();

                deletePath += @"EXCLDATA\CustomerRepoExtract.xls";

                if(System.IO.File.Exists(deletePath))
                    System.IO.File.Delete(deletePath);
                VehicleRepossessionReport myReportObject = new VehicleRepossessionReport();
                myReportObject.SetDataSource(VehicleDataSet);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
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

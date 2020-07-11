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
    public partial class ClosedCustomerTierSummary : Form
    {
        public ClosedCustomerTierSummary()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //String deletePath = "";
            //SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

            IACDataSet ReportDataSet = new IACDataSet();
            IACDataSetTableAdapters.ClosedCustomertTierSummaryTableAdapter ClosedCustomertTierSummaryTableAdapter = new IACDataSetTableAdapters.ClosedCustomertTierSummaryTableAdapter();

            ClosedCustomertTierSummaryTableAdapter.Fill(ReportDataSet.ClosedCustomertTierSummary,"A%","%");

            if (ReportDataSet.ClosedCustomertTierSummary.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Customers Selected! ***");
            else
            {
                /*
                deletePath = ReportDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();

                deletePath += @"EXCLDATA\CustomerRepoExtract.xls";

                if(System.IO.File.Exists(deletePath))
                    System.IO.File.Delete(deletePath);*/
                ClosedCustomerTierSummaryReport myReportObject = new ClosedCustomerTierSummaryReport();
                myReportObject.SetDataSource(ReportDataSet);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
                //SQLBR.CustomerRepoExtractJob();
            }
            //SQLBR.Dispose();
            //SQLBR = null;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

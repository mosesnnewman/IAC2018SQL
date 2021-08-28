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

namespace IAC2021SQL
{
    public partial class CustomerShortBalanceReport : Form
    {
        public CustomerShortBalanceReport()
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
            IACDataSetTableAdapters.ClosedCustomerShortBalanceTableAdapter ClosedCustomerShortBalanceTableAdapter = new IACDataSetTableAdapters.ClosedCustomerShortBalanceTableAdapter();

            ClosedCustomerShortBalanceTableAdapter.Fill(ReportDataSet.ClosedCustomerShortBalance);

            if (ReportDataSet.ClosedCustomerShortBalance.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Customers with Short Balances! ***");
            else
            {
                /*
                deletePath = ReportDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();

                deletePath += @"EXCLDATA\CustomerRepoExtract.xls";

                if(System.IO.File.Exists(deletePath))
                    System.IO.File.Delete(deletePath);*/
                ShortBalanceReport myReportObject = new ShortBalanceReport();
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

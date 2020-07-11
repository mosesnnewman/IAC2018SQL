using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class frmImportTCI : Form
    {
        public frmImportTCI()
        {
            InitializeComponent();
        }

        
        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();

            CUSTOMERTableAdapter.ImportFromTCI();
            PrintIt();

            MessageBox.Show("*** Finished importing TCI XML Applications! ***");

            Close();
        }

        
        private void frmImportTCI_Load(object sender, EventArgs e)
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
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.DuplicatesTCITableAdapter DuplicatesTCITableAdapter = new IACDataSetTableAdapters.DuplicatesTCITableAdapter();


            CustomerTableAdapter.FillByNonPostedTCI(ReportData.CUSTOMER);
            if (ReportData.CUSTOMER.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO CUSTOMERS IN NEW BUSINESS! ***");
            }
            else
            {
                DEALERTableAdapter.FillByMissingDealers(ReportData.DEALER);
                ClosedCustomerEditListTCI myReportObject = new ClosedCustomerEditListTCI();
                MDImain.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;
                myReportObject.SetDataSource(ReportData);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

                rptViewr.crystalReportViewer.ReportSource = myReportObject;
                rptViewr.crystalReportViewer.Refresh();
                rptViewr.Show();
            }
            CustomerTableAdapter.FillByDupesTCI(ReportData.CUSTOMER);  
            DuplicatesTCITableAdapter.FillByALL(ReportData.DuplicatesTCI);
            DEALERTableAdapter.FillByDupesTCI(ReportData.DEALER);
            if (ReportData.DuplicatesTCI.Rows.Count > 0)
            {  
                TCIDuplicates myReportObject2 = new TCIDuplicates();
                myReportObject2.SetDataSource(ReportData);
                myReportObject2.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject2.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject2.SetParameterValue("gsTitle", "TCI - Rejected Duplicate Accounts");
                MDImain2.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewr2 = (ReportViewer)MDImain2.ActiveMdiChild;
                rptViewr2.crystalReportViewer.ReportSource = myReportObject2;
                rptViewr2.crystalReportViewer.Refresh();
                rptViewr2.Show();
            }   
        }
    }
}

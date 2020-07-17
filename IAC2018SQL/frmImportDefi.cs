using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class frmImportDefi : Form
    {
        public frmImportDefi()
        {
            InitializeComponent();
        }

        
        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();

            CUSTOMERTableAdapter.ImportFromDEFI();
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
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.DuplicatesDefiTableAdapter DuplicatesDefiTableAdapter = new IACDataSetTableAdapters.DuplicatesDefiTableAdapter();


            CustomerTableAdapter.FillByNonPostedDefi(ReportData.CUSTOMER);
            if (ReportData.CUSTOMER.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO CUSTOMERS IN NEW BUSINESS! ***");
            }
            else
            {
                DEALERTableAdapter.FillByMissingDealersDefi(ReportData.DEALER);
                ClosedCustomerEditListDefi myReportObject = new ClosedCustomerEditListDefi();
                MDImain.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;
                myReportObject.SetDataSource(ReportData);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

                rptViewr.crystalReportViewer.ReportSource = myReportObject;
                rptViewr.crystalReportViewer.Refresh();
                rptViewr.Show();
            }
            CustomerTableAdapter.FillByDupesDefi(ReportData.CUSTOMER);  
            DuplicatesDefiTableAdapter.FillByAll(ReportData.DuplicatesDefi);
            DEALERTableAdapter.FillByDupesDefi(ReportData.DEALER);
            if (ReportData.DuplicatesDefi.Rows.Count > 0)
            {  
                DefiDuplicates myReportObject2 = new DefiDuplicates();
                myReportObject2.SetDataSource(ReportData);
                myReportObject2.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject2.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject2.SetParameterValue("gsTitle", "Defi - Rejected Duplicate Accounts");
                MDImain2.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewr2 = (ReportViewer)MDImain2.ActiveMdiChild;
                rptViewr2.crystalReportViewer.ReportSource = myReportObject2;
                rptViewr2.crystalReportViewer.Refresh();
                rptViewr2.Show();
            }   
        }
    }
}

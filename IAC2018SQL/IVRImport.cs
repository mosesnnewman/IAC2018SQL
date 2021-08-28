using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace IAC2021SQL
{
    public partial class frmIVRImport : Form
    {

        public frmIVRImport()
        {
            InitializeComponent();
        }        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ReadPCPAYFILE(IACDataSet PCPAY)
        {
            PaymentDataSet IVR = new PaymentDataSet();
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            IACDataSetTableAdapters.IVRPAYTableAdapter IVRPAYTableAdapter = new IACDataSetTableAdapters.IVRPAYTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            PaymentDataSetTableAdapters.IVRRejectsTableAdapter IVRRejectsTableAdapter = new PaymentDataSetTableAdapters.IVRRejectsTableAdapter();

             if (SQLBR.RunJob("IVRIMPORT", "Import from IVR",false))
             {
                 Thread.Sleep(5000);
                 try
                 {
                     IVRPAYTableAdapter.Fill(PCPAY.IVRPAY);
                 }
                 catch
                 {
                     IVRPAYTableAdapter.Fill(PCPAY.IVRPAY);
                 }
             }
            // Moses Newman 09/25/2018 Create Rejects Report if any customers are Inactive.
            if (PCPAY.IVRPAY.Rows.Count != 0)
            {
                IVRRejectsTableAdapter.Create();
                IVRRejectsTableAdapter.FillByAll(IVR.IVRRejects);
                if(IVR.IVRRejects.Rows.Count > 0)
                {
                    MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                    Hide();
                    MDImain.CreateFormInstance("ReportViewer", false);
                    ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                    IVRRejects myReportObject = new IVRRejects();
                    myReportObject.SetDataSource(IVR);
                    myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                    myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                    myReportObject.SetParameterValue("gsTitle", "IVR PAYMENT REJECTS REPORT");
                    rptViewer.crystalReportViewer.ReportSource = myReportObject;
                    rptViewer.crystalReportViewer.Refresh();
                    rptViewer.Show();
                }
            }

            if (SQLBR.RunJob("IVRToPayment", "Move IVR to PAYMENT",false))
            {
                Thread.Sleep(5000);
                try
                {
                    PAYMENTTableAdapter.FillByAll(PCPAY.PAYMENT);
                }
                catch
                {
                    PAYMENTTableAdapter.FillByAll(PCPAY.PAYMENT);
                }
            }
            PCPAY.IVRPAY.Clear();
           
            IVRPAYTableAdapter.Dispose();
            PAYMENTTableAdapter.Dispose();
           
            PCPAY.Dispose();
        }

        public void RenameFile(string originalName, string newName)
        {
            File.Move(originalName, newName);
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.IVRPAYTableAdapter IVRPAYTableAdapter = new IACDataSetTableAdapters.IVRPAYTableAdapter();
            IACDataSet AUTOBANK = new IACDataSet();
            ReadPCPAYFILE(AUTOBANK);
            IVRPAYTableAdapter.Fill(AUTOBANK.IVRPAY);
            String lsUNCROOT = Program.GsDataPath,lsOldFile,lsNewFile;

            lsOldFile = lsUNCROOT + @"IVRPAY\IVRpmt.csv";
            lsNewFile = lsUNCROOT + @"IVRPAY\IVRpmt" + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString().PadLeft(2, '0') + DateTime.Now.Date.Day.ToString().PadLeft(2, '0')+@".csv";
            if (AUTOBANK.IVRPAY.Rows.Count != 0)
            {
                RenameFile(lsOldFile, lsNewFile);
                MessageBox.Show("*** Import of " + AUTOBANK.IVRPAY.Rows.Count.ToString().Trim() + " IVR RECORDS complete. ***", "IVR Payments Import");
            }
            else
                MessageBox.Show("*** NO IVR RECORDS FOUND! ***", "IVR Payments Import");
            IVRPAYTableAdapter.Dispose();
            AUTOBANK.Dispose();
        }
    }
}

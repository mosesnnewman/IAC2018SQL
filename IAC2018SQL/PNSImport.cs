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
using Renci.SshNet;
using Renci.SshNet.Sftp;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Excel = Microsoft.Office.Interop.Excel;


namespace IAC2021SQL
{
    // Moses Newman 11/06/2019 Create PayNSeconds SFTP download and import int PAYMENTS routines.
    public partial class frmPNSImport : Form
    {
        private string host = @"204.13.110.68";
        private string username = @"iacinc_0";
        private string password = @"LAK2zWqNqF2LQm42";
        private string remoteDirectory = @"/00000000-0000-2d07-e9ea-08d6fe68bbde/Download";
        private string remoteArchive = @"/00000000-0000-2d07-e9ea-08d6fe68bbde/Download/Archive";


        public frmPNSImport()
        {
            InitializeComponent();
        }        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Downloads a file in the desktop synchronously
        /// </summary>
        public Boolean downloadFile(string pathRemoteFile, string pathLocalFile, int FileCount, int FileNumber)
        {
            Int32 Progress = (Int32)(Math.Round(((Double)FileNumber / (Double)FileCount), 2) * 100);
            String FullLocalPath = pathLocalFile + @"\" + pathRemoteFile,
                   FullRemotePath = remoteDirectory + @"\" + pathRemoteFile,
                   FullRemoteArchivePath = remoteDirectory + @"\Archive\" + pathRemoteFile;
            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();
 
                    labelDownload.Text = "Downloading: " + pathRemoteFile;
                    labelDownload.Refresh();

                    using (Stream fileStream = File.Create(FullLocalPath))
                    {
                        try
                        {
                            sftp.DownloadFile(FullRemotePath, fileStream);
                        }
                        // Moses Newman 01/06/2020 File Not Found because it is in the Archive Folder So Redo!
                        catch (Renci.SshNet.Common.SftpPathNotFoundException)
                        {
                            sftp.DownloadFile(FullRemoteArchivePath, fileStream);
                        }
                        sftp.Disconnect();
                        progressBarDownload.Value = Progress;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show("Download Failed due to " + er.Message,"*** Download File Error ***",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private Int32 DownloadPNSPayments() 
        {
            int FileNumber = 0;
            var FilesOnly = new List<SftpFile>();
            Boolean success = false;

            labelDownload.Text = "";
            labelDownload.Visible = true;

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    SftpFile orgFile;
                    var files = sftp.ListDirectory(remoteDirectory);
                    // Moses Newman 01/01/2020 Add Archive folder files
                    var archivefiles = sftp.ListDirectory(remoteArchive);
                    // Moses Newman 07/09/2021 end mod. 
                    files = files.Union(archivefiles);
                    
                    foreach (var file in files)
                    {
                        if(!file.IsDirectory)
                        {
                            FilesOnly.Add(file);
                        }
                    }

                    foreach (var file in FilesOnly)
                    {
                        FileNumber += 1;
                        success = downloadFile(file.Name, @"\\dc-iac\Public\PayNSeconds", FilesOnly.Count(), FileNumber);
                        if (!success)
                        {
                            MessageBox.Show("*** Error downloading: " + file.Name + " Import not completed! ***", "PNS Download Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return 0;
                        }
                        orgFile = (SftpFile)file;
                        // Moses Newman 01/06/2020 Delete successful downloads
                        orgFile.Delete();
                        //orgFile.MoveTo(remoteDirectory + "/Archive/" + file.Name);
                    }

                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    MessageBox.Show("An exception has been caught " + e.ToString(),"PNS Download Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return 0;
                }
            }
            labelDownload.Text = "*** Download(s) Completed Sucessfully! ***";
            return FilesOnly.Count();
        }

        private Boolean ReadPNSFile(PaymentDataSet PNS, Boolean withDownload = true)
        {
            IACDataSet PNSIAC = new IACDataSet();
            Boolean ReturnCode = false;
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            PaymentDataSetTableAdapters.PayNSecondsTableAdapter PayNSecondsTableAdapter = new PaymentDataSetTableAdapters.PayNSecondsTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();
            PaymentDataSetTableAdapters.PNSRejectsTableAdapter PNSRejectsTableAdapter = new PaymentDataSetTableAdapters.PNSRejectsTableAdapter();
            PaymentDataSetTableAdapters.PNSIMPORTParamsTableAdapter PNSIMPORTParamsTableAdapter = new PaymentDataSetTableAdapters.PNSIMPORTParamsTableAdapter();
            Int32 FileNumber = 0, TotalFiles = 0, Progress = 0,TotalDownloads = 0;
            String FilePath = @"\\dc-iac\Public\PayNSeconds\",
                   ConnStringStart = @"Data Source=SQL-IAC;",
                   lsConnect = lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(),
                   DataBase = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16,
                        (lsConnect.IndexOf(";", lsConnect.IndexOf("INITIAL CATALOG=") + 16) - (lsConnect.IndexOf("INITIAL CATALOG=") + 16))),
                   ConnStringEnd = @";Provider=SQLNCLI11.1;Integrated Security=SSPI;Auto Translate=False;",
                   ConnString = ConnStringStart + "INITIAL CATALOG=" + DataBase + ConnStringEnd;

            // Moses Newman 03/26/2021
            if (withDownload)
                TotalDownloads = DownloadPNSPayments();
            if (TotalDownloads > 0 || !withDownload)
            {
                PayNSecondsTableAdapter.DeleteAll();
                var filenames = Directory
                            .EnumerateFiles(FilePath, "*.xlsx", SearchOption.TopDirectoryOnly)
                            .Select(Path.GetFileName); // <-- note you can shorten the lambda
                TotalFiles = filenames.Count()-1;

                // Moses Newman 10/14/2021 do not reformat if previous attempt to process failed
                if(withDownload)
                    FormatExcel(FilePath, filenames);  // Moses Newman 07/10/2021
                foreach (String FileName in filenames)
                {
                    if (FileName.IndexOf("Template.xlsx") == -1)
                    {
                        FileNumber += 1;
                        Progress = (Int32)(Math.Round(((Double)FileNumber / (Double)TotalFiles), 2) * 100);
                        // Moses Newman 07/10/2021 No longer open and save xlsx files to insure Excel 2016 as new FormatExcel routine 
                        // handles that after proper formating of new Pay -N- Seconds format.
                        PNSIMPORTParamsTableAdapter.DeleteAll();
                        PNSIMPORTParamsTableAdapter.Insert(ConnString, FileName, @"\\DC-IAC\Public\PayNSeconds\");


                        if (SQLBR.RunJob("PNSIMPORT", "Import from PayNSeconds", false))
                        {
                            Thread.Sleep(5000);
                            try
                            {
                                PayNSecondsTableAdapter.Fill(PNS.PayNSeconds);
                            }
                            catch
                            {
                                PayNSecondsTableAdapter.Fill(PNS.PayNSeconds);
                            }
                        }
                        //pkg.Variables["PNSXLSFileName"].Value = FileName;
                        labelDownload.Text = "Executing PNSIMPORT.dtsx for file " + FileNumber.ToString().Trim() + " of " + TotalFiles.ToString().Trim();
                        labelDownload.Refresh();
                        //pkgResults = pkg.Execute();
                        progressBarDownload.Value = Progress;
                    }
                }
                PayNSecondsTableAdapter.Fill(PNS.PayNSeconds);

                // Moses Newman 11/06/2019 Create Rejects Report if any customers are Inactive.
                if (PNS.PayNSeconds.Rows.Count != 0)
                {
                    PNSRejectsTableAdapter.Create();
                    PNSRejectsTableAdapter.FillByAll(PNS.PNSRejects);
                    if (PNS.PNSRejects.Rows.Count > 0)
                    {
                        MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                        Hide();
                        MDImain.CreateFormInstance("ReportViewer", false);
                        ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                        PNSRejects myReportObject = new PNSRejects();
                        myReportObject.SetDataSource(PNS);
                        myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                        myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                        myReportObject.SetParameterValue("gsTitle", "PNS PAYMENT REJECTS REPORT");
                        rptViewer.crystalReportViewer.ReportSource = myReportObject;
                        rptViewer.crystalReportViewer.Refresh();
                        rptViewer.Show();
                    }
                }
                if (SQLBR.RunJob("PNSToPayment", "Insert into Payment", false))
                {
                    Thread.Sleep(5000);
                    try
                    {
                        PAYMENTTableAdapter.FillByAll(PNSIAC.PAYMENT);
                        OPNPAYTableAdapter.FillByAll(PNSIAC.OPNPAY);
                    }
                    catch
                    {
                        PAYMENTTableAdapter.FillByAll(PNSIAC.PAYMENT);
                        OPNPAYTableAdapter.FillByAll(PNSIAC.OPNPAY);
                    }
                }

                labelDownload.Text = "Executing PNSToPayments.dtsx";
                labelDownload.Refresh();
                progressBarDownload.Value = (Int32)100;

                labelDownload.Text = "";
                labelDownload.Refresh();

                ReturnCode = true;
            }
            else
            {
                MessageBox.Show("*** Download Failure(s)! No files updated! ***", "PNSIMPORT FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReturnCode = false;
            }
            PNS.PayNSeconds.Clear();
           
            PayNSecondsTableAdapter.Dispose();
            PAYMENTTableAdapter.Dispose();
           
            PNS.Dispose();
            return ReturnCode;
        }

        public void RenameFile(string originalName, string newName)
        {
            File.Move(originalName, newName);
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            buttonTransfer.Enabled = false;  // Moses Newman 09/14/2020 disable button so that Transfer SSIS Package can only get called once.
            PaymentDataSetTableAdapters.PayNSecondsTableAdapter PayNSecondsTableAdapter = new PaymentDataSetTableAdapters.PayNSecondsTableAdapter();
            PaymentDataSet PNS = new PaymentDataSet();
            if (ReadPNSFile(PNS,true))
            {
                PayNSecondsTableAdapter.Fill(PNS.PayNSeconds);
                String lsUNCROOT = Program.GsDataPath, lsOldFile, lsNewFile, FilePath = @"\\dc-iac\Public\PayNSeconds\";

                var filenames = Directory
                .EnumerateFiles(FilePath, "*.xlsx", SearchOption.TopDirectoryOnly)
                .Select(Path.GetFileName); // <-- note you can shorten the lambda

                if (PNS.PayNSeconds.Rows.Count != 0)
                {
                    foreach (String FileName in filenames)
                    {
                        if (FileName.IndexOf("Template.xlsx") == -1)
                        {
                            lsOldFile = lsUNCROOT + @"PayNSeconds\" + FileName;
                            lsNewFile = lsUNCROOT + @"PayNSeconds\Archive\" + FileName;
                            RenameFile(lsOldFile, lsNewFile);
                        }
                    }
                    MessageBox.Show("*** Import of " + PNS.PayNSeconds.Rows.Count.ToString().Trim() + " PayNSeconds RECORDS complete. ***", "PNS Payments Import");
                }
                else
                    MessageBox.Show("*** NO IVR RECORDS FOUND! ***", "IVR Payments Import");
            }
            PayNSecondsTableAdapter.Dispose();
            PNS.Dispose();
            this.Close();
        }

        private void buttonReImport_Click(object sender, EventArgs e)
        {
            buttonReImport.Enabled = false;  // Moses Newman 09/14/2020 disable button so that Transfer SSIS Package can only get called once.
            PaymentDataSetTableAdapters.PayNSecondsTableAdapter PayNSecondsTableAdapter = new PaymentDataSetTableAdapters.PayNSecondsTableAdapter();
            PaymentDataSet PNS = new PaymentDataSet();
            if (ReadPNSFile(PNS, false))
            {
                PayNSecondsTableAdapter.Fill(PNS.PayNSeconds);
                String lsUNCROOT = Program.GsDataPath, lsOldFile, lsNewFile, FilePath = @"\\dc-iac\Public\PayNSeconds\";

                var filenames = Directory
                .EnumerateFiles(FilePath, "*.xlsx", SearchOption.TopDirectoryOnly)
                .Select(Path.GetFileName); // <-- note you can shorten the lambda

                if (PNS.PayNSeconds.Rows.Count != 0)
                {
                    foreach (String FileName in filenames)
                    {
                        if (FileName.IndexOf("Template.xlsx") == -1)
                        {
                            lsOldFile = lsUNCROOT + @"PayNSeconds\" + FileName;
                            lsNewFile = lsUNCROOT + @"PayNSeconds\Archive\" + FileName;
                            RenameFile(lsOldFile, lsNewFile);
                        }
                    }
                    MessageBox.Show("*** Import of " + PNS.PayNSeconds.Rows.Count.ToString().Trim() + " PayNSeconds RECORDS complete. ***", "PNS Payments Import");
                }
                else
                    MessageBox.Show("*** NO IVR RECORDS FOUND! ***", "IVR Payments Import");
            }
            PayNSecondsTableAdapter.Dispose();
            PNS.Dispose();
            this.Close();
        }


        // Moses Newman 07/10/2021 Format new XLSX files from Pay -N- Seconds to proper format!
        private void FormatExcel(String FilePath, IEnumerable<String> filenames)
        {
            Int32 FileNumber = 0, lastUsedRow = 0;
            String FullFileName, tmpString, FirstName, LastName;

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;
            Excel.Worksheet excelWorkSheet;
            Excel.Workbook excelWorkBook;
            Excel.Range NewRow;
            Excel.Range NewColumn;
            Excel.Range rng;
            foreach (String FileName in filenames)
            {
                if (FileName.IndexOf("Template.xlsx") == -1)
                {
                    FileNumber += 1;
                    // Moses Newman 11/06/2019 open, save, and close xlsx files to make certain EXCEL 2016 format!
                    FullFileName = FilePath + FileName;
                    excelApp.Workbooks.Open(FullFileName);
                    excelWorkBook = excelApp.Workbooks[1];
                    excelWorkSheet = excelApp.Workbooks[1].Worksheets[1];

                    NewRow = excelWorkSheet.Rows[1];
                    NewRow.Insert();

                    NewColumn = excelWorkSheet.Range["F1"];
                    NewColumn.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftToRight,
                                                  Excel.XlInsertFormatOrigin.xlFormatFromRightOrBelow);
                    // Find the last real row
                    lastUsedRow = excelWorkSheet.Cells.Find("*", System.Reflection.Missing.Value,
                                                   System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                                   Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                                                   false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;
                    excelWorkSheet.get_Range("A1:A1").Value = "ReferenceNumber";
                    excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
                    excelWorkSheet.get_Range("B1:B1").Value = "Timestamp";
                    excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
                    excelWorkSheet.get_Range("C1:C1").Value = "PaymentMethod";
                    excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
                    excelWorkSheet.get_Range("D1:D1").Value = "Service";
                    excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";
                    excelWorkSheet.get_Range("E1:E1").Value = "FirstName";
                    excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";
                    excelWorkSheet.get_Range("F1:F1").Value = "LastName";
                    excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";
                    excelWorkSheet.get_Range("G1:G1").Value = "AccountNumber";
                    excelWorkSheet.get_Range("G1:G1").Font.FontStyle = "Bold";
                    excelWorkSheet.get_Range("H1:H1").Value = "Principal";
                    excelWorkSheet.get_Range("H1:H1").Font.FontStyle = "Bold";

                    //Convert Principal column to number
                    rng = excelWorkSheet.get_Range("H2", "H" + lastUsedRow);
                    foreach (Excel.Range range in rng)
                    {
                        if (range.Value != null)
                        {
                            tmpString = range.Value.Trim();
                            range.Value = tmpString;
                        }
                    }
                    rng = excelWorkSheet.get_Range("E2", "E" + lastUsedRow);
                    foreach (Excel.Range range in rng)
                    {
                        if (range.Value != null)
                        {
                            FirstName = range.Value.Remove(range.Value.LastIndexOf(' ')).TrimEnd();
                            LastName = range.Value.Trim();
                            LastName = LastName.Substring(LastName.LastIndexOf(' ') + 1);
                            range.Value = FirstName;
                            range.Offset[0, 1].Value = LastName;
                        }
                    }

                    excelApp.Workbooks[1].Save();
                    excelApp.Workbooks.Close();
                }
            }
            excelApp.Quit();
        }

        // Moses Newman 09/20/2021 Reprint PNS Rejects Report
        private void buttonReprint_Click(object sender, EventArgs e)
        {
            PaymentDataSet PNS = new PaymentDataSet();
            PaymentDataSetTableAdapters.PNSRejectsTableAdapter PNSRejectsTableAdapter = new PaymentDataSetTableAdapters.PNSRejectsTableAdapter();
            
            PNSRejectsTableAdapter.FillByAll(PNS.PNSRejects);
            if (PNS.PNSRejects.Rows.Count > 0)
            {
                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                Hide();
                MDImain.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                PNSRejects myReportObject = new PNSRejects();
                myReportObject.SetDataSource(PNS);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject.SetParameterValue("gsTitle", "PNS PAYMENT REJECTS REPORT");
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
        }
    }
}

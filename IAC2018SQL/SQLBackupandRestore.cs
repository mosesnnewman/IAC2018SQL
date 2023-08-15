using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using DevExpress;
using DevExpress.XtraEditors;
using System.Threading;


// Moses Newman 10/19/2018 Changed SQL to SQL-IAC server.
// Moses Newman 10/21/2018 Changed location of SSIS to SQL-IAC.
namespace IAC2021SQL
{
    class SQLBackupandRestore:IDisposable
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private String lsProgMessage = "";

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if(worker != null)
                {
                    worker.Dispose();
                    worker = null;
                }
            }
        }

        static void StartStopSqlJob(string jobName)
        {

            //Sql server name
            string sqlServerName = "SQL-IAC";  // Moses Newman 10/21/2019
            //Sql server user name and password that have access to sql agent
            string sqlUserName = "sa";
            string sqluserPassword = "password";

            //Create a connection to the Sql Server
            Microsoft.SqlServer.Management.Common.ServerConnection connection =
                new Microsoft.SqlServer.Management.Common.ServerConnection(sqlServerName, sqlUserName, sqluserPassword);

            //Get an instance of the Sql Server
            Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(connection);


            try
            {
                //Get the particular job object using job name
                Microsoft.SqlServer.Management.Smo.Agent.Job job = server.JobServer.Jobs[jobName];
                //Check the job state, if it is not running i.e Idle then start the job
                if (job.CurrentRunStatus == Microsoft.SqlServer.Management.Smo.Agent.JobExecutionStatus.Idle)
                    job.Start();
                if (job.CurrentRunStatus == Microsoft.SqlServer.Management.Smo.Agent.JobExecutionStatus.Executing)
                    job.Stop();



            }
            catch (Exception ex)
            {
                //Log the exception
                Console.WriteLine(ex.StackTrace);

            }

        }

        public Boolean RunJob(String tsJobName,String tsJobLiteral,Boolean tbResultDialog = true)
        {
            SqlConnection jobConnection;
            SqlCommand jobCommand;
            SqlParameter jobReturnValue;
            SqlParameter jobParameter;
            int jobResult;

            jobConnection = new SqlConnection("Data Source=SQL-IAC;Initial Catalog=msdb;Integrated Security=SSPI;TrustServerCertificate=True");
            jobCommand = new SqlCommand("sp_start_job", jobConnection);
            jobCommand.CommandType = CommandType.StoredProcedure;

            jobReturnValue = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            jobReturnValue.Direction = ParameterDirection.ReturnValue;
            jobCommand.Parameters.Add(jobReturnValue);

            jobParameter = new SqlParameter("@job_name", SqlDbType.VarChar);
            jobParameter.Direction = ParameterDirection.Input;
            jobCommand.Parameters.Add(jobParameter);
            jobParameter.Value = tsJobName;

            jobConnection.Open();
            try
            {
                jobCommand.ExecuteNonQuery();
            }
            // Moses Newman 08/08/2023
            catch (Microsoft.Data.SqlClient.SqlException ex) 
            {
                Thread.Sleep(5000);
                jobCommand.ExecuteNonQuery();
            }
            jobResult = (Int32)jobCommand.Parameters["@RETURN_VALUE"].Value;
            jobConnection.Close();

            if (tbResultDialog)
                switch (jobResult)
                {
                    case 0:
                        MessageBox.Show("SQL Server Agent job, " + tsJobLiteral + " started successfully.");
                        return true;
                    default:
                        MessageBox.Show("SQL Server Agent job, " + tsJobLiteral + " failed to start.");
                        return false;
                }
            else
                if (jobResult == 0)
                    return true;
                else
                    return false;
        }

        public void VehicleExtractJob()
        {
            RunJob("CreateVerifactoExtract", "CreateVerifactoExtract",false);
        }
        public void VERIFACTOJob()
        {
            RunJob("ImportVERIFACTOFile", "ImportVERIFACTOFile",false);
        }

        public void LeeMasonJob()
        {
            RunJob("ImportLeeMasonFile", "ImportLeeMasonFile");
        }

        // Moses Newman 01/13/2014 Added new job to Create CustomerRepoExtract.xls EXCEL file
        public void CustomerRepoExtractJob()
        {
            RunJob("CreateRepoExtract", "", false);
        }

        public void LeeMasonImportPackage()
        {
            string pkgLocation;
            Package pkg;
            Microsoft.SqlServer.Dts.Runtime.Application app;
            DTSExecResult pkgResults;

            pkgLocation =
              @"\\SQL-IAC\SSISPackages" +
              @"\LeeMason.dtsx";
            app = new Microsoft.SqlServer.Dts.Runtime.Application();
            pkg = app.LoadPackage(pkgLocation, null);
            pkgResults = pkg.Execute();
            MessageBox.Show("The Results are: " + pkgResults);
        }

        public void VehicleExtractPackage()
        {
            string pkgLocation;
            Package pkg;
            Microsoft.SqlServer.Dts.Runtime.Application app;
            DTSExecResult pkgResults;

            pkgLocation =
              @"\\SQL-IAC\SSISPackages" +
              @"\Create Vehicle Extract.dtsx";
            app = new Microsoft.SqlServer.Dts.Runtime.Application();
            pkg = app.LoadPackage(pkgLocation, null);
            pkgResults = pkg.Execute();
            MessageBox.Show("The Results are: " + pkgResults);
        }

        public Boolean PrePostBackup()
        {
            IACDataSet BackupDataSet = new IACDataSet();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();

            String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), DataBase = "", sourcePath = "",targetPath = "", deletePath = "";

            DataPathTableAdapter.Fill(BackupDataSet.DataPath);
            DataBase = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16,
                        (lsConnect.IndexOf(";", lsConnect.IndexOf("INITIAL CATALOG=") + 16) - (lsConnect.IndexOf("INITIAL CATALOG=") + 16)));

            //sourcePath = BackupDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();
            sourcePath = @"\\SQL-IAC\Backup";
            targetPath = sourcePath;
            deletePath = sourcePath;

            targetPath += @"\PrePostBackup\";
            deletePath += @"\PrePostBackup";

            if (File.GetLastWriteTime(targetPath).Date != DateTime.Now.Date)
            {
                if (System.IO.Directory.Exists(targetPath))
                    FileSystem.DeleteDirectory(deletePath, DeleteDirectoryOption.DeleteAllContents);
                Directory.CreateDirectory(deletePath);
                PrePostSQLServerBackup(targetPath,DataBase);
                BackupDataSet.Clear();
                BackupDataSet.Dispose();
                DataPathTableAdapter.Dispose();
                return true;
            }
            else
            {
                var result = MessageBox.Show("*** THERE ALREADY IS A PRE-POST BACKUP FOR TODAY.  DO YOU REALLY WANT TO OVERWRITE IT? ***", "Overwrite Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (Directory.Exists(targetPath))
                        FileSystem.DeleteDirectory(deletePath, DeleteDirectoryOption.DeleteAllContents);
                    Directory.CreateDirectory(deletePath);
                    PrePostSQLServerBackup(targetPath, DataBase); BackupDataSet.Clear();
                    BackupDataSet.Dispose();
                    DataPathTableAdapter.Dispose();
                    return true;
                }
                else
                {
                    BackupDataSet.Clear();
                    BackupDataSet.Dispose();
                    DataPathTableAdapter.Dispose();
                    return true; // Not an error already backed up
                }
            }
        }

        // 04/10/2012 Moses Newman Add General Backup on Demand Function 
        public Boolean GeneralBackup()
        {
            XtraFolderBrowserDialog FolderBrowser = new XtraFolderBrowserDialog();

            IACDataSet BackupDataSet = new IACDataSet();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();

            String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), DataBase = "", sourcePath = "", targetPath = "", deletePath = "";

            DataPathTableAdapter.Fill(BackupDataSet.DataPath);
            DataBase = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16,
                        (lsConnect.IndexOf(";", lsConnect.IndexOf("INITIAL CATALOG=") + 16) - (lsConnect.IndexOf("INITIAL CATALOG=") + 16)));

            //sourcePath = BackupDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();
            sourcePath = @"\\SQL-IAC\Backup\";
            targetPath = sourcePath;
            deletePath = sourcePath;
            
            targetPath += "PrePostBackup" + @"\";
            deletePath += @"PrePostBackup";
            
            FolderBrowser.UseParentFormIcon = true;
            FolderBrowser.DialogStyle = DevExpress.Utils.CommonDialogs.FolderBrowserDialogStyle.Compact;
            
            FolderBrowser.SelectedPath = targetPath;
            FolderBrowser.Description = "Select folder to BACKUP TO.";
            FolderBrowser.ShowDialog();
            targetPath = FolderBrowser.SelectedPath;
            deletePath = targetPath;

            if (Directory.Exists(targetPath))
            {
                if (File.GetLastWriteTime(targetPath).Date != DateTime.Now.Date)
                {
                    if (System.IO.Directory.Exists(targetPath))
                        FileSystem.DeleteDirectory(deletePath, DeleteDirectoryOption.DeleteAllContents);
                    Directory.CreateDirectory(deletePath);
                    PrePostSQLServerBackup(targetPath, DataBase);
                    BackupDataSet.Clear();
                    BackupDataSet.Dispose();
                    DataPathTableAdapter.Dispose();
                    return true;
                }
                else
                {
                    var result = MessageBox.Show("*** THERE ALREADY IS A BACKUP FOR TODAY IN THIS FOLDER.  DO YOU REALLY WANT TO OVERWRITE IT? ***", "Overwrite Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (Directory.Exists(targetPath))
                            FileSystem.DeleteDirectory(deletePath, DeleteDirectoryOption.DeleteAllContents);
                        Directory.CreateDirectory(deletePath);
                        PrePostSQLServerBackup(targetPath, DataBase);
                        BackupDataSet.Clear();
                        BackupDataSet.Dispose();
                        DataPathTableAdapter.Dispose();
                        return true;
                    }
                    else
                    {
                        BackupDataSet.Clear();
                        BackupDataSet.Dispose();
                        DataPathTableAdapter.Dispose();
                        return true; // Not an error already backed up
                    }
                }
            }
            else
            {
                MessageBox.Show("Source path does not exist!");
                BackupDataSet.Clear();
                BackupDataSet.Dispose();
                DataPathTableAdapter.Dispose();
                return false;
            }
        }

        public Boolean PrePostSQLServerBackup(String tsDestination, String tsDataBase)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)System.Windows.Forms.Application.OpenForms["MDIIAC2013"];
            MDIMain.CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Text = "Backup Microsoft SQL Server IAC2012 Database";
            lfrm.lblProgress.Text = "Backing up Microsoft SQL Server IAC2012 Database";

            SqlConnection.ClearAllPools();
            SqlConnection DataConn;

            DataConn = new SqlConnection();
            DataConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            DataConn.Open();

            Server srv;
            ServerConnection SrvConn = new ServerConnection(DataConn);
            srv = new Server(SrvConn);

            Database db;
            db = srv.Databases[tsDataBase];

            RecoveryModel recoverymod = db.DatabaseOptions.RecoveryModel;

            Backup bk = new Backup();
            //tsDestination = @"\\SQL-IAC\Backup";
            bk.Action = BackupActionType.Database;
            bk.BackupSetDescription = "Full Prepost Backup of IAC2016";
            bk.BackupSetName = "Prepost IAC2016 Backup";
            bk.Database = tsDataBase;

            BackupDeviceItem bdi = new BackupDeviceItem(tsDestination + @"\IAC2016_BACKUP.BAK", DeviceType.File);
            bk.Devices.Add(bdi);

            bk.Incremental = false;

            DateTime backupdate = DateTime.Now.Date;

            bk.ExpirationDate = backupdate;

            bk.LogTruncation = BackupTruncateLogType.Truncate;

            bk.PercentCompleteNotification = 10;
            bk.PercentComplete += new Microsoft.SqlServer.Management.Smo.PercentCompleteEventHandler(worker_BackupSQLProgressChanged);
            bk.Complete += new Microsoft.SqlServer.Management.Common.ServerMessageEventHandler(worker_RunWorkerCompleted);

            try
            {
                bk.SqlBackupAsync(srv);
            }
            //Catch the SMO exception 
            catch (SmoException smoex)
            {
                String lsMessages = "";
                //Display the SMO exception message. 
                lsMessages += smoex.Message;
                //Display the sequence of non-SMO exceptions that caused the SMO exception. 
                Exception ex; 
                ex = smoex.InnerException; 
                while (!object.ReferenceEquals(ex, (null))) 
                { 
                    lsMessages += '\n' + ex.Message;
                    ex = ex.InnerException;  
                }

                MessageBox.Show("There was a Microsoft SQL Server Management Objects exception: " + lsMessages);
                SrvConn.Disconnect();
                SrvConn = null;
                srv = null;
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a general exception: " + ex.Message);
                SrvConn.Disconnect();
                SrvConn = null;
                srv = null;
                return false;
            }
            lfrm.ShowDialog();
            lfrm.Close();
            SrvConn.Disconnect();
            SrvConn = null;
            srv = null;
            DataConn.Close();
            return true;
        }

        public Boolean PrePostSQLServerRestore(String tsSource, String tsDataBase, String tsServer)
        {
            tsSource += @"\";
            MDIIAC2013 MDIMain = (MDIIAC2013)System.Windows.Forms.Application.OpenForms["MDIIAC2013"];
            MDIMain.CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Text = "Restore Microsoft SQL Server IAC2018 Database";
            lfrm.lblProgress.Text = "Restoring Microsoft SQL Server IAC2018 Database";

            IACDataSet BackupDataSet = new IACDataSet();


            Server srv;
            srv = new Server(tsServer);

            Database db = srv.Databases[tsDataBase];
            db.UserAccess = DatabaseUserAccess.Single;
            db.Alter(TerminationClause.RollbackTransactionsImmediately);

            //db.Drop();

            Restore rst = new Restore();

            rst.Action = RestoreActionType.Database;
            rst.Database = tsDataBase;
            rst.ReplaceDatabase = true;

            BackupDeviceItem bdi = new BackupDeviceItem(tsSource + "IAC2016_BACKUP.BAK", DeviceType.File);
            rst.Devices.Add(bdi);

            rst.PercentCompleteNotification = 10;
            rst.PercentComplete += new Microsoft.SqlServer.Management.Smo.PercentCompleteEventHandler(worker_RestoreSQLProgressChanged);
            rst.Complete += new Microsoft.SqlServer.Management.Common.ServerMessageEventHandler(worker_RunWorkerCompleted);

            try
            {
                rst.SqlRestore(srv);
            }
            //Catch the SMO exception 
            catch (SmoException smoex)
            {
                String lsMessages = "";
                //Display the SMO exception message. 
                lsMessages += smoex.Message;
                //Display the sequence of non-SMO exceptions that caused the SMO exception. 
                Exception ex;
                ex = smoex.InnerException;
                while (!object.ReferenceEquals(ex, (null)))
                {
                    lsMessages += '\n' + ex.Message;
                    ex = ex.InnerException;
                }

                MessageBox.Show("There was a Microsoft SQL Server Management Objects exception: " + lsMessages);
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a general exception: " + ex.Message);
                return false;
            }
            lfrm.ShowDialog();
            lfrm.Close();
            db = srv.Databases[tsDataBase];
            db.UserAccess = DatabaseUserAccess.Multiple;
            db.Alter(TerminationClause.RollbackTransactionsImmediately);
            return true;
        }


        // 04/10/2012 Moses Newman Add General Restore on Demand Function 
        public Boolean GeneralRestore()
        {
            XtraFolderBrowserDialog FolderBrowser = new XtraFolderBrowserDialog();

            IACDataSet BackupDataSet = new IACDataSet();
            IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();

            String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), DataBase = "", sourcePath = "",lsServer = "";

            DataPathTableAdapter.Fill(BackupDataSet.DataPath);
            DataBase = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16,
                        (lsConnect.IndexOf(";", lsConnect.IndexOf("INITIAL CATALOG=") + 16) - (lsConnect.IndexOf("INITIAL CATALOG=") + 16)));

            lsServer = lsConnect.Substring(lsConnect.IndexOf("DATA SOURCE=") + 12,
                        (lsConnect.IndexOf(";", lsConnect.IndexOf("DATA SOURCE=") + 12) - (lsConnect.IndexOf("DATA SOURCE=") + 12)));

            //sourcePath = BackupDataSet.DataPath.Rows[0].Field<String>("Path").TrimEnd();
            sourcePath = @"\\SQL-IAC\Backup\";
            //targetPath = sourcePath;
            //deletePath = sourcePath;

            sourcePath += @"PrePostBackup\";
            FolderBrowser.SelectedPath = sourcePath;
            FolderBrowser.Description = "Select folder to RESTORE FROM.";
            FolderBrowser.ShowDialog();
            sourcePath = FolderBrowser.SelectedPath;

            if (Directory.Exists(sourcePath))
            {
                PrePostSQLServerRestore(sourcePath,DataBase,lsServer);
                BackupDataSet.Clear();
                BackupDataSet.Dispose();
                DataPathTableAdapter.Dispose();
                return true;
            }
            else
            {
                MessageBox.Show("Source path does not exist!");
                BackupDataSet.Clear();
                BackupDataSet.Dispose();
                DataPathTableAdapter.Dispose();
                return false;
            }
        }

        private void worker_RunWorkerCompleted(object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)System.Windows.Forms.Application.OpenForms["MDIIAC2013"];
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Invoke(new closeProgress(CloseProgressDialog));
        }

        private void worker_BackupSQLProgressChanged(object sender, Microsoft.SqlServer.Management.Smo.PercentCompleteEventArgs e)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)System.Windows.Forms.Application.OpenForms["MDIIAC2013"];
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Invoke(new displayBackupProgress_delegate(displayBackupProgress), e.Percent);
        }

        private void worker_RestoreSQLProgressChanged(object sender, Microsoft.SqlServer.Management.Smo.PercentCompleteEventArgs e)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)System.Windows.Forms.Application.OpenForms["MDIIAC2013"];
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Invoke(new displayRestoreProgress_delegate(displayRestoreProgress), e.Percent);
        }

        private delegate void displayBackupProgress_delegate(int progress);
        private delegate void displayRestoreProgress_delegate(int progress);
        private delegate void closeProgress();

        private void displayBackupProgress(int progress)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)System.Windows.Forms.Application.OpenForms["MDIIAC2013"];
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.QueryprogressBar.EditValue = (progress < 101) ? progress : 100;
            lfrm.lblProgress.Text = "Backing up IAC2012 SQL Database Objects" + "\n" + lsProgMessage;
        }

        private void displayRestoreProgress(int progress)
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)System.Windows.Forms.Application.OpenForms["MDIIAC2013"];
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.QueryprogressBar.EditValue = (progress < 101) ? progress : 100;
            lfrm.lblProgress.Text = "Restoring IAC2012 SQL Database Objects" + "\n" + lsProgMessage;
        }

        private void CloseProgressDialog()
        {
            MDIIAC2013 MDIMain = (MDIIAC2013)System.Windows.Forms.Application.OpenForms["MDIIAC2013"];
            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Close();
        }
    }
}

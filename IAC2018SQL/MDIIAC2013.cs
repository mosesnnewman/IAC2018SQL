using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;

using Microsoft.SqlServer.Dts.Runtime;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;


namespace IAC2021SQL
{
    public partial class MDIIAC2013 : Form
    {
        private int childFormNumber = 0;
        private BackgroundWorker worker;
        public Form frm;
        private IACDataSet ReportData;

        public MDIIAC2013()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        public void CreateFormInstance(String tsFormName, bool tbIsModal, bool tbShowAuto = true,bool tbCenter = false)
        {
            // Get current assembly
            Assembly frmMain = Assembly.GetEntryAssembly();
            // Get Type of your form
            Type formType = frmMain.GetType("IAC2021SQL." + tsFormName.TrimEnd());
            // Create instance of form
            object pc = Activator.CreateInstance(formType);
            // Cast to Form class
            frm = (Form)pc;
            if (!tbCenter)
                frm.StartPosition = FormStartPosition.Manual;
            else
                frm.StartPosition = FormStartPosition.CenterParent;
            // Show Form
            if (!tbIsModal)
            {
                if (!tbCenter)
                    frm.Location = new Point(0, 0);
                frm.MdiParent = this;
                if (tbShowAuto)
                    frm.Show();
            }
            else
            {
                if(!tbCenter)
                    frm.Location = new Point(2, 47);
                if (tbShowAuto)
                {
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
            }
        }

        
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutIAC2021SQL newMDIChild = new AboutIAC2021SQL();
            newMDIChild.ShowDialog();
        }

        private void masterContingentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("OpenMasterContingentMaintenance", false);
        }

        private void MDIIAC2013_Load(object sender, EventArgs e)
        {
            String lsConnect = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper(), DataBase = "";
            Hide();
            SplashForm frmSplash = new SplashForm();
            frmSplash.Show();
            frmSplash.Update();
            Thread.Sleep(5000);
            frmSplash.Close();
            LoginForm frmLogin = new LoginForm();
            frmLogin.ShowDialog();
            if (frmLogin.gbLoginCorrect && Program.LockfileShare())
            {
                DataBase = lsConnect.Substring(lsConnect.IndexOf("INITIAL CATALOG=") + 16,
                        (lsConnect.IndexOf(";", lsConnect.IndexOf("INITIAL CATALOG=") + 16) - (lsConnect.IndexOf("INITIAL CATALOG=") + 16)));
                frmLogin.Dispose();
                Text = "IAC 2021 SQL " + "(Hello: " + Program.gsUserName.ToString().ToUpper() + ") [DataBase: " + DataBase + "]";
                if (Program.gsUserID == "MNN")
                    mosesFixesToolStripMenuItem.Visible = true;
                else
                    mosesFixesToolStripMenuItem.Visible = false;
                Visible = true;
            }
            else
            {
                frmLogin.Dispose();
                Close();
            }
            PerformAutoScale();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) 
        {
            frm.Close(); 
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            lfrm.QueryprogressBar.Value = e.ProgressPercentage;

            if(Program.gsProgMessage != "")
                lfrm.lblProgress.Text = Program.gsProgMessage;
        }
        
        private void worker_DoClosedNewBusinessPosting(object sender, DoWorkEventArgs e)
        {
            Program.NewClosedCustomerPosting(ref worker);
        }

        private void worker_DoOpenNewBusinessPosting(object sender, DoWorkEventArgs e)
        {
            Program.NewOpenCustomerPosting(ref worker);
        }

        private void openEditListRPT0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNCUSTTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();

            CustomerTableAdapter.FillByNonPosted(ReportData.OPNCUST);
            DEALERTableAdapter.FillByNonPostedCustomers(ReportData.OPNDEALR);
            OpenCustomerEditList myReportObject = new OpenCustomerEditList();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();

        }

        private void closedEndPaymentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();

            CustomerTableAdapter.FillByUnPostedPayments(ReportData.CUSTOMER);
            DEALERTableAdapter.FillByUnPostedPayments(ReportData.DEALER);
            PAYMENTTableAdapter.CustomizeFill("SELECT * FROM PAYMENT");
            PAYMENTTableAdapter.CustomFillBy(ReportData.PAYMENT);
            PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(ReportData.PAYCODE);
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

            ClosedPaymentEditList myReportObject = new ClosedPaymentEditList();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void worker_DoNewClosedPaymentPostingWithoutPost(object sender, DoWorkEventArgs e)
        {
            ClosedPaymentPosting CPaymentPosting = new ClosedPaymentPosting();
            //CPaymentPosting.CopyAmortizetoAmortTemp(ReportData, ref worker);
            CPaymentPosting.NewClosedPaymentPosting(ref ReportData, ref worker);
            CPaymentPosting.Dispose();
            CPaymentPosting = null;
        }

        private void worker_DoNewOpenPaymentPostingWithoutPost(object sender, DoWorkEventArgs e)
        {
            OpenPaymentPosting OPaymentPosting = new OpenPaymentPosting();
            OPaymentPosting.NewOpenPaymenPosting(ref ReportData, ref worker);
            OPaymentPosting.Dispose();
            OPaymentPosting = null;
        }

        private void worker_DoNewClosedPaymentPostingWithPost(object sender, DoWorkEventArgs e)
        {
            ClosedPaymentPosting CPaymentPosting = new ClosedPaymentPosting();
            //CPaymentPosting.CopyAmortizetoAmortTemp(ReportData, ref worker);
            CPaymentPosting.NewClosedPaymentPosting(ref ReportData, ref worker,true);
        }

        private void worker_DoNewOpenPaymentPostingWithPost(object sender, DoWorkEventArgs e)
        {
            OpenPaymentPosting OPaymentPosting = new OpenPaymentPosting();
            OPaymentPosting.NewOpenPaymenPosting(ref ReportData, ref worker, true);
        }

        private void customerMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmCustMaint", false);
        }

        private void dealerMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("ClosedDealerMaintenance", false);
        }

        private void CustomersMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenCustMaint", false);
        }

        private void dealersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenDealerMaintenance", false);
        }

        private void deepSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Moses Newman 02/21/2018 change to use new generic lookup form
            //CreateFormInstance("frmGeneralCustomerLookup", false);
            CreateFormInstance("frmCustomerLookup", false);
        }

        private void dealerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormClosedDealerContingentMaintenance", false);
        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("ClosedMasterContingentMaintenance", false);
        }

        private void paymentsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateFormInstance("formClosedPayment", false);
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("formOpenPayment", false);
        }

        private void amortizartionScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("AmortDialog", false);
        }

        private void newCustomerEditListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();

            CustomerTableAdapter.FillByNonPosted(ReportData.CUSTOMER);
            DEALERTableAdapter.FillByNonPostedCustomers(ReportData.DEALER);
            ClosedCustomerEditList myReportObject = new ClosedCustomerEditList();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void paymentDisbursementEditListIACRPT08ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportData = new IACDataSet();
            ReportData.Clear();

            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
            IACDataSetTableAdapters.PaymentDistributionTableAdapter PaymentDistributionTableAdapter = new IACDataSetTableAdapters.PaymentDistributionTableAdapter();
            IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();

            PAYMENTTableAdapter.FillByAll(ReportData.PAYMENT);
            if (ReportData.PAYMENT.Rows.Count == 0)
            {
                MessageBox.Show("*** There are NO UNPOSTED Closed End Payments! ***");
                return;
            }
            WS_DEALER_PAYTableAdapter.Fill(ReportData.WS_DEALER_PAY);
            PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(ReportData.PAYCODE);
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoNewClosedPaymentPostingWithoutPost);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Closed Payments Posting No Update";
            lfrm.lblProgress.Text = "Posting Closed Payments Without Update";
            lfrm.ShowDialog();

            PaymentDistributionTableAdapter.FillByPayments(ReportData.PaymentDistribution);
            MasterTotalTempTableAdapter.Fill(ReportData.MasterTotalTemp);
            DEALERTableAdapter.FillByUnPostedPayments(ReportData.DEALER);

            ClosedPaymentBalanceJournal myReportObject = new ClosedPaymentBalanceJournal();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gsFormTitle", "Closed Payment Receipts Balance Journal - No Update");

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
            ReportData.Clear();
            ReportData.Dispose();
        }

        private void dealerContingentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormOpenDealerContingentMaintenance", false);
        }

        private void newBusinessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoClosedNewBusinessPosting);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Closed New Account Posting";
            lfrm.lblProgress.Text = "Posting new closed end accounts";
            lfrm.ShowDialog();
        }

        private void paymentsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
            IACDataSetTableAdapters.PaymentDistributionTableAdapter PaymentDistributionTableAdapter = new IACDataSetTableAdapters.PaymentDistributionTableAdapter();
            IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();

            PAYMENTTableAdapter.FillByAll(ReportData.PAYMENT);
            if (ReportData.PAYMENT.Rows.Count == 0)
            {
                MessageBox.Show("*** There are NO UNPOSTED Closed End Payments! ***");
                return;
            }
            WS_DEALER_PAYTableAdapter.Fill(ReportData.WS_DEALER_PAY);
            PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(ReportData.PAYCODE);
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoNewClosedPaymentPostingWithPost);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Closed Payments Posting WITH Update";
            lfrm.lblProgress.Text = "Posting Closed Payments WITH Update";
            lfrm.ShowDialog();

            PaymentDistributionTableAdapter.FillByPayments(ReportData.PaymentDistribution);
            MasterTotalTempTableAdapter.Fill(ReportData.MasterTotalTemp);
            DEALERTableAdapter.FillByUnPostedPayments(ReportData.DEALER);

            ClosedPaymentBalanceJournal myReportObject = new ClosedPaymentBalanceJournal();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gsFormTitle", "Closed Payment Receipts Balance Journal - With Update");

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void newCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoOpenNewBusinessPosting);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Open Account Posting";
            lfrm.lblProgress.Text = "Posting new open end accounts";
            lfrm.ShowDialog();
        }

        private void paymentReceiptsBalanceJournalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();
            IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter OPN_WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
            IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();
            IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter OpenPaymentDistributionTableAdapter = new IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter();

            OPNPAYTableAdapter.FillByAll(ReportData.OPNPAY);
            if (ReportData.OPNPAY.Rows.Count == 0)
            {
                MessageBox.Show("*** There are NO UNPOSTED Open End Payments! ***");
                return;
            }
            OPN_WS_DEALER_PAYTableAdapter.Fill(ReportData.OPN_WS_DEALER_PAY);
            PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(ReportData.PAYCODE);
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoNewOpenPaymentPostingWithoutPost);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Open Payments Posting No Update";
            lfrm.lblProgress.Text = "Posting Open Payments Without Update";
            lfrm.ShowDialog();

            OpenPaymentDistributionTableAdapter.FillByPayments(ReportData.OpenPaymentDistribution);
            MasterTotalTempTableAdapter.Fill(ReportData.MasterTotalTemp);
            OPNDEALRTableAdapter.FillBYUnPostedPayments(ReportData.OPNDEALR);

            OpenPaymentBalanceJournal myReportObject = new OpenPaymentBalanceJournal();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gsFormTitle", "Open Payment Receipts Balance Journal - No Update");

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
            ReportData.Clear();
            ReportData.Dispose();
        }

        private void paymentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();
            IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter OPN_WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
            IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();
            IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter OpenPaymentDistributionTableAdapter = new IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter();

            OPNPAYTableAdapter.FillByAll(ReportData.OPNPAY);
            if (ReportData.OPNPAY.Rows.Count == 0)
            {
                MessageBox.Show("*** There are NO UNPOSTED Open End Payments! ***");
                return;
            }
            OPN_WS_DEALER_PAYTableAdapter.Fill(ReportData.OPN_WS_DEALER_PAY);
            PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(ReportData.PAYCODE);
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoNewOpenPaymentPostingWithPost);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Open Payments Posting With Update";
            lfrm.lblProgress.Text = "Posting Open Payments With Update";
            lfrm.ShowDialog();

            OpenPaymentDistributionTableAdapter.FillByPayments(ReportData.OpenPaymentDistribution);
            MasterTotalTempTableAdapter.Fill(ReportData.MasterTotalTemp);
            OPNDEALRTableAdapter.FillBYUnPostedPayments(ReportData.OPNDEALR);

            OpenPaymentBalanceJournal myReportObject = new OpenPaymentBalanceJournal();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gsFormTitle", "Open Payment Receipts Balance Journal - With Update");

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
            ReportData.Clear();
            ReportData.Dispose();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void newCustomerEditListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNCUSTTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNRATETableAdapter OPNRATETableAdapter = new IACDataSetTableAdapters.OPNRATETableAdapter();

            CustomerTableAdapter.FillByNonPosted(ReportData.OPNCUST);
            DEALERTableAdapter.FillByNonPostedCustomers(ReportData.OPNDEALR);
            OPNRATETableAdapter.FillAll(ReportData.OPNRATE);

            OpenCustomerEditList myReportObject = new OpenCustomerEditList();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void newBusinessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("QueryProgress", true, false, true);
                QueryProgress lfrm;
                lfrm = (QueryProgress)frm;
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler(worker_DoClosedNewBusinessPosting);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.RunWorkerAsync();
                lfrm.Text = "Closed New Account Posting";
                lfrm.lblProgress.Text = "Posting new closed end accounts";
                lfrm.ShowDialog();
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void paymentsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore Backup = new SQLBackupandRestore();
            if (Program.LockfileExclusive())
            {
                if (Backup.PrePostBackup())
                {
                    ReportData = new IACDataSet();
                    IACDataSetTableAdapters.PaymentTypeCodeSummarySelectTableAdapter PaymentTypeCodeSummarySelectTableAdapter = new IACDataSetTableAdapters.PaymentTypeCodeSummarySelectTableAdapter();
                    IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
                    IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter();
                    IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
                    IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
                    IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                    IACDataSetTableAdapters.PaymentDistributionTableAdapter PaymentDistributionTableAdapter = new IACDataSetTableAdapters.PaymentDistributionTableAdapter();
                    IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();

                    PAYMENTTableAdapter.FillByAll(ReportData.PAYMENT);
                    PaymentTypeCodeSummarySelectTableAdapter.Fill(ReportData.PaymentTypeCodeSummarySelect);

                    if (ReportData.PAYMENT.Rows.Count == 0)
                    {
                        MessageBox.Show("*** There are NO UNPOSTED Closed End Payments! ***");
                        return;
                    }

                    // Moses Newman 01/19/2018 Add TotalIVR, TotalIVRAmex, TotalIVRFees
                    Object loTotalIVR = null, loTotalIVRAmex = null, loTotalIVRFees = null;
                    Decimal lnTotalIVR = 0, lnTotalIVRAmex = 0, lnTotalIVRFees = 0;
                    loTotalIVR = PAYMENTTableAdapter.IVRSUM();
                    loTotalIVRAmex = PAYMENTTableAdapter.AMEXTOT();
                    loTotalIVRFees = PAYMENTTableAdapter.IVRFEETOT();
                    lnTotalIVR = loTotalIVR != null ? (Decimal)loTotalIVR : lnTotalIVR;
                    lnTotalIVRAmex = loTotalIVRAmex != null ? (Decimal)loTotalIVRAmex : lnTotalIVRAmex;
                    lnTotalIVRFees = loTotalIVRFees != null ? (Decimal)loTotalIVRFees : lnTotalIVRFees;
                    WS_DEALER_PAYTableAdapter.ClearBeforeFill = true;
                    WS_DEALER_PAYTableAdapter.Fill(ReportData.WS_DEALER_PAY);
                    PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
                    PAYCODETableAdapter.Fill(ReportData.PAYCODE);
                    ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

                    CreateFormInstance("QueryProgress", true, false, true);
                    QueryProgress lfrm;
                    lfrm = (QueryProgress)frm;
                    worker = new BackgroundWorker();
                    worker.WorkerReportsProgress = true;
                    worker.DoWork += new DoWorkEventHandler(worker_DoNewClosedPaymentPostingWithPost);
                    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                    worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                    worker.RunWorkerAsync();
                    lfrm.Text = "Closed Payments Posting WITH Update";
                    lfrm.lblProgress.Text = "Posting Closed Payments WITH Update";
                    lfrm.ShowDialog();

                    PaymentDistributionTableAdapter.FillByPayments(ReportData.PaymentDistribution);
                    MasterTotalTempTableAdapter.Fill(ReportData.MasterTotalTemp);


                    ClosedPaymentBalanceJournal myReportObject = new ClosedPaymentBalanceJournal();
                    myReportObject.SetDataSource(ReportData);
                    myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                    myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                    myReportObject.SetParameterValue("TotalIVR", lnTotalIVR);
                    myReportObject.SetParameterValue("TotalIVRAmex", lnTotalIVRAmex);
                    myReportObject.SetParameterValue("TotalIVRFees", lnTotalIVRFees);
                    myReportObject.SetParameterValue("gsFormTitle", "Closed Payment Receipts Balance Journal - With Update");

                    CreateFormInstance("ReportViewer", false);
                    ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
                    rptViewr.crystalReportViewer.ReportSource = myReportObject;
                    rptViewr.crystalReportViewer.Refresh();
                    rptViewr.Show();
                    ReportData.Clear();
                    ReportData.Dispose();
                    Program.ReleaseExclusiveLock();
                    // Moses Newman 08/05/2014 Relock current in shared mode!
                    Program.LockfileShare();
                }
            }
        }

        private void amortizationScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("AmortDialog", false);
        }

        private void newCustomerEditListIACRPT01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();

            CustomerTableAdapter.FillByNonPosted(ReportData.CUSTOMER);
            if (ReportData.CUSTOMER.Rows.Count < 1)
            {
                MessageBox.Show("*** There are NO CUSTOMERS IN NEW BUSINESS! ***");
                return;
            }
                
            DEALERTableAdapter.FillByNonPostedCustomers(ReportData.DEALER);
            ClosedCustomerEditList myReportObject = new ClosedCustomerEditList();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        // Closed Report 07 Paymnent Receipts Balance Journal without post
        public void paymentReceiptsBalanceJurnalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportData = new IACDataSet();
            IACDataSetTableAdapters.PaymentTypeCodeSummarySelectTableAdapter PaymentTypeCodeSummarySelectTableAdapter = new IACDataSetTableAdapters.PaymentTypeCodeSummarySelectTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
            IACDataSetTableAdapters.PaymentDistributionTableAdapter PaymentDistributionTableAdapter = new IACDataSetTableAdapters.PaymentDistributionTableAdapter();
            IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();

            PAYMENTTableAdapter.FillByAll(ReportData.PAYMENT);
            PaymentTypeCodeSummarySelectTableAdapter.Fill(ReportData.PaymentTypeCodeSummarySelect);
            if (ReportData.PAYMENT.Rows.Count == 0)
            {
                MessageBox.Show("*** There are NO UNPOSTED Closed End Payments! ***");
                return;
            }
            WS_DEALER_PAYTableAdapter.ClearBeforeFill = true;
            WS_DEALER_PAYTableAdapter.Fill(ReportData.WS_DEALER_PAY);
            PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(ReportData.PAYCODE);
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoNewClosedPaymentPostingWithoutPost);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Closed Payments Posting No Update";
            lfrm.lblProgress.Text = "Posting Closed Payments Without Update";
            lfrm.ShowDialog();

            PaymentDistributionTableAdapter.FillByPayments(ReportData.PaymentDistribution);
            MasterTotalTempTableAdapter.Fill(ReportData.MasterTotalTemp);
            // Moses Newman 01/19/2018 Add TotalIVR, TotalIVRAmex, TotalIVRFees
            Object loTotalIVR = null, loTotalIVRAmex = null, loTotalIVRFees = null;
            Decimal lnTotalIVR = 0, lnTotalIVRAmex = 0, lnTotalIVRFees = 0;
            loTotalIVR = PAYMENTTableAdapter.IVRSUM();
            loTotalIVRAmex = PAYMENTTableAdapter.AMEXTOT();
            loTotalIVRFees = PAYMENTTableAdapter.IVRFEETOT();
            lnTotalIVR = loTotalIVR != null ? (Decimal)loTotalIVR:lnTotalIVR;
            lnTotalIVRAmex = loTotalIVRAmex != null ? (Decimal)loTotalIVRAmex : lnTotalIVRAmex;
            lnTotalIVRFees = loTotalIVRFees != null ? (Decimal)loTotalIVRFees : lnTotalIVRFees;
                 
            ClosedPaymentBalanceJournal myReportObject = new ClosedPaymentBalanceJournal();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("TotalIVR", lnTotalIVR);
            myReportObject.SetParameterValue("TotalIVRAmex", lnTotalIVRAmex);
            myReportObject.SetParameterValue("TotalIVRFees", lnTotalIVRFees);
            myReportObject.SetParameterValue("gsFormTitle", "Closed Payment Receipts Balance Journal - No Update");

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
            ReportData.Clear();
            ReportData.Dispose();
        }

        private void newBusinessToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("QueryProgress", true, false, true);
                QueryProgress lfrm;
                lfrm = (QueryProgress)frm;
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler(worker_DoOpenNewBusinessPosting);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.RunWorkerAsync();
                lfrm.Text = "Open Account Posting";
                lfrm.lblProgress.Text = "Posting new open end accounts";
                lfrm.ShowDialog();
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void paymentsToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                ReportData = new IACDataSet();
                IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();
                IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter OPN_WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter();
                IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
                IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();
                IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter OpenPaymentDistributionTableAdapter = new IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter();

                OPNPAYTableAdapter.FillByAll(ReportData.OPNPAY);
                if (ReportData.OPNPAY.Rows.Count == 0)
                {
                    MessageBox.Show("*** There are NO UNPOSTED Open End Payments! ***");
                    return;
                }
                OPN_WS_DEALER_PAYTableAdapter.Fill(ReportData.OPN_WS_DEALER_PAY);
                PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
                PAYCODETableAdapter.Fill(ReportData.PAYCODE);
                ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

                CreateFormInstance("QueryProgress", true, false, true);
                QueryProgress lfrm;
                lfrm = (QueryProgress)frm;
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler(worker_DoNewOpenPaymentPostingWithPost);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.RunWorkerAsync();
                lfrm.Text = "Open Payments Posting With Update";
                lfrm.lblProgress.Text = "Posting Open Payments With Update";
                lfrm.ShowDialog();

                OpenPaymentDistributionTableAdapter.FillByPayments(ReportData.OpenPaymentDistribution);
                MasterTotalTempTableAdapter.Fill(ReportData.MasterTotalTemp);

                OpenPaymentBalanceJournal myReportObject = new OpenPaymentBalanceJournal();
                myReportObject.SetDataSource(ReportData);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject.SetParameterValue("gsFormTitle", "Open Payment Receipts Balance Journal - With Update");

                CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
                rptViewr.crystalReportViewer.ReportSource = myReportObject;
                rptViewr.crystalReportViewer.Refresh();
                rptViewr.Show();
                ReportData.Clear();
                ReportData.Dispose();
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        public void paymentReceiptsBalanceJournalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();
            IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter OPN_WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTypeTableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.PAYCODETableAdapter PAYCODETableAdapter = new IACDataSetTableAdapters.PAYCODETableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
            IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();
            IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter OpenPaymentDistributionTableAdapter = new IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter();

            OPNPAYTableAdapter.FillByAll(ReportData.OPNPAY);
            if (ReportData.OPNPAY.Rows.Count == 0)
            {
                MessageBox.Show("*** There are NO UNPOSTED Open End Payments! ***");
                return;
            }
            OPN_WS_DEALER_PAYTableAdapter.Fill(ReportData.OPN_WS_DEALER_PAY);
            PAYMENTTypeTableAdapter.Fill(ReportData.PAYMENTTYPE);
            PAYCODETableAdapter.Fill(ReportData.PAYCODE);
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoNewOpenPaymentPostingWithoutPost);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "Open Payments Posting No Update";
            lfrm.lblProgress.Text = "Posting Open Payments Without Update";
            lfrm.ShowDialog();

            OpenPaymentDistributionTableAdapter.FillByPayments(ReportData.OpenPaymentDistribution);
            MasterTotalTempTableAdapter.Fill(ReportData.MasterTotalTemp);

            OpenPaymentBalanceJournal myReportObject = new OpenPaymentBalanceJournal();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gsFormTitle", "Open Payment Receipts Balance Journal - No Update");

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
            ReportData.Clear();
            ReportData.Dispose();
        }

        private void delinquencyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenDelinquencyReports", false);
        }

        private void addOnMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("formOpenLoanBalanceAddOn", false);
        }

        private void customerLateChargeListingIACRPT032ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportData = new IACDataSet();
            IACDataSetTableAdapters.NOTICETableAdapter NOTICETableAdapter = new IACDataSetTableAdapters.NOTICETableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter   = new IACDataSetTableAdapters.ULISTTableAdapter();
            IACDataSetTableAdapters.SystemTableAdapter SystemTableAdapter = new IACDataSetTableAdapters.SystemTableAdapter();

            NOTICETableAdapter.FillAll(ReportData.NOTICE);
            DEALERTableAdapter.FillByNotice(ReportData.DEALER);

            if (ReportData.NOTICE.Rows.Count == 0)
            {
                MessageBox.Show("*** There are NO NOTICES! ***");
                return;
            }
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);
            SystemTableAdapter.Fill(ReportData.System,1);

            ClosedCustomerLateChargeListing myReportObject = new ClosedCustomerLateChargeListing();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gdRunDate", ReportData.System.Rows[0].Field<DateTime>("ClosedNoticeRunDate"));

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();

        }

        private void noticesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("frmOpnNotices", false);
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void noticesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("frmNotices", false);
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void customerLateChargeListingIACRPT35ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNNOTTableAdapter OPNNOTTableAdapter = new IACDataSetTableAdapters.OPNNOTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
            IACDataSetTableAdapters.SystemTableAdapter SystemTableAdapter = new IACDataSetTableAdapters.SystemTableAdapter();

            OPNNOTTableAdapter.FillAll(ReportData.OPNNOT);
            OPNDEALRTableAdapter.FillByNotice(ReportData.OPNDEALR);

            if (ReportData.OPNNOT.Rows.Count == 0)
            {
                MessageBox.Show("*** There are NO NOTICES! ***");
                return;
            }
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);
            SystemTableAdapter.Fill(ReportData.System,1);
            OpenCustomerLateChargeListing myReportObject = new OpenCustomerLateChargeListing();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gdRunDate", ReportData.System.Rows[0].Field<DateTime>("OpenNoticeRunDate"));

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void monthlyUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dealerContingentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("frmClosedDealerContingentPost", false);
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void masterContingentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("frmClosedMasterContingentPost", false);
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void dealerContingentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("frmOpenDealerContingentPost", false);
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void masterContingentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("frmOpenMasterContingentPost", false);
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void addOnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("frmOpenAddOnPost", false);
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void addOnEditListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNCUSTTableAdapter  CustomerTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNUPDATTableAdapter OPNUPDATTableAdapter = new IACDataSetTableAdapters.OPNUPDATTableAdapter();
            IACDataSetTableAdapters.ULISTTableAdapter    ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();

            OPNUPDATTableAdapter.FillAll(ReportData.OPNUPDAT);
            CustomerTableAdapter.FillByAddOns(ReportData.OPNCUST);
            DEALERTableAdapter.FillByAddOns(ReportData.OPNDEALR);
            ULISTTableAdapter.FillById(ReportData.ULIST, Program.gsUserID);

            OpenAddOnAmountEditList myReportObject = new OpenAddOnAmountEditList();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void dealerContingentEditListWithTotalsIACRPT03ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.CONTINGTableAdapter CONTINGTableAdapter = new IACDataSetTableAdapters.CONTINGTableAdapter();
            IACDataSetTableAdapters.MACONTTableAdapter MACONTTableAdapter = new IACDataSetTableAdapters.MACONTTableAdapter();

            CONTINGTableAdapter.FillByAllUnPosted(ReportData.CONTING);
            DEALERTableAdapter.FillByConting(ReportData.DEALER);
            MACONTTableAdapter.FillByAll(ReportData.MACONT);

            ClosedContingentEditList myReportObject = new ClosedContingentEditList();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gsFormTitle", "CLOSED CONTINGENT EDIT LIST WITH TOTALS - NOT POSTED");

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void dealerContingentEditListWithTotalsOPNRPT03ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNCONTTableAdapter OPNCONTTableAdapter = new IACDataSetTableAdapters.OPNCONTTableAdapter();
            IACDataSetTableAdapters.OPNMCONTTableAdapter OPNMCONTTableAdapter = new IACDataSetTableAdapters.OPNMCONTTableAdapter();

            OPNCONTTableAdapter.FillByAllUnposted(ReportData.OPNCONT);
            OPNDEALRTableAdapter.FillByConting(ReportData.OPNDEALR);
            OPNMCONTTableAdapter.FillByAll(ReportData.OPNMCONT);

            OpenContingentEditList myReportObject = new OpenContingentEditList();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gsFormTitle", "OPEN CONTINGENT EDIT LIST WITH TOTALS - NOT POSTED");

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void recreatePaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 Unreach = 1;
            IACDataSetTableAdapters.AMORTIZETableAdapter AMORTIZETableAdapter = new IACDataSetTableAdapters.AMORTIZETableAdapter();
            IACDataSetTableAdapters.AmortTempTableAdapter AmortTempTableAdapter = new IACDataSetTableAdapters.AmortTempTableAdapter();
            ReportData = new IACDataSet();
            ClosedPaymentPosting CPaymentPosting = new ClosedPaymentPosting();
            AMORTIZETableAdapter.CustomizeFill("SELECT * FROM AMORTIZE");
            AMORTIZETableAdapter.CustomFillBy(ReportData.AMORTIZE,"");
            //CPaymentPosting.CopyAmortizetoAmortTemp(ReportData, ref worker);
            // Prevent unreachable code error
            if(Unreach==1)
                return;
            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoFixAmortRecords);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_FixAmortProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = @"Fixing Amortize Records for ALL 'A'CTIVE customers.";
            lfrm.lblProgress.Text = "RECREATING AMORTIZE AND AmortTemp records.";
            lfrm.ShowDialog();
            MessageBox.Show("Done !!!");
        }

        private void statementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                CreateFormInstance("frmOpenStatements", false);
                Program.ReleaseExclusiveLock();
                // Moses Newman 08/05/2014 Relock current in shared mode!
                Program.LockfileShare();
            }
        }

        private void reprintStatementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmReprintStatements", false);
        }

        private void customerFinanceReportOFINRPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenCustomerFinanceChargeReport", false);
        }

        private void loanTrialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedTrialBalance", false);
        }

        private void openLoanTrialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenTrialBalance", false);
        }

        private void createSumRecsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoFixAmortRecords);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_FixAmortProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = @"Fixing Amortize Records for ALL 'A'CTIVE customers.";
            lfrm.lblProgress.Text = "RECREATING AMORTIZE AND AmortTemp records.";
            lfrm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void worker_DoFixAmortRecords(object sender, DoWorkEventArgs e)
        {
            //Program.FixAmortize(ref worker,true);
        }

        void worker_FixAmortProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            lfrm.QueryprogressBar.Value = e.ProgressPercentage;
            lfrm.lblProgress.Text = "RECREATING AMORTIZE AND AmortTemp records." + Program.gsAmortProgressText;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmPrintNewBusinessStatements", false);
        }

        private void dealerSummaryReportIACRPT26ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedDealerSummaryReport", false);
        }

        private void dealerSummaryReportOPNRPT26ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenDealerSummaryReport", false);
        }

        private void printNoticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MailMergeComponents CreateNoticeLetters = new MailMergeComponents();
            // Moses Newman 08/19/2018 Add progress bar for use when creating attachments in late charges, only need ref here becuase they are required params.
            String blank = "";
           
            CreateNoticeLetters.CreateNotices(0,false,ref worker,ref blank);
            CreateNoticeLetters.CreateNotices(1, false, ref worker, ref blank);
            CreateNoticeLetters.CreateNotices(2, false, ref worker, ref blank);
            CreateNoticeLetters.CreateNotices(3, false, ref worker, ref blank);
            CreateNoticeLetters.CreateNotices(4, false, ref worker, ref blank);
            CreateNoticeLetters.CreateNotices(5, false, ref worker, ref blank);
            CreateNoticeLetters.CreateNotices(6, false, ref worker, ref blank);
            CreateNoticeLetters.CreateNotices(9, false, ref worker, ref blank);
            CreateNoticeLetters = null;
        }

        private void dealerHistoryReportIACRPT41ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedDealerHistoryReport", false);
        }

        private void dealerHistoryReportOPNRPT41ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenDealerHistoryReport", false);
        }

        private void masterHistoryReportIACRPT43ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmMasterHistoryReport", false);
        }

        private void masterHistoryReportIACRPT43ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmMasterHistoryReport", false);
        }

        private void closedCustomerBuyBackReportBUYBACKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedCustomerBuybackReport", false);
        }

        private void openCustomerBuyBackReportBUYBACKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenCustomerBuybackReport", false);
        }

        private void printScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MailMergeComponents MM = new MailMergeComponents();
            Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);


            Graphics gs = Graphics.FromImage(bit);
            String lsPath = Program.GsDataPath + @"\MailMerge\TEMPSCRN.JPG";

            gs.CopyFromScreen(

            new Point(0, 0), new Point(0, 0), bit.Size);
            MM.SaveJpeg(lsPath, bit, 100);

            MM.ScrnPrnt(lsPath);
            bit.Dispose();
            bit = null;
            MM = null;
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore Backup = new SQLBackupandRestore();
            Backup.GeneralBackup();
            Backup.Dispose();
            Backup = null;
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore Restore = new SQLBackupandRestore();
            Restore.GeneralRestore();
            Restore.Dispose();
            Restore = null;
        }

        private void createWellsFargoExtractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmCreateBankCustomerExtract", false);
        }

        private void aUTOBANKTransferAndReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmCreateAutoBankFiles", false);
        }

        private void importPCPAYFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmImportPCPAYFile", false);
        }

        private void paidInFullReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedPaidInFullReport", false);
        }

        private void paidInfullReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenPaidInFullReport", false);
        }

        private void tSBExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmCreateTSBExtract", false);
        }

        private void delinquencyReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedDelinquencyReports", false);
        }

        private void monthlyInterestReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportData = new IACDataSet();
            // Moses Newman 11/29/2020 add new Daily Interest Variance Sub Report
            DailyDataSet DailyData = new DailyDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.SystemTableAdapter SystemTableAdapter = new IACDataSetTableAdapters.SystemTableAdapter();

            DailyDataSetTableAdapters.DailyInterestVarianceTableAdapter DailyInterestVarianceTableAdapter = new DailyDataSetTableAdapters.DailyInterestVarianceTableAdapter();

            SystemTableAdapter.Fill(ReportData.System,1);

            DateTime ldLastRun = ReportData.System.Rows[0].Field<DateTime>("LastUpdateDate");

            CUSTOMERTableAdapter.FillByUpdates(ReportData.CUSTOMER, ldLastRun);
            DEALERTableAdapter.FillByUpdates(ReportData.DEALER, ldLastRun);
            CUSTHISTTableAdapter.FillByUpdatesOnly(ReportData.CUSTHIST, ldLastRun);
            if (ReportData.CUSTHIST.Rows.Count == 0)
            {
                MessageBox.Show("*** There are no UPDATES to report on! ***");
                return;
            }

            DailyInterestVarianceTableAdapter.Fill(DailyData.DailyInterestVariance, ldLastRun);
            MonthlyUpdateListing myReportObject = new MonthlyUpdateListing();

            //MonthlyUpdateDevience myReportObject = new MonthlyUpdateDevience();
            myReportObject.SetDataSource(ReportData);
            myReportObject.Subreports["DailyInterestVariance.rpt"].SetDataSource(DailyData);   // Moses Newman 11/29/2020 add new data source
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
            myReportObject.SetParameterValue("gsFormTitle", "Monthly Interest Update Report");
            myReportObject.SetParameterValue("gdLastRun", ldLastRun);

            CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)ActiveMdiChild;
            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
            ReportData.Clear();
            ReportData.Dispose();
        }

        private void chargesAppliedToDealerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedChargesAppliedtoDealerReport", false);
        }

        private void chargesAppliedToDealerReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenChargesAppliedtoDealerReport", false);
        }

        private void closedMonthlyUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LockfileExclusive())
            {
                // 05/4/2015 Moses Newman opne form modal so that lock is not released until done!
                CreateFormInstance("frmMonthlyupdate", true);
                // Moses Newman 05/04/2015 Added Release of lockes to form worker threads instead of here!
            }
        }

        private void recalcBuyoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


 
            
        private void fix211DataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormValidateCellPhones", false);
        }

        private void unlockCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormUnlock", false);
        }

        private void leeMasonImportAndExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormLeeMason", false);
        }

        private void vehicleReposessionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("CustomerRepossessionReport", false);
        }

        private void vehicleMissingTitleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("CustomerMissingTitleReport", false);
        }

        private void shortBalanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("CustomerShortBalanceReport", false);
        }

        private void creditScoreTierSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("ClosedCustomerTierSummary", false);
        }

        private void createEFTNoticesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CreateFormInstance("CreateEFTNotices", false);
        }

        private void recalcPartialPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosedPaymentPosting CP = new ClosedPaymentPosting();
            CreateFormInstance("QueryProgress", true, false, true);
            QueryProgress lfrm;
            lfrm = (QueryProgress)frm;
            CP.worker = new BackgroundWorker();
            CP.worker.WorkerReportsProgress = true;

            CP.worker.DoWork += new DoWorkEventHandler(CP.worker_DorRecalcPTLF);
            CP.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            CP.worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            CP.worker.RunWorkerAsync();
            lfrm.Text = "Closed Recalculate Partial Payments, Late Fee Blances, Paid Throughs, Payments Made, and Payments Remaining";
            lfrm.ShowDialog();
            CP.Dispose();
            CP = null;
        }

        private void firstPaymentDefaultReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedFirstPaymentDefaultReport", false);
        }

        private void paidInAdvanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedPayedInAdvanceReport", false);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmDealerLookup", false);
        }

        private void repoReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormRepoReport", false);
        }

        private void importTCIAppsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmImportTCI", false);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormBULKSMSMessage", false);
        }

        private void closedImportPCPAYFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedImportPCPAYFile", false);
        }

        private void importIVRPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmIVRImport", false);
        }

        private void vSIExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormVSIExtract", false);
        }

        private void paidInFullPriorToMaturityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmClosedPaidInFullPriorToMaturityReport", false);
        }

        private void fixPaidThroughsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FixPaidThroughs", false);
        }

        private void firstPaymentDefaultReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmOpenFirstPaymentDefaultReport", false);
        }

        // Moses Newman 11/03/2019 Convert TimeValueXLSX to .dat file for US Attorney
        private void carToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            int docno = 0;
            var filenames4 = Directory
                .EnumerateFiles(@"\\dc-iac\Public\Car Nation\", "*.xlsx", SearchOption.AllDirectories)
                .Select(Path.GetFileName); // <-- note you can shorten the lambda

            string pkgLocation;
            Package pkg;
            Microsoft.SqlServer.Dts.Runtime.Application app;
            DTSExecResult pkgResults;

            pkgLocation =
              @"E:\SSISPackages\LeeMasonToVehicle\LeeMasonToVehicle" +
              @"\CarNation.dtsx";
            app = new Microsoft.SqlServer.Dts.Runtime.Application();
            pkg = app.LoadPackage(pkgLocation, null);
            foreach (String FileName in filenames4)
            {
                docno += 1;
                pkg.Variables["XLXFName"].Value = FileName;
                pkg.Variables["UserBatesNumber"].Value = "IAC-" + FileName.Substring(0,6) + docno.ToString().Trim().PadLeft(2,'0');
                pkgResults = pkg.Execute();
                //MessageBox.Show("The Results are: " + pkgResults);
            }
            MessageBox.Show("Completed!");
        }

        private void importPNSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmPNSImport", false);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmImportDefi", false);
        }

        private void fixCreateDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormFixCreateDate", false);
        }

        private void globalSearchPDFUploaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("GlobalCapturePDFUploader", false);
        }

        private void createWellsFargoExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fixPaidThroughsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FixPaidThroughs", false);
        }

        private void importDefiPDFImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("frmImportDefiPDFs", false);
        }

        private void overPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("ClosedOverPaymentReport", false); 
        }

        private void fixPartialPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FixPaidThroughs", false);
        }

        private void receivedContractReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("ClosedCustomerReceivedContractReport", false);
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormInstance("FormTickets", false);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            CreateFormInstance("FormCashPaymentSummary", false);
        }

        private void closedEndToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

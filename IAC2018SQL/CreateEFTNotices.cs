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
    public partial class CreateEFTNotices : DevExpress.XtraEditors.XtraForm
    {
        IACDataSet iACDataSet = new IACDataSet();
        IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
        IACDataSetTableAdapters.COMMENTTableAdapter COMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();
        MailMergeComponents MailMerge = new MailMergeComponents();
 
        private Nullable<DateTime> ldECHDate = null;
        QueryProgress lfrm;

        BackgroundWorker worker;
        String lsProgMessage ="",lsTestEmail = "", lsMergeFileName = "";
        Int32 lnDayDue;
        DateTime ldDueDate;
        Boolean lbSMS = false,lbAutoPay = true, lbTestOnly = false;
        
        public CreateEFTNotices()
        {
            InitializeComponent();
        }

        private void CreateECHNotices_Load(object sender, EventArgs e)
        {
            // Moses Newman 11/21/2017 Remove hard coded UNC pathing.
            String path = Program.GsDataPath + @"MailMerge";
            textBoxTestEmail.Text = "DCarocci@iaccredit.com";
            var FileNames = Directory.EnumerateFiles(path, "*.docx").Select(Path.GetFileName);

            foreach (object i in FileNames)
                listBoxMergeFileName.Items.Add(i);
            listBoxMergeFileName.SelectedIndex = listBoxMergeFileName.FindStringExact(@"ElectronicClearingHousePayment.docx");
        }

        private void comboBoxDayDue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDayDue.Text.TrimEnd() == "")
            {
                ldECHDate = null;
                return;
            }
            if (DateTime.Now.Date.Month == 2 && comboBoxDayDue.Text == "30")
                ldECHDate = DateTime.Parse("02/1/" + DateTime.Now.Date.Year.ToString()).AddMonths(1).AddDays(-1);
            else
            {
                ldECHDate = DateTime.Parse(DateTime.Now.Date.Month.ToString() + "/" + comboBoxDayDue.Text + "/" + DateTime.Now.Date.Year.ToString());
            }
            
            nullableDateTimePicker1.EditValue = ldECHDate;
        }

        private void worker_DoMailMerge(object sender, DoWorkEventArgs e)
        {
            if (!lbTestOnly)
                lsTestEmail = "";
            MailMerge.CreateECHNotice(iACDataSet, lnDayDue, ldDueDate, lsTestEmail, ref worker, ref lsProgMessage, !lbSMS, lbAutoPay,lbTestOnly, lsMergeFileName);
        }

        private void buttonCreateECHNotices_Click(object sender, EventArgs e)
        {
            if (checkBoxTestOnly.Checked)
            {
                // Moses Newman 11/9/2014 if test mode add test email address(s) to Email table.
                IACDataSetTableAdapters.EmailTableAdapter EmailTableAdapter = new IACDataSetTableAdapters.EmailTableAdapter();
                EmailTableAdapter.UpdateTestEmail(textBoxTestEmail.Text.TrimStart().TrimEnd());
                EmailTableAdapter.Dispose();
                EmailTableAdapter = null;
            }
            ldDueDate = (DateTime)nullableDateTimePicker1.EditValue;
            lbSMS = false;
            lsMergeFileName = (String)listBoxMergeFileName.Items[listBoxMergeFileName.SelectedIndex];
            if (comboBoxDayDue.Text.TrimEnd() == "")
                lnDayDue = 0;
            else
                lnDayDue = Convert.ToInt32(comboBoxDayDue.Text);
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoMailMerge);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "EFT Email Notices";
            lfrm.lblProgress.Text = "Creating EFT Email Notices";
            lfrm.ShowDialog();
            Clipboard.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            CustomerTableAdapter.Connection.Close();
            CustomerTableAdapter.Dispose();
            iACDataSet.Dispose();
            MailMerge = null;
            Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.EditValue = e.ProgressPercentage;
            if(!lbSMS)
                lfrm.lblProgress.Text = "Emailing EFT Notice to customer: " + lsProgMessage;
            else
                lfrm.lblProgress.Text = "Sending SMS EFT Notice to customer: " + lsProgMessage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lnDayDue = Convert.ToInt32(comboBoxDayDue.Text);
            ldDueDate = (DateTime)nullableDateTimePicker1.EditValue;
            lbSMS = true;
            if (comboBoxDayDue.Text.TrimEnd() == "")
                lnDayDue = 0;
            else
                lnDayDue = Convert.ToInt32(comboBoxDayDue.Text);
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoMailMerge);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lfrm.Text = "EFT SMS Notices";
            lfrm.lblProgress.Text = "Creating SMS Notices";
            lfrm.ShowDialog();
        }

        private void checkBoxAutoPayOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoPayOnly.Checked)
                lbAutoPay = true;
            else
                lbAutoPay = false;
        }

        private void checkBoxTestOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTestOnly.Checked)
            {
                lbTestOnly = true;
                labelTestEmail.Visible = true;
                textBoxTestEmail.Visible = true;
            }
            else
            {
                lbTestOnly = false;
                labelTestEmail.Visible = false;
                textBoxTestEmail.Visible = false;
            }
        }

        private void textBoxTestEmail_TextChanged(object sender, EventArgs e)
        {
            lsTestEmail = textBoxTestEmail.Text.TrimStart().TrimEnd();
        }
    }
}

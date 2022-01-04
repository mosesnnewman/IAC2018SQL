using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.Transactions;


namespace IAC2021SQL
{
    public partial class ClosedDealerMaintenance : DevExpress.XtraEditors.XtraForm
    {
        //private String Program.gsKey="";
        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection  tableAdapConn = null;

        private bool lbAddFlag = false,lbFromDealer = false,lbEdit = false,lbILockedIt = false;
        private frmDealerLookup form2inst;
        private ErrorProvider errmsg = new ErrorProvider();


        public ClosedDealerMaintenance()
        {
            InitializeComponent();
        }


        private void setRelatedData()
        {
            Double lnContOSLoansRatio;

            if (lbAddFlag || lbEdit)
                return;
            if (DEALERcomboBox.Text.ToString().TrimEnd().Length > 0)
            {
                iacDataSet.DEALER.Clear();
                iacDataSet.DEALHIST.Clear();
                dEALERTableAdapter.Fill(iacDataSet.DEALER, DEALERcomboBox.Text.ToString().TrimEnd());
                if (iacDataSet.DEALER.Rows.Count > 0)
                {
                    dEALHISTTableAdapter.FillAllByDealerAcc(iacDataSet.DEALHIST, DEALERcomboBox.Text.ToString().TrimEnd());
                    lnContOSLoansRatio = 0;
                    if (iacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_OLOAN") != null)
                        if(iacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN") !=0) 
                            lnContOSLoansRatio = Convert.ToDouble(iacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_CONT") / iacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN"));
                    ResperOSLoanstextBox.Text = (lnContOSLoansRatio != 0) ? lnContOSLoansRatio.ToString("P", new System.Globalization.CultureInfo("en-US")):"";
                    ResperOSLoanstextBox2.Text = ResperOSLoanstextBox.Text;
                    dLRLISTBYNUMTableAdapter.Fill(iacDataSet.DLRLISTBYNUM);
                    dEALERLISTTableAdapter.FillAll(iacDataSet.DEALERLIST);
                    DEALERcomboBox.Text = (Program.gsKey != null) ? Program.gsKey : "";
                    //DealerListbindingSource.Position = DealerListbindingSource.Find("DEALER_ACC_NO", (object)DEALERcomboBox.Text);
                }
                else
                {
                    var ldlgAnswer = MessageBox.Show("Sorry no dealer found that matches your selected dealer number! Would you like to add a new record?", "Add New Prompt", MessageBoxButtons.YesNo);
                    if (ldlgAnswer == DialogResult.No)
                    {
                        DealerNamecomboBox.Text = "";
                        ActiveControl = DealerNamecomboBox;
                        DealerNamecomboBox.SelectAll();
                    }
                    else
                    {
                        lbAddFlag = true;
                        iacDataSet.DEALER.Clear();
                        DealerbindingSource.AddNew();
                        DealerbindingSource.EndEdit();

                        // Set NULL VALUES to empty string
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_ACC_NO", DEALERcomboBox.Text);
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_STATUS", "A");
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<DateTime>("DEALER_POST_DATE", DateTime.Now.Date);
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<DateTime>("DealerStartDate", DateTime.Now.Date);
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("CellPhone", "");
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_NAME", "");
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_ADDR", "");
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_HOME_PHONE", "");
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_CITY", "");
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_ST", "");
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_WORK_PHONE", "");
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_ZIP", "");

                        DealerNamecomboBox.Enabled = false;
                        nullableDateTimePickerDealerStartDate.Enabled = true;
                        DEALER_STREETTextBox.Enabled = true;
                        DealerCityTextBox.Enabled = true;
                        DealerStateTextBox.Enabled = true;
                        DealerZipTextBox.Enabled = true;
                        DealerHomePhoneTextBox.Enabled = true;
                        maskedTextBoxCellPhone.Enabled = true; 
                        DEALERWorkPhoneTextBox.Enabled = true;
                        textBoxDealerEmail.Enabled = true;
                        dEALER_NAMETextBox.Enabled = true;
                        toolStripButtonEdit.Enabled = false;
                        DEALERcomboBox.Enabled = false;
                        DealerNamecomboBox.Enabled = false;
                        ActiveControl = dEALER_NAMETextBox;
                        dEALER_NAMETextBox.SelectAll();
                    }
                }
            }
        }

        private void General_KeyPress(object sender, KeyPressEventArgs e)
        {
            string lsTempKey = "";

            lsTempKey += e.KeyChar; 
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }

            else
            {
                if (ActiveControl == DEALERcomboBox || ActiveControl == DealerNamecomboBox)
                    return;
                toolStripButtonSave.Enabled = true;
            }
        }

        private void DEALERcomboBox_Validated(object sender, EventArgs e)
        {
            string lsDealerNo;
            Int32 DLRPOS = -1;
            Object Key = null;
            if (DEALERcomboBox.Text.ToString().Trim().Length < 3 && DEALERcomboBox.Text.ToString().Trim().Length > 0)
                DEALERcomboBox.Text = DEALERcomboBox.Text.PadLeft(3, '0');

            lsDealerNo = DEALERcomboBox.Text.ToString().Trim();

            if (lsDealerNo == "")
                return;
            lbFromDealer = true;
            setRelatedData();
            if (iacDataSet.DEALER.Rows.Count > 0)
            {
                if (!lbAddFlag)
                    toolStripButtonEdit.Enabled = true;
                if (iacDataSet.DEALHIST.Rows.Count == 0 && !lbEdit)
                    toolStripButtonDelete.Enabled = true;
                else
                    toolStripButtonDelete.Enabled = false;
                Key = iacDataSet.DEALER.Rows[0].Field<String>("DEALER_ACC_NO");
                DLRPOS = DLRLISTBYNUMbindingSource.Find("DEALER_ACC_NO", Key);

                if (DLRPOS != -1)
                {
                    DealerListbindingSource.Position = DealerListbindingSource.Find("DEALER_ACC_NO", Key);
                    ActiveControl = dEALER_NAMETextBox;
                    dEALER_NAMETextBox.SelectAll();
                }
            }
            else
                DEALERcomboBox.Text = lsDealerNo;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            string lsDealerNo="";

            Validate();  //Validate form so all data sets are updated with field values
            DealerbindingSource.EndEdit();

            lsDealerNo = DEALERcomboBox.Text.ToString().Trim();

            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;

            tableAdapConn.Open();                                                                                        
            dEALERTableAdapter.Connection = tableAdapConn;
            tableAdapTran = dEALERTableAdapter.BeginTransaction();
            dEALERTableAdapter.Transaction = tableAdapTran;
            try
            {
                dEALERTableAdapter.Update(iacDataSet.DEALER.Rows[DealerbindingSource.Position]);
                tableAdapTran.Commit();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("General Exception Error: " + ex.Message.ToString());
            }
            finally
            {
                dEALERTableAdapter.UnlockRecord(iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_ACC_NO"));
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                if (lbAddFlag)
                {
                    lbAddFlag = false;
                    iacDataSet.DEALER.Clear();
                    StartUpConfiguration();
                }
                iacDataSet.AcceptChanges();
                Program.gsKey = lsDealerNo;
                DEALERcomboBox.Text = lsDealerNo;
                if (lbEdit)
                {
                    lbEdit = false;
                    SetViewMode();
                }
            }
        }

        private void DealerMaintenance_Load(object sender, EventArgs e)
        {
            StartUpConfiguration();
            PerformAutoScale();
        }

        private void StartUpConfiguration()
        {
            dLRLISTBYNUMTableAdapter.Fill(iacDataSet.DLRLISTBYNUM);
            dEALERLISTTableAdapter.FillAll(iacDataSet.DEALERLIST);
            DEALERcomboBox.Enabled = true;
            DealerNamecomboBox.Enabled = true;
            DEALERcomboBox.Text = (Program.gsKey != null) ? Program.gsKey : "";
            if (Program.gsKey != null)
            {
                setRelatedData();
                if (iacDataSet.DEALER.Rows.Count == 0)
                {
                    DEALERcomboBox.Text = "";
                    DealerNamecomboBox.Text = "";
                }
                else
                {
                    DealerNamecomboBox.Text = iacDataSet.DEALER.Rows[0].Field<String>("DEALER_NAME");
                }
            }
            else
            {
                DealerNamecomboBox.Text = "";
                DEALERcomboBox.Text = "";
                dEALER_NAMETextBox.Text = "";
            }
            Program.gsKey = null;
            if (!lbEdit)
                SetViewMode();
            else
                SetEditMode();
            toolStripButtonSave.Enabled = false;
        }

        private void SetViewMode()
        {
                // Moses Newman 10/3/2014 Disable Dealer Status
                DEALER_STATTextBox.Enabled = false;
                dEALER_NAMETextBox.Enabled = false;
                DEALER_STREETTextBox.Enabled = false;
                DealerCityTextBox.Enabled = false;
                DealerStateTextBox.Enabled = false;
                DealerZipTextBox.Enabled = false;
                DealerHomePhoneTextBox.Enabled = false;
                DEALERWorkPhoneTextBox.Enabled = false;
                maskedTextBoxCellPhone.Enabled = false;
                nullableDateTimePickerDealerStartDate.Enabled = false;
                toolStripButtonEdit.Enabled = true;
                textBoxDealerEmail.Enabled = false;
                DealerNamecomboBox.Text = dEALER_NAMETextBox.Text;
                ActiveControl = DEALERcomboBox;
                DEALERcomboBox.SelectAll();
        }

        private void SetEditMode()
        {
            Visible = true;
            // Moses Newman 10/3/2014 Enable Dealer Status
            DEALER_STATTextBox.Enabled = true;
            DEALER_STREETTextBox.Enabled = true;
            DealerCityTextBox.Enabled = true;
            DealerStateTextBox.Enabled = true;
            DealerZipTextBox.Enabled = true;
            DealerHomePhoneTextBox.Enabled = true;
            DEALERWorkPhoneTextBox.Enabled = true;
            maskedTextBoxCellPhone.Enabled = true;
            nullableDateTimePickerDealerStartDate.Enabled = true;
            DealerNamecomboBox.Text = dEALER_NAMETextBox.Text;
            dEALER_NAMETextBox.Enabled = true;
            toolStripButtonEdit.Enabled = false;
            textBoxDealerEmail.Enabled = true;
            ActiveControl = dEALER_NAMETextBox;
            dEALER_NAMETextBox.SelectAll();
        }
        

        private void DealerNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAddFlag)
                return;
            if (DealerNamecomboBox.SelectedIndex > -1)
            {
                DEALERcomboBox.Text = iacDataSet.DEALERLIST.Rows[DealerNamecomboBox.SelectedIndex].Field<String>("DEALER_ACC_NO");
                ActiveControl = dEALER_NAMETextBox;
                dEALER_NAMETextBox.SelectAll();
            }
        }

        private void DealerHistorydataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in DealerHistorydataGridView.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView2.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView3.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void DEALERcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFromDealer)
            {
                lbFromDealer = false;
                return;
            }
            ActiveControl = DEALERcomboBox;
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }


        private void LockDealerRecord()
        {   
            Object loLockedBy = dEALERTableAdapter.LockedBy(DEALERcomboBox.Text),
                   loLockedTime = dEALERTableAdapter.LockTime(DEALERcomboBox.Text);
             
            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(iacDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** DEALER: " + DEALERcomboBox.Text + " WAS LOCKED BY USER: " +
                    loLockedBy + " " +
                    iacDataSet.ULIST.Rows[0].Field<String>("LIST_NAME") +
                    "\nON: " + ((DateTime)loLockedTime).ToLongDateString() + " " +
                    ((DateTime)loLockedTime).ToLongTimeString() + "\n" +
                    "YOU MUST WAIT UNTIL THEY RELEASE IT! ***", "RECORD LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripButtonSave.Enabled = false;
                ULISTTableAdapter.Dispose();
                loLockedBy = null;
                lbEdit = false;
                iacDataSet.Clear();
                StartUpConfiguration();
            }
            else
            {
                dEALERTableAdapter.LockRecord(Program.gsUserID, DEALERcomboBox.Text);
                lbILockedIt = true;   //  Make sure other instances of form don't unlocke this record!
            }
        }


        private void ClosedDealerMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Moses Newman 12/18/2019 Clear gsKey so when reopened does not go to last dealer.
            Program.gsKey = "";
            if (iacDataSet.DEALER.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = dEALERTableAdapter.LockedBy(iacDataSet.DEALER.Rows[0].Field<String>("DEALER_ACC_NO"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    dEALERTableAdapter.UnlockRecord(iacDataSet.DEALER.Rows[0].Field<String>("DEALER_ACC_NO"));
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            lbEdit = true;
            LockDealerRecord();
            if (lbEdit)
                SetEditMode();
            else
                Refresh();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            string lsDealerNo = "";

            Validate();  //Validate form so all data sets are updated with field values
            lsDealerNo = DEALERcomboBox.Text.ToString().Trim();

            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            dEALERTableAdapter.Connection = tableAdapConn;
            tableAdapTran = dEALERTableAdapter.BeginTransaction();
            dEALERTableAdapter.Transaction = tableAdapTran;

            try
            {
                dEALERTableAdapter.DeleteQuery(lsDealerNo);
                tableAdapTran.Commit();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("The has been a Microsoft SQL Server Database Error: " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
            }
            catch (System.Exception ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("General Exception Error: " + ex.Message.ToString());
            }
            finally
            {
                iacDataSet.AcceptChanges();
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonEdit.Enabled = false;
                iacDataSet.DEALER.Clear();
                Program.gsKey = null;
                StartUpConfiguration();
            }

        }

        // Moses Newman 12/18/2019 Handle validation of email address.
        private void textBoxDealerEmail_Validating(object sender, CancelEventArgs e)
        {
            Program.EmailValidator(ref sender, ref e, ref errmsg);
        }

        private void nullableDateTimePickerDealerStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Visible = false;
            form2inst = new frmDealerLookup();

            form2inst.ShowDialog(this);
            form2inst.Dispose();
            Visible = true;
            if (Program.gsKey != null)
            {
                DEALERcomboBox.SelectedIndex = DEALERcomboBox.FindStringExact(Program.gsKey);
                ActiveControl = dEALER_NAMETextBox;
                dEALER_NAMETextBox.Select();
            }
            Program.gsKey = null;
        }
    }
}

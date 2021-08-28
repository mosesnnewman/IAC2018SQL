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


namespace IAC2021SQL
{
    public partial class frmOpenDealerMaintenance : Form
    {
        private String lsKey = "";
        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection tableAdapConn = null;

        private bool lbAddFlag = false, lbFromDealer = false, lbEdit = false, lbILockedIt = false;

        public frmOpenDealerMaintenance()
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
                iacDataSet.OPNDEALR.Clear();
                iacDataSet.OPNHDEAL.Clear();
                oPNDEALRTableAdapter.Fill(iacDataSet.OPNDEALR, DEALERcomboBox.Text.ToString().TrimEnd());
                if (iacDataSet.OPNDEALR.Rows.Count > 0)
                {
                    oPNHDEALTableAdapter.FillByDealerAcc(iacDataSet.OPNHDEAL, DEALERcomboBox.Text.ToString().TrimEnd());
                    if (iacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN") != 0)
                        lnContOSLoansRatio = Convert.ToDouble(iacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_CONT") / iacDataSet.OPNDEALR.Rows[0].Field<Decimal>("OPNDEALR_YTD_OLOAN"));
                    else
                        lnContOSLoansRatio = 0;
                    ResperOSLoanstextBox.Text = (lnContOSLoansRatio != 0) ? lnContOSLoansRatio.ToString("P", new System.Globalization.CultureInfo("en-US")) : "";
                    ResperOSLoanstextBox2.Text = ResperOSLoanstextBox.Text;
                    oPNDLRLISTBYNUMTableAdapter.Fill(iacDataSet.OPNDLRLISTBYNUM);
                    oPNDEALRLISTTableAdapter.FillAll(iacDataSet.OPNDEALRLIST);
                    DealerListbindingSource.Position = DealerListbindingSource.Find("OPNDEALR_ACC_NO", (object)DEALERcomboBox.Text);
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
                        iacDataSet.OPNDEALR.Clear();
                        DealerbindingSource.AddNew();
                        DealerbindingSource.EndEdit();

                        // Set NULL VALUES to empty string
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_ACC_NO", DEALERcomboBox.Text);
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_STATUS", "A");
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<DateTime>("OPNDEALR_POST_DATE", DateTime.Now.Date);
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_NAME", "");
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_ADDR", "");
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_HOME_PHONE", "");
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_CITY", "");
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_ST", "");
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_WORK_PHONE", "");
                        iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].SetField<String>("OPNDEALR_ZIP", "");

                        DealerNamecomboBox.Enabled = false;
                        DEALER_STREETTextBox.Enabled = true;
                        DealerCityTextBox.Enabled = true;
                        DealerStateTextBox.Enabled = true;
                        DealerZipTextBox.Enabled = true;
                        DealerHomePhoneTextBox.Enabled = true;
                        DEALERWorkPhoneTextBox.Enabled = true;
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
           if (iacDataSet.OPNDEALR.Rows.Count > 0)
           {
               if (!lbAddFlag)
                   toolStripButtonEdit.Enabled = true;
               if (iacDataSet.OPNHDEAL.Rows.Count == 0 && !lbEdit)
                   toolStripButtonDelete.Enabled = true;
               else
                   toolStripButtonDelete.Enabled = false;
               Key = iacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO");
               DLRPOS = OPNDLRLISTBYNUMbindingSource.Find("OPNDEALR_ACC_NO", Key);

               if (DLRPOS != -1)
               {
                   DealerListbindingSource.Position = DealerListbindingSource.Find("OPNDEALR_ACC_NO", Key);
                   ActiveControl = dEALER_NAMETextBox;
                   dEALER_NAMETextBox.SelectAll();
               }
           }
           else
               DEALERcomboBox.Text = lsDealerNo;
       }



        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            string lsDealerNo = "";

            Validate();  //Validate form so all data sets are updated with field values
            DealerbindingSource.EndEdit();

            lsDealerNo = DEALERcomboBox.Text.ToString().Trim();

            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;

            tableAdapConn.Open();
            oPNDEALRTableAdapter.Connection = tableAdapConn;
            tableAdapTran = oPNDEALRTableAdapter.BeginTransaction();
            oPNDEALRTableAdapter.Transaction = tableAdapTran;
            try
            {
                oPNDEALRTableAdapter.Update(iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position]);
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
                oPNDEALRTableAdapter.UnlockRecord(iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].Field<String>("OPNDEALR_ACC_NO"));
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                if (lbAddFlag)
                {
                    lbAddFlag = false;
                    iacDataSet.OPNDEALR.Clear();
                    StartUpConfiguration();
                }
                iacDataSet.AcceptChanges();
                lsKey = lsDealerNo;
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
            oPNDLRLISTBYNUMTableAdapter.Fill(iacDataSet.OPNDLRLISTBYNUM);
            oPNDEALRLISTTableAdapter.FillAll(iacDataSet.OPNDEALRLIST);
            DEALERcomboBox.Enabled = true;
            DealerNamecomboBox.Enabled = true;
            DEALERcomboBox.Text = (lsKey != null) ? lsKey : "";
            if (lsKey != null)
            {
                setRelatedData();
                if (iacDataSet.OPNDEALR.Rows.Count == 0)
                {
                    DEALERcomboBox.Text = "";
                    DealerNamecomboBox.Text = "";
                }
                else
                {
                    DealerNamecomboBox.Text = iacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_NAME");
                }
            }
            else
            {
                DealerNamecomboBox.Text = "";
                DEALERcomboBox.Text = "";
                dEALER_NAMETextBox.Text = "";
            }
            lsKey = null;
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
            toolStripButtonEdit.Enabled = true;
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
            DealerNamecomboBox.Text = dEALER_NAMETextBox.Text;
            dEALER_NAMETextBox.Enabled = true;
            toolStripButtonEdit.Enabled = false;
            ActiveControl = dEALER_NAMETextBox;
            dEALER_NAMETextBox.SelectAll();
        }


        private void DealerNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAddFlag)
                return;
            if (DealerNamecomboBox.SelectedIndex > -1)
            {
                DEALERcomboBox.Text = iacDataSet.OPNDEALRLIST.Rows[DealerNamecomboBox.SelectedIndex].Field<String>("OPNDEALR_ACC_NO");
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
            Object loLockedBy = oPNDEALRTableAdapter.LockedBy(DEALERcomboBox.Text),
                   loLockedTime = oPNDEALRTableAdapter.LockTime(DEALERcomboBox.Text);

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
                oPNDEALRTableAdapter.LockRecord(Program.gsUserID, DEALERcomboBox.Text);
                lbILockedIt = true;   //  Make sure other instances of form don't unlocke this record!
            }
        }

        private void OpenDealerMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (iacDataSet.OPNDEALR.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = oPNDEALRTableAdapter.LockedBy(iacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    oPNDEALRTableAdapter.UnlockRecord(iacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO"));
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


        private void General_Validated(object sender, EventArgs e)
        {
            if (toolStripButtonSave.Enabled)
                return;
            DealerbindingSource.EndEdit();
            if (iacDataSet.OPNDEALR.Rows[DealerbindingSource.Position].RowState == DataRowState.Modified)
            {
                toolStripButtonSave.Enabled = true;
            }
        }



        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            string lsDealerNo = "";

            Validate();  //Validate form so all data sets are updated with field values
            lsDealerNo = DEALERcomboBox.Text.ToString().Trim();

            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            oPNDEALRTableAdapter.Connection = tableAdapConn;
            tableAdapTran = oPNDEALRTableAdapter.BeginTransaction();
            oPNDEALRTableAdapter.Transaction = tableAdapTran;

            try
            {
                oPNDEALRTableAdapter.DeleteQuery(lsDealerNo);
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
                iacDataSet.OPNDEALR.Clear();
                lsKey = null;
                StartUpConfiguration();
            }

        }
    }
}


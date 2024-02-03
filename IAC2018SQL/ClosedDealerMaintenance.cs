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
using DevExpress.XtraEditors;


namespace IAC2021SQL
{
    public partial class ClosedDealerMaintenance : DevExpress.XtraEditors.XtraForm
    {
        //private String Program.gsKey="";
        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection  tableAdapConn = null;

        private bool lbAddFlag = false,lbEdit = false,lbILockedIt = false;
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
            if (!String.IsNullOrEmpty(DEALERcomboBox.EditValue.ToString()))
            {
                //iacDataSet.DEALER.Clear();
                iacDataSet.DEALHIST.Clear();
                dEALERTableAdapter.Fill(iacDataSet.DEALER, (Int32)DEALERcomboBox.EditValue);
                if (iacDataSet.DEALER.Rows.Count > 0)
                {
                    dEALHISTTableAdapter.FillAllByDealerAcc(iacDataSet.DEALHIST, (Int32)DEALERcomboBox.EditValue);
                    lnContOSLoansRatio = 0;
                    if (iacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_OLOAN") != null)
                        if (iacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN") != 0)
                            lnContOSLoansRatio = Convert.ToDouble(iacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_CONT") / iacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN"));
                    ResperOSLoanstextBox.Text = (lnContOSLoansRatio != 0) ? lnContOSLoansRatio.ToString("P", new System.Globalization.CultureInfo("en-US")) : "";
                    ResperOSLoanstextBox2.Text = ResperOSLoanstextBox.Text;
                    dLRLISTBYNUMTableAdapter.Fill(iacDataSet.DLRLISTBYNUM);
                    dEALERLISTTableAdapter.FillAll(iacDataSet.DEALERLIST);
                    //DEALERcomboBox.EditValue = (Program.gsKey != null) ? Program.gsKey : "";
                }
                else
                {
                    lbAddFlag = true;
                    toolStripButtonNew.Enabled = false;
                    iacDataSet.DEALER.Clear();
                    DealerbindingSource.AddNew();
                    DealerbindingSource.EndEdit();

                    // Set NULL VALUES to empty string
                    iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_ACC_NO", DEALERcomboBox.EditValue.ToString().Trim());
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
                    /*ActiveControl = dEALER_NAMETextBox;
                    dEALER_NAMETextBox.SelectAll();*/
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
                if (ActiveControl == DEALERcomboBox)
                    return;
                toolStripButtonSave.Enabled = true;
            }
        }

        private void DEALERcomboBox_Validated(object sender, EventArgs e)
        {
            LookUpEdit lookUp = sender as LookUpEdit;
            Object lookAt = lookUp.EditValue;

            if (lookAt == null)
                return;
            Int32 lnDealerNo = 0;
            Int32 DLRPOS = -1;
            Object Key = null;

            lnDealerNo = !String.IsNullOrEmpty(lookUp.EditValue.ToString()) ? (Int32)lookUp.EditValue : 0;

            if (lnDealerNo == 0)
                return;
            
            setRelatedData();
            if (iacDataSet.DEALER.Rows.Count > 0)
            {
                if (!lbAddFlag)
                    toolStripButtonEdit.Enabled = true;
                if (iacDataSet.DEALHIST.Rows.Count == 0 && !lbEdit)
                    toolStripButtonDelete.Enabled = true;
                else
                    toolStripButtonDelete.Enabled = false;
                Key = iacDataSet.DEALER.Rows[0].Field<Int32>("id");
                DLRPOS = DLRLISTBYNUMbindingSource.Find("id", (Int32)Key);

                if (DLRPOS != -1)
                {
                    DealerListbindingSource.Position = DealerListbindingSource.Find("id", (Int32)Key);
                }
            }
            else
            {
                //DEALERcomboBox.EditValue = lnDealerNo;
            }
            dEALER_NAMETextBox.Focus();
            dEALER_NAMETextBox.SelectAll();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Int32 lnDealerNo = 0;

            if (lbAddFlag)
                iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_ACC_NO", DEALERcomboBox.EditValue.ToString().Trim());
            Validate();  //Validate form so all data sets are updated with field values
            DealerbindingSource.EndEdit();
            if(!lbAddFlag)
                lnDealerNo = (Int32)DEALERcomboBox.EditValue;

            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;

            tableAdapConn.Open();                                                                                        
            dEALERTableAdapter.Connection = tableAdapConn;
            tableAdapTran = dEALERTableAdapter.BeginTransaction();
            dEALERTableAdapter.Transaction = tableAdapTran;
            try
            {
                if (!lbAddFlag)
                    dEALERTableAdapter.Update(iacDataSet.DEALER.Rows[DealerbindingSource.Position]);
                else
                    // Moses Newman 05/10/2022 Allow user entry of NEW dealer number, no more identity for id!
                    dEALERTableAdapter.Insert(iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_ACC_NO"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_NAME"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_ADDR"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_HOME_PHONE"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_CITY"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_ST"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_WORK_PHONE"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_ZIP"),
                                              (DateTime?)DateTime.Now.Date,
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_RSV"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_CONT"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_OLOAN"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_ADJ"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_BAD"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_LOSS"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_RSV"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_CONT"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_OLOAN"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_ADJ"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_BAD"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_LOSS"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("DEALER_STATUS"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_AMORT_INT"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_AMORT_INT"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_OLD_INT"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_OLD_INT"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_SIMPLE_INT"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_SIMPLE_INT"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_AMORT_PDI"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_AMORT_PDI"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_SIMPLE_PDI"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_SIMPLE_PDI"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_CUR_OLD_PDI"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Decimal?>("DEALER_YTD_OLD_PDI"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Boolean?>("IsLocked"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("LockedBy"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<DateTime?>("LockTime"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<DateTime?>("DealerStartDate"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("CellPhone"),
                                              iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<String>("Email"));
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
                /*   Moses Newman 05/10/2022 no more identity for id.
                if (lbAddFlag)
                {
                    if (insertID != null)
                    {
                        lnDealerNo = (Int32)insertID;
                        iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_ACC_NO", Convert.ToString(lnDealerNo).Trim());
                    }
                }*/
                dEALERTableAdapter.UnlockRecord(iacDataSet.DEALER.Rows[DealerbindingSource.Position].Field<Int32>("id"));
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
                Program.gsKey = lnDealerNo.ToString().Trim();
                DEALERcomboBox.EditValue = lnDealerNo;
                if (lbEdit)
                {
                    lbEdit = false;
                    SetViewMode();
                }
            }
        }

        private void DealerMaintenance_Load(object sender, EventArgs e)
        {
            /*ActiveControl = DEALERcomboBox;
            DEALERcomboBox.Focus();
            DEALERcomboBox.SelectAll();*/
            nullableDateTimePickerDealerStartDate.EditValue = DateTime.Now.Date;
            StartUpConfiguration();
            PerformAutoScale();
        }

        private void StartUpConfiguration()
        {
            dLRLISTBYNUMTableAdapter.Fill(iacDataSet.DLRLISTBYNUM);
            dEALERLISTTableAdapter.FillAll(iacDataSet.DEALERLIST);
            DEALERcomboBox.Enabled = true;
            if (!String.IsNullOrEmpty(Program.gsKey))
            {
                DEALERcomboBox.EditValue = Convert.ToInt32(Program.gsKey);
                setRelatedData();
                if (iacDataSet.DEALER.Rows.Count == 0)
                {
                    DEALERcomboBox.EditValue = 0;
                    dEALER_NAMETextBox.Text = "";
                }
            }
            else
            {
                DEALERcomboBox.EditValue = 0;
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
                // Moses Newman 05/10/2022 no more identity specification for id, so no NEW button for now!
                toolStripButtonNew.Enabled = false;
                textBoxDealerEmail.Enabled = false;
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
            dEALER_NAMETextBox.Enabled = true;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonNew.Enabled = false;
            textBoxDealerEmail.Enabled = true;
            ActiveControl = dEALER_NAMETextBox;
            dEALER_NAMETextBox.SelectAll();
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

        private void LockDealerRecord()
        {   
            Object loLockedBy = dEALERTableAdapter.LockedBy((Int32)DEALERcomboBox.EditValue),
                   loLockedTime = dEALERTableAdapter.LockTime((Int32)DEALERcomboBox.EditValue);
             
            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(iacDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** DEALER: " + DEALERcomboBox.EditValue.ToString().Trim() + " WAS LOCKED BY USER: " +
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
                dEALERTableAdapter.LockRecord(Program.gsUserID, (Int32)DEALERcomboBox.EditValue);
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

            loLockedBy = dEALERTableAdapter.LockedBy(iacDataSet.DEALER.Rows[0].Field<Int32>("id"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    dEALERTableAdapter.UnlockRecord(iacDataSet.DEALER.Rows[0].Field<Int32>("id"));
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
            Int32 lnDealerNo = 0;

            Validate();  //Validate form so all data sets are updated with field values
            lnDealerNo = (Int32)DEALERcomboBox.EditValue;

            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            dEALERTableAdapter.Connection = tableAdapConn;
            tableAdapTran = dEALERTableAdapter.BeginTransaction();
            dEALERTableAdapter.Transaction = tableAdapTran;

            try
            {
                dEALERTableAdapter.Delete(lnDealerNo);
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

        private void DEALERcomboBox_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUp = sender as LookUpEdit;
            Object thisval = lookUp.EditValue;
            if (thisval == null)
                return;
            if (lookUp.EditValue.ToString() != String.Empty)
                if (lookUp.EditValue.GetType() == typeof(String))
                    lookUp.EditValue = Convert.ToInt32(lookUp.EditValue);
            Int32 lnEditVal = lookUp.EditValue.ToString()!=String.Empty ? (Int32)lookUp.EditValue : 0;
            if (lnEditVal == 0)
                return;
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            lbAddFlag = true;
            toolStripButtonNew.Enabled = false;
            iacDataSet.DEALER.Clear();
            DealerbindingSource.AddNew();
            DealerbindingSource.EndEdit();

            // Set NULL VALUES to empty string
            iacDataSet.DEALER.Rows[DealerbindingSource.Position].SetField<String>("DEALER_ACC_NO", DEALERcomboBox.EditValue.ToString().Trim());
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
            ActiveControl = dEALER_NAMETextBox;
            dEALER_NAMETextBox.SelectAll();

        }

        // Moses Newman 12/18/2019 Handle validation of email address.
        private void textBoxDealerEmail_Validating(object sender, CancelEventArgs e)
        {
            Program.EmailValidator(ref sender, ref e, ref errmsg);
        }

        private void DEALERcomboBox_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if(lbAddFlag)
            {
                //e.DisplayText = "NEWDEALER";
            }
               
        }

        private void ClosedDealerMaintenance_Shown(object sender, EventArgs e)
        {
            this.DEALERcomboBox.Focus();
        }

        private void DEALERcomboBox_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            DataRow newListRow = iacDataSet.DLRLISTBYNUM.NewRow();

            LookUpEdit lookUp = sender as LookUpEdit; 
            if (lbAddFlag || lbEdit || lookUp == null)  // Moses Newman 02/03/2024 Handle Null;
                return;

            if (!String.IsNullOrEmpty(lookUp.EditValue.ToString()) && MessageBox.Show(
                    this, "Dealer number: " + lookUp.EditValue.ToString() + " does not exist. Would you like to add it?",
                    "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DLRLISTBYNUMbindingSource.AddNew();
                DLRLISTBYNUMbindingSource.EndEdit();
                iacDataSet.DLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField("id", Convert.ToInt32(lookUp.EditValue));
                iacDataSet.DLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField("DEALER_NAME", "");
                DLRLISTBYNUMbindingSource.EndEdit();
                e.Handled = true;
                dEALER_NAMETextBox.Focus();
            }
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
                DEALERcomboBox.ItemIndex = (Int32)DEALERcomboBox.Properties.GetKeyValueByDisplayValue(Program.gsKey);
                ActiveControl = dEALER_NAMETextBox;
                dEALER_NAMETextBox.Select();
            }
            Program.gsKey = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class FormClosedDealerContingentMaintenance : DevExpress.XtraEditors.XtraForm
    {
        private Boolean lbFormClosing = false, lbEdit = false, lbAdd = false, lbILockedIt = false,
                        lbFromSetRelated = false, lbFromMovement = false;

        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection tableAdapConn = null;

        public FormClosedDealerContingentMaintenance()
        {
            InitializeComponent();
        }

        private void FormClosedDealerContingentMaintenance_Load(object sender, EventArgs e)
        {
            StartUpConfiguration();
            PerformAutoScale();
        }

        private void StartUpConfiguration()
        {
            dLRLISTBYNUMTableAdapter.Fill(CONTINGiacDataSet.DLRLISTBYNUM);
            dEALERLISTTableAdapter.FillAll(CONTINGiacDataSet.DEALERLIST);
            dateTimePickerPostDate.EditValue = DateTime.Now.Date;
            DEALERcomboBox.EditValue = 0;
            Text = "Closed Dealer Contingents (VIEW Mode)";

            toolStripButtonAdd.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripButtonSave.Enabled = false;

            setRelatedData();
            DefaultSettings();
        }

        private void DefaultSettings()
        {
            if (!lbEdit && !lbAdd)
            {
                toolStripButtonAdd.Enabled = true;
                toolStripButtonEdit.Enabled = true;
                toolStripButtonDelete.Enabled = true;
                dateTimePickerPostDate.Enabled = true;
                textBoxDealerLossReserve.Enabled = false;
                textBoxDealerLossReserveComment.Enabled = false;
                textBoxContingentReserve.Enabled = false;
                textBoxContingentReserveComment.Enabled = false;
                textBoxAdjust.Enabled = false;
                textBoxAdjustComment.Enabled = false;
                textBoxRecoveryForBad.Enabled = false;
                textBoxRecoveryForBadComment.Enabled = false;
                textBoxReservedForLoss.Enabled = false;
                textBoxReserveForLossComment.Enabled = false;
                textBoxOLoans.Enabled = false;
                textBoxOLoanComment.Enabled = false;
                textBoxNotesPayable.Enabled = false;
                textBoxNPComment.Enabled = false;
                textBoxInterestSimple.Enabled = false;
                textBoxSIMPLE_SW.Enabled = false;
                textBoxInterestSimpleComment.Enabled = false;                
                textBoxInterestAmort.Enabled = false;
                textBoxAMORT_SW.Enabled = false;
                textBoxInterestAmortComment.Enabled = false;
                textBoxInterestNonAmort.Enabled = false;
                textBoxOLD_SW.Enabled = false;
                textBoxInterestNonAmortComment.Enabled = false;
                
                bindingNavigator.Enabled = true;
                bindingNavigator.Visible = true;
                toolStripButtonCancel.Visible = false;
                toolStripButtonCancel.Enabled = false;
                DEALERcomboBox.Enabled = true;
            }
            else
            {
                toolStripButtonAdd.Enabled = false;
                toolStripButtonEdit.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                dateTimePickerPostDate.Enabled = true;
                textBoxDealerLossReserve.Enabled = true;
                textBoxDealerLossReserveComment.Enabled = true;
                textBoxContingentReserve.Enabled = true;
                textBoxContingentReserveComment.Enabled = true;
                textBoxAdjust.Enabled = true;
                textBoxAdjustComment.Enabled = true;
                textBoxRecoveryForBad.Enabled = true;
                textBoxRecoveryForBadComment.Enabled = true;
                textBoxReservedForLoss.Enabled = true;
                textBoxReserveForLossComment.Enabled = true;
                textBoxOLoans.Enabled = true;
                textBoxOLoanComment.Enabled = true;
                textBoxNotesPayable.Enabled = true;
                textBoxNPComment.Enabled = true;
                textBoxInterestAmort.Enabled = true;
                textBoxAMORT_SW.Enabled = true;
                textBoxInterestSimpleComment.Enabled = true;
                textBoxInterestSimple.Enabled = true;
                textBoxSIMPLE_SW.Enabled = true;
                textBoxInterestAmortComment.Enabled = true;
                textBoxInterestNonAmort.Enabled = true;
                textBoxOLD_SW.Enabled = true;
                textBoxInterestNonAmortComment.Enabled = true;
            }

            if (lbEdit)
            {
                toolStripButtonAdd.Enabled = false;
                toolStripButtonEdit.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                lbAdd = false;
                bindingNavigator.Enabled = false;
                bindingNavigator.Visible = true;
                setRelatedData();
                toolStripButtonCancel.Visible = false;
                toolStripButtonCancel.Enabled = false;
                DEALERcomboBox.Enabled = false;
                ActiveControl = dateTimePickerPostDate;
                dateTimePickerPostDate.Select();
            }
            if (lbAdd)
            {
                toolStripButtonAdd.Enabled = false;
                toolStripButtonEdit.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                lbEdit = false;
                bindingNavigator.Enabled = false;
                bindingNavigator.Visible = false;
                setRelatedData();
                toolStripButtonCancel.Visible = true;
                toolStripButtonCancel.Enabled = true;
                dateTimePickerPostDate.Enabled = true;
                ActiveControl = DEALERcomboBox;
                DEALERcomboBox.SelectAll();
            }

            if (!lbEdit && !lbAdd)
            {
                ActiveControl = DEALERcomboBox;
                DEALERcomboBox.SelectAll();
            }
        }


        private void SetEditMode()
        {
            Text = "Closed Dealer Contingents (EDIT Mode)";
            toolStripButtonAdd.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            lbEdit = true;
            LockContingRecord();
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = true;
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            DEALERcomboBox.Enabled = false;
            ActiveControl = dateTimePickerPostDate;
            dateTimePickerPostDate.Select();
            toolStripButtonAdd.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            dateTimePickerPostDate.Enabled = true;
            textBoxDealerLossReserve.Enabled = true;
            textBoxDealerLossReserveComment.Enabled = true;
            textBoxContingentReserve.Enabled = true;
            textBoxContingentReserveComment.Enabled = true;
            textBoxAdjust.Enabled = true;
            textBoxAdjustComment.Enabled = true;
            textBoxRecoveryForBad.Enabled = true;
            textBoxRecoveryForBadComment.Enabled = true;
            textBoxReservedForLoss.Enabled = true;
            textBoxReserveForLossComment.Enabled = true;
            textBoxOLoans.Enabled = true;
            textBoxOLoanComment.Enabled = true;
            textBoxNotesPayable.Enabled = true;
            textBoxNPComment.Enabled = true;
            textBoxInterestAmort.Enabled = true;
            textBoxAMORT_SW.Enabled = true;
            textBoxInterestSimpleComment.Enabled = true;
            textBoxInterestSimple.Enabled = true;
            textBoxSIMPLE_SW.Enabled = true;
            textBoxInterestAmortComment.Enabled = true;
            textBoxInterestNonAmort.Enabled = true;
            textBoxOLD_SW.Enabled = true;
            textBoxInterestNonAmortComment.Enabled = true;
        }


        private void SetAddMode()
        {
            DEALERcomboBox.EditValue = 0;
            lbEdit = false;
            lbAdd = true;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonAdd.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = false;
            dateTimePickerPostDate.Enabled = true;
            Text = "Closed Dealer Contingents (ADD Mode)";
            CONTINGiacDataSet.CONTING.Clear();
            CONTINGiacDataSet.DEALER.Clear();
            DefaultSettings();
            ActiveControl = DEALERcomboBox;
            DEALERcomboBox.SelectAll();
        }

        private void SetViewMode()
        {
            dateTimePickerPostDate.EditValue = DateTime.Now.Date;
            Text = "Closed Dealer Contingents (VIEW Mode)";

            toolStripButtonAdd.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripButtonSave.Enabled = false;
            ActiveControl = DEALERcomboBox;
            DEALERcomboBox.SelectAll();
        }

        private void setRelatedData()
        {
            Int32 lnDealer = (Int32)DEALERcomboBox.EditValue;

            if (lbEdit)
                return;
            lbFromSetRelated = true;
            IACDataSetTableAdapters.CONTINGTableAdapter CONTINGTableAdapter = new IACDataSetTableAdapters.CONTINGTableAdapter();

            if (!lbAdd)
            {
                if(!lbFromMovement)
                    cONTINGTableAdapter.FillByDealerDate(CONTINGiacDataSet.CONTING, lnDealer, (DateTime)dateTimePickerPostDate.EditValue, 30);
            }


            if (CONTINGiacDataSet.CONTING.Rows.Count > 0)
            {
                dEALERTableAdapter.Fill(CONTINGiacDataSet.DEALER, CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_DEALER"));
                dateTimePickerPostDate.EditValue = CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE").Date;
            }
            else
            {
                if ((Int32)DEALERcomboBox.EditValue == 0)
                    return;
                dEALERTableAdapter.Fill(CONTINGiacDataSet.DEALER, (Int32)DEALERcomboBox.EditValue);
                dateTimePickerPostDate.EditValue = DateTime.Now.Date;
            }
            if (CONTINGiacDataSet.DEALER.Rows.Count > 0)
            {
                DEALERcomboBox.EditValue = CONTINGiacDataSet.DEALER.Rows[0].Field<Int32>("id");
            }
            lbFromSetRelated = false;
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
                if (ActiveControl == DEALERcomboBox)
                    return;
                toolStripButtonSave.Enabled = true;
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Validate();
            CONTINGbindingSource.EndEdit();

            if (CONTINGiacDataSet.DEALER.Rows.Count == 0)
                return;
            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            cONTINGTableAdapter.Connection = tableAdapConn;
            tableAdapTran = cONTINGTableAdapter.BeginTransaction();
            cONTINGTableAdapter.Transaction = tableAdapTran;
            try
            {
                cONTINGTableAdapter.Update(CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position]);
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
                cONTINGTableAdapter.UnlockRecord(Program.gsUserID, CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_DEALER"),
                                                CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE"),
                                                CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                CONTINGiacDataSet.AcceptChanges();
                if (lbEdit)
                    lbEdit = false;
                if (lbAdd)
                    CONTINGiacDataSet.CONTING.Clear();
                StartUpConfiguration();
                // Moses Newman 09/18/2013 Set dealer number as Active Control if in ADD Mode!
                if (!lbAdd)
                {
                    ActiveControl = dateTimePickerPostDate;
                    dateTimePickerPostDate.Select();
                }
                else
                {
                    ActiveControl = DEALERcomboBox;
                    DEALERcomboBox.SelectAll();
                }
            }
        }
        
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            SetAddMode();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void DEALERcomboBox_Validated(object sender, EventArgs e)
        {
            if (lbFormClosing || (Int32)DEALERcomboBox.EditValue == 0)
                return;

            int lnContingentPos = 0, lnSeq = 0;

            Object loContingentSeq = null;

            Int32 lnDealerNo = DEALERcomboBox.EditValue != null ? (Int32)DEALERcomboBox.EditValue:0;
            if (!lbEdit)
            {
                setRelatedData();
            }
            if (CONTINGiacDataSet.CONTING.Rows.Count != 0)
            {
                if (CONTINGbindingSource.Position == -1)
                    lnContingentPos = CONTINGbindingSource.Find("CONTING_DEALER", lnDealerNo);
                else
                    lnContingentPos = CONTINGbindingSource.Position;
                if (lnContingentPos > -1)
                {
                    if (lbAdd)
                        return;
                    else
                        CONTINGbindingSource.Position = lnContingentPos;
                }
                else
                {
                    if (!lbAdd)
                    {
                        lnDealerNo = CONTINGiacDataSet.CONTING.Rows[0].Field<Int32>("CONTINGENT_DEALER");
                        CONTINGbindingSource.MoveFirst();
                    }
                }
            }
            else
            {
                if (!lbAdd)
                    return;
            }

            if (CONTINGiacDataSet.DEALER.Rows.Count == 0 && (Int32)DEALERcomboBox.EditValue != 0)
            {
                MessageBox.Show("Sorry no dealer found that matches your selected dealer number!");
                DEALERcomboBox.EditValue = 0;
                
                ActiveControl = dEALER_NAMETextBox;
                dEALER_NAMETextBox.SelectAll();
            }
            else
            {
                if (lbEdit)
                    if (CONTINGiacDataSet.CONTING.Rows.Count == 0)
                    {
                        MessageBox.Show("Sorry no contingent records found that match your selected dealer number!");
                        ActiveControl = DEALERcomboBox;
                        DEALERcomboBox.Select();
                    }
                if (lbAdd && (Int32)DEALERcomboBox.EditValue != 0)
                {
                    CONTINGbindingSource.AddNew();
                    CONTINGbindingSource.EndEdit();

                    CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].SetField<Int32>("CONTING_DEALER", (Int32)DEALERcomboBox.EditValue);
                    CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].SetField<DateTime>("CONTING_POST_DATE", DateTime.Now.Date);
                    loContingentSeq = cONTINGTableAdapter.MaxSeqQuery((Int32)DEALERcomboBox.EditValue, DateTime.Now.Date);
                    if (loContingentSeq != null)
                        lnSeq = (int)loContingentSeq + 1;
                    else
                        lnSeq = 0;   //Closed and Open contingents start with 0 for first sequence number
                    CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].SetField<Int32>("CONTING_ENTRY_SEQ", lnSeq);
                    CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].SetField<Char>("CONTING_POST_IND", (Char)(255));
                    if (CONTINGiacDataSet.CONTING.Rows.Count != 0)
                    {
                        toolStripButtonSave.Enabled = true;
                    }
                }
                if (CONTINGiacDataSet.DEALER.Rows.Count > 0 && !lbAdd)
                    if (lbAdd || lbEdit)
                    {
                        dateTimePickerPostDate.Enabled = true;
                        ActiveControl = dateTimePickerPostDate;
                        dateTimePickerPostDate.Select();
                    }
            }
        }

        private void FormClosedDealerContingentMaintenance_Shown(object sender, EventArgs e)
        {
            DEALERcomboBox.Focus();
        }

        private void DEALERcomboBox_EditValueChanged(object sender, EventArgs e)
        {
            Int32 lnEditVal = DEALERcomboBox.EditValue != null ? (Int32)DEALERcomboBox.EditValue : 0;
            if (lnEditVal == 0)
                return;
            ActiveControl = DEALERcomboBox;
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            lbAdd = false;
            lbEdit = false;
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            if (CONTINGiacDataSet.CONTING.Rows.Count > 1 && CONTINGbindingSource.Position != -1)
            {
                CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].CancelEdit();
                CONTINGbindingSource.RemoveCurrent();
                CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].AcceptChanges();
            }
            if (CONTINGiacDataSet.CONTING.Rows.Count > 0)
                CONTINGiacDataSet.CONTING.Clear();
            else
                DEALERcomboBox.EditValue = 0;
            DefaultSettings();
            setRelatedData();
            ActiveControl = dateTimePickerPostDate;
            dateTimePickerPostDate.Select();
            if (CONTINGiacDataSet.CONTING.Rows.Count > 0)
            {
                CONTINGbindingSource.MoveLast();
                CONTINGbindingSource.MoveFirst();
            }
            toolStripButtonAdd.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripButtonSave.Enabled = false;
            bindingNavigator.Enabled = true;
            bindingNavigator.Visible = true;
            Text = "Closed Dealer Contingents (VIEW Mode)";
        }

        private void FormClosedDealerContingentMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CONTINGiacDataSet.CONTING.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = cONTINGTableAdapter.LockedBy(CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_DEALER"),
                                                    CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE"),
                                                    CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    cONTINGTableAdapter.UnlockRecord(Program.gsUserID,CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_DEALER"),
                                                    CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE"),
                                                    CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (CONTINGiacDataSet.CONTING.Rows.Count < 1)
                return;
            Int32 lnDealer = CONTINGiacDataSet.CONTING.Rows[0].Field<Int32>("CONTING_DEALER");
            DateTime ldSrchDate = CONTINGiacDataSet.CONTING.Rows[0].Field<DateTime>("CONTING_POST_DATE");
            Validate();
            CONTINGbindingSource.EndEdit();

            if (CONTINGiacDataSet.DEALER.Rows.Count == 0)
                return;
            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            cONTINGTableAdapter.Connection = tableAdapConn;
            tableAdapTran = cONTINGTableAdapter.BeginTransaction();
            cONTINGTableAdapter.Transaction = tableAdapTran;

            try
            {
                cONTINGTableAdapter.Delete(CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_DEALER"),
                                                CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE"),
                                                CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
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
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                CONTINGiacDataSet.AcceptChanges();
                CONTINGiacDataSet.CONTING.Clear();
                DEALERcomboBox.EditValue= lnDealer;
                dateTimePickerPostDate.EditValue = ldSrchDate;
                setRelatedData();
                DefaultSettings();
                ActiveControl = dateTimePickerPostDate;
                dateTimePickerPostDate.Select();
            }
        }

        private void CONTINGbindingSource_PositionChanged(object sender, EventArgs e)
        { 
            if (CONTINGbindingSource.Position == -1 || lbFromSetRelated || lbEdit || lbAdd || !bindingNavigator.Visible)
                return;
            if (CONTINGiacDataSet.CONTING.Rows.Count > 0)
            {
                lbFromMovement = true;
                DEALERcomboBox.EditValue = CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_DEALER");
                setRelatedData();
                lbFromMovement = false;
            }
        }

        private void LockContingRecord()
        {
            Object loLockedBy   = cONTINGTableAdapter.LockedBy((Int32)DEALERcomboBox.EditValue, (DateTime)dateTimePickerPostDate.EditValue, CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ")),
                   loLockedTime = cONTINGTableAdapter.LockTime((Int32)DEALERcomboBox.EditValue, (DateTime)dateTimePickerPostDate.EditValue, CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));

            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(CONTINGiacDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** (CONTINGENT RECORD) DEALER#: " + DEALERcomboBox.EditValue.ToString().Trim() + " POST DATE:" + dateTimePickerPostDate.Text + " SEQUENCE #: " + CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ").ToString().TrimStart() + " WAS LOCKED BY USER: " +
                    loLockedBy + " " +
                    CONTINGiacDataSet.ULIST.Rows[0].Field<String>("LIST_NAME") +
                    "\nON: " + ((DateTime)loLockedTime).ToLongDateString() + " " +
                    ((DateTime)loLockedTime).ToLongTimeString() + "\n" +
                    "YOU MUST WAIT UNTIL THEY RELEASE IT! ***", "RECORD LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripButtonSave.Enabled = false;
                ULISTTableAdapter.Dispose();
                loLockedBy = null;
                lbEdit = false;
                CONTINGiacDataSet.Clear();
                StartUpConfiguration();
            }
            else
            {
                cONTINGTableAdapter.LockRecord(Program.gsUserID, (Int32)DEALERcomboBox.EditValue, (DateTime)dateTimePickerPostDate.EditValue, CONTINGiacDataSet.CONTING.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
                lbILockedIt = true;   //  Make sure other instances of form don't unlock this record!
            }
        }
    }
}

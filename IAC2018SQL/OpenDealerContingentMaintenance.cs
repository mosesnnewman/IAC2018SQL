using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class FormOpenDealerContingentMaintenance : Form
    {
        private Boolean lbFormClosing = false, lbEdit = false, lbAdd = false, lbJustSaved = false, lbILockedIt = false,
                        lbFromSetRelated = false, lbFromMovement = false, lbFromDealerNameChange = false;
        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection tableAdapConn = null;

        public FormOpenDealerContingentMaintenance()
        {
            InitializeComponent();
        }

        private void FormOpenDealerContingentMaintenance_Load(object sender, EventArgs e)
        {
            oPNDLRLISTBYNUMTableAdapter.Fill(CONTINGiacDataSet.OPNDLRLISTBYNUM);
            oPNDEALRLISTTableAdapter.FillAll(CONTINGiacDataSet.OPNDEALRLIST);
            StartUpConfiguration();
            PerformAutoScale();
        }

        private void StartUpConfiguration()
        {
            dateTimePickerPostDate.Value = DateTime.Now.Date;
            DealerNamecomboBox.Text = "";
            DEALERcomboBox.Text = "";
            Text = "Open Dealer Contingents (VIEW Mode)";

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

                bindingNavigator.Enabled = true;
                bindingNavigator.Visible = true;
                toolStripButtonCancel.Visible = false;
                toolStripButtonCancel.Enabled = false;
                DealerNamecomboBox.Enabled = true;
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
                DealerNamecomboBox.Enabled = false;
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
            Text = "Open Dealer Contingents (EDIT Mode)";
            toolStripButtonAdd.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            lbEdit = true;
            LockContingRecord();
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = true;
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            DealerNamecomboBox.Enabled = false;
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
        }


        private void SetAddMode()
        {
            DEALERcomboBox.Text = "";

            DealerNamecomboBox.Text = "";
            lbEdit = false;
            lbAdd = true;
            toolStripButtonEdit.Enabled = false;
            toolStripButtonAdd.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            bindingNavigator.Enabled = false;
            bindingNavigator.Visible = false;
            dateTimePickerPostDate.Enabled = true;
            Text = "Open Dealer Contingents (ADD Mode)";
            CONTINGiacDataSet.OPNCONT.Clear();
            CONTINGiacDataSet.OPNDEALR.Clear();
            DefaultSettings();
            ActiveControl = DEALERcomboBox;
            DEALERcomboBox.SelectAll();
        }

        private void SetViewMode()
        {
            dateTimePickerPostDate.Value = DateTime.Now.Date;
            Text = "Open Dealer Contingents (VIEW Mode)";

            toolStripButtonAdd.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripButtonSave.Enabled = false;
            ActiveControl = DEALERcomboBox;
            DEALERcomboBox.SelectAll();
        }

        private void setRelatedData()
        {
            String lsDealer = DEALERcomboBox.Text;

            if (lbEdit)
                return;
            lbFromSetRelated = true;
            IACDataSetTableAdapters.OPNCONTTableAdapter oPNCONTTableAdapter = new IACDataSetTableAdapters.OPNCONTTableAdapter();

            if (!lbAdd)
            {
                if (!lbFromMovement)
                    oPNCONTTableAdapter.FillByDealerDate(CONTINGiacDataSet.OPNCONT, lsDealer, (DateTime)dateTimePickerPostDate.Value, 30);
                if (lbJustSaved)
                {
                    lbJustSaved = false;
                    lbAdd = false;
                    lbEdit = false;
                }
            }


            if (CONTINGiacDataSet.OPNCONT.Rows.Count > 0)
            {
                oPNDEALRTableAdapter.Fill(CONTINGiacDataSet.OPNDEALR, CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<String>("CONTING_DEALER"));
                dateTimePickerPostDate.Value = CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE").Date;
            }
            else
            {
                oPNDEALRTableAdapter.Fill(CONTINGiacDataSet.OPNDEALR, DEALERcomboBox.Text.TrimStart().TrimEnd());
                dateTimePickerPostDate.Value = DateTime.Now.Date;
            }
            if (CONTINGiacDataSet.OPNDEALR.Rows.Count > 0)
            {
                lbFromDealerNameChange = true;
                DEALERcomboBox.Text = CONTINGiacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_ACC_NO");
                DealerNamecomboBox.Text = CONTINGiacDataSet.OPNDEALR.Rows[0].Field<String>("OPNDEALR_NAME");
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

        private void DEALERcomboBox_Validated(object sender, EventArgs e)
        {
            if (lbFormClosing || DEALERcomboBox.Text.TrimEnd() == "")
                return;

            int lnContingentPos = 0, lnSeq = 0;

            Object loContingentSeq = null;

            String lsDealerNo = "";

            if (DEALERcomboBox.Text.ToString().Trim().Length < 3 && DEALERcomboBox.Text.ToString().Trim().Length > 0)
            {
                lbFromDealerNameChange = true;
                DEALERcomboBox.Text = DEALERcomboBox.Text.PadLeft(3, '0');
            }

            lsDealerNo = DEALERcomboBox.Text;
            if (!lbEdit)
            {
                setRelatedData();
            }
            if (CONTINGiacDataSet.OPNCONT.Rows.Count != 0)
            {
                if (CONTINGbindingSource.Position == -1)
                    lnContingentPos = CONTINGbindingSource.Find("CONTING_DEALER", lsDealerNo);
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
                        lsDealerNo = CONTINGiacDataSet.OPNCONT.Rows[0].Field<String>("CONTINGENT_DEALER");
                        CONTINGbindingSource.MoveFirst();
                    }
                }
            }
            else
            {
                if (!lbAdd)
                    return;
            }

            if (CONTINGiacDataSet.OPNDEALR.Rows.Count == 0 && DEALERcomboBox.Text.TrimEnd().Length != 0)
            {
                MessageBox.Show("Sorry no dealer found that matches your selected dealer number!");
                DEALERcomboBox.Text = "";
                DealerNamecomboBox.Text = "";
                ActiveControl = DealerNamecomboBox;
                DealerNamecomboBox.SelectAll();
            }
            else
            {
                if (lbEdit)
                    if (CONTINGiacDataSet.OPNCONT.Rows.Count == 0)
                    {
                        MessageBox.Show("Sorry no contingent records found that match your selected dealer number!");
                        ActiveControl = DEALERcomboBox;
                        DEALERcomboBox.Select();
                    }
                if (lbAdd && DEALERcomboBox.Text.ToString().TrimEnd() != "")
                {
                    CONTINGbindingSource.AddNew();
                    CONTINGbindingSource.EndEdit();

                    CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].SetField<String>("CONTING_DEALER", DEALERcomboBox.Text.ToString());
                    CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].SetField<DateTime>("CONTING_POST_DATE", DateTime.Now.Date);
                    loContingentSeq = oPNCONTTableAdapter.MaxSeqQuery(DEALERcomboBox.Text.ToString(), DateTime.Now.Date);
                    if (loContingentSeq != null)
                        lnSeq = (int)loContingentSeq + 1;
                    else
                        lnSeq = 0;   //Closed and Open contingents start with 0 for first sequence number
                    CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].SetField<Int32>("CONTING_ENTRY_SEQ", lnSeq);
                    CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].SetField<Char>("CONTING_POST_IND", (Char)(255));
                    if (CONTINGiacDataSet.OPNCONT.Rows.Count != 0)
                    {
                        toolStripButtonSave.Enabled = true;
                    }
                }
                if (CONTINGiacDataSet.DEALER.Rows.Count > 0 && !lbAdd)
                    //DealerNamecomboBox.Text = CONTINGiacDataSet.DEALER.Rows[0].Field<String>("DEALER_NAME");
                    if (lbAdd || lbEdit)
                    {
                        dateTimePickerPostDate.Enabled = true;
                        ActiveControl = dateTimePickerPostDate;
                        dateTimePickerPostDate.Select();
                    }
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Validate();
            CONTINGbindingSource.EndEdit();

            if (CONTINGiacDataSet.OPNDEALR.Rows.Count == 0)
                return;
            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2018SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            oPNCONTTableAdapter.Connection = tableAdapConn;
            tableAdapTran = oPNCONTTableAdapter.BeginTransaction();
            oPNCONTTableAdapter.Transaction = tableAdapTran;
            try
            {
                oPNCONTTableAdapter.Update(CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position]);
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
                oPNCONTTableAdapter.UnlockRecord(Program.gsUserID, CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<String>("CONTING_DEALER"),
                                                CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE"),
                                                CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                CONTINGiacDataSet.AcceptChanges();
                if (lbEdit)
                    lbEdit = false;
                if (lbAdd)
                    CONTINGiacDataSet.OPNCONT.Clear();
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

        private void DEALERcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveControl = DealerNamecomboBox;
            DealerNamecomboBox.Select();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            SetAddMode();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            lbAdd = false;
            lbEdit = false;
            toolStripButtonCancel.Visible = false;
            toolStripButtonCancel.Enabled = false;
            if (CONTINGiacDataSet.OPNCONT.Rows.Count > 1 && CONTINGbindingSource.Position != -1)
            {
                CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].CancelEdit();
                CONTINGbindingSource.RemoveCurrent();
                CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].AcceptChanges();
            }
            if (CONTINGiacDataSet.OPNCONT.Rows.Count > 0)
                CONTINGiacDataSet.OPNCONT.Clear();
            else
                DEALERcomboBox.Text = "";
            DealerNamecomboBox.Text = "";
            DefaultSettings();
            setRelatedData();
            ActiveControl = dateTimePickerPostDate;
            dateTimePickerPostDate.Select();
            if (CONTINGiacDataSet.OPNCONT.Rows.Count > 0)
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
            Text = "Open Dealer Contingents (VIEW Mode)";
        }

        private void FormOpenDealerContingentMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CONTINGiacDataSet.OPNCONT.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = oPNCONTTableAdapter.LockedBy(CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<String>("CONTING_DEALER"),
                                                    CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE"),
                                                    CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    oPNCONTTableAdapter.UnlockRecord(Program.gsUserID, CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<String>("CONTING_DEALER"),
                                                    CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE"),
                                                    CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (CONTINGiacDataSet.OPNCONT.Rows.Count < 1)
                return;
            String lsDealer = CONTINGiacDataSet.OPNCONT.Rows[0].Field<String>("CONTING_DEALER");
            DateTime ldSrchDate = CONTINGiacDataSet.OPNCONT.Rows[0].Field<DateTime>("CONTING_POST_DATE");
            Validate();
            CONTINGbindingSource.EndEdit();

            if (CONTINGiacDataSet.OPNDEALR.Rows.Count == 0)
                return;
            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2018SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            oPNCONTTableAdapter.Connection = tableAdapConn;
            tableAdapTran = oPNCONTTableAdapter.BeginTransaction();
            oPNCONTTableAdapter.Transaction = tableAdapTran;

            try
            {
                oPNCONTTableAdapter.Delete(CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<String>("CONTING_DEALER"),
                                                CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<DateTime>("CONTING_POST_DATE"),
                                                CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
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
                CONTINGiacDataSet.OPNCONT.Clear();
                lbFromDealerNameChange = true;
                DEALERcomboBox.Text = lsDealer;
                dateTimePickerPostDate.Value = ldSrchDate;
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
            if (CONTINGiacDataSet.OPNCONT.Rows.Count > 0)
            {
                lbFromMovement = true;
                DEALERcomboBox.Text = CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<String>("CONTING_DEALER");
                setRelatedData();
                lbFromMovement = false;
            }
        }


        private void LockContingRecord()
        {
            Object loLockedBy   = oPNCONTTableAdapter.LockedBy(DEALERcomboBox.Text, (DateTime)dateTimePickerPostDate.Value, CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ")),
                   loLockedTime = oPNCONTTableAdapter.LockTime(DEALERcomboBox.Text, (DateTime)dateTimePickerPostDate.Value, CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));

            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(CONTINGiacDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** (CONTINGENT RECORD) DEALER#: " + DEALERcomboBox.Text + " POST DATE:" + dateTimePickerPostDate.Text + " SEQUENCE #: " + CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ").ToString().TrimStart() + " WAS LOCKED BY USER: " +
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
                oPNCONTTableAdapter.LockRecord(Program.gsUserID, DEALERcomboBox.Text, (DateTime)dateTimePickerPostDate.Value, CONTINGiacDataSet.OPNCONT.Rows[CONTINGbindingSource.Position].Field<Int32>("CONTING_ENTRY_SEQ"));
                lbILockedIt = true;   //  Make sure other instances of form don't unlock this record!
            }
        }

        private void DealerNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CONTINGiacDataSet.OPNDEALRLIST.Rows.Count > 0 && DealerNamecomboBox.SelectedIndex >= 0 && !lbFromDealerNameChange)
            {
                lbFromDealerNameChange = true;
                DEALERcomboBox.Text = CONTINGiacDataSet.OPNDEALRLIST.Rows[DealerNamecomboBox.SelectedIndex].Field<String>("OPNDEALR_ACC_NO");
            }
            else
            {
                lbFromDealerNameChange = false;
                ActiveControl = dateTimePickerPostDate;
                dateTimePickerPostDate.Select();
                return;
            }
            System.Windows.Forms.SendKeys.Send("{TAB}");
            System.Windows.Forms.SendKeys.Send("{TAB}");
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }
    }
}

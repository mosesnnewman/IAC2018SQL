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
    public partial class ClosedMasterContingentMaintenance : DevExpress.XtraEditors.XtraForm
    {
        private Boolean lbEdit = false, lbAdd = false, lbILockedIt = false;
        private Microsoft.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private Microsoft.Data.SqlClient.SqlConnection tableAdapConn = null;

        public ClosedMasterContingentMaintenance()
        {
            InitializeComponent();
        }

        private void MasterContingentMaintenance_Load(object sender, EventArgs e)
        {
            StartUpConfiguration();
            PerformAutoScale();
        }

        private void StartUpConfiguration()
        {
            MasterName2textBox.Visible = false;
            MasterName2textBox.Enabled = false;
            Amount2textBox.Visible = false;
            Amount2textBox.Enabled = false;
            Comment2textBox.Visible = false;
            Comment2textBox.Enabled = false;
            toolStripButtonDelete.Enabled = false;
            mASTERLISTTableAdapter.Fill(MasteriacDataSet.MASTERLIST);
            MasterNamecomboBox.Text = "";
            ActiveControl = MasterAccNoTextBox;
            MasterAccNoTextBox.SelectAll();
        }

        private void setRelatedData()
        {
            Int32 MacontPos = 0;
            mASTERTableAdapter.Fill(MasteriacDataSet.MASTER, MasterAccNoTextBox.Text);
            if (MasteriacDataSet.MASTER.Rows.Count > 0)
            {
                MasterAccNoTextBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO");

                MasterHistorydataGridView.Size = new Size(338, 311);
                MasterHistorydataGridView.Location = new Point(265,141);

                if (MasterHistorydataGridView.Columns.Count == 6)
                {
                    MasterHistorydataGridView.Columns.Remove("CurrentNotes");
                    MasterHistorydataGridView.Columns.Remove("YTDNotes");
                }
                lblCurValue.AutoSize = true;
                lblCurValue.Visible = true;
                lblCurValue.Enabled = true;

                lblYTDValue.AutoSize = true;
                lblYTDValue.Visible = true;
                lblYTDValue.Enabled = true;

                lblCurValue2.AutoSize = true;
                lblCurValue2.Visible = false;
                lblCurValue2.Enabled = true;

                lblYTDValue2.AutoSize = true;
                lblYTDValue2.Visible = false;
                lblYTDValue2.Enabled = true;
                
                txtCurValue2.AutoSize = true;
                txtCurValue2.Visible = false;
                txtCurValue2.Enabled = false;

                txtYTDValue2.AutoSize = true;
                txtYTDValue2.Visible = false;
                txtYTDValue2.Enabled = false;

                MasterName2textBox.Visible = false;
                MasterName2textBox.Enabled = false;
                Amount2textBox.Visible = false;
                Amount2textBox.Enabled = false;
                Comment2textBox.Visible = false;
                Comment2textBox.Enabled = false;

                macontTableAdapter.FillByAll(MasteriacDataSet.MACONT);
                MacontPos = MACONTbindingSource.Find("MACONT_ACC_NO", MasterAccNoTextBox.Text);
                if (MasteriacDataSet.MACONT.Rows.Count == 0 || MacontPos == -1)
                {
                    MACONTbindingSource.AddNew();
                    MACONTbindingSource.EndEdit();
                    MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].SetField<String>("MACONT_ACC_NO", MasterAccNoTextBox.Text);
                    MasterNamecomboBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME");
                    MasterAccNoTextBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO");
                    MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].SetField<Nullable<DateTime>>("MACONT_POST_DATE", DateTime.Now.Date);

                    MACONTbindingSource.EndEdit();

                    Text = "Closed Master Contingent Maintenance (ADD MODE)";
                    toolStripButtonDelete.Enabled = false;
                }
                else
                {
                    MACONTbindingSource.Position = MacontPos;
                    Text = "Closed Master Contingent Maintenance (EDIT MODE)";
                    LockMcontRecord();
                    toolStripButtonDelete.Enabled = true;
                }
                toolStripButtonDelete.Enabled = true;
                switch (MasterAccNoTextBox.Text.ToString().TrimEnd())
                {
                    case "210":
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT CONTINGENT";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_CUR_CONT";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE CONTINGENT";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_YTD_CONT";
                        lblCurValue.Text = "CONTINGENT";
                        lblYTDValue.Text = "CONTINGENT";
                        txtCurValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Clear();
                        txtCurValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_CUR_CONT").FormatString = "C2";
                        txtYTDValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_YTD_CONT").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_CONT").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        MasterName1textBox.Text = "CONTINGENT RESERVE";
                        MasterName2textBox.Text = "";
                        break;
                    case "211":
                        MasterName2textBox.Visible = true;
                        MasterName2textBox.Enabled = false;
                        Amount2textBox.Visible = true;
                        Amount2textBox.Enabled = true;
                        Comment2textBox.Visible = true;
                        Comment2textBox.Enabled = true;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_OLOAN").FormatString = "C2";
                        Amount2textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_NOTES").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        Comment2textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT2").FormatString = "C2";
                        MasterName1textBox.Text = "OSLOAN (N/R)";
                        MasterName2textBox.Text = "NOTES PAYABLE";


                        MasterHistorydataGridView.Size = new Size(545,311);
                        MasterHistorydataGridView.Location = new Point(162,141);
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT O/S LOANS";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_CUR_OLOAN";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE O/S LOANS";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_YTD_OLOAN";
                        MasterHistorydataGridView.Columns.Add("CurrentNotes", "CURRENT NOTES");
                        MasterHistorydataGridView.Columns[4].DataPropertyName = "MASTHIST_CUR_NOTES";
                        MasterHistorydataGridView.Columns[4].DefaultCellStyle.Format="C2";
                        MasterHistorydataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        MasterHistorydataGridView.Columns.Add("YTDNotes", "YEAR TO DATE NOTES");
                        MasterHistorydataGridView.Columns[5].DataPropertyName = "MASTHIST_YTD_NOTES";
                        MasterHistorydataGridView.Columns[5].DefaultCellStyle.Format="C2";
                        MasterHistorydataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        lblCurValue.Text  = "OUTSTANDING LOANS";
                        lblYTDValue.Text  = "OUTSTANDING LOANS";
                        lblCurValue2.Visible = true;
                        lblYTDValue2.Visible = true;
                        lblCurValue2.Text = "NOTES PAYABLE";
                        lblYTDValue2.Text = "NOTES PAYABLE";
                        txtCurValue2.Visible = true;
                        txtYTDValue2.Visible = true;
                        txtCurValue.Enabled = false;
                        txtYTDValue.Enabled = false;
                        txtCurValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Clear();
                        txtCurValue2.DataBindings.Clear();
                        txtYTDValue2.DataBindings.Clear();
                        txtCurValue.DataBindings.Add("Text",  MASTERbindingSource, "MASTER_CUR_OLOAN").FormatString = "C2";
                        txtYTDValue.DataBindings.Add("Text",  MASTERbindingSource, "MASTER_YTD_OLOAN").FormatString = "C2";
                        txtCurValue2.DataBindings.Add("Text", MASTERbindingSource, "MASTER_CUR_NOTES").FormatString = "C2";
                        txtYTDValue2.DataBindings.Add("Text", MASTERbindingSource, "MASTER_YTD_NOTES").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        txtCurValue2.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue2.DataBindings[0].FormattingEnabled = true;
                        break;
                    case "212":
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT AMORT INTEREST";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_AMORT_CUR_INT";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE AMORT INTEREST";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_AMORT_YTD_INT";
                        lblCurValue.Text = "AMORT INTEREST";
                        lblYTDValue.Text = "AMORT INTEREST";
                        txtCurValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Clear();
                        txtCurValue.Enabled = false;
                        txtYTDValue.Enabled = false;
                        txtCurValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_AMORT_CUR_INT").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_AMORT_YTD_INT").FormatString = "C2";
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_AMORT_INT").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        MasterName1textBox.Text = "AMORTIZATION INTEREST";
                        MasterName2textBox.Text = "";
                        break;
                    case "500":
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT SIMPLE INTEREST";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_SIMPLE_CUR_INT";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE SIMPLE INTEREST";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_SIMPLE_YTD_INT";
                        lblCurValue.Text = "SIMPLE INTEREST";
                        lblYTDValue.Text = "SIMPLE INTEREST";
                        txtCurValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Clear();
                        txtCurValue.Enabled = false;
                        txtYTDValue.Enabled = false;
                        txtCurValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_SIMPLE_CUR_INT").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_SIMPLE_YTD_INT").FormatString = "C2";
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_SIMPLE_INT").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        MasterName1textBox.Text = "SIMPLE INTEREST";
                        MasterName2textBox.Text = "";
                        break;
                    case "213":
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT INTEREST";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_CUR_INT";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE INTEREST";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_YTD_INT";
                        lblCurValue.Text = "INTEREST";
                        lblYTDValue.Text = "INTEREST";
                        txtCurValue.DataBindings.Clear();
                        txtCurValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_CUR_INT").FormatString = "C2";
                        txtYTDValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_YTD_INT").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        txtCurValue.Enabled = false;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_INT").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        MasterName1textBox.Text = "DEALER & CUST. INTEREST";
                        MasterName2textBox.Text = "";
                        txtYTDValue.Enabled = false;
                        break;
                    case "214":
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT BAD DEBTS";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_CUR_BAD";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE BAD DEBTS";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_YTD_BAD";
                        lblCurValue.Text = "BAD DEBTS";
                        lblYTDValue.Text = "BAD DEBTS";
                        txtCurValue.DataBindings.Clear();
                        txtCurValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_CUR_BAD").FormatString = "C2";
                        txtYTDValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_YTD_BAD").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        txtCurValue.Enabled = false;
                        txtYTDValue.Enabled = false;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_BAD").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        MasterName1textBox.Text = "REC. OF BAD DEBTS";
                        MasterName2textBox.Text = "";
                        txtYTDValue.Enabled = false;
                        break;
                    case "216":
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT RESERVE";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_CUR_RSV";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE RESERVE";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_YTD_RSV";
                        lblCurValue.Text = "RESERVE FOR LOSS";
                        lblYTDValue.Text = "RESERVE FOR LOSS";
                        txtCurValue.DataBindings.Clear();
                        txtCurValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_CUR_RSV").FormatString = "C2";
                        txtYTDValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_YTD_RSV").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        txtCurValue.Enabled = false;
                        txtYTDValue.Enabled = false;
                        txtYTDValue.Enabled = false;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_RSV").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        MasterName1textBox.Text = "RESERVE FOR LOSSES";
                        MasterName2textBox.Text = "";
                        break;
                    case "217":
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT LOSS RESERVE";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_CUR_LOSS";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE LOSS RESERVE";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_YTD_LOSS";
                        lblCurValue.Text = "DEALER LOSS RESERVE";
                        lblYTDValue.Text = "DEALER LOSS RESERVE";
                        txtCurValue.DataBindings.Clear();
                        txtCurValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_CUR_LOSS").FormatString = "C2";
                        txtYTDValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_YTD_LOSS").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        txtCurValue.Enabled = false;
                        txtYTDValue.Enabled = false;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_LOSS").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        MasterName1textBox.Text = "DEALER LOSS RESERVE";
                        MasterName2textBox.Text = "";
                        break;
                    case "422":
                        MasterHistorydataGridView.Columns[2].HeaderText = "CURRENT ADJUSTMENT";
                        MasterHistorydataGridView.Columns[2].DataPropertyName = "MASTHIST_CUR_ADJ";
                        MasterHistorydataGridView.Columns[3].HeaderText = "YEAR TO DATE ADJUSTMENT";
                        MasterHistorydataGridView.Columns[3].DataPropertyName = "MASTHIST_YTD_ADJ";
                        lblCurValue.Text = "ADJUSTMENTS";
                        lblYTDValue.Text = "ADJUSMENTS";
                        txtCurValue.DataBindings.Clear();
                        txtCurValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_CUR_ADJ").FormatString = "C2";
                        txtYTDValue.DataBindings.Clear();
                        txtYTDValue.DataBindings.Add("Text", MASTERbindingSource, "MASTER_YTD_ADJ").FormatString = "C2";
                        txtCurValue.DataBindings[0].FormattingEnabled = true;
                        txtYTDValue.DataBindings[0].FormattingEnabled = true;
                        txtCurValue.Enabled = false;
                        txtYTDValue.Enabled = false;
                        Amount1textBox.DataBindings.Clear();
                        Amount2textBox.DataBindings.Clear();
                        Amount1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_CUR_ADJ").FormatString = "C2";
                        Comment1textBox.DataBindings.Clear();
                        Comment2textBox.DataBindings.Clear();
                        Comment1textBox.DataBindings.Add("Text", MACONTbindingSource, "MACONT_COMMENT1").FormatString = "C2";
                        MasterName1textBox.Text = "ADJUSTMENT (A/A)";
                        MasterName2textBox.Text = "";
                        break;
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
                if (ActiveControl == MasterAccNoTextBox || ActiveControl == MasterNamecomboBox)
                    return;
                toolStripButtonSave.Enabled = true;
            }
        }

        private void MasterHistorydataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in MasterHistorydataGridView.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void MasterAccNoTextBox_Validated(object sender, EventArgs e)
        {
            string lsMasterNo;

            lsMasterNo = MasterAccNoTextBox.Text.ToString().Trim();

            if (MasterAccNoTextBox.Text.ToString().Trim().Length < 3 && MasterAccNoTextBox.Text.ToString().Trim().Length > 0)
                MasterAccNoTextBox.Text = MasterAccNoTextBox.Text.PadLeft(3, '0');
            setRelatedData();

            if (MasteriacDataSet.MASTER.Rows.Count == 0)
            {
                if (lsMasterNo != "")
                {
                    MessageBox.Show("Sorry no master record found that matches your selected master number!");
                }
                ActiveControl = MasterNamecomboBox;
                MasterNamecomboBox.SelectAll();
            }
            else
            {
                MasterNamecomboBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME");
                ActiveControl = Amount1textBox;
                Amount1textBox.Select();
            }
        }

        private void MastHistNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MasterNamecomboBox.SelectedIndex >= 0)
            {
                MasterAccNoTextBox.Text    = MasteriacDataSet.MASTERLIST.Rows[MasterNamecomboBox.SelectedIndex].Field<String>("MASTER_ACC_NO");
                MasterName1textBox.Text     = MasteriacDataSet.MASTERLIST.Rows[MasterNamecomboBox.SelectedIndex].Field<String>("MASTER_NAME");
            } 
            setRelatedData();
        }

        private void LockMcontRecord()
        {
            Object loLockedBy   = macontTableAdapter.LockedBy(MasterAccNoTextBox.Text),
                   loLockedTime = macontTableAdapter.LockTime(MasterAccNoTextBox.Text);

            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    return;
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(MasteriacDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** (MASTER CONTINGENT RECORD): " + MasterAccNoTextBox.Text + " WAS LOCKED BY USER: " +
                    loLockedBy + " " +
                    MasteriacDataSet.ULIST.Rows[0].Field<String>("LIST_NAME") +
                    "\nON: " + ((DateTime)loLockedTime).ToLongDateString() + " " +
                    ((DateTime)loLockedTime).ToLongTimeString() + "\n" +
                    "YOU MUST WAIT UNTIL THEY RELEASE IT! ***", "RECORD LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripButtonSave.Enabled = false;
                ULISTTableAdapter.Dispose();
                loLockedBy = null;
                lbEdit = false;
                MasteriacDataSet.Clear();
                StartUpConfiguration();
            }
            else
            {
                macontTableAdapter.LockRecord(Program.gsUserID, MasterAccNoTextBox.Text);
                lbILockedIt = true;   //  Make sure other instances of form don't unlock this record!
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            MACONTbindingSource.EndEdit();
            if (MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].Field<Nullable<DateTime>>("MACONT_POST_DATE") == null)
            {
                MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].SetField<Nullable<DateTime>>("MACONT_POST_DATE", (Nullable<DateTime>)TextBoxPostDate.Value);
                MACONTbindingSource.EndEdit();
            }
            tableAdapConn = new Microsoft.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            macontTableAdapter.Connection = tableAdapConn;
            tableAdapTran = macontTableAdapter.BeginTransaction();
            macontTableAdapter.Transaction = tableAdapTran;
            try
            {
                macontTableAdapter.Update(MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position]);
                tableAdapTran.Commit();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("There is a Microsoft SQL Server database error: " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("There is an Invalid Operation Error: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("There is a General Exception Error: " + ex.Message.ToString());
            }
            finally
            {
                macontTableAdapter.UnlockRecord(MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].Field<String>("MACONT_ACC_NO"));
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                MasteriacDataSet.AcceptChanges();
                if (lbEdit)
                    lbEdit = false;
                if (lbAdd)
                    MasteriacDataSet.MACONT.Clear();
                StartUpConfiguration();
                ActiveControl = MasterAccNoTextBox;
                MasterAccNoTextBox.Select();
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (MasteriacDataSet.MACONT.Rows.Count < 1)
                return;
            MACONTbindingSource.EndEdit();
            tableAdapConn = new Microsoft.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            macontTableAdapter.Connection = tableAdapConn;
            tableAdapTran = macontTableAdapter.BeginTransaction();
            macontTableAdapter.Transaction = tableAdapTran;
            try
            {
                macontTableAdapter.Delete(MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].Field<String>("MACONT_ACC_NO"));
                tableAdapTran.Commit();
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("There is a Microsoft SQL Server database error: " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("There is an Invalid Operation Error: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("There is a General Exception Error: " + ex.Message.ToString());
            }
            finally
            {
                macontTableAdapter.UnlockRecord(MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].Field<String>("MACONT_ACC_NO"));
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                MasteriacDataSet.MACONT.Clear();
                StartUpConfiguration();
                ActiveControl = MasterAccNoTextBox;
                MasterAccNoTextBox.Select();
            }
        }

        private void ClosedMasterContingentMaintenance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MasteriacDataSet.MACONT.Rows.Count < 1)
                return;
            Object loLockedBy = null;

            loLockedBy = macontTableAdapter.LockedBy(MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].Field<String>("MACONT_ACC_NO"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    macontTableAdapter.UnlockRecord(MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].Field<String>("MACONT_ACC_NO"));
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
                mASTHISTTableAdapter.FillByAccNo(MasteriacDataSet.MASTHIST, MasterAccNoTextBox.Text);
        }
    }
}

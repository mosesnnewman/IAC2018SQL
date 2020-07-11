using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2010
{
    public partial class MasterHistory : Form
    {
        private System.Data.OleDb.OleDbTransaction tableAdapTran = null;
        private System.Data.OleDb.OleDbConnection tableAdapConn = null;

        public MasterHistory()
        {
            InitializeComponent();
        }

        private void setRelatedData()
        {
            Int32 MacontPos = 0;
            if (tableAdapConn != null)
            {
                tableAdapConn.Close();
                tableAdapTran.Dispose();
                tableAdapConn.Dispose();
            }
            FillMasterWithLock();
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


                MacontPos = MACONTbindingSource.Find("MACONT_ACC_NO", MasterAccNoTextBox.Text);
                if (MasteriacDataSet.MACONT.Rows.Count == 0 || MacontPos == -1)
                {
                    MACONTbindingSource.AddNew();
                    MACONTbindingSource.EndEdit();
                    MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].SetField<String>("MACONT_ACC_NO", MasterAccNoTextBox.Text);
                    MasterNamecomboBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME");
                    MasterAccNoTextBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO");
                    MasteriacDataSet.MACONT.Rows[0].SetField<Nullable<DateTime>>("MACONT_POST_DATE", DateTime.Now.Date);
                   
                    MACONTbindingSource.EndEdit();
                    Text = "Master History Maintenance (ADD MODE)";
                }
                else
                {
                    MACONTbindingSource.Position = MacontPos;
                    Text = "Closed Master Contingent Maintenance (EDIT MODE)";
                }

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
                        break;
                    case "211":

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
            }
        }

        private void MasterContingentMaintenance_Load(object sender, EventArgs e)
        {
            mASTERLISTTableAdapter.Fill(MasteriacDataSet.MASTERLIST);
            MasterNamecomboBox.Text = "";
            PerformAutoScale();
            ActiveControl = MasterAccNoTextBox;
            MasterAccNoTextBox.SelectAll();
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

            if (MasteriacDataSet.MASTER.Rows.Count == 0 && lsMasterNo != "")
            {
                MessageBox.Show("Sorry no master record found that matches your selected master number!");
                ActiveControl = MasterNamecomboBox;
                MasterNamecomboBox.SelectAll();
            }
            else
            {
                MasterNamecomboBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME");
            }
        }

        private void MastHistNamecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MasterNamecomboBox.SelectedIndex >= 0)
            {
                MasterAccNoTextBox.Text    = MasteriacDataSet.MASTERLIST.Rows[MasterNamecomboBox.SelectedIndex].Field<String>("MASTER_ACC_NO");
                //MasterName1textBox.Text    = MasteriacDataSet.MASTERLIST.Rows[MasterNamecomboBox.SelectedIndex].Field<String>("MASTER_NAME");
            }
            setRelatedData();
        }

        private void FillMasterWithLock()
        {
            Int32 MacontPos = 0;
            if (MasterNamecomboBox.SelectedIndex < 0)
                return;

            String lsMasterQuery = "";

            lsMasterQuery  = "SELECT * FROM MASTER WHERE MASTER_ACC_NO = \'";
            lsMasterQuery += MasterAccNoTextBox.Text.TrimEnd() + "\' ";
            lsMasterQuery += "FOR UPDATE";

            mASTERTableAdapter.CustomizeFill(lsMasterQuery);
            
            try
            {
                tableAdapConn = new System.Data.OleDb.OleDbConnection();
                tableAdapConn.ConnectionString = IAC2010.Properties.Settings.Default.IACMicroFocus;
                tableAdapConn.Open();

                mASTERTableAdapter.Connection = tableAdapConn;
                tableAdapTran = mASTERTableAdapter.BeginTransaction();

                macontTableAdapter.Connection = tableAdapConn;
                macontTableAdapter.Transaction = tableAdapTran;

                mASTHISTTableAdapter.Connection = tableAdapConn;
                mASTHISTTableAdapter.Transaction = tableAdapTran;

                mASTERTableAdapter.CustomFillBy(MasteriacDataSet.MASTER);
                if (MasteriacDataSet.MASTER.Rows.Count > 0)
                {
                    mASTHISTTableAdapter.FillByAccNo(MasteriacDataSet.MASTHIST, MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    //macontTableAdapter.Fill(MasteriacDataSet.MACONT, MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    if(MasteriacDataSet.MACONT.Rows.Count == 0) 
                        macontTableAdapter.FillByAll(MasteriacDataSet.MACONT);
                    MacontPos = MACONTbindingSource.Find("MACONT_ACC_NO", MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                    if (MacontPos > -1)
                        MACONTbindingSource.Position = MacontPos;
                }
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("This record is in use by someone else, you must wait until they release it to make your changes " + ex.Message.ToString());
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                //  lbEditAbort = true;
                Close();
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            MACONTbindingSource.EndEdit();
            /*
            for (int i = 0; i < MasteriacDataSet.MACONT.Rows.Count; i++)
            {
                if (MasteriacDataSet.MACONT.Rows[i].Field<Nullable<DateTime>>("MACONT_POST_DATE") == null)
                    MasteriacDataSet.MACONT.Rows[i].SetField<Nullable<DateTime>>("MACONT_POST_DATE", (Nullable<DateTime>)TextBoxPostDate.Value);
            }*/
            MACONTbindingSource.EndEdit();
            macontTableAdapter.Update(MasteriacDataSet.MACONT);
            tableAdapTran.Commit();
            tableAdapTran.Dispose();
            tableAdapConn.Close();
            tableAdapConn.Dispose();
            Text = "Closed Master Contingent Maintenance (Edit MODE)";

            //MasteriacDataSet.Clear();
            MasterContingentMaintenance_Load(sender, e);
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            MACONTbindingSource.EndEdit();
            macontTableAdapter.Delete(MasterAccNoTextBox.Text.TrimEnd());
            tableAdapTran.Commit();
            tableAdapTran.Dispose();
            tableAdapConn.Close();
            tableAdapConn.Dispose();
            Text = "Master History Maintenance (Edit MODE)";
            MasteriacDataSet.Clear();
            MasterContingentMaintenance_Load(sender, e);
        }

        private void MACONTbindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (MACONTbindingSource.Position > -1 && ((MACONTbindingSource.Position + 1) <= MasteriacDataSet.MACONT.Rows.Count))
            {
                MasterAccNoTextBox.Text = MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].Field<String>("MACONT_ACC_NO");
                mASTERTableAdapter.Fill(MasteriacDataSet.MASTER, MasteriacDataSet.MACONT.Rows[MACONTbindingSource.Position].Field<String>("MACONT_ACC_NO"));
                MasterNamecomboBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME");
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            MACONTbindingSource.RemoveCurrent();
            for (int i = 0; i < MasteriacDataSet.MACONT.Rows.Count; i++)
            {
                //if (MasteriacDataSet.MACONT.Rows[i].Field<Nullable<DateTime>>("MACONT_POST_DATE") == null)
                  //  MasteriacDataSet.MACONT.Rows[i].SetField<Nullable<DateTime>>("MACONT_POST_DATE", (Nullable<DateTime>)TextBoxPostDate.Value);
            }
            MACONTbindingSource.EndEdit();
            Text = "Master History Maintenance (EDIT MODE)";
            macontTableAdapter.FillByAll(MasteriacDataSet.MACONT);
            MasterNamecomboBox.Text = MasteriacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME");
            tableAdapTran.Dispose();
            tableAdapConn.Close();
            tableAdapConn.Dispose();
            MasterContingentMaintenance_Load(sender, e);
        }
    }
}

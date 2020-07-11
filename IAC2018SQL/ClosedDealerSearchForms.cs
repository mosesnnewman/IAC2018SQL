using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IAC2018SQL;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;

namespace IAC2018SQL
{
    public partial class frmDealerLookup : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private String lsProgMessage = "",targetPath = "";

        public frmDealerLookup()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String lcQuery = "",lcName = "%",lcStreet = "%",lcCity = "%",lcState = "%",lcZip = "%",lcStatus = "%",lcHomePhone = "%",lcWorkPhone = "%",
                   lcCellPhone = "%",lcStartDate = "%",lcDOBYY, lcDOBMM, lcDOBDD,lcDOB = "",lcEmail = "%";



            int lnDOB = 0;

            iacDataSet1.DEALER.Clear();
            bindingNavigator1.BindingSource = DealerbindingSource;

            if (textBoxDealer.Text.Length == 3)
            {
                lcQuery = "SELECT * FROM DEALER WHERE DEALER_ACC_NO = '" + textBoxDealer.Text + "'";
            }
            else
            {
                if (dEALER_NAMETextBox.Text.TrimEnd().Length > 0)
                    lcName = dEALER_NAMETextBox.Text.TrimEnd().ToUpper() + "%";
                if (DEALER_STREETTextBox.Text.TrimEnd().Length > 0)
                    lcStreet = DEALER_STREETTextBox.Text.TrimEnd().ToUpper() + "%";
                if (DealerCityTextBox.Text.TrimEnd().Length > 0)
                    lcCity = DealerCityTextBox.Text.TrimEnd().ToUpper() + "%";
                if (DealerStateTextBox.Text.TrimEnd().Length > 0)
                    lcState = DealerStateTextBox.Text.TrimEnd().ToUpper() + "%";
                if (DealerZipTextBox.Text.TrimEnd().Length > 0)
                    lcZip = DealerZipTextBox.Text.TrimEnd() + "%";
                if (radioButtonActive.Checked)
                    lcStatus = "A%";
                else
                    if (radioButtonInactive.Checked)
                        lcStatus = "I%";
                if (maskedTextBoxStartDate.Text.Length > 0)
                    lcStartDate = maskedTextBoxStartDate.Text.TrimEnd() + "%";
                if (textBoxDealerEmail.Text.Length > 0)
                    lcEmail = textBoxDealerEmail.Text.TrimEnd() + '%';
                lcHomePhone = DealerHomePhoneTextBox.Text.ToString();
                lcHomePhone = lcHomePhone.Substring(1, 3).Trim() + lcHomePhone.Substring(6, 3).Trim() + ((DealerHomePhoneTextBox.Text.Length > 9) ? lcHomePhone.Substring(10).Trim() : "") + "%";
                lcWorkPhone = DEALERWorkPhoneTextBox.Text.ToString();
                lcWorkPhone = lcWorkPhone.Substring(1, 3).Trim() + lcWorkPhone.Substring(6, 3).Trim() + ((DEALERWorkPhoneTextBox.Text.Length > 9) ? lcWorkPhone.Substring(10).Trim() : "") + "%";
                lcCellPhone = maskedTextBoxCellPhone.Text.ToString();
                lcCellPhone = lcCellPhone.Substring(1, 3).Trim() + lcCellPhone.Substring(6, 3).Trim() + ((maskedTextBoxCellPhone.Text.ToString().Length > 9) ? lcCellPhone.Substring(10).Trim() : "") + "%";

                if (maskedTextBoxStartDate.Text.ToString().TrimStart().TrimEnd().Length > 5)
                {
                    lcDOBMM = maskedTextBoxStartDate.Text.ToString().Substring(0, 2);
                    if (lcDOBMM.Substring(0, 1) == "0")
                        lcDOBMM = lcDOBMM.Substring(1, 1);
                    lcDOBDD = maskedTextBoxStartDate.Text.ToString().Substring(3, 2);
                    lcDOBYY = maskedTextBoxStartDate.Text.ToString().Substring(6, 4);
                    lcDOB = lcDOBMM + lcDOBDD + lcDOBYY;
                    lnDOB = Convert.ToInt32(lcDOB);
                    if (lcDOB.Length < 7)
                        lnDOB = 0;
                }

                lcQuery = "SELECT * ";
                lcQuery += "FROM  DEALER ";
                lcQuery += "WHERE DEALER_NAME LIKE \'" + lcName + "\'";
                lcQuery += " AND DEALER_ADDR LIKE \'" + lcStreet + "\'";
                lcQuery += " AND DEALER_CITY LIKE \'" + lcCity + "\'";
                lcQuery += " AND DEALER_ST LIKE \'" + lcState + "\'";
                lcQuery += " AND DEALER_ZIP LIKE \'" + lcZip + "\'";
                lcQuery += " AND DEALER_STATUS LIKE \'" + lcStatus + "\'";
                lcQuery += " AND DEALER_HOME_PHONE LIKE \'" + lcHomePhone + "\'";
                lcQuery += " AND DEALER_WORK_PHONE LIKE \'" + lcWorkPhone + "\'";
                lcQuery += " AND CellPhone LIKE \'" + lcCellPhone + "\'";
                lcQuery += " AND Email LIKE \'" + lcEmail + "\'";
                if (lnDOB != 0)
                    lcQuery += " AND DealerStartDate = " + lcDOB + "\'";
            }
            dEALERTableAdapter.CustomizeFill(lcQuery);
            dEALERTableAdapter.CustomFillBy(iacDataSet1.DEALER);

            if (iacDataSet1.DEALER.Count > 0)
            {
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_ADJ");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_RSV");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_CONT");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_OLOAN");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_BAD");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_LOSS");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_AMORT_INT");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_SIMPLE_INT");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_AMORT_PDI");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_SIMPLE_PDI");
                iacDataSet1.DEALER.Columns.Remove("DEALER_CUR_OLD_PDI");
                iacDataSet1.DEALER.Columns.Remove("IsLocked");
                iacDataSet1.DEALER.Columns.Remove("LockedBy");
                iacDataSet1.DEALER.Columns.Remove("LockTime");
                iacDataSet1.DEALER.Columns["DEALER_STATUS"].SetOrdinal(1);
                iacDataSet1.DEALER.Columns["DEALER_CITY"].SetOrdinal(5);
                iacDataSet1.DEALER.Columns["DEALER_ST"].SetOrdinal(6);
                iacDataSet1.DEALER.Columns["DEALER_ZIP"].SetOrdinal(7);
                iacDataSet1.DEALER.Columns["DEALER_HOME_PHONE"].SetOrdinal(8);
                iacDataSet1.DEALER.Columns["DEALER_WORK_PHONE"].SetOrdinal(9);
                iacDataSet1.DEALER.Columns["CellPhone"].SetOrdinal(10);
                iacDataSet1.DEALER.Columns["DEALER_POST_DATE"].SetOrdinal(11);
                iacDataSet1.DEALER.Columns["DEALER_YTD_RSV"].SetOrdinal(12);


                ActiveControl = dataGridViewDealerLookup;
                dataGridViewDealerLookup.Select();
            }
            else
                MessageBox.Show("Sorry no dealers found that match your selected criteria!");    
        }

        private void ClearAllFields()
        {
            textBoxDealer.Text = "";
            dEALER_NAMETextBox.Text = "";
            DEALER_STREETTextBox.Text = "";
            DealerCityTextBox.Text = "";
            DealerStateTextBox.Text = "";
            DealerZipTextBox.Text = "";
            textBoxDealerEmail.Text = "";
            maskedTextBoxStartDate.Text = "";
            DealerHomePhoneTextBox.Text = "";
            DEALERWorkPhoneTextBox.Text = "";
            maskedTextBoxCellPhone.Text = "";
            radioButtonActive.Checked = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (iacDataSet1.DEALER.Count > 0 && dataGridViewDealerLookup.SelectedRows.Count > 0)
            {
                Program.gsKey = dataGridViewDealerLookup.SelectedRows[0].Cells["dEALERACCNODataGridViewTextBoxColumn"].Value.ToString().TrimEnd();
                if (this.Owner == null)
                {
                    MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                    MDImain.CreateFormInstance("ClosedDealerMaintenance", false);
                    iacDataSet1.Clear();
                    ClearAllFields();
                    Refresh();
                    Show();
                }
                else
                {
                    dEALERTableAdapter.Connection.Close();
                    Close();
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
        }

        private void frmDealerLookup_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            radioButtonActive.Checked = true;
            ActiveControl = textBoxDealer;
            textBoxDealer.Select();
        }

        private void dataGridViewDealerLookup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dataGridViewDealerLookup.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void textBoxDealer_Validated(object sender, EventArgs e)
        {
            if (textBoxDealer.Text.Length > 0)
                textBoxDealer.Text = textBoxDealer.Text.PadLeft(3, '0');
        }

        private String GetFilePath()
        {
            String targetPath = "";
            FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();

            //Create an Excel workbook instance and open it from the predefined location
            // Moses Newman 11/21/2017 Remove hard coded UNC pathing.
            targetPath = Program.GsDataPath + @"DealerExcels";
            FolderBrowser.SelectedPath = targetPath;
            FolderBrowser.Description = "Select folder to save Excel sheet to.";
            FolderBrowser.ShowDialog();
            targetPath = FolderBrowser.SelectedPath;

            targetPath += @"\DealerLookupExtract.xlsx";
            return targetPath; 
        }

        /// <summary>
        /// This method takes DataSet as input paramenter and it exports the same to excel
        /// </summary>
        /// <param name="ds"></param>
        private void worker_ExportDataSetToExcel(object sender, DoWorkEventArgs e)
        {
            Decimal lnProg = 0;

            //Create an Excel application instance
            Excel.Application excelApp = new Excel.Application();

              //Create an Excel workbook instance and open it from the predefined location
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);


            //Add a new worksheet to workbook with the Datatable name
            Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
            excelWorkSheet.Name = iacDataSet1.DEALER.TableName;

            // Add Column Names
            for (int i = 1; i < iacDataSet1.DEALER.Columns.Count + 1; i++)
            {
                excelWorkSheet.Cells[1, i] = iacDataSet1.DEALER.Columns[i - 1].ColumnName;
                lnProg = ((Decimal)(i + 1) / (Decimal)iacDataSet1.DEALER.Columns.Count) * (Decimal)100;
                lsProgMessage = "Adding Cell " + iacDataSet1.DEALER.Columns[i - 1].ColumnName +": " + i.ToString().TrimStart() + " of " + iacDataSet1.DEALER.Columns.Count.ToString() + ".";
                worker.ReportProgress((Int32)lnProg);
            }
            // Add rows and data
            for (int j = 0; j < iacDataSet1.DEALER.Rows.Count; j++)
            {
                lnProg = ((Decimal)(j + 1) / (Decimal)iacDataSet1.DEALER.Rows.Count) * (Decimal)100;
                lsProgMessage = "Adding Row: " + j.ToString().TrimStart() + " of " + iacDataSet1.DEALER.Rows.Count.ToString() + ".";
                worker.ReportProgress((Int32)lnProg);
                for (int k = 0; k < iacDataSet1.DEALER.Columns.Count; k++)
                {
                    lnProg = ((Decimal)(k+1) / (Decimal)iacDataSet1.DEALER.Columns.Count) * (Decimal)100;
                    excelWorkSheet.Cells[j + 2, k + 1] = iacDataSet1.DEALER.Rows[j].ItemArray[k].ToString();
                    lsProgMessage = "Adding Data to cell[" + j.ToString().TrimStart() + "," + k.ToString().TrimStart() + "]";
                    worker.ReportProgress((Int32)lnProg);
                }
            }
            Excel.Range DealerNo = excelWorkSheet.get_Range("A:A");
            DealerNo.Columns.ColumnWidth = 5;
            Excel.Range Status = excelWorkSheet.get_Range("B:B");
            Status.Columns.ColumnWidth = 5;
            Excel.Range DealerName = excelWorkSheet.get_Range("C:C");
            DealerName.Columns.ColumnWidth = 30;
            Excel.Range Address = excelWorkSheet.get_Range("D:D");
            Address.Columns.ColumnWidth = 30;
            Excel.Range City = excelWorkSheet.get_Range("E:E");
            City.Columns.ColumnWidth = 22;
            Excel.Range State = excelWorkSheet.get_Range("F:F");
            State.Columns.ColumnWidth = 5;
            Excel.Range ZipCode = excelWorkSheet.get_Range("G:G");
            ZipCode.NumberFormat = "0####";
            ZipCode.Columns.ColumnWidth = 11.57;
            ZipCode.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

            Excel.Range PostDate = excelWorkSheet.get_Range("K:K");
            PostDate.NumberFormat = "m/d/yyyy";
            PostDate.Columns.ColumnWidth = 11.71;
            Excel.Range HomePhone = excelWorkSheet.get_Range("H:H");
            HomePhone.NumberFormat = "(###) ###-####";
            HomePhone.Columns.ColumnWidth = 14.57;
            Excel.Range WorkPhone = excelWorkSheet.get_Range("I:I");
            WorkPhone.NumberFormat = "(###) ###-####";
            WorkPhone.Columns.ColumnWidth = 14.57;
            Excel.Range CellPhone = excelWorkSheet.get_Range("J:J");
            CellPhone.NumberFormat = "(###) ###-####";
            CellPhone.Columns.ColumnWidth = 14.57;

            excelWorkBook.SaveAs(targetPath);
            excelWorkBook.Close();
            excelApp.Quit();
        }

        private void toolStripButtonExporttoExcel_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDIMain;
            if (iacDataSet1.DEALER.Rows.Count > 0)
            {
                targetPath = GetFilePath();

                if (this.Owner == null)
                    MDIMain = (MDIIAC2013)MdiParent;
                else
                    MDIMain = (MDIIAC2013)this.Owner;

                MDIMain.CreateFormInstance("QueryProgress", true, false, true);
                QueryProgress lfrm;
                lfrm = (QueryProgress)MDIMain.frm;
                worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler(worker_ExportDataSetToExcel);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_FillExtractProgressChanged);
                worker.RunWorkerAsync();
                lfrm.Text = "Create Dealer EXCEL Extract File";
                lfrm.lblProgress.Text = "Creating Dealer EXCEL Extract File";
                lfrm.ShowDialog();
                lfrm.Close();
                Close();
            }
        }

        private void worker_FillExtractProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MDIIAC2013 MDIMain;

            if (this.Owner == null)
                MDIMain = (MDIIAC2013)MdiParent;
            else
                MDIMain = (MDIIAC2013)this.Owner;

            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.QueryprogressBar.Value = (e.ProgressPercentage < 101) ? e.ProgressPercentage : 100;

            lfrm.lblProgress.Text = "Creating Dealer EXCEL Extract" + "\n" + lsProgMessage;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MDIIAC2013 MDIMain;

            if (this.Owner == null)
                MDIMain = (MDIIAC2013)MdiParent;
            else
                MDIMain = (MDIIAC2013)this.Owner;

            QueryProgress lfrm;
            lfrm = (QueryProgress)MDIMain.frm;
            lfrm.Close();
        }
    }
}

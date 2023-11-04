using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;
using DevExpress.Export.Xl;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Windows.Media;

namespace IAC2021SQL
{
    public partial class FormRepoReport : DevExpress.XtraEditors.XtraForm
    {
        public FormRepoReport()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            DateTime ldStartDate = DateTime.Now.Date.AddYears(-1),ldEndDate = DateTime.Now.Date;
            
            String lsRepoCode = cUSTOMER_REPO_CDEtextBox.Text.Trim() + "%",lsAgeCode = "%",lsStatus = "%";

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            if (radioButtonY.Checked)
                lsAgeCode = "Y%";
            if (radioButtonP.Checked)
                lsAgeCode = "P%";
            if (radioButtonR.Checked)
                lsAgeCode = "R%";
            if (radioButtonI.Checked)
                lsAgeCode = "I%";
            // Moses Newman 12/03/2019 change lsStatus = "Z" to lsAgeCode = "Z" as it is a repo_ind not a status!
            if (radioButtonZ.Checked)
                lsAgeCode = "Z%";
            if (radioButtonIndBoth.Checked)
                lsAgeCode = "%";
            if (radioButtonActive.Checked)
                lsStatus = "A%";
            if (radioButtonInactive.Checked)
                lsStatus = "I%";
            if (radioButtonStatusBoth.Checked)
                lsStatus = "%";
            if (nullableDateTimePickerStartDate.EditValue == null)
                ldStartDate = DateTime.Parse("01/01/1980");
            else
                ldStartDate = (DateTime)nullableDateTimePickerStartDate.EditValue;
            if (nullableDateTimePickerEndDate.EditValue == null)
                ldEndDate = DateTime.Now;
            else
                ldEndDate = (DateTime)nullableDateTimePickerEndDate.EditValue;
            CUSTOMERTableAdapter.FillByRepoCode(DelinquencyData.CUSTOMER, lsAgeCode, ldStartDate,ldEndDate,lsStatus,lsRepoCode);
            // Moses Newman 11/19/2013 Moses Newman added ldCurrDate as new parameter to DealerFillByDelinQuencies Query
            DEALERTableAdapter.FillByRepoCode(DelinquencyData.DEALER, lsAgeCode, ldStartDate, ldEndDate, lsStatus, lsRepoCode);
            if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
            {
                Hide();
                // Moses Newman 08/24/2022 Covert to XtraReport
                var report = new XtraReportClosedCustomerDelinquencyRepoReport();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;
                report.Parameters["gsRepoInd"].Value = lsAgeCode;
                report.Parameters["gnAgedMonths"].Value = 8;
                report.Parameters["gdCurrentDate"].Value = ldStartDate;
                report.Parameters["gdStartDate"].Value = ldStartDate;
                report.Parameters["gdEndDate"].Value = ldEndDate;
                report.Parameters["gsRepoCode"].Value = cUSTOMER_REPO_CDEtextBox.Text.Trim() + '%';
                report.Parameters["gsCustStatus"].Value = lsStatus;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();

                DelinquencyData.Clear();
                DelinquencyData.Dispose();

                DEALERTableAdapter.Dispose();
                CUSTOMERTableAdapter.Dispose();
                Close();
            }
            else
            {
                MessageBox.Show("No records that match your selected criteria.  Please try again.");
            }
        }

        private void FormRepoReport_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
            nullableDateTimePickerStartDate.EditValue = DateTime.Parse(DateTime.Now.Month.ToString()+"/"+DateTime.Now.Year.ToString());
            repoCodesTableAdapter.Fill(this.DelinquencyData.RepoCodes);
            radioButtonIndBoth.Checked = true;
            radioButtonStatusBoth.Checked = true;
            bindingSourceRepoCodes.Position = bindingSourceRepoCodes.Find("Code", "");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            DateTime ldStartDate = DateTime.Now.Date.AddYears(-1), ldEndDate = DateTime.Now.Date;

            String lsRepoCode = cUSTOMER_REPO_CDEtextBox.Text.Trim() + "%", lsAgeCode = "%", lsStatus = "%";

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            if (radioButtonY.Checked)
                lsAgeCode = "Y%";
            if (radioButtonP.Checked)
                lsAgeCode = "P%";
            if (radioButtonR.Checked)
                lsAgeCode = "R%";
            if (radioButtonI.Checked)
                lsAgeCode = "I%";
            // Moses Newman 12/03/2019 change lsStatus = "Z" to lsAgeCode = "Z" as it is a repo_ind not a status!
            if (radioButtonZ.Checked)
                lsAgeCode = "Z%";
            if (radioButtonIndBoth.Checked)
                lsAgeCode = "%";
            if (radioButtonActive.Checked)
                lsStatus = "A%";
            if (radioButtonInactive.Checked)
                lsStatus = "I%";
            if (radioButtonStatusBoth.Checked)
                lsStatus = "%";
            if (nullableDateTimePickerStartDate.EditValue == null)
                ldStartDate = DateTime.Parse("01/01/1980");
            else
                ldStartDate = (DateTime)nullableDateTimePickerStartDate.EditValue;
            if (nullableDateTimePickerEndDate.EditValue == null)
                ldEndDate = DateTime.Now;
            else
                ldEndDate = (DateTime)nullableDateTimePickerEndDate.EditValue;
            RepoDataSet repoDataSet = new RepoDataSet();
            sqlDataSourceEXCEL.Queries[0].Parameters[0].Value = lsAgeCode;
            sqlDataSourceEXCEL.Queries[0].Parameters[1].Value = ldStartDate;
            sqlDataSourceEXCEL.Queries[0].Parameters[2].Value = ldEndDate;
            sqlDataSourceEXCEL.Queries[0].Parameters[3].Value = lsStatus;
            sqlDataSourceEXCEL.Queries[0].Parameters[4].Value = cUSTOMER_REPO_CDEtextBox.Text.Trim() + '%';
            sqlDataSourceEXCEL.Queries[1].Parameters[0].Value = lsAgeCode;
            sqlDataSourceEXCEL.Queries[1].Parameters[1].Value = ldStartDate;
            sqlDataSourceEXCEL.Queries[1].Parameters[2].Value = ldEndDate;
            sqlDataSourceEXCEL.Queries[1].Parameters[3].Value = lsStatus;
            sqlDataSourceEXCEL.Queries[1].Parameters[4].Value = cUSTOMER_REPO_CDEtextBox.Text.Trim() + '%';
            sqlDataSourceEXCEL.Fill();
            DelinquencyData.CUSTOMER.Clear();
            DelinquencyData.DEALER.Clear();
            repoDataSet.CUSTOMERVEHICLE.Clear();
            ITable srcCUSTOMER = sqlDataSourceEXCEL.Result[0];
            foreach (IRow row in srcCUSTOMER)
                repoDataSet.CUSTOMERVEHICLE.Rows.Add(row.ToArray());
            ITable srcDEALER = srcCUSTOMER.GetDetailRelation("CUSTOMERDEALER").Detail;
            foreach (IRow row in srcDEALER)
                DelinquencyData.DEALER.Rows.Add(row.ToArray());

            if (repoDataSet.CUSTOMERVEHICLE.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
            {
                // Create an exporter instance. 
                IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xlsx);

                // Create the FileStream object with the specified file path.
                using (FileStream stream = new FileStream("RepoExtract.xlsx", FileMode.Create, FileAccess.ReadWrite))
                {
                    // Create a new document and begin to write it to the specified stream.
                    using (IXlDocument document = exporter.CreateDocument(stream))
                    {
                        // Add a new worksheet to the document. 
                        using (IXlSheet sheet = document.CreateSheet())
                        {
                            // Specify the worksheet name.
                            sheet.Name = "Repo report";

                            // Create an instance of the XlConditionalFormatting class.
                            XlConditionalFormatting formatting = new XlConditionalFormatting();
                            formatting.Ranges.Add(XlCellRange.RowInterval(0, repoDataSet.CUSTOMERVEHICLE.Rows.Count));
                            XlCondFmtRuleExpression rule = new XlCondFmtRuleExpression("=MOD(ROW(),2) = 0");
                            rule.Formatting = XlFill.SolidFill(System.Drawing.Color.FromArgb(198, 239, 206));
                            formatting.Rules.Add(rule);
                            sheet.ConditionalFormattings.Add(formatting);
                            // Open the XLSX document using the default application.

                            // Create the Dealer# column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 9;
                            }

                            // Create the DealerState column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 13;
                            }

                            // Create the DealerName column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 33;
                            }
                            // Create the Account# column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 11;
                            }
                            // Create the Name column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 35;
                            }
                            // Create the Code column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 9;
                            }
                            // Create the RepoAgent column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 31;
                            }
                            // Create the CurrentLocation column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 44;
                            }
                            // Create the Auction column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 44;
                            }
                            // Create the LocationDate column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 15;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.IsDateTimeFormatString = true;
                                column.Formatting.NetFormatString = "d";

                            }
                            // Create the AuctionHouseDate column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 21;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.IsDateTimeFormatString = true;
                                column.Formatting.NetFormatString = "d";
                            }
                            // Create the Year column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 9;
                            }
                            // Create the Make column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 20;
                            }
                            // Create the Model column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInCharacters = 23;
                            }
                            // Create the Buyout column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = @"_([$$-409]* #,##0.00_);_([$$-409]* \(#,##0.00\);_([$$-409]* ""-""??_);_(@_)";
                            }
                            // Create the Totals column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = @"_([$$-409]* #,##0.00_);_([$$-409]* \(#,##0.00\);_([$$-409]* ""-""??_);_(@_)";
                            }

                            // Specify cell font attributes.
                            XlCellFormatting cellFormatting = new XlCellFormatting();
                            cellFormatting.Font = new XlFont();
                            cellFormatting.Font.Name = "Century Gothic";
                            cellFormatting.Font.SchemeStyle = XlFontSchemeStyles.None;

                            // Specify formatting settings for the header row.
                            XlCellFormatting headerRowFormatting = new XlCellFormatting();
                            headerRowFormatting.CopyFrom(cellFormatting);
                            headerRowFormatting.Font.Bold = true;
                            headerRowFormatting.Font.Color = XlColor.FromTheme(XlThemeColor.Light1, 0.0);
                            headerRowFormatting.Fill = XlFill.SolidFill(System.Drawing.Color.Green);

                            // Create the header row.
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Dealer#";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Dealer State";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Dealer Name";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Account#";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Name";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Code";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "RepoAgent";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Current Location";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Auction";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Location Date";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Auction House Date";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Year";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Make";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Model";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Buyout";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Totals";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                            }

                            Int32 DealerID = 0;
                            DataRow dealerRow = null;
                            for (int i = 0; i < repoDataSet.CUSTOMERVEHICLE.Rows.Count; i++)
                            {
                                DealerID = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<Int32>("CUSTOMER_DEALER");
                                dealerRow = DelinquencyData.DEALER.Rows.Find(DealerID);
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<Int32>("CUSTOMER_DEALER");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = dealerRow.Field<String>("DEALER_ST");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = dealerRow.Field<String>("DEALER_NAME");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<Int32>("CustomerID");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<String>("CUSTOMER_FIRST_NAME").Trim() + ' '+
                                                     repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<String>("CUSTOMER_LAST_NAME").Trim();
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<String>("CUSTOMER_REPO_CDE");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<String>("RepoAgent");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<String>("CurrentLocation");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<String>("AuctionHouse");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        if (repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<DateTime?>("LocationDate") != null)
                                            cell.Value = (XlVariantValue)repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<DateTime>("LocationDate");
                                        else
                                            cell.Value = "";
                                        //cell.SetFormula(String.Format("=IF(ISNUMBER(DATEVALUE({0})),DATEVALUE({0}),\"\")", cell.Value.TextValue));
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        if (repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<DateTime?>("AuctionHouseDate") != null)
                                            cell.Value = (XlVariantValue)repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<DateTime>("AuctionHouseDate");
                                        else
                                            cell.Value = "";
                                        //cell.SetFormula(String.Format("=IF(ISNUMBER(DATEVALUE({0})),DATEVALUE({0}),\"\")", cell.Value.TextValue));
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<Int32>("VEHICLE_YEAR");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<String>("VEHICLE_MAKE");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<String>("VEHICLE_MODEL");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (XlVariantValue)repoDataSet.CUSTOMERVEHICLE.Rows[i].Field<Decimal>("CUSTOMER_BUYOUT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                }
                            }                            
                        }
                    }
                }
                Process.Start(new ProcessStartInfo("RepoExtract.xlsx") { UseShellExecute = true });
                DelinquencyData.Clear();
                DelinquencyData.Dispose();

                DEALERTableAdapter.Dispose();
                CUSTOMERTableAdapter.Dispose();
                Close();
            }
            else
            {
                MessageBox.Show("No records that match your selected criteria.  Please try again.");
            }
        }
    }
}

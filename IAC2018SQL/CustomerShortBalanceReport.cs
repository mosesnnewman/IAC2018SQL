using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.Export.Xl;
using System.IO;
using System.Data;
using Microsoft.Office.Interop.Word;
using System.Drawing;


namespace IAC2021SQL
{
    public partial class CustomerShortBalanceReport : DevExpress.XtraEditors.XtraForm
    {
        public CustomerShortBalanceReport()
        {
            InitializeComponent();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            IACDataSet ReportDataSet = new IACDataSet();
            IACDataSetTableAdapters.ClosedCustomerShortBalanceTableAdapter ClosedCustomerShortBalanceTableAdapter = new IACDataSetTableAdapters.ClosedCustomerShortBalanceTableAdapter();

            ClosedCustomerShortBalanceTableAdapter.Fill(ReportDataSet.ClosedCustomerShortBalance);

            if (ReportDataSet.ClosedCustomerShortBalance.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Customers with Short Balances! ***");
            else
            {
                String  lsUNCROOT = Program.GsDataPath,
                        lsNewFileOut = lsUNCROOT + @"AccStuff\mfdata\EXCLDATA\ShortBalance" + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString().PadLeft(2, '0') + DateTime.Now.Date.Day.ToString().PadLeft(2, '0') + @".xlsx";
                // Create an exporter instance. 
                IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xlsx);

                // Create the FileStream object with the specified file path. 
                using (FileStream stream = new FileStream(lsNewFileOut, FileMode.Create, FileAccess.ReadWrite))
                {
                    // Create a new document and begin to write it to the specified stream. 
                    using (IXlDocument document = exporter.CreateDocument(stream))
                    {
                        // Add a new worksheet to the document. 
                        using (IXlSheet sheet = document.CreateSheet())
                        {
                            // Specify the worksheet name.
                            sheet.Name = "Short Balance";

                            // Create the DEALER column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                            }

                            // Create the ACCOUNT column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 250;
                            }

                            // Create the FIRST NAME column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 250;
                            }

                            // Create the LAST NAME column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 250;
                            }

                            // Create the Monthly Payment column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = @"_([$$-409]* #,##0.00_);_([$$-409]* \(#,##0.00\);_([$$-409]* ""-""??_);_(@_)";
                            }

                            // Create the Balance column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = @"_([$$-409]* #,##0.00_);_([$$-409]* \(#,##0.00\);_([$$-409]* ""-""??_);_(@_)";
                            }

                            // Create the Buyout column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = @"_([$$-409]* #,##0.00_);_([$$-409]* \(#,##0.00\);_([$$-409]* ""-""??_);_(@_)";
                            }

                            // Create the PAID THRU column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
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
                            headerRowFormatting.Fill = XlFill.SolidFill(XlColor.FromTheme(XlThemeColor.Accent2, 0.0));

                            // Create the header row.
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Dealer";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Account";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "First Name";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Last Name";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Monthly Payment";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Balance";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Buyout";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Paid Thru";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }

                            }

                            // Generate data for the sales report.
                            for (int i = 0; i < ReportDataSet.ClosedCustomerShortBalance.Rows.Count; i++)
                            {
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<String>("DEALER_ACC_NO");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<String>("CUSTOMER_NO");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<String>("CUSTOMER_FIRST_NAME");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<String>("CUSTOMER_LAST_NAME");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<Decimal>("CUSTOMER_BALANCE");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<Decimal>("CUSTOMER_BUYOUT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<String>("CUSTOMER_PAID_THRU_MM") + "/" + ReportDataSet.ClosedCustomerShortBalance.Rows[i].Field<String>("CUSTOMER_PAID_THRU_YY");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                }
                            }
                            // Create an instance of the XlConditionalFormatting class.
                            XlConditionalFormatting formatting = new XlConditionalFormatting();

                            formatting.Ranges.Add(XlCellRange.FromLTRB(0, 0, 7, ReportDataSet.ClosedCustomerShortBalance.Rows.Count));

                            //XlCondFmtRuleCellIs rule = new XlCondFmtRuleCellIs();
                            XlCondFmtRuleExpression rule = new XlCondFmtRuleExpression("=MOD(ROW(),2) = 0");                            
                            rule.Formatting = XlFill.SolidFill(Color.Bisque);
                            formatting.Rules.Add(rule);
                            sheet.ConditionalFormattings.Add(formatting);
                            // Enable AutoFilter for the created cell range.
                            sheet.AutoFilterRange = sheet.DataRange;

                            /*
                            // Specify formatting settings for the total row.
                            XlCellFormatting totalRowFormatting = new XlCellFormatting();
                            totalRowFormatting.CopyFrom(cellFormatting);
                            totalRowFormatting.Font.Bold = true;
                            totalRowFormatting.Fill = XlFill.SolidFill(XlColor.FromTheme(XlThemeColor.Accent5, 0.6));
                            
                            // Create the total row.
                            using (IXlRow row = sheet.CreateRow())
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.ApplyFormatting(totalRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Total amount";
                                    cell.ApplyFormatting(totalRowFormatting);
                                    cell.ApplyFormatting(XlCellAlignment.FromHV(XlHorizontalAlignment.Right, XlVerticalAlignment.Bottom));
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    // Add values in the cell range C2 through C9 using the SUBTOTAL function. 
                                    cell.SetFormula(XlFunc.Subtotal(XlCellRange.FromLTRB(2, 1, 2, 8), XlSummary.Sum, true));
                                    cell.ApplyFormatting(totalRowFormatting);
                                }
                            }*/
                        }
                    }
                }
                // Open the XLSX document using the default application.
                System.Diagnostics.Process.Start(lsNewFileOut);
            }
            /*
            if (ReportDataSet.ClosedCustomerShortBalance.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no Customers with Short Balances! ***");
            else
            {
                // Moses Newman 05/09/2022 Covert to XtraReport
                var report = new XtraReportShortBalanceReport();
                SqlDataSource ds = report.DataSource as SqlDataSource;

                report.DataSource = ds;
                report.RequestParameters = false;
                report.Parameters["gsUserID"].Value = Program.gsUserID;
                report.Parameters["gsUserName"].Value = Program.gsUserName;

                var tool = new ReportPrintTool(report);

                tool.PreviewRibbonForm.MdiParent = MDImain;
                tool.AutoShowParametersPanel = false;
                tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                tool.ShowRibbonPreview();
            }*/
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

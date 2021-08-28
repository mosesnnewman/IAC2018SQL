using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System.IO;


namespace IAC2021SQL
{
    class TrialBalancePretty
    {
        public String FullSourcePath { get; set; }
        public String IACType { get; set; }
        public Int32 CustDealerCount { get; set; }
        public Int32 DealerCount { get; set; }
        public Int32 DealerSummaryCount { get; set; }

        public void TBPRetty()
        {
            File.SetAttributes(FullSourcePath, FileAttributes.Normal);
            String tmpString = "";
            Excel.Range last;
            // Moses Newman 11/14/2019 Add Excel Automation column and page formatting
            //Create an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            excelApp.Visible = true;
            excelApp.WindowState = Excel.XlWindowState.xlMinimized;
            excelApp.WindowState = Excel.XlWindowState.xlMaximized;

            excelApp.Workbooks.Open(FullSourcePath);

            //open excel workbook
            Excel.Workbook excelWorkBook = excelApp.Workbooks[1];

            Excel.Worksheet excelWorkSheet;
            excelWorkBook = excelApp.Workbooks[1];
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[1];

            //excelWorkSheet.PageSetup.CenterHeader = "&\"Arial\"&B&12&KFF0000" + "Customer Bank Extract";
            excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;

            // Do Trial Balance Main Page
            excelWorkSheet.Select();

            if (IACType == "O")
                excelWorkSheet.Name = "OpenTrialBalance";

            String LastRow = (CustDealerCount + 1).ToString();
            last = excelWorkSheet.get_Range("C2:G" + LastRow);

            foreach (Excel.Range Rng in last)
            {
                if (Rng.Value != null)
                {
                    tmpString = Rng.Value;
                    Rng.Value = tmpString.Trim();
                }
            }
            Excel.Range NAME = excelWorkSheet.get_Range("A:A");
            NAME.Columns.EntireColumn.AutoFit();
            NAME.Columns.ColumnWidth = 35;
            excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("A1:A1").Value = "NAME";

            Excel.Range LOANNO = excelWorkSheet.get_Range("B:B");
            LOANNO.Columns.EntireColumn.AutoFit();
            LOANNO.Columns.ColumnWidth = 12;
            LOANNO.Columns.NumberFormat = "000000";
            LOANNO.Columns.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            LOANNO.Columns.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("B1:B1").Value = "LOAN #";

            Excel.Range Balance = excelWorkSheet.get_Range("C:C");
            Balance.Columns.EntireColumn.AutoFit();
            Balance.Columns.ColumnWidth = 18;
            Balance.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("C1:C1").Value = "Balance";

            Excel.Range UEInterest = excelWorkSheet.get_Range("D:D");
            UEInterest.Columns.EntireColumn.AutoFit();
            UEInterest.Columns.ColumnWidth = 18;
            UEInterest.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("D1:D1").Value = "UNPAID INTEREST";

            Excel.Range PaidInterest = excelWorkSheet.get_Range("E:E");
            PaidInterest.Columns.EntireColumn.AutoFit();
            PaidInterest.Columns.ColumnWidth = 18;
            PaidInterest.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("E1:E1").Value = "PAID INTEREST";

            Excel.Range TotalInterest = excelWorkSheet.get_Range("F:F");
            TotalInterest.Columns.EntireColumn.AutoFit();
            TotalInterest.Columns.ColumnWidth = 18;
            TotalInterest.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("F1:F1").Value = "TOTAL INTEREST";

            Excel.Range OrgLoanAmount = excelWorkSheet.get_Range("G:G");
            OrgLoanAmount.Columns.EntireColumn.AutoFit();
            OrgLoanAmount.Columns.ColumnWidth = 21;
            OrgLoanAmount.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("G1:G1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("G1:G1").Value = "ORG LOAN AMOUNT";

            Excel.Range DealerNo = excelWorkSheet.get_Range("H:H");
            DealerNo.Columns.EntireColumn.AutoFit();
            DealerNo.Columns.ColumnWidth = 9;
            DealerNo.Columns.NumberFormat = "000";
            DealerNo.Columns.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            DealerNo.Columns.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelWorkSheet.get_Range("H1:H1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("H1:H1").Value = "DEALER #";

            Excel.Range DealerName = excelWorkSheet.get_Range("I:I");
            DealerName.Columns.EntireColumn.AutoFit();
            DealerName.Columns.ColumnWidth = 30;
            excelWorkSheet.get_Range("I1:I1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("I1:I1").Value = "DEALER NAME";

            Excel.Range DealerST = excelWorkSheet.get_Range("J:J");
            DealerST.Columns.EntireColumn.AutoFit();
            DealerST.Columns.ColumnWidth = 4;
            DealerST.Columns.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            DealerST.Columns.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelWorkSheet.get_Range("J1:J1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("J1:J1").Value = "ST";

            excelWorkSheet.get_Range("A:J").Font.Size = 11;

            // Moses Newman 08/01/2018 Freeze header row.
            Excel.Range firstRow = (Excel.Range)excelWorkSheet.Rows[1];
            excelWorkSheet.Activate();
            excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
            firstRow.Application.ActiveWindow.FreezePanes = true;

            Excel.Range U1 = excelWorkSheet.get_Range("A1:J1");
            Excel.Range r = excelWorkSheet.get_Range("A2:J" + LastRow);

            U1.Font.Bold = true;
            U1.Font.Color = Excel.XlRgbColor.rgbWhite;
            U1.Interior.Color = Excel.XlRgbColor.rgbGreen;

            Excel.FormatCondition format = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
            format.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206);
            /*Excel.FormatCondition formatodd = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) <> 0");
            formatodd.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206); */
            r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            U1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            Excel.Range SubTotalRange = excelWorkSheet.get_Range("B1:H" + LastRow);
            SubTotalRange.Subtotal(7, Excel.XlConsolidationFunction.xlSum, new int[] { 2, 3, 4, 5, 6 }, true, false, Excel.XlSummaryRow.xlSummaryBelow);
            SubTotalRange.Subtotal(7, Excel.XlConsolidationFunction.xlCount, new int[] { 1 }, false, false, Excel.XlSummaryRow.xlSummaryBelow);

            if (IACType == "O")
            {
                OrgLoanAmount.Delete();
                TotalInterest.Delete();
                PaidInterest.Delete();
                UEInterest.Delete();
            }

            // End Trial Balance Main Tab

            // Do Dealer Summary Tab
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[2];
            excelWorkSheet.Select();

            //if (Dts.Variables["User::IACType"].Value.ToString() == "O")
            // excelWorkSheet.Name = "OpenTrialBalance";
            // Take leading space out of all number fields
            LastRow = (DealerCount + 1).ToString();
            String TotalRow = (DealerCount + 2).ToString();
            last = excelWorkSheet.get_Range("C2:I" + LastRow);

            foreach (Excel.Range Rng2 in last)
            {
                if (Rng2.Value != null)
                {
                    tmpString = Rng2.Value;
                    Rng2.Value = tmpString.Trim();
                }
            }

            Excel.Range DEALER = excelWorkSheet.get_Range("A:A");
            DEALER.Columns.EntireColumn.AutoFit();
            DEALER.Columns.ColumnWidth = 7;
            DEALER.Columns.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            DEALER.Columns.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("A1:A1").Value = "DEALER";
            excelWorkSheet.get_Range("A" + TotalRow + ":A" + TotalRow).Value = "TOTAL";
            excelWorkSheet.get_Range("A" + TotalRow + ":A" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DealerState = excelWorkSheet.get_Range("B:B");
            DealerState.Columns.EntireColumn.AutoFit();
            DealerState.Columns.ColumnWidth = 4;
            DealerState.Columns.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            DealerState.Columns.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("B1:B1").Value = "ST.";

            Excel.Range ACCTS = excelWorkSheet.get_Range("C:C");
            ACCTS.Columns.EntireColumn.AutoFit();
            ACCTS.Columns.ColumnWidth = 7;
            ACCTS.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("C1:C1").Value = "ACCTS";
            excelWorkSheet.get_Range("C" + TotalRow + ":C" + TotalRow).Value = "=SUM(C2:C" + LastRow + ")";
            excelWorkSheet.get_Range("C" + TotalRow + ":C" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range CUSTTOTALS = excelWorkSheet.get_Range("D:D");
            CUSTTOTALS.Columns.EntireColumn.AutoFit();
            CUSTTOTALS.Columns.ColumnWidth = 18;
            CUSTTOTALS.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("D1:D1").Value = "CUST TOTALS";
            excelWorkSheet.get_Range("D" + TotalRow + ":D" + TotalRow).Value = "=SUM(D2:D" + LastRow + ")";
            excelWorkSheet.get_Range("D" + TotalRow + ":D" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DEALERTOTALS = excelWorkSheet.get_Range("E:E");
            DEALERTOTALS.Columns.EntireColumn.AutoFit();
            DEALERTOTALS.Columns.ColumnWidth = 18;
            DEALERTOTALS.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("E1:E1").Value = "DEALER TOTALS";
            excelWorkSheet.get_Range("E" + TotalRow + ":E" + TotalRow).Value = "=SUM(E2:E" + LastRow + ")";
            excelWorkSheet.get_Range("E" + TotalRow + ":E" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DEALERCONT = excelWorkSheet.get_Range("F:F");
            DEALERCONT.Columns.EntireColumn.AutoFit();
            DEALERCONT.Columns.ColumnWidth = 18;
            DEALERCONT.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("F1:F1").Value = "DLR CONTINGENT";
            excelWorkSheet.get_Range("F" + TotalRow + ":F" + TotalRow).Value = "=SUM(F2:F" + LastRow + ")";
            excelWorkSheet.get_Range("F" + TotalRow + ":F" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DEALERAA = excelWorkSheet.get_Range("G:G");
            DEALERAA.Columns.EntireColumn.AutoFit();
            DEALERAA.Columns.ColumnWidth = 18;
            DEALERAA.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("G1:G1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("G1:G1").Value = "DEALER A/A";
            excelWorkSheet.get_Range("G" + TotalRow + ":G" + TotalRow).Value = "=SUM(G2:G" + LastRow + ")";
            excelWorkSheet.get_Range("G" + TotalRow + ":G" + TotalRow).Font.FontStyle = "Bold";


            Excel.Range DEALERINT = excelWorkSheet.get_Range("H:H");
            DEALERINT.Columns.EntireColumn.AutoFit();
            DEALERINT.Columns.ColumnWidth = 18;
            DEALERINT.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("H1:H1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("H1:H1").Value = "INTEREST E/C";
            excelWorkSheet.get_Range("H" + TotalRow + ":H" + TotalRow).Value = "=SUM(H2:H" + LastRow + ")";
            excelWorkSheet.get_Range("H" + TotalRow + ":H" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DEALERPAIDINT = excelWorkSheet.get_Range("I:I");
            DEALERPAIDINT.Columns.EntireColumn.AutoFit();
            DEALERPAIDINT.Columns.ColumnWidth = 18;
            DEALERPAIDINT.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("I1:I1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("I1:I1").Value = "PAID INTEREST";
            excelWorkSheet.get_Range("I" + TotalRow + ":I" + TotalRow).Value = "=SUM(I2:I" + LastRow + ")";
            excelWorkSheet.get_Range("I" + TotalRow + ":I" + TotalRow).Font.FontStyle = "Bold";

            excelWorkSheet.get_Range("A:I").Font.Size = 11;

            // Moses Newman 08/01/2018 Freeze header row.
            firstRow = (Excel.Range)excelWorkSheet.Rows[1];
            excelWorkSheet.Activate();
            excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
            firstRow.Application.ActiveWindow.FreezePanes = true;

            Excel.Range U21 = excelWorkSheet.get_Range("A1:I1");
            Excel.Range r2 = excelWorkSheet.get_Range("A2:I" + LastRow);

            U21.Font.Bold = true;
            U21.Font.Color = Excel.XlRgbColor.rgbWhite;
            U21.Interior.Color = Excel.XlRgbColor.rgbGreen;

            format = r2.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
            format.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206);
            r2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            U21.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            if (IACType == "O")
            {
                DEALERINT.Delete();
                DEALERPAIDINT.Delete();
            }

            // End Trial Balance Dealer Summary 

            // MasterTotals Tab
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[3];
            excelWorkSheet.Select();

            //if (Dts.Variables["User::IACType"].Value.ToString() == "O")
            // excelWorkSheet.Name = "OpenTrialBalance";
            // Take leading space out of all number fields
            last = excelWorkSheet.get_Range("A2:D2");

            foreach (Excel.Range Rng3 in last)
            {
                if (Rng3.Value != null)
                {
                    tmpString = Rng3.Value;
                    Rng3.Value = tmpString.Trim();
                }
            }

            Excel.Range MASTEROL = excelWorkSheet.get_Range("A:A");
            MASTEROL.Columns.EntireColumn.AutoFit();
            MASTEROL.Columns.ColumnWidth = 18;
            MASTEROL.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("A1:A1").Value = "MASTER O/L";

            Excel.Range MASTERCONT = excelWorkSheet.get_Range("B:B");
            MASTERCONT.Columns.EntireColumn.AutoFit();
            MASTERCONT.Columns.ColumnWidth = 18;
            MASTERCONT.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("B1:B1").Value = "MASTER CONT";

            Excel.Range MASTERAA = excelWorkSheet.get_Range("C:C");
            MASTERAA.Columns.EntireColumn.AutoFit();
            MASTERAA.Columns.ColumnWidth = 18;
            MASTERAA.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("C1:C1").Value = "MASTER A/A";

            Excel.Range MASTERINT = excelWorkSheet.get_Range("D:D");

            MASTERINT.Delete();
            excelWorkSheet.get_Range("A:I").Font.Size = 11;

            // Moses Newman 08/01/2018 Freeze header row.
            firstRow = (Excel.Range)excelWorkSheet.Rows[1];
            excelWorkSheet.Activate();
            excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
            firstRow.Application.ActiveWindow.FreezePanes = true;

            Excel.Range U31 = excelWorkSheet.get_Range("A1:C1");
            Excel.Range r3 = excelWorkSheet.get_Range("A2:C2");

            U31.Font.Bold = true;
            U31.Font.Color = Excel.XlRgbColor.rgbWhite;
            U31.Interior.Color = Excel.XlRgbColor.rgbGreen;

            format = r3.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
            format.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206);
            r3.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            U31.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            // End of MasterTotals Tab

            // Do Dealer Summary Report 26 Tab
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[4];
            excelWorkSheet.Select();
            excelWorkSheet.Name = "DealerSummaryReport(26)";

            // Take leading space out of all number fields
            LastRow = (DealerSummaryCount + 1).ToString();
            TotalRow = (DealerSummaryCount + 2).ToString();
            last = excelWorkSheet.get_Range("C2:F" + LastRow);

            foreach (Excel.Range Rng4 in last)
            {
                if (Rng4.Value != null)
                {
                    tmpString = Rng4.Value;
                    Rng4.Value = tmpString.Trim();
                }
            }

            Excel.Range DEALERacct = excelWorkSheet.get_Range("A:A");
            DEALERacct.Columns.EntireColumn.AutoFit();
            DEALERacct.Columns.ColumnWidth = 7;
            DEALERacct.Columns.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            DEALERacct.Columns.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("A1:A1").Value = "DEALER";
            excelWorkSheet.get_Range("A" + TotalRow + ":A" + TotalRow).Value = "TOTAL";
            excelWorkSheet.get_Range("A" + TotalRow + ":A" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DealerNm = excelWorkSheet.get_Range("B:B");
            DealerNm.Columns.EntireColumn.AutoFit();
            DealerNm.Columns.ColumnWidth = 30;
            excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("B1:B1").Value = "NAME";


            Excel.Range DEALERTOTALSNR = excelWorkSheet.get_Range("C:C");
            DEALERTOTALSNR.Columns.EntireColumn.AutoFit();
            DEALERTOTALSNR.Columns.ColumnWidth = 18;
            DEALERTOTALSNR.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("C1:C1").Value = "DEALER TOTALS (NR)";
            excelWorkSheet.get_Range("C" + TotalRow + ":C" + TotalRow).Value = "=SUM(C2:C" + LastRow + ")";
            excelWorkSheet.get_Range("C" + TotalRow + ":C" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DEALERCONTINGENT = excelWorkSheet.get_Range("D:D");
            DEALERCONTINGENT.Columns.EntireColumn.AutoFit();
            DEALERCONTINGENT.Columns.ColumnWidth = 20;
            DEALERCONTINGENT.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("D1:D1").Value = "DEALER CONTINGENT";
            excelWorkSheet.get_Range("D" + TotalRow + ":D" + TotalRow).Value = "=SUM(D2:D" + LastRow + ")";
            excelWorkSheet.get_Range("D" + TotalRow + ":D" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DLRAA = excelWorkSheet.get_Range("E:E");
            DLRAA.Columns.EntireColumn.AutoFit();
            DLRAA.Columns.ColumnWidth = 18;
            DLRAA.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("E1:E1").Value = "DEALER A/A";
            excelWorkSheet.get_Range("E" + TotalRow + ":E" + TotalRow).Value = "=SUM(E2:E" + LastRow + ")";
            excelWorkSheet.get_Range("E" + TotalRow + ":E" + TotalRow).Font.FontStyle = "Bold";

            Excel.Range DEALERLOSS = excelWorkSheet.get_Range("F:F");
            DEALERLOSS.Columns.EntireColumn.AutoFit();
            DEALERLOSS.Columns.ColumnWidth = 18;
            DEALERLOSS.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("F1:F1").Value = "DEALER LOSS RESV.";
            excelWorkSheet.get_Range("F" + TotalRow + ":F" + TotalRow).Value = "=SUM(F2:F" + LastRow + ")";
            excelWorkSheet.get_Range("F" + TotalRow + ":F" + TotalRow).Font.FontStyle = "Bold";


            excelWorkSheet.get_Range("A:F").Font.Size = 11;

            // Moses Newman 08/01/2018 Freeze header row.
            firstRow = (Excel.Range)excelWorkSheet.Rows[1];
            excelWorkSheet.Activate();
            excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
            firstRow.Application.ActiveWindow.FreezePanes = true;

            Excel.Range U41 = excelWorkSheet.get_Range("A1:F1");
            Excel.Range r4 = excelWorkSheet.get_Range("A2:F" + LastRow);

            U41.Font.Bold = true;
            U41.Font.Color = Excel.XlRgbColor.rgbWhite;
            U41.Interior.Color = Excel.XlRgbColor.rgbGreen;

            format = r4.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
            format.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206);
            r4.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            U41.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            // End Trial Balance Dealer Summary Report 26


            // Go back to detail sheet
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[1];
            excelWorkSheet.Select();

            excelWorkBook.Save();
        }

        public bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
}

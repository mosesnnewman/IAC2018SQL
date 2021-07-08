using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System.IO;


namespace IAC2018SQL
{
    public partial class FormCashPaymentSummary : Form
    {
        private PaymentDataSet PaymentData = new PaymentDataSet();
        private PaymentDataSetTableAdapters.CashPaymentSummaryTableAdapter CashPaymentSummaryTableAdapter = new PaymentDataSetTableAdapters.CashPaymentSummaryTableAdapter();
        private Int32 RowCount;

        public FormCashPaymentSummary()
        {
            InitializeComponent();
        }

        private void FormCashPaymentSummary_Load(object sender, EventArgs e)
        {
            Int32 lnMonth = DateTime.Now.Date.Month,
                  lnYear  = DateTime.Now.Date.Year;
            DateTime ldStart, ldEnd;

            ldStart = new DateTime(lnYear, lnMonth, 1);
            if (lnMonth == 12)
            {
                ldEnd = new DateTime(lnYear,lnMonth,31);
            }
            else
            {
                ldEnd = new DateTime(lnYear, lnMonth + 1, 1);
                ldEnd = ldEnd.AddDays(-1);
            }

            nullableDateTimePickerStartDate.Value = ldStart;
            nullableDateTimePickerEndDate.Value = ldEnd;
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();

            CashPaymentSummaryTableAdapter.Fill(PaymentData.CashPaymentSummary, (DateTime)nullableDateTimePickerStartDate.Value, (DateTime)nullableDateTimePickerEndDate.Value);
            RowCount = PaymentData.CashPaymentSummary.Rows.Count;
            if (SQLBR.RunJob("CreateCashSummary", "Create Cash Summary EXCEL", false))
            {
                Thread.Sleep(1000);
                EXCELPretty();
            }
        }

        private void EXCELPretty()
        {
            String FullSourcePath = @"\\DC-IAC\PUBLIC\AccStuff\mfdata\EXCLDATA\CashPaymentSummary.xlsx";

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

            excelWorkSheet.Name = "CashPaymentSummary";
            excelWorkSheet.Rows[1].Delete();

            String LastRow = (RowCount + 1).ToString();

            Excel.Range Date = excelWorkSheet.get_Range("A:A");
            Date.Columns.EntireColumn.AutoFit();
            Date.Columns.ColumnWidth = 12;
            Date.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("A1:A1").Value = "Date";

            Excel.Range Week = excelWorkSheet.get_Range("B:B");
            Week.Columns.EntireColumn.AutoFit();
            Week.Columns.ColumnWidth = 12;
            Week.Columns.NumberFormat = "mm/dd/yyyy";
            excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("B1:B1").Value = "Week";


            Excel.Range ClosedCheckCount = excelWorkSheet.get_Range("C:C");
            ClosedCheckCount.Columns.EntireColumn.AutoFit();
            ClosedCheckCount.Columns.ColumnWidth = 7;
            ClosedCheckCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("C1:C1").Value = "ClosedCheckCount";

            Excel.Range ClosedCheckTotal = excelWorkSheet.get_Range("D:D");
            ClosedCheckTotal.Columns.EntireColumn.AutoFit();
            ClosedCheckTotal.Columns.ColumnWidth = 18;
            ClosedCheckTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("D1:D1").Value = "ClosedCheckTotal";

            Excel.Range OpenCheckCount = excelWorkSheet.get_Range("E:E");
            OpenCheckCount.Columns.EntireColumn.AutoFit();
            OpenCheckCount.Columns.ColumnWidth = 7;
            OpenCheckCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("E1:E1").Value = "OpenCheckCount";

            Excel.Range OpenCheckTotal = excelWorkSheet.get_Range("D:D");
            OpenCheckTotal.Columns.EntireColumn.AutoFit();
            OpenCheckTotal.Columns.ColumnWidth = 18;
            OpenCheckTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("F1:F1").Value = "OpenCheckTotal";

            Excel.Range ClosedCashCount = excelWorkSheet.get_Range("G:G");
            ClosedCashCount.Columns.EntireColumn.AutoFit();
            ClosedCashCount.Columns.ColumnWidth = 7;
            ClosedCashCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("G1:G1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("G1:G1").Value = "ClosedCashCount";

            Excel.Range ClosedCashTotal = excelWorkSheet.get_Range("H:H");
            ClosedCashTotal.Columns.EntireColumn.AutoFit();
            ClosedCashTotal.Columns.ColumnWidth = 18;
            ClosedCashTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("H1:H1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("H1:H1").Value = "ClosedCashTotal";

            Excel.Range OpenCashCount = excelWorkSheet.get_Range("I:I");
            OpenCashCount.Columns.EntireColumn.AutoFit();
            OpenCashCount.Columns.ColumnWidth = 7;
            OpenCashCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("I1:I1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("I1:I1").Value = "OpenCashCount";

            Excel.Range OpenCashTotal = excelWorkSheet.get_Range("J:J");
            OpenCashTotal.Columns.EntireColumn.AutoFit();
            OpenCashTotal.Columns.ColumnWidth = 18;
            OpenCashTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("J1:J1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("J1:J1").Value = "OpenCashTotal";

            Excel.Range ClosedWesternUnionCount = excelWorkSheet.get_Range("K:K");
            ClosedWesternUnionCount.Columns.EntireColumn.AutoFit();
            ClosedWesternUnionCount.Columns.ColumnWidth = 7;
            ClosedWesternUnionCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("K1:K1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("K1:K1").Value = "ClosedWesternUnionCount";

            Excel.Range ClosedWesternUnionTotal = excelWorkSheet.get_Range("L:L");
            ClosedWesternUnionTotal.Columns.EntireColumn.AutoFit();
            ClosedWesternUnionTotal.Columns.ColumnWidth = 18;
            ClosedWesternUnionTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("L1:L1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("L1:L1").Value = "ClosedWesternUnionTotal";

            Excel.Range OpenWesternUnionCount = excelWorkSheet.get_Range("M:M");
            OpenWesternUnionCount.Columns.EntireColumn.AutoFit();
            OpenWesternUnionCount.Columns.ColumnWidth = 7;
            OpenWesternUnionCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("M1:M1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("M1:M1").Value = "OpenWesternUnionCount";

            Excel.Range OpenWesternUnionTotal = excelWorkSheet.get_Range("N:n");
            OpenWesternUnionTotal.Columns.EntireColumn.AutoFit();
            OpenWesternUnionTotal.Columns.ColumnWidth = 18;
            OpenWesternUnionTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("N1:N1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("N1:N1").Value = "OpenWesternUnionTotal";

            Excel.Range ClosedPayNearMeCount = excelWorkSheet.get_Range("O:O");
            ClosedPayNearMeCount.Columns.EntireColumn.AutoFit();
            ClosedPayNearMeCount.Columns.ColumnWidth = 7;
            ClosedPayNearMeCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("O1:O1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("O1:O1").Value = "ClosedPayNearMeCount";

            Excel.Range ClosedPayNearMeTotal = excelWorkSheet.get_Range("P:P");
            ClosedPayNearMeTotal.Columns.EntireColumn.AutoFit();
            ClosedPayNearMeTotal.Columns.ColumnWidth = 18;
            ClosedPayNearMeTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("P1:P1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("P1:P1").Value = "ClosedPayNearMeTotal";

            Excel.Range OpenPayNearMeCount = excelWorkSheet.get_Range("Q:Q");
            OpenPayNearMeCount.Columns.EntireColumn.AutoFit();
            OpenPayNearMeCount.Columns.ColumnWidth = 7;
            OpenPayNearMeCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("Q1:Q1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("Q1:Q1").Value = "OpenPayNearMeCount";

            Excel.Range OpenPayNearMeTotal = excelWorkSheet.get_Range("R:R");
            OpenPayNearMeTotal.Columns.EntireColumn.AutoFit();
            OpenPayNearMeTotal.Columns.ColumnWidth = 18;
            OpenPayNearMeTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("R1:R1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("R1:R1").Value = "OpenPayNearMeTotal";

            Excel.Range ClosedACHCount = excelWorkSheet.get_Range("S:S");
            ClosedACHCount.Columns.EntireColumn.AutoFit();
            ClosedACHCount.Columns.ColumnWidth = 7;
            ClosedACHCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("S1:S1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("S1:S1").Value = "ClosedACHCount";

            Excel.Range ClosedACHTotal = excelWorkSheet.get_Range("T:T");
            ClosedACHTotal.Columns.EntireColumn.AutoFit();
            ClosedACHTotal.Columns.ColumnWidth = 18;
            ClosedACHTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("T1:T1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("T1:T1").Value = "ClosedACHTotal";

            Excel.Range OpenACHCount = excelWorkSheet.get_Range("U:U");
            OpenACHCount.Columns.EntireColumn.AutoFit();
            OpenACHCount.Columns.ColumnWidth = 7;
            OpenACHCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("U1:U1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("U1:U1").Value = "OpenACHCount";

            Excel.Range OpenACHTotal = excelWorkSheet.get_Range("V:V");
            OpenACHTotal.Columns.EntireColumn.AutoFit();
            OpenACHTotal.Columns.ColumnWidth = 18;
            OpenACHTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("V1:V1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("V1:V1").Value = "OpenACHTotal";

            Excel.Range ClosedCreditCardCount = excelWorkSheet.get_Range("W:W");
            ClosedCreditCardCount.Columns.EntireColumn.AutoFit();
            ClosedCreditCardCount.Columns.ColumnWidth = 7;
            ClosedCreditCardCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("W1:W1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("W1:W1").Value = "ClosedCreditCardCount";

            Excel.Range ClosedCreditCardTotal = excelWorkSheet.get_Range("X:X");
            ClosedCreditCardTotal.Columns.EntireColumn.AutoFit();
            ClosedCreditCardTotal.Columns.ColumnWidth = 18;
            ClosedCreditCardTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("X1:X1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("X1:X1").Value = "ClosedCreditCardTotal";

            Excel.Range OpenCreditCardCount = excelWorkSheet.get_Range("Y:Y");
            OpenCreditCardCount.Columns.EntireColumn.AutoFit();
            OpenCreditCardCount.Columns.ColumnWidth = 7;
            OpenCreditCardCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("Y1:Y1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("Y1:Y1").Value = "OpenCreditCardCount";

            Excel.Range OpenCreditCardTotal = excelWorkSheet.get_Range("Z:Z");
            OpenCreditCardTotal.Columns.EntireColumn.AutoFit();
            OpenCreditCardTotal.Columns.ColumnWidth = 18;
            OpenCreditCardTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("Z1:Z1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("Z1:Z1").Value = "OpenCreditCardTotal";

            Excel.Range ClosedEFTCount = excelWorkSheet.get_Range("AA:AA");
            ClosedEFTCount.Columns.EntireColumn.AutoFit();
            ClosedEFTCount.Columns.ColumnWidth = 7;
            ClosedEFTCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("AA1:AA1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AA1:AA1").Value = "ClosedEFTCount";

            Excel.Range ClosedEFTTotal = excelWorkSheet.get_Range("AB:AB");
            ClosedEFTTotal.Columns.EntireColumn.AutoFit();
            ClosedEFTTotal.Columns.ColumnWidth = 18;
            ClosedEFTTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("AB1:AB1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AB1:AB1").Value = "ClosedEFTTotal";

            Excel.Range OpenEFTCount = excelWorkSheet.get_Range("AC:AC");
            OpenEFTCount.Columns.EntireColumn.AutoFit();
            OpenEFTCount.Columns.ColumnWidth = 7;
            OpenEFTCount.Columns.NumberFormat = "######";
            excelWorkSheet.get_Range("AC1:AC1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AC1:AC1").Value = "OpenEFTCount";

            Excel.Range OpenEFTTotal = excelWorkSheet.get_Range("AD:AD");
            OpenEFTTotal.Columns.EntireColumn.AutoFit();
            OpenEFTTotal.Columns.ColumnWidth = 18;
            OpenEFTTotal.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("AD1:AD1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("AD1:AD1").Value = "OpenEFTTotal";

            excelWorkSheet.get_Range("A:AD").Font.Size = 11;

            // Moses Newman 08/01/2018 Freeze header row.
            Excel.Range firstRow = (Excel.Range)excelWorkSheet.Rows[1];
            excelWorkSheet.Activate();
            excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
            firstRow.Application.ActiveWindow.FreezePanes = true;

            Excel.Range U1 = excelWorkSheet.get_Range("A1:AD1");
            Excel.Range r = excelWorkSheet.get_Range("A2:AD2" + LastRow);

            U1.Font.Bold = true;
            U1.Font.Color = Excel.XlRgbColor.rgbWhite;
            U1.Interior.Color = Excel.XlRgbColor.rgbGreen;

            Excel.FormatCondition format = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
            format.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206);
            /*Excel.FormatCondition formatodd = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) <> 0");
            formatodd.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206); */
            /*r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
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
            */
            // End Trial Balance Main Tab

            // Do Dealer Summary Tab
            //excelWorkSheet = excelApp.Workbooks[1].Worksheets[2];
            excelWorkSheet.Select();

            //if (Dts.Variables["User::IACType"].Value.ToString() == "O")
            // excelWorkSheet.Name = "OpenTrialBalance";
            // Take leading space out of all number fields
            /*LastRow = (DealerCount + 1).ToString();
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

            */
            // Go back to detail sheet
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[1];
            excelWorkSheet.Select();

            excelWorkBook.Save();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

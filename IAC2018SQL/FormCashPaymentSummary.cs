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


namespace IAC2021SQL
{
    public partial class FormCashPaymentSummary : DevExpress.XtraEditors.XtraForm
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

            nullableDateTimePickerStartDate.EditValue = DateTime.Now.AddMonths(-1).Date;
            nullableDateTimePickerEndDate.EditValue = DateTime.Now.Date;
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();

            CashPaymentSummaryTableAdapter.Fill(PaymentData.CashPaymentSummary, (DateTime)nullableDateTimePickerStartDate.EditValue, (DateTime)nullableDateTimePickerEndDate.EditValue);
            RowCount = PaymentData.CashPaymentSummary.Rows.Count;
            if(RowCount < 1)
            {
                MessageBox.Show("*** No records were returned for this date range! ***");
                return;
            }
            if (SQLBR.RunJob("CreateCashSummary", "Create Cash Summary EXCEL", false))
            {
                Thread.Sleep(2000);
                EXCELPretty();
            }
        }

        private void EXCELPretty()
        {
            String FullSourcePath = @"\\DC-IAC\PUBLIC\AccStuff\mfdata\EXCLDATA\CashPaymentSummary.xlsx";

            Excel.Application excelApp = new Excel.Application();

            excelApp.Visible = true;
            excelApp.WindowState = Excel.XlWindowState.xlMinimized;
            excelApp.WindowState = Excel.XlWindowState.xlMaximized;

            excelApp.Workbooks.Open(FullSourcePath);

            Excel.Workbook excelWorkBook = excelApp.Workbooks[1];

            Excel.Worksheet excelWorkSheet;
            excelWorkBook = excelApp.Workbooks[1];
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[1];

            //excelWorkSheet.PageSetup.CenterHeader = "&\"Arial\"&B&12&KFF0000" + "Customer Bank Extract";
            excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;

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
            Week.Columns.ColumnWidth = 16;
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

            Excel.Range OpenCheckTotal = excelWorkSheet.get_Range("F:F");
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

            Excel.Range OpenWesternUnionTotal = excelWorkSheet.get_Range("N:N");
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

            // Freeze header row.
            Excel.Range firstRow = (Excel.Range)excelWorkSheet.Rows[1];
            excelWorkSheet.Activate();
            excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
            firstRow.Application.ActiveWindow.FreezePanes = true;

            Excel.Range SubTotalRange = excelWorkSheet.get_Range("B1:AD" + LastRow);
            SubTotalRange.Subtotal(1, Excel.XlConsolidationFunction.xlSum, new int[] { 2, 3, 4, 5, 6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27 }, true, false, Excel.XlSummaryRow.xlSummaryBelow);

            String tmpString;
            foreach(Excel.Range rCell in SubTotalRange.Rows)
            {
                tmpString = rCell.Cells[1, 1].Value2 != null ? rCell.Cells[1,1].Value2.ToString().Trim():"";
                if (tmpString.Length > 5)
                    if (tmpString.Substring(tmpString.Length - 5, 5) == "Total" || tmpString.Substring(0, 11) == "Grand Total")
                        rCell.Font.Bold = true;
            }

            var loWCount = CashPaymentSummaryTableAdapter.WeekCount();
            Int32 WeekCount = loWCount != null ? (Int32)loWCount : 0;

            
            LastRow = (RowCount + WeekCount + 1).ToString();
            String GrandRow = (RowCount + WeekCount + 2).ToString();
            Excel.Range LastLine = excelWorkSheet.get_Range("B"+LastRow + ":AD" + GrandRow);
            LastLine.EntireRow.Font.Bold = true;

            Excel.Range U1 = excelWorkSheet.get_Range("A1:AD1");
            Excel.Range r = excelWorkSheet.get_Range("A2:AD" + GrandRow);

            U1.Font.Bold = true;
            U1.Font.Color = Excel.XlRgbColor.rgbWhite;
            U1.Interior.Color = Excel.XlRgbColor.rgbLightSalmon;

            Excel.FormatCondition format = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
            format.Interior.Color = Excel.XlRgbColor.rgbBisque;
            Excel.FormatCondition formatodd = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) <> 0");
            formatodd.Interior.Color = Excel.XlRgbColor.rgbLightSalmon;
            r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            U1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            excelWorkSheet.Select();

            excelWorkBook.Save();
            excelApp.Quit();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System.Threading;
using System.Windows.Forms;


namespace IAC2018SQL
{
    class ClosedOverpayment
    {
        private IACDataSet Bank = new IACDataSet();
        private IACDataSetTableAdapters.DataPathTableAdapter DataPathTableAdapter = new IACDataSetTableAdapters.DataPathTableAdapter();
        private PaymentDataSetTableAdapters.CustomerExtractTableAdapter CustomerExtractTableAdapter = new PaymentDataSetTableAdapters.CustomerExtractTableAdapter();
        private String sourcePath, lsExcelFileOut, lsTemplate;

        private void CreateExcelFile()
        {

            DataPathTableAdapter.Fill(Bank.DataPath);
            sourcePath = Bank.DataPath.Rows[0].Field<String>("Path").TrimEnd();
            lsExcelFileOut = sourcePath + @"comp1000\OverPayment.xlsx";
            lsTemplate = sourcePath + @"comp1000\TemplateOverPayment.xlsx";

            try
            {
                if (File.Exists(lsExcelFileOut))
                    File.Delete(lsExcelFileOut);
            }
            catch
            {
                MessageBox.Show("Could Not Open OverPayment.xlsx because someone has it open!", "EXCEL File In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (File.Exists(lsTemplate))
            {
                File.Copy(lsTemplate, lsExcelFileOut);
                File.SetAttributes(lsExcelFileOut, FileAttributes.Normal);
            }
            sourcePath += @"comp1000\OverPAyment.xlsx";
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            SQLBR.RunJob("CustomerOverpayment", "Create OverPayment Excel Ouput", false);
            Thread.Sleep(10000);
            SQLBR.Dispose();
        }

        public void CreateIt()
        {
            CreateExcelFile();
            //Create an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            excelApp.Visible = true;
            excelApp.WindowState = Excel.XlWindowState.xlMinimized;
            excelApp.WindowState = Excel.XlWindowState.xlMaximized;

            //open excel workbook
            Excel.Workbook excelWorkBook;
            excelApp.Workbooks.Open(lsExcelFileOut);

            Excel.Worksheet excelWorkSheet;
            excelWorkBook = excelApp.Workbooks[1];
            excelWorkSheet = excelApp.Workbooks[1].Worksheets[1];

            excelWorkSheet.PageSetup.CenterHeader = "&\"Arial\"&B&12&KFF0000" + "Closed Customer Overpayments";
            excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;

            Excel.Range Account = excelWorkSheet.get_Range("A:A");
            Account.Columns.EntireColumn.AutoFit();
            Account.Columns.ColumnWidth = 12;
            Account.Columns.NumberFormat = "000000";
            excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("A1:A1").Value = "Account No.";

            Excel.Range Name = excelWorkSheet.get_Range("B:B");
            Name.Columns.EntireColumn.AutoFit();
            Name.Columns.ColumnWidth = 31;
            excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("B1:B1").Value = "Name";


            Excel.Range Address = excelWorkSheet.get_Range("C:C");
            Address.Columns.EntireColumn.AutoFit();
            Address.Columns.ColumnWidth = 30;
            excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("C1:C1").Value = "Address";

            Excel.Range City = excelWorkSheet.get_Range("D:D");
            City.Columns.EntireColumn.AutoFit();
            City.Columns.ColumnWidth = 15;
            excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("D1:D1").Value = "City";

            Excel.Range State = excelWorkSheet.get_Range("E:E");
            State.Columns.EntireColumn.AutoFit();
            State.Columns.ColumnWidth = 6;
            excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("E1:E1").Value = "State";

            Excel.Range ZipCode = excelWorkSheet.get_Range("F:F");
            ZipCode.Columns.EntireColumn.AutoFit();
            ZipCode.Columns.ColumnWidth = 11;
            ZipCode.Columns.NumberFormat = "00000";
            excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("F1:F1").Value = "Zip Code";

            Excel.Range DealerNum = excelWorkSheet.get_Range("G:G");
            DealerNum.Columns.EntireColumn.AutoFit();
            DealerNum.Columns.ColumnWidth = 7;
            DealerNum.Columns.NumberFormat = "###";
            excelWorkSheet.get_Range("G1:G1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("G1:G1").Value = "Dealer";

            Excel.Range PostingCode = excelWorkSheet.get_Range("H:H");
            PostingCode.Columns.EntireColumn.AutoFit();
            PostingCode.Columns.ColumnWidth = 9;
            excelWorkSheet.get_Range("H1:H1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("H1:H1").Value = "Post Code";

            Excel.Range PaymentDate = excelWorkSheet.get_Range("I:I");
            PaymentDate.Columns.EntireColumn.AutoFit();
            PaymentDate.Columns.NumberFormat = "mm/dd/yyyy";
            PaymentDate.Columns.ColumnWidth = 10.57;
            excelWorkSheet.get_Range("I1:I1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("I1:I1").Value = "Payment Date";

            Excel.Range LastPayment = excelWorkSheet.get_Range("J:J");
            LastPayment.Columns.EntireColumn.AutoFit();
            LastPayment.Columns.ColumnWidth = 14;
            LastPayment.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("J1:J1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("J1:J1").Value = "Last Payment";

            Excel.Range Balance = excelWorkSheet.get_Range("K:K");
            Balance.Columns.EntireColumn.AutoFit();
            Balance.Columns.ColumnWidth = 14;
            Balance.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
            excelWorkSheet.get_Range("K1:K1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("K1:K1").Value = "Balance";

            Excel.Range CheckIssued = excelWorkSheet.get_Range("L:L");
            CheckIssued.Columns.EntireColumn.AutoFit();
            CheckIssued.Columns.ColumnWidth = 17;
            excelWorkSheet.get_Range("L1:L1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("L1:L1").Value = "O/P Check Issued?";

            Excel.Range CheckNumber = excelWorkSheet.get_Range("M:M");
            CheckNumber.Columns.EntireColumn.AutoFit();
            CheckNumber.Columns.ColumnWidth = 14;
            excelWorkSheet.get_Range("M1:M1").Font.FontStyle = "Bold";
            excelWorkSheet.get_Range("M1:M1").Value = "Check Number";

            Excel.Range last = excelWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, System.Type.Missing);
            for (int i = 2; i < last.Row + 1; i++)
            {
                excelWorkSheet.Cells[i, 10].Value = Convert.ToDecimal(excelWorkSheet.Cells[i, 10].Value);
                excelWorkSheet.Cells[i, 11].Value = Convert.ToDecimal(excelWorkSheet.Cells[i, 11].Value);
            }

            excelWorkSheet.get_Range("A:M").Font.Size = 11;
            // Moses Newman 08/01/2018 Freeze header row.
            Excel.Range firstRow = (Excel.Range)excelWorkSheet.Rows[1];
            excelWorkSheet.Activate();
            excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
            firstRow.Application.ActiveWindow.FreezePanes = true;

            Excel.Range U1 = excelWorkSheet.get_Range("A1:M1");
            Excel.Range r = excelWorkSheet.get_Range("A2:M" + (excelWorkSheet.Rows.Count).ToString());

            U1.Font.Bold = true;
            U1.Font.Color = Excel.XlRgbColor.rgbWhite;
            U1.Interior.Color = Excel.XlRgbColor.rgbGreen;

            Excel.FormatCondition format = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
            format.Interior.Color = System.Drawing.Color.FromArgb(198, 239, 206);
            r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            U1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            Balance.Delete();
            excelWorkBook.Save();
            excelWorkBook.Close();
            excelApp.Quit();
            MessageBox.Show("*** Closed Overpayment Report Completed! ***");
        }
    }
}

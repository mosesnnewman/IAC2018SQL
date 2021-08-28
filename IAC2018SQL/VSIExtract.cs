using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
// Moses Newman 01/26/2018 Pretty the VSI Extract fields by using Excel Automation
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;

namespace IAC2021SQL
{
    public partial class FormVSIExtract : Form
    {

        public FormVSIExtract()
        {
            InitializeComponent();
        }

        
        private void FormVSIExtract_Load(object sender, EventArgs e)
        {
            this.dLRLISTBYNUMTableAdapter.Fill(this.iACDataSet.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.DataSource = iACDataSet.DLRLISTBYNUM;
            nullableDateTimePickerStartDate.Value = DateTime.Parse("01/01/1980").Date;
            nullableDateTimePickerEndDate.Value = DateTime.Now.Date;
            dLRLISTBYNUMTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_ACC_NO", "   ");
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("DEALER_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            String lsDealer = comboBoxDealer.Text.TrimEnd() + "%", lsState = textBoxState.Text.Trim() + "%";

            IACDataSetTableAdapters.CustomerVSITableAdapter CustomerVSITableAdapter = new IACDataSetTableAdapters.CustomerVSITableAdapter();
            CustomerVSITableAdapter.Fill(iACDataSet.CustomerVSI, (DateTime)nullableDateTimePickerStartDate.Value, (DateTime)nullableDateTimePickerEndDate.Value,lsDealer,lsState);

            String  lsUNCROOT = Program.GsDataPath, lsExcelFileOut = lsUNCROOT + @"\AccStuff\mfdata\EXCLDATA\CustomerVSIExtract.xls",
                               lsTemplate = lsUNCROOT + @"\AccStuff\mfdata\EXCLDATA\CustomerVSIExtractTemplate.xls",

                    lsNewFileOut = lsUNCROOT + @"\AccStuff\mfdata\EXCLDATA\CustomerVSIExtract" + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString().PadLeft(2, '0') + DateTime.Now.Date.Day.ToString().PadLeft(2, '0') + @".xlsx";

            if (File.Exists(lsExcelFileOut))
                File.Delete(lsExcelFileOut);

            if (File.Exists(lsNewFileOut))
                File.Delete(lsNewFileOut);

            File.SetAttributes(lsTemplate, FileAttributes.Normal);

            File.Copy(lsTemplate, lsExcelFileOut);

            File.SetAttributes(lsTemplate, FileAttributes.ReadOnly);
            if (SQLBR.RunJob("VSIToExcel", "VSI Extract To Excel", false))
            {
                Thread.Sleep(5000);
                try
                {

                    if (File.Exists(lsExcelFileOut))
                    {
                        // Moses Newman 01/30/2017 Add Excel Automation column and page formatting
                        //Create an Excel application instance
                        Excel.Application excelApp = new Excel.Application();

                        //Create an Excel workbook open excel workbook
                        Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(lsExcelFileOut);


                        //Add a new worksheet to workbook with the Datatable name
                        Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets["VSIExtract"];
                        excelWorkSheet.Select(Type.Missing);

                        excelWorkSheet.PageSetup.CenterHeader = "&\"Arial\"&B&12&KFF0000VSI Extract Report";
                        excelWorkSheet.PageSetup.LeftHeader = "&\"Arial\"&B&12&KFF0000Date: &D\nPolicy#: UL152162\n\n\n   ";

                        Excel.Range DealerNo = excelWorkSheet.get_Range("A:A");
                        DealerNo.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold"; 

                        Excel.Range AccountNumber = excelWorkSheet.get_Range("B:B");
                        AccountNumber.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold"; 
                        

                        Excel.Range Name = excelWorkSheet.get_Range("C:C");
                        Name.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";

                        Excel.Range CoBuyerName = excelWorkSheet.get_Range("D:D");
                        CoBuyerName.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";

                        Excel.Range ContractDate = excelWorkSheet.get_Range("E:E");
                        ContractDate.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";

                        Excel.Range Term = excelWorkSheet.get_Range("F:F");
                        Term.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";

                        Excel.Range AmountFinanced = excelWorkSheet.get_Range("G:G");
                        AmountFinanced.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("G1:G1").Font.FontStyle = "Bold";

                        Excel.Range VinLast6 = excelWorkSheet.get_Range("H:H");
                        VinLast6.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("H1:H1").Font.FontStyle = "Bold";

                        Excel.Range Year = excelWorkSheet.get_Range("I:I");
                        Year.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("I1:I1").Font.FontStyle = "Bold";
                        excelWorkSheet.get_Range("I1:I1").Value = "Year";

                        Excel.Range Make = excelWorkSheet.get_Range("J:J");
                        Make.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("J1:J1").Font.FontStyle = "Bold";
                        excelWorkSheet.get_Range("J1:J1").Value = "Make";

                        Excel.Range Model = excelWorkSheet.get_Range("K:K");
                        Model.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("K1:K1").Font.FontStyle = "Bold";
                        excelWorkSheet.get_Range("K1:K1").Value = "Model";

                        Excel.Range DealerState = excelWorkSheet.get_Range("L:L");
                        DealerState.Columns.EntireColumn.AutoFit();
                        excelWorkSheet.get_Range("L1:L1").Font.FontStyle = "Bold";
                        excelWorkSheet.get_Range("L1:L1").Value = "State";

                        Excel.Range r = excelWorkSheet.get_Range("A2:L" + excelWorkSheet.Rows.Count.ToString());
                        Excel.FormatCondition format = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
                        format.Interior.Color = Excel.XlRgbColor.rgbBisque;

                        excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter;
                        excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                        //excelWorkSheet.PageSetup.TopMargin = .25;
                        excelWorkSheet.PageSetup.LeftMargin = .25;
                        excelWorkSheet.PageSetup.RightMargin = .25;
                        excelWorkSheet.PageSetup.BottomMargin = .25;
                        excelWorkSheet.PageSetup.FitToPagesWide = 1;
                        excelWorkSheet.PageSetup.Zoom = false;

                        excelApp.ActiveWindow.View = Excel.XlWindowView.xlPageLayoutView;

                        excelWorkSheet.get_Range("A:L").Font.Size = 8;

                        excelWorkBook.SaveAs(lsExcelFileOut+'x',Excel.XlFileFormat.xlWorkbookDefault);
                        excelWorkBook.Close();
                        excelApp.Quit();
                        // Moses Newman 01/30/2018 End Excel Formatting

                        if (File.Exists(lsExcelFileOut))
                            File.Delete(lsExcelFileOut);
                        File.Move(lsExcelFileOut+'x',lsNewFileOut);
                        MessageBox.Show("Successfully Created: " + lsNewFileOut);
                    }
                }
                catch
                {
                    MessageBox.Show("*** Something went wrong!  File not created! ***");
                }
            }


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

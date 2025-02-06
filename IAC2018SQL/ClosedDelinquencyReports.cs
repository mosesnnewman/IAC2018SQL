using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using IAC2021SQL.IACDataSetTableAdapters;
using DevExpress.Export.Xl;
using System.Data;
using System.IO;
using System.Drawing;



namespace IAC2021SQL
{
    public partial class frmClosedDelinquencyReports : DevExpress.XtraEditors.XtraForm
    {
        public frmClosedDelinquencyReports()
        {
            InitializeComponent();
        }

        private void frmClosedDelinquencyReports_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            comboBoxAgedPeriod.SelectedIndex = 0;
            nullableDateTimePickerDueDate.EditValue = DateTime.Now.Date;
            comboBoxSortType.SelectedIndex = 0;
        }

        private void PrintDelinquencyReport()
        {
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.EditValue)).Date;

            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter ClosedDealerAgedSummarySelectTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectCOLTableAdapter ClosedDealerAgedSummarySelectCOLTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectCOLTableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.EmailTableAdapter EmailTableAdapter = new IACDataSetTableAdapters.EmailTableAdapter();
            // Moses Newman 11/9/2021 Add handling of Extension and Rate Changes for Last Payment Amount Field
            IACDataSetTableAdapters.ClosedExtensionCountsTableAdapter ClosedExtensionCountsTableAdapter = new IACDataSetTableAdapters.ClosedExtensionCountsTableAdapter();
            Int32 lnAgedTest = comboBoxAgedPeriod.SelectedIndex + 1;

            // Moses Newman 11/20/2018 add sort order.
            String lsSortType = null;

            if (comboBoxSortType.SelectedIndex == 1)
                lsSortType = "D";

            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            switch (lnAgedTest)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:

                    if (!checkBoxCollections.Checked)
                    {
                        CUSTOMERTableAdapter.FillByDelinquencies(DelinquencyData.CUSTOMER, lnAgedTest, ldCurrDate.Date, lsSortType);
                        // Moses Newman 11/19/2013 Moses Newman added ldCurrDate as new parameter to DealerFillByDelinQuencies Query
                        DEALERTableAdapter.FillByDelinquencies(DelinquencyData.DEALER, lnAgedTest, ldCurrDate);
                        // Moses Newman 09/27/2021 
                        EmailTableAdapter.FillByDelinquencies(DelinquencyData.Email, lnAgedTest, ldCurrDate);
                        // Moses Newman 11/9/2021 Handle Extensions and Rate Changes for Last Payment
                        ClosedExtensionCountsTableAdapter.Fill(DelinquencyData.ClosedExtensionCounts, lnAgedTest, ldCurrDate);

                        if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
                        {
                            Hide();
                            // Moses Newman 04/26/2022 Covert to XtraReport
                            var report = new XtraReportDelinquency();
                            SqlDataSource ds = report.DataSource as SqlDataSource;


                            ds.Queries[0].Parameters[0].Value = lnAgedTest;
                            ds.Queries[0].Parameters[1].Value = ldCurrDate;
                            ds.Queries[0].Parameters[2].Value = lsSortType;
                            ds.Queries[1].Parameters[0].Value = lnAgedTest;
                            ds.Queries[1].Parameters[1].Value = ldCurrDate;
                            ds.Queries[2].Parameters[0].Value = lnAgedTest;
                            ds.Queries[2].Parameters[1].Value = ldCurrDate;
                            ds.Queries[3].Parameters[0].Value = lnAgedTest;
                            ds.Queries[3].Parameters[1].Value = ldCurrDate;

                            // Moses Newman 05/05/2022
                            GroupHeaderBand StateSortHeader = report.Bands[9] as GroupHeaderBand;
                            GroupFooterBand StateSortFooter = report.Bands[10] as GroupFooterBand;

                            if (!checkEditSortAndGroupDetailByState.Checked)
                            {
                                StateSortHeader.GroupFields.Clear();
                                StateSortHeader.Visible = false;
                                StateSortFooter.Visible = false;
                            }

                            report.DataSource = ds;
                            report.RequestParameters = false;
                            report.Parameters["gsUserID"].Value = Program.gsUserID;
                            report.Parameters["gsUserName"].Value = Program.gsUserName;
                            report.Parameters["gnAgedMonths"].Value = comboBoxAgedPeriod.SelectedIndex + 1;
                            report.Parameters["gdCurrentDate"].Value = ldCurrDate;


                            // Moses Newman 04/17/2022 Now do DealerSummary Sub Report datasource!
                            XRSubreport subReport = report.FindControl("SubreportDelinquencyDealerSummary", true) as XRSubreport;
                            XtraReport reportSource = subReport.ReportSource as XtraReport;
                            SqlDataSource subds = reportSource.DataSource as SqlDataSource;

                            subds.Queries[0].Parameters[0].Value = lnAgedTest;
                            subds.Queries[0].Parameters[1].Value = ldCurrDate;
                            subds.Queries[0].Parameters[2].Value = lsSortType;
                            subds.Queries[1].Parameters[0].Value = lnAgedTest;
                            subds.Queries[1].Parameters[1].Value = ldCurrDate;
                            // Moses Newman 05/05/2022
                            if (!checkEditSortAndGroupDealerByState.Checked)
                            {
                                StateSortHeader = reportSource.Bands[2] as GroupHeaderBand;
                                StateSortFooter = reportSource.Bands[4] as GroupFooterBand;
                                StateSortHeader.GroupFields.Clear();
                                StateSortHeader.Visible = false;
                                StateSortFooter.Visible = false;
                            }

                            reportSource.DataSource = subds;
                            reportSource.RequestParameters = false;
                            reportSource.Parameters["gsUserID"].Value = Program.gsUserID;
                            reportSource.Parameters["gsUserName"].Value = Program.gsUserName;
                            reportSource.Parameters["gnAgedMonths"].Value = comboBoxAgedPeriod.SelectedIndex + 1;
                            reportSource.Parameters["gdCurrentDate"].Value = ldCurrDate;

                            var tool = new ReportPrintTool(report);

                            tool.PreviewRibbonForm.MdiParent = MDImain;
                            tool.AutoShowParametersPanel = false;
                            tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                            tool.ShowRibbonPreview();
                        }
                    }
                    else
                    {
                        /*CUSTOMERTableAdapter.FillByDelinquenciesCOL(DelinquencyData.CUSTOMER, lnAgedTest, ldCurrDate,lsSortType);
                        // Moses Newman 11/19/2013 Moses Newman added ldCurrDate as new parameter to DealerFillByDelinQuencies Query
                        DEALERTableAdapter.FillByDelinquenciesCOL(DelinquencyData.DEALER, lnAgedTest, ldCurrDate);
                        // Moses Newman 09/27/2021 
                        EmailTableAdapter.FillByDelinquencies(DelinquencyData.Email, lnAgedTest, ldCurrDate);

                        if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
                        {
                            Hide();
                            MDImain.CreateFormInstance("ReportViewer", false);
                            ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                            ClosedCustomerDelinquencyCOL myReportObject = new ClosedCustomerDelinquencyCOL();
                            myReportObject.SetDataSource(DelinquencyData);
                            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                            myReportObject.SetParameterValue("gnAgedMonths", comboBoxAgedPeriod.SelectedIndex + 1);
                            myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                            rptViewer.crystalReportViewer.ReportSource = myReportObject;
                            rptViewer.crystalReportViewer.Refresh();
                            rptViewer.Show();
                        }*/
                    }
                    break;
                case 7:
                    if (!checkBoxCollections.Checked)
                    {
                        ClosedDealerAgedSummarySelectTableAdapter.SetCommandTimeout(360);
                        ClosedDealerAgedSummarySelectTableAdapter.Fill(DelinquencyData.ClosedDealerAgedSummarySelect, ldCurrDate);
                        if (DelinquencyData.ClosedDealerAgedSummarySelect.Rows.Count != 0)
                        {
                            Hide();
                            // Moses Newman 03/03/2022 Covert to XtraReport
                            var report = new XtraReportClosedDelinquencySummary();
                            SqlDataSource ds = report.DataSource as SqlDataSource;

                            report.DataSource = ds;
                            report.RequestParameters = false;
                            report.Parameters["gsUserID"].Value = Program.gsUserID;
                            report.Parameters["gsUserName"].Value = Program.gsUserName;
                            report.Parameters["gdThisRun"].Value = ldCurrDate;

                            var tool = new ReportPrintTool(report);

                            tool.PreviewRibbonForm.MdiParent = MDImain;
                            tool.AutoShowParametersPanel = false;
                            tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                            tool.ShowRibbonPreview();
                        }
                    }
                    else // Moses Newman 02/24/2015 Add Collections version of Delinquency Summary Report
                    {
                        /*ClosedDealerAgedSummarySelectTableAdapter.SetCommandTimeout(360);
                        ClosedDealerAgedSummarySelectTableAdapter.Fill(DelinquencyData.ClosedDealerAgedSummarySelect, ldCurrDate);
                        ClosedDealerAgedSummarySelectCOLTableAdapter.Fill(DelinquencyData.ClosedDealerAgedSummarySelectCOL, ldCurrDate);
                        if (DelinquencyData.ClosedDealerAgedSummarySelect.Rows.Count != 0)
                        {
                            Hide();
                            MDImain.CreateFormInstance("ReportViewer", false);
                            ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                            ClosedCustomerDelinquencySummaryCOL myReportObject = new ClosedCustomerDelinquencySummaryCOL();
                            myReportObject.SetDataSource(DelinquencyData);
                            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                            myReportObject.SetParameterValue("gnAgedMonths", comboBoxAgedPeriod.SelectedIndex + 1);
                            myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                            rptViewer.crystalReportViewer.ReportSource = myReportObject;
                            rptViewer.crystalReportViewer.Refresh();
                            rptViewer.Show();
                        }*/
                    }
                    break;
                case 8:
                    /*
                    IACDataSetTableAdapters.RepoCodesTableAdapter RepoCodesTableAdapter = new IACDataSetTableAdapters.RepoCodesTableAdapter();
                    IACDataSetTableAdapters.VEHICLETableAdapter VEHICLETableAdapter = new IACDataSetTableAdapters.VEHICLETableAdapter();
                    CUSTOMERTableAdapter.FillByDelinquenciesCOL(DelinquencyData.CUSTOMER, 9, ldCurrDate);
                    // Moses Newman 11/19/2013 Moses Newman added ldCurrDate as new parameter to DealerFillByDelinQuencies Query
                    DEALERTableAdapter.FillByDelinquenciesCOL(DelinquencyData.DEALER, 9, ldCurrDate);
                    RepoCodesTableAdapter.Fill(DelinquencyData.RepoCodes);
                    VEHICLETableAdapter.FillByRepo(DelinquencyData.VEHICLE);
                    if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
                    {
                        Hide();
                        MDImain.CreateFormInstance("ReportViewer", false);
                        ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                        ClosedCustomerDelinquencyRepoReport myReportObject = new ClosedCustomerDelinquencyRepoReport();
                        myReportObject.SetDataSource(DelinquencyData);
                        myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                        myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                        myReportObject.SetParameterValue("gnAgedMonths", 8);
                        myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                        rptViewer.crystalReportViewer.ReportSource = myReportObject;
                        rptViewer.crystalReportViewer.Refresh();
                        rptViewer.Show();
                    }
                    VEHICLETableAdapter.Dispose();
                    RepoCodesTableAdapter.Dispose();*/
                    break;
            }
            DelinquencyData.Clear();
            DelinquencyData.Dispose();

            CUSTOMERTableAdapter.Dispose();
            DEALERTableAdapter.Dispose();
            ClosedDealerAgedSummarySelectTableAdapter.Dispose();
            ClosedDealerAgedSummarySelectCOLTableAdapter.Dispose();
        }


        private void buttonPost_Click(object sender, EventArgs e)
        {
            PrintDelinquencyReport();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            /* CUSTOMER_DEALER, DEALER.DEALER_NAME, DEALER.DEALER_ST,
               TOTALNOTES, 
		       CUR, 
			   AGED30, 
			   AGED60, 
			   AGED90, 
			   AGED120, 
			   AGED150, 
			   AGED180PLUS,
               TOTALCOUNT,
               CURCOUNT, 
			   AGED30COUNT, 
			   AGED60COUNT, 
			   AGED90COUNT, 
			   AGED120COUNT, 
			   AGED150COUNT, 
			   AGED180PLUSCOUNT */
            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter ClosedDealerAgedSummarySelectTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter();
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.EditValue)).Date;
            ClosedDealerAgedSummarySelectTableAdapter.SetCommandTimeout(360);
            ClosedDealerAgedSummarySelectTableAdapter.Fill(DelinquencyData.ClosedDealerAgedSummarySelect, ldCurrDate);


            if (DelinquencyData.ClosedDealerAgedSummarySelect.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no records selected from the dealer aged summary. ***");
            else
            {
                String lsUNCROOT = Program.GsDataPath,
                        lsNewFileOut = lsUNCROOT + @"AccStuff\mfdata\EXCLDATA\AgedDealerSummary" + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Month.ToString().PadLeft(2, '0') + DateTime.Now.Date.Day.ToString().PadLeft(2, '0') + @".xlsx";
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
                            sheet.Name = "Aged Dealer Summary";

                            // Create the DEALER column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                            }

                            // Create the DEALER NAME column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 250;
                            }

                            // Create the DEALER STATE column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                            }

                            // Create the TOTAL NOTES column and set its width.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            }

                            // Create the CURRENT column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            }

                            // Create the AGED30 column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            }

                            // Create the AGED60 column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            }

                            // Create the AGED90 column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            }

                            // Create the AGED120 column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            }
                            // Create the AGED150 column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            }
                            // Create the AGED180+ column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                            }
                            // Create the CURRENT COUNT column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "####";
                            }

                            // Create the AGED30 COUNT column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "####";
                            }

                            // Create the AGED60 COUNT column and set the specific number format for its cells.
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "####";
                            }

                            // Create the AGED90 COUNT column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "####";
                            }

                            // Create the AGED120 COUNT column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "####";
                            }
                            // Create the AGED150 COUNT column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "####";
                            }
                            // Create the AGED180+ COUNT column and set its width. 
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 100;
                                column.Formatting = new XlCellFormatting();
                                column.Formatting.NumberFormat = "####";
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
                                    cell.Value = "Dealer Number";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Dealer Name";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Dealer State";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Total Notes";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Current";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 30";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 60";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 90";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 120";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 150";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 180+";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Current Count";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 30 Count";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 60 Count";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 90 Count";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 120 Count";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 150 Count";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = "Aged 180+ Count";
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                            }
                            /* CUSTOMER_DEALER, DEALER.DEALER_NAME, DEALER.DEALER_ST,
                               TOTALNOTES, 
                               CUR, 
                               AGED30, 
                               AGED60, 
                               AGED90, 
                               AGED120, 
                               AGED150, 
                               AGED180PLUS,
                               TOTALCOUNT,
                               CURCOUNT, 
                               AGED30COUNT, 
                               AGED60COUNT, 
                               AGED90COUNT, 
                               AGED120COUNT, 
                               AGED150COUNT, 
                               AGED180PLUSCOUNT */

                            // Generate data for the sales report.
                            for (int i = 0; i < DelinquencyData.ClosedDealerAgedSummarySelect.Rows.Count; i++)
                            {
                                using (IXlRow row = sheet.CreateRow())
                                {
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Int32>("CUSTOMER_DEALER");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<String>("DEALER_NAME");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<String>("DEALER_ST");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Decimal>("TOTALNOTES");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Decimal>("CUR");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Decimal>("AGED30");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Decimal>("AGED60");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Decimal>("AGED90");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Decimal>("AGED120");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Decimal>("AGED150");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = (Double)DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Decimal>("AGED180PLUS");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Int32>("CURCOUNT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Int32>("AGED30COUNT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Int32>("AGED60COUNT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Int32>("AGED90COUNT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Int32>("AGED120COUNT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Int32>("AGED150COUNT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                    using (IXlCell cell = row.CreateCell())
                                    {
                                        cell.Value = DelinquencyData.ClosedDealerAgedSummarySelect.Rows[i].Field<Int32>("AGED180PLUSCOUNT");
                                        cell.ApplyFormatting(cellFormatting);
                                    }
                                }
                            }
                            // Create an instance of the XlConditionalFormatting class.
                            XlConditionalFormatting formatting = new XlConditionalFormatting();

                            formatting.Ranges.Add(XlCellRange.FromLTRB(0, 0, 17, DelinquencyData.ClosedDealerAgedSummarySelect.Rows.Count));

                            //XlCondFmtRuleCellIs rule = new XlCondFmtRuleCellIs();
                            XlCondFmtRuleExpression rule = new XlCondFmtRuleExpression("=MOD(ROW(),2) = 0");
                            rule.Formatting = XlFill.SolidFill(Color.Bisque);
                            formatting.Rules.Add(rule);
                            sheet.ConditionalFormattings.Add(formatting);
                            // Enable AutoFilter for the created cell range.
                            sheet.AutoFilterRange = sheet.DataRange;
                        }
                    }
                }
                // Open the XLSX document using the default application.
                System.Diagnostics.Process.Start(lsNewFileOut);
            }
        }
    }
}

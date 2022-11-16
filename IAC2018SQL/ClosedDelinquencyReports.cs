using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;


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
            Int32   lnAgedTest = comboBoxAgedPeriod.SelectedIndex + 1;

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
                        CUSTOMERTableAdapter.FillByDelinquencies(DelinquencyData.CUSTOMER, lnAgedTest, ldCurrDate,lsSortType);
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

    }
}

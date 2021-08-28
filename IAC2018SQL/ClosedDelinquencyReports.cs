using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class frmClosedDelinquencyReports : Form
    {
        public frmClosedDelinquencyReports()
        {
            InitializeComponent();
        }

        private void frmClosedDelinquencyReports_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            comboBoxAgedPeriod.SelectedIndex = 0;
            nullableDateTimePickerDueDate.Value = DateTime.Now.Date;
            comboBoxSortType.SelectedIndex = 0;
        }

        private void PrintDelinquencyReport()
        {
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.Value)).Date; 

            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter ClosedDealerAgedSummarySelectTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectCOLTableAdapter ClosedDealerAgedSummarySelectCOLTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectCOLTableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
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

                        if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
                        {
                            Hide();
                            MDImain.CreateFormInstance("ReportViewer", false);
                            ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                            ClosedCustomerDelinquency myReportObject = new ClosedCustomerDelinquency();
                            myReportObject.SetDataSource(DelinquencyData);
                            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                            myReportObject.SetParameterValue("gnAgedMonths", comboBoxAgedPeriod.SelectedIndex + 1);
                            myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                            rptViewer.crystalReportViewer.ReportSource = myReportObject;
                            rptViewer.crystalReportViewer.Refresh();
                            rptViewer.Show();
                        }
                    }
                    else
                    {
                        CUSTOMERTableAdapter.FillByDelinquenciesCOL(DelinquencyData.CUSTOMER, lnAgedTest, ldCurrDate,lsSortType);
                        // Moses Newman 11/19/2013 Moses Newman added ldCurrDate as new parameter to DealerFillByDelinQuencies Query
                        DEALERTableAdapter.FillByDelinquenciesCOL(DelinquencyData.DEALER, lnAgedTest, ldCurrDate);
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
                        }
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
                            MDImain.CreateFormInstance("ReportViewer", false);
                            ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                            ClosedCustomerDelinquencySummary myReportObject = new ClosedCustomerDelinquencySummary();
                            myReportObject.SetDataSource(DelinquencyData);
                            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                            myReportObject.SetParameterValue("gnAgedMonths", comboBoxAgedPeriod.SelectedIndex + 1);
                            myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                            rptViewer.crystalReportViewer.ReportSource = myReportObject;
                            rptViewer.crystalReportViewer.Refresh();
                            rptViewer.Show();
                        }
                    }
                    else // Moses Newman 02/24/2015 Add Collections version of Delinquency Summary Report
                    {
                        ClosedDealerAgedSummarySelectTableAdapter.SetCommandTimeout(360);
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
                        }

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

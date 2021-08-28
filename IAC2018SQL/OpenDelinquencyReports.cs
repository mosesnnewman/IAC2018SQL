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
    public partial class frmOpenDelinquencyReports : Form
    {

        public frmOpenDelinquencyReports()
        {
            InitializeComponent();
        }

        private void frmOpenDelinquencyReports_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            comboBoxAgedPeriod.SelectedIndex = 0;
            nullableDateTimePickerDueDate.Value = DateTime.Now.Date;
        }

        private void PrintDelinquencyReport()
        {
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.Value)).Date;

            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.OpenDealerAgedSummarySelectTableAdapter OpenDealerAgedSummarySelectTableAdapter = new IACDataSetTableAdapters.OpenDealerAgedSummarySelectTableAdapter();
            IACDataSetTableAdapters.OPNCUSTTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();

            Int32 lnAgedTest = comboBoxAgedPeriod.SelectedIndex + 1;
                
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            switch (lnAgedTest)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:


                    CUSTOMERTableAdapter.FillByDelinqencies(DelinquencyData.OPNCUST, lnAgedTest, ldCurrDate);
                    // Moses Newman 11/19/2013 Moses Newman added ldCurrDate as new parameter to DealerFillByDelinQuencies Query
                    DEALERTableAdapter.FillByDelinquencies(DelinquencyData.OPNDEALR, lnAgedTest, ldCurrDate);

                    if (DelinquencyData.OPNCUST.Rows.Count != 0 && DelinquencyData.OPNDEALR.Rows.Count != 0)
                    {
                        Hide();
                        MDImain.CreateFormInstance("ReportViewer", false);
                        ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                        OpenCustomerDelinquency myReportObject = new OpenCustomerDelinquency();
                        myReportObject.SetDataSource(DelinquencyData);
                        myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                        myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                        myReportObject.SetParameterValue("gnAgedMonths", comboBoxAgedPeriod.SelectedIndex + 1);
                        myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                        rptViewer.crystalReportViewer.ReportSource = myReportObject;
                        rptViewer.crystalReportViewer.Refresh();
                        rptViewer.Show();
                    }
                    else
                            // Moses Newman 09/30/2015 Give error message if no records foound!
                            MessageBox.Show("*** No Records Found  for :" + comboBoxAgedPeriod.SelectedItem,"No RECORDS");
                    break;
                case 7:
                    OpenDealerAgedSummarySelectTableAdapter.Fill(DelinquencyData.OpenDealerAgedSummarySelect, ldCurrDate);
                    if (DelinquencyData.OpenDealerAgedSummarySelect.Rows.Count != 0)
                    {
                        Hide();
                        MDImain.CreateFormInstance("ReportViewer", false);
                        ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                        OpenCustomerDelinquencySummary myReportObject = new OpenCustomerDelinquencySummary();
                        myReportObject.SetDataSource(DelinquencyData);
                        myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                        myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                        myReportObject.SetParameterValue("gnAgedMonths", comboBoxAgedPeriod.SelectedIndex + 1);
                        myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                        rptViewer.crystalReportViewer.ReportSource = myReportObject;
                        rptViewer.crystalReportViewer.Refresh();
                        rptViewer.Show();
                    }
                    break;
            }
            DelinquencyData.Clear();
            DelinquencyData.Dispose();
            CUSTOMERTableAdapter.Dispose();
            DEALERTableAdapter.Dispose();
            OpenDealerAgedSummarySelectTableAdapter.Dispose();
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

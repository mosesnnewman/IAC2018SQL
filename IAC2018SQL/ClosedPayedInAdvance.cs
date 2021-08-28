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
    public partial class frmClosedPayedInAdvanceReport : Form
    {

        public frmClosedPayedInAdvanceReport()
        {
            InitializeComponent();
        }

        private void frmClosedPayedInAdvanceReport_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            nullableDateTimePickerDueDate.Value = DateTime.Now.Date;
        }

        private void PrintDelinquencyReport()
        {
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.Value)).Date;

            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter ClosedDealerAgedSummarySelectTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectTableAdapter();
            IACDataSetTableAdapters.ClosedDealerAgedSummarySelectCOLTableAdapter ClosedDealerAgedSummarySelectCOLTableAdapter = new IACDataSetTableAdapters.ClosedDealerAgedSummarySelectCOLTableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();

            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;


            CUSTOMERTableAdapter.FillByPaidInAdvance(DelinquencyData.CUSTOMER, ldCurrDate);
            
            DEALERTableAdapter.FillByPaidInAdvance(DelinquencyData.DEALER, ldCurrDate);

            if (DelinquencyData.CUSTOMER.Rows.Count != 0 && DelinquencyData.DEALER.Rows.Count != 0)
            {
                Hide();
                MDImain.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                ClosedPaidInAdvance myReportObject = new ClosedPaidInAdvance();
                myReportObject.SetDataSource(DelinquencyData);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject.SetParameterValue("gdCurrentDate", ldCurrDate);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
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

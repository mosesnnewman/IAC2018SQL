using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class frmOpenCustomerFinanceChargeReport : Form
    {

        public frmOpenCustomerFinanceChargeReport()
        {
            InitializeComponent();
        }

        private void frmOpenCustomerFinanceChargeReport_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintFinanceReport(rptViewr);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintFinanceReport(ReportViewer rptViewer)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter StatementCustomerHeaderTableAdapter = new IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter();
            IACDataSetTableAdapters.StatementDealerSummaryTableAdapter StatementDealerSummaryTableAdapter = new IACDataSetTableAdapters.StatementDealerSummaryTableAdapter();

            OPNCUSTTableAdapter.CustomizeFill("SELECT * FROM OPNCUST WHERE CUSTOMER_ACT_STAT <> \'I\' AND CUSTOMER_DAY_DUE = " + ((DateTime)StatementDatenullableDateTimePicker.Value).Day.ToString().TrimStart().TrimEnd() + " ORDER BY CUSTOMER_DEALER,CUSTOMER_NO");
            OPNCUSTTableAdapter.CustomFillBy(ReportData.OPNCUST);
            StatementCustomerHeaderTableAdapter.FillByDueDate(ReportData.StatementCustomerHeader, ((DateTime)StatementDatenullableDateTimePicker.Value).Date,false,false);
            StatementDealerSummaryTableAdapter.FillByDueDate(ReportData.StatementDealerSummary, ((DateTime)StatementDatenullableDateTimePicker.Value).Date);
            if (ReportData.StatementCustomerHeader.Rows.Count == 0 || ReportData.OPNCUST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no statements for the DUE DATE you entered!!! ***");
            else
            {
                OPNDEALRTableAdapter.CustomizeFill("SELECT * FROM OPNDEALR");
                OPNDEALRTableAdapter.CustomFillBy(ReportData.OPNDEALR);

                FinanceReport myReportObject = new FinanceReport();
                myReportObject.SetDataSource(ReportData);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                myReportObject.SetParameterValue("gsFormTitle", "Open Customer Finance Charge Report");
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
        }
    }
}

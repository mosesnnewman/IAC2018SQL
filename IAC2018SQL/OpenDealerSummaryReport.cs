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
    public partial class frmOpenDealerSummaryReport : Form
    {

        public frmOpenDealerSummaryReport()
        {
            InitializeComponent();
        }

        private void frmOpenDealerSummaryReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            monthNamesTableAdapter.Fill(iACDataSet.MonthNames);
            monthNamesBindingSource.DataSource = iACDataSet.MonthNames;
            monthNamesBindingSource.MoveFirst();
            monthNamesBindingSource.Position = monthNamesBindingSource.Find("MonthNumber", lnRunMonth);
            textBoxRunYear.Text = lnRunYear.ToString();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintDealerSummary(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintDealerSummary(ReportViewer rptViewer)
        {
            DateTime ldRunDate;
            String lsRunDate = "";
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OpenDealerSummaryTableAdapter OpenDealerSummaryTableAdapter = new IACDataSetTableAdapters.OpenDealerSummaryTableAdapter();


            lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/31/" + textBoxRunYear.Text;
            DateTime.TryParse(lsRunDate,out ldRunDate);
            if (ldRunDate == DateTime.MinValue)
            {
                lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/30/" + textBoxRunYear.Text;
                DateTime.TryParse(lsRunDate, out ldRunDate);
                if (ldRunDate == DateTime.MinValue)
                {
                    lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/28/" + textBoxRunYear.Text;
                    DateTime.TryParse(lsRunDate, out ldRunDate);
                    if (ldRunDate == DateTime.MinValue)
                    {
                        lsRunDate = comboBoxRunMonth.SelectedValue.ToString() + "/27/" + textBoxRunYear.Text;   // Must be a leap year with February run date
                        DateTime.TryParse(lsRunDate, out ldRunDate);
                    }
                }
            }

            OpenDealerSummaryTableAdapter.Fill(ReportData.OpenDealerSummary, ldRunDate.Month, ldRunDate.Year);

            if (ReportData.OpenDealerSummary.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no OPNHDEAL records for the RUN MONTH AND YEAR you entered!!! ***");
            else
            {
                OpenDealerSummary myReportObject = new OpenDealerSummary();
                myReportObject.SetDataSource(ReportData);
                myReportObject.SetParameterValue("gdCutOffDate", ldRunDate);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
        }
    }
}

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
    public partial class frmMasterHistoryReport : Form
    {

        public frmMasterHistoryReport()
        {
            InitializeComponent();
        }

        private void frmMasterHistoryReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.Value = DateTime.Now.Date;
            nullableDateTimePickerEndDate.Value = DateTime.Now.Date;
            masterlistTableAdapter.Fill(iACDataSet.MASTERLIST);
            bindingSourceMasterList.AddNew();
            bindingSourceMasterList.EndEdit();
            iACDataSet.MASTERLIST.Rows[bindingSourceMasterList.Position].SetField<String>("MASTER_ACC_NO", "   ");
            iACDataSet.MASTERLIST.Rows[bindingSourceMasterList.Position].SetField<String>("MASTER_NAME", "                  ");
            bindingSourceMasterList.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintMasterHistory(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintMasterHistory(ReportViewer rptViewer)
        {
            String lsAccountNum = comboBoxAccount.Text.TrimEnd().TrimStart() + "%";

            masthistTableAdapter.FillByMasterDateRange(iACDataSet.MASTHIST, lsAccountNum, (DateTime)nullableDateTimePickerStartDate.Value, (DateTime)nullableDateTimePickerEndDate.Value);
            masterTableAdapter.CustomizeFill(@"SELECT * FROM MASTER WHERE MASTER_ACC_NO IN (SELECT MASTHIST_ACC_NO FROM MASTHIST WHERE MASTHIST_POST_DATE >= '" +
                                                ((DateTime)nullableDateTimePickerStartDate.Value).Year.ToString() + "-" +
                                                ((DateTime)nullableDateTimePickerStartDate.Value).Month.ToString() + "-" +
                                                ((DateTime)nullableDateTimePickerStartDate.Value).Day.ToString() + @"' AND MASTHIST_POST_DATE <= '" +
                                                ((DateTime)nullableDateTimePickerEndDate.Value).Year.ToString() + "-" +
                                                ((DateTime)nullableDateTimePickerEndDate.Value).Month.ToString() + "-" +
                                                ((DateTime)nullableDateTimePickerEndDate.Value).Day.ToString() + @"' AND MASTHIST_ACC_NO LIKE '" + lsAccountNum + @"')");
            masterTableAdapter.CustomFillBy(iACDataSet.MASTER);
            if (iACDataSet.MASTHIST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no MASTHIST records for the DATES and /or ACCOUNT you selected!!! ***");
            else
            {
                MasterHistory myReportObject = new MasterHistory();
                myReportObject.SetDataSource(iACDataSet);
                myReportObject.SetParameterValue("gdFromDate", (DateTime)nullableDateTimePickerStartDate.Value);
                myReportObject.SetParameterValue("gdToDate", (DateTime)nullableDateTimePickerEndDate.Value);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
        }
    }
}

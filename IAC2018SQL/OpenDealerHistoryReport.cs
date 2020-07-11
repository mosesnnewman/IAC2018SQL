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
    public partial class frmOpenDealerHistoryReport : Form
    {

        public frmOpenDealerHistoryReport()
        {
            InitializeComponent();
        }

        private void frmOpenDealerHistoryReport_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.Value = DateTime.Now.Date;
            nullableDateTimePickerEndDate.Value = DateTime.Now.Date;
            opndlrlistbynumTableAdapter.Fill(iACDataSet.OPNDLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.OPNDLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("OPNDEALR_ACC_NO", "   ");
            iACDataSet.OPNDLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("OPNDEALR_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintDealerHistory(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintDealerHistory(ReportViewer rptViewer)
        {
            String lsDealerNum = comboBoxDealer.Text.TrimEnd().TrimStart() + "%";

            opnhdealTableAdapter.FillByDealerDateRange(iACDataSet.OPNHDEAL, lsDealerNum, (DateTime)nullableDateTimePickerStartDate.Value, (DateTime)nullableDateTimePickerEndDate.Value);
            opndealrTableAdapter.CustomizeFill(@"SELECT * FROM OPNDEALR WHERE OPNDEALR_ACC_NO IN (SELECT DEALHIST_ACC_NO FROM OPNHDEAL WHERE DEALHIST_POST_DATE >= '" +
                                                ((DateTime)nullableDateTimePickerStartDate.Value).Year.ToString() + "-" +
                                                ((DateTime)nullableDateTimePickerStartDate.Value).Month.ToString() + "-" +
                                                ((DateTime)nullableDateTimePickerStartDate.Value).Day.ToString() + @"' AND DEALHIST_POST_DATE <= '" +
                                                ((DateTime)nullableDateTimePickerEndDate.Value).Year.ToString() + "-" +
                                                ((DateTime)nullableDateTimePickerEndDate.Value).Month.ToString() + "-" +
                                                ((DateTime)nullableDateTimePickerEndDate.Value).Day.ToString() + @"' AND DEALHIST_ACC_NO LIKE '" + lsDealerNum + @"')");
            opndealrTableAdapter.CustomFillBy(iACDataSet.OPNDEALR);
            if (iACDataSet.OPNHDEAL.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no OPNHDEAL records for the DATES and/or DEALER you selected!!! ***");
            else
            {
                OpenDealerHistory myReportObject = new OpenDealerHistory();
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

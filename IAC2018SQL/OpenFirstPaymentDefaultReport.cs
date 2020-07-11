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
    public partial class frmOpenFirstPaymentDefaultReport : Form
    {
        public frmOpenFirstPaymentDefaultReport()
        {
            InitializeComponent();
        }

        private void frmOpenFirstPaymentDefaultReport_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
            nullableDateTimePickerDueDate.Value = DateTime.Now.Date;
        }

        private void PrintDelinquencyReport()
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            DateTime ldCurrDate = ((DateTime)(nullableDateTimePickerDueDate.Value)).Date;

            IACDataSet DelinquencyData = new IACDataSet();
            IACDataSetTableAdapters.OPNCUSTTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();


            CUSTOMERTableAdapter.FillByFirstPaymentDefault(DelinquencyData.OPNCUST, ldCurrDate);
            DEALERTableAdapter.FillByFirstPaymentDefault(DelinquencyData.OPNDEALR, ldCurrDate);

            if (DelinquencyData.OPNCUST.Rows.Count != 0 && DelinquencyData.OPNDEALR.Rows.Count != 0)
            {
                Hide();
                MDImain.CreateFormInstance("ReportViewer", false);
                ReportViewer rptViewer = (ReportViewer)MDImain.ActiveMdiChild;

                OpenFirstPaymentDefault myReportObject = new OpenFirstPaymentDefault();
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

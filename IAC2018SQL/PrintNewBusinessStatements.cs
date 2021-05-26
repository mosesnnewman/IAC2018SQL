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
    public partial class frmPrintNewBusinessStatements : Form
    {

        public frmPrintNewBusinessStatements()
        {
            InitializeComponent();
        }

        private void frmPrintNewBusinessStatements_Load(object sender, EventArgs e)
        {
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintStatements(rptViewr);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrintStatements(ReportViewer rptViewer)
        {
            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNRATETableAdapter OPNRATETableAdapter = new IACDataSetTableAdapters.OPNRATETableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTYPETableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter StatementCustomerHeaderTableAdapter = new IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter();

            BindingSource OPNCUSTBindingSource = new BindingSource();
            BindingSource PAYMENTTypeBindingSource = new BindingSource();
            BindingSource OPNHCUSTBindingSource = new BindingSource();

            OPNCUSTBindingSource.DataSource = ReportData.OPNCUST;
            OPNHCUSTBindingSource.DataSource = ReportData.OPNHCUST;
            PAYMENTTypeBindingSource.DataSource = ReportData.PAYMENTTYPE;

            // Moses Newman 04/07/2020 Get rid of CustomQuery
            OPNCUSTTableAdapter.FillByNewBusiness(ReportData.OPNCUST);
            StatementCustomerHeaderTableAdapter.FillByNewBusiness(ReportData.StatementCustomerHeader);
            if (ReportData.StatementCustomerHeader.Rows.Count == 0 || ReportData.OPNCUST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no New Business statements!!! ***");
            else
            {
                // Moses Newman 04/07/2020 Get rid of CustomQuery
                OPNHCUSTTableAdapter.FillByNewBusiness(ReportData.OPNHCUST);
                OPNDEALRTableAdapter.CustomizeFill(@"SELECT * FROM OPNDEALR WHERE OPNDEALR_ACC_NO IN (SELECT CUSTOMER_DEALER FROM OPNCUST WHERE CUSTOMER_PAY_REM_1 = 'NEW')");
                OPNDEALRTableAdapter.CustomFillBy(ReportData.OPNDEALR);
                OPNRATETableAdapter.FillAll(ReportData.OPNRATE);
                PAYMENTTYPETableAdapter.Fill(ReportData.PAYMENTTYPE);
                /*PAYMENTTypeBindingSource.AddNew(); // Moses Newman 05/26/2021 Already have a blank row now!
                PAYMENTTypeBindingSource.EndEdit();
                ReportData.PAYMENTTYPE.Rows[PAYMENTTypeBindingSource.Position].SetField<String>("Type", " ");
                PAYMENTTypeBindingSource.EndEdit();
                ReportData.PAYMENTTYPE.AcceptChanges();*/

                DataRow  CustFound = null;
                Object[] Key = null;

                Key = new Object[4];

                for (Int32 i = 0; i < ReportData.OPNCUST.Rows.Count; i++)
                {
                    Key[0] = ReportData.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO");
                    Key[1] = ReportData.OPNCUST.Rows[i].Field<DateTime>("CUSTOMER_INIT_DATE");
                    Key[2] = true;
                    Key[3] = false;

                    CustFound = ReportData.StatementCustomerHeader.Rows.Find(Key);
                    if (CustFound == null)
                    {
                        OPNCUSTBindingSource.Position = i;
                        OPNCUSTBindingSource.RemoveCurrent();
                        ReportData.OPNCUST.AcceptChanges();
                    }
                }
                Statement myReportObject = new Statement();
                myReportObject.SetDataSource(ReportData);
                DailyDataSet Daily = new DailyDataSet();  // Moses Newman 05/25/2021
                DailyDataSetTableAdapters.OpenCustomerHistoryLateChargeTableAdapter LateCharge = new DailyDataSetTableAdapters.OpenCustomerHistoryLateChargeTableAdapter();
                
                //LateCharge.Fill(Daily.OpenCustomerHistoryLateCharge, DateTime.Now.Date.AddMonths(-1), DateTime.Now.Date);
                // Moses Newman 05/25/2021
                myReportObject.Database.Tables[6].SetDataSource(Daily);

                myReportObject.SetParameterValue("gsMessage", "**** T H I S  I S  N O T  A  B I L L ****");
                myReportObject.SetParameterValue("gdEntryDate", DateTime.Now.Date);
                myReportObject.SetParameterValue("gdClosingDate", DateTime.Now.Date);
                myReportObject.SetParameterValue("gbNewAdd", true);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
            PAYMENTTypeBindingSource.Dispose();
            OPNHCUSTBindingSource.Dispose();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class frmReprintStatements : DevExpress.XtraEditors.XtraForm
    {

        public frmReprintStatements()
        {
            InitializeComponent();
        }

        private void frmReprintStatements_Load(object sender, EventArgs e)
        {
            Object loDueDate = null;


            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter StatementCustomerHeaderTableAdapter = new IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter();
            loDueDate = StatementCustomerHeaderTableAdapter.LastDueDate();
            if (loDueDate != null)
            {
                StatementDatenullableDateTimePicker.EditValue = (DateTime)loDueDate;
                StatementDatenullableDateTimePicker.Text = ((DateTime)loDueDate).ToShortDateString();
            }
            StatementCustomerHeaderTableAdapter.Dispose();
            ReportData.Dispose();
            textBoxMessage.Text = "MAKE PAYMENTS ONLINE @ IACCREDIT.COM";
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
            DailyDataSet Daily = new DailyDataSet();  // Moses Newman 04/12/2021
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNRATETableAdapter OPNRATETableAdapter = new IACDataSetTableAdapters.OPNRATETableAdapter();
            IACDataSetTableAdapters.PAYMENTTYPETableAdapter PAYMENTTYPETableAdapter = new IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter StatementCustomerHeaderTableAdapter = new IACDataSetTableAdapters.StatementCustomerHeaderTableAdapter();
            DailyDataSetTableAdapters.OpenCustomerHistoryLateChargeTableAdapter LateCharge = new DailyDataSetTableAdapters.OpenCustomerHistoryLateChargeTableAdapter();
            BindingSource PAYMENTTypeBindingSource = new BindingSource();
            BindingSource OPNHCUSTBindingSource = new BindingSource();

            DateTime ldClosingDate, ldLastClosingDate;

            OPNHCUSTBindingSource.DataSource = ReportData.OPNHCUST;
            PAYMENTTypeBindingSource.DataSource = ReportData.PAYMENTTYPE;
            // Moses Newman 03/16/2012 Added test to make sure not UNPOSTED NEW BUSINESS!
            OPNCUSTTableAdapter.CustomizeFill(@"SELECT * FROM OPNCUST WHERE CUSTOMER_ACT_STAT = 'A' AND CUSTOMER_POST_IND <> CHAR(255) AND CUSTOMER_DAY_DUE = " + StatementDatenullableDateTimePicker.DateTime.Day.ToString().TrimStart().TrimEnd());
            OPNCUSTTableAdapter.CustomFillBy(ReportData.OPNCUST);
            StatementCustomerHeaderTableAdapter.FillByDueDate(ReportData.StatementCustomerHeader, StatementDatenullableDateTimePicker.DateTime.Date, false, false);
            if (ReportData.StatementCustomerHeader.Rows.Count == 0 || ReportData.OPNCUST.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no statements for the DUE DATE you entered!!! ***");
            else
            {
                ldClosingDate = ReportData.StatementCustomerHeader.Rows[0].Field<DateTime>("ClosingDate");
                ldLastClosingDate = ReportData.StatementCustomerHeader.Rows[0].Field<DateTime>("LastClosingDate");
                OPNHCUSTTableAdapter.FillByDateRange(ReportData.OPNHCUST, ldLastClosingDate, ldClosingDate);
                // Moses Newman 03/16/2012 Added test to make sure not UNPOSTED NEW BUSINESS!
                OPNDEALRTableAdapter.CustomizeFill(@"SELECT * FROM OPNDEALR WHERE OPNDEALR_ACC_NO IN (SELECT CUSTOMER_DEALER FROM OPNCUST WHERE CUSTOMER_ACT_STAT = 'A' AND CUSTOMER_POST_IND <> CHAR(255) AND CUSTOMER_DAY_DUE = " + StatementDatenullableDateTimePicker.DateTime.Day.ToString().TrimStart().TrimEnd() + ")");
                OPNDEALRTableAdapter.CustomFillBy(ReportData.OPNDEALR);
                OPNRATETableAdapter.FillAll(ReportData.OPNRATE);
                PAYMENTTYPETableAdapter.Fill(ReportData.PAYMENTTYPE);
                /*PAYMENTTypeBindingSource.AddNew(); // Moses Newman 05/26/2021 Already have a blank row now!
                PAYMENTTypeBindingSource.EndEdit();
                ReportData.PAYMENTTYPE.Rows[PAYMENTTypeBindingSource.Position].SetField<String>("Type", " ");
                ReportData.PAYMENTTYPE.Rows[PAYMENTTypeBindingSource.Position].SetField<String>("DESCRIPTION", "                     ");
                PAYMENTTypeBindingSource.EndEdit();
                ReportData.PAYMENTTYPE.AcceptChanges();*/

                // Statement report requires detail or no print, so create dummy history for customers with NO activity in this statement period.
                for (Int32 i = 0; i < ReportData.OPNCUST.Rows.Count; i++)
                {
                    if (OPNHCUSTBindingSource.Find("CUSTHIST_NO", ReportData.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO")) < 0)
                    {
                        OPNHCUSTBindingSource.AddNew();
                        OPNHCUSTBindingSource.EndEdit();
                        ReportData.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_NO", ReportData.OPNCUST.Rows[i].Field<String>("CUSTOMER_NO"));
                        ReportData.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", ldClosingDate);
                        ReportData.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", 1);
                        ReportData.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_TYPE", " ");
                        OPNHCUSTBindingSource.EndEdit();
                    }
                }
                ReportData.OPNHCUST.AcceptChanges();
                Statement myReportObject = new Statement();
                myReportObject.SetDataSource(ReportData);
                LateCharge.Fill(Daily.OpenCustomerHistoryLateCharge, ldLastClosingDate, ldClosingDate);
                // Moses Newman 04/12/2021
                myReportObject.Database.Tables[6].SetDataSource(Daily);
                // Moses Newman 04/07/2021 Fill new start and end command prameters
                //myReportObject.SetParameterValue("Start", ldLastClosingDate);
                //myReportObject.SetParameterValue("End", ldClosingDate);
                myReportObject.SetParameterValue("gsMessage", textBoxMessage.Text.Trim());
                myReportObject.SetParameterValue("gdEntryDate", StatementDatenullableDateTimePicker.DateTime);
                myReportObject.SetParameterValue("gdClosingDate", ldClosingDate);
                myReportObject.SetParameterValue("gbNewAdd", false);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
            PAYMENTTypeBindingSource.Dispose();
            OPNHCUSTBindingSource.Dispose();
        }

        private void textBoxMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void StatementDatenullableDateTimePicker_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}

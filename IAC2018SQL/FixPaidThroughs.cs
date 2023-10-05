using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class FixPaidThroughs : Form
    {
        public FixPaidThroughs()
        {
            InitializeComponent();
        }

        private void buttonDoIt_Click(object sender, EventArgs e)
        {
            ClosedPaymentPosting CP = new ClosedPaymentPosting();
            BackgroundWorker BW = new BackgroundWorker();
            Decimal lnSimpBal = 0;
            DateTime ldDate = DateTime.Now.Date;


            IACDataSet DT = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();

            //CUSTOMERTableAdapter.Fill(DT.CUSTOMER, cUSTOMER_NOTextBox.Text.Trim());
            CUSTOMERTableAdapter.FillByAllPosted(DT.CUSTOMER);
            label1.Text = "Fixing Paid Throughs, Number of Payments, Statuses etc.";
            label1.Refresh();
            for (int i = 0; i < DT.CUSTOMER.Rows.Count; i++)
            {
                if (DT.CUSTOMER.Rows[i].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE") != null)
                    ldDate = DT.CUSTOMER.Rows[i].Field<DateTime>("CUSTOMER_LAST_PAYMENT_DATE");
                else
                    ldDate = DateTime.Now.Date;
                label1.Text = "CREATING AMORT TABLES WORKING ON: CUSTOMER NUMBER: " + DT.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO") + " " + (i + 1).ToString() + " OF " + DT.CUSTOMER.Rows.Count.ToString();
                label1.Refresh();
   
                lnSimpBal = Program.TVSimpleGetBuyout(DT, ldDate,
                  (Double)DT.CUSTOMER.Rows[i].Field<Int32>("CUSTOMER_TERM"),
                  (Double)(DT.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                  (Double)DT.CUSTOMER.Rows[i].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                  DT.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"),
                    // 04/30/2017 Handle BOTH Simple Interest and Normal Daily Compounding
                  DT.CUSTOMER.Rows[i].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, true, false, false, -1, true);
                CP.NewGetPartialPaymentandLateFeeBalance(DT.CUSTOMER.Rows[i].Field<String>("CUSTOMER_NO"), ref DT, i, false, -1, true, true);
            }
            label1.Text = "*** DONE! ***";
            label1.Refresh();
        }

        private void cUSTOMER_NOTextBox_Validated(object sender, EventArgs e)
        {
            string lsCustomerNo;
            if (cUSTOMER_NOTextBox.Text.ToString().Trim().Length < 6 && cUSTOMER_NOTextBox.Text.ToString().Trim().Length > 0)
                cUSTOMER_NOTextBox.Text = cUSTOMER_NOTextBox.Text.Trim().PadLeft(6, '0');
            lsCustomerNo = cUSTOMER_NOTextBox.Text.ToString().Trim();
            if (lsCustomerNo == "")  // Moses Newman 03/02/2012 previously only returned if in Add Mode!!!
                return;
        }
    }
}

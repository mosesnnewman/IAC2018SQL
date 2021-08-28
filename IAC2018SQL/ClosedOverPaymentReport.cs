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
    public partial class ClosedOverPaymentReport : Form
    {
        public ClosedOverPaymentReport()
        {
            InitializeComponent();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            PaymentDataSetTableAdapters.ClosedOverPaymentsTableAdapter ClosedOverPaymentsTableAdapter = new PaymentDataSetTableAdapters.ClosedOverPaymentsTableAdapter();
            ClosedOverPaymentsTableAdapter.CreateOverPayments(((DateTime)(nullableDateTimePickerFrom.Value)).Date, ((DateTime)(nullableDateTimePickerTo.Value)).Date);
            ClosedOverpayment OP = new ClosedOverpayment();
            OP.CreateIt();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClosedOverPaymentReport_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerFrom.Value = DateTime.Parse("01/01/1980");
            nullableDateTimePickerTo.Value = DateTime.Now.Date;
        }
    }
}

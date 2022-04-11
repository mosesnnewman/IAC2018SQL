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
    public partial class ClosedOverPaymentReport : DevExpress.XtraEditors.XtraForm
    {
        public ClosedOverPaymentReport()
        {
            InitializeComponent();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            PaymentDataSetTableAdapters.ClosedOverPaymentsTableAdapter ClosedOverPaymentsTableAdapter = new PaymentDataSetTableAdapters.ClosedOverPaymentsTableAdapter();
            ClosedOverPaymentsTableAdapter.CreateOverPayments(((DateTime)(nullableDateTimePickerFrom.EditValue)).Date, ((DateTime)(nullableDateTimePickerTo.EditValue)).Date);
            ClosedOverpayment OP = new ClosedOverpayment();
            OP.CreateIt();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClosedOverPaymentReport_Load(object sender, EventArgs e)
        {
            nullableDateTimePickerFrom.EditValue = DateTime.Parse("01/01/1980");
            nullableDateTimePickerTo.EditValue = DateTime.Now.Date;
        }
    }
}

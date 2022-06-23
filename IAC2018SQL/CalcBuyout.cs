using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class CalcBuyout : DevExpress.XtraEditors.XtraForm
    {
        private IACDataSet _DataSet;

        public IACDataSet gdsDataSet
        {
            get { return _DataSet; }
            set { _DataSet = value; }
        }

        public CalcBuyout()
        {
            InitializeComponent();
        }

        private void buttonCalcBuyout_Click(object sender, EventArgs e)
        {
            // Moses Newman 04/30/2017  Handle Simple Interest Flag Properly
            textBoxBuyout.Text = "";
            textBoxBuyout.Text = "CALCULATING...".ToString(new CultureInfo("en-US"));
            textBoxBuyout.Text =
            Program.TVSimpleGetBuyout(_DataSet,
                    (DateTime)nullableDateTimePicker1.EditValue,
                    (Double)_DataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM"),
                    (Double)(_DataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                    (Double)_DataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                    _DataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"),
                    _DataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true:false, true, false).ToString("C", new CultureInfo("en-US"));
        }

        private void CalcBuyout_Load(object sender, EventArgs e)
        {
            nullableDateTimePicker1.EditValue = DateTime.Now.Date;
        }
    }
}

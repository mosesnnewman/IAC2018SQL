using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace IAC2018SQL
{
    public partial class frmRecalcBuyout : Form
    {
        public frmRecalcBuyout()
        {
            InitializeComponent();
        }

        private void buttonRecalc_Click(object sender, EventArgs e)
        {
            IACDataSet RecalcData = new IACDataSet();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();

            BindingSource CustomerBindingSource = new BindingSource();

            Object loLastBalance = null;
            Decimal lnBalance = 0;
            CUSTOMERTableAdapter.FillByAll(RecalcData.CUSTOMER);

            CustomerBindingSource.DataSource = RecalcData.CUSTOMER;
            CustomerBindingSource.MoveFirst();

            for (Int32 i=0; i < CustomerBindingSource.Count; i++)
            {
                labelDisplay.Text = "Customer #: " + RecalcData.CUSTOMER.Rows[CustomerBindingSource.Position].Field<String>("CUSTOMER_NO");

                loLastBalance = CUSTHISTTableAdapter.LastBalance(RecalcData.CUSTOMER.Rows[CustomerBindingSource.Position].Field<String>("CUSTOMER_NO"));
                if (loLastBalance != null)
                    lnBalance = (Decimal)loLastBalance;
                RecalcData.CUSTOMER.Rows[CustomerBindingSource.Position].SetField<Decimal>("CUSTOMER_BALANCE", lnBalance);
                CustomerBindingSource.EndEdit();
                CUSTOMERTableAdapter.Update(RecalcData.CUSTOMER.Rows[CustomerBindingSource.Position]);
                CustomerBindingSource.MoveNext();
            }
            MessageBox.Show("Completed : " + CustomerBindingSource.Count.ToString() + "Records");
            CUSTOMERTableAdapter.Dispose();
            RecalcData.Dispose();
            CustomerBindingSource.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

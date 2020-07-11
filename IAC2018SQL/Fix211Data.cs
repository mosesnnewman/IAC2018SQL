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
    public partial class frmFix211Data : Form
    {
        public frmFix211Data()
        {
            InitializeComponent();
        }

        private void buttonRecalc_Click(object sender, EventArgs e)
        {
            IACDataSet RecalcData = new IACDataSet();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();

            BindingSource MASTHISTBindingSource = new BindingSource();

            MASTHISTTableAdapter.FillByAccNo(RecalcData.MASTHIST, "211");

            MASTHISTBindingSource.DataSource = RecalcData.MASTHIST;
            MASTHISTBindingSource.MoveFirst();

            Decimal lnLastBalance = 0;
            lnLastBalance = RecalcData.MASTHIST.Rows[0].Field<Decimal>("MASTHIST_YTD_OLOAN");

            for (Int32 i=0; i < MASTHISTBindingSource.Count; i++)
            {
                labelDisplay.Text = " Acct no: " + RecalcData.MASTHIST.Rows[i].Field<String>("MASTHIST_ACC_NO") + "  Date:" +
                                                RecalcData.MASTHIST.Rows[i].Field<DateTime>("MASTHIST_POST_DATE").ToShortDateString() +
                                                " Sequence#: " +
                                                RecalcData.MASTHIST.Rows[i].Field<Int32>("MASTHIST_SEQ_NO");

                if (i != 0)
                {
                    lnLastBalance = RecalcData.MASTHIST.Rows[i - 1].Field<Decimal>("MASTHIST_YTD_OLOAN");
                    RecalcData.MASTHIST.Rows[i].SetField<Decimal>("MASTHIST_YTD_OLOAN", lnLastBalance - RecalcData.MASTHIST.Rows[i].Field<Decimal>("MASTHIST_CUR_OLOAN"));

                    MASTHISTBindingSource.EndEdit();
                    MASTHISTTableAdapter.Update(RecalcData.MASTHIST.Rows[i]);
                }
            }
            MessageBox.Show("Completed : " + MASTHISTBindingSource.Count.ToString() + "Records");
            MASTHISTTableAdapter.Dispose();
            RecalcData.Dispose();
            MASTHISTBindingSource.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

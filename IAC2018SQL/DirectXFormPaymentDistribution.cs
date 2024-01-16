using DevExpress.XtraEditors;
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
    public partial class DirectXFormPaymentDistribution : DevExpress.XtraEditors.DirectXForm
    {
        public Int32 giCustomerID
        {
            get;
            set;
        }
        public DirectXFormPaymentDistribution()
        {
            InitializeComponent();
        }
    }
}
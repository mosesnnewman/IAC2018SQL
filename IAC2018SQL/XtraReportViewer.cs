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
    public partial class XtraReportViewer : DevExpress.XtraEditors.XtraForm
    {
        public XtraReportViewer()
        {
            InitializeComponent();
        }


        private void ReportViewer_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }
    }
}

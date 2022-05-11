using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportMonthlyUpdateDailyInterestVariance : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportMonthlyUpdateDailyInterestVariance()
        {
            InitializeComponent();
        }

        private void InterestType_GetValue(object sender, GetValueEventArgs e)
        {
            String lsType = (String)e.GetColumnValue("Type");
            if (String.IsNullOrEmpty(lsType))
                return;

            switch (lsType)
            {
                case "P":
                    e.Value = "Payment Posting Interest";
                    break;
                case "L":
                    e.Value = "Notice Posting Interest";
                    break;
                case "M":
                    e.Value = "Monthly Interest";
                    break;
            }
        }
    }
}


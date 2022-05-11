using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportDelinquency : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportDelinquency()
        {
            InitializeComponent();
        }

        private void DaysDelinquent_GetValue(object sender, GetValueEventArgs e)
        {
            TimeSpan DateDiff;
            object oPaidThru = e.GetColumnValue("CUSTOMER_PAID_THRU");
            if (oPaidThru == null)
            {
                e.Value = 0;
                return;
            }
            Int32 DueDay = (Int32)e.GetColumnValue("CUSTOMER_DAY_DUE"), DaysDelinquent = 0;
            String YearPart = DateTime.Now.Year.ToString().Trim().Substring(0,2) + ((String)oPaidThru).Substring(2, 2),
                   MonthPart = ((String)oPaidThru).Substring(0, 2),
                   DayPart = DueDay.ToString().PadLeft(2,'0');
            DateTime NextDueDate;
            if (DueDay == 30 && MonthPart == "02")
                NextDueDate = DateTime.Parse("03/30/" + YearPart);
            else
                NextDueDate = DateTime.Parse(MonthPart + "/" + DayPart + "/" + YearPart).AddMonths(1);

            DateDiff = (DateTime)gdCurrentDate.Value - NextDueDate;
            DaysDelinquent = (Int32)DateDiff.TotalDays;

            if (DaysDelinquent > 0)
                e.Value = DaysDelinquent;
            else
                e.Value = 0;
        }
    }
}

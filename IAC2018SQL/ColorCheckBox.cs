using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2018SQL
{
    // Moses Newman 06/13/2018 Colored Checkbox custom control
    public partial class ColorCheckBox : CheckBox
    {
        //private readonly Appearance Appearance;

        public ColorCheckBox()
        {
            Appearance = System.Windows.Forms.Appearance.Button;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TextAlign = ContentAlignment.MiddleRight;
            FlatAppearance.BorderSize = 0;
            AutoSize = false;
            Height = 16;
            Width = 129;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);

            pevent.Graphics.Clear(BackColor);

            using (SolidBrush brush = new SolidBrush(ForeColor))
                pevent.Graphics.DrawString(Text, Font, brush, 27, 4);

            Point pt = new Point(4, 4);
            Rectangle rect = new Rectangle(pt, new Size(16, 16));

            pevent.Graphics.FillRectangle(Brushes.Beige, rect);

            if (Checked)
            {
                using (SolidBrush brush = new SolidBrush(ForeColor))
                using (Font wing = new Font("Wingdings", 12f))
                    pevent.Graphics.DrawString("ü", wing, brush, 1, 2);
            }
            pevent.Graphics.DrawRectangle(Pens.DarkSlateBlue, rect);

            Rectangle fRect = ClientRectangle;

            if (Focused)
            {
                fRect.Inflate(-1, -1);
                using (Pen pen = new Pen(Brushes.Gray) { DashStyle = DashStyle.Dot })
                    pevent.Graphics.DrawRectangle(pen, fRect);
            }
        }
    }
}

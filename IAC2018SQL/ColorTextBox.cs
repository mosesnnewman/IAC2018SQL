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

namespace IAC2021SQL
{
    // Moses Newman 09/05/2020 Colored TextBox custom control
    public partial class ColorTextBox : TextBox
    {
        //private readonly Appearance Appearance;

        private System.Drawing.Color _backColorDisabled = System.Drawing.SystemColors.Control;
        private System.Drawing.Color _foreColorCustom = Color.Red;

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            this.Invalidate();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            //System.Drawing.SolidBrush textBrush;

            if (!Enabled)
            {
                System.Drawing.SolidBrush backBrush = new System.Drawing.SolidBrush(_backColorDisabled);
                e.Graphics.FillRectangle(backBrush, ClientRectangle);
            }

            //Set user selected backcolor when disabled
            if (this.Text.IndexOf('(') >= 0)
                _foreColorCustom = Color.Red;
            else
                if (this.Text.IndexOf('$') >= 0 && this.Text.Trim() != "$0.00")
                    _foreColorCustom = Color.Green;
            else
                if (!Enabled)
                    _foreColorCustom = System.Drawing.SystemColors.GrayText;
                else
                    _foreColorCustom = System.Drawing.SystemColors.ControlText;
            // textBrush = new System.Drawing.SolidBrush(_foreColorCustom);
            // Moses Newman 09/05/2020 GDI Drawtext Renders Text MUCH better thatn Graphics.DrawString!
            /*StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Far;
            sf.Alignment = StringAlignment.Far;*/

            TextFormatFlags flags = TextFormatFlags.Right | TextFormatFlags.NoPadding;
            //Paint text
            //e.Graphics.DrawString(Text,Font, textBrush, ClientRectangle,sf);
            TextRenderer.DrawText(e.Graphics,Text, Font, ClientRectangle, _foreColorCustom,flags);
        }
    }
}

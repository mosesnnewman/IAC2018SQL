using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;

namespace IAC2021SQL
{
    /// <summary>
    /// Custom column header cell that can display an Image or Icon in addition to the typical Value.
    /// </summary>
    public class DataGridViewImageColumnHeaderCell : DataGridViewColumnHeaderCell
    {
        private Padding imagePadding;
        private bool imageBeforeValue;
        private Image image;
        private Icon icon;
        /// <summary>
        /// Constructor that sets the default values
        /// </summary>
        public DataGridViewImageColumnHeaderCell()
        {
            this.imageBeforeValue = true;
        }
        /// <summary>
        /// Represents the icon displayed by the cell
        /// </summary>
        [
            DefaultValue(null)
        ]
        public Icon Icon
        {
            get
            {
                return this.icon;
            }
            set
            {
                this.icon = value;
                if (this.DataGridView != null)
                {
                    this.DataGridView.UpdateCellValue(this.ColumnIndex, -1);
                }
            }
        }
        /// <summary>
        /// Represents the image displayed by the cell
        /// </summary>
        [
            DefaultValue(null)
        ]
        public Image Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
                if (this.DataGridView != null)
                {
                    // Moses Newman 10/19/2017 Not sure why they are setting the column index to -1 but it blows up. Works commented out!
                    //this.DataGridView.UpdateCellValue(this.ColumnIndex, -1);
                }
            }
        }
        /// <summary>
        /// Determines if the Image or Icon is displayed on the left of right of the Value.
        /// </summary>
        [
            DefaultValue(true)
        ]
        public bool ImageBeforeValue
        {
            get
            {
                return this.imageBeforeValue;
            }
            set
            {
                if (this.ImageBeforeValue != value)
                {
                    this.imageBeforeValue = value;
                    if (this.DataGridView != null)
                    {
                        this.DataGridView.InvalidateCell(this);
                    }
                }
            }
        }
        /// <summary>
        /// Defines a padding around the image or icon.
        /// </summary>
        public Padding ImagePadding
        {
            get
            {
                return this.imagePadding;
            }
            set
            {
                if (this.ImagePadding != value)
                {
                    if (value.Left < 0 || value.Right < 0 || value.Top < 0 || value.Bottom < 0)
                    {
                        if (value.All != -1)
                        {
                            value.All = 0;
                        }
                        else
                        {
                            value.Left = Math.Max(0, value.Left);
                            value.Right = Math.Max(0, value.Right);
                            value.Top = Math.Max(0, value.Top);
                            value.Bottom = Math.Max(0, value.Bottom);
                        }
                    }
                    this.imagePadding = value;
                    if (this.DataGridView != null)
                    {
                        //this.DataGridView.UpdateCellValue(this.ColumnIndex, -1);
                    }
                }
            }
        }
        /// <summary>
        /// Custom Clone implementation that copies the cell specific properties.
        /// </summary>
        public override object Clone()
        {
            DataGridViewImageColumnHeaderCell dataGridViewCell = base.Clone() as DataGridViewImageColumnHeaderCell;
            if (dataGridViewCell != null)
            {
                dataGridViewCell.ImageBeforeValue = this.ImageBeforeValue;
                dataGridViewCell.ImagePadding = this.ImagePadding;
                dataGridViewCell.Image = this.Image;
                dataGridViewCell.Icon = this.Icon;
            }
            return dataGridViewCell;
        }
        /// <summary>
        /// Utility function that adjusts the vertical padding of the cell to account 
        /// for the additional image or icon.
        /// </summary>
        private Padding GetAdjustedCellPadding(DataGridViewCellStyle cellStyle)
        {
            if (this.image != null)
            {
                if (this.imageBeforeValue)
                {
                    return new Padding(cellStyle.Padding.Left + this.imagePadding.Horizontal + this.image.Width, cellStyle.Padding.Top, cellStyle.Padding.Right, cellStyle.Padding.Bottom);
                }
                else
                {
                    return new Padding(cellStyle.Padding.Left, cellStyle.Padding.Top, cellStyle.Padding.Right + this.imagePadding.Horizontal + this.image.Width, cellStyle.Padding.Bottom);
                }
            }
            else if (this.icon != null)
            {
                if (this.imageBeforeValue)
                {
                    return new Padding(cellStyle.Padding.Left + this.imagePadding.Horizontal + this.icon.Width, cellStyle.Padding.Top, cellStyle.Padding.Right, cellStyle.Padding.Bottom);
                }
                else
                {
                    return new Padding(cellStyle.Padding.Left, cellStyle.Padding.Top, cellStyle.Padding.Right + this.imagePadding.Horizontal + this.icon.Width, cellStyle.Padding.Bottom);
                }
            }
            return cellStyle.Padding;
        }
        /// <summary>
        /// Custom implementation of GetContentBounds to ensure that the potential image or icon is not part
        /// of the content bounds.
        /// </summary>
        protected override Rectangle GetContentBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
        {
            if (this.image != null || this.icon != null)
            {
                if (cellStyle == null)
                {
                    throw new ArgumentNullException("cellStyle");
                }
                cellStyle.Padding = GetAdjustedCellPadding(cellStyle);
            }
            return base.GetContentBounds(graphics, cellStyle, rowIndex);
        }
        /// <summary>
        /// Custom implementation of GetPreferredSize that take into account the potential
        /// image or icon and its padding.
        /// </summary>
        protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
            if (rowIndex != -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if (this.DataGridView == null)
            {
                return new Size(-1, -1);
            }
            Size basePreferredSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            if (constraintSize.Width == 0)
            {
                if (this.image != null)
                {
                    basePreferredSize.Width += image.Width + this.ImagePadding.Horizontal;
                }
                else if (this.icon != null)
                {
                    basePreferredSize.Width += icon.Width + this.ImagePadding.Horizontal;
                }
            }
            if (constraintSize.Height == 0)
            {
                DataGridViewAdvancedBorderStyle dgvabsPlaceholder = new DataGridViewAdvancedBorderStyle(), dgvabsEffective;
                dgvabsEffective = this.DataGridView.AdjustColumnHeaderBorderStyle(this.DataGridView.AdvancedColumnHeadersBorderStyle,
                    dgvabsPlaceholder,
                    false /*isFirstDisplayedColumn*/,
                    false /*isLastVisibleColumn*/);
                Rectangle borderWidthsRect = BorderWidths(dgvabsEffective);
                int borderAndPaddingHeights = borderWidthsRect.Top + borderWidthsRect.Height + cellStyle.Padding.Vertical;
                if (this.image != null)
                {
                    basePreferredSize.Height = Math.Max(basePreferredSize.Height, image.Height + borderAndPaddingHeights + this.ImagePadding.Vertical);
                }
                else if (this.icon != null)
                {
                    basePreferredSize.Height = Math.Max(basePreferredSize.Height, icon.Height + borderAndPaddingHeights + this.ImagePadding.Vertical);
                }
            }
            return basePreferredSize;
        }
        /// <summary>
        /// Custom painting implementation that paints the image or icon on top of the base implementation.
        /// </summary>
        protected override void Paint(Graphics graphics,
            Rectangle clipBounds,
            Rectangle cellBounds,
            int rowIndex,
            DataGridViewElementStates dataGridViewElementState,
            object value,
            object formattedValue,
            string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            if (cellStyle == null)
            {
                throw new ArgumentNullException("cellStyle");
            }
            Padding cellStylePadding = cellStyle.Padding;
            int imageHeight = 0, imageWidth = 0;
            if (this.image != null || this.icon != null)
            {
                if (this.image != null)
                {
                    imageHeight = this.image.Height;
                    imageWidth = this.image.Width;
                }
                else if (this.icon != null)
                {
                    imageHeight = this.icon.Height;
                    imageWidth = this.icon.Width;
                }
                cellStyle.Padding = GetAdjustedCellPadding(cellStyle);
            }
            base.Paint(graphics,
                       clipBounds,
                       cellBounds,
                       rowIndex,
                       dataGridViewElementState,
                       value,
                       formattedValue,
                       errorText,
                       cellStyle,
                       advancedBorderStyle,
                       paintParts);
            if (this.image != null || this.icon != null)
            {
                Rectangle valBounds = cellBounds;
                Rectangle borderWidths = BorderWidths(advancedBorderStyle);
                valBounds.Offset(borderWidths.X, borderWidths.Y);
                valBounds.Width -= borderWidths.Right;
                valBounds.Height -= borderWidths.Bottom;
                if (valBounds.Width > 0 && valBounds.Height > 0)
                {
                    if (this.imageBeforeValue)
                    {
                        if (this.DataGridView.RightToLeft == RightToLeft.Yes)
                        {
                            valBounds.Offset(Math.Max(cellStylePadding.Right + this.ImagePadding.Right, valBounds.Width - cellStylePadding.Left - this.ImagePadding.Left - imageWidth), cellStylePadding.Top + this.ImagePadding.Top);
                        }
                        else
                        {
                            valBounds.Offset(cellStylePadding.Left + this.ImagePadding.Left, cellStylePadding.Top + this.ImagePadding.Top);
                        }
                    }
                    else
                    {
                        if (this.DataGridView.RightToLeft == RightToLeft.Yes)
                        {
                            valBounds.Offset(cellStylePadding.Right + this.ImagePadding.Right, cellStylePadding.Top + this.ImagePadding.Top);
                        }
                        else
                        {
                            valBounds.Offset(Math.Max(cellStylePadding.Left + this.ImagePadding.Left, valBounds.Width - cellStylePadding.Right - this.ImagePadding.Right - imageWidth), cellStylePadding.Top + this.ImagePadding.Top);
                        }
                    }
                    valBounds.Width -= cellStylePadding.Horizontal + this.ImagePadding.Horizontal;
                    valBounds.Height -= cellStylePadding.Vertical + this.ImagePadding.Vertical;
                    if (valBounds.Width > 0 && valBounds.Height > 0)
                    {
                        switch (cellStyle.Alignment)
                        {
                            case DataGridViewContentAlignment.MiddleCenter:
                            case DataGridViewContentAlignment.MiddleLeft:
                            case DataGridViewContentAlignment.MiddleRight:
                                valBounds.Y += Math.Max(0, (valBounds.Height - imageHeight) / 2);
                                break;
                            case DataGridViewContentAlignment.BottomCenter:
                            case DataGridViewContentAlignment.BottomLeft:
                            case DataGridViewContentAlignment.BottomRight:
                                valBounds.Y += Math.Max(0, valBounds.Height - imageHeight);
                                break;
                        }
                        Region reg = graphics.Clip;
                        graphics.SetClip(Rectangle.Intersect(valBounds, Rectangle.Truncate(graphics.VisibleClipBounds)));
                        try
                        {
                            if (this.image != null)
                            {
                                Rectangle imageBounds = new Rectangle(valBounds.Location, this.image.Size);
                                graphics.DrawImage(this.image, imageBounds);
                            }
                            else if (this.icon != null)
                            {
                                Rectangle iconBounds = new Rectangle(valBounds.Location, this.icon.Size);
                                graphics.DrawIconUnstretched(this.icon, iconBounds);
                            }
                        }
                        finally
                        {
                            graphics.Clip = reg;
                        }
                    }
                }
                cellStyle.Padding = cellStylePadding;
            }
        }
        /// <summary>
        /// Custom string representation of this custom cell type.
        /// </summary>
        public override string ToString()
        {
            return "DataGridViewImageColumnHeaderCell { ColumnIndex=" + this.ColumnIndex.ToString(CultureInfo.CurrentCulture) + " }";
        }
    }
}


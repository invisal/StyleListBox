using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using VisalPack;

namespace VisalPackDemo {
    class ListDriveItem : StyleListBoxItem 
    {
        int _size = 0;
        int _used = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">Text of the item</param>
        /// <param name="imageIndex">Image index of the item</param>
        /// <param name="size">Used space of the drive</param>
        /// <param name="used">Total space of the drive</param>
        public ListDriveItem(string text = "", int imageIndex = -1, int size = 0, int used = 0) : base(text, imageIndex)
        {
            _size = size;
            _used = used;
        }

        protected override void OnDrawText(Graphics g, Rectangle bound, StyleListBoxItemStyle style) {
            // Decide which color to use for text
            Color textColor;
            if (Selected) {
                textColor = style.SelectedTextColor;
            } else {
                textColor = style.TextColor;
            }

            // Draw text
            TextRenderer.DrawText(g, this.Text, style.Font, bound.Location, textColor);

            // Draw progressbar
            Rectangle progressbarBound = new Rectangle(bound.X, bound.Y + style.Font.Height + 3, 200, 15);
            ProgressBarRenderer.DrawHorizontalBar(g, progressbarBound);
            
            progressbarBound.Width = (int)(progressbarBound.Width * ((float)_used / _size));
            progressbarBound.X = progressbarBound.X + 1;
            progressbarBound.Y = progressbarBound.Y + 1;
            progressbarBound.Height = progressbarBound.Height - 2;
            ProgressBarRenderer.DrawHorizontalChunks(g, progressbarBound);

            // Draw the below caption
            TextRenderer.DrawText(g, (_size - _used).ToString() + " GB free of " + _size.ToString() + " GB", style.Font, new Point(bound.X, bound.Y + style.Font.Height + 20), textColor);
        }

        protected override Size OnMeasureText(Graphics g, StyleListBoxItemStyle style) {
            Size size = base.OnMeasureText(g, style);
            size.Height *= 2;
            size.Height += 18;

            return size;
        }
    }
}

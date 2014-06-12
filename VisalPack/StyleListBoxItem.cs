using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace VisalPack {
    public class StyleListBoxItem {
        // Private Declarations
        private String _text;
        private int _imageIndex = -1;

        private bool _selected;
        private bool isCanUpdateChange = true;

        private StyleListBoxItemStyle _style;

        // Events
        internal event EventHandler<EventItemChangedArgs> OnItemChanged;
        internal event EventHandler<EventItemChangedArgs> OnItemSelectionChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        public StyleListBoxItem(String text = "", int imageIndex = -1) {
            _style = new StyleListBoxItemStyle();
            _style.OnStyleChange += OnStyleChange;

            SuspendUpdateChange();

            this.Text = text;
            this.ImageIndex = imageIndex;
            this.Selected = false;

            ResumeUpdateChange();
        }

        /// <summary>
        /// Gets or sets the ImageList to use when displaying items
        /// </summary>
        [Description("ImageList to use when displaying items")]
        public int ImageIndex {
            get { return _imageIndex;  }
            set { 
                _imageIndex = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets the style currently applied to the cell.
        /// </summary>
        [Browsable(false)]
        public StyleListBoxItemStyle InheritedStyle {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets the style for the item.
        /// </summary>
        [Description("Style for the item.")]
        [TypeConverter(typeof(StyleListBoxItemStyleConverter))]
        public StyleListBoxItemStyle Style {
            get {
                return _style;    
            }
            set {
                if (!Object.ReferenceEquals(_style, value)) {
                    // Unbind the previous event
                    _style.OnStyleChange = null;
                    _style = value;
                
                    // Rebind the OnStyleChange event
                    _style.OnStyleChange += OnStyleChange;

                    UpdateChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets text for the item.
        /// </summary>
        [Description("Text for the item.")]
        public String Text {
            get { return _text; }
            set { 
                _text = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets the zero-based index of the item within the StyleListBox control.
        /// </summary>
        [Browsable(false)]
        public int Index {
            get;
            internal set;
        }

        /// <summary>
        /// Gets or sets value indicating whether the item is selected.
        /// </summary>
        public bool Selected {
            get { return _selected; }
            set {
                if (_selected != value) {
                    _selected = value;
                    UpdateSelectionChanged();
                    UpdateChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets the parent control
        /// </summary>
        [Browsable(false)]
        public StyleListBox Control { 
            get; 
            internal set; 
        }

        /// <summary>
        /// Draws list item on specified bounds.
        /// </summary>
        /// <param name="g">The Graphics used to draw the item.</param>
        /// <param name="bound">The Rectangle that specifies the bounds of the item</param>
        public void DrawItem(Graphics g, Rectangle bound) 
        {
            StyleListBoxItemStyle style = GetStyle();
            OnDrawItem(g, bound, style);
        }

        /// <summary>
        /// Overridable method to draw item on specified bounds.
        /// </summary>
        /// <param name="g">The Graphics used to draw the item.</param>
        /// <param name="bound">The Rectangle that specfies the bounds of the item</param>
        /// <param name="style">The Style used to draw the item.</param>
        public virtual void OnDrawItem(Graphics g, Rectangle bound, StyleListBoxItemStyle style)
        {
            int leftX = style.Padding.Left;
            int rightX = bound.Right - style.Padding.Right;
            int textX;

            Size textSize = OnMeasureText(g, style);
            Rectangle textBound;
            Rectangle imageBound = new Rectangle();

            OnDrawBackground(g, bound, style);

            // Draw image
            if (Control.ImageList != null && this.ImageIndex >= 0) {
                // Calculate the bound of the image
                Image image = Control.ImageList.Images[this.ImageIndex];

                if (style.ImageAlignment == StyleItemAlignment.Left || style.ImageAlignment == StyleItemAlignment.None) {
                    if (image.Height < textSize.Height) {
                        imageBound = new Rectangle(leftX, bound.Y + style.Padding.Top + (image.Height - textSize.Height) / 2, image.Width, image.Height);
                    } else {
                        imageBound = new Rectangle(leftX, bound.Y + style.Padding.Top, image.Width, image.Height);
                    }

                    leftX += image.Width;
                } else {
                    rightX -= image.Width;

                    if (image.Height > textSize.Height) {
                        imageBound = new Rectangle(rightX, bound.Y + style.Padding.Top + (image.Height - textSize.Height) / 2, image.Width, image.Height);
                    } else {
                        imageBound = new Rectangle(rightX, bound.Y + style.Padding.Top, image.Width, image.Height);
                    }
                }
                
                OnDrawImage(g, imageBound, image);
            }

            // Calculate the text bound
            if (style.TextAlignment == StyleItemAlignment.Right) {
                textX = rightX - textSize.Width;
            } else {
                textX = leftX;
            }

            if (style.TextVerticalAlignment == StyleItemVerticalAlignment.Top) {
                textBound = new Rectangle(textX, bound.Y + style.Padding.Top, textSize.Width, textSize.Height);
            } else if (style.TextVerticalAlignment == StyleItemVerticalAlignment.Bottom) {
                textBound = new Rectangle(textX, bound.Bottom - style.Padding.Bottom - textSize.Height, textSize.Width, textSize.Height);
            } else {
                if (textSize.Height < imageBound.Height) {
                    textBound = new Rectangle(textX, bound.Y + style.Padding.Top + (imageBound.Height - textSize.Height) / 2, textSize.Width, textSize.Height);
                } else {
                    textBound = new Rectangle(textX, bound.Y + style.Padding.Top, textSize.Width, textSize.Height);
                }
            }

            // Draw text
            OnDrawText(g, textBound, style);
        }

        /// <summary>
        /// Draw background of the item
        /// </summary>
        /// <param name="g">The Graphic used to draw the background of the item</param>
        /// <param name="bound">Bound of the item</param>
        /// <param name="style">Style of the item</param>
        protected virtual void OnDrawBackground(Graphics g, Rectangle bound, StyleListBoxItemStyle style) 
        {
            if (!Selected) {
                g.FillRectangle(new SolidBrush(style.BackColor), bound);
            } else {
                if (style.SelectionStyle == SelectionStyle.Flat) {
                    g.FillRectangle(new SolidBrush(style.SelectedBackColor), bound);
                } else {
                    // Leave some spaces for selection
                    Rectangle rect = new Rectangle(bound.X + 1, bound.Y + 1, bound.Width - 2, bound.Height - 2);

                    // Get lighter color of the background
                    Color c1 = Color.FromArgb(200, style.SelectedBackColor);
                    Color c2 = Color.FromArgb(50, style.SelectedBackColor);

                    g.DrawRectangle(new Pen(style.SelectedBackColor), rect);
                    g.FillRectangle(new LinearGradientBrush(new Point(rect.X, rect.Y), new Point(rect.X, rect.Bottom), c2, c1), rect);
                }
            }

            // Draw focus border
            if (Control != null && Control.FocuedIndex == this.Index) {
                int borderMargin = 1;
                if (style.SelectionStyle == SelectionStyle.Crystal) borderMargin = 2;

                Rectangle focusRect = new Rectangle(bound.X + borderMargin, bound.Y + borderMargin, bound.Width - (borderMargin * 2), bound.Height - (borderMargin * 2));
                Pen focusPen;

                if (this.Selected) {
                    focusPen = new Pen(style.SelectedTextColor);
                } else {
                    focusPen = new Pen(style.TextColor);
                }
                
                focusPen.DashStyle = DashStyle.Dot;

                g.DrawRectangle(focusPen, focusRect);
            }
        }

        /// <summary>
        /// Measure the size of the text area
        /// </summary>
        /// <param name="g">The Graphic used to draw the text</param>
        /// <param name="style">Style of the item</param>
        /// <returns></returns>
        protected virtual Size OnMeasureText(Graphics g, StyleListBoxItemStyle style) 
        {
            return TextRenderer.MeasureText(this.Text, style.Font);
        }

        /// <summary>
        /// Draw the image part of the item
        /// </summary>
        /// <param name="g">The Graphic used to draw the image</param>
        /// <param name="bound">The bound of where to draw the image</param>
        /// <param name="image"></param>
        protected virtual void OnDrawImage(Graphics g, Rectangle bound, Image image)
        {
            g.DrawImage(image, bound);
        }

        /// <summary>
        /// Draw the text part of the item
        /// </summary>
        /// <param name="g">The Graphics used to draw the text part</param>
        /// <param name="bound">The bound of where to draw the text</param>
        /// <param name="style">The style of the item</param>
        protected virtual void OnDrawText(Graphics g, Rectangle bound, StyleListBoxItemStyle style)
        {
            // Choose the correct text color
            Color textColor;
            if (this.Selected) {
                textColor = style.SelectedTextColor;
            } else {
                textColor = style.TextColor;
            }

            TextRenderer.DrawText(g, this.Text, style.Font, bound, textColor);
        }

        /// <summary>
        /// Measures the height of the item.
        /// </summary>
        /// <param name="g">The Graphics used to measure the item</param>
        /// <returns>The height of the item.</returns>
        public int MeasureItem() {
            StyleListBoxItemStyle style = GetStyle();

            if (ImageIndex >= 0 && Control.ImageList != null) {
                return Math.Max(Control.ImageList.Images[ImageIndex].Height, style.Font.Height) + style.Padding.Top + style.Padding.Bottom;
            } else {
                return style.Font.Height + style.Padding.Top + style.Padding.Bottom;
            }
        }

        /// <summary>
        /// Prevents OnItemChanged event to trigger when any property is changed.
        /// </summary>
        public void SuspendUpdateChange() {
            isCanUpdateChange = false;
        }

        /// <summary>
        /// Resumes OnItemChanged event to trigger when any property is changed.
        /// 
        /// Note:
        /// It does not trigger OnItemChanged when ResumeUpdateChanged is called.
        /// If you have called SuspendUpdateChange(), made changes to any
        /// properties and called ResumeUpdateChange(), you should also call
        /// UpdateChange()
        /// </summary>
        public void ResumeUpdateChange() {
            isCanUpdateChange = true;
        }

        /// <summary>
        /// Forces to trigger OnItemChanged Event.
        /// 
        /// Note:
        /// If you have called SuspendUpdateChange, UpdateChange()
        /// will not trigger OnItemChanged Event. You should call this
        /// method after ResumeUpdatechange().
        /// </summary>
        public void UpdateChange() {
            if (OnItemChanged != null && isCanUpdateChange) {
                OnItemChanged(Control, new EventItemChangedArgs(this));
            }
        }

        /// <summary>
        /// Force to trigger OnItemSelectionChanged Event.
        /// </summary>
        internal void UpdateSelectionChanged() {
            if (OnItemSelectionChanged != null) {
                OnItemSelectionChanged(Control, new EventItemChangedArgs(this));
            }
        }

        /// <summary>
        /// Set Selected by bypassing OnItemSelectionChanged event
        /// </summary>
        /// <param name="selected"></param>
        internal void SetSelected(bool selected) {
            _selected = selected;
        }


        /// <summary>
        /// Gets current style combining with InheritedStyle
        /// </summary>
        /// <returns></returns>
        protected StyleListBoxItemStyle GetStyle() {
            return this.Style.CloneMerge(InheritedStyle);
        }

        /// <summary>
        /// Notify other when item style is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnStyleChange(object sender, EventArgs e) 
        {
            if (isCanUpdateChange) {
                UpdateChange();
            }
        }
    }
}

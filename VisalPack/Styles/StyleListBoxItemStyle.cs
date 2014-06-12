using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace VisalPack {
    public class StyleListBoxItemStyle {
        // Declarations
        private Font _font = null;
        private Color _backColor = Color.Empty;
        private Color _textColor = Color.Empty;
        private Color _selectedBackColor = Color.Empty;
        private Color _selectedTextColor = Color.Empty;
        private Padding _padding = Padding.Empty;
        private SelectionStyle _selectionStyle = SelectionStyle.Inherited;
        private StyleItemAlignment _textAlignment = StyleItemAlignment.None;
        private StyleItemVerticalAlignment _textVerticalAlignment = StyleItemVerticalAlignment.None;
        private StyleItemAlignment _imageAlignment = StyleItemAlignment.None;

        // Events
        internal EventHandler OnStyleChange;

        /// <summary>
        /// Gets or sets text alignment for the item.
        /// </summary>
        [Description("Text alignment for the item")]
        [DefaultValue("Left")]
        public StyleItemAlignment TextAlignment {
            get { return _textAlignment; }
            set {
                _textAlignment = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets vertical alignment for the item.
        /// </summary>
        [Description("Text vertical alignment for the item")]
        [DefaultValue("Middle")]
        public StyleItemVerticalAlignment TextVerticalAlignment {
            get { return _textVerticalAlignment;  }
            set {
                _textVerticalAlignment = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets image alignment for the item.
        /// </summary>
        [Description("Image alignment for the item")]
        [DefaultValue("Left")]
        public StyleItemAlignment ImageAlignment {
            get { return _imageAlignment; }
            set {
                _imageAlignment = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets the font for the item.
        /// </summary>
        [Description("Font for the item")]
        [DefaultValue(null)]
        public Font Font {
            get { return _font; }
            set {
                _font = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets the background color for the item.
        /// </summary>
        [Description("Background color for the item")]
        public Color BackColor {
            get { return _backColor; }
            set {
                _backColor = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets the text color for the item.
        /// </summary>
        [Description("Text color for the item")]
        public Color TextColor {
            get { return _textColor; }
            set {
                _textColor = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets the selection style for the item.
        /// </summary>
        [Description("Selection Style for item")]
        [DefaultValue("Flat")]
        public SelectionStyle SelectionStyle {
            get { return _selectionStyle; }
            set {
                _selectionStyle = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets the background color for the item when it is selected
        /// </summary>
        [Description("Background color for the item when it is selected")]        
        public Color SelectedBackColor {
            get { return _selectedBackColor; }
            set {
                _selectedBackColor = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets the text color for the item when it is selected
        /// </summary>
        [Description("Text color for the item when it is selected")]
        public Color SelectedTextColor {
            get { return _selectedTextColor; }
            set {
                _selectedTextColor = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Gets or sets padding for the item.
        /// </summary>
        [Description("Padding for the item.")]
        [DefaultValue(typeof(Padding), "0, 0, 0, 0")]
        public Padding Padding {
            get { return _padding; }
            set {
                _padding = value;
                UpdateChange();
            }
        }

        /// <summary>
        /// Notify that the style has changed.
        /// </summary>
        protected void UpdateChange() {
            if (OnStyleChange != null) {
                OnStyleChange(null, null);
            }
        }

        /// <summary>
        /// Clones a new StyleListBoxItemStyle by combining the current
        /// StyleListBoxItemStyle with alternative StyleListBoxItemStyle.
        /// 
        /// Note:
        /// If any property of the current StyleListBoxItemStyle has not
        /// set, it will seek for value from the alternative StyleListBoxItemStyle
        /// </summary>
        /// <param name="other">Other alternative StyleListBoxItemStyle</param>
        /// <returns></returns>
        public StyleListBoxItemStyle CloneMerge(StyleListBoxItemStyle other)
        {
            StyleListBoxItemStyle clone = new StyleListBoxItemStyle();

            clone.BackColor = (this.BackColor == Color.Empty) ? other.BackColor : this.BackColor;
            clone.TextColor = (this.TextColor == Color.Empty) ? other.TextColor : this.TextColor;
            clone.Padding = (this.Padding == Padding.Empty) ? other.Padding : this.Padding;
            clone.Font = (this.Font == null) ? other.Font : this.Font;
            clone.SelectedBackColor = (this.SelectedBackColor == Color.Empty) ? other.SelectedBackColor : this.SelectedBackColor;
            clone.SelectedTextColor = (this.SelectedTextColor == Color.Empty) ? other.SelectedTextColor : this.SelectedTextColor;
            clone.SelectionStyle = (this.SelectionStyle == SelectionStyle.Inherited) ? other.SelectionStyle : this.SelectionStyle;
            clone.TextAlignment = (this.TextAlignment == StyleItemAlignment.None) ? other.TextAlignment : this.TextAlignment;
            clone.TextVerticalAlignment = (this.TextVerticalAlignment == StyleItemVerticalAlignment.None) ? other.TextVerticalAlignment : this.TextVerticalAlignment;
            clone.ImageAlignment = (this.ImageAlignment == StyleItemAlignment.None) ? other.ImageAlignment : this.ImageAlignment;

            return clone;
        }
    }
}

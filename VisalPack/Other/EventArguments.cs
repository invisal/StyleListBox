using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisalPack {
    public enum SelectionStyle {
        Inherited = 0,
        Flat = 1,
        Crystal = 2
    }

    public enum StyleItemDisplay {
        None = 0,
        TextOnly = 1,
        ImageWithText = 2
    }

    public enum StyleItemAlignment {
        None = 0,
        Left = 1,
        Right = 2
    }

    public enum StyleItemVerticalAlignment {
        None = 0,
        Top = 1,
        Middle = 2,
        Bottom = 3
    }

    /// <summary>
    /// Argument for event that occurs when new item is added/removed
    /// to StyleListBoxItemCollection.
    /// </summary>
    public class EventItemArgs : EventArgs 
    {
        public EventItemArgs(StyleListBoxItem item) {
            this.Item = item;
        }

        public StyleListBoxItem Item { get; set; }
    }

    /// <summary>
    /// Argument for event that occurs when item is changed
    /// in StyleListBoxItemCollection or StyleListBoxItem.
    /// </summary>
    public class EventItemChangedArgs : EventArgs 
    {
        public EventItemChangedArgs(StyleListBoxItem item) {
            this.Item = item;
        }

        public StyleListBoxItem Item { get; set; }
    }
}

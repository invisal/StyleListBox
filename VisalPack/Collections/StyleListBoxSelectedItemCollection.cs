using System;
using System.Collections;

namespace VisalPack {
    /// <summary>
    /// StyleListBoxSelectedItemCollection is a readonly collection that
    /// stores list of selected StyleListBoxItem.
    /// </summary>
    public class StyleListBoxSelectedItemCollection : CollectionBase {
        internal void Add(StyleListBoxItem item) 
        {
            List.Add(item);
        }

        internal void Remove(StyleListBoxItem item) 
        {
            List.Remove(item);
        }

        internal new void RemoveAt(int index) 
        {
            List.RemoveAt(index);
        }

        public StyleListBoxItem this[int index] 
        {
            get { return (StyleListBoxItem)List[index]; }
        }
    }
}

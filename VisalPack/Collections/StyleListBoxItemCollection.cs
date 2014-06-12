using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VisalPack {
    public class StyleListBoxItemCollection : CollectionBase 
    {
        #region "Declarations"
        protected StyleListBox listbox;
        #endregion

        #region "Constructors"
        public StyleListBoxItemCollection(StyleListBox listbox)
        {
            this.listbox = listbox;
        }
        #endregion

        #region "List Manipulation Methods"
        public void Add(StyleListBoxItem obj) 
        {
            // Fill default style value to new item
            obj.SuspendUpdateChange();
            obj.InheritedStyle = listbox.DefaultItemStyle;
            obj.ResumeUpdateChange();

            // Fill index to new item
            obj.Control = listbox;
            obj.Index = List.Count;
            
            // Monitor the changes of item property
            obj.OnItemChanged += OnChanged;
            obj.OnItemSelectionChanged += OnSelectionChanged;

            List.Add(obj);

            // Raise AddItem event
            if (OnItemAdded != null) {
                OnItemAdded(listbox, new EventItemArgs(obj));
            }
        }

        public void Add(String text = "", int imageIndex = -1) {
            Add(new StyleListBoxItem(text, imageIndex));
        }

        public new void RemoveAt(int index) {
            StyleListBoxItem temp = (StyleListBoxItem)List[index];
            List.RemoveAt(index);

            // Change index of other StyleListBoxItem
            for (int i = index; i < List.Count; i++) {
                ((StyleListBoxItem)List[i]).Index--;
            }

            if (OnItemRemoved != null) {
                OnItemRemoved(listbox, new EventItemArgs(temp));
            }
        }

        public void Remove(StyleListBoxItem obj) {
            RemoveAt(obj.Index);
        }

        public StyleListBoxItem this[int index] {
            get { return (StyleListBoxItem)List[index];  }
        }
        #endregion

        #region "Events"
        internal event EventHandler<EventItemArgs> OnItemAdded;
        internal event EventHandler<EventItemArgs> OnItemRemoved;
        internal event EventHandler<EventItemChangedArgs> OnItemChanged;
        internal event EventHandler<EventItemChangedArgs> OnItemSelectionChanged;
        #endregion

        #region "Event Handler"
        public void OnChanged(object sender, EventItemChangedArgs e) {
            if (OnItemChanged != null) {
                OnItemChanged(sender, e);
            }
        }

        public void OnSelectionChanged(object sender, EventItemChangedArgs e) {
            if (OnItemSelectionChanged != null) {
                OnItemSelectionChanged(sender, e);
            }
        }
        #endregion
    }
}

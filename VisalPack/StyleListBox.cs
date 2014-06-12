using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

/**
 * TODO LIST
 *      - Press key Up/Down to move or to increase the selection range
 *      - Drag items for multi-select
 *      - Animation
 **/

namespace VisalPack {
    public class StyleListBox : UserControl 
    {
        // Declarations
        StyleListBoxItemCollection itemList;
        StyleListBoxSelectedItemCollection itemSelectedList;

        int itemTotalHeight = 0;         // store the total height of all the items in the StyleListBox
        List<int> itemCacheHeight;       // store each heigh of the item in the StyleListBox,
                                         // prevent from calling too much MeasureItem().
        int itemFirstVisibleIndex = 0;   // first item index that is visible to the screen
        int itemLastVisibleIndex = 0;    // last item index that is visible to the screen
        int itemFirstVisibleY = 0;       // first total height from first item to the first visible item.
        int lastScrollValue = 0;

        StyleListBoxItemStyle defaultItemStyle;

        VScrollBar scroll;
        int lastSelectedIndex = -1;
        int _selectedIndex = -1;
        int _focusedIndex = 0;

        bool isCanUpdate = true;

        // ------------------------------------------------
        // Events
        // ------------------------------------------------
        public event EventHandler SelectedIndexChanged;
        public event EventHandler<EventItemArgs> ItemClicked;
        public event EventHandler<EventItemArgs> ItemDoubleClicked;

        #region "Properties"
        public ImageList ImageList {
            get; set;
        }

        public int SelectedIndex {
            get { return _selectedIndex; }
            set {
                if (value >= 0 && value < itemList.Count) {
                    itemList[value].Selected = true;
                    _selectedIndex = value;
                }
            }
        }

        public int FocuedIndex {
            get { return _focusedIndex; }
            set {
                _focusedIndex = value;
                Update();
            }
        }

        /// <summary>
        /// Gets the items of the StyleListBox
        /// </summary>
        [Browsable(false)]
        public StyleListBoxItemCollection Items {
            get { return itemList; }
        }

        /// <summary>
        /// Gets collection of currently selected items in the ListBox.
        /// </summary>
        [Browsable(false)]
        public StyleListBoxSelectedItemCollection SelectedItems {
            get { return itemSelectedList; }
        }

        /// <summary>
        /// Gets or sets the method in which items are selected in the ListBox.
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates if the list box is to be single-select, multi-select, or not selectable.")]
        [DefaultValue("One")]
        public SelectionMode SelectionMode {
            get; set;
        }

        [TypeConverter(typeof(StyleListBoxItemStyleConverter))]
        public StyleListBoxItemStyle DefaultItemStyle {
            get { return defaultItemStyle; }
            set {
                defaultItemStyle.OnStyleChange = null;
                defaultItemStyle = value;

                defaultItemStyle.OnStyleChange += OnDefaultStyleChange;
                OnDefaultStyleChange(null, null);
            }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public StyleListBox() 
        {
            itemList = new StyleListBoxItemCollection(this);
            itemSelectedList = new StyleListBoxSelectedItemCollection();
            itemCacheHeight = new List<int>();

            defaultItemStyle = new StyleListBoxItemStyle();
            defaultItemStyle.BackColor = Color.White;
            defaultItemStyle.TextColor = Color.Black;
            defaultItemStyle.SelectedBackColor = Color.Blue;
            defaultItemStyle.SelectedTextColor = Color.White;
            defaultItemStyle.Padding = new Padding(2, 2, 2, 2);
            defaultItemStyle.Font = new Font(this.Font, FontStyle.Regular);
            defaultItemStyle.SelectionStyle = SelectionStyle.Flat;
            defaultItemStyle.OnStyleChange += OnDefaultStyleChange;

            this.DoubleBuffered = true;
            SelectionMode = SelectionMode.One;

            // Handles collection events
            itemList.OnItemAdded += OnCollectionItemAdded;
            itemList.OnItemRemoved += OnCollectionItemRemoved;
            itemList.OnItemChanged += OnCollectionItemChanged;
            itemList.OnItemSelectionChanged += OnCollectionItemSelectionChanged;

            // Create scroll bar
            scroll = new VScrollBar();

            scroll.Width = 20;
            scroll.Left = this.Width - scroll.Width;
            scroll.Top = 0;
            scroll.Height = this.Height;
            scroll.Visible = false;

            scroll.Minimum = 0;
            scroll.Maximum = 0;
            scroll.Value = 0;
            scroll.SmallChange = 50;
            scroll.LargeChange = 50;

            scroll.ValueChanged += Scroll_OnValueChanged;
            scroll.KeyDown += Scroll_OnKeyDown;

            this.Controls.Add(scroll);
        }

        protected void OnDefaultStyleChange(object sender, EventArgs e) 
        {
            // recalculate the total height and each item height
            int height;
            int lastItemTotalHeight = itemTotalHeight;
            bool isFoundFirstVisibleIndex = false;
            itemTotalHeight = 0;

            for (int i = 0; i < itemList.Count; i++) {
                height = itemList[i].MeasureItem();

                if (isFoundFirstVisibleIndex == false) {
                    if (itemTotalHeight + height > scroll.Value) {
                        itemFirstVisibleY = itemTotalHeight;
                        itemFirstVisibleIndex = i;
                        isFoundFirstVisibleIndex = true;
                    }
                }

                itemTotalHeight += height;
                itemCacheHeight[i] = height;
            }

            itemLastVisibleIndex = GetLastVisibleItemIndex();

            // update scroll and repaint
            Update();
        }

        protected override void OnResize(EventArgs e) {
            scroll.Left = this.Width - scroll.Width;
            scroll.Height = this.Height;
            
            this.Update();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            if (!isCanUpdate) {
                return;
            }

            // Clear up
            Brush brushBackColor = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(brushBackColor, 0, 0, this.Width, this.Height);

            if (itemList.Count > 0) {
                // Only draw item that is visible
                int scrollWidth = (scroll.Visible) ? scroll.Width : 0;
                Rectangle bound = new Rectangle(0, itemFirstVisibleY - scroll.Value, this.Width - scrollWidth, 0);

                for (int i = itemFirstVisibleIndex; i <= itemLastVisibleIndex; i++) {
                    bound.Height = itemList[i].MeasureItem();
                    itemList[i].DrawItem(e.Graphics, bound);
                    bound.Y += bound.Height;
                }
            }
        }

        public void OnCollectionItemAdded(object sender, EventItemArgs e) {
            int height = e.Item.MeasureItem();
            int lastTotalHeight = itemTotalHeight;

            itemTotalHeight += height;
            itemCacheHeight.Add(height);

            // Update last visible item index
            if (scroll.Value + this.Height > lastTotalHeight) {
                itemLastVisibleIndex = GetLastVisibleItemIndex();
            }

            Update();
        }

        public void OnCollectionItemChanged(object sender, EventItemChangedArgs e) {
            int height = e.Item.MeasureItem();
            int change = height - itemCacheHeight[e.Item.Index];

            itemTotalHeight += change;
            itemCacheHeight[e.Item.Index] = height;

            // Update last visible item index
            if (e.Item.Index < itemFirstVisibleIndex) {
                itemFirstVisibleY += change;
                UpdateItemVisibilityByChange(change);
                itemLastVisibleIndex = GetLastVisibleItemIndex();
            } else if (e.Item.Index < itemLastVisibleIndex) {
                itemLastVisibleIndex = GetLastVisibleItemIndex();
            }

            Update();
        }

        public void OnCollectionItemRemoved(object sender, EventItemArgs e) {
            int height = e.Item.MeasureItem();
            itemTotalHeight -= height;
            itemCacheHeight.RemoveAt(e.Item.Index);

            if (e.Item.Selected) {
                itemSelectedList.Remove(e.Item);

                if (_selectedIndex == e.Item.Index) {
                    if (itemSelectedList.Count > 0) {
                        _selectedIndex = itemSelectedList[0].Index;
                    } else {
                        _selectedIndex = -1;
                    }
                }
            }

            // Update first visible item index and last visible item index accordingly
            if (e.Item.Index <= itemFirstVisibleIndex) {
                UpdateItemVisibilityByChange(-height);
                itemLastVisibleIndex = GetLastVisibleItemIndex();
            } else if (e.Item.Index <= itemLastVisibleIndex) {
                itemLastVisibleIndex = GetLastVisibleItemIndex();
            }

            Update();
        }

        protected override void OnKeyDown(KeyEventArgs e) {
        
            base.OnKeyDown(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e) {
            OnMouseClick(e);
            base.OnMouseDoubleClick(e);
        }

        /// <summary>
        /// Handles item selection when mouse is clicked on the item
        /// according to the SelectionMode rules.
        /// </summary>
        protected override void OnMouseClick(MouseEventArgs e) {
            if (!isCanUpdate) {
                return;
            }

            if (e.Button == MouseButtons.Left && SelectionMode != SelectionMode.None) {
                StyleListBoxItem item = GetItemFromPoint(e.Location);

                if (item != null) {
                    SuspendUpdate();

                    if (SelectionMode == SelectionMode.One) {
                        item.Selected = true;
                    } else if (SelectionMode == SelectionMode.MultiSimple) {
                        item.Selected = !item.Selected;
                    } else if (SelectionMode == SelectionMode.MultiExtended) {
                        if (Control.ModifierKeys.HasFlag(Keys.Control))  {
                            item.Selected = !item.Selected;
                        }  else if (Control.ModifierKeys.HasFlag(Keys.Shift)) {
                            // check if lastSelectedIndex is a valid index
                            if (lastSelectedIndex < itemList.Count)  {
                                ClearSelected();

                                int startIndex = Math.Min(lastSelectedIndex, item.Index);
                                int endIndex = Math.Max(lastSelectedIndex, item.Index);

                                for (int i = startIndex; i <= endIndex; i++) {
                                    itemList[i].SetSelected(true);
                                    itemSelectedList.Add(itemList[i]);
                                }

                                _selectedIndex = item.Index;
                            }
                        } else {
                            ClearSelected();
                            item.Selected = true;
                        }
                    }

                    lastSelectedIndex = item.Index;

                    ResumeUpdate();
                    Update();

                    if (e.Clicks == 1) {
                        if (ItemClicked != null) {
                            ItemClicked(this, new EventItemArgs(item));
                        }
                    } else if (e.Clicks > 1) {
                        if (ItemDoubleClicked != null) {
                            ItemDoubleClicked(this, new EventItemArgs(item));
                        }
                    }
                }
            }

            base.OnMouseClick(e);
        }

        /// <summary>
        /// Handles when StyleListBoxItem.Selected is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCollectionItemSelectionChanged(object sender, EventItemChangedArgs e) {
            if (e.Item.Selected) {
                if (SelectionMode == SelectionMode.One) {
                    ClearSelected();
                }

                // from False -> True
                itemSelectedList.Add(e.Item);
                _selectedIndex = e.Item.Index;
                _focusedIndex = e.Item.Index;
            } else {
                // from True -> False
                itemSelectedList.Remove(e.Item);

                if (_selectedIndex == e.Item.Index) {
                    if (itemSelectedList.Count > 0) {
                        _selectedIndex = itemSelectedList[itemSelectedList.Count - 1].Index;
                        _focusedIndex = _selectedIndex;
                    } else {
                        _selectedIndex = -1;
                        _focusedIndex = 0;
                    }
                }
            }

            if (SelectedIndexChanged != null) {
                SelectedIndexChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Gets StyleListBoxItem by location on the StyleListBox
        /// </summary>
        /// <param name="location">Location to get StyleListBoxItem</param>
        /// <returns>StyleListBoxItem at the given location or NULL if not found.</returns>
        public StyleListBoxItem GetItemFromPoint(Point location) {
            int clickY = location.Y + scroll.Value;
            int itemY = itemFirstVisibleY;
            int itemHeight = 0;

            // find which item that we have clicked
            for (int i = itemFirstVisibleIndex; i <= itemLastVisibleIndex; i++) {
                itemHeight = itemList[i].MeasureItem();

                if ((clickY >= itemY) && (clickY <= itemY + itemHeight)) {
                    return itemList[i];
                }

                itemY += itemHeight;
            }

            return null;
        }

        /// <summary>
        /// Deselects all the selected item in StyleListBox
        /// </summary>
        public void ClearSelected() {
            foreach (StyleListBoxItem item in itemSelectedList) {
                item.SetSelected(false);
            }

            _selectedIndex = -1;
            itemSelectedList.Clear();

            Update();
        }

        /// <summary>
        /// Scroll the list by using mouse wheel
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e) 
        {
            if (!isCanUpdate) {
                return;
            }

            if (e.Delta < 0) {
                ScrollByValue(scroll.SmallChange);
            } else {
                ScrollByValue(-scroll.SmallChange);
            }

            base.OnMouseWheel(e);
        }

        /// <summary>
        /// Redraw the list when list is scrolled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Scroll_OnValueChanged(Object sender, EventArgs e) {
            int change = scroll.Value - lastScrollValue;

            UpdateItemVisibilityByChange(change);

            lastScrollValue = scroll.Value;
            Update();
        }

        protected void Scroll_OnKeyDown(Object sender, KeyEventArgs e) {
            e.Handled = true;
            this.OnKeyDown(e);
        }

        /// <summary>
        /// Upates the first and last visible items in the list by changes
        /// </summary>
        /// <param name="change"></param>
        protected void UpdateItemVisibilityByChange(int change) 
        {
            if (itemList.Count == 0) {
                itemFirstVisibleIndex = 0;
                itemFirstVisibleY = 0;
                return;
            }

            if (change > 0) {
                // increase the first visible item index
                if (scroll.Value > itemFirstVisibleY + itemCacheHeight[itemFirstVisibleIndex]) {
                    for (int i = itemFirstVisibleIndex + 1; i < itemList.Count; i++) {
                        itemFirstVisibleIndex = i;
                        itemFirstVisibleY += itemCacheHeight[i];

                        if (scroll.Value < itemFirstVisibleY + itemCacheHeight[itemFirstVisibleIndex]) {
                            break;
                        }
                    }
                }

                itemLastVisibleIndex = GetLastVisibleItemIndex();
            } else {
                // decrease the first visible item index.
                if (itemFirstVisibleY > scroll.Value) {
                    for (int i = itemFirstVisibleIndex - 1; i >= 0; i--) {
                        itemFirstVisibleIndex = i;
                        itemFirstVisibleY -= itemCacheHeight[i];

                        if (scroll.Value >= itemFirstVisibleY) {
                            break;
                        }
                    }
                }

                itemLastVisibleIndex = GetLastVisibleItemIndex();
            }
        }

        /// <summary>
        /// Gets the index of item that is visible at the end of the list
        /// </summary>
        /// <returns>Index of item that is visible at the end of the list</returns>
        protected int GetLastVisibleItemIndex() {
            int y = itemFirstVisibleY;

            for (int i = itemFirstVisibleIndex; i < itemList.Count; i++) {
                y += itemCacheHeight[i];
                
                if (scroll.Value + this.Height < y) {
                    return i;
                }
            }

            return itemList.Count - 1;
        }

        /// <summary>
        /// Make a scroll by changed value
        /// </summary>
        /// <param name="change">Changed Value</param>
        protected void ScrollByValue(int change) 
        {
            if (scroll.Maximum > 0) {
                int newValue = scroll.Value + change;

                // check whether the new value is valid,
                if (newValue < 0) {
                    newValue = 0;
                } else if (newValue > scroll.Maximum - scroll.LargeChange) {
                    newValue = scroll.Maximum - scroll.LargeChange;
                }

                // check how much change
                change = newValue - scroll.Value;
                scroll.Value = newValue;
            } else {
                scroll.Value = 0;
            }
        }

        protected void UpdateScroll() {
            if (itemTotalHeight - this.Height > 0) {
                if (scroll.Value > itemTotalHeight - this.Height) {
                    scroll.Value = itemTotalHeight - this.Height;
                }

                scroll.Maximum = itemTotalHeight;
                scroll.SmallChange = 20;
                scroll.LargeChange = this.Height;

                scroll.Visible = true;
            } else {
                scroll.Value = 0;
                scroll.Maximum = 0;
                scroll.Visible = false;
            }
        }

        /// <summary>
        /// Update scroll and redraw the list
        /// </summary>
        public new void Update() {
            if (isCanUpdate) {
                UpdateScroll();
                this.Invalidate();
            }
        }

        /// <summary>
        /// Prevents Update() until ResumeUpdate() is called.
        /// </summary>
        public void SuspendUpdate() 
        {
            isCanUpdate = false;   
        }

        /// <summary>
        /// Allows Update() to be called.
        /// 
        /// Note:
        /// ResumeUpdate() does not trigger Update(). If you have made
        /// any changes and need to update, you need to manually
        /// call Update() after.
        /// </summary>
        public void ResumeUpdate() 
        {
            isCanUpdate = true;
        }
    }
}

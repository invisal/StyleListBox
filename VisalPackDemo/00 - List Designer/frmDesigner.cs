using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace VisalPackDemo {
    public partial class frmDesigner : Form {
        public frmDesigner() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            styleListBox1.SuspendUpdate();
            for (int i = 0; i < 100; i++) {
                styleListBox1.Items.Add(new VisalPack.StyleListBoxItem("Hello World " + i.ToString()));
            }
            styleListBox1.ResumeUpdate();
            styleListBox1.Update();
        }

        private void styleListBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (styleListBox1.SelectedItems.Count > 0) {
                propertyGrid2.SelectedObject = styleListBox1.SelectedItems[0];
                propertyGrid2.ExpandAllGridItems();
            }
        }
    }
}

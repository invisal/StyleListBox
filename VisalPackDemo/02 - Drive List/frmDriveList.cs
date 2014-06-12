using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisalPack;

namespace VisalPackDemo {
    public partial class frmDriveList : Form {
        public frmDriveList() {
            InitializeComponent();
        }

        private void frmDriveList_Load(object sender, EventArgs e) {
            styleListBox1.Items.Add(new ListDriveItem("Local Disk (C:)", 0, 300, 100));
            styleListBox1.Items.Add(new ListDriveItem("Local Disk (D:)", 0, 360, 270));
        }
    }
}

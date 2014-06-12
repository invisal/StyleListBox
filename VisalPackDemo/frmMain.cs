using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisalPackDemo {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            styleListBox1.ImageList = imageList1;
            styleListBox1.Items.Add("01 - List Item Designer Demo", 1);
            styleListBox1.Items.Add("02 - Million Items Demo", 1);
            styleListBox1.Items.Add("03 - Hard Drive List Demo", 1);
            styleListBox1.Items.Add("04 - Animation Demo", 2);
        }

        private void styleListBox1_DoubleClick(object sender, EventArgs e) {

        }

        private void styleListBox1_ItemDoubleClicked(object sender, VisalPack.EventItemArgs e) {
            switch (e.Item.Text) {
                case "01 - List Item Designer Demo":
                    new frmDesigner().ShowDialog();
                    break;
                case "02 - Million Items Demo":
                    new frmMillionItem().ShowDialog();
                    break;
                case "03 - Hard Drive List Demo":
                    new frmDriveList().ShowDialog();
                    break;
            }
        }

        private void styleListBox1_ItemClicked(object sender, VisalPack.EventItemArgs e) {
        }
    }
}

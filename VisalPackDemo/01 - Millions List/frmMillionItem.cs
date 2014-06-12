using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisalPackDemo {
    public partial class frmMillionItem : Form {
        public frmMillionItem() {
            InitializeComponent();
        }

        private void frmMillionItem_Load(object sender, EventArgs e) {
            listBox1.BeginUpdate();
            styleListBox1.SuspendUpdate();

            progressBar1.Maximum = 1000000;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            for (int i = 0; i < 1000000; i++) {
                this.Invoke((MethodInvoker) delegate {
                    listBox1.Items.Add("Hello World " + i.ToString());
                    styleListBox1.Items.Add("Hello World " + i.ToString());
                    progressBar1.Value = i + 1;
                });
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            listBox1.EndUpdate();
            styleListBox1.ResumeUpdate();
            styleListBox1.Update();
        }
    }
}

namespace VisalPackDemo {
    partial class frmMillionItem {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            VisalPack.StyleListBoxItemStyle styleListBoxItemStyle1 = new VisalPack.StyleListBoxItemStyle();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.styleListBox1 = new VisalPack.StyleListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(241, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(228, 394);
            this.listBox1.TabIndex = 1;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // styleListBox1
            // 
            this.styleListBox1.BackColor = System.Drawing.Color.White;
            this.styleListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            styleListBoxItemStyle1.BackColor = System.Drawing.Color.White;
            styleListBoxItemStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            styleListBoxItemStyle1.ImageAlignment = VisalPack.StyleItemAlignment.None;
            styleListBoxItemStyle1.Padding = new System.Windows.Forms.Padding(2);
            styleListBoxItemStyle1.SelectedBackColor = System.Drawing.Color.Blue;
            styleListBoxItemStyle1.SelectedTextColor = System.Drawing.Color.White;
            styleListBoxItemStyle1.SelectionStyle = VisalPack.SelectionStyle.Flat;
            styleListBoxItemStyle1.TextAlignment = VisalPack.StyleItemAlignment.None;
            styleListBoxItemStyle1.TextColor = System.Drawing.Color.Black;
            styleListBoxItemStyle1.TextVerticalAlignment = VisalPack.StyleItemVerticalAlignment.None;
            this.styleListBox1.DefaultItemStyle = styleListBoxItemStyle1;
            this.styleListBox1.FocuedIndex = 0;
            this.styleListBox1.ImageList = null;
            this.styleListBox1.Location = new System.Drawing.Point(12, 49);
            this.styleListBox1.Name = "styleListBox1";
            this.styleListBox1.SelectedIndex = -1;
            this.styleListBox1.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.styleListBox1.Size = new System.Drawing.Size(221, 394);
            this.styleListBox1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(458, 31);
            this.progressBar1.TabIndex = 2;
            // 
            // frmMillionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 454);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.styleListBox1);
            this.Name = "frmMillionItem";
            this.Text = "frmMillionItem";
            this.Load += new System.EventHandler(this.frmMillionItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VisalPack.StyleListBox styleListBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
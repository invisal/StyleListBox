namespace VisalPackDemo {
    partial class frmDriveList {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDriveList));
            VisalPack.StyleListBoxItemStyle styleListBoxItemStyle2 = new VisalPack.StyleListBoxItemStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.styleListBox1 = new VisalPack.StyleListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1401821954_drive-harddisk.png");
            // 
            // styleListBox1
            // 
            this.styleListBox1.BackColor = System.Drawing.Color.White;
            styleListBoxItemStyle2.BackColor = System.Drawing.Color.White;
            styleListBoxItemStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            styleListBoxItemStyle2.Padding = new System.Windows.Forms.Padding(2);
            styleListBoxItemStyle2.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            styleListBoxItemStyle2.SelectedTextColor = System.Drawing.Color.Black;
            styleListBoxItemStyle2.SelectionStyle = VisalPack.SelectionStyle.Flat;
            styleListBoxItemStyle2.TextColor = System.Drawing.Color.Black;
            this.styleListBox1.DefaultItemStyle = styleListBoxItemStyle2;
            this.styleListBox1.ImageList = this.imageList1;
            this.styleListBox1.Location = new System.Drawing.Point(7, 7);
            this.styleListBox1.Name = "styleListBox1";
            this.styleListBox1.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.styleListBox1.Size = new System.Drawing.Size(510, 210);
            this.styleListBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.styleListBox1);
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 228);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please select drive that you want to scan";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Scan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmDriveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 313);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmDriveList";
            this.Text = "frmDriveList";
            this.Load += new System.EventHandler(this.frmDriveList_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private VisalPack.StyleListBox styleListBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
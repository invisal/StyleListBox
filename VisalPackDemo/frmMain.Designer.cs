namespace VisalPackDemo {
    partial class frmMain {
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
            VisalPack.StyleListBoxItemStyle styleListBoxItemStyle1 = new VisalPack.StyleListBoxItemStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.styleListBox1 = new VisalPack.StyleListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
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
            this.styleListBox1.Location = new System.Drawing.Point(12, 35);
            this.styleListBox1.Name = "styleListBox1";
            this.styleListBox1.SelectedIndex = -1;
            this.styleListBox1.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.styleListBox1.Size = new System.Drawing.Size(250, 386);
            this.styleListBox1.TabIndex = 0;
            this.styleListBox1.ItemClicked += new System.EventHandler<VisalPack.EventItemArgs>(this.styleListBox1_ItemClicked);
            this.styleListBox1.ItemDoubleClicked += new System.EventHandler<VisalPack.EventItemArgs>(this.styleListBox1_ItemDoubleClicked);
            this.styleListBox1.DoubleClick += new System.EventHandler(this.styleListBox1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Double click to view StyleListBox in action.";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon_circle");
            this.imageList1.Images.SetKeyName(1, "icon_tick");
            this.imageList1.Images.SetKeyName(2, "icon_alert");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 433);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.styleListBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VisalPack.StyleListBox styleListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
    }
}
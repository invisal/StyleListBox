namespace VisalPackDemo {
    partial class frmDesigner {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesigner));
            VisalPack.StyleListBoxItemStyle styleListBoxItemStyle2 = new VisalPack.StyleListBoxItemStyle();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.styleListBox1 = new VisalPack.StyleListBox();
            this.SuspendLayout();
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Location = new System.Drawing.Point(216, 9);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(379, 480);
            this.propertyGrid2.TabIndex = 9;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CallHierarchy.png");
            this.imageList1.Images.SetKeyName(1, "CallsFrom(ambiguous)_8526.png");
            this.imageList1.Images.SetKeyName(2, "CallsTo(ambiguous)_8527.png");
            this.imageList1.Images.SetKeyName(3, "CanvasElement_10701.png");
            this.imageList1.Images.SetKeyName(4, "CatalogZone_6015.png");
            this.imageList1.Images.SetKeyName(5, "cctprojectnode_ID09.png");
            this.imageList1.Images.SetKeyName(6, "cctprojectnode_ID10.png");
            this.imageList1.Images.SetKeyName(7, "CheckBox_669.png");
            this.imageList1.Images.SetKeyName(8, "CheckBoxList_727.png");
            this.imageList1.Images.SetKeyName(9, "Class_489.png");
            this.imageList1.Images.SetKeyName(10, "ClassandMethodreference(ambiguous)_8528.png");
            this.imageList1.Images.SetKeyName(11, "ClassandMethodreference_6228.png");
            this.imageList1.Images.SetKeyName(12, "Class-Friend_491.png");
            this.imageList1.Images.SetKeyName(13, "ClassIcon.png");
            this.imageList1.Images.SetKeyName(14, "Class-Private_493.png");
            // 
            // styleListBox1
            // 
            this.styleListBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.styleListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            styleListBoxItemStyle2.BackColor = System.Drawing.Color.White;
            styleListBoxItemStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleListBoxItemStyle2.ImageAlignment = VisalPack.StyleItemAlignment.None;
            styleListBoxItemStyle2.Padding = new System.Windows.Forms.Padding(2);
            styleListBoxItemStyle2.SelectedBackColor = System.Drawing.Color.Blue;
            styleListBoxItemStyle2.SelectedTextColor = System.Drawing.Color.White;
            styleListBoxItemStyle2.SelectionStyle = VisalPack.SelectionStyle.Inherited;
            styleListBoxItemStyle2.TextAlignment = VisalPack.StyleItemAlignment.None;
            styleListBoxItemStyle2.TextColor = System.Drawing.Color.Black;
            styleListBoxItemStyle2.TextVerticalAlignment = VisalPack.StyleItemVerticalAlignment.None;
            this.styleListBox1.DefaultItemStyle = styleListBoxItemStyle2;
            this.styleListBox1.FocuedIndex = 0;
            this.styleListBox1.ImageList = this.imageList1;
            this.styleListBox1.Location = new System.Drawing.Point(12, 12);
            this.styleListBox1.Name = "styleListBox1";
            this.styleListBox1.Padding = new System.Windows.Forms.Padding(5);
            this.styleListBox1.SelectedIndex = -1;
            this.styleListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.styleListBox1.Size = new System.Drawing.Size(198, 477);
            this.styleListBox1.TabIndex = 2;
            this.styleListBox1.SelectedIndexChanged += new System.EventHandler(this.styleListBox1_SelectedIndexChanged);
            // 
            // frmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 501);
            this.Controls.Add(this.propertyGrid2);
            this.Controls.Add(this.styleListBox1);
            this.Name = "frmDesigner";
            this.Text = "Designer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VisalPack.StyleListBox styleListBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.ImageList imageList1;
    }
}


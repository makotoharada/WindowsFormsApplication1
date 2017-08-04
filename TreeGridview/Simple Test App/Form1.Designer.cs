namespace Simple_Test_App
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            AdvancedDataGridView.TreeGridNode treeGridNode9 = new AdvancedDataGridView.TreeGridNode();
            AdvancedDataGridView.TreeGridNode treeGridNode10 = new AdvancedDataGridView.TreeGridNode();
            AdvancedDataGridView.TreeGridNode treeGridNode11 = new AdvancedDataGridView.TreeGridNode();
            AdvancedDataGridView.TreeGridNode treeGridNode12 = new AdvancedDataGridView.TreeGridNode();
            AdvancedDataGridView.TreeGridNode treeGridNode13 = new AdvancedDataGridView.TreeGridNode();
            AdvancedDataGridView.TreeGridNode treeGridNode14 = new AdvancedDataGridView.TreeGridNode();
            AdvancedDataGridView.TreeGridNode treeGridNode15 = new AdvancedDataGridView.TreeGridNode();
            AdvancedDataGridView.TreeGridNode treeGridNode16 = new AdvancedDataGridView.TreeGridNode();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeGridView1 = new AdvancedDataGridView.TreeGridView();
            this.treeColumn = new AdvancedDataGridView.TreeGridColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeGridView2 = new AdvancedDataGridView.TreeGridView();
            this.colName = new AdvancedDataGridView.TreeGridColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelect = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cdmusic.ico");
            this.imageList1.Images.SetKeyName(1, "cellphone.ico");
            this.imageList1.Images.SetKeyName(2, "CONTACTS.ICO");
            this.imageList1.Images.SetKeyName(3, "delete_16x.ico");
            this.imageList1.Images.SetKeyName(4, "disconnect2.ico");
            this.imageList1.Images.SetKeyName(5, "disconnect3.ico");
            this.imageList1.Images.SetKeyName(6, "document.ico");
            this.imageList1.Images.SetKeyName(7, "error.ico");
            this.imageList1.Images.SetKeyName(8, "GenVideoDoc.ico");
            this.imageList1.Images.SetKeyName(9, "globe.ico");
            this.imageList1.Images.SetKeyName(10, "group.ico");
            this.imageList1.Images.SetKeyName(11, "help.ico");
            this.imageList1.Images.SetKeyName(12, "helpdoc.ico");
            this.imageList1.Images.SetKeyName(13, "homenet.ico");
            this.imageList1.Images.SetKeyName(14, "hotplug.ico");
            this.imageList1.Images.SetKeyName(15, "ICS client.ico");
            // 
            // treeGridView1
            // 
            this.treeGridView1.AllowUserToAddRows = false;
            this.treeGridView1.AllowUserToDeleteRows = false;
            this.treeGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.treeGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.treeColumn,
            this.nameColumn,
            this.descriptionColumn});
            this.treeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.treeGridView1.ImageList = this.imageList1;
            this.treeGridView1.Location = new System.Drawing.Point(405, 267);
            this.treeGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.treeGridView1.Name = "treeGridView1";
            treeGridNode9.Height = 24;
            treeGridNode9.ImageIndex = 0;
            treeGridNode10.Height = 24;
            treeGridNode10.ImageIndex = 11;
            treeGridNode9.Nodes.Add(treeGridNode10);
            treeGridNode11.Height = 24;
            treeGridNode11.ImageIndex = 13;
            treeGridNode12.Height = 24;
            treeGridNode12.ImageIndex = 7;
            treeGridNode13.Height = 24;
            treeGridNode13.ImageIndex = 15;
            treeGridNode14.Height = 24;
            treeGridNode14.ImageIndex = 0;
            treeGridNode15.Height = 24;
            treeGridNode15.ImageIndex = 9;
            treeGridNode16.Height = 24;
            treeGridNode16.ImageIndex = 10;
            treeGridNode15.Nodes.Add(treeGridNode16);
            treeGridNode14.Nodes.Add(treeGridNode15);
            this.treeGridView1.Nodes.Add(treeGridNode9);
            this.treeGridView1.Nodes.Add(treeGridNode11);
            this.treeGridView1.Nodes.Add(treeGridNode12);
            this.treeGridView1.Nodes.Add(treeGridNode13);
            this.treeGridView1.Nodes.Add(treeGridNode14);
            this.treeGridView1.RowHeadersVisible = false;
            this.treeGridView1.Size = new System.Drawing.Size(389, 307);
            this.treeGridView1.TabIndex = 0;
            // 
            // treeColumn
            // 
            this.treeColumn.DefaultNodeImage = null;
            this.treeColumn.HeaderText = "Tree";
            this.treeColumn.Name = "treeColumn";
            this.treeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            this.nameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // treeGridView2
            // 
            this.treeGridView2.AllowUserToAddRows = false;
            this.treeGridView2.AllowUserToDeleteRows = false;
            this.treeGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colValue,
            this.colSelect});
            this.treeGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.treeGridView2.ImageList = null;
            this.treeGridView2.Location = new System.Drawing.Point(21, 37);
            this.treeGridView2.Name = "treeGridView2";
            this.treeGridView2.Size = new System.Drawing.Size(427, 224);
            this.treeGridView2.TabIndex = 1;
            this.treeGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.treeGridView2_CellContentClick);
            // 
            // colName
            // 
            this.colName.DefaultNodeImage = null;
            this.colName.HeaderText = "名前";
            this.colName.Name = "colName";
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "値";
            this.colValue.Name = "colValue";
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "選択";
            this.colSelect.Items.AddRange(new object[] {
            "選択肢A",
            "選択肢B",
            "選択肢C"});
            this.colSelect.Name = "colSelect";
            this.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 600);
            this.Controls.Add(this.treeGridView2);
            this.Controls.Add(this.treeGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdvancedDataGridView.TreeGridView treeGridView1;
        private AdvancedDataGridView.TreeGridColumn treeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.ImageList imageList1;
        private AdvancedDataGridView.TreeGridView treeGridView2;
        private AdvancedDataGridView.TreeGridColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSelect;
    }
}


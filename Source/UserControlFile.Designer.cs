namespace ATWiki {
  partial class UserControlFile {
    /// <summary>
    /// Designer variable used to keep track of non-visual components.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Button buttonNew;
    private System.Windows.Forms.Button buttonOpen;
    private System.Windows.Forms.Button buttonOption;
    private System.Windows.Forms.Button buttonHelp;
    private System.Windows.Forms.Button buttonAbout;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label labelRecent;
    private System.Windows.Forms.Label labelSort;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label labelSearch;
    private System.Windows.Forms.TextBox textBoxFilter;
    private BrightIdeasSoftware.ObjectListView objectListView1;
    private BrightIdeasSoftware.OLVColumn columnName;
    private BrightIdeasSoftware.OLVColumn columnDate;
    private BrightIdeasSoftware.OLVColumn columnSize;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLocation;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemove;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveAll;
    private System.Windows.Forms.Panel panel3;

    /// <summary>
    /// Disposes resources used by the control.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing) {
        if (components != null) {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    /// <summary>
    /// This method is required for Windows Forms designer support.
    /// Do not change the method contents inside the source code editor. The Forms designer might
    /// not be able to load this method if it was changed manually.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlFile));
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemLocation = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.labelTitle = new System.Windows.Forms.Label();
      this.buttonNew = new System.Windows.Forms.Button();
      this.buttonOpen = new System.Windows.Forms.Button();
      this.buttonOption = new System.Windows.Forms.Button();
      this.buttonHelp = new System.Windows.Forms.Button();
      this.buttonAbout = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
      this.columnName = new BrightIdeasSoftware.OLVColumn();
      this.columnDate = new BrightIdeasSoftware.OLVColumn();
      this.columnSize = new BrightIdeasSoftware.OLVColumn();
      this.panel3 = new System.Windows.Forms.Panel();
      this.labelRecent = new System.Windows.Forms.Label();
      this.labelSort = new System.Windows.Forms.Label();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.labelSearch = new System.Windows.Forms.Label();
      this.textBoxFilter = new System.Windows.Forms.TextBox();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
      this.toolStripMenuItemOpen,
      this.toolStripMenuItemLocation,
      this.toolStripMenuItemDelete,
      this.toolStripMenuItemRemove,
      this.toolStripMenuItemRemoveAll});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(262, 144);
      this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
      // 
      // toolStripMenuItemOpen
      // 
      this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
      this.toolStripMenuItemOpen.Size = new System.Drawing.Size(261, 28);
      this.toolStripMenuItemOpen.Text = "Open";
      this.toolStripMenuItemOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpenClick);
      // 
      // toolStripMenuItemLocation
      // 
      this.toolStripMenuItemLocation.Name = "toolStripMenuItemLocation";
      this.toolStripMenuItemLocation.Size = new System.Drawing.Size(261, 28);
      this.toolStripMenuItemLocation.Text = "Go to file location";
      this.toolStripMenuItemLocation.Click += new System.EventHandler(this.ToolStripMenuItemLocationClick);
      // 
      // toolStripMenuItemDelete
      // 
      this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
      this.toolStripMenuItemDelete.Size = new System.Drawing.Size(261, 28);
      this.toolStripMenuItemDelete.Text = "Permanently delete";
      this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDeleteClick);
      // 
      // toolStripMenuItemRemove
      // 
      this.toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
      this.toolStripMenuItemRemove.Size = new System.Drawing.Size(261, 28);
      this.toolStripMenuItemRemove.Text = "Remove this from list";
      this.toolStripMenuItemRemove.Click += new System.EventHandler(this.ToolStripMenuItemRemoveClick);
      // 
      // toolStripMenuItemRemoveAll
      // 
      this.toolStripMenuItemRemoveAll.Name = "toolStripMenuItemRemoveAll";
      this.toolStripMenuItemRemoveAll.Size = new System.Drawing.Size(261, 28);
      this.toolStripMenuItemRemoveAll.Text = "Remove all from list";
      this.toolStripMenuItemRemoveAll.Click += new System.EventHandler(this.ToolStripMenuItemRemoveAllClick);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
      this.panel1.Controls.Add(this.labelTitle);
      this.panel1.Controls.Add(this.buttonNew);
      this.panel1.Controls.Add(this.buttonOpen);
      this.panel1.Controls.Add(this.buttonOption);
      this.panel1.Controls.Add(this.buttonHelp);
      this.panel1.Controls.Add(this.buttonAbout);
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(300, 600);
      this.panel1.TabIndex = 0;
      // 
      // labelTitle
      // 
      this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
      this.labelTitle.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.labelTitle.Location = new System.Drawing.Point(0, 158);
      this.labelTitle.Margin = new System.Windows.Forms.Padding(10);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(300, 50);
      this.labelTitle.TabIndex = 0;
      this.labelTitle.Text = "ATWiki";
      this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // buttonNew
      // 
      this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonNew.BackColor = System.Drawing.Color.Transparent;
      this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonNew.Location = new System.Drawing.Point(30, 228);
      this.buttonNew.Margin = new System.Windows.Forms.Padding(10);
      this.buttonNew.Name = "buttonNew";
      this.buttonNew.Size = new System.Drawing.Size(240, 40);
      this.buttonNew.TabIndex = 1;
      this.buttonNew.Text = "New";
      this.buttonNew.UseVisualStyleBackColor = false;
      this.buttonNew.Click += new System.EventHandler(this.ButtonNewClick);
      // 
      // buttonOpen
      // 
      this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOpen.BackColor = System.Drawing.Color.Transparent;
      this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonOpen.Location = new System.Drawing.Point(30, 288);
      this.buttonOpen.Margin = new System.Windows.Forms.Padding(10);
      this.buttonOpen.Name = "buttonOpen";
      this.buttonOpen.Size = new System.Drawing.Size(240, 40);
      this.buttonOpen.TabIndex = 2;
      this.buttonOpen.Text = "Open";
      this.buttonOpen.UseVisualStyleBackColor = false;
      this.buttonOpen.Click += new System.EventHandler(this.ButtonOpenClick);
      // 
      // buttonOption
      // 
      this.buttonOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOption.BackColor = System.Drawing.Color.Transparent;
      this.buttonOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonOption.Location = new System.Drawing.Point(30, 348);
      this.buttonOption.Margin = new System.Windows.Forms.Padding(10);
      this.buttonOption.Name = "buttonOption";
      this.buttonOption.Size = new System.Drawing.Size(240, 40);
      this.buttonOption.TabIndex = 3;
      this.buttonOption.Text = "Option";
      this.buttonOption.UseVisualStyleBackColor = false;
      this.buttonOption.Click += new System.EventHandler(this.ButtonOptionClick);
      // 
      // buttonHelp
      // 
      this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonHelp.BackColor = System.Drawing.Color.Transparent;
      this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonHelp.Location = new System.Drawing.Point(30, 408);
      this.buttonHelp.Margin = new System.Windows.Forms.Padding(10);
      this.buttonHelp.Name = "buttonHelp";
      this.buttonHelp.Size = new System.Drawing.Size(240, 40);
      this.buttonHelp.TabIndex = 4;
      this.buttonHelp.Text = "Help";
      this.buttonHelp.UseVisualStyleBackColor = true;
      this.buttonHelp.Click += new System.EventHandler(this.ButtonHelpClick);
      // 
      // buttonAbout
      // 
      this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonAbout.BackColor = System.Drawing.Color.Transparent;
      this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonAbout.Location = new System.Drawing.Point(30, 468);
      this.buttonAbout.Margin = new System.Windows.Forms.Padding(10);
      this.buttonAbout.Name = "buttonAbout";
      this.buttonAbout.Size = new System.Drawing.Size(240, 40);
      this.buttonAbout.TabIndex = 5;
      this.buttonAbout.Text = "About";
      this.buttonAbout.UseVisualStyleBackColor = false;
      this.buttonAbout.Click += new System.EventHandler(this.ButtonAboutClick);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
      | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(0, 10);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(300, 128);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.pictureBox1.TabIndex = 29;
      this.pictureBox1.TabStop = false;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Transparent;
      this.panel2.Controls.Add(this.objectListView1);
      this.panel2.Controls.Add(this.panel3);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(300, 0);
      this.panel2.Margin = new System.Windows.Forms.Padding(0);
      this.panel2.Name = "panel2";
      this.panel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.panel2.Size = new System.Drawing.Size(724, 600);
      this.panel2.TabIndex = 0;
      // 
      // objectListView1
      // 
      this.objectListView1.AllColumns.Add(this.columnName);
      this.objectListView1.AllColumns.Add(this.columnDate);
      this.objectListView1.AllColumns.Add(this.columnSize);
      this.objectListView1.BackColor = System.Drawing.SystemColors.Window;
      this.objectListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.objectListView1.CellEditUseWholeCell = false;
      this.objectListView1.CheckedAspectName = "";
      this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
      this.columnName,
      this.columnDate,
      this.columnSize});
      this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
      this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.objectListView1.FullRowSelect = true;
      this.objectListView1.Location = new System.Drawing.Point(10, 44);
      this.objectListView1.Margin = new System.Windows.Forms.Padding(15);
      this.objectListView1.MultiSelect = false;
      this.objectListView1.Name = "objectListView1";
      this.objectListView1.OverlayText.BorderWidth = 2F;
      this.objectListView1.OverlayText.Text = "";
      this.objectListView1.ShowGroups = false;
      this.objectListView1.ShowHeaderInAllViews = false;
      this.objectListView1.ShowItemToolTips = true;
      this.objectListView1.Size = new System.Drawing.Size(714, 556);
      this.objectListView1.TabIndex = 1;
      this.objectListView1.UseCompatibleStateImageBehavior = false;
      this.objectListView1.UseFiltering = true;
      this.objectListView1.UseHotItem = true;
      this.objectListView1.UseTranslucentHotItem = true;
      this.objectListView1.UseTranslucentSelection = true;
      this.objectListView1.View = System.Windows.Forms.View.Details;
      this.objectListView1.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.ObjectListView1CellClick);
      this.objectListView1.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.ObjectListView1CellRightClick);
      this.objectListView1.SizeChanged += new System.EventHandler(this.ObjectListView1SizeChanged);
      // 
      // columnName
      // 
      this.columnName.AspectName = "Name";
      this.columnName.MinimumWidth = 40;
      this.columnName.Text = "Name";
      this.columnName.ToolTipText = "";
      this.columnName.Width = 400;
      // 
      // columnDate
      // 
      this.columnDate.AspectName = "Date";
      this.columnDate.MinimumWidth = 40;
      this.columnDate.Text = "Date";
      this.columnDate.ToolTipText = "";
      this.columnDate.Width = 400;
      // 
      // columnSize
      // 
      this.columnSize.AspectName = "Size";
      this.columnSize.MinimumWidth = 40;
      this.columnSize.Text = "Size";
      this.columnSize.ToolTipText = "";
      this.columnSize.Width = 400;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.labelRecent);
      this.panel3.Controls.Add(this.labelSort);
      this.panel3.Controls.Add(this.comboBox1);
      this.panel3.Controls.Add(this.labelSearch);
      this.panel3.Controls.Add(this.textBoxFilter);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel3.Location = new System.Drawing.Point(10, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(714, 44);
      this.panel3.TabIndex = 1;
      // 
      // labelRecent
      // 
      this.labelRecent.AutoSize = true;
      this.labelRecent.Location = new System.Drawing.Point(8, 13);
      this.labelRecent.Margin = new System.Windows.Forms.Padding(8, 13, 8, 8);
      this.labelRecent.Name = "labelRecent";
      this.labelRecent.Size = new System.Drawing.Size(152, 18);
      this.labelRecent.TabIndex = 0;
      this.labelRecent.Text = "Recent Documents";
      // 
      // labelSort
      // 
      this.labelSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.labelSort.AutoSize = true;
      this.labelSort.Location = new System.Drawing.Point(273, 13);
      this.labelSort.Margin = new System.Windows.Forms.Padding(8, 13, 8, 8);
      this.labelSort.Name = "labelSort";
      this.labelSort.Size = new System.Drawing.Size(44, 18);
      this.labelSort.TabIndex = 1;
      this.labelSort.Text = "Sort";
      // 
      // comboBox1
      // 
      this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.comboBox1.BackColor = System.Drawing.Color.LightSkyBlue;
      this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[] {
      "Name▲",
      "Name▼",
      "Date▲",
      "Date▼",
      "Size▲",
      "Size▼"});
      this.comboBox1.Location = new System.Drawing.Point(345, 9);
      this.comboBox1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 8);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(115, 26);
      this.comboBox1.TabIndex = 2;
      this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.ComboBox1SelectionChangeCommitted);
      // 
      // labelSearch
      // 
      this.labelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.labelSearch.AutoSize = true;
      this.labelSearch.Location = new System.Drawing.Point(485, 13);
      this.labelSearch.Margin = new System.Windows.Forms.Padding(20, 13, 8, 8);
      this.labelSearch.Name = "labelSearch";
      this.labelSearch.Size = new System.Drawing.Size(62, 18);
      this.labelSearch.TabIndex = 3;
      this.labelSearch.Text = "Search";
      // 
      // textBoxFilter
      // 
      this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxFilter.BackColor = System.Drawing.Color.LightSkyBlue;
      this.textBoxFilter.Location = new System.Drawing.Point(557, 8);
      this.textBoxFilter.Margin = new System.Windows.Forms.Padding(8, 8, 20, 8);
      this.textBoxFilter.Name = "textBoxFilter";
      this.textBoxFilter.Size = new System.Drawing.Size(150, 28);
      this.textBoxFilter.TabIndex = 4;
      this.textBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilterTextChanged);
      // 
      // UserControlFile
      // 
      this.BackColor = System.Drawing.SystemColors.Window;
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "UserControlFile";
      this.Size = new System.Drawing.Size(1024, 600);
      this.Load += new System.EventHandler(this.UserControlFileLoad);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);

    }
  }
}

namespace ATWiki
{
  partial class MainForm
  {
    /// <summary>
    /// Designer variable used to keep track of non-visual components.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
    private System.Windows.Forms.WebBrowser webBrowser1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNew;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.Panel panelFile;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
    
    /// <summary>
    /// Disposes resources used by the form.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
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
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.toolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.panelFile = new System.Windows.Forms.Panel();
      this.menuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
      this.toolStripMenuItemNew,
      this.toolStripMenuItemOpen,
      this.toolStripMenuItemHelp,
      this.toolStripMenuItemAbout});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1002, 32);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // toolStripMenuItemNew
      // 
      this.toolStripMenuItemNew.Name = "toolStripMenuItemNew";
      this.toolStripMenuItemNew.Size = new System.Drawing.Size(61, 28);
      this.toolStripMenuItemNew.Text = "New";
      this.toolStripMenuItemNew.Click += new System.EventHandler(this.ToolStripMenuItemNewClick);
      // 
      // toolStripMenuItemOpen
      // 
      this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
      this.toolStripMenuItemOpen.Size = new System.Drawing.Size(70, 28);
      this.toolStripMenuItemOpen.Text = "Open";
      this.toolStripMenuItemOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpenClick);
      // 
      // toolStripMenuItemHelp
      // 
      this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
      this.toolStripMenuItemHelp.Size = new System.Drawing.Size(63, 28);
      this.toolStripMenuItemHelp.Text = "Help";
      this.toolStripMenuItemHelp.Click += new System.EventHandler(this.ToolStripMenuItemHelpClick);
      // 
      // toolStripMenuItemAbout
      // 
      this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
      this.toolStripMenuItemAbout.Size = new System.Drawing.Size(76, 28);
      this.toolStripMenuItemAbout.Text = "About";
      this.toolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAboutClick);
      // 
      // webBrowser1
      // 
      this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowser1.Location = new System.Drawing.Point(0, 32);
      this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.Size = new System.Drawing.Size(1002, 512);
      this.webBrowser1.TabIndex = 1;
      this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1DocumentCompleted);
      this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowser1Navigated);
      this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebBrowser1Navigating);
      this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.WebBrowser1ProgressChanged);
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "html";
      this.openFileDialog1.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.panel1.Controls.Add(this.label1);
      this.panel1.Location = new System.Drawing.Point(690, 452);
      this.panel1.MaximumSize = new System.Drawing.Size(300, 80);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(300, 80);
      this.panel1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(10);
      this.label1.Size = new System.Drawing.Size(300, 80);
      this.label1.TabIndex = 0;
      this.label1.Text = "label1\r\n123";
      this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "html";
      this.saveFileDialog1.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
      // 
      // panelFile
      // 
      this.panelFile.Location = new System.Drawing.Point(690, 350);
      this.panelFile.Name = "panelFile";
      this.panelFile.Size = new System.Drawing.Size(300, 80);
      this.panelFile.TabIndex = 3;
      // 
      // MainForm
      // 
      this.ClientSize = new System.Drawing.Size(1002, 544);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panelFile);
      this.Controls.Add(this.webBrowser1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(1024, 600);
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "ATWiki";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
      this.Shown += new System.EventHandler(this.MainFormShown);
      this.LocationChanged += new System.EventHandler(this.MainFormLocationChanged);
      this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }
  }
}

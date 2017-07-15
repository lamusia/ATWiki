using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using BrightIdeasSoftware;

namespace ATWiki {
  /// <summary>
  /// Description of UserControl1.
  /// </summary>
  public partial class UserControlFile : UserControl {
    public UserControlFile() {
      //
      // The InitializeComponent() call is required for Windows Forms designer support.
      //
      InitializeComponent();
      
      comboBox1.Items.Clear();
      comboBox1.Items.AddRange(new object[] {
        Program.i18n.GetString("Name") + "▲",
        Program.i18n.GetString("Name") + "▼",
        Program.i18n.GetString("Date") + "▲",
        Program.i18n.GetString("Date") + "▼",
        Program.i18n.GetString("Size") + "▲",
        Program.i18n.GetString("Size") + "▼"
      });
      
      // 语言&缩放
      this.Size = new System.Drawing.Size(
        this.Size.Width * Program.dpiZoom / 100,
        this.Size.Height * Program.dpiZoom / 100);
      Program.i18n.UpdateControls(this.Controls);
      Program.i18n.UpdateMenus(this.contextMenuStrip1.Items);
      this.textBoxFilter.Location = new System.Drawing.Point(
        this.panel3.Size.Width - this.textBoxFilter.Size.Width - 8 * Program.dpiZoom / 100,
        this.textBoxFilter.Location.Y);
      this.labelSearch.Location = new System.Drawing.Point(
        this.textBoxFilter.Location.X - this.labelSearch.Size.Width - 8 * Program.dpiZoom / 100,
        this.labelSearch.Location.Y);
      this.comboBox1.Location = new System.Drawing.Point(
        this.labelSearch.Location.X - this.comboBox1.Size.Width - 20 * Program.dpiZoom / 100,
        this.comboBox1.Location.Y);
      this.labelSort.Location = new System.Drawing.Point(
        this.comboBox1.Location.X - this.labelSort.Size.Width - 8 * Program.dpiZoom / 100,
        this.labelSort.Location.Y);
      
    }
    void UserControlFileLoad(object sender, EventArgs e) {
      // 设置 Renderer
      this.columnName.Renderer = myRenderer();
      // 标题使用的属性
      this.columnName.AspectName = "Name";
      // 图像使用的属性
      this.columnName.ImageAspectName = "Image";
      // 行高
      this.objectListView1.RowHeight = 54;
      // 设置属性
      this.objectListView1.EmptyListMsg = Program.i18n.GetString("No thing to show");
      this.objectListView1.UseAlternatingBackColors = false;
      // Put a little bit of space around the task and its description
      // this.columnName.CellPadding = new Rectangle(4, 2, 4, 2);
      // Add a more interesting focus for editing operations
      // this.objectListView1.AddDecoration(new BorderDecoration(new Pen(Color.FromArgb(64, Color.Blue), 10)));
      // 设置表头
      columnName.Text = "File list";
      columnDate.IsVisible = false;
      columnSize.IsVisible = false;
      objectListView1.HeaderMaximumHeight = 0;
      objectListView1.RebuildColumns();
      
      // 创建并显示列表
      buildListView();
      
      // 设置排序
      var sortType = Program.mainForm.sortType;
      //Console.WriteLine("sortType : " + sortType + " - " + sortType.Length.ToString());
      comboBox1.Text = Program.i18n.GetString(sortType.Substring(0, sortType.Length - 1)) + sortType.Substring(sortType.Length - 1);
      ComboBox1SelectionChangeCommitted(null, null);
    }
    
    void ButtonNewClick(object sender, EventArgs e) {
      Program.mainForm.ToolStripMenuItemNewClick(sender, e);
    }
    void ButtonOpenClick(object sender, EventArgs e) {
      Program.mainForm.ToolStripMenuItemOpenClick(sender, e);
    }
    void ButtonHelpClick(object sender, EventArgs e) {
      Program.mainForm.ToolStripMenuItemHelpClick(sender, e);
    }
    void ButtonAboutClick(object sender, EventArgs e) {
      Program.mainForm.ToolStripMenuItemAboutClick(sender, e);
    }
    
    private void buildListView() {
      var listObjects = new List<ListObject>();
      foreach (var filename in Program.mainForm.filelist) {
        string date = "????-??-?? ??:??";
        long size = 0;
        if (File.Exists(filename)) {
          System.IO.FileInfo file = new System.IO.FileInfo(filename);
          size = file.Length;
          date = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm");
        }
        listObjects.Add(new ListObject(filename, "icon1", date, size));
      }
      this.objectListView1.SetObjects(listObjects);
    }
    private DescribedTaskRenderer myRenderer() {
      // Let's create an appropriately configured renderer.
      var renderer = new DescribedTaskRenderer();

      // Give the renderer its own collection of images.
      // If this isn't set, the renderer will use the SmallImageList from the ObjectListView.
      // (this is standard Renderer behaviour, not specific to DescribedTaskRenderer).
      renderer.ImageList = this.imageList1;

      // Tell the renderer which property holds the text to be used as a description
      renderer.DescriptionAspectName = "Description";

      // 设置格式
      renderer.TitleFont = new Font(labelSort.Font.FontFamily.Name, 14, FontStyle.Bold);
      renderer.DescriptionFont = new Font(labelSort.Font.FontFamily.Name, 9);
      renderer.ImageTextSpace = 8;
      renderer.TitleDescriptionSpace = 1;

      // 设置颜色
      renderer.TitleColor = Color.DarkBlue;
      renderer.DescriptionColor = Color.CornflowerBlue;

      // Use older Gdi renderering, since most people think the text looks clearer
      renderer.UseGdiTextRendering = true;

      return renderer;
    }
    void ComboBox1SelectionChangeCommitted(object sender, EventArgs e) {
      if (comboBox1.Text.Contains(Program.i18n.GetString("Name"))) {
        objectListView1.PrimarySortColumn = columnName;
        Program.mainForm.sortType = "Name";
      }
      if (comboBox1.Text.Contains(Program.i18n.GetString("Date"))) {
        objectListView1.PrimarySortColumn = columnDate;
        Program.mainForm.sortType = "Date";
      }
      if (comboBox1.Text.Contains(Program.i18n.GetString("Size"))) {
        objectListView1.PrimarySortColumn = columnSize;
        Program.mainForm.sortType = "Size";
      }
      
      if (comboBox1.Text.Contains("▲")) {
        objectListView1.PrimarySortOrder = SortOrder.Ascending;
        Program.mainForm.sortType += "▲";
      }
      if (comboBox1.Text.Contains("▼")) {
        objectListView1.PrimarySortOrder = SortOrder.Descending;
        Program.mainForm.sortType += "▼";
      }
      
      objectListView1.Sort();
    }
    void TextBoxFilterTextChanged(object sender, EventArgs e) {
      // 过滤器
      var filters = new List<IModelFilter>();

      if (!String.IsNullOrEmpty(this.textBoxFilter.Text))
        filters.Add(new TextMatchFilter(this.objectListView1, this.textBoxFilter.Text));

      this.objectListView1.AdditionalFilter = filters.Count == 0 ? null : new CompositeAllFilter(filters);
    }
    
    void ObjectListView1SizeChanged(object sender, EventArgs e) {
      columnName.Width = objectListView1.Width - 22 * Program.dpiZoom / 100;
      //columnName.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
    }
    void ObjectListView1CellClick(object sender, CellClickEventArgs e) {
      if (objectListView1.SelectedItems.Count < 1) {
        return;
      }
      if (e.ClickCount == 2) {
        ToolStripMenuItemOpenClick(null, null);
      }
    }
    void ObjectListView1CellRightClick(object sender, CellRightClickEventArgs e) {
      e.MenuStrip = this.contextMenuStrip1;
    }
    
    void ContextMenuStrip1Opening(object sender, CancelEventArgs e) {
      if (objectListView1.SelectedIndex < 0) {
        toolStripMenuItemOpen.Enabled = false;
        toolStripMenuItemLocation.Enabled = false;
        toolStripMenuItemDelete.Enabled = false;
        toolStripMenuItemRemove.Enabled = false;
        toolStripMenuItemRemoveAll.Enabled = true;
      } else {
        toolStripMenuItemOpen.Enabled = true;
        toolStripMenuItemLocation.Enabled = true;
        toolStripMenuItemDelete.Enabled = true;
        toolStripMenuItemRemove.Enabled = true;
        toolStripMenuItemRemoveAll.Enabled = true;
      }
    }
    void ToolStripMenuItemOpenClick(object sender, EventArgs e) {
      string filename = objectListView1.SelectedItem.Text;

      if (!File.Exists(filename)) {
        MessageBox.Show(Program.i18n.GetString("Can not open file : ") + filename);
        return;
      }
      
      System.IO.FileInfo file = new System.IO.FileInfo(filename);
      filename = file.FullName;
      // Console.WriteLine("open : " + objectListView1.SelectedIndex + " - " + filename);
      Program.mainForm.openFile(filename);
    }
    void ToolStripMenuItemLocationClick(object sender, EventArgs e) {
      string filename = objectListView1.SelectedItem.Text;

      if (!File.Exists(filename)) {
        MessageBox.Show(Program.i18n.GetString("Can not open file location : ") + filename);
        return;
      }
      
      System.IO.FileInfo file = new System.IO.FileInfo(filename);
      filename = file.FullName;
      
      System.Diagnostics.Process.Start("Explorer.exe", @"/select," + filename);
    }
    void ToolStripMenuItemDeleteClick(object sender, EventArgs e) {
      string filename = objectListView1.SelectedItem.Text;
      
      var result = MessageBox.Show(Program.i18n.GetString("Delete file : ") + filename,
                     Program.i18n.GetString("Really delete? This can not be undo."),
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
      if (result != DialogResult.OK) {
        return;
      }
      
      if (!File.Exists(filename)) {
        MessageBox.Show(Program.i18n.GetString("Can not delete file : ") + filename);
        return;
      }
      
      Program.mainForm.filelist.Remove(objectListView1.SelectedItem.Text);
      buildListView();
      
      System.IO.FileInfo file = new System.IO.FileInfo(filename);
      filename = file.FullName;
      File.Delete(filename);
    }
    void ToolStripMenuItemRemoveClick(object sender, EventArgs e) {
      Program.mainForm.filelist.Remove(objectListView1.SelectedItem.Text);
      buildListView();
    }
    void ToolStripMenuItemRemoveAllClick(object sender, EventArgs e) {
      Program.mainForm.filelist.Clear();
      buildListView();
    }
  }
  
  /// <summary>
  /// Dumb model class
  /// </summary>
  public class ListObject {
    public string Name;
    public string Image;
    public string Description;
    public string Date;
    public long Size;
    
    public ListObject(string name, string image, string date, long size) {
      this.Name = name;
      this.Image = image;
      this.Description = date + "    " + Utility.GetFileSize(size);
      this.Date = date;
      this.Size = size;
    }
  }
}

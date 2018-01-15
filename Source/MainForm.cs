using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Resources;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ATWiki {
  /// <summary>
  /// Description of MainForm.
  /// </summary>
  public partial class MainForm : Form {
    public string sortType = "Name▲";
    public List<string> filelist = new List<string>();
    public string filename = "";
    public bool backupEnable = false;
    public bool backupOverwrite = false;
    public string backupFilename = "<folder>\\<filename>.<fyear>-<fmonth>-<fday>.<fileext>";

    private string[] args = null;
    private Rectangle oldBounds;

    private Timer timer;
    private int timerStatus = 0;
    private int timerCount = 0;
    private UserControlFile userControlFile;

    private bool zoomed = false;

    public MainForm(string[] args) {
      // The InitializeComponent() call is required for Windows Forms designer support.
      InitializeComponent();

      // 初始化
      this.args = args;
      timer = new Timer();
      timer.Interval = 20;
      timer.Tick += timer_Tick;

      // 菜单
      menuStrip1.Visible = false;
      userControlFile = new UserControlFile();
      userControlFile.Dock = DockStyle.Fill;
      panelFile.Controls.Add(userControlFile);
      panelFile.Dock = DockStyle.Fill;
      panelFile.Visible = true;

      // 提示
      panel1.Visible = false;
      //label1.Dock = DockStyle.None;

      // 语言&缩放
      this.Size = new System.Drawing.Size(
        this.Size.Width * Program.dpiZoom / 100,
        this.Size.Height * Program.dpiZoom / 100);
      this.MinimumSize = new System.Drawing.Size(
        this.MinimumSize.Width * Program.dpiZoom / 100,
        this.MinimumSize.Height * Program.dpiZoom / 100);
      Program.i18n.UpdateControls(this.Controls);
      this.panel1.Location = new System.Drawing.Point(
        this.ClientRectangle.Width - this.panel1.Size.Width - 30 * Program.dpiZoom / 100,
        this.ClientRectangle.Height - this.panel1.Size.Height - 30 * Program.dpiZoom / 100);

      // 读取 option.xml
      var xmlOption = new XmlDocument();
      try {
        xmlOption.Load(Path.GetDirectoryName(Application.ExecutablePath) + "\\option.xml");

        XmlNode xmlNode = xmlOption.GetElementsByTagName("position")[0];
        if (xmlNode != null) {
          if (xmlNode.Attributes["x"] != null)
            this.Left = Convert.ToInt32(xmlNode.Attributes["x"].Value);
          if (xmlNode.Attributes["y"] != null)
            this.Top = Convert.ToInt32(xmlNode.Attributes["y"].Value);
          if (xmlNode.Attributes["w"] != null)
            this.Width = Convert.ToInt32(xmlNode.Attributes["w"].Value);
          if (xmlNode.Attributes["h"] != null)
            this.Height = Convert.ToInt32(xmlNode.Attributes["h"].Value);
          if (xmlNode.Attributes["s"] != null)
          if (xmlNode.Attributes["s"].Value == Convert.ToString(FormWindowState.Maximized))
            this.WindowState = FormWindowState.Maximized;
        }

        xmlNode = xmlOption.GetElementsByTagName("filelist")[0];
        if (xmlNode != null) {
          if (xmlNode.Attributes["sort"] != null) {
            string asortType = xmlNode.Attributes["sort"].Value;
            List<string> sortTypes = new List<string> {
              "Name▲",
              "Name▼",
              "Date▲",
              "Date▼",
              "Size▲",
              "Size▼"
            };
            if (sortTypes.Contains(asortType))
              sortType = asortType;
          }

          XmlNodeList xfilelist = xmlNode.ChildNodes;
          for (int i = 0; i < xfilelist.Count; i++) {
            filelist.Add(xfilelist[i].InnerText);
          }
        }

        xmlNode = xmlOption.GetElementsByTagName("backup")[0];
        if (xmlNode != null) {
          if (xmlNode.Attributes["enable"] != null)
            backupEnable = Convert.ToBoolean(xmlNode.Attributes["enable"].Value);
          if (xmlNode.Attributes["overwrite"] != null)
            backupOverwrite = Convert.ToBoolean(xmlNode.Attributes["overwrite"].Value);
          if (xmlNode.Attributes["filename"] != null)
            backupFilename = xmlNode.Attributes["filename"].Value;
        }
      } catch (Exception ex) {
        Console.WriteLine("Broken option.xml : " + ex.Message);
      }
      oldBounds.X = this.Left;
      oldBounds.Y = this.Top;
      oldBounds.Width = this.Width;
      oldBounds.Height = this.Height;

      // JavaScript调用C#
      this.webBrowser1.ObjectForScripting = new WebInterface();
    }
    void MainFormShown(object sender, EventArgs e) {
      if (args.Length > 0 && File.Exists(args[0])) {
        openFile(args[0]);
      }
    }
    void MainFormLocationChanged(object sender, EventArgs e) {
      MainFormSizeChanged(sender, e);
    }
    void MainFormSizeChanged(object sender, EventArgs e) {
      if (this.WindowState == FormWindowState.Normal) {
        oldBounds.X = this.Left;
        oldBounds.Y = this.Top;
        oldBounds.Width = this.Width;
        oldBounds.Height = this.Height;
      }
    }
    void MainFormFormClosing(object sender, FormClosingEventArgs e) {
      // 检查状态
      if (webBrowser1.Document != null) {
        object jsObject = webBrowser1.Document.InvokeScript("JsInterface_confirmExit", new object[]{ });
        if (jsObject != null) {
          var result = MessageBox.Show(jsObject.ToString(),
                         Program.i18n.GetString("Really exit?"),
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
          if (result != DialogResult.OK) {
            e.Cancel = true; // 不退出
            return;
          }
        }
      }

      // 写入 option.xml
      var xmlOption = new XmlDocument();
      XmlElement eOption = xmlOption.CreateElement("option");

      XmlElement ePosition = xmlOption.CreateElement("position");
      ePosition.SetAttribute("x", Convert.ToString(oldBounds.X));
      ePosition.SetAttribute("y", Convert.ToString(oldBounds.Y));
      ePosition.SetAttribute("w", Convert.ToString(oldBounds.Width));
      ePosition.SetAttribute("h", Convert.ToString(oldBounds.Height));
      ePosition.SetAttribute("s", Convert.ToString(this.WindowState));
      eOption.AppendChild(ePosition);

      XmlElement efilelist = xmlOption.CreateElement("filelist");
      efilelist.SetAttribute("sort", sortType);
      for (int i = 0; i < filelist.Count; i++) {
        var eitem = xmlOption.CreateElement("item");
        eitem.InnerText = filelist[i];
        efilelist.AppendChild(eitem);
      }
      eOption.AppendChild(efilelist);

      XmlElement ebackup = xmlOption.CreateElement("backup");
      ebackup.SetAttribute("enable", Convert.ToString(backupEnable));
      ebackup.SetAttribute("overwrite", Convert.ToString(backupOverwrite));
      ebackup.SetAttribute("filename", backupFilename);
      eOption.AppendChild(ebackup);

      xmlOption.AppendChild(eOption);
      xmlOption.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\option.xml");
    }

    public void ToolStripMenuItemNewClick(object sender, EventArgs e) {
      if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
        return;

      string afilename = this.saveFileDialog1.FileName;

      // 写文件
      /*
      var resourceManager = new ResourceManager("Properties", typeof(Program).Assembly);
      var content = resourceManager.GetObject("empty.html") as byte[];
      */
      var stream = GetType().Assembly.GetManifestResourceStream("ATWiki.Properties.empty.html");
      var buffer = new byte[stream.Length];
      stream.Read(buffer, 0, buffer.Length);
      stream.Close();

      var fileStream = new FileStream(afilename, FileMode.CreateNew, FileAccess.Write);
      fileStream.Write(buffer, 0, buffer.Length);
      fileStream.Flush();
      fileStream.Close();

      // 打开
      openFile(afilename);
    }
    public void ToolStripMenuItemOpenClick(object sender, EventArgs e) {
      if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
        openFile(this.openFileDialog1.FileName);
    }
    public void ToolStripMenuItemOptionClick(object sender, EventArgs e) {
      var stream = GetType().Assembly.GetManifestResourceStream("ATWiki.Properties." + Program.i18n.GetString("option.html"));
      stream.Position = 0;
      var reader = new StreamReader(stream);
      string text = reader.ReadToEnd();
      openText(text);
    }
    public void ToolStripMenuItemHelpClick(object sender, EventArgs e) {
      var stream = GetType().Assembly.GetManifestResourceStream("ATWiki.Properties." + Program.i18n.GetString("help.html"));
      stream.Position = 0;
      var reader = new StreamReader(stream);
      string text = reader.ReadToEnd();
      openText(text);
    }
    public void ToolStripMenuItemAboutClick(object sender, EventArgs e) {
      //MessageBox.Show(Program.sTitle + " " + Program.sVersion);
      var stream = GetType().Assembly.GetManifestResourceStream("ATWiki.Properties." + Program.i18n.GetString("about.html"));
      stream.Position = 0;
      var reader = new StreamReader(stream);
      string text = reader.ReadToEnd();
      openText(text);
    }

    void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e) {
      // Console.WriteLine(e.Url);
    }
    void WebBrowser1Navigating(object sender, WebBrowserNavigatingEventArgs e) {
      // Console.WriteLine(e.Url);
    }
    void WebBrowser1ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) {
      // Console.WriteLine(e.CurrentProgress + "/" + e.MaximumProgress);

      if (e.CurrentProgress == e.MaximumProgress) {
        object jsObject = webBrowser1.Document.InvokeScript("eval", new object[] {
          "typeof(ATWikiSaver)"
        });
        if (jsObject.ToString() != "undefined") {
          return;
        }

        // 设置 WebInterface
        webBrowser1.Document.InvokeScript("eval", new object[] {
          "ATWikiSaver = function(text,method,callback) {"
          + "  callback(null);"
          + "  return window.external.saveFile(document.location.pathname.substr(1), text);"
          + "};"
          + "function addSaver() {"
          + "  if (typeof($tw) != 'undefined' && typeof($tw.saverHandler) != 'undefined' && typeof($tw.saverHandler.savers) != 'undefined') {"
          //+ "    alert('addSaver');"
          + "    $tw.saverHandler.savers.push({"
          + "      info: {"
          + "        name: 'ATWiki-saver',"
          + "        priority: 5000,"
          + "        capabilities: ['save', 'autosave']"
          + "      },"
          + "      save: ATWikiSaver"
          + "    });"
          + "  } else {"
          + "    setTimeout(addSaver, 200);"
          + "  }"
          + "}"
          + "addSaver();"
        });

        // 设置 JsInterface
        this.webBrowser1.Document.InvokeScript("eval", new object[] {
          "JsInterface_confirmExit = function() {"
          + "if (window.onbeforeunload) {"
          + "  return(window.onbeforeunload());"
          + "} else {"
          + "  return('" + Program.i18n.GetString("If there are any unsaved changes, they will lost.") + "');"
          + "}"
          + "}"
        });
      }
    }
    void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
      // Console.WriteLine("WebBrowser1DocumentCompleted");

      // 设置 DPI
      /*
      var wb = (dynamic)this.webBrowser1.GetType().GetField("axIWebBrowser2",
                 BindingFlags.Instance | BindingFlags.NonPublic)
              .GetValue(this.webBrowser1);
      //int zoomLevel = 150; // Between 10 and 1000
      wb.ExecWB(63, 2, zoomLevel, ref zoomLevel);
      */
      if (!zoomed) {
        zoomed = true;
        this.webBrowser1.Focus();
        if (this.webBrowser1.Document != null) {
          this.webBrowser1.Document.Focus();
          if (this.webBrowser1.Document.Body != null) {
            this.webBrowser1.Document.Body.Focus();
          }
        }
        SendKeys.SendWait("^0");

        if (Program.dpiZoom <= 50)
          SendKeys.SendWait("^-");
        if (50 < Program.dpiZoom && Program.dpiZoom <= 75)
          SendKeys.SendWait("^-");

        if (75 < Program.dpiZoom && Program.dpiZoom <= 100)
          SendKeys.SendWait("^0");

        if (100 < Program.dpiZoom)
          SendKeys.SendWait("^=");
        if (125 < Program.dpiZoom)
          SendKeys.SendWait("^=");
        if (150 < Program.dpiZoom)
          SendKeys.SendWait("^=");
        if (175 < Program.dpiZoom)
          SendKeys.SendWait("^=");
        if (200 < Program.dpiZoom)
          SendKeys.SendWait("^=");
        if (250 < Program.dpiZoom)
          SendKeys.SendWait("^=");
        if (300 < Program.dpiZoom)
          SendKeys.SendWait("^=");

        SendKeys.SendWait("{HOME}");
        //webBrowser1.Document.Window.ScrollTo(0, webBrowser1.Document.Body.ScrollRectangle.Height);
      }
      // 标题
      this.Text = (sender as WebBrowser).DocumentTitle;
    }
    void webBrowser1DocumentTitleChanged(object sender, EventArgs e) {
      // 标题
      this.Text = (sender as WebBrowser).DocumentTitle;
    }

    void timer_Tick(object sender, EventArgs e) {
      timerCount += 1;
      if (timerStatus == 0) { // 显示
        panel1.Height = 10 * timerCount;
        if (panel1.Height == panel1.MaximumSize.Height) {
          timerStatus++;
          timerCount = 0;
        }
      } else if (timerStatus == 1) { // 等待
        if (timerCount == 50 * 2) {
          timerStatus++;
          timerCount = 0;
        }
      } else if (timerStatus == 2) { // 隐藏
        panel1.Height = panel1.MaximumSize.Height - 10 * timerCount;
        if (panel1.Height == 0) {
          panel1.Visible = false;
          timerStatus = 0;
          timerCount = 0;
          timer.Stop();
        }
      }
    }

    // ============  ============
    public void openFile(string afilename) {
      if (!File.Exists(afilename)) {
        MessageBox.Show(Program.i18n.GetString("Can not open file : ") + afilename);
        return;
      }
      filename = afilename;
      webBrowser1.Navigate(new Uri(afilename));
      panelFile.Visible = false;

      //this.userControlFile.Dispose();
      //this.panelFile.Dispose();
      //GC.Collect();

      if (!filelist.Contains(afilename))
        filelist.Add(afilename);
    }
    public void openText(string HTML) {
      webBrowser1.DocumentText = HTML;
      panelFile.Visible = false;
    }
    public void showTip() { // 显示提示
      label1.Text = Program.i18n.GetString("Saved to : ") + "\r\n" + filename;
      panel1.Height = 0;
      panel1.Visible = true;
      timerStatus = 0;
      timerCount = 0;
      timer.Start();
    }
    public void showPanelFile() { // 文件面板
      //menuStrip1.Visible = true;
      panelFile.Visible = true;
      this.Text = Program.sTitle;
      zoomed = false;

      this.Controls.Remove(this.webBrowser1);
      this.webBrowser1.Dispose();
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.webBrowser1.Dock = DockStyle.Fill;
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.ObjectForScripting = new WebInterface();
      this.webBrowser1.DocumentCompleted += this.WebBrowser1DocumentCompleted;
      this.webBrowser1.Navigated += this.WebBrowser1Navigated;
      this.webBrowser1.Navigating += this.WebBrowser1Navigating;
      this.webBrowser1.ProgressChanged += this.WebBrowser1ProgressChanged;
      this.Controls.Add(this.webBrowser1);
      this.Controls.Remove(this.menuStrip1);
      this.Controls.Add(this.menuStrip1);
      GC.Collect();
    }
  }

  /// <summary>
  /// WebInterface
  /// </summary>
  [System.Runtime.InteropServices.ComVisibleAttribute(true)]
  public class WebInterface {
    public string version() {
      return Program.sVersion;
    }
    public void showMessage(string text) {
      MessageBox.Show(text);
    }
    public bool saveFile(string pathname, string text) { // 保存
      try {
        string backupFilename = Program.mainForm.backupFilename;
        backupFilename = backupFilename.Replace("<folder>",
          Path.GetDirectoryName(Program.mainForm.filename));
        backupFilename = backupFilename.Replace("<filename>",
          Path.GetFileNameWithoutExtension(Program.mainForm.filename));
        backupFilename = backupFilename.Replace("<fileext>",
          Path.GetExtension(Program.mainForm.filename).Substring(1));
        DateTime dt = File.GetLastWriteTime(Program.mainForm.filename);
        backupFilename = backupFilename.Replace("<fyear>", dt.ToString("yyyy"));
        backupFilename = backupFilename.Replace("<fmonth>", dt.ToString("MM"));
        backupFilename = backupFilename.Replace("<fday>", dt.ToString("dd"));
        backupFilename = backupFilename.Replace("<fhour>", dt.ToString("HH"));
        backupFilename = backupFilename.Replace("<fminute>", dt.ToString("mm"));
        backupFilename = backupFilename.Replace("<fsecond>", dt.ToString("ss"));
        backupFilename = backupFilename.Replace("<year>", DateTime.Now.ToString("yyyy"));
        backupFilename = backupFilename.Replace("<month>", DateTime.Now.ToString("MM"));
        backupFilename = backupFilename.Replace("<day>", DateTime.Now.ToString("dd"));
        backupFilename = backupFilename.Replace("<hour>", DateTime.Now.ToString("HH"));
        backupFilename = backupFilename.Replace("<minute>", DateTime.Now.ToString("mm"));
        backupFilename = backupFilename.Replace("<second>", DateTime.Now.ToString("ss"));
        if (Program.mainForm.backupEnable
            && (!File.Exists(backupFilename) || Program.mainForm.backupOverwrite)) {
          if (File.Exists(backupFilename))
            File.Delete(backupFilename);
          if (!Directory.Exists(Path.GetDirectoryName(backupFilename)))
            Directory.CreateDirectory(Path.GetDirectoryName(backupFilename));
          File.Move(Program.mainForm.filename, backupFilename);
        }

        var fs = new FileStream(Program.mainForm.filename, FileMode.Create);
        var sw = new StreamWriter(fs);
        sw.Write(text);
        sw.Flush();
        sw.Close();
        fs.Close();

        Program.mainForm.showTip();
        return true;
      } catch (Exception ex) {
        MessageBox.Show("" + ex.Message,
          Program.i18n.GetString("Error"),
          MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
    }
    public void home() {
      Program.mainForm.showPanelFile();
    }
    public bool backupEnable(string text) {
      if (text == "true")
        Program.mainForm.backupEnable = true;
      if (text == "false")
        Program.mainForm.backupEnable = false;
      return Program.mainForm.backupEnable;
    }
    public bool backupOverwrite(string text) {
      if (text == "true")
        Program.mainForm.backupOverwrite = true;
      if (text == "false")
        Program.mainForm.backupOverwrite = false;
      return Program.mainForm.backupOverwrite;
    }
    public string backupFilename(string text) {
      if (text != "")
        Program.mainForm.backupFilename = text;
      return Program.mainForm.backupFilename;
    }
  }
}

using System;
using System.Windows.Forms;
using System.Drawing;

namespace ATWiki {
  /// <summary>
  /// Class with program entry point.
  /// </summary>
  internal sealed class Program {
    /// <summary>
    /// Program entry point.
    /// </summary>

    public static MainForm mainForm = null;
    public static int dpiZoom = 100;
    public static I18n i18n = null;

    public const string sTitle = "ATWiki";
    public const string sVersion = "1.8";


    [STAThread]
    private static void Main(string[] args) {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // 设置 DPI
      using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero)) {
        float dpiX = graphics.DpiX;
        float dpiY = graphics.DpiY;
        dpiZoom = (int)((dpiX + dpiY) / 2 / 96 * 100);
      }

      // 设置 i18n
      i18n = new I18n();

      // 启动
      mainForm = new MainForm(args);
      Application.Run(mainForm);
    }
  }

  /// <summary>
  /// Utility
  /// </summary>
  public static class Utility {
    /// <summary>
    /// 格式化文件大小
    /// </summary>
    /// <param name="filesize">文件的大小,传入的是一个bytes为单位的参数</param>
    /// <returns>格式化后的值</returns>
    public static string GetFileSize(long filesize) {
      if (filesize < 0) {
        return "0";
      } else if (filesize >= 1024 * 1024 * 1024) { // 文件大小大于或等于1024MB
        return string.Format("{0:0.00} GB", (double)filesize / (1024 * 1024 * 1024));
      } else if (filesize >= 1024 * 1024) { // 文件大小大于或等于1024KB
        return string.Format("{0:0.00} MB", (double)filesize / (1024 * 1024));
      } else if (filesize >= 1024) { // 文件大小大于等于1024bytes
        return string.Format("{0:0.00} KB", (double)filesize / 1024);
      } else {
        return string.Format("{0:0} bytes", filesize);
      }
    }

  }
}

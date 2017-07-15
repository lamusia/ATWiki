using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace ATWiki {
  /// <summary>
  /// Description of I18n.
  /// </summary>
  public class I18n {
    readonly ResourceManager rm;
    //=null;

    public I18n() {
      foreach (var resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames()) {
        if (resourceName ==
            "ATWiki.Properties."
            + System.Globalization.CultureInfo.InstalledUICulture.Name
            + ".resources") {
          rm = new ResourceManager(
            "ATWiki.Properties." + System.Globalization.CultureInfo.InstalledUICulture.Name,
            Assembly.GetExecutingAssembly());
        }
      }
    }
    
    public string GetString(string str) {
      if (rm == null)
        return str;

      return (string)rm.GetObject(str);
    }
    
    public void UpdateControls(Control.ControlCollection Controls) {
      foreach (Control ctl in Controls) {
        if (ctl is UserControl) {
          continue;
        }
        
        // Console.WriteLine(ctl.Name + " - " + ctl.GetType());
        if (ctl.HasChildren) {
          UpdateControls(ctl.Controls);
        }
        
        // 语言
        if (rm != null && ctl.Text != null) {
          string str = (string)rm.GetObject(ctl.Name + ".Text");
          if (!string.IsNullOrEmpty(str))
            ctl.Text = str;
        }
        
        // 缩放
        if (ctl.Font != null) {
          var font = new Font(ctl.Font.FontFamily,
                       ctl.Font.Size * Program.dpiZoom / 100,
                       ctl.Font.Style);
          ctl.Font = font;
        }
        ctl.MaximumSize = new System.Drawing.Size(
          ctl.MaximumSize.Width * Program.dpiZoom / 100,
          ctl.MaximumSize.Height * Program.dpiZoom / 100);
        //Console.WriteLine(ctl.Name + " - " + ctl.GetType() +
        //" Width, Height " + ctl.Size.Width + "," + ctl.Size.Height);
        switch (ctl.Anchor) {
          case (AnchorStyles.Top | AnchorStyles.Left):
            ctl.Size = new System.Drawing.Size(
              ctl.Size.Width * Program.dpiZoom / 100,
              ctl.Size.Height * Program.dpiZoom / 100);
            ctl.Location = new System.Drawing.Point(
              ctl.Location.X * Program.dpiZoom / 100,
              ctl.Location.Y * Program.dpiZoom / 100);
            break;
          case (AnchorStyles.Top | AnchorStyles.Right):
            ctl.Size = new System.Drawing.Size(
              ctl.Size.Width * Program.dpiZoom / 100,
              ctl.Size.Height * Program.dpiZoom / 100);
            ctl.Location = new System.Drawing.Point(
              ctl.Location.X,
              ctl.Location.Y * Program.dpiZoom / 100);
            break;
          case (AnchorStyles.Top):
          case (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right):
            ctl.Size = new System.Drawing.Size(
              ctl.Size.Width,
              ctl.Size.Height * Program.dpiZoom / 100);
            ctl.Location = new System.Drawing.Point(
              ctl.Location.X,
              ctl.Location.Y * Program.dpiZoom / 100);
            break;
          case (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom):
            break;
          default:
            ctl.Size = new System.Drawing.Size(
              ctl.Size.Width * Program.dpiZoom / 100,
              ctl.Size.Height * Program.dpiZoom / 100);
            ctl.Location = new System.Drawing.Point(
              ctl.Location.X * Program.dpiZoom / 100,
              ctl.Location.Y * Program.dpiZoom / 100);
            break;
        }
        //Console.WriteLine(ctl.Name + " - " + ctl.GetType() +
        //" Width, Height " + ctl.Size.Width + "," + ctl.Size.Height);
        
        //var menuStrip = ctl as MenuStrip;
        //if (menuStrip != null) {
        //  UpdateMenus(menuStrip.Items);
        //}
      }
    }
    
    public void UpdateMenus(ToolStripItemCollection Menus) {
      foreach (ToolStripMenuItem menu in Menus) {
        if (menu.HasDropDownItems) {
          UpdateMenus(menu.DropDownItems);
        }
        
        if (rm != null) {
          string str = (string)rm.GetObject(menu.Name + ".Text");
          if (!string.IsNullOrEmpty(str))
            menu.Text = str;
        }

        var font = new Font(menu.Font.FontFamily,
                     menu.Font.Size * Program.dpiZoom / 100,
                     menu.Font.Style);
        menu.Font = font;
      }
    }

  }
}

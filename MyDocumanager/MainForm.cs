using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDocumanager
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void AddDocument(object sender, EventArgs e)
    {
      fileBrowser.ShowDialog();
      string file = fileBrowser.FileName;

      Console.WriteLine(file);
    }

    private void AddFolder(object sender, EventArgs e)
    {
      folderBrowser.ShowDialog();
      string folder = folderBrowser.SelectedPath;

      Console.WriteLine(folder);
    }
  }
}

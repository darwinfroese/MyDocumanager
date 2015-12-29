using System;
using System.IO;
using System.Windows.Forms;

namespace MyDocumanager
{
  public partial class MainForm : Form
  {
    private DocumentHandler _dh;

    public MainForm()
    {
      InitializeComponent();
      
      _dh = new DocumentHandler();
    }

    private void AddDocument(object sender, EventArgs e)
    {
      fileBrowser.ShowDialog();
      string file = fileBrowser.FileName;

      InsertDocument(file);
    }

    private void AddFolder(object sender, EventArgs e)
    {
      folderBrowser.ShowDialog();
      string folder = folderBrowser.SelectedPath;

      string[] files = Directory.GetFiles(folder);

      foreach (string file in files)
        InsertDocument(file);
    }

    private void InsertDocument(string file)
    {
      Document d = new Document(file, Path.GetFileName(file));
      if (_dh.AddDocument(d))
        mainListView.Items.Add(d);
    }
  }
}

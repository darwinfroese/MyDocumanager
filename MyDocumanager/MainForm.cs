using System;
using System.Collections.Generic;
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

      if (InsertDocument(file))
        infoStatusLabel.Text = "1 document inserted.";
    }

    private void AddFolder(object sender, EventArgs e)
    {
      int insertedCount = 0;

      folderBrowser.ShowDialog();
      string folder = folderBrowser.SelectedPath;

      string[] files = Directory.GetFiles(folder);

      foreach (string file in files)
        if (InsertDocument(file))
          insertedCount++;

      infoStatusLabel.Text = insertedCount + " documents inserted.";
    }

    private bool InsertDocument(string file)
    {
      bool inserted = false;

      if (String.IsNullOrWhiteSpace(file))
        return inserted;

      Document d = new Document(file, Path.GetFileName(file));

      inserted = _dh.AddDocument(d);

      if (inserted)
        mainListView.Items.Add(d);

      return inserted;
    }

    private void OnLoad(object sender, EventArgs e)
    {
      List<Document> documents = _dh.GetAllDocuments();

      foreach (Document d in documents)
        mainListView.Items.Add(d);
    }
  }
}

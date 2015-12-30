using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MyDocumanager
{
  public partial class MainForm : Form
  {
    private DocumentHandler _dh;
    private editForm _ef;
    private Document _selected;

    public MainForm()
    {
      InitializeComponent();
      
      _dh = new DocumentHandler();
      _ef = new editForm();
      _ef.Owner = this;
    }

    public void UpdateDocument(Document d)
    {
      mainListView.Items.Remove(_selected);
      mainListView.Items.Add(d);

      _dh.UpdateDocument(_selected, d);
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

      if (String.IsNullOrWhiteSpace(folder))
        return;

      string[] files = Directory.GetFiles(folder);

      foreach (string file in files)
        if (InsertDocument(file))
          insertedCount++;

      infoStatusLabel.Text = insertedCount + " documents inserted.";
    }

    private bool InsertDocument(string file)
    {
      if (String.IsNullOrWhiteSpace(file))
        return false;

      Document d = _dh.AddDocument(file, Path.GetFileName(file));

      if (d != null)
      {
        mainListView.Items.Add(d);
        return true;
      }

      return false;
    }

    private void OnLoad(object sender, EventArgs e)
    {
      List<Document> documents = _dh.GetAllDocuments();

      foreach (Document d in documents)
        mainListView.Items.Add(d);
    }

    private void EditDocument(object sender, EventArgs e)
    {
      _selected = (Document) (mainListView.SelectedItems[0]);
      _ef.Document = _selected;
      _ef.ShowDialog();
    }

    private void OnFocus(object sender, EventArgs e)
    {
      searchTextBox.Text = "";
    }

    private void LostFocus(object sender, EventArgs e)
    {
      if (String.IsNullOrWhiteSpace(searchTextBox.Text))
        searchTextBox.Text = "Search...";
    }

    private void TextChanged(object sender, EventArgs e)
    {
      List<Document> results;

      if (String.IsNullOrWhiteSpace(searchTextBox.Text) || searchTextBox.Text == "Search...")
      {
        mainListView.Items.Clear();
        results = _dh.GetAllDocuments();
      }
      else
      {
        mainListView.Items.Clear();
        results = _dh.FindDocumentsContainingString(searchTextBox.Text);
      }

      foreach (Document d in results)
        mainListView.Items.Add(d);
    }
  }
}

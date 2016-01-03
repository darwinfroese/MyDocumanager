using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MyDocumanager
{
  public partial class MainForm : Form
  {
    private DocumentHandler _dh;
    private editForm _ef;
    private PdfReader _pf;
    private Document _selected;

    public MainForm()
    {
      InitializeComponent();
      
      _dh = new DocumentHandler();
      _ef = new editForm();
      _ef.Owner = this;

      mainListView.ContextMenuStrip = itemMenu;
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
      folderBrowser.ShowDialog();
      string folder = folderBrowser.SelectedPath;

      if (String.IsNullOrWhiteSpace(folder))
        return;

      string[] files = Directory.GetFiles(folder);

      int insertedCount = files.Count(InsertDocument);

      infoStatusLabel.Text = insertedCount + " documents inserted.";
    }

    private bool InsertDocument(string file)
    {
      if (String.IsNullOrWhiteSpace(file))
        return false;

      Document d = _dh.AddDocument(file, Path.GetFileName(file));

      if (d == null)
        return false;

      mainListView.Items.Add(d);
      return true;
    }

    private void OnLoad(object sender, EventArgs e)
    {
      List<Document> documents = _dh.GetAllDocuments();

      foreach (Document d in documents)
        mainListView.Items.Add(d);
    }

    private void ViewDocument(object sender, EventArgs e)
    {
      _selected = (Document) (mainListView.SelectedItems[0]);
      _pf = new PdfReader(_selected);
      _pf.ShowDialog();
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

    private void MenuOpen(object sender, System.ComponentModel.CancelEventArgs e)
    {
      e.Cancel = (mainListView.SelectedItems.Count == 0);
    }
  }
}

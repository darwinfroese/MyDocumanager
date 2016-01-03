﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace MyDocumanager
{
  public partial class editForm : Form
  {
    public Document Document { get; set; }

    private DBInterface _dhi;
    private List<Tag> _tags;

    public editForm()
    {
      InitializeComponent();
    }

    public editForm(Document d)
    {
      InitializeComponent();

      Document = d;
    }

    private void CancelUpdate(object sender, System.EventArgs e)
    {
      this.Close();
    }

    private void CommitUpdate(object sender, System.EventArgs e)
    {
      MainForm parent = (MainForm) this.Owner;

      Document d = BuildDocument();

      parent.UpdateDocument(d);
      parent.UpdateTags(tagTextBox.Text.Split(','));
      this.Close();
    }

    private Document BuildDocument()
    {
      Document d = new Document(Document.ID, filePathLabel.Text, titleTextBox.Text, descriptionTextBox.Text);
      d.Tags = Document.Tags;

      return d;
    }

    private void OnLoad(object sender, System.EventArgs e)
    {
      _dhi = new DBInterface();
      _tags = _dhi.GetTags();
      // Use these^ for autocomplete maybe?

      filePathLabel.Text = Document.FilePath;
      titleTextBox.Text = Document.Title;
      descriptionTextBox.Text = Document.Description;
      tagTextBox.Text = FillTagBox();
    }

    private string FillTagBox()
    {
      string text = "";

      if (Document.Tags == null)
        return text;

      foreach (Tag t in Document.Tags)
      {
        text += t.Name + ", ";
      }

      if (text.Length > 0 && text[text.Length - 1] == ' ')
        text = text.Substring(0, text.Length - 2);

      return text;
    }
  }
}

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MyDocumanager
{
  public class Document : ListViewItem
  {
    private readonly string _filePath;
    private readonly string _title;
    private readonly string _description;
    private int _id;
    private List<Tag> _tags;
    private List<Author> _authors;
    private string _authorString;
    private string _tagString;

    public string FilePath { get { return _filePath; } }
    public string Title { get { return _title; } }
    public string Description { get { return _description; } }
    public int ID { get { return _id; } set { _id = value;  } }

    private const int AuthorColumn = 2;
    private const int TagColumn = 3;

    public List<Tag> Tags
    {
      get
      {
        return _tags;
      }
      set
      {
        _tags = value;
        _tagString = SetTagString();
        base.SubItems[TagColumn].Text = _tagString;
      }
    }

    public List<Author> Authors
    {
      get
      {
        return _authors;
      }
      set
      {
        _authors = value;
        _authorString = SetAuthorString();
        base.SubItems[AuthorColumn].Text = _authorString;
      }
    } 

    public Document(string fp, string t) : base(t)
    {
      _filePath = fp;
      _title = t;
      _description = "";
      _authorString = "";
      _tagString = "";

      base.SubItems.Add(_description);
      base.SubItems.Add(_tagString);
      base.SubItems.Add(_authorString);
    }

    public Document(string fp, string t, string d) : base(t)
    {
      _filePath = fp;
      _title = t;
      _description = d;
      _authorString = "";
      _tagString = "";

      base.SubItems.Add(_description);
      base.SubItems.Add(_authorString);
      base.SubItems.Add(_tagString);
    }

    public Document(int id, string fp, string t, string d) : base(t)
    {
      _id = id;
      _filePath = fp;
      _title = t;
      _description = d;
      _authorString = "";
      _tagString = "";

      base.SubItems.Add(_description);
      base.SubItems.Add(_authorString);
      base.SubItems.Add(_tagString);
    }

    public bool Equals(Document d)
    {
      bool isEqual = (d._filePath == _filePath);

      return isEqual;
    }

    public int GenerateHashCode()
    {
      return _filePath.GetHashCode();
    }

    private string SetTagString()
    {
      string text = "";

      if (_tags.Count == 0)
        return text;

      for (int i = 0; i < _tags.Count - 1; i++)
        text += _tags[i].Name + ", ";

      text += _tags[_tags.Count - 1].Name;

      return text;
    }

    private string SetAuthorString()
    {
      string text = "";

      if (_authors.Count == 0)
        return text;

      for (int i = 0; i < _authors.Count - 1; i++)
        text += _authors[i].Name + ", ";

      text += _authors[_authors.Count - 1].Name;

      return text;
    }
  }
}

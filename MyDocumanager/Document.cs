using System.Windows.Forms;

namespace MyDocumanager
{
  public class Document : ListViewItem
  {
    private readonly string _filePath;
    private readonly string _title;
    private readonly string _description;
    private int _id;

    public string FilePath { get { return _filePath; } }
    public string Title { get { return _title; } }
    public string Description { get { return _description; } }
    public int ID { get { return _id; } set { _id = value;  } }

    public Document(string fp, string t) : base(t)
    {
      _filePath = fp;
      _title = t;
      _description = "";

      base.SubItems.Add(_description);
    }

    public Document(string fp, string t, string d) : base(t)
    {
      _filePath = fp;
      _title = t;
      _description = d;

      base.SubItems.Add(_description);
    }

    public Document(int id, string fp, string t, string d) : base(t)
    {
      _id = id;
      _filePath = fp;
      _title = t;
      _description = d;

      base.SubItems.Add(_description);
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
  }
}

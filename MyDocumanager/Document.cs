﻿using System.Windows.Forms;

namespace MyDocumanager
{
  class Document : ListViewItem
  {
    private string _filePath;
    private string _title;
    private string _description;


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

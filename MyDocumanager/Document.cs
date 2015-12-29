using System.Windows.Forms;

namespace MyDocumanager
{
  class Document : ListViewItem
  {
    public string FilePath { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Document(string fp, string t) : base(t)
    {
      FilePath = fp;
      Title = t;
      Description = "";

      base.SubItems.Add(Description);
    }

    public Document(string fp, string t, string d) : base(t)
    {
      FilePath = fp;
      Title = t;
      Description = d;

      base.SubItems.Add(Description);
    }
  }
}

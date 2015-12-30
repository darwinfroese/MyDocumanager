using System.Windows.Forms;

namespace MyDocumanager
{
  public partial class editForm : Form
  {
    public Document Document { get; set; }

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

      parent.UpdateDocument(new Document(Document.ID, filePathLabel.Text, titleTextBox.Text, descriptionTextBox.Text));
      this.Close();
    }

    private void OnLoad(object sender, System.EventArgs e)
    {
      filePathLabel.Text = Document.FilePath;
      titleTextBox.Text = Document.Title;
      descriptionTextBox.Text = Document.Description;
    }
  }
}

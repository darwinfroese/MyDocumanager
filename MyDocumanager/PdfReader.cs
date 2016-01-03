using System.IO;
using System.Windows.Forms;

namespace MyDocumanager
{
  public partial class PdfReader : Form
  {
    public PdfReader()
    {
      InitializeComponent();
    }

    public PdfReader(Document d)
    {
      InitializeComponent();

      if (Path.GetExtension(d.FilePath) == ".pdf")
        pdfDisplay.src = d.FilePath;
    }
  }
}

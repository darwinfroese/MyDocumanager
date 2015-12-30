using System.Collections.Generic;
using System.Linq;

namespace MyDocumanager
{
  class DocumentHandler
  {
    private readonly HashSet<Document> _documents;
    private readonly DBInterface _dbi;

    public DocumentHandler()
    {
      _documents = new HashSet<Document>(new DocumentComparer());
      _dbi = new DBInterface();

      GetStoredDocuments();
    }

    public Document AddDocument(string filePath, string fileName)
    {
      Document d = _dbi.Insert(filePath, fileName);

      if (_documents.Add(d))
        return d;
      else
        return null;
    }

    public void UpdateDocument(Document oldDocument, Document newDocument)
    {
      _documents.Remove(oldDocument);
      _documents.Add(newDocument);

      _dbi.Update(newDocument);
    }

    public void RemoveDocument(Document d)
    {
      _documents.Remove(d);

      _dbi.Remove(d);
    }

    public List<Document> GetAllDocuments()
    {
      return _documents.ToList();
    }

    private void GetStoredDocuments()
    {
      List<Document> documents = _dbi.GetAllDocuments();

      if (documents == null)
        return;

      foreach (Document d in documents)
        _documents.Add(d);
    }
  }
}

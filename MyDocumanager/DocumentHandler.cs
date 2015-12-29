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

    public bool AddDocument(Document d)
    {
      bool inserted = _documents.Add(d);

      if (inserted)
        _dbi.Insert(d);

      return inserted;
    }

    public void UpdateDocument(Document d)
    {
      
    }

    public void RemoveDocument(Document d)
    {
      
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

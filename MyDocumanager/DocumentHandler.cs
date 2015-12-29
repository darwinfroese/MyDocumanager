using System.Collections.Generic;

namespace MyDocumanager
{
  class DocumentHandler
  {
    private readonly HashSet<Document> _documents;

    public DocumentHandler()
    {
      _documents = new HashSet<Document>(new DocumentComparer());
    }

    public bool AddDocument(Document d)
    {
      return _documents.Add(d);
    }
  }
}

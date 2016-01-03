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

      if (d == null)
        return null;

      return _documents.Add(d) ? d : null;
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

    public List<Document> FindDocumentsContainingString(string term)
    {
      return _documents.Where(d => d.Title.ToLower().Contains(term.ToLower()) || d.Description.ToLower().Contains(term.ToLower())).ToList();
    }

    public List<Document> FindDocumentsByTitle(string term)
    {
      return _documents.Where(d => d.Title.ToLower().StartsWith(term.ToLower())).ToList();
    }

    public List<Document> GetAllDocuments()
    {
      return _documents.ToList();
    }

    public List<Tag> UpdateTags(Document d, string[] tags)
    {
      // Add/Remove tags from database
      // Return list of tags in database for the document
      // Set the list to be the documents list
      return _dbi.UpdateTags(d.ID, tags);
    }

    public List<Author> UpdateAuthors(Document d, string[] authors)
    {
      return _dbi.UpdateAuthors(d.ID, authors);
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

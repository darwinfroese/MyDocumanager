using System;
using System.Collections.Generic;
using System.IO;

namespace MyDocumanager
{
  class DBInterface
  {
    private string _dbLocation = ".\\";
    private string _dbFileName = "documanager.ddb";

    private StreamWriter writer;
    private StreamReader reader;

    public DBInterface()
    {
      
    }

    public void Insert(Document d)
    {
      writer = Open();
      writer.WriteLine(d.ToString());
      writer.Close();
    }

    public List<Document> GetAllDocuments()
    {
      List<Document> documents = new List<Document>();

      if (File.Exists(_dbLocation + _dbFileName))
        reader = new StreamReader(_dbLocation + _dbFileName);
      else
        return null;

      string line;
      while (!String.IsNullOrWhiteSpace(line = reader.ReadLine()))
      {
        string[] parameters = line.Split('|');

        documents.Add(new Document(parameters[0], parameters[1], parameters[2]));
      }

      reader.Close();
      return documents;
    } 

    private StreamWriter Open()
    {
      return File.AppendText(_dbLocation + _dbFileName);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MyDocumanager
{
  class DBInterface
  {
    private const string DbConnectionString =
      @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\documanagerDB.mdf;Integrated Security=True";
    
    private SqlConnection _conn;

    public DBInterface()
    {
      // For Install (?)
      // AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);

      AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\programming\home_work\MyDocumanager\MyDocumanager");
      _conn = new SqlConnection(DbConnectionString);
    }

    public Document Insert(string filePath, string title)
    {
      Document d;

      SqlCommand cmd = new SqlCommand("InsertDocument", _conn);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@path", filePath);
      cmd.Parameters.AddWithValue("@title", title);
      cmd.Parameters.AddWithValue("@description", "");
      SqlParameter returnValue = cmd.Parameters.Add("@ret_id", SqlDbType.Int);
      returnValue.Direction = ParameterDirection.ReturnValue;

      _conn.Open();
      SqlTransaction trans = _conn.BeginTransaction();
      cmd.Transaction = trans;
      try
      {
        cmd.ExecuteNonQuery();
        d = new Document((int)(cmd.Parameters["@ret_id"].Value), filePath, title, "");
      }
      catch (SqlException exception)
      {
        d = null;
      }

      trans.Commit();
      _conn.Close();

      return d;
    }

    public void Update(Document d)
    {
      SqlCommand cmd = new SqlCommand("UpdateDocument", _conn);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@id", d.ID);
      cmd.Parameters.AddWithValue("@path", d.FilePath);
      cmd.Parameters.AddWithValue("@title", d.Title);
      cmd.Parameters.AddWithValue("@description", d.Description);

      _conn.Open();
      SqlTransaction trans = _conn.BeginTransaction();
      cmd.Transaction = trans;
      cmd.ExecuteNonQuery();

      trans.Commit();
      _conn.Close();
    }

    public void Remove(Document d)
    {
      SqlCommand cmd = new SqlCommand("RemoveDocument", _conn);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@id", d.ID);

      _conn.Open();
      SqlTransaction trans = _conn.BeginTransaction();
      cmd.Transaction = trans;
      cmd.ExecuteNonQuery();

      trans.Commit();
      _conn.Close();
    }

    public List<Document> GetAllDocuments()
    {
      List<Document> documents = new List<Document>();

      SqlCommand cmd = new SqlCommand("GetAllDocuments", _conn);
      cmd.CommandType = CommandType.StoredProcedure;
      _conn.Open();

      SqlDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
        documents.Add(new Document( (int)(reader["id"]),
                                    reader["Path"].ToString(),
                                    reader["Title"].ToString(),
                                    reader["Description"].ToString()));
      
      _conn.Close();

      foreach (Document d in documents)
        d.Tags = GetDocumentTags(d.ID);

      return documents;
    }

    public List<Tag> GetTags()
    {
      List<Tag> tags = new List<Tag>();

      SqlCommand cmd = new SqlCommand("GetTags", _conn);
      cmd.CommandType = CommandType.StoredProcedure;
      _conn.Open();

      SqlDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
        tags.Add(new Tag(reader["tagName"].ToString(), (int)(reader["id"])));

      _conn.Close();
      return tags;
    }

    public List<Tag> GetDocumentTags(int id)
    {
      List<Tag> tags = new List<Tag>();

      SqlCommand cmd = new SqlCommand("GetDocumentTags", _conn);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@docID", id);

      _conn.Open();

      SqlDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
        tags.Add(new Tag(reader["tagName"].ToString(), (int)(reader["id"])));

      _conn.Close();
      return tags;
    } 

    public List<Tag> UpdateTags(int docID, string[] names)
    {
      // Tags associated with document
      List<Tag> docTags = GetDocumentTags(docID);
      // Tags in Database
      List<Tag> storedTags = GetTags();
      // Tags to add (if not already added)
      List<Tag> tags = new List<Tag>();
      Tag[] iterable = new Tag[docTags.Count];
      docTags.CopyTo(iterable);

      // TODO: Optimize this
      foreach (Tag t in iterable)
      {
        bool found = FoundInArray(t, names);
        
        if (!found)
        {
          // remove
          RemoveDocumentTag(docID, t);
          docTags.Remove(t);
        }
      }

      foreach (string n in names)
      {
        int index = FoundInList(n, storedTags);
        int id = 0;

        if (index == -1)
          // Create and insert new tag
          id = CreateTag(n);
        else
          id = storedTags[index].ID;

        tags.Add(new Tag(n.Trim(), id));
      }

      //iterable = new Tag[docTags.Count];
      //docTags.CopyTo(iterable);
      foreach (Tag t in tags)
      {
        bool found = false;

        for (int i = 0; i < docTags.Count && !found; i++)
        {
          if (String.Equals(docTags[i].Name, t.Name, StringComparison.CurrentCultureIgnoreCase))
            found = true;
        }

        if (!found)
        {
          docTags.Add(t);
          AddDocumentTag(docID, t.ID);
        }
      }

      return docTags;
    }

    private int FoundInList(string name, List<Tag> tags)
    {
      int index = -1;
      bool found = false;

      for (int i = 0; i < tags.Count && !found; i++)
      {
        if (tags[i].Name.ToLower().Trim() == name.ToLower().Trim())
        {
          found = true;
          index = i;
        }
      }

      return index;
    }

    private void AddDocumentTag(int docID, int tagID)
    {
      SqlCommand cmd = new SqlCommand("AddDocumentTag", _conn);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@docID", docID);
      cmd.Parameters.AddWithValue("@tagID", tagID);

      _conn.Open();
      SqlTransaction trans = _conn.BeginTransaction();
      cmd.Transaction = trans;

      try
      {
        cmd.ExecuteNonQuery();
      }
      catch (SqlException exception)
      {
        
      }

      trans.Commit();
      _conn.Close();
    }

    private bool FoundInArray(Tag tag, string[] names)
    {
      bool found = false;

      for (int i = 0; i < names.Length && !found; i++)
      {
        if (tag.Name.ToLower() == names[i].ToLower())
          found = true;
      }

      return found;
    }

    private int CreateTag(string name)
    {
      int id = -1;

      SqlCommand cmd = new SqlCommand("CreateTag", _conn);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@tagName", name.Trim());
      SqlParameter returnValue = cmd.Parameters.Add("@ret_id", SqlDbType.Int);
      returnValue.Direction = ParameterDirection.ReturnValue;

      _conn.Open();
      SqlTransaction trans = _conn.BeginTransaction();
      cmd.Transaction = trans;
      try
      {
        cmd.ExecuteNonQuery();
        id = (int)(cmd.Parameters["@ret_id"].Value);
      }
      catch (SqlException exception)
      {
        id = -1;
      }

      trans.Commit();
      _conn.Close();

      return id;
    }

    private void RemoveDocumentTag(int id, Tag t)
    {
      SqlCommand cmd = new SqlCommand("RemoveDocumentTag", _conn);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.AddWithValue("@docID", id);
      cmd.Parameters.AddWithValue("@tagID", t.ID);

      _conn.Open();
      SqlTransaction trans = _conn.BeginTransaction();
      cmd.Transaction = trans;
      cmd.ExecuteNonQuery();

      trans.Commit();
      _conn.Close();
    }
  }
}

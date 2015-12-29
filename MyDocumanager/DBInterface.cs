using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MyDocumanager
{
  class DBInterface
  {
    private const string DbConnectionString =
      @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\documanagerDB.mdf;Integrated Security=True";

    private string _dbLocation = @"D:\programming\home_work\MyDocumanager\MyDocumanager";
    private SqlConnection _conn;

    public DBInterface()
    {
      AppDomain.CurrentDomain.SetData("DataDirectory", _dbLocation);
      _conn = new SqlConnection(DbConnectionString);
    }

    public void Insert(Document d)
    {
      SqlCommand cmd = new SqlCommand("InsertDocument", _conn);
      cmd.CommandType = CommandType.StoredProcedure;

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

    public List<Document> GetAllDocuments()
    {
      List<Document> documents = new List<Document>();

      SqlCommand cmd = new SqlCommand("GetAllDocuments", _conn);
      cmd.CommandType = CommandType.StoredProcedure;
      _conn.Open();

      SqlDataReader reader = cmd.ExecuteReader();

      while (reader.Read())
        documents.Add(new Document( reader["Path"].ToString(),
                                    reader["Title"].ToString(),
                                    reader["Description"].ToString()));
      
      _conn.Close();

      return documents;
    }
  }
}

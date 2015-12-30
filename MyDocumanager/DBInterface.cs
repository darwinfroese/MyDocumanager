using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

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
      cmd.ExecuteNonQuery();

      Document d = new Document((int)(cmd.Parameters["@ret_id"].Value), filePath, title, "");

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

      return documents;
    }
  }
}

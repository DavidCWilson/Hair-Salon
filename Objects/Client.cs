using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon.Objects
{
  public class Client
  {
    private int _id;
    private string _firstName;
    private int _stylist_id;

    public Client(string firstName, int stylist_id, int Id = 0)
    {
      _id = Id;
      _firstName = firstName;
      _stylist_id = stylist_id;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool nameEquality = this.GetName() == newClient.GetName();
        bool stylist_idEquality = this.GetStylistId() == newClient.GetStylistId();
        return (idEquality && nameEquality && stylist_idEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }
    public int GetStylistId()
    {
      return _stylist_id;
    }
    public string GetName()
    {
      return _firstName;
    }
    public void SetFirstName(string newFirstName)
    {
      _firstName = newFirstName;
    }
    public void SetStylistId(int newStylistId)
    {
      _stylist_id = newStylistId;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}

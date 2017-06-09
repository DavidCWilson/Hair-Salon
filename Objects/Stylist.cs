using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HairSalon;

namespace HairSalon.Objects
{
  public class Stylist
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _specialty;

    public Stylist(string firstName, string lastName, string specialty, int Id = 0)
    {
      _id = Id;
      _firstName = firstName;
      _lastName = lastName;
      _specialty = specialty;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId() == newStylist.GetId();
        bool nameEquality = this.GetFullName() == newStylist.GetFullName();
        bool specialtyEquality = this.GetSpecialty() == newStylist.GetSpecialty();
        return (idEquality && nameEquality && specialtyEquality);
      }
    }

    public int GetId()
    {
      return _id;
    }
    public string GetSpecialty()
    {
      return _specialty;
    }
    public string GetFullName()
    {
      return _firstName + " " + _lastName;
    }
    public void SetFirstName(string newFirstName)
    {
      _firstName = newFirstName;
    }
    public void SetLastName(string newLastName)
    {
      _lastName = newLastName;
    }
    public void SetSpecialty(string newSpecialty)
    {
      _specialty = newSpecialty;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistFirstName = rdr.GetString(1);
        string stylistLasttName = rdr.GetString(2);
        string stylistSpecialty = rdr.GetString(3);
        Stylist newStylist = new Stylist(stylistFirstName, stylistLasttName, stylistSpecialty, stylistId);
        allStylists.Add(newStylist);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allStylists;
    }
  }
}

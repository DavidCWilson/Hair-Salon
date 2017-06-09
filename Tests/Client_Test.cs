using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
  [Collection("HairSalon")]
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Client.GetAll().Count;
      Assert.Equal(0, result);
    }
  }
}

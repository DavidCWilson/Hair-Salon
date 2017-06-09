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
    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Client firstClient = new Client("NotDavid", 1);
      Client secondClient = new Client("NotDavid", 1);
      Assert.Equal(firstClient, secondClient);
    }
    [Fact]
    public void Test_Save_ToClientDatabase()
    {
      Client testClient = new Client("Iforgotmynameoops", 2);
      testClient.Save();

      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_FindClientInDatabase()
    {
      Client testClient = new Client("Chet", 2);
      testClient.Save();

      Client foundClient = Client.Find(testClient.GetId());

      Assert.Equal(testClient, foundClient);
    }
  }
}

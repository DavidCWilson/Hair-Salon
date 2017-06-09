using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HairSalon.Objects;

namespace HairSalon
{
  [Collection("HairSalon")]
  public class StylistTest : IDisposable
  {
    public StylistTest()
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
      int result = Stylist.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Stylist firstStylist = new Stylist("David", "Copperfield", "BuzzCuts");
      Stylist secondStylist = new Stylist("David", "Copperfield", "BuzzCuts");
      Assert.Equal(firstStylist, secondStylist);
    }
    [Fact]
    public void Test_Save_ToStylistDatabase()
    {
      Stylist testStylist = new Stylist("Fran", "Dresher", "Perm");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};
      Assert.Equal(testList, result);
    }
    [Fact]
    public void Test_FindStylistInDatabase()
    {
      Stylist testStylist = new Stylist("Ricky", "Bobby", "The Winner");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      Assert.Equal(testStylist, foundStylist);
    }
    [Fact]
    public void Test_GetClients_RetrievesAllClientsWithStylist()
    {
      Stylist testStylist = new Stylist("Chet", "Manly", "The StrongMan Do");
      testStylist.Save();

      Client firstClient = new Client("Lenny", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("Burt", testStylist.GetId());
      secondClient.Save();

      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClients();

      Assert.Equal(testClientList, resultClientList);
    }
  }
}

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
    [Fact]
    public void Test_Update_UpdatesClientInDatabase()
    {
      string name = "Bart";
      int stylist_id = 2;
      Client testClient = new Client(name, stylist_id);
      testClient.Save();
      string newName = "Bartholomewchlewizkyzak";

      testClient.Update(newName);

      string result = testClient.GetName();

      Assert.Equal(newName, result);
    }
    [Fact]
    public void Test_Delete_DeletesClientFromDatabase()
    {
      string firstName1 = "French";
      string lastName1 = "Fry";
      string specialty1 = "Oil Blast";
      Stylist testStylist1 = new Stylist(firstName1, lastName1, specialty1);
      testStylist1.Save();

      string firstName2 = "Chunky";
      string lastName2 = "Monkey";
      string specialty2 = "Grooming";
      Stylist testStylist2 = new Stylist(firstName2, lastName2, specialty2);
      testStylist2.Save();

      Client testClient1 = new Client("Franz", testStylist1.GetId());
      testClient1.Save();
      Client testClient2 = new Client("Hanz", testStylist2.GetId());
      testClient2.Save();

      testClient1.Delete();
      List<Stylist> resultStylists = Stylist.GetAll();
      List<Stylist> testStylistList = new List<Stylist> {testStylist1, testStylist2};

      List<Client> resultClients = Client.GetAll();
      List<Client> testClientList = new List<Client> {testClient2};

      Assert.Equal(testStylistList, resultStylists);
      Assert.Equal(testClientList, resultClients);
    }
  }
}

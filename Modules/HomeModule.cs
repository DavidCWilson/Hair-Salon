using Nancy;
using System;
using HairSalon.Objects;
using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["home.cshtml", allStylists];
      };
      Get["/stylists"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["stylists.cshtml", allStylists];
      };
      Get["/clients"] = _ => {
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };
      Get["/stylists/new"] = _ => {
        return View["stylist_add.cshtml"];
      };
      Get["/clients/new"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["client_add.cshtml", allStylists];
      };
      Post["/stylists/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-firstName"], Request.Form["stylist-lastName"], Request.Form["stylist-specialty"]);
        newStylist.Save();
        return View["success.cshtml"];
      };
      Post["/clients/new"] = _ => {
        Client newClient = new Client(Request.Form["client-firstName"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["success.cshtml"];
      };
      Get["/stylists/{id}"] = parameters => {
        Dictionary<string, object> zomgHair = new Dictionary<string, object>();
        var selectedStylist = Stylist.Find(parameters.id);
        var stylistClients = selectedStylist.GetClients();
        zomgHair.Add("stylist", selectedStylist);
        zomgHair.Add("clients", stylistClients);
        return View["stylist.cshtml", zomgHair];
      };
      Get["/clients/{id}"] = parameters => {
        Dictionary<string, object> zomgFixMyHair = new Dictionary<string, object>();
        var selectedClient = Client.Find(parameters.id);
        zomgFixMyHair.Add("client", selectedClient);
        return View["client.cshtml", zomgFixMyHair];
      };
      Get["/clients/{id}/edit"] = parameters => {
        Dictionary<string, object> zomgEdit = new Dictionary<string, object>();
        Client selectedClient = Client.Find(parameters.id);
        zomgEdit.Add("selectedClient", selectedClient);
        return View["client_edit.cshtml", zomgEdit];
      };
      Get["/clients/{id}/delete"] = _ => {
        return View["success.cshtml"];
      };
      Patch["/clients/{id}/edit"] = parameters => {
        Client selectedClient = Client.Find(parameters.id);
        string newName = Request.Form["client-name"];
        selectedClient.Update(newName);
        return View["success.cshtml"];
      };
      Delete["/clients/{id}/delete"] = parameters => {
        Client selectedClient = Client.Find(parameters.id);
        selectedClient.Delete();
        return View["success.cshtml"];
      };
    }
  }
}

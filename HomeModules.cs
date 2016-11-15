using Nancy;
using System;
using cdCollection.Objects;
using System.Collections.Generic;

namespace cdCollection
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["form.cshtml"];
      Get["/form"] = _ => View["form.cshtml"];
      Get["/list"] = _ => View["list.cshtml"];
      Get["/cds-clear"] = _ => View["cds-clear.cshtml"];
      Get["/search"] = _ => View["search.cshtml"];
      Get["/searchPage"] = _ => View["searchPage.cshtml"];
      Post["/list"] = _ => {
        Cd newCd = new Cd (Request.Form["artist"], Request.Form["album"], Request.Form["year"]);
        newCd.SetDescription();
        newCd.Save();
        newCd.SetInstances();
        List<string> allAlbums = Cd.GetList();

        return View["list.cshtml", allAlbums];
      };
      Post["/searchPage"] =_=> {
        Console.WriteLine("search");
        string artistSearch = Request.Form["search"];
        List<Cd> allAlbums = Cd.GetInstances();
        List<string> searchList = new List<string>{};
        foreach (var album in allAlbums)
        {
          Console.WriteLine(album);
          if(album.GetArtist().ToLower() == artistSearch.ToLower())
          {
            album.SetDescription();
            searchList.Add(album.GetDescription());
          }
        }
        return View["searchPage.cshtml", searchList];

      };

      Post["/form"] = _ =>
      {
        Cd.ClearAll();
        return View["form.cshtml"];
      };
    }
  }
}

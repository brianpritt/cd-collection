using Nancy;
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
      Post["/list"] = _ => {
        Cd newCd = new Cd (Request.Form["artist"], Request.Form["album"], Request.Form["year"]);
        newCd.SetDescription();
        newCd.Save();
        List<string> allAlbums = Cd.GetList();
        return View["list.cshtml", allAlbums];
      };

      Post["/form"] = _ =>
      {
        Cd.ClearAll();
        return View["form.cshtml"];
      };
    }
  }
}

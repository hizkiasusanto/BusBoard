using System.Web.Mvc;
using BusBoard.Api;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection)
    {
      HttpContext.Response.Headers.Add("refresh", "30; url=" + Url.Action("BusInfo",selection));
      
      var info = new BusInfo(selection.Postcode, selection.SearchRadius);
      info.Coordinate = new PostCodeApiHandler().GetCoordinate(selection.Postcode);
      info.NearbyBusStops = new TflApiHandler().GetNearbyBusStops(info.Coordinate,selection.SearchRadius);

      if (info.NearbyBusStops != null)
      {
        foreach (var nearbyBusStop in info.NearbyBusStops)
        {
          info.StopWithArrivals.Add(new StopWithArrivals(nearbyBusStop));
        }
      }
      else
      {
        info.StopWithArrivals = null;
      }

      return View(info);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Information about this site";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact us!";

      return View();
    }
  }
}
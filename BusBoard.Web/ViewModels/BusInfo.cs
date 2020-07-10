using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode, int searchRadius)
    {
      PostCode = postCode;
      SearchRadius = searchRadius;

      StopWithArrivals = new List<StopWithArrivals>();
    }

    public string PostCode { get; set; }
    public int SearchRadius { get; set; }
    public Coordinate Coordinate { get; set; }
    
    public List<BusStop> NearbyBusStops { get; set; }
    
    public List<StopWithArrivals> StopWithArrivals { get; set; }

  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class TflApiHandler
    {
        private static string _url = @"https://api.tfl.gov.uk";
        private IRestClient _client = new RestClient(_url);


        public List<IncomingBusPrediction> GetIncomingBusPredictions(string stopId)
        {
            var request = new RestRequest($"StopPoint/{stopId}/Arrivals");

            return _client.Execute<List<IncomingBusPrediction>>(request).Data.OrderBy(t => t.TimeToStation).Take(5).ToList();
            ;
        }

        public List<BusStop> GetNearbyBusStops(Coordinate coordinate, int searchRadiusInMeters = 200)
        {
            var request =
                new RestRequest(
                    $"StopPoint?stopTypes=NaptanPublicBusCoachTram&modes=bus" +
                    $"&radius={searchRadiusInMeters}&lat={coordinate.Latitude}&lon={coordinate.Longitude}");
            request.RootElement = "stopPoints";

            var response = _client.Execute<List<BusStop>>(request);

            if (response.Data.Count == 0)
            {
                Console.WriteLine("Cannot find any bus stops around the area. Try increasing search radius");
            }

            if (searchRadiusInMeters <= 0)
            {
                Console.WriteLine("Invalid search radius! Must be a positive integer");
            }

            if (response.IsSuccessful)
            {
                return response.Data.OrderBy(t => t.Distance).Take(2).ToList();
            }
            else
            {
                return new List<BusStop>();
            }
        }
    }
}
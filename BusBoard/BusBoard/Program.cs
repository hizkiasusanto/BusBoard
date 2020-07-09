using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a bus stop ID: ");
                var stopId = Console.ReadLine();

                var tflApiUrl = "https://api.tfl.gov.uk";

                var request = new RestRequest($"StopPoint/{stopId}/Arrivals");

                var incomingBusPredictions =
                    JsonConvert.DeserializeObject<List<IncomingBusPrediction>>(new RestClient(tflApiUrl).Get(request)
                        .Content);
                
                incomingBusPredictions = incomingBusPredictions
                    .OrderBy(t => t.TimeToArrival).ToList();

                QueryResponder.PrintBusArrivalSchedule(incomingBusPredictions);
            }
        }
    }
}
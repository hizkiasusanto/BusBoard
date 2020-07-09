using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;

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

                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("|{0,-10}|{1,-25}|{2,-25}|", "Bus Number", "Final Stop", "Time to Arrival (seconds)");
                Console.WriteLine("----------------------------------------------------------------");
                foreach (var incomingBusPrediction in incomingBusPredictions.Take(5))
                {
                    incomingBusPrediction.Print();
                }
            }
        }
    }
}
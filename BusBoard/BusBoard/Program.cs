using System;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    internal class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("\nEnter a postal code: ");
                var postCode = Console.ReadLine();
                
                var postCodeCoordinate = new PostCodeApi().GetCoordinate(postCode);

                var nearbyBusStops = new TflApi().GetNearbyBusStops(postCodeCoordinate);

                foreach (var busStop in nearbyBusStops)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Bus Stop Name: {busStop.CommonName}");
                    Console.WriteLine($"Bus Stop ID: {busStop.Id}");
                    QueryResponder.PrintBusArrivalSchedule(busStop.GetIncomingBusPredictions());
                }
            }
        }
    }
}
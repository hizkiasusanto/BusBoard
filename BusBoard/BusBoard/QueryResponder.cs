using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class QueryResponder
    {
        public static void PrintNearbyBusStopsArrivals(List<BusStop> nearbyBusStops)
        {
            if (nearbyBusStops.Count > 0){
                foreach (var busStop in nearbyBusStops)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Bus Stop Name: {busStop.CommonName}");
                    Console.WriteLine($"Bus Stop ID: {busStop.Id}");
                    PrintBusArrivalSchedule(new TflApiHandler().GetIncomingBusPredictions(busStop.Id));
                }
            }
        }
        public static void PrintBusArrivalSchedule(List<IncomingBusPrediction> incomingBusPredictions)
        {
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
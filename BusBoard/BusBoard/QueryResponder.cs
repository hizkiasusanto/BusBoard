using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class QueryResponder
    {
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
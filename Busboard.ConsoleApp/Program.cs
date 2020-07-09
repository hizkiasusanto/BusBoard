using System;

namespace BusBoard.ConsoleApp
{
    internal class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("\nEnter a postal code: ");
                var postCode = Console.ReadLine();
                Console.Write("Enter search radius in meters (default=200): ");
                int searchRadius  = int.Parse(Console.ReadLine());

                var postCodeCoordinate = new PostCodeApiHandler().GetCoordinate(postCode);

                var nearbyBusStops = new TflApiHandler().GetNearbyBusStops(postCodeCoordinate, searchRadius);

                QueryResponder.PrintNearbyBusStopsArrivals(nearbyBusStops);
            }
        }

        
    }
}
using System;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a postal code: ");
                var postCode = Console.ReadLine();
                
                var postCodeCoordinate = new PostCodeApi().GetCoordinate(postCode);

                var incomingBusPredictions = new TflApi().GetIncomingBusPredictions("490008660N");

                incomingBusPredictions = incomingBusPredictions
                    .OrderBy(t => t.TimeToStation).ToList();

                QueryResponder.PrintBusArrivalSchedule(incomingBusPredictions);
            }
        }
    }
}
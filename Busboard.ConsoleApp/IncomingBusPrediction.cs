using System;

namespace BusBoard.ConsoleApp
{
    public class IncomingBusPrediction
    {
        public string LineName { get; set; }
        public string DestinationName { get; set; }
        public int TimeToStation { get; set; }

        public void Print()
        {
            Console.WriteLine("|{0,-10}|{1,-25}|{2,-25}|",this.LineName,this.DestinationName,this.TimeToStation);
        }
    }
}
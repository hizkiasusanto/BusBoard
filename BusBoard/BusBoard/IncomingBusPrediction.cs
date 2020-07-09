using System;
using Newtonsoft.Json;

namespace BusBoard
{
    public class IncomingBusPrediction
    {
        [JsonProperty("lineName")] public string LineName { get; set; }
        [JsonProperty("destinationName")] public string DestinationName { get; set; }
        [JsonProperty("timeToStation")] public int TimeToStation { get; set; }

        public void Print()
        {
            Console.WriteLine("|{0,-10}|{1,-25}|{2,-25}|",this.LineName,this.DestinationName,this.TimeToStation);
        }
    }
}
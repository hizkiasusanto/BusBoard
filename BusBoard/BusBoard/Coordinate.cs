using Newtonsoft.Json;

namespace BusBoard
{
    public class Coordinate
    {
        [JsonProperty("longitude")] public float Longitude { get; set; }
        [JsonProperty("latitude")] public float Latitude { get; set; }
    }
}
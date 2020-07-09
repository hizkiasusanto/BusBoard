using System;
using RestSharp;

namespace BusBoard
{
    public class PostCodeApiHandler
    {
        private static string _url = "https://api.postcodes.io/postcodes";
        private readonly IRestClient _client = new RestClient(_url);
        
        public Coordinate GetCoordinate(string postCode)
        {
            var  request = new RestRequest(postCode);
            request.RootElement = "result";
            var response = _client.Execute<Coordinate>(request);

            if (!response.IsSuccessful)
            {
                Console.WriteLine("Invalid postal code");
            }
            
            return response.Data;
        }
    }
}
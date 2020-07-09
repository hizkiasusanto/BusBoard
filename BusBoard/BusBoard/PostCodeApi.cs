using System;
using RestSharp;

namespace BusBoard
{
    public class PostCodeApi : IApiHandler
    {
        private static string _url = "https://api.postcodes.io/postcodes";
        private IRestClient _client = new RestClient(_url);
        
        public string BaseUrl {
            get => _url;
            set => _url = value;
        }
        
        public IRestClient Client
        {
            get => _client;
            set => _client = value;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);
            
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new Exception(message, response.ErrorException);
            }
            return response.Data;
        }

        public Coordinate GetCoordinate(string postCode)
        {
            var  request = new RestRequest(postCode);
            request.RootElement = "result";

            return Execute<Coordinate>(request);
        }
    }
}
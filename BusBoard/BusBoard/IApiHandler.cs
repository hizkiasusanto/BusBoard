using System;
using RestSharp;

namespace BusBoard
{
    public interface IApiHandler
    {
        string BaseUrl { get; set; }
        IRestClient Client { get; set; }
        
        T Execute<T>(RestRequest request) where T : new();
    }
}
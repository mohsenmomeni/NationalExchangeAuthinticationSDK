using RestSharp;
using System;
using System.Net;

namespace NationalAuthorization.SDK
{
    public abstract class WebAPIRequest
    {
        public string Url { get; private set; }
        public WebAPIRequest(string url)
        {
            var uri = new Uri(url);
            this.Url = url;
        }

        protected abstract RestRequest CreateRestRequest();

        public IRestResponse ExecuteRequest()
        {
            RestClient restClient = new RestClient(this.Url);
            return restClient.Execute(this.CreateRestRequest());
        }
    }
}
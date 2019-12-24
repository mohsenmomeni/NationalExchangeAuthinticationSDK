using Newtonsoft.Json;
using RestSharp;
using Soshyant.Repo.Common;
using System;
using System.Collections.Generic;

namespace NationalAuthorization.SDK
{
    public class AccessTokenRequest : WebAPIRequest
    {
        public string Username { get; private set; }
        public string Password { get; private set; }


        public AccessTokenRequest(string url, string username, string password) : base(url)
        {
            this.Username = username;
            this.Password = password;
        }

        protected override RestRequest CreateRestRequest()
        {
            var dictionary = new Dictionary<string, object>
            {
                {"username", this.Username}, {"password", this.Password}
            };            
            RestRequest restRequest = new RestRequest(Method.POST) { Resource = this.Url };
            restRequest.AddJsonBody(dictionary);
            return restRequest;
        }
    }
}
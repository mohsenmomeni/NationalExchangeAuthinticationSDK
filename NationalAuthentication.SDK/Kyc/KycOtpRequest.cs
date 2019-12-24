using RestSharp;
using System.Collections.Generic;

namespace NationalAuthorization.SDK
{
    public class KycOtpRequest : WebAPIRequest
    {
        public string UniqueIdentifier { get; private set; }
        public string AccessToken { get; private set; }

        public KycOtpRequest(string url, string accessToken, string uniqeidentifier): base(url)
        {
            UniqueIdentifier = uniqeidentifier;
            AccessToken = accessToken;
        }

        protected override RestRequest CreateRestRequest()
        {
            var dictionary = new Dictionary<string, object>
            {
                {"uniqueidentifier", UniqueIdentifier}
            };
            RestRequest restRequest = new RestRequest(Method.POST) { Resource = Url };
            restRequest.AddJsonBody(dictionary);
            restRequest.AddHeader("Authorization", "Bearer " + AccessToken);
            return restRequest;
        }
    }
}
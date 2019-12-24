using RestSharp;
using System.Collections.Generic;

namespace NationalAuthorization.SDK
{
    public class KYCRequest : WebAPIRequest
    {
        public string UniqueIdentifier { get; private set; }
        public string AccessToken { get; private set; }
        public string Otp { get; private set; }

        public KYCRequest(string accessToken,
                string url,
                string identifier,
                string otp) : base(url.Substring(url.Length - 1, 1) == "/" ? url : url + "/")
        {
            UniqueIdentifier = identifier;
            AccessToken = accessToken;
            Otp = otp;
        }

        protected override RestRequest CreateRestRequest()
        {
            var dictionary = new Dictionary<string, object>
            {
                {"uniqueidentifier", UniqueIdentifier}
            };            
            RestRequest restRequest = new RestRequest(Method.GET) { Resource = Url + UniqueIdentifier };
            restRequest.AddParameter("otp", Otp);
            restRequest.AddHeader("Authorization", "Bearer " + AccessToken);
            return restRequest;
        }
    }
}
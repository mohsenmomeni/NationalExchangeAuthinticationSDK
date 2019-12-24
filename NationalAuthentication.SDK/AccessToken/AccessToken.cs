using Newtonsoft.Json;
using RestSharp;
using Soshyant.Repo.Common;
using System;
using System.Collections.Generic;

namespace NationalAuthorization.SDK
{
    public class AccessToken : RequestResponse
    {
        public string Token { get; set; }

        public TimeSpan? TTL { get; set; }

        public AccessToken(IRestResponse restResponse)
        {
            FillAccessToken(restResponse, 
                JsonConvert.DeserializeObject<Token>(restResponse.Content) as Token);
        }

        private void FillAccessToken(IRestResponse restResponse, Token token)
        {
            if (token == null)
            {
                EvaluateResponse(restResponse);
                return;
            }
            FillByToken(token);
        }

        private void FillByToken(Token result)
        {
            if (result.Error == null)
            {
                ValidationStatus = true;
                Token = result.Data?.AccessToken;
                TTL = result.Data?.TTL;
                return;
            }
            IssueFailure(result);
        }

         
    }
}
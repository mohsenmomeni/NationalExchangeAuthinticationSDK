using NationalAuthorization.SDK;
using System;

namespace NationalAuthorization.Tests
{
    public class AccessTokenProvider
    {
        private AccessToken aToken;
        private DateTime lastGetTime;

        public AccessTokenProvider()
        {

        }

        public string Token
        {
            get
            {
                if (aToken == null || aToken.TTL == null)
                {
                    GetAccessToken();
                }
                if (lastGetTime.Add(aToken.TTL.Value) > DateTime.Now)
                {
                    GetAccessToken();
                }
                return aToken.Token;
            }
        }

        private void GetAccessToken()
        {
            SejamRegistrar authorizer = new SejamRegistrar();
            AccessTokenRequest request = 
                new AccessTokenRequest(
                        SejamRegistrarTests.URL_ACCESS_TOKEN, 
                        SejamRegistrarTests.USERNAME, 
                        SejamRegistrarTests.PASSWORD);
            var accessToken = authorizer.GetAccessToken(request);
            if (accessToken != null)
            {
                this.aToken = accessToken;
                this.lastGetTime = DateTime.Now;
            }

        }
    }    
}

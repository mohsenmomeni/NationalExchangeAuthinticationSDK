using System;

namespace NationalAuthorization.SDK
{
    public class AccessTokenData
    {
        public string AccessToken { get; set; }
        public TimeSpan TTL { get; set; }
    }
}
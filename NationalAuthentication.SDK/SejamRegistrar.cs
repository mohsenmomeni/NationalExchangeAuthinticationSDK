namespace NationalAuthorization.SDK
{
    public class SejamRegistrar
    {
        public SejamRegistrar()
        {
           
        }

        public AccessToken GetAccessToken(AccessTokenRequest accessTokenRequest)
        {           
            return new AccessToken( accessTokenRequest.ExecuteRequest()) ;
        }

        public KycOtp GetKycOtp(KycOtpRequest request)
        {
            return new KycOtp( request.ExecuteRequest());
        }

        public KycResult GetKYC(KYCRequest kycRequest)
        {
            return new KycResult(kycRequest.ExecuteRequest());
        }
    }
}

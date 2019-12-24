using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace NationalAuthorization.SDK
{
    public class KycOtp : RequestResponse
    {
        public string Result { get; private set; }
        public KycOtp(IRestResponse restResponse):base()
        {            
            if (restResponse.StatusCode == System.Net.HttpStatusCode.NoContent
               && restResponse.IsSuccessful)
            {
                this.ValidationStatus = true;
                this.Result = "Otp Sent Successfully.";
            }
            else
            {
                this.ValidationStatus = false;
                FillKycOtpObject(restResponse,
                    JsonConvert.DeserializeObject<Info>(restResponse.Content) as Info);                
            }
        }

        private void FillKycOtpObject(IRestResponse restResponse, Info info)
        {
            if (info == null)
            {
                EvaluateResponse(restResponse);
                return;
            }
            IssueFailure(info);
        }
    }
}
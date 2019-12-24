using RestSharp;
using Soshyant.Repo.Common;
using System.Collections.Generic;

namespace NationalAuthorization.SDK
{
    public class RequestResponse
    {
        public bool ValidationStatus { get; set; }
        
        public List<ValidationMessage> ValidationMessages { get; set; }

        public RequestResponse()
        {
            ValidationMessages = new List<ValidationMessage>();
            ValidationStatus = false;
        }

        protected void Failure(string code, string message)
        {
            var validationMessage = new ValidationMessage(code, message);
            ValidationStatus = false;
            ValidationMessages.Add(validationMessage);
        }

        protected void EvaluateResponse(IRestResponse restResponse)
        {
            if (restResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Failure("0002", "Invalid url");
                return;
            }
            if (!string.IsNullOrEmpty(restResponse.ErrorMessage))
            {
                Failure("0001", restResponse.ErrorMessage);
                return;
            }
            Failure("0000", "Unhandled Exception");
            return;
        }

        protected void IssueFailure(Info result)
        {
            var message = GetMessage(result.Error.ErrorCode);
            if (message != null)
            {
                Failure(result.Error.ErrorCode, message);
            }
            else
            {
                Failure(result.Error.ErrorCode, result.Error.CustomMessage);
                Failure(result.Error.ErrorCode, result.Error.Exception);
            }
        }

        protected string GetMessage(string code)
        {
            return MessageRepository.ContainsKey(code) ? MessageRepository[code] : null;
        }

        private Dictionary<string, string> MessageRepository
        {
            get
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                keyValuePairs.Add("400", "Bad request");
                keyValuePairs.Add("403", "Forbidden");
                keyValuePairs.Add("2001", "Successful");
                keyValuePairs.Add("4010", "Unautorizad");
                keyValuePairs.Add("4041", "User not found");
                keyValuePairs.Add("4001", "Invalid Msisdn");
                keyValuePairs.Add("4002", "Invalid Otp. time");
                keyValuePairs.Add("4004", "Incomplete Registrations");
                keyValuePairs.Add("4005", "Invalid trace code");
                keyValuePairs.Add("4008", "Too large image");
                keyValuePairs.Add("4011", "Locked user");
                keyValuePairs.Add("4031", "Invalid Otp");
                keyValuePairs.Add("4042", "Undefined service");
                keyValuePairs.Add("4043", "Third party service not found");
                keyValuePairs.Add("4090", "Conflicts");
                keyValuePairs.Add("4150", "Unsupported Media Type");
                keyValuePairs.Add("4290", "Too many request");
                keyValuePairs.Add("500", "Unknown server error");
                keyValuePairs.Add("600", "Failed send sms");
                keyValuePairs.Add("601", "Failed payment");
                return keyValuePairs;
            }
        }
    }
}
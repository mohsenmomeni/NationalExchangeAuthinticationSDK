using NationalAuthorization.SDK.Kyc.KycDetail;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace NationalAuthorization.SDK
{
    public class KycResult : RequestResponse
    {

        public string Mobile { get; set; }
        public string Email { get; set; }

        public string UniqueIdentifier { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public PrivatePersonViewModel PrivatePerson { get; set; }

        public LegalPersonViewModel LegalPersonViewModel { get; set; }

        public List<AddressViewModel> Addresses { get; set; }


        public List<TradingCodeViewModel> TradingCodes { get; set; }
        public AgentViewModel Agent { get; set; }

        public List<BankingAccountViewModel> Accounts { get; set; }

        public JobInfoViewModel JobInfo { get; set; }

        public FinancialInfoViewModel FinancialInfo { get; set; }
        public List<LegalPersonShareholderViewModel> LegalPersonShareholder { get; set; }
        public List<LegalPersonStakeholderViewModel> LegalPersonStakeholders { get; set; }

        public KycResult(IRestResponse restResponse)
        {
            this.ValidationStatus = true;
            KycResult kyc = JsonConvert.DeserializeObject<KycResult>(restResponse.Content) as KycResult;
        }
    }
}
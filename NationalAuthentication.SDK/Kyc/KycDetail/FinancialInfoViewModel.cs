using System.Collections.Generic;

namespace NationalAuthorization.SDK.Kyc.KycDetail
{
    public class FinancialInfoViewModel
    {
        public long? AssetsValue { get; set; }
        public long? IncomingAverage { get; set; }
        public long? SExchangeTransaction { get; set; }
        public long? CExchangeTransaction { get; set; }
        public long? OutExchangeTransaction { get; set; }
        public string TransactionLevel { get; set; }
        public string TradingKnowledgeLevel { get; set; }

        public string CompanyPurpose { get; set; }

        public string ReferenceRateCompany { get; set; }

        public string RateDate { get; set; }

        public int? Rate { get; set; }

        public List<FinancialBrokerViewModel> FinancialBrokers { get; set; }

    }

}

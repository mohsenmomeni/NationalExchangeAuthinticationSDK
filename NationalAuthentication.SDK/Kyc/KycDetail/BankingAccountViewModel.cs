namespace NationalAuthorization.SDK.Kyc.KycDetail
{
    public class BankingAccountViewModel
    {
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public string Sheba { get; set; }
        public BankViewModel Bank { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public Identifier BranchCity { get; set; }
        public bool? IsDefault { get; set; }
    }
}

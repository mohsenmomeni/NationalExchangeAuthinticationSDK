namespace NationalAuthorization.SDK.Kyc.KycDetail
{
    public class LegalPersonShareholderViewModel
    {
        public string UniqueIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string PositionType { get; set; }
        public int? PercentageVotingRight { get; set; }
    }
}

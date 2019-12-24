namespace NationalAuthorization.SDK.Kyc.KycDetail
{
    public class AgentViewModel
    {
        public string Type { get; set; }
        public string ExpirationDate { get; set; }
        public string Description { get; set; }

        public string UniqueIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool? IsConfirmed { get; set; }

    }
}

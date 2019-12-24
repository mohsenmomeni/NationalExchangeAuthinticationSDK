namespace NationalAuthorization.SDK.Kyc.KycDetail
{
    public class LegalPersonStakeholderViewModel
    {
        public string UniqueIdentifier { get; set; }
        public string Type { get; set; }
        public string PositionType { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public bool? IsOwnerSignature { get; set; }


    }
}

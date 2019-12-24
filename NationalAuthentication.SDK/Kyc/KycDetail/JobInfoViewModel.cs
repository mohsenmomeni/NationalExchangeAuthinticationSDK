namespace NationalAuthorization.SDK.Kyc.KycDetail
{
    public class JobInfoViewModel
    {
        public string EmploymentDate { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyCityPrefix { get; set; }
        public string CompanyPhone { get; set; }
        public string Position { get; set; }
        public string CompanyFaxPrefix { get; set; }
        public string CompanyFax { get; set; }
        public JobViewModel Job { get; set; }
    }
}

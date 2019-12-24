namespace NationalAuthorization.SDK.Kyc.KycDetail
{
    public class AddressViewModel
    {
        public string PostalCode { get; set; }
        public Identifier Country { get; set; }
        public Identifier Province { get; set; }
        public Identifier City { get; set; }
        public Identifier Section { get; set; }
        public string CityPrefix { get; set; }
        public string RemnantAddress { get; set; }
        public string Alley { get; set; }
        public string Plaque { get; set; }
        public string Tel { get; set; }
        public string CountryPrefix { get; set; }
        public string Mobile { get; set; }
        public string EmergencyTel { get; set; }
        public string EmergencyTelCityPrefix { get; set; }
        public string EmergencyTelCountryPrefix { get; set; }
        public string FaxPrefix { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
    }
}
namespace CleanArchitecture.Application.Models.Identity
{
    //Stored inside Client App Settings
    public class JWTSettings
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public string Issuer { get; set; }
        public string DurationInMinutes { get; set; }
    }
}

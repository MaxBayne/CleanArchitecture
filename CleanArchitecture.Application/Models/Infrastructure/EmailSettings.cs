namespace CleanArchitecture.Application.Models.Infrastructure
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}

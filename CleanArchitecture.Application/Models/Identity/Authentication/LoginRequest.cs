namespace CleanArchitecture.Application.Models.Identity.Authentication
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string SecurityStamp { get; set; } = "123";
    }
}

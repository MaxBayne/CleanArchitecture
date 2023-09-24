
namespace CleanArchitecture.Application.Models.Identity
{
    public class LoginRequest
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}

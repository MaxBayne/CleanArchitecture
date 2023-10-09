using CleanArchitecture.Application.Models.Identity;

namespace CleanArchitecture.Application.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);

        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}

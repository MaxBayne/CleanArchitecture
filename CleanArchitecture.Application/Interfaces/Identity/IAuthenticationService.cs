using CleanArchitecture.Application.Models.Identity.Authentication;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Interfaces.Identity
{
    public interface IAuthenticationService
    {
        Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest request);

        Task<Result<LoginResponse>> LoginAsync(LoginRequest request);

        /// <summary>
        /// Get All Users inside Role Users
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUsers();

        /// <summary>
        /// Get All Users inside Role Supervisors
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetSupervisors();

        /// <summary>
        /// Get All Users inside Role Administrators
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAdministrators();
    }
}

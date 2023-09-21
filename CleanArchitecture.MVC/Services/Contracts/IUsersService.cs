using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.ViewModels.User;

namespace CleanArchitecture.MVC.Services.Contracts
{
    public interface IUsersService
    {
        Task<ApiResponse<List<UserViewModel>>> GetUsers();
        Task<ApiResponse<UserViewModel>> GetUser(int id);

        Task<ApiResponse<UserViewModel>> CreateUser(CreateUserViewModel user);
        Task<ApiResponse>UpdateUser(UpdateUserViewModel user);
        Task<ApiResponse> DeleteUser(int userId);
    }
}

using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.ViewModels.User;

namespace CleanArchitecture.MVC.Services.Contracts
{
    public interface IUsersService
    {
        Task<List<List<UserViewModel>>> GetUsers();
        Task<List<UserViewModel>> GetUser();

        Task<ApiResponse<UserViewModel>> CreateUser(CreateUserViewModel user);
        Task UpdateUser(UpdateUserViewModel user);
        Task DeleteUser(DeleteUserViewModel user);
    }
}

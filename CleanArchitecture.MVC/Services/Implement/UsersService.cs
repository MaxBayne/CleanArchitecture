using AutoMapper;
using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.ViewModels.User;

namespace CleanArchitecture.MVC.Services.Implement
{
    public class UsersService:ApiService,IUsersService
    {
        public UsersService(IMapper mapper, IApiClient apiClient, ILocalStorageService localStorage) : base(mapper, apiClient, localStorage) { }


        public async Task<List<List<UserViewModel>>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserViewModel>> GetUser()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<UserViewModel>> CreateUser(CreateUserViewModel user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(UpdateUserViewModel user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(DeleteUserViewModel user)
        {
            throw new NotImplementedException();
        }

        
    }
}

using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.ViewModels.User;

namespace CleanArchitecture.MVC.Services.Implement
{
    public class UsersService:ApiService,IUsersService
    {
        public UsersService(IMapper mapper, IApiClient apiClient, ILocalStorageService localStorage) : base(mapper, apiClient, localStorage) { }

        public async Task<ApiResponse<List<UserViewModel>>> GetUsers()
        {
            return  await GetAsync<List<UserDto>, List<UserViewModel>>("users");
        }

        public async Task<ApiResponse<UserViewModel>> GetUser(int id)
        {
            return await GetAsync<UserDto, UserViewModel>($"users/{id}");
        }

        public async Task<ApiResponse<UserViewModel>> CreateUser(CreateUserViewModel user)
        {
            return await PostAsync<UserDto, UserViewModel>("users",user);
        }

        public async Task<ApiResponse> UpdateUser(UpdateUserViewModel user)
        {
            var result = await PutAsync<UserDto, UserViewModel>($"users/{user.Id}", user);

            return new ApiResponse(result.IsSuccess,result.Message, result.ValidationErrors);


        }

        public async Task<ApiResponse> DeleteUser(int userId)
        {
            var result = await DeleteAsync<UserDto, UserViewModel>($"users/{userId}");

            return new ApiResponse(result.IsSuccess, result.Message, result.ValidationErrors);

        }
    }
}

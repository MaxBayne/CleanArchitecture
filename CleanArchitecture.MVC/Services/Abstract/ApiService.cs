using System.Net.Http.Headers;
using AutoMapper;
using CleanArchitecture.MVC.Services.Contracts;

namespace CleanArchitecture.MVC.Services.Abstract
{
    public abstract class ApiService:IApiService
    {
        protected IMapper Mapper;
        protected IApiClient ApiClient;
        protected readonly ILocalStorageService LocalStorage;


        protected ApiService(IMapper mapper,IApiClient apiClient,ILocalStorageService localStorage)
        {
            ApiClient = apiClient;
            LocalStorage = localStorage;
            Mapper=mapper;
        }


        void IApiService.AddBearerTokenInRequestHeader()
        {
            if (LocalStorage.Exist("token"))
            {
                ApiClient.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.GetStorageValue<string>("token"));
            }
        }

    }

}

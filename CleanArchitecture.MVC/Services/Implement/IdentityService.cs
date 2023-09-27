using AutoMapper;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.ViewModels.Account;


namespace CleanArchitecture.MVC.Services.Implement
{
    public class IdentityService: ApiService,IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IMapper mapper, IApiClient apiClient, ILocalStorageService localStorage,IHttpContextAccessor httpContextAccessor) : base(mapper, apiClient, localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<bool> Login(string username, string password,string securityStamp)
        {

            try
            {
                /*
                //Try To Login using Api and Identity Service
                var loginResult = await PostAsync<,LoginViewModel>("Identity/login", new LoginRequest
                {
                    UserName = username,
                    UserPassword = password,
                    SecurityStamp = securityStamp
                });

                //if login failed ----------------------
                if (!loginResult.IsSuccess)
                {
                    ModelState.AddModelError("", "Login Attempt Failed . Please try again");
                    return View(loginVm);
                }

                //if login Success ---------------------

                //create user Principal that contain its claims
                var claimsIdentity = new ClaimsIdentity(loginResult.UserClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                //sign-in user Principal inside httpContext
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                //store user Token inside LocalStorage
                _localStorageService.SetStorageValue<string>("token", loginResult.UserToken);
                */
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Register(string username, string password, string email)
        {
            throw new NotImplementedException();
        }
    }
}

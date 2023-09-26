using System.Security.Claims;
using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.Services.Implement;
using CleanArchitecture.MVC.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly ILocalStorageService _localStorageService;

        public AccountController(IIdentityService identityService,ILocalStorageService _localStorageService)
        {
            _identityService = identityService;
            this._localStorageService = _localStorageService;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            //Validate Model
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Try To Login using Api and Identity Service
            var loginResult = await _identityService.LoginAsync(new LoginRequest
            {
                UserName = loginVm.UserName,
                UserPassword = loginVm.UserPassword,
                SecurityStamp = loginVm.SecurityStamp
            });

            //if login failed ----------------------
            if (!loginResult.IsSuccess)
            {
                ModelState.AddModelError("","Login Attempt Failed . Please try again");
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

            //Redirect User to returnUrl
            return LocalRedirect(loginVm.ReturnUrl);
        }

        //[HttpGet]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    _localStorageService.ClearStorage("token");

        //    //return RedirectToAction(actionName: "Index",controllerName: "HomeController");
        //}

       

    }
}

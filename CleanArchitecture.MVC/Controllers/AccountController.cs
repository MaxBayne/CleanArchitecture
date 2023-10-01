﻿using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;
        

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        
        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            try
            {
                //Validate Model
                if (!ModelState.IsValid)
                {
                    return View(loginVm);
                }

                //Try To Login using Api and Identity Service
                var loginResult = await _identityService.Login(loginVm.UserName, loginVm.UserPassword, loginVm.SecurityStamp);

                //if login failed ----------------------
                if (!loginResult)
                {
                    ModelState.AddModelError("", "Login Attempt Failed . Please try again");
                    return View(loginVm);
                }

                //if login Success ---------------------

                //Redirect User to returnUrl
                return LocalRedirect(loginVm.ReturnUrl);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(loginVm);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //Try To Login using Api and Identity Service
            await _identityService.Logout();

            return RedirectToAction(actionName: "Index",controllerName: "Home");
        }

        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Register(RegisterViewModel registerVm)
        //{
        //    return View();
        //}


    }
}

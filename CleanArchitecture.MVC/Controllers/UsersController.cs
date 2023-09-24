using AutoMapper;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService,IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        #region Get List

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            //Get List of Users
            var response = await _usersService.GetUsers();

            return View(response.Data);
        }


        #endregion

        #region Get Item

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(int id)
        { 
            //get user info
            var response = await _usersService.GetUser(id);

            return View(response.Data);
        }

        #endregion

        #region Create

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel userViewModel)
        {
            try
            {
                //create user 
                var response = await _usersService.CreateUser(userViewModel);

                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in response.ValidationErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
            }

            return View(userViewModel);
        }

        #endregion

        #region Update

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //get user info
            var response = await _usersService.GetUser(id);

            //Map UserViewModel To UpdateUserViewModel
            var model = _mapper.Map<UpdateUserViewModel>(response.Data);

            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateUserViewModel userViewModel)
        {
            try
            {
                //update user 
                var response = await _usersService.UpdateUser(userViewModel);

                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in response.ValidationErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(userViewModel);
        }

        #endregion

        #region Delete

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //get user info
            var response = await _usersService.GetUser(id);

            //Map UserViewModel To DeleteUserViewModel
            var model = _mapper.Map<DeleteUserViewModel>(response.Data);

            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,DeleteUserViewModel user)
        {
            try
            {
                user.Id = id;

                //delete user 
                var response = await _usersService.DeleteUser(user.Id);

                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in response.ValidationErrors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(user);
        }

        #endregion

    }
}

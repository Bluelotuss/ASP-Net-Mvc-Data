using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Identity;
using ASP_Net_Mvc_Data.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Net_Mvc_Data.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) // Constructor Injection
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous] //Allows anyone to access, even if you are not loged in. This one overrides the Authorize.
        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken] // Validating preferable for login.
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)    //Create viewmodel
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false); // username, password, presistlogin, lockout

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                /*if (result.IsLockedOut)
                {

                }*/
                ViewBag.Msg = "Failed to login";
            }

            return View();
        }

        [AllowAnonymous] //Allows anyone to access, even if you are not loged in. This one overrides the Authorize.
        [HttpGet]
        public IActionResult SignUp()
        {
            SignUpViewModel signUpViewModel = new SignUpViewModel();
            return View(signUpViewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)    //Create viewmodel
        {
            AppUser appUser = new AppUser();
            appUser.UserName = signUpViewModel.UserName;

            appUser.FirstName = signUpViewModel.FirstName;
            appUser.LastName = signUpViewModel.LastName;
            appUser.DOB = signUpViewModel.DOB;

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(appUser, signUpViewModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.UpdateAsync(appUser);
                    return RedirectToAction("Login");
                }
            }
            //result.Errors //Don't give out to user, contains sensitive info.
            ViewBag.Msg = "Failed to sign up.";

            return View(signUpViewModel);
        }

        //[Authorize] not needed here because the controller is set to demand this.
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //Change Password/Username ....
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_Net_Mvc_Data.Models;
using Microsoft.AspNetCore.Identity;
using ASP_Net_Mvc_Data.Models.Identity;

namespace ASP_Net_Mvc_Data.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            if (! _roleManager.Roles.Any())
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).Wait();

                _roleManager.CreateAsync(new IdentityRole("Member")).Wait();

                AppUser superAdmin = new AppUser() { UserName = "SuperAdmin" };

                _userManager.CreateAsync(superAdmin, "Qwerty123456!").Wait();

                superAdmin = _userManager.FindByNameAsync("SuperAdmin").Result;

                _userManager.AddToRoleAsync(superAdmin, "Admin").Wait();
            }

            return View();
        }
    }
}

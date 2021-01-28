﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Net_Mvc_Data.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> AddAdmin(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser != null)
            {
                var result = await _userManager.AddToRoleAsync(appUser, "Admin");
            }

                return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveAdmin(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser != null && appUser.UserName != "SuperAdmin")
            {
                var result = await _userManager.RemoveFromRoleAsync(appUser, "Admin");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddMember(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser != null)
            {
                var result = await _userManager.AddToRoleAsync(appUser, "Member");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveMember(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser != null)
            {
                var result = await _userManager.RemoveFromRoleAsync(appUser, "Member");
            }

            return RedirectToAction("Index");
        }
    }
}

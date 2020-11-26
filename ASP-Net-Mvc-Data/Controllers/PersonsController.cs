﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Net_Mvc_Data.Controllers
{
    public class PersonsController : Controller
    {
        private IPeopleService _peopleService = new PeopleService();


        public IActionResult Index()
        {
            var result = _peopleService.All();

            return View(result);
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel filter)
        {
            var result = _peopleService.FindBy(filter);

                return View(result);
        }

        [HttpPost]
        public IActionResult Create(PeopleViewModel person)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person.CreatePerson);

                return RedirectToAction(nameof(Index));
            }
            return View("Index", person);
        }

        public IActionResult Delete(string id)
        {
            _peopleService.Remove(int.Parse(id));

            return RedirectToAction(nameof(Index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Services;
using ASP_Net_Mvc_Data.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Net_Mvc_Data.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IPeopleService _peopleService;
        private readonly ICountryService _countryService;

        public PeopleController(ICityService cityService, IPeopleService peopleService, ICountryService countryService)
        {
            _cityService = cityService;
            _peopleService = peopleService;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            var result = _peopleService.All();
            return View(result);
        }

        public ActionResult Details(int id)         //Why not Iaction?
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public ActionResult Create()
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();

            createPersonViewModel.CityList = _cityService.All();



            return View(createPersonViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePersonViewModel createPerson)
        {
            City city = _cityService.FindBy(createPerson.City.Id);

            //person.Name = createPerson.Name;
            //person.PhoneNumber = createPerson.PhoneNumber;
            createPerson.City = city;                   // For the hook. Not fully following. 
            

            if (ModelState.IsValid)
            {
                Person addPerson = _peopleService.Add(createPerson);

                return RedirectToAction(nameof(Index));
            }
                return View(createPerson);
        }
    }
}

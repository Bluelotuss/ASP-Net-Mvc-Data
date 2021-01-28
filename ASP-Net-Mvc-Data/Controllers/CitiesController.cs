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
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CitiesController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        public ActionResult Index()                 //Why not IAction?
        {
            return View(_cityService.All());
        }

        public ActionResult Create()
        {
            CreateCityViewModel createCityViewModel = new CreateCityViewModel();
            createCityViewModel.CountryList = _countryService.All();                     //Why sending in cCVM with all? (So they can be displayed in dropdown)


            return View(createCityViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]                  //What is antiforgerytoken? "special safety for intruders"
        public ActionResult Create(CreateCityViewModel createCity)
        {
            Country country = _countryService.FindBy(createCity.Country.Id);

            //person.Name = createPerson.Name;
            //person.PhoneNumber = createPerson.PhoneNumber;
            createCity.Country = country;

            if (ModelState.IsValid)
            {
                City city = _cityService.Add(createCity);

                if (city == null)
                {
                    ModelState.AddModelError("msg", "Database problems");
                    return View(createCity);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createCity);
            }
        }

        public ActionResult AddCountry()
        {
            AddCountryViewModel addCountryViewModel = new AddCountryViewModel();

            addCountryViewModel.CityList = _cityService.All();
            addCountryViewModel.CountryList = _countryService.All();

            return View(addCountryViewModel);
        }

        [HttpPost]
        public ActionResult AddCountry(AddCountryViewModel addCountry)
        {
            return View(addCountry);
        }
    }
}

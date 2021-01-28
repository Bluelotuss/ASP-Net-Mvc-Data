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
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        private readonly ICityService _cityService;

        public CountriesController(ICountryService countryService, ICityService cityService)
        {
            _countryService = countryService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var result = _countryService.All();
            return View(result);
        }

        public ActionResult Create()
        {
            CreateCountryViewModel createCountryViewModel = new CreateCountryViewModel();
            //createCountryViewModel.CityList = _cityService.All();                      //Why sending in cCVM with all?


            return View(createCountryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]                  //What is antiforgerytoken? "special safety for intruders"
        public ActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                Country country = _countryService.Add(createCountry);

                if (country == null)
                {
                    ModelState.AddModelError("msg", "Database problems");
                    return View(createCountry);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createCountry);
            }
        }
    }
}

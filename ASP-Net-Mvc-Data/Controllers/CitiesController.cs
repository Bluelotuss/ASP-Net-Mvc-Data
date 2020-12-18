using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Net_Mvc_Data.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: /<controller>/
        public ActionResult Index()
        {
            return View(_cityService.All());
        }

        public ActionResult Create()
        {
            CreateCityViewModel createCityViewModel = new CreateCityViewModel();
            createCityViewModel.CityList = _cityService.All();


            return PartialView("createCityViewModel");
        }
    }
}

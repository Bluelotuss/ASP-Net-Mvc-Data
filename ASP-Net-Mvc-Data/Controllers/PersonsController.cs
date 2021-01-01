using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Services;
using ASP_Net_Mvc_Data.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Net_Mvc_Data.Controllers
{
    public class PersonsController : Controller
    {
        //private IPeopleService _peopleService = new PeopleService();

        private readonly IPeopleService _peopleService;

        public PersonsController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

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

            //Testing branches
            //Testing

            return RedirectToAction(nameof(Index));
        }

       
        /*public IActionResult AjaxFindByCityOrName(string filter)
        {
            

            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.Search = filter;

            PeopleViewModel newSearch = _peopleService.FindBy(peopleViewModel);

            if (newSearch == null)
            {
                return NotFound(); //404
            }
            else
            {
                return PartialView("_ListPersonPartialView", newSearch);
            }
        }*/
    }
}

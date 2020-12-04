using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Services;

namespace ASP_Net_Mvc_Data.Controllers
{
    public class AjaxPersonsController : Controller
    {
        private IPeopleService _peopleService = new PeopleService();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AjaxFindByCityOrName(string filter)
        {
            PeopleViewModel peopleViewModel = new PeopleViewModel();

            peopleViewModel.Search = filter;

           
            if (peopleViewModel.Search == null)
            {
                var allPeople = _peopleService.All();

                //Response.StatusCode = 400;

                return PartialView("_ListPersonPartialView", allPeople);
            }
            else
            {
                var newSearch = _peopleService.FindBy(peopleViewModel);
                return PartialView("_ListPersonPartialView", newSearch);
            }
        }

        [HttpGet]
        public IActionResult CreateForm()
        {
            return PartialView("_PersonCreateAjaxPartialView");
        }

        [HttpPost]
        public IActionResult AjaxCreateForm(CreatePersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Add(personViewModel);

                return PartialView("_PersonPartialView", person);
            }

            Response.StatusCode = 400;

            return PartialView("_PersonCreateAjaxPartialView", personViewModel);
        }

        public IActionResult AjaxDelete(string id)
        {
             if (_peopleService.Remove(int.Parse(id)))
            {
                return Ok();
            } else
            {
                return NotFound(); //404
            }
        }

        [HttpGet]           //Is this necessary for get methods?
        public IActionResult AjaxEdit(int id)
        {
            Person person = _peopleService.FindBy(id);

            return PartialView("_EditPersonAjaxPartialView", person);
        }

        [HttpPost]
        public IActionResult AjaxEditForm(Person person, string id)
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();

            createPersonViewModel.Name = person.Name;
            createPersonViewModel.PhoneNumber = person.PhoneNumber;
            createPersonViewModel.City = person.City;

            if (TryValidateModel(createPersonViewModel))
            {
                Person editedPerson = _peopleService.Edit(int.Parse(id), person);

                return PartialView("_PersonPartialView", editedPerson);
            }

            Response.StatusCode = 400;

            return PartialView("_EditPersonAjaxPartialView", person);
        }
    }
}

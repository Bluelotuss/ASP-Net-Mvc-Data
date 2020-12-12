using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Services;
using Microsoft.Extensions.Logging;

namespace ASP_Net_Mvc_Data.Controllers
{
    public class AjaxPersonsController : Controller
    {
        //private IPeopleService _peopleService = new PeopleService();

        private readonly IPeopleService _peopleService;
        private readonly ILogger _logger;

        public AjaxPersonsController(IPeopleService peopleService, ILogger<AjaxPersonsController> logger)
        {
            _peopleService = peopleService;
            _logger = logger;
        }

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
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel() {

                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                City = person.City
        };

            if (TryValidateModel(createPersonViewModel))
            {
                Person editedPerson = _peopleService.Edit(int.Parse(id), person);

                return PartialView("_PersonPartialView", editedPerson);
            }

            Response.StatusCode = 400;

            return PartialView("_EditPersonAjaxPartialView", person);
        }

        public IActionResult AjaxNextPage(int currentPage, int numOfPages, int recordsPerPage)
        {
            PeopleViewModel allPeople = _peopleService.All();
            PeopleViewModel newList = new PeopleViewModel();

            var rangeIndex = (currentPage * recordsPerPage) - 3;

            var numOfListItems = allPeople.PersonList.Count;

            if (numOfPages > currentPage)
            {
                var endCount = recordsPerPage;
                var result = allPeople.PersonList.GetRange(rangeIndex, endCount);

                foreach (Person person in result)
                {
                    newList.PersonList.Add(person);
                }

            }
            else
            { 

            var endCountCalc = currentPage - 1;                     //To get right amount on page 3
            var endCount = numOfListItems - (recordsPerPage * endCountCalc);

            var result = allPeople.PersonList.GetRange(rangeIndex, endCount);

            foreach (Person person in result)
            {
                newList.PersonList.Add(person);
            }
            }
            return PartialView("_ListPersonPartialView", newList);
        }

        public IActionResult AjaxPrevPage(int currentPage, int numOfPages, int recordsPerPage)
        {
            PeopleViewModel allPeople = _peopleService.All();
            PeopleViewModel newList = new PeopleViewModel();

            var rangeIndex = (currentPage * recordsPerPage) - 3;

            var numOfListItems = allPeople.PersonList.Count;


            var result = allPeople.PersonList.GetRange(rangeIndex, recordsPerPage);

            foreach (Person person in result)
            {
                newList.PersonList.Add(person);
            }

            return PartialView("_ListPersonPartialView", newList);
        }

        public IActionResult AjaxPage(int currentPage, int numOfPages, int recordsPerPage, int numOfPageItems)
        {
            PeopleViewModel newList = _peopleService.PageList(currentPage, recordsPerPage, numOfPageItems);

            return PartialView("_ListPersonPartialView", newList);
        }
    }
}

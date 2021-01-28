using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Services;
using ASP_Net_Mvc_Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Net_Mvc_Data.Controllers
{
    public class PersonLanguageController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly IPersonLanguageService _personLanguageService;
        private readonly ILanguageService _languageService;

        public PersonLanguageController(IPeopleService peopleService, IPersonLanguageService personLanguageService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _personLanguageService = personLanguageService;
            _languageService = languageService;
        }
        
        public IActionResult Index()
        {
            var result = _personLanguageService.All();

            var result2 = _peopleService.All().PersonList
                .Select(p => new PersonLanguageViewModel
                {
                    PersonLanguageId = p.Id,
                    PersonName = p.Name,
                    ListOfLanguages = p.PersonLanguageList
                    .Select(m => m.Language.LanguageTitle)
                    .ToList()
                })
                .ToList();

            //var languagesGroupedByPerson = result.PersonLanguages.GroupBy(i => i.Language);



            //result.PeopleList.GroupBy(person => person.Id);
                

            //var result = _personLanguageService.All();
            return View(result2);
        }

        public ActionResult AddLanguageToPerson()
        {
            PersonLanguageViewModel personLanguageViewModel = new PersonLanguageViewModel();
            //PeopleViewModel peopleViewModel = new PeopleViewModel();

            var resultPeopleViewModel = _peopleService.All();

            personLanguageViewModel.PeopleList = resultPeopleViewModel.PersonList;
            personLanguageViewModel.LanguageList = _languageService.All();

            return View(personLanguageViewModel);
        }

        [HttpPost]
        public ActionResult AddLanguageToPerson(PersonLanguageViewModel personLanguageViewModel)
        {
            if (ModelState.IsValid)
            {
                PersonLanguage personLanguage = _personLanguageService.Add(personLanguageViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(personLanguageViewModel);
        }

        public ActionResult Details(int id)         //Why not Iaction?
        {
            PersonLanguageViewModel newModel = new PersonLanguageViewModel();
            var result = _personLanguageService.FindBy(id);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            newModel.PersonName = result.PersonLanguages[0].Person.Name;

            newModel.ListOfLanguages = result.PersonLanguages
                .Select(l => l.Language.LanguageTitle).ToList();

            newModel.SpokenLanguages = string.Join<string>(", ", newModel.ListOfLanguages);

            return View(newModel);
        }
    }
}

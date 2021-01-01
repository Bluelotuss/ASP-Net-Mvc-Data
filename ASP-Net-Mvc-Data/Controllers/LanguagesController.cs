using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Database;
using ASP_Net_Mvc_Data.Models.Services;
using ASP_Net_Mvc_Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Net_Mvc_Data.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IPeopleService _peopleService;
        private readonly PeopleDbContext _context;

        public LanguagesController(ILanguageService languageService, IPeopleService peopleService, PeopleDbContext context)
        {
            _languageService = languageService;
            _peopleService = peopleService;
            _context = context;
        }

        public ActionResult Index()
        {
            var result = _languageService.All();

            return View(result);
        }

        public ActionResult Create()
        {
            CreateLanguageViewModel createLanguageViewModel = new CreateLanguageViewModel();

            return View(createLanguageViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguageViewModel createLanguageViewModel)
        {
            if (ModelState.IsValid)
            {
                Language language = _languageService.Add(createLanguageViewModel);

                if (language == null)
                {
                    ModelState.AddModelError("msg", "Database problems");
                    return View(createLanguageViewModel);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createLanguageViewModel);
            }
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
            var personID = personLanguageViewModel.Person.Id;
            var languageID = personLanguageViewModel.Language.Id;

            var existingItems = _context.PersonLanguage
                .Where(pl => pl.PersonID == personID)
                .Where(pl => pl.LanguageID == languageID).ToList();

            if (existingItems.Count == 0)
            {
                PersonLanguage newItem = new PersonLanguage
                {
                    Person = _context.People.Single(p => p.Id == personID),
                    Language = _context.Language.Single(l => l.Id == languageID)
                };

                _context.PersonLanguage.Add(newItem);
                _context.SaveChanges();
                

            }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

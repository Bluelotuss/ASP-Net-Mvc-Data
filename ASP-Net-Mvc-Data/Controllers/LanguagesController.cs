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

        public LanguagesController(ILanguageService languageService, IPeopleService peopleService)
        {
            _languageService = languageService;
            _peopleService = peopleService;
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
    }
}

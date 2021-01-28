using System;
using System.Collections.Generic;
using ASP_Net_Mvc_Data.Models.Data;
using ASP_Net_Mvc_Data.Models.ViewModels;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public class PersonLanguageService : IPersonLanguageService
    {
        private readonly IPersonLanguageRepo _personLanguageRepo;

        public PersonLanguageService(IPersonLanguageRepo personLanguageRepo)
        {
            _personLanguageRepo = personLanguageRepo;
        }

        public PersonLanguage Add(PersonLanguageViewModel personLanguageViewModel)
        {
            return _personLanguageRepo.Create(personLanguageViewModel.Person, personLanguageViewModel.Language);
        }

        public PersonLanguageViewModel All()
        {
            PersonLanguageViewModel plvm = new PersonLanguageViewModel();
            plvm.PersonLanguages = _personLanguageRepo.Read();
            return plvm;
        }

        public PersonLanguageViewModel FindBy(PersonLanguageViewModel search)
        {
            PersonLanguageViewModel plvm = new PersonLanguageViewModel();
            return plvm;
        }

        public PersonLanguageViewModel FindBy(int id)
        {
            PersonLanguageViewModel plvm = new PersonLanguageViewModel();
            plvm.PersonLanguages = _personLanguageRepo.Read(id);
            return plvm;
        }

        public PersonLanguage Edit(int id, Person person, Language language)
        {
            PersonLanguage personLanguage = new PersonLanguage();
            return personLanguage;
        }

        public bool Remove(int id)
        {
            return true;
        }
    }
}

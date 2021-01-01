using System;
using System.Collections.Generic;
using ASP_Net_Mvc_Data.Models.Data;
using ASP_Net_Mvc_Data.Models.ViewModels;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }

        public Language Add(CreateLanguageViewModel createLanguageViewModel)
        {
            Language language = new Language() { LanguageTitle = createLanguageViewModel.LanguageTitle };
            return _languageRepo.Create(language);
        }

        public List<Language> All()
        {
            return _languageRepo.Read();
        }

        public Language FindBy(int id)
        {
            return _languageRepo.Read(id);
        }

        public Language Edit(int id, Language language)
        {
            Language editedLanguage = new Language() { Id = id, LanguageTitle = language.LanguageTitle };
            return _languageRepo.Update(editedLanguage);
        }
         
        public bool Remove(int id)
        {
            Language language = _languageRepo.Read(id);
            if (language == null)
            {
                return false;
            }
            else
            {
                return _languageRepo.Delete(language);
            }
        }
    }
}

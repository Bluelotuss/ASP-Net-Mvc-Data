using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.ViewModels;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public interface IPersonLanguageService
    {
        public PersonLanguage Add(PersonLanguageViewModel personLanguageViewModel);
        public PersonLanguageViewModel All();
        public PersonLanguageViewModel FindBy(PersonLanguageViewModel search);
        public PersonLanguageViewModel FindBy(int id);
        public PersonLanguage Edit(int id, Person person, Language language);
        public bool Remove(int id);
    }
}

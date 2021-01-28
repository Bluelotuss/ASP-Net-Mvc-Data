using System;
using System.Collections.Generic;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class PersonLanguageViewModel
    {
        public int PersonLanguageId { get; set; }
        public Person Person { get; set; }
        public List<Person> PeopleList { get; set; }
        public string PersonName { get; set; }

        public Language Language { get; set; }

        public string SpokenLanguages { get; set; }
        public List<Language> LanguageList { get; set; }

        public List<PersonLanguage> PersonLanguages { get; set; }

        public IEnumerable<string> ListOfLanguages { get; set; }

        public PersonLanguageViewModel()
        {
            PersonLanguages = new List<PersonLanguage>();
        }
    }
}

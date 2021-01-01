using System;
using System.Collections.Generic;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class PersonLanguageViewModel
    {
        public Person Person { get; set; }
        public List<Person> PeopleList { get; set; }

        public Language Language { get; set; }
        public List<Language> LanguageList { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ASP_Net_Mvc_Data.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageTitle { get; set; }

        public List<PersonLanguage> PersonLanguageList { get; set; }

        public Person Person { get; set; }

        public Language() { }
        public Language(string languageTitle)
        {
            LanguageTitle = languageTitle;
        }

        public Language(string languageTitle, Person person) : this(languageTitle)
        {
            Person = person;
        }

        public Language(int id, string languageTitle, Person person) :this(languageTitle, person)
        {
            Id = id;
        }
    }
}

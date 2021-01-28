using System;
using System.Collections.Generic;

namespace ASP_Net_Mvc_Data.Models
{
    public class PersonLanguage
    {
        public int Id { get; set; }
        public int PersonID { get; set; }
        public int LanguageID { get; set; }

        public Person Person { get; set; }
        public Language Language { get; set; }

        public PersonLanguage()
        {

        }

        public PersonLanguage(Person person, Language language)
        {
            Person = person;
            Language = language;
        }
    }
}

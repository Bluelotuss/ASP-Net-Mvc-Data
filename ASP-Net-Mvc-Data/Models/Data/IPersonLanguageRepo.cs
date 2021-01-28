using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public interface IPersonLanguageRepo
    {
        PersonLanguage Create(Person person, Language language);
        List<PersonLanguage> Read();
        List<PersonLanguage> Read(int id);
        PersonLanguage Update(PersonLanguage personLanguage);
        bool Delete(PersonLanguage personLanguage);
    }
}

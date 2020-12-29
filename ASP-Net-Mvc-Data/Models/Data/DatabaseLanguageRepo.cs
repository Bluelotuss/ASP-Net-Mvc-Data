using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public class DatabaseLanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _languageDbContext;

        public DatabaseLanguageRepo(PeopleDbContext languageDbContext)
        {
            _languageDbContext = languageDbContext;
        }

        public Language Create(Language language)
        {
            _languageDbContext.LanguageList.Add(language);

            _languageDbContext.SaveChanges();

            return language;
        }

        public List<Language> Read()
        {
            return _languageDbContext.LanguageList.ToList();
        }

        public Language Read(int id)
        {
            var language = _languageDbContext.LanguageList.Find(id);

            if (language != null)
            {
                return language;
            }

            return null;
        }

        public Language Update(Language language)
        {
            var languageToUpdate = _languageDbContext.LanguageList.Where(x => x.Id == language.Id).FirstOrDefault();

            if (languageToUpdate == null)
            {
                return null;
            }

            languageToUpdate.LanguageTitle = language.LanguageTitle;

            _languageDbContext.Update(languageToUpdate);
            _languageDbContext.SaveChanges();

            return languageToUpdate;
        }

        public bool Delete(Language language)
        {
            _languageDbContext.LanguageList.Remove(language);

            var changes = _languageDbContext.SaveChanges();

            return changes > 0;
        }
    }
}

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
        private readonly IdentityPeopleDbContext _languageDbContext;

        public DatabaseLanguageRepo(IdentityPeopleDbContext languageDbContext)
        {
            _languageDbContext = languageDbContext;
        }

        public Language Create(Language language)
        {
            _languageDbContext.Language.Add(language);

            _languageDbContext.SaveChanges();

            return language;
        }

        public List<Language> Read()
        {
            return _languageDbContext.Language.ToList();
        }

        public Language Read(int id)
        {
            var language = _languageDbContext.Language.Find(id);

            if (language != null)
            {
                return language;
            }

            return null;
        }

        public Language Update(Language language)
        {
            var languageToUpdate = _languageDbContext.Language.Where(x => x.Id == language.Id).FirstOrDefault();

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
            _languageDbContext.Language.Remove(language);

            var changes = _languageDbContext.SaveChanges();

            return changes > 0;
        }
    }
}

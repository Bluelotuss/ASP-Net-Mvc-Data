using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Database;
using ASP_Net_Mvc_Data.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public class DatabasePersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly IdentityPeopleDbContext _personLanguageDbContext;

        public DatabasePersonLanguageRepo(IdentityPeopleDbContext personLanguageDbContext)
        {
            _personLanguageDbContext = personLanguageDbContext;
        }

        public PersonLanguage Create(Person person, Language language)
        {
            var personID = person.Id;
            var languageID = language.Id;

            var existingItems = _personLanguageDbContext.PersonLanguage
                    .Where(pl => pl.PersonID == personID)
                    .Where(pl => pl.LanguageID == languageID).ToList();

            PersonLanguage newItem = new PersonLanguage
            {
                Person = _personLanguageDbContext.People.Single(p => p.Id == personID),
                Language = _personLanguageDbContext.Language.Single(l => l.Id == languageID)
            };

            if (existingItems.Count == 0)
            {

                _personLanguageDbContext.PersonLanguage.Add(newItem);
                _personLanguageDbContext.SaveChanges();
            }
            return newItem;
        }

        public List<PersonLanguage> Read()
        {
            var result = _personLanguageDbContext.PersonLanguage
                .Include(n => n.Person)
                .Include(i => i.Language).ToList();
            return result;
        }

        public List<PersonLanguage> Read(int id)
        {
            var personLanguage = _personLanguageDbContext.PersonLanguage.Find(id);

            var personList = Read();

            if (personLanguage != null)
            {
                List<PersonLanguage> result = personList.Where(j => j.PersonID == id).ToList();

                return result;
            }

            return null;
        }

        public PersonLanguage Update(PersonLanguage personLanguage)
        {
            PersonLanguage person = new PersonLanguage();
            return person;
        }

        public bool Delete(PersonLanguage personLanguage)
        {
            return true;
        }
    }
}

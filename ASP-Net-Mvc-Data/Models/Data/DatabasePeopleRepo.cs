using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly IdentityPeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo(IdentityPeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Create(string name, string phoneNumber, City city)
        {
            Person person = new Person(name, phoneNumber, city);

            _peopleDbContext.People.Add(person);

            _peopleDbContext.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            _peopleDbContext.People.Remove(person);

            var changes = _peopleDbContext.SaveChanges();

            return changes > 0;
        }

        public List<Person> Read()
        {
            //return _peopleDbContext.PersonList.ToList();//Lazy loading (only Persons no city)
            return _peopleDbContext.People.Include(c => c.City)
                .Include(k => k.City.Country).ToList();//Eager loading (cities and persons)
        }

        public Person Read(int id)
        {
            var person = _peopleDbContext.People.Find(id);

            if (person != null)
            {
                return person;
            }

            return null;
        }

        public Person Update(Person person)
        {
            var personToUpdate = _peopleDbContext.People.Where(x => x.Id == person.Id).FirstOrDefault();
            
            if (personToUpdate == null)
            {
                return null;
            }

            personToUpdate.Name = person.Name;
            personToUpdate.PhoneNumber = person.PhoneNumber;
            personToUpdate.City = person.City;

            _peopleDbContext.Update(personToUpdate);
            _peopleDbContext.SaveChanges();

            return personToUpdate;
        }
    }
}

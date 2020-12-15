using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Database;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Person Create(string name, string phoneNumber, string city)
        {
            Person person = new Person(name, phoneNumber, city);

            _peopleDbContext.PersonList.Add(person);

            _peopleDbContext.SaveChanges();

            return person;
        }

        public bool Delete(Person person)
        {
            _peopleDbContext.PersonList.Remove(person);

            var changes = _peopleDbContext.SaveChanges();

            return changes > 0;
        }

        public List<Person> Read()
        {
            return _peopleDbContext.PersonList.ToList();
        }

        public Person Read(int id)
        {
            var person = _peopleDbContext.PersonList.Find(id);

            if (person != null)
            {
                return person;
            }

            return null;
        }

        public Person Update(Person person)
        {
            var personToUpdate = _peopleDbContext.PersonList.Where(x => x.Id == person.Id).FirstOrDefault();
            
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

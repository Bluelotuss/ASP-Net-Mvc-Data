using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Data;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo = new InMemoryPeopleRepo();

        public Person Add(CreatePersonViewModel person)
        {
            return _peopleRepo.Create(person.Name, person.PhoneNumber, person.City);
        }

        public PeopleViewModel All()
        {
            PeopleViewModel pvm = new PeopleViewModel();
            pvm.PersonList = _peopleRepo.Read();
            return pvm;
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            PeopleViewModel pvm = new PeopleViewModel();

            if(search.Search == null)
            {
                return pvm;
            } else
            { 
            foreach (Person person in _peopleRepo.Read())
            {
            if (person.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase) || person.City.Contains(search.Search, StringComparison.OrdinalIgnoreCase))
            {
                        pvm.PersonList.Add(person);
            }
            }
            }
            return pvm;
        }

        public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }

        public Person Edit(int id, Person person)
        {
            Person editPerson = new Person() { Id = id, Name = person.Name, PhoneNumber = person.PhoneNumber, City = person.City };
            return _peopleRepo.Update(editPerson);
        }

        public bool Remove(int id)
        {
            Person person = _peopleRepo.Read(id);
            if (person == null)
            {
                return false;
            }
            else
            {
                return _peopleRepo.Delete(person);
            }
        }
    }
}

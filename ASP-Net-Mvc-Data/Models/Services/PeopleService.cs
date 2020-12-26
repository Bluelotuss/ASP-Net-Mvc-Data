using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Data;
using ASP_Net_Mvc_Data.Models.ViewModels;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        //IPeopleRepo _peopleRepo = new InMemoryPeopleRepo();

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

            pvm.Search = search.Search;

            foreach (Person person in _peopleRepo.Read())
            {
                if (search.Search == null)
                {
                    return pvm;
                }
                else if (person.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase))
                {
                    pvm.PersonList.Add(person);
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

        public PeopleViewModel PageList(int currentPage, int recordsPerPage, int numOfPageItems)
        {
            var allPeople = All();
          
            PeopleViewModel newList = new PeopleViewModel();

            var numOfListItems = allPeople.PersonList.Count;

            if (currentPage == 1 && numOfPageItems < 4)
            {
                var result = allPeople.PersonList.GetRange(0, numOfPageItems);

                foreach (Person person in result)
                {
                    newList.PersonList.Add(person);
                }
                return newList;
            } else if (currentPage == 1)
            {
                var result = allPeople.PersonList.GetRange(0, recordsPerPage);

                foreach (Person person in result)
                {
                    newList.PersonList.Add(person);
                }
                return newList;
            } else if (currentPage > 1)
            {
                var rangeIndex = (currentPage * recordsPerPage) - 3;

                var endCount = numOfListItems - recordsPerPage;

                if (endCount > recordsPerPage)
                {
                    endCount = recordsPerPage;

                    var result = allPeople.PersonList.GetRange(rangeIndex, endCount);

                    foreach (Person person in result)
                    {
                        newList.PersonList.Add(person);
                    }
                    return newList;
                } else
                { 

                var result = allPeople.PersonList.GetRange(rangeIndex, endCount);

                foreach (Person person in result)
                {
                    newList.PersonList.Add(person);
                }
                return newList;
                }
            }

            return newList;
        }
    }
}

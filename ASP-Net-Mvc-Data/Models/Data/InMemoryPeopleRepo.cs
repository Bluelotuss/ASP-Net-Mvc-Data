using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> personList = new List<Person>();

        private static int idCounter = 0;

        public Person Create(string name, string phoneNumber, City city)
        {
            Person person = new Person(++idCounter, name, phoneNumber, city);
            personList.Add(person);
            return person;
        }

        public List<Person> Read()
        {
            return personList;
        }

        public Person Read(int id)
        {
            foreach (Person person in personList)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }

        public Person Update(Person person)
        {
            Person originalPerson = Read(person.Id);
            if (originalPerson == null)
            {
                return null;
            }

            originalPerson.Name = person.Name;
            originalPerson.PhoneNumber = person.PhoneNumber;
            originalPerson.City = person.City;

            return originalPerson;
        }

        public bool Delete(Person person)
        {
            Person findPerson = Read(person.Id);
            personList.Remove(person);

            if (findPerson != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}

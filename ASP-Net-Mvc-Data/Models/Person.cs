using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_Net_Mvc_Data.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public City City { get; set; }
        public List<PersonLanguage> PersonLanguageList { get; set; }

        public Person() { }                     //Varför har jag en tom ctor?

        public Person(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public Person(string name, string phoneNumber, City city) : this(name, phoneNumber)
        {
            City = city;
        }

        public Person(int id, string name, string phoneNumber, City city) : this(name, phoneNumber, city)
        {
            Id = id;
        }
    }
}

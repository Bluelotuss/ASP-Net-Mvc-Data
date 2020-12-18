using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Net_Mvc_Data.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }

        public Person() { }

        public Person(string name, string phoneNumber, City city)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }

        public Person(int id, string name, string phoneNumber, City city) : this(name, phoneNumber, city)
        {
            Id = id;
        }
    }
}

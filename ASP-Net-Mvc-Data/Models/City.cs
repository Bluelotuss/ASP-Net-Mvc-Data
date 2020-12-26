using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_Net_Mvc_Data.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string CityName { get; set; }

        public List<Person> PeopleList { get; set; }

        public Country Country { get; set; }

        public City() { }

        public City(string cityName)       //Necessary?
        {
            CityName = cityName;
        }

        public City(string cityName, Country country) : this(cityName)
        {
            Country = country;
        }
    }
}

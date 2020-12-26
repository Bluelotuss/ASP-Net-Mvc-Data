using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_Net_Mvc_Data.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string CountryName { get; set; }

        public List<City> CityList { get; set; }
    }
}

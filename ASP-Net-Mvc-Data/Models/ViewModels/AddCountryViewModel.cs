using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class AddCountryViewModel
    {
        public List<City> CityList { get; set; }

        public City City { get; set; }

        public List<Country> CountryList { get; set; }

        public Country Country { get; set; }
    }
}

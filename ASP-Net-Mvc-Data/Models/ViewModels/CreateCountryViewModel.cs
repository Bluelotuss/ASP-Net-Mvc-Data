using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        public List<Country> CountryList { get; set; }
        [Required(ErrorMessage = "Country Required")]
        [Display(Name = "Country")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be under 50 characters")]
        public string CountryName { get; set; }

        public City City { get; set; }

        public List<City> CityList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class CreatePeopleViewModel
    {
        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Your Name")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [Display(Name = "Phone number")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be under 50 characters")]
        public string PhoneNumber { get; set; }

        public City City { get; set; }

        public List<City> CityList { get; set; }

        public Country Country { get; set; }

        public List<Country> CountryList { get; set; }

        public List<Person> PersonList { get; set; }
    }
}

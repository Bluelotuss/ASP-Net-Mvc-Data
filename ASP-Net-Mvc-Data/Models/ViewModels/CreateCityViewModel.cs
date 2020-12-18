using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASP_Net_Mvc_Data.Models
{
    public class CreateCityViewModel
    {
        public List<City> CityList { get; set; }
        [Required(ErrorMessage = "City Required")]
        [Display(Name = "City")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be under 50 characters")]
        public string CityName { get; set; }
    }
}

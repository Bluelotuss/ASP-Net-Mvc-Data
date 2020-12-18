using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Net_Mvc_Data.Models
{   
    public class CreatePersonViewModel
    {
        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Your Name")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [Display(Name = "Phone number")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be under 50 characters")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "City")]
        public City City { get; set; }
    }
}

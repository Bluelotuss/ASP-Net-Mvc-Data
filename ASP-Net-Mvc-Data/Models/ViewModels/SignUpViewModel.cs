using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "First name required")]
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be under 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be under 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Birth date required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}
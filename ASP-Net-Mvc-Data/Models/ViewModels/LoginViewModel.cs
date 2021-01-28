using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(18, MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30,
            MinimumLength = 6,
            ErrorMessage = "Password must atleast contain a uppercase letter, lowecase letter, digit and symbol.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

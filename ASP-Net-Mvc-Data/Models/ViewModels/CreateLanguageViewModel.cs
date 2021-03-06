﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required(ErrorMessage = "Language Required")]
        [Display(Name = "Language")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be under 50 characters")]
        public string LanguageTitle { get; set; }

    }
}

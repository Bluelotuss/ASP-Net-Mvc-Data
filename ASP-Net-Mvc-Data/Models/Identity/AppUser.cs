using System;
using Microsoft.AspNetCore.Identity;

namespace ASP_Net_Mvc_Data.Models.Identity
{
    public class AppUser : IdentityUser
    {
        //Need more to the user, add it here.

        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}

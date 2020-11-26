using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models
{
    public class PeopleViewModel
    {
        public string Search { get; set; }
        public CreatePersonViewModel CreatePerson { get; set; }
        public List<Person> PersonList { get; set; }

        public PeopleViewModel()
        {
            PersonList = new List<Person>();
        }
    }
}

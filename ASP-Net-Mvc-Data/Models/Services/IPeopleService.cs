using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public interface IPeopleService
    {
        public Person Add(CreatePersonViewModel person);
        public PeopleViewModel All();
        public PeopleViewModel FindBy(PeopleViewModel search);
        public Person FindBy(int id);
        public Person Edit(int id, Person person);
        public bool Remove(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.ViewModels;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public interface ICountryService
    {
        public Country Add(CreateCountryViewModel createCountryViewModel);
        public List<Country> All();
        public Country FindBy(int id);
        public Country Edit(int id, Country country);
        public bool Remove(int id);
    }
}

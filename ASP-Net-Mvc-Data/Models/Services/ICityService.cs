using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public interface ICityService
    {
        public City Add(CreateCityViewModel createCityViewModel);
        public List<City> All();
        public City FindBy(int id);
        public City Edit(int id, CreateCityViewModel city);
        public bool Remove(int id);
    }
}

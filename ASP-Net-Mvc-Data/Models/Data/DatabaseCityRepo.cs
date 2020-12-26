using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Database;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public class DatabaseCityRepo : ICityRepo
    {
        private readonly PeopleDbContext _cityDbContext;

        public DatabaseCityRepo(PeopleDbContext cityDbContext)
        {
            _cityDbContext = cityDbContext;
        }

        public City Create(string cityName, Country country)
        {
            City city = new City() { CityName = cityName, Country = country};

            _cityDbContext.CityList.Add(city);

            _cityDbContext.SaveChanges();

            return city;
        }

        public bool Delete(City city)
        {
            _cityDbContext.CityList.Remove(city);

            var changes = _cityDbContext.SaveChanges();

            return changes > 0;
        }

        public List<City> Read()
        {
            return _cityDbContext.CityList.ToList();
        }

        public City Read(int id)
        {
            var city = _cityDbContext.CityList.Find(id);

            if (city != null)
            {
                return city;
            }

            return null;
        }

        public City Update(City city)
        {
            var cityToUpdate = _cityDbContext.CityList.Where(x => x.Id == city.Id).FirstOrDefault();

            if (cityToUpdate == null)
            {
                return null;
            }

            cityToUpdate.CityName = city.CityName;
            
            _cityDbContext.Update(cityToUpdate);
            _cityDbContext.SaveChanges();

            return cityToUpdate;
        }
    }
}

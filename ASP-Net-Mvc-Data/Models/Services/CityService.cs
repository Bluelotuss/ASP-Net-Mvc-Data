using System;
using System.Collections.Generic;
using ASP_Net_Mvc_Data.Models.Data;
using ASP_Net_Mvc_Data.Models.ViewModels;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public City Add(CreateCityViewModel createCityViewModel)
        {
            return _cityRepo.Create(createCityViewModel.CityName, createCityViewModel.Country);
        }

        public List<City> All()
        {
            return _cityRepo.Read();
        }

        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public City Edit(int id, City city)
        {
            City editedCity = new City() { Id = id, CityName = city.CityName };
            return _cityRepo.Update(editedCity);
        }

        public bool Remove(int id)
        {
            City city = _cityRepo.Read(id);
            if (city == null)
            {
                return false;
            }
            else
            {
                return _cityRepo.Delete(city);
            }
        }
    }
}

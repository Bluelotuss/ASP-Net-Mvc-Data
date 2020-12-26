using System;
using System.Collections.Generic;
using ASP_Net_Mvc_Data.Models.Data;
using ASP_Net_Mvc_Data.Models.ViewModels;

namespace ASP_Net_Mvc_Data.Models.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Add(CreateCountryViewModel createCountryViewModel)
        {
            return _countryRepo.Create(createCountryViewModel.CountryName);
        }

        public List<Country> All()
        {
            return _countryRepo.Read();
        }

        public Country FindBy(int id)
        {
            return _countryRepo.Read(id);
        }

        public Country Edit(int id, Country country)
        {
            Country editedCountry = new Country() { Id = id, CountryName = country.CountryName };
            return _countryRepo.Update(editedCountry);
        }

        public bool Remove(int id)
        {
            Country country = _countryRepo.Read(id);
            if (country == null)
            {
                return false;
            }
            else
            {
                return _countryRepo.Delete(country);
            }
        }
    }
}

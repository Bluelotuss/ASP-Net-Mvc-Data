using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models.Database;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _countryDbContext;

        public DatabaseCountryRepo(PeopleDbContext countryDbContext)
        {
            _countryDbContext = countryDbContext;
        }

        public Country Create(string countryName)
        {
            Country country = new Country() { CountryName = countryName};

            _countryDbContext.CountryList.Add(country);

            _countryDbContext.SaveChanges();

            return country;
        }

        public bool Delete(Country country)
        {
            _countryDbContext.CountryList.Remove(country);

            var changes = _countryDbContext.SaveChanges();

            return changes > 0;
        }

        public List<Country> Read()
        {
            return _countryDbContext.CountryList.ToList();
        }

        public Country Read(int id)
        {
            var country = _countryDbContext.CountryList.Find(id);

            if (country != null)
            {
                return country;
            }

            return null;
        }

        public Country Update(Country country)
        {
            var countryToUpdate = _countryDbContext.CountryList.Where(x => x.Id == country.Id).FirstOrDefault();

            if (countryToUpdate == null)
            {
                return null;
            }

            countryToUpdate.CountryName = country.CountryName;

            _countryDbContext.Update(countryToUpdate);
            _countryDbContext.SaveChanges();

            return countryToUpdate;
        }
    }
}

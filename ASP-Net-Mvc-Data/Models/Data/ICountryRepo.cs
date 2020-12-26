using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public interface ICountryRepo
    {
        Country Create(string countryName);
        List<Country> Read();
        Country Read(int id);
        Country Update(Country countryName);
        bool Delete(Country countryName);
    }
}

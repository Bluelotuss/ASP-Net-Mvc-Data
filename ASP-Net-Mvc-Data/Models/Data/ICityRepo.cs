using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Mvc_Data.Models.Data
{
    public interface ICityRepo
    {
        City Create(string cityName);
        List<City> Read();
        City Read(int id);
        City Update(City cityName);
        bool Delete(City cityName);
    }
}

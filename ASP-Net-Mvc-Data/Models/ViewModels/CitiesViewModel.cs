using System;
using System.Collections.Generic;

namespace ASP_Net_Mvc_Data.Models.ViewModels
{
    public class CitiesViewModel
    {
        public CreateCityViewModel CreateCity { get; set; }
        public List<City> CityList { get; set; }

        public CitiesViewModel()
        {
            CityList = new List<City>();
        }
    }
}

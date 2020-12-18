using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_Net_Mvc_Data.Models.Database
{
    public class PeopleDbContext : DbContext
    {
        //ctor
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }


        //DbSet
        public DbSet<Person> PersonList { get; set; } //Will be tables in the database
        public DbSet<City> CityList { get; set; }
    }
}

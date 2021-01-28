using ASP_Net_Mvc_Data.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASP_Net_Mvc_Data.Models.Database
{
    public class IdentityPeopleDbContext : IdentityDbContext<AppUser>
    {
        public IdentityPeopleDbContext(DbContextOptions<IdentityPeopleDbContext> options) : base(options) { }


        //DbSet
        public DbSet<Person> People { get; set; } //Will be tables in the database
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<PersonLanguage> PersonLanguage { get; set; }
    }
}

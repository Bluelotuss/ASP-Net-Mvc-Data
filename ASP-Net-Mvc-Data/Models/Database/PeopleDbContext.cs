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
        public DbSet<Person> People { get; set; } //Will be tables in the database
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<PersonLanguage> PersonLanguage { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<PersonLanguage>()
        //        .HasKey(c => new { c.PersonID, c.LanguageID });
        //}
    }
}

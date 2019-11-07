using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace DataBaseLibrary
{
    public class CountryDBContext : DbContext
    {
        /// <summary>
        /// класс подключения к базу данных 
        /// строка подключения находится в json файле appsettings
        /// </summary>

        readonly string connectionString = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build()
                                    .GetConnectionString("DefaultConnection");
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }


        public CountryDBContext():base()  
        {
            Database.EnsureCreated();
            Console.WriteLine("Context_Run");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

       

        public static void AddToDbCity(CountryDBContext _db, City city)
        {
            _db.Cities.Add(city);
            _db.SaveChanges();
        }

        public static void AddToDbRegion(CountryDBContext _db, Region region)
        {
            _db.Regions.Add(region);
            _db.SaveChanges();
        }

        public static void AddToDbCountry(CountryDBContext _db, Country country, Region region, City city)
        {
            country.RegionId = _db.Regions.FirstOrDefault(r => r.Name == region.Name).Id;
            country.CityId = _db.Cities.FirstOrDefault(s => s.Name == city.Name).Id;
            _db.Countries.Add(country);
            _db.SaveChanges();
        }




    }
}

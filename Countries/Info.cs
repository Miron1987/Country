using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace Countries
{
    public static class Info
    {
        public static void ShowInfo(Dictionary<string, object> dictionary)
        {
            ///<summary>
            ///Метод просто выводит построчно информацию из словаря
            /// 
            /// </summary>
            Console.WriteLine($"Country name: {dictionary["name"].ToString()}");
            Console.WriteLine($"Country capital: {dictionary["capital"].ToString()}");
            Console.WriteLine($"Country calling code: {dictionary["callingCodes"].ToString().Substring(3, dictionary["callingCodes"].ToString().Length - 6)}");
            Console.WriteLine($"Country area: {dictionary["area"].ToString()}");
            Console.WriteLine($"Country population: {dictionary["population"].ToString()}");
            Console.WriteLine($"Country region: {dictionary["region"].ToString()}");
        }

        public static void ShowAllCountriesFromDB(CountryDBContext _db)
        {
            ///<summary>
            ///Метод выводит всю информацию из базы 
            ///в алфавитном порядке по странам
            /// </summary>
            var countries = from country in _db.Countries
                            orderby country.Name
                            join city in _db.Cities on country.CityId equals city.Id
                            join region in _db.Regions on country.RegionId equals region.Id
                            select new
                            {
                                Name = country.Name,
                                City = city.Name,
                                Region = region.Name,
                                Area = country.Area,
                                Population = country.Population,
                                CallingCode = country.CallingCode
                            };
            foreach (var singleCountry in countries)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Country name: {singleCountry.Name}");
                Console.WriteLine($"Country capital: {singleCountry.City}");
                Console.WriteLine($"Country calling code: {singleCountry.CallingCode}");
                Console.WriteLine($"Country area: {singleCountry.Area}");
                Console.WriteLine($"Country population: {singleCountry.Population}");
                Console.WriteLine($"Country region: {singleCountry.Region}");
                Console.WriteLine("----------------------------------------");
            }

        }

        public static void Greeting()
        {
            Console.WriteLine("Выберите что-необходимо сделать: ");
            Console.WriteLine("1 - Вывод информации по всем странам из базы.");
            Console.WriteLine("2 - Искать информацию по стране в Интернете.");
            Console.WriteLine("3 - Ввести информацию по стране самому");
            Console.WriteLine("4 - Завершить");
        }
    }
}

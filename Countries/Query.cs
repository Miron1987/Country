using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Countries
{
    static class Query
    {
        static List<Dictionary<string, object>> dictionaries;

        public static void Querying(CountryDBContext _db, string countryName)
        {
            ///<summary>
            ///метод добавляет в базу информацию,
            ///полученную из интернета
            /// </summary>


            if (Networking.Request(countryName, out dictionaries))
            {
                foreach (var dictionary in dictionaries)
                {
                    Info.ShowInfo(dictionary);

                    var city = Build.NewCity(dictionary);

                    var region = Build.NewRegion(dictionary);

                    var country = Build.NewCountry(dictionary);

                    if (_db.Cities.FirstOrDefault(c => c.Name == city.Name) == null)
                    {
                        CountryDBContext.AddToDbCity(_db, city);
                    }

                    if (_db.Regions.FirstOrDefault(c => c.Name == region.Name) == null)
                    {
                        CountryDBContext.AddToDbRegion(_db, region);
                    }

                    if (_db.Countries.FirstOrDefault(c => c.Name == country.Name) == null)
                    {
                        CountryDBContext.AddToDbCountry(_db, country, region, city);
                    }
                }

            }
            else
            {
                Console.WriteLine("Не удалось получить ответ");
            }

        }

        public static void AddingToDB(CountryDBContext _db)
        {
            ///<summary>
            ///метод реализует добавление информации в базу вручную
            /// </summary>

            Console.WriteLine("Введите название страны на английском языке:");
            var countryName = Console.ReadLine();

            Console.WriteLine("Введите название столицы на английском языке:");
            var cityName = Console.ReadLine();

            Console.WriteLine("Введите название региона(Европа, Азия и т.д.) на английском языке:");
            var regionName = Console.ReadLine();

            string callingCode;
            int callingCodeNumber;
            do
            {
                Console.WriteLine("Введите телефонный код страны:");
                callingCode = Console.ReadLine();
            }
            while (!int.TryParse(callingCode, out callingCodeNumber));

            string citizenPopulation;
            int sitizenPopulationNumber;
            do
            {
                Console.WriteLine("Введите количество жителей страны:");
                citizenPopulation = Console.ReadLine();
            }
            while (!int.TryParse(citizenPopulation, out sitizenPopulationNumber));

            string areaSize;
            double areaSizeNumber;
            do
            {
                Console.WriteLine("Введите площадь страны:");
                areaSize = Console.ReadLine();
            }
            while (!double.TryParse(areaSize, out areaSizeNumber));

            var city = Build.NewCity(cityName);

            var region = Build.NewRegion(regionName);

            var country = Build.NewCountry(countryName, 
                                            callingCode, 
                                            areaSizeNumber, 
                                            sitizenPopulationNumber);

            if (_db.Cities.FirstOrDefault(c => c.Name == city.Name) == null)
            {
                CountryDBContext.AddToDbCity(_db, city);
            }

            if (_db.Regions.FirstOrDefault(c => c.Name == region.Name) == null)
            {
                CountryDBContext.AddToDbRegion(_db, region);
            }

            if (_db.Countries.FirstOrDefault(c => c.Name == country.Name) == null)
            {
                CountryDBContext.AddToDbCountry(_db, country, region, city);
            }

        }

    }
}

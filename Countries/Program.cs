using DataBaseLibrary;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Countries
{
    class Program
    {
              
        static void Main(string[] args)
        {

            try
            {
                using (var _db = new CountryDBContext())
                {
                    Info.Greeting();

                    var number = Console.ReadLine();

                    while (number != "4")
                    {
                        switch (number)
                        {
                            case "1":
                                Console.WriteLine("1");
                                Info.ShowAllCountriesFromDB(_db);
                                break;
                            case "2":
                                Console.WriteLine("2");
                                Console.WriteLine("Введите название страны на английском языке:");
                                var country = Console.ReadLine();
                                Query.Querying(_db, country);
                                break;
                            case "3":
                                Query.AddingToDB(_db);
                                break;
                            default:
                                Console.WriteLine("Выберите 1, 2, 3 или 4!");
                                break;
                        }
                        Info.Greeting();
                        number = Console.ReadLine();

                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        


    }
}

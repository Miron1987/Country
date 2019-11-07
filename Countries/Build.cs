using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Countries
{
    class Build
    {
        public static City NewCity(Dictionary<string, object> dictionary)
        {
            ///<summary>
            ///Метод возвращает новый объект типа City 
            /// </summary>
            return new City()
            {
                Name = dictionary["capital"].ToString()
            };
        }

        public static City NewCity(string _name)
        {
            ///<summary>
            ///Метод возвращает новый объект типа City 
            /// </summary>
            return new City()
            {
                Name = _name
            };
        }

        public static Region NewRegion(Dictionary<string, object> dictionary)
        {
            ///<summary>
            ///Метод возвращает новый объект типа Region 
            /// </summary>
            return new Region()
            {
                Name = dictionary["region"].ToString()
            };
        }

        public static Region NewRegion(string _name)
        {
            ///<summary>
            ///Метод возвращает новый объект типа Region 
            /// </summary>
            return new Region()
            {
                Name = _name
            };
        }

        public static Country NewCountry(Dictionary<string, object> dictionary)
        {
            ///<summary>
            ///Метод возвращает новый объект типа Country 
            /// </summary>
            double doubleResult;

            int intResult;

            return new Country()
            {
                Name = dictionary["name"].ToString(),
                CallingCode = dictionary["callingCodes"]
                                            .ToString()
                                            .Substring(3, dictionary["callingCodes"]
                                                                    .ToString()
                                                                    .Length - 6),
                Area = Double.TryParse(dictionary["area"].ToString(), out doubleResult) ? doubleResult : default,
                Population = Int32.TryParse(dictionary["population"].ToString(), out intResult) ? intResult : default
            };
        }

        public static Country NewCountry(string _countryName, 
                                         string _callingCode,
                                         double _area,
                                         int _population)
        {
            ///<summary>
            ///Метод возвращает новый объект типа Country 
            /// </summary>
            return new Country()
            {
                Name = _countryName,
                CallingCode = _callingCode,
                Area = _area,
                Population = _population
            };
        }
    }
}

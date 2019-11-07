using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBaseLibrary
{
    public class Country
    {
        //таблица представляет страны
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } // название стран

        public string CallingCode { get; set; } // код страны

        public double Area { get; set; } // площадь

        public int Population { get; set; } // численность населения

        public int CityId { get; set; }

        public int RegionId { get; set; }

        public City City { get; set; }
        public Region Region { get; set; } //регион
    }
}

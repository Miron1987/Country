using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLibrary
{
    public class City
    {
        //таблица представляет города
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public Country Country { get; set; }
    }
}

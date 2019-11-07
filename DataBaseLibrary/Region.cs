using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLibrary
{
    public class Region
    {
        //таблица представляет регионы
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Country> Countries { get; set; }
    }
}

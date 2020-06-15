using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Region
    {
        public int? RegionId { get; set; }
        public string Name { get; set; }

        public IList<Сountry> Сountries { get; set; }

        public static implicit operator Region(string name)
        {
            return new Region { Name = name };
        }
    }
}

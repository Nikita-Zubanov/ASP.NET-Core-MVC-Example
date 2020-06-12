using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Сountry
    {
        public int? СountryId { get; set; }
        [Display(Name = "Название страны")]
        public string Name { get; set; }
        [Display(Name = "Код страны")]
        public string СountryCode { get; set; }
        [Display(Name = "Площадь страны")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Area { get; set; }
        [Display(Name = "Количество населения")]
        public int Population { get; set; }

        [Display(Name = "Столица")]
        public City Capital { get; set; }
        public int? CityId { get; set; }
        [Display(Name = "Регион столицы")]
        public Region Region { get; set; }
        public int? RegionId { get; set; }
    }
}

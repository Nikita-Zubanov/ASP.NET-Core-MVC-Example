using Newtonsoft.Json;
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
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display(Name = "Код страны")]
        public string СountryCode
        {
            get { return СountryCodes[0]; }
            set { СountryCodes[0] = value; }
        }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Площадь страны")]
        [JsonProperty("area")]
        public decimal Area { get; set; }

        [Display(Name = "Количество населения")]
        [JsonProperty("population")]
        public int Population { get; set; }

        [Display(Name = "Столица")]
        [JsonProperty("capital")]
        public City Capital { get; set; }
        public int? CityId { get; set; }

        [Display(Name = "Регион столицы")]
        [JsonProperty("region")]
        public Region Region { get; set; }
        public int? RegionId { get; set; }

        [NotMapped]
        [JsonProperty("callingCodes")]
        public string[] СountryCodes { get; set; } = new string[1];
    }
}

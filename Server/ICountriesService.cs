using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server
{
    public interface ICountriesService
    {
        void AddCity(City city);
        void AddRegion(Region region);
        void AddСountry(Сountry сountry);

        void UpdateСountry(Сountry beforeCountry, ref Сountry afterСountry);

        IEnumerable<City> GetCities();
        IEnumerable<Region> GetRegions();
        IEnumerable<Сountry> GetСountries();

        City GetCityByName(string name);
        Region GetRegionByName(string name);
        Сountry GetСountryByName(string name);
    }
}

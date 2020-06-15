using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class CountriesService : ICountriesService
    {
        private readonly CountriesDbContext _context;

        public CountriesService(CountriesDbContext context)
        {
            _context = context;
        }

        public void AddCity(City city)
        {
            var findedCity = _context.Cities
                .Where(c => c.Name == city.Name)
                .FirstOrDefault();

            if (findedCity == null)
            {
                _context.Cities.Add(new City { Name = city.Name });
                _context.SaveChanges();
            }
        }
        public void AddRegion(Region region)
        {
            var findedRegion = _context.Regions
                .Where(rgn => rgn.Name == region.Name)
                .FirstOrDefault();

            if (findedRegion == null)
            {
                _context.Regions.Add(new Region { Name = region.Name });
                _context.SaveChanges();
            }
        }
        public void AddСountry(Сountry сountry)
        {
            AddCity(сountry.Capital);
            AddRegion(сountry.Region);

            City city = GetCityByName(сountry.Capital.Name);
            Region region = GetRegionByName(сountry.Region.Name);
            сountry.Capital = city;
            сountry.Region = region;

            Сountry findedСountry = GetСountryByName(сountry.Name);
            if (findedСountry == null)
            {
                _context.Сountries.Add(new Сountry
                {
                    Name = сountry.Name,
                    СountryCode = сountry.СountryCode,
                    Area = сountry.Area,
                    Population = сountry.Population,
                    Capital = сountry.Capital,
                    Region = сountry.Region
                });

                _context.SaveChanges();
            }
            else
                UpdateСountry(сountry, ref findedСountry);
        }

        public void UpdateСountry(Сountry beforeCountry, ref Сountry afterСountry)
        {
            afterСountry.Name = beforeCountry.Name;
            afterСountry.СountryCode = beforeCountry.СountryCode;
            afterСountry.Area = beforeCountry.Area;
            afterСountry.Population = beforeCountry.Population;
            afterСountry.Capital = beforeCountry.Capital;
            afterСountry.Region = beforeCountry.Region;

            _context.SaveChanges();
        }

        public IEnumerable<Сountry> GetСountries()
        {
            return _context.Сountries
                .Include(c => c.Capital)
                .Include(c => c.Region);
        }

        public City GetCityByName(string name)
        {
            return _context.Cities
                .Include(ct => ct.Сountry)
                .Where(ct => ct.Name == name)
                .FirstOrDefault();
        }
        public Region GetRegionByName(string name)
        {
            return _context.Regions
                .Include(rgn => rgn.Сountries)
                .Where(rgn => rgn.Name == name)
                .FirstOrDefault();
        }
        public Сountry GetСountryByName(string name)
        {
            return _context.Сountries
                .Include(c => c.Capital)
                .Include(c => c.Region)
                .Where(c => c.Name.ToLower() == name.ToLower())
                .FirstOrDefault();
        }
    }
}

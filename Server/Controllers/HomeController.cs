using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Server.Models;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountriesService _service;

        public HomeController(ICountriesService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ViewBag.Countries = _service.GetСountries();
            return View();
        }

        public IActionResult AllDetails()
        {
            var countries = _service.GetСountries();

            return View(countries);
        }
        public IActionResult Details(string name)
        {
            var country = _service.GetСountryByName(name);

            if (country == null)
            {
                ViewBag.NameNotFound = name;
                return View("Error");
            }

            return View(country);
        }

        public IActionResult Create()
        {
            Сountry сountry = new Сountry { Capital = new City(), Region = new Region() };
            ViewBag.Cities = _service.GetCities();
            ViewBag.Regions = _service.GetRegions();

            return View(сountry);
        }
        [HttpPost]
        public IActionResult Create(Сountry сountry)
        {
            _service.AddСountry(сountry);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string name, string countryCode, string area, int population, string capitalName, string regionName)
        {
            Сountry сountry = new Сountry
            {
                Name = name,
                СountryCode = countryCode,
                Area = Convert.ToDecimal(area),
                Population = population,
                Capital = new City { Name = capitalName },
                Region = new Region { Name = regionName }
            };
            ViewBag.Cities = _service.GetCities();
            ViewBag.Regions = _service.GetRegions();

            return View("Create", сountry);
        }
    }
}

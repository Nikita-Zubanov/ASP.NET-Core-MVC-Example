using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        static readonly HttpClient client = new HttpClient();

        public HomeController(ICountriesService service)
        {
            _service = service;

            client.BaseAddress ??= new Uri("https://restcountries.eu/");
        }

        public IActionResult Index()
        {
            ViewBag.Countries = _service.GetСountries();
            return View();
        }

        public async Task<IActionResult> Details(string name)
        {
            string path = $"rest/v2/name/{name}";
            var response = await client.GetAsync(path);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return View("Error", new Error(
                    response.StatusCode,
                    $"Страна «{name}» не найдена."));
            }
            else
            {
                var countriesList = await response.Content.ReadAsAsync<IList<Сountry>>();
                Сountry country = countriesList.First();

                return View(country);
            }
        }
        public IActionResult AllDetails()
        {
            var countries = _service.GetСountries();
            return View(countries);
        }

        public IActionResult Save(string name, string countryCode, string area, int population, string capitalName, string regionName)
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
            _service.AddСountry(сountry);

            return RedirectToAction(nameof(Index));
        }
    }
}

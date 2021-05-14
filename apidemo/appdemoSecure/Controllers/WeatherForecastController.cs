using apidemo.core.models;
using apidemo.core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appdemoSecure.Controllers
{
    [Authorize]
    public class WeatherForecastController : Controller
    {
        IWeatherForecastService _service;
        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }
        public IActionResult Index() => View(_service.GetForeCastSeries());
        

        
        public IActionResult Create(WeatherForecast forecast)
        {        

            return View(nameof(Create));
        }

        [HttpPost(Name ="Create")]
        public IActionResult CreateNew(WeatherForecast forecast)
        {
            _service.Add(forecast);
            return RedirectToAction(nameof(Index));
        }
    }
}

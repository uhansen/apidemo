using apidemo.core.models;
using apidemo.core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apidemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        IWeatherForecastService _service;
                
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForecastService service,ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.GetForeCastSeries());
        

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id) => Ok(_service.GetForecast(Id));
        

        [HttpPost]
        public void AddForeCast(WeatherForecast forecast) => _service.Add(forecast);
    }
}

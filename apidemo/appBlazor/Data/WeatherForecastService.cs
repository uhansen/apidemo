using apidemo.core.models;
using apidemo.core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace appBlazor.Data
{
    public class WeatherForecastService
    {
        IWeatherForecastService _service;
        public WeatherForecastService(IWeatherForecastService service)
        {
            _service = service;
        }
        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var result= await _service.GetForeCastSeries();
            return result.ToArray();
        }
    }
}

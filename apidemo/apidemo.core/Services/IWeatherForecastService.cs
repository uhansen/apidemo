using apidemo.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidemo.core.Services
{
    public interface IWeatherForecastService
    {
        void Add(WeatherForecast foreCast);
        IEnumerable<WeatherForecast> GetForeCastSeries();
        WeatherForecast GetForecast(Guid Id);
    }
}

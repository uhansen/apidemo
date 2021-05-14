using apidemo.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidemo.core.Repositories
{
    public interface IWeatherForecastRepository
    {
        void Save(WeatherForecast forecast);
        void Update(WeatherForecast forecast);
        void Delete(WeatherForecast forecast);
        WeatherForecast Read(Guid id);
        IEnumerable<WeatherForecast> GetAll();
    }
}

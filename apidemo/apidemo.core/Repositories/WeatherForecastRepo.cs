using apidemo.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidemo.core.Repositories
{
    public class WeatherForecastRepo : IWeatherForecastRepository
    {
        private static Dictionary<Guid, WeatherForecast> dataSource;
        public WeatherForecastRepo()
        {
            if (dataSource == null)
                dataSource = new Dictionary<Guid, WeatherForecast>();
        }
        public void Delete(WeatherForecast forecast)
        {
            if (dataSource.TryGetValue(forecast.Id,out var f))
            {
                dataSource.Remove(f.Id);
            }           
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return dataSource.Values.ToList();
        }

        public WeatherForecast Read(Guid id)
        {
            if (dataSource.TryGetValue(id, out var f))
            {
                return f;
            }
            return null;
        }

        public void Save(WeatherForecast forecast)
        {
            dataSource.Add(forecast.Id, forecast);
        }

        public void Update(WeatherForecast forecast)
        {
            if (dataSource.TryGetValue(forecast.Id, out var f))
            {
                f.Summary = forecast.Summary;
                f.TemperatureC = forecast.TemperatureC;
                
                f.Date = forecast.Date;
            }
            else
            {
                dataSource.Add(forecast.Id, forecast);
            }
        }
    }
}

using apidemo.core.Gateways;
using apidemo.core.models;
using apidemo.core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apidemo.core.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        IWeatherForecastRepository _repository;
        IAirpressure _airpressure;
        public WeatherForecastService(IWeatherForecastRepository repository, IAirpressure airpressure)
        {
            _repository = repository;
            _airpressure = airpressure;
        }
        public void Add(WeatherForecast foreCast)
        {
            foreCast.AirPressure=_airpressure.GetAirPressureBasesOnPosition(foreCast.PosX, foreCast.PosY);
            if (foreCast.AirPressure > 1004.0)
                foreCast.Summary = $"Højtryk -{foreCast.AirPressure}";
            else
            {
                foreCast.Summary = $"Lavtryk -{foreCast.AirPressure}";
            }
            _repository.Save(foreCast);
        }

        public WeatherForecast GetForecast(Guid Id)
        {
            return _repository.Read(Id);
        }

        public IEnumerable<WeatherForecast> GetForeCastSeries()
        {
            return _repository.GetAll();
        }
    }
}

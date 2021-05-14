using apidemo.core.Gateways;
using apidemo.core.models;
using apidemo.core.Repositories;
using apidemo.core.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace apidemo.core.test
{
    public class MockAirpressuerServiceHigh : IAirpressure
    {
        public double GetAirPressureBasesOnPosition(double x, double y)
        {
            return 1005.0;
        }
    }

    public class MockAirpressuerServiceLow : IAirpressure
    {
        public double GetAirPressureBasesOnPosition(double x, double y)
        {
            return 1001.0;
        }
    }

    public class MockWeatherForecastRepo : IWeatherForecastRepository
    {
        private static Dictionary<Guid, WeatherForecast> dataSource;
        public MockWeatherForecastRepo()
        {
            if (dataSource == null)
                dataSource = new Dictionary<Guid, WeatherForecast>();
        }
        public void Delete(WeatherForecast forecast)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }

    public class WeatherforecastServiceTest
    {
        [Fact]
        public void TestAirPressureHigh()
        {

            var wfs = new WeatherForecastService(new MockWeatherForecastRepo(), new MockAirpressuerServiceHigh());
            var wf = new WeatherForecast()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                PosX = 1.0,
                PosY = 1.0,
                TemperatureC = 30,
            };

            wfs.Add(wf);
            var nwf=wfs.GetForecast(wf.Id);
            Assert.True(nwf.Id == wf.Id);
            Assert.Contains("Højtryk", nwf.Summary);


        }

        [Fact]
        public void TestAirPressureLow()
        {

            var wfs = new WeatherForecastService(new MockWeatherForecastRepo(), new MockAirpressuerServiceLow());
            var wf = new WeatherForecast()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                PosX = 1.0,
                PosY = 1.0,
                TemperatureC = 30,
            };

            wfs.Add(wf);
            var nwf = wfs.GetForecast(wf.Id);
            Assert.True(nwf.Id == wf.Id);
            Assert.Contains("Lavtryk", nwf.Summary);


        }
    }
}

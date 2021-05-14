using System;

namespace apidemo.core.models
{
    public class WeatherForecast
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double AirPressure { get; set; }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}

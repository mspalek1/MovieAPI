using System.Collections.Generic;
using Contracts;

namespace Services.Interfaces
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
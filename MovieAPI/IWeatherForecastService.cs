using System;
using System.Collections.Generic;


namespace MovieAPI
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
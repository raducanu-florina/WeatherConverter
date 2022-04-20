using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherConverter.Models;

namespace WeatherConverter.Services
{
    public class TemperatureConvertion
    {
        Temperature temperature = new Temperature();
        public Temperature ConvertCelsiusToFahrenheit(double celsius)
        {
            var fahrenheit = (9.0 / 5.0) * celsius + 32;
            temperature = new Temperature() 
            { 
                Celsius = celsius,
                Fahrenheit = fahrenheit 
            };
            return temperature;

        }

        public Temperature ConvertFahrenheitToCelsius (double fahrenheit)
        {
            var celsius = (fahrenheit - 32) * (5.0 / 9.0);
            temperature = new Temperature()
            {
                Celsius = celsius,
                Fahrenheit = fahrenheit
            };
            return temperature;

        }


    }
}

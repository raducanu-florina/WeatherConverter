using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherConverter.Models;

namespace WeatherConverter.Services
{
    public class ConvertionTable
    {
        static TemperatureConvertion temperatureConvertion = new TemperatureConvertion();
        public void DisplayConvertionTable()
        {
            DisplayTableHeader();
            List<Temperature> convertionToFahrenheit = GetTeperatureConvertedToFahrenheit();
            List<Temperature> convertionToCelsius = GetTemperatureConvertedToCelsius();
            DisplayConvertions(convertionToFahrenheit, convertionToCelsius);
        }

        private static void DisplayConvertions(List<Temperature> convertionToFahrenheit, List<Temperature> convertionToCelsius)
        {
            for (int y = 0; y < 10; y++)
            {
                Console.WriteLine("{0,5} {1,7} {2,10} {3,12} {4,10} {5,7}\n",
                            convertionToFahrenheit[y].Celsius, "->", convertionToFahrenheit[y].Fahrenheit,
                            convertionToCelsius[y].Fahrenheit, "->", Math.Round(convertionToCelsius[y].Celsius, 2));
            }
        }

        private static List<Temperature> GetTemperatureConvertedToCelsius()
        {
            List<Temperature> temperatureListF = new List<Temperature>();
            var fahrenheit = 0;
            for (int i = 0; i < 10; i++)
            {
                var temperatureInCelsius = temperatureConvertion.ConvertFahrenheitToCelsius(fahrenheit);
                temperatureListF.Add(new Temperature() { Fahrenheit = fahrenheit, Celsius = temperatureInCelsius.Celsius });
                fahrenheit = fahrenheit + 10;
            }

            return temperatureListF;
        }

        private static List<Temperature> GetTeperatureConvertedToFahrenheit()
        {
            List<Temperature> temperatureList = new List<Temperature>();
            var celsius = 0;
            for (int i = 0; i < 10; i++)
            {

                var temperatureInFahrenheit = temperatureConvertion.ConvertCelsiusToFahrenheit(celsius);
                temperatureList.Add(new Temperature() { Fahrenheit = temperatureInFahrenheit.Fahrenheit, Celsius = celsius });
                celsius = celsius + 10;

            }

            return temperatureList;
        }

        private static void DisplayTableHeader()
        {
            Console.Clear();
            Console.WriteLine("\n{0,10} -> {1,10} {2,20} -> {3,7}", "Celsius", "Fahrenheit", "Fahrenheit", "Celsius");
            Console.WriteLine("{0,10}", new string('-', 80));
        }
    }
}

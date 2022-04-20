using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherConverter.Models;
using WeatherConverter.Services;

namespace WeatherConverter
{
    internal class Program
    {
        static TemperatureConvertion temperatureConvertion = new TemperatureConvertion();
        static ConvertionTable convertionTable = new ConvertionTable();
        static Temperature temperature = new Temperature();
        static void Main(string[] args)
        {
            convertionTable.DisplayConvertionTable();
            ConvertTemperature();          
        }        

        private static void ConvertTemperature()
        {            
            bool exit = false;

            do
            {
                AskUserToInputScale();
                string scale = GetUserInput();
                scale = UserInputCleanUp(scale);
                double degrees;

                if (scale.Equals("C"))
                {
                    AskUserToInputTemperatureToBeConverted("°F");
                    var isInputCorrect = double.TryParse(GetUserInput().Trim(), out degrees);
                    if (isInputCorrect)
                    {
                        var temperatureInCelsius = GetTemperatureInCelsius(degrees);
                        Console.WriteLine("{0}°F -> {1}°C", temperatureInCelsius.Fahrenheit, Math.Round(temperatureInCelsius.Celsius,2));
                        exit = CheckIfUserWantsToTryAgain();
                    }
                    else
                    {           
                        Console.WriteLine("***Invalid input***");
                        exit = CheckIfUserWantsToTryAgain();
                    }                    

                }
                else if (scale.Equals("F"))
                {
                    AskUserToInputTemperatureToBeConverted("°C");
                    var isInputCorrect = double.TryParse(GetUserInput().Trim(), out degrees);
                    if (isInputCorrect)       
                    {
                        var temperatureInFahrenheit = GetTemperatureInFahrenheit(degrees);

                        Console.WriteLine("{0}°C -> {1}°F", temperatureInFahrenheit.Celsius, Math.Round(temperatureInFahrenheit.Fahrenheit,2));
                        exit = CheckIfUserWantsToTryAgain();                        
                    }
                    else
                    {
                        Console.WriteLine("***Invalid input***");
                        exit = CheckIfUserWantsToTryAgain();

                    }
                    
                }
                else if (scale.Equals("X"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("***Invalid input***");
                    exit = CheckIfUserWantsToTryAgain();
                }
            }
            while (!exit);           


        }


        private static Temperature GetTemperatureInFahrenheit(double degrees)
        {        
            temperature = temperatureConvertion.ConvertCelsiusToFahrenheit(degrees);         

            return temperature;
        }        

        private static Temperature GetTemperatureInCelsius(double degrees)
        {
           temperature = temperatureConvertion.ConvertFahrenheitToCelsius(degrees);           
           return temperature;
        }

        private static bool CheckIfUserWantsToTryAgain()
        {
            bool exit = false;
            AskUserToTryAgaing();
            var continuesOrNot = GetUserInput();
            continuesOrNot = UserInputCleanUp(continuesOrNot);
            
            if (continuesOrNot.Equals("Y"))
            {
                exit = false;
            }
            else if (continuesOrNot.Equals("N"))
            {
                exit = true;
            }
            else
            {
                Console.WriteLine("***Invalid input***");
                exit = true;
            }                    

            return exit;
        }

        private static void AskUserToInputScale()
        {
            Console.WriteLine("Please choose what temperature scale you you want to convert to: Fahrenheit(F)/Celsius(C) or Exit(X): ");
        }

        private static void AskUserToInputTemperatureToBeConverted(string scaleToConvertFrom)
        {
            Console.WriteLine("Please enter the temperature in {0}: ", scaleToConvertFrom);
        }

        private static void AskUserToTryAgaing()
        {
            Console.WriteLine("Would you like to try again: Y/N: ");
        }

        private static string GetUserInput()
        {            
            string input = Console.ReadLine();
            return input;
        }

        private static string UserInputCleanUp(string input)
        {
            input = input.Trim();
            input = input.ToUpper();
            return input;
        }

    }
}

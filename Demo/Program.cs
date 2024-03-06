using System.Text.Json;

namespace ApiTestingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            WeatherForecast weatherForecast = new WeatherForecast() 
            {
            Date = DateTime.Now,
            TemperatureC = 32,
            Summary = "New test summary"
            };

            string weatherForecastJson = JsonSerializer.Serialize(weatherForecast);

            Console.WriteLine(weatherForecastJson);


        }
    }
}

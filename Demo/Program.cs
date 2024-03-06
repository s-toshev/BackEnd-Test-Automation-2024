using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Text.Json;

namespace ApiTestingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //serialization

            //WeatherForecast weatherForecast = new WeatherForecast() 
            //{
            //Date = DateTime.Now,
            //TemperatureC = 32,
            //Summary = "New test summary"
            //};

            //string weatherForecastJson = JsonSerializer.Serialize(weatherForecast);

            //Console.WriteLine(weatherForecastJson);


            // deserialization:

            //string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory)+"/../../../weatherForecast.json");

            //var weatherForecastObject = JsonSerializer.Deserialize<List<WeatherForecast>>(jsonString);



            //serialization with json.net:

            //WeatherForecast weatherForecast = new WeatherForecast()
            //{
            //    Date = DateTime.Now,
            //    TemperatureC = 32,
            //    Summary = "New test summary"
            //};

            //string weatherForecastJson = JsonConvert.SerializeObject(weatherForecast, Formatting.Indented);

            //Console.WriteLine(weatherForecastJson);

            //with people:

            //string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../People.json");

            //var person = new
            //{
            //    FirstName = string.Empty,
            //    LastName = string.Empty,
            //    JobTitle = string.Empty
            //};

            //var personObj = JsonConvert.DeserializeAnonymousType(jsonString,person);

            //Console.WriteLine(personObj);


            ///another exercise: 
            ///

            //string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../weatherForecast.json");

            //var weatherObj = JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonString);


            //exercise with json.net parsing of objects 

            WeatherForecast weatherForecast = new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = 32,
                Summary = "New test summary"
            };


            DefaultContractResolver contractResolver =
 new DefaultContractResolver()
 {
     NamingStrategy = new SnakeCaseNamingStrategy()
 };
            var serialized = JsonConvert.SerializeObject(weatherForecast,
             new JsonSerializerSettings()
             {
                 ContractResolver = contractResolver,
                 Formatting = Formatting.Indented
             });

            Console.WriteLine(serialized);



            string jsonString = File.ReadAllText(Path.Combine(Environment.CurrentDirectory) + "/../../../People.json");

            var person = JObject.Parse(jsonString);

            Console.WriteLine(person["firstName"]);
            Console.WriteLine(person["lastName"]);


            //linq:

            var json = JObject.Parse(@"{'products': [
            {'name': 'Fruits', 'products': ['apple', 'banana']},
            {'name': 'Vegetables', 'products': ['cucumber']}]}");


            var products = json["products"].Select(t =>
             string.Format("{0} ({1})",
             t["name"],
             string.Join(", ", t["products"])
            ));

            foreach (var product in products)
            {
                Console.WriteLine(product);
            };




        }
    }
}

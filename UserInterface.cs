using Weather_Monitoring_System.DataParsers;

namespace Weather_Monitoring_System
{
    public class UserInterface
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcom To Weather Monitoring System");
            Console.WriteLine("Enter the weather data usign JSON or XML format\n");

            var weatherDataInput = Console.ReadLine();

            if (weatherDataInput.StartsWith('{'))
            {
                var weatherService = new WeatherService(new JsonWeatherDataParser());

                try
                {
                    var weatherDataFromJson = weatherService.ParseToWeatherData(weatherDataInput);
                    weatherService.AvtivatBots(weatherDataFromJson);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else if (weatherDataInput.StartsWith('<'))
            {
                var weatherService = new WeatherService(new XmlWeatherDataParser());

                try
                {
                    var weatherDataFromXML = weatherService.ParseToWeatherData(weatherDataInput);
                    weatherService.AvtivatBots(weatherDataFromXML);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

        }
    }
}

using Weather_Monitoring_System.DataParsers;
using Weather_Monitoring_System.Services.BotServices;
using Weather_Monitoring_System.Services.WeatherService;

namespace Weather_Monitoring_System
{
    public class UserInterface
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcom To Weather Monitoring System");
            Console.WriteLine("Enter the weather data usign JSON or XML format\n");

            var weatherDataInput = Console.ReadLine();

            var botList = new List<BotService>
            {
                new RainBotService(),
                new SnowBotService(),
                new SunBotService()
            };

            if (weatherDataInput.StartsWith('{'))
            {
                var weatherService = new WeatherService(new JsonWeatherDataParser(), botList);

                try
                {
                    var weatherDataFromJson = weatherService.ParseToWeatherData(weatherDataInput);
                    weatherService.PrinActiveMessageIfBotActive(weatherDataFromJson);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else if (weatherDataInput.StartsWith('<'))
            {
                var weatherService = new WeatherService(new XmlWeatherDataParser(), botList);

                try
                {
                    var weatherDataFromXML = weatherService.ParseToWeatherData(weatherDataInput);
                    weatherService.PrinActiveMessageIfBotActive(weatherDataFromXML);

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

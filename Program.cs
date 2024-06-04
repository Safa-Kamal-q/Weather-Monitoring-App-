using Weather_Monitoring_System.DataParsers;
using Weather_Monitoring_System.Models;
using Weather_Monitoring_System.Services.BotServices;
using Weather_Monitoring_System.Services.WeatherService;

namespace Weather_Monitoring_System
{
    public class Program
    {
        private static char? _option;
        private static IDataParserFactory _parserFactory;
        private static WeatherData _weatherData;
        private static IWeatherService _weatherService;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcom To Weather Monitoring System");
                Console.WriteLine("1. Start the program.");
                Console.WriteLine("2. Exit the program.");
                Console.Write("\nChoose: ");

                var userChoice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userChoice))
                {
                    Console.Clear();
                    Console.WriteLine("\nInvalid input. Please enter a valid option.\n");
                    continue;
                }

                _option = userChoice.First();

                switch (_option)
                {
                    case '1':
                        Console.WriteLine("Enter the weather data usign JSON or XML format\n");
                        var weatherDataInput = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(weatherDataInput))
                        {
                            Console.Clear();
                            Console.WriteLine("\nNull or empty data are not accepted, please try again\n");
                            continue;
                        }

                        else
                        {
                            _parserFactory = new DataParserFactory(weatherDataInput);
                            _weatherData = _parserFactory.TryParseToWeatherData();

                            if (_weatherData == null)
                            {
                                Console.Clear();
                                Console.WriteLine("\nInvalid format input, please try again\n");
                                continue;
                            }
                        }
                        break;

                    case '2':
                        Console.WriteLine("Exiting the program. Goodbye!");
                        Environment.Exit(1);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nInvalid Input, try again\n");
                        continue;
                }
                break;
            }


            var botsList = new List<IBotService>
            {
                new RainBotService(),
                new SnowBotService(),
                new SunBotService()
            };

            _weatherService = new WeatherService(botsList);

            try
            {
                _weatherService.PrintActiveMessageIfBotActive(_weatherData);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

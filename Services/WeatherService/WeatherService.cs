using Weather_Monitoring_System.DataParsers;
using Weather_Monitoring_System.Models;
using Weather_Monitoring_System.Services.BotServices;

namespace Weather_Monitoring_System.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherDataParser _dataParser;

        private readonly List<BotService> _botServices;

        public WeatherService(IWeatherDataParser dataParser, List<BotService> botSevices)
        {
            _dataParser = dataParser;
            _botServices = botSevices;
        }

        public WeatherData ParseToWeatherData(string data)
        {
            return _dataParser.TryParse(data);
        }

        public void PrinActiveMessageIfBotActive(WeatherData weatherData)
        {
            foreach (var botService in _botServices)
            {
                if (botService.IsActive(weatherData))
                {
                    botService.PrintActiveMessage();
                }
            }
        }
    }
}

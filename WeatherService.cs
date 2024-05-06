using Weather_Monitoring_System.Bots;
using Weather_Monitoring_System.DataParsers;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System
{
    public class WeatherService
    {
        private readonly IWeatherDataParser _dataParser;

        private readonly List<Bot> _botServices = [new RainBotService(), new SnowBotService(), new SunBotService()];

        public WeatherService(IWeatherDataParser dataParser)
        {
            _dataParser = dataParser;
        }

        public WeatherData ParseToWeatherData(string data)
        {
            return _dataParser.TryParse(data);
        }

        public void AvtivatBots(WeatherData weatherData)
        {
            foreach(var botService in _botServices)
            {
                if (botService.IsActive(weatherData))
                {
                    botService.PrintActiveMessage();
                }
            }
        }
    }
}

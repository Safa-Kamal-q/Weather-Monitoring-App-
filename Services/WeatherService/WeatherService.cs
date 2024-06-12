using Weather_Monitoring_System.Models;
using Weather_Monitoring_System.Services.BotServices;

namespace Weather_Monitoring_System.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private List<IBotService> _botServices;

        public WeatherService(List<IBotService> botSevices)
        {
            _botServices = botSevices;
        }

        public void PrintActiveMessageIfBotActive(WeatherData weatherData)
        {
            foreach (var botService in _botServices)
            {
                botService.PrintActiveMessageIfBotActive(weatherData);
            }
        }
    }
}

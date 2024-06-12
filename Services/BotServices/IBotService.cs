using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Services.BotServices
{
    public interface IBotService
    {
        public bool IsActive(WeatherData weatherData);

        public void PrintActiveMessage();

        public void PrintActiveMessageIfBotActive(WeatherData weatherData);
    }
}

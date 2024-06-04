using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Services.BotServices
{
    public interface IBotService
    {
        public abstract bool IsActive(WeatherData weatherData);

        public abstract void PrintActiveMessage();
    }
}

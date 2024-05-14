using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Services.WeatherService
{
    public interface IWeatherService
    {
        public WeatherData ParseToWeatherData(string data);

        public void PrinActiveMessageIfBotActive(WeatherData weatherData);
    }
}

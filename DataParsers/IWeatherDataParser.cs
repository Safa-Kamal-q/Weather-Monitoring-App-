using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public interface IWeatherDataParser
    {
        bool TryParse(string data, out WeatherData? weatherData);
    }
}

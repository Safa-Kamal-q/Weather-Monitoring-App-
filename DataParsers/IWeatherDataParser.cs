using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public interface IWeatherDataParser
    {
        WeatherData Parse(string data);
    }
}

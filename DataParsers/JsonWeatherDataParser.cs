using Newtonsoft.Json;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData? TryParse(string data)
        {
            return JsonConvert.DeserializeObject<WeatherData>(data);
        }
    }
}

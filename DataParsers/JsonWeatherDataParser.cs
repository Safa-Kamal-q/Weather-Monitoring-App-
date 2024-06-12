using Newtonsoft.Json;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public bool TryParse(string data, out WeatherData? weatherData)
        {
            weatherData = null;

            try
            {
                weatherData = JsonConvert.DeserializeObject<WeatherData>(data);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

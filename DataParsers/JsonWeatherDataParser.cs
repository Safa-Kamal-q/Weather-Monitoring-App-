using Newtonsoft.Json;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData? TryParse(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<WeatherData>(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
                return null;
            }

        }
    }
}

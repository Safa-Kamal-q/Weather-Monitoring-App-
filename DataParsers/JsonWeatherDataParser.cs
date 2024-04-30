using Newtonsoft.Json;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public class JsonWeatherDataParser: IWeatherDataParser
    {
        public WeatherData? Parse(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<WeatherData>(data);
            }
            catch (JsonException ex)
            {
                throw new JsonException($"Error parsing JSON data: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while parsing JSON data: {ex.Message}");
            }
        }
    }
}

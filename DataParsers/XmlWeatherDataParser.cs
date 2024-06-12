using System.Xml;
using System.Xml.Serialization;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public bool TryParse(string data, out WeatherData? weatherData)
        {
            weatherData = null;

            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));

                var reader = XmlReader.Create(new StringReader(data));

                weatherData = (WeatherData)serializer.Deserialize(reader);

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

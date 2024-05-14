using System.Xml;
using System.Xml.Serialization;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData? TryParse(string data)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));

                var reader = XmlReader.Create(new StringReader(data));

                return (WeatherData)serializer.Deserialize(reader);

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

using System.Xml;
using System.Xml.Serialization;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    internal class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string data)
        {
            var serializer = new XmlSerializer(typeof(WeatherData));

            XmlReader reader = XmlReader.Create(new StringReader(data));

            return (WeatherData)serializer.Deserialize(reader);
        }
    }
}

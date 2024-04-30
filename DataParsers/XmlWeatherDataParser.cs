using System.Xml;
using System.Xml.Serialization;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    internal class XmlWeatherDataParser: IWeatherDataParser
    {
        public WeatherData Parse(string data)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));

                XmlReader reader = XmlReader.Create(new StringReader(data));

                return (WeatherData)serializer.Deserialize(reader);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Error parsing XML data. Invalid format or structure: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while parsing XML data: {ex.Message}");
            }
        }
    }
}

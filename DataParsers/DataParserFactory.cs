using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.DataParsers
{
    public class DataParserFactory: IDataParserFactory
    {
        private string _weatherDataInput;
        private IWeatherDataParser _dataParser;

        public DataParserFactory(string weatherDataInput)
        {
            _weatherDataInput = weatherDataInput;
        }

        public WeatherData? TryParseToWeatherData()
        {
            WeatherData? weatherData = null;

            if (_weatherDataInput.StartsWith('{'))
            {
                _dataParser = new JsonWeatherDataParser();
                _dataParser.TryParse(_weatherDataInput, out weatherData);
            }
            else if (_weatherDataInput.StartsWith('<'))
            {
                _dataParser = new XmlWeatherDataParser();
                _dataParser.TryParse(_weatherDataInput, out weatherData);
            }
            return weatherData;
        }
    }
}

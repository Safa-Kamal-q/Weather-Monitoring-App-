namespace Weather_Monitoring_System.DataParsers
{
    public class DataParserFactory : IDataParserFactory
    {
        private string _weatherDataInput;

        public DataParserFactory(string weatherDataInput)
        {
            _weatherDataInput = weatherDataInput;
        }

        public bool TryParseInputToJsonOrXml(out IWeatherDataParser? dataParser)
        {
            dataParser = null;

            try
            {
                if (_weatherDataInput.StartsWith('{'))
                {
                    dataParser = new JsonWeatherDataParser();
                }
                else if (_weatherDataInput.StartsWith('<'))
                {
                    dataParser = new XmlWeatherDataParser();
                }
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

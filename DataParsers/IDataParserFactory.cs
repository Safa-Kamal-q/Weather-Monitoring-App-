namespace Weather_Monitoring_System.DataParsers
{
    public interface IDataParserFactory
    {
        public bool TryParseInputToJsonOrXml(out IWeatherDataParser dataParser);
    }
}

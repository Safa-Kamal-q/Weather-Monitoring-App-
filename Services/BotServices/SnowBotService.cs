using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Services.BotServices
{
    public class SnowBotService : BotService, IBotService
    {
        private SnowBotConfig _snowBotConfig;

        public SnowBotService()
        {
            var config = LoadConfig("SnowBot");
            _snowBotConfig = new SnowBotConfig()
            {
                BotName = config.BotName,
                Enabled = config.Enabled,
                Threshold = config.Threshold,
                Message = config.Message
            };
        }

        public bool IsActive(WeatherData weatherData)
        {
            return _snowBotConfig.Enabled && weatherData.Temperature < _snowBotConfig.Threshold;
        }

        public void PrintActiveMessage()
        {
            Console.WriteLine($"\n{_snowBotConfig.BotName} activated!");
            Console.WriteLine($"{_snowBotConfig.BotName}: {_snowBotConfig.Message}\n");
        }
    }
}

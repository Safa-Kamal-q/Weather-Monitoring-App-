using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Bots
{
    public class SnowBotService : Bot
    {
        private SnowBotConfig _snowBotConfig;

        public SnowBotService()
        {
            var config = LoadConfig("RainBot");
            _snowBotConfig.BotName = config.BotName;
            _snowBotConfig.Enabled = config.Enabled;
            _snowBotConfig.Threshold = config.Threshold;
            _snowBotConfig.Message = config.Message;
        }

        public override bool IsActive(WeatherData weatherData)
        {
            return _snowBotConfig.Enabled && weatherData.Temperature < _snowBotConfig.Threshold;
        }

        public override void PrintActiveMessage()
        {
            Console.WriteLine($"{GetType().Name} activated!");
            Console.WriteLine($"{GetType().Name}: {_snowBotConfig.Message}");
        }
    }
}

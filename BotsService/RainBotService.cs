using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Bots
{
    public class RainBotService : Bot
    {
        private RainBotConfig _rainBotConfig;

        public RainBotService()
        {
            var config = LoadConfig("RainBot");
            _rainBotConfig = new RainBotConfig(config.BotName)
            {
                Enabled = config.Enabled,
                Threshold = config.Threshold,
                Message = config.Message
            };
        }

        public override bool IsActive(WeatherData weatherData)
        {
            return _rainBotConfig.Enabled && weatherData.Humidity > _rainBotConfig.Threshold;
        }

        public override void PrintActiveMessage()
        {
            Console.WriteLine($"\n{_rainBotConfig.BotName} activated!");
            Console.WriteLine($"{_rainBotConfig.BotName}: {_rainBotConfig.Message}\n");
        }
    }
}

using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Bots
{
    public class RainBotService : Bot
    {
        private RainBotConfig _rainBotConfig;

        public RainBotService()
        {
            var config = LoadConfig("RainBot");
            _rainBotConfig.BotName = config.BotName;
            _rainBotConfig.Enabled = config.Enabled;
            _rainBotConfig.Threshold = config.Threshold;
            _rainBotConfig.Message = config.Message;
        }

        public override bool IsActive(WeatherData weatherData)
        {
            return _rainBotConfig.Enabled && weatherData.Humidity > _rainBotConfig.Threshold;
        }

        public override void PrintActiveMessage()
        {
            Console.WriteLine($"{GetType().Name} activated!");
            Console.WriteLine($"{GetType().Name}: {_rainBotConfig.Message}");
        }
    }
}

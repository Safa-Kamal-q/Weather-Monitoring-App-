using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Bots
{
    public class SunBotService : Bot
    {
        private SunBotConfig _sunBotConfig;

        public SunBotService()
        {
            var config = LoadConfig("RainBot");
            _sunBotConfig.BotName = config.BotName;
            _sunBotConfig.Enabled = config.Enabled;
            _sunBotConfig.Threshold = config.Threshold;
            _sunBotConfig.Message = config.Message;
        }

        public override bool IsActive(WeatherData weatherData)
        {
            return _sunBotConfig.Enabled && weatherData.Temperature > _sunBotConfig.Threshold;
        }

        public override void PrintActiveMessage()
        {
            Console.WriteLine($"{GetType().Name} activated!");
            Console.WriteLine($"{GetType().Name}: {_sunBotConfig.Message}");
        }
    }
}

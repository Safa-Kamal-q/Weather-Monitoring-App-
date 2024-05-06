using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Bots
{
    public class SunBotService : Bot
    {
        private SunBotConfig _sunBotConfig;

        public SunBotService()
        {
            var config = LoadConfig("SunBot");
            _sunBotConfig = new SunBotConfig(config.BotName)
            {
                Enabled = config.Enabled,
                Threshold = config.Threshold,
                Message = config.Message
            };
        }

        public override bool IsActive(WeatherData weatherData)
        {
            return _sunBotConfig.Enabled && weatherData.Temperature > _sunBotConfig.Threshold;
        }

        public override void PrintActiveMessage()
        {
            Console.WriteLine($"\n{_sunBotConfig.BotName} activated!");
            Console.WriteLine($"{_sunBotConfig.BotName}: {_sunBotConfig.Message}\n");
        }
    }
}

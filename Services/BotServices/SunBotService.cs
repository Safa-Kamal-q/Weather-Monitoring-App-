using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Services.BotServices
{
    public class SunBotService : BotService, IBotService
    {
        private SunBotConfig _sunBotConfig;

        public SunBotService()
        {
            var config = LoadConfig("SunBot");
            _sunBotConfig = new SunBotConfig()
            {
                BotName = config.BotName,
                Enabled = config.Enabled,
                Threshold = config.Threshold,
                Message = config.Message
            };
        }

        public bool IsActive(WeatherData weatherData)
        {
            return _sunBotConfig.Enabled && weatherData.Temperature > _sunBotConfig.Threshold;
        }

        public void PrintActiveMessage()
        {
            Console.WriteLine($"\n{_sunBotConfig.BotName} activated!");
            Console.WriteLine($"{_sunBotConfig.BotName}: {_sunBotConfig.Message}\n");
        }
    }
}

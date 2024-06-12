using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Services.BotServices
{
    public class RainBotService : BotService, IBotService
    {
        private RainBotConfig _rainBotConfig;

        public RainBotService()
        {
            var config = LoadConfig("RainBot");
            _rainBotConfig = new RainBotConfig()
            {
                BotName = config.BotName,
                Enabled = config.Enabled,
                Threshold = config.Threshold,
                Message = config.Message
            };
        }

        public bool IsActive(WeatherData weatherData)
        {
            return _rainBotConfig.Enabled && weatherData.Humidity > _rainBotConfig.Threshold;
        }

        public void PrintActiveMessage()
        {
            Console.WriteLine($"\n{_rainBotConfig.BotName} activated!");
            Console.WriteLine($"{_rainBotConfig.BotName}: {_rainBotConfig.Message}\n");
        }

        public void PrintActiveMessageIfBotActive(WeatherData weatherData)
        {
            if (IsActive(weatherData))
            {
                PrintActiveMessage();
            }
        }
    }
}

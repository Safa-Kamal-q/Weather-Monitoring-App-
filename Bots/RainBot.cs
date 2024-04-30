using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Bots
{
    public class RainBot : Bot
    {
        private readonly BotConfig _config;

        public RainBot()
        {
            _config = LoadConfig("RainBot");

        }

        public override void Active(WeatherData weatherData)
        {
            if (_config.Enabled && weatherData.Humidity > _config.Threshold)
            {
                Console.WriteLine($"{GetType().Name} activated!");
                Console.WriteLine($"{GetType().Name}: {_config.Message}");
            }
        }
    }
}

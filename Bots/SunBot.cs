using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Bots
{
    public class SunBot : Bot
    {
        private readonly BotConfig _config;

        public SunBot()
        {
            _config = LoadConfig("SunBot");

        }

        public override void Active(WeatherData weatherData)
        {
            if (_config.Enabled && weatherData.Temperature > _config.Threshold)
            {
                Console.WriteLine($"{GetType().Name} activated!");
                Console.WriteLine($"{GetType().Name}: {_config.Message}");
            }
        }
    }
}

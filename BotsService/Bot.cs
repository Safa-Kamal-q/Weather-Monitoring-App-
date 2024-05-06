using Newtonsoft.Json.Linq;
using Weather_Monitoring_System.Configs;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Bots
{
    public abstract class Bot
    {
        protected BotConfig? LoadConfig(string botName)
        {
            try
            {
                JObject config = ConfigReader.ReadConfig();

                if (config != null && config.TryGetValue(botName, out var botConfig))
                {
                    return new BotConfig(botName,
                                        (bool)botConfig["enabled"],
                                        (botName == "RainBot") ? (decimal)botConfig["humidityThreshold"] : (decimal)botConfig["temperatureThreshold"],
                                        botConfig["message"].ToString());
                }
                else
                {
                    return new BotConfig(botName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
                return null;
            }

        }

        public abstract bool IsActive(WeatherData weatherData);

        public abstract void PrintActiveMessage();
    }
}

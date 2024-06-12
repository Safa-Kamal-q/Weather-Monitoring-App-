using Newtonsoft.Json.Linq;
using Weather_Monitoring_System.Configs;
using Weather_Monitoring_System.Models;

namespace Weather_Monitoring_System.Services.BotServices
{
    public abstract class BotService
    {
        protected BotConfig? LoadConfig(string botName)
        {
            try
            {
                JObject config = ConfigReader.ReadConfig();

                if (config != null && config.TryGetValue(botName, out var botConfig))
                {
                    return new BotConfig
                    {
                        BotName = botName,
                        Enabled = (bool)botConfig["enabled"],
                        Threshold = botName == "RainBot" ? (decimal)botConfig["humidityThreshold"] : (decimal)botConfig["temperatureThreshold"],
                        Message = botConfig["message"].ToString()
                    };
                }
                return new BotConfig
                {
                    BotName = botName,
                    Enabled = false,
                    Threshold = 0,
                    Message = string.Empty
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
                return null;
            }
        }
    }
}

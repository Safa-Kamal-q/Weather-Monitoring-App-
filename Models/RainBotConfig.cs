namespace Weather_Monitoring_System.Models
{
    public class RainBotConfig : BotConfig
    {
        public RainBotConfig(string botName, bool enabled = false, decimal threshold = 0, string message = "")
            : base(botName, enabled, threshold, message) { }
    }
}

namespace Weather_Monitoring_System.Models
{
    public class SnowBotConfig : BotConfig
    {
        public SnowBotConfig(string botName, bool enabled = false, decimal threshold = 0, string message = "")
            : base(botName, enabled, threshold, message) { }
    }
}

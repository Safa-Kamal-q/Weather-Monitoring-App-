namespace Weather_Monitoring_System.Models
{
    public class SunBotConfig : BotConfig
    {
        public SunBotConfig(string botName, bool enabled = false, decimal threshold = 0, string message = "")
            : base(botName, enabled, threshold, message) { }
    }
}

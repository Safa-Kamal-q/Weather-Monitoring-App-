namespace Weather_Monitoring_System.Models
{
    public class BotConfig
    {
        public string BotName { get; set; }

        public bool Enabled { get; set; }

        public decimal Threshold { get; set; }

        public string Message { get; set; }

        public BotConfig(string botName, bool enabled = false, decimal threshold = 0, string message = "")
        {
            BotName = botName;
            Enabled = enabled;
            Threshold = threshold;
            Message = message;
        }
    }
}

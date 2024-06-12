namespace Weather_Monitoring_System.Models
{
    public class BotConfig
    {
        public string BotName { get; set; }

        public bool Enabled { get; set; } = false;

        public decimal Threshold { get; set; } = 0;

        public string Message { get; set; } = string.Empty;

        public BotConfig() { }
    }
}

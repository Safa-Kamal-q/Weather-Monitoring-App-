using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Weather_Monitoring_System.Configs
{
    internal class ConfigReader
    {
        private const string ConfigFilePath = "config.json";

        public static JObject ReadConfig()
        {
            using StreamReader file = File.OpenText(ConfigFilePath);
            using JsonTextReader reader = new(file);
            return JObject.Load(reader);
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Weather_Monitoring_System.Configs
{
    public class ConfigReader
    {
        private const string ConfigFilePath = "D:\\Weather Monitoring System\\Configs\\config.json";

        public static JObject ReadConfig()
        {
            var file = File.OpenText(ConfigFilePath);
            var reader = new JsonTextReader(file);
            return JObject.Load(reader);
        }
    }
}

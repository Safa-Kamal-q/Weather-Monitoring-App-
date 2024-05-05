using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Weather_Monitoring_System.Configs
{
    internal class ConfigReader
    {
        private const string ConfigFilePath = "config.json";

        public static JObject ReadConfig()
        {
            try
            {
                using StreamReader file = File.OpenText(ConfigFilePath);
                using JsonTextReader reader = new(file);
                return JObject.Load(reader);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"Error: Configuration file '{ConfigFilePath}' not found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading configuration file: {ex.Message}");
            }

        }
    }
}

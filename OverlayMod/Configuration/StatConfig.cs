using IPA.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverlayMod.Stat.Stats;
using System.IO;

namespace OverlayMod.Configuration
{
    internal class StatConfig
    {
        private static readonly string pathToConfigFolder = $"{UnityGame.InstallPath}\\UserData\\OverlayMod\\";

        private IStat stat;

        private string name;

        public StatConfig(IStat stat, string name)
        {
            this.stat = stat;
            this.name = name;
        }

        public static void clearConfig()
        {
            if (!Directory.Exists(pathToConfigFolder)) return;

            Directory.Delete(pathToConfigFolder, true);
        }

        public T? getConfigEntry<T>(string entry) where T : struct
        {
            Directory.CreateDirectory(pathToConfigFolder);
            try
            {
                if (!Directory.Exists(pathToConfigFolder) || !File.Exists($"{pathToConfigFolder}{name}.json")) return null;

                return JObject.Parse(File.ReadAllText($"{pathToConfigFolder}{name}.json"))[entry].Value<T>();
            }
            catch
            {
                return null;
            }
        }

        public void setConfigEntry(string entry, object value)
        {
            JObject config = getConfigIfExistsOrNewConfig($"{pathToConfigFolder}{name}.json");

            config[entry] = JToken.FromObject(value);

            File.WriteAllText($"{pathToConfigFolder}{name}.json", JsonConvert.SerializeObject(config));
        }

        private JObject getConfigIfExistsOrNewConfig(string path)
        {
            if (Directory.Exists(pathToConfigFolder) && File.Exists(path))
                return JObject.Parse(File.ReadAllText(path));
            return new JObject();
        }
    }
}

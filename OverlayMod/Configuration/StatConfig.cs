using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OverlayMod.Stat.Stats;
using IPA.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.CodeDom;

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

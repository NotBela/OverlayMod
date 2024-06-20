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

namespace OverlayMod.Configuration
{
    internal static class StatConfig
    {
        private static readonly string pathToConfigFolder = $"{UnityGame.InstallPath}\\UserData\\OverlayMod\\";

        public static void clearConfig()
        {
            if (!Directory.Exists(pathToConfigFolder)) return;

            Directory.Delete(pathToConfigFolder, true);
        }

        public static T? getConfigEntry<T>(IStat.StatTypes stat, string entry) where T : struct
        {
            if (!Directory.Exists(pathToConfigFolder) || !File.Exists($"{pathToConfigFolder}{stat}.json")) return null;

            try
            {
                return JObject.Parse(File.ReadAllText($"{pathToConfigFolder}{stat}.json"))[entry].Value<T>();
            }
            catch
            {
                Plugin.Log.Warn($"Config {stat} could not be loaded! Is it valid?");
                return null;
            }
        }

        public static void setConfigEntry(IStat.StatTypes stat, string entry, object value)
        {
            Directory.CreateDirectory(pathToConfigFolder);

            JObject config;

            try
            {
                config = JObject.Parse(File.ReadAllText($"{pathToConfigFolder}{stat}.json"));
            }
            catch
            {
                config = new JObject();
            }

            if (config.ContainsKey(entry)) config[entry] = JToken.FromObject(value);
            else config.Add(entry, JToken.FromObject(value));

            File.WriteAllText($"{pathToConfigFolder}{stat}.json", JsonConvert.SerializeObject(config));
        }
    }
}

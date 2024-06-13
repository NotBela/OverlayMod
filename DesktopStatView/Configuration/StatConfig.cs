using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DesktopStatView.Stat.Stats;
using IPA.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DesktopStatView.Configuration
{
    internal class StatConfig
    {
        private static readonly string pathToConfigFolder = $"{UnityGame.InstallPath}\\UserData\\DesktopStatView\\";

        public static T? getConfigEntry<Stat, T>(string entry) where T : struct where Stat : IStat
        {
            if (!Directory.Exists(pathToConfigFolder) || !File.Exists($"{pathToConfigFolder}{typeof(Stat)}.json")) return null;

            try
            {
                return JObject.Parse(File.ReadAllText($"{pathToConfigFolder}{typeof(Stat)}.json"))[entry].Value<T>();
            }
            catch(Exception e)
            {
                Plugin.Log.Warn($"Config {typeof(Stat)} could not be loaded: {e}");
                return null;
            }
        }

        public static void setConfigEntry<Stat>(string entry, object value) where Stat : IStat
        {
            Directory.CreateDirectory(pathToConfigFolder);

            JObject config;

            try
            {
                config = JObject.Parse(File.ReadAllText($"{pathToConfigFolder}{typeof(Stat)}.json"));
            }
            catch
            {
                config = new JObject();
            }

            if (config.ContainsKey(entry)) config[entry] = JToken.FromObject(value);
            else config.Add(entry, JToken.FromObject(value));

            File.WriteAllText($"{pathToConfigFolder}{typeof(Stat)}.json", JsonConvert.SerializeObject(config));
        }
    }
}

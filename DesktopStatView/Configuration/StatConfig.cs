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
        private readonly IStat stat;

        private JObject config;
        private static readonly string pathToConfigFolder = Path.Combine(UnityGame.InstallPath, "\\UserData\\DesktopStatView\\");

        public StatConfig(IStat stat)
        {
            this.stat = stat;

            if (!File.Exists(Path.Combine(pathToConfigFolder, $"{stat.counterName}.json")))
                config = new JObject();

            else config = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(Path.Combine(pathToConfigFolder, $"{stat.counterName}.json")));
        }

        public void setConfigEntry<T>(string entry, T value) where T : struct
        {
            config.SetProperty(entry, value);

            File.WriteAllText(Path.Combine(pathToConfigFolder, stat.counterName), JsonConvert.SerializeObject(config));
        }

        public T? getConfigEntry<T>(string nameOfEntry) where T : struct
        {
            try
            {
                T? returnObj = config.GetValue(nameOfEntry).Value<T>();
                return returnObj;
            }
            catch
            {
                return null;
            }
            
        }
    }
}

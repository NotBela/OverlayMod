using IPA.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OverlayMod.Stat.Stats;
using System.IO;
using UnityEngine;

namespace OverlayMod.Configuration
{
    internal class StatConfig
    {
        private static readonly string pathToConfigFolder = $"{UnityGame.InstallPath}\\UserData\\OverlayMod\\";

        private Stat.Stats.Stat stat;

        private string name;

        public StatConfig(Stat.Stats.Stat stat, string name)
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

                var json = JObject.Parse(File.ReadAllText($"{pathToConfigFolder}{name}.json"));
                var token = json[entry];

                if (typeof(T) == typeof(Color))
                {
                    var colorWorkAround = token.ToObject<ColorWorkAround>();
                    Color color = new Color(colorWorkAround.r, colorWorkAround.g, colorWorkAround.b, colorWorkAround.a);
                    return (T?)(object)color;
                }
                else
                {
                    return token.ToObject<T?>();
                }
            }
            catch
            {
                return null;
            }
        }

        public void setConfigEntry(string entry, object value)
        {
            JObject config = getConfigIfExistsOrNewConfig($"{pathToConfigFolder}{name}.json");
            
            if(value.GetType() == typeof(Color))
            {
                var color = (Color)value;
                value = new ColorWorkAround(color.r,color.g,color.b,color.a);
            }

            config[entry] = JToken.FromObject(value);

            File.WriteAllText($"{pathToConfigFolder}{name}.json", JsonConvert.SerializeObject(config));
        }

        private JObject getConfigIfExistsOrNewConfig(string path)
        {
            if (Directory.Exists(pathToConfigFolder) && File.Exists(path))
                return JObject.Parse(File.ReadAllText(path));
            return new JObject();
        }

        struct ColorWorkAround
        {

            public ColorWorkAround(float r, float g, float b, float a)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }

            public float r;
            public float g;
            public float b;
            public float a;
        }
    }
}

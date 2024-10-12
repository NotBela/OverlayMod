using IPA;
using IPA.Config;
using IPA.Config.Stores;
using OverlayMod.Configuration;
using OverlayMod.Installers;
using SiraUtil.Zenject;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace OverlayMod
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        public static float scaleX { get => (float)Screen.width / 1920; }
        public static float scaleY { get => (float)Screen.height / 1080; }

        [Init]
        public void Init(IPALogger logger, Config conf, Zenjector zenject)
        {
            Instance = this;
            Log = logger;
            PluginConfig.Instance = conf.Generated<PluginConfig>();

            zenject.Install<NotMultiplayerInstaller>(Location.StandardPlayer);
            zenject.Install<MenuInstaller>(Location.Menu);
        }
    }
}

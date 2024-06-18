using OverlayMod.Installers;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using OverlayMod.Configuration;

namespace OverlayMod
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        public static float scaleX { get => (float) Screen.width / 1920; }
        public static float scaleY { get => (float) Screen.height / 1080; }

        [Init]
        public void Init(IPALogger logger, Config conf, Zenjector zenject)
        {
            Instance = this;
            Log = logger;
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            zenject.Install<GameInstaller>(Location.GameCore);
            zenject.Install<MenuInstaller>(Location.Menu);
        }
    }
}

using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using OverlayMod.Configuration;
using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using Zenject;


namespace OverlayMod.Views.ViewControllers
{
    [HotReload(RelativePathToLayout = @"ConfigViewController.bsml")]
    [ViewDefinition("OverlayMod.Views.ViewControllers.ConfigViewController.bsml")]
    internal class ConfigViewController : BSMLAutomaticViewController
    {
        #region Combo
        [UIValue("comboEnabled")]
        private bool comboEnabled
        {
            get
            {
                var comboEnabled = StatConfig.getConfigEntry<bool>(IStat.StatTypes.ComboStat, "enabled");
                return comboEnabled ?? false;
            }
            set
            {
                Configuration.StatConfig.setConfigEntry(IStat.StatTypes.ComboStat, "enabled", value);
            }
        }
        #endregion Combo

        #region percent
        [UIValue("percentEnabled")]
        private bool percentEnabled
        {
            get
            {
                return Configuration.StatConfig.getConfigEntry<bool>(IStat.StatTypes.PercentStat, "enabled") ?? true;
            }
            set
            {
                Configuration.StatConfig.setConfigEntry(IStat.StatTypes.PercentStat, "enabled", value);
            }
        }
        #endregion percent
    }
}

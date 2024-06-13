using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
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
                var comboEnabled = Configuration.StatConfig.getConfigEntry<ComboStat, bool>("enabled");
                return comboEnabled ?? ComboStat.defaultEnabled;
            }
            set
            {
                Configuration.StatConfig.setConfigEntry<ComboStat>("enabled", value);
            }
        }
        #endregion Combo

        #region percent
        [UIValue("percentEnabled")]
        private bool percentEnabled
        {
            get
            {
                return Configuration.StatConfig.getConfigEntry<PercentStat, bool>("enabled") ?? PercentStat.defaultEnabled;
            }
            set
            {
                Configuration.StatConfig.setConfigEntry<PercentStat>("enabled", value);
            }
        }
        #endregion percent
    }
}

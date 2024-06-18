using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using OverlayMod.Configuration;
using System;
using System.Collections.Generic;


namespace OverlayMod.Views.ViewControllers.LeftScreen
{
    [ViewDefinition("OverlayMod.Views.ViewControllers.LeftScreen.GlobalSettingsViewController.bsml")]
    internal class GlobalSettingsViewController : BSMLAutomaticViewController
    {
        [UIValue("globalEnable")]
        private bool globalEnable
        {
            get => PluginConfig.Instance.globalEnable;
            set => PluginConfig.Instance.globalEnable = value;
        }
    }
}

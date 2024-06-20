using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using OverlayMod.Configuration;
using OverlayMod.Views.ViewControllers.CenterScreen;
using System;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Zenject;


namespace OverlayMod.Views.ViewControllers.LeftScreen
{
    [ViewDefinition("OverlayMod.Views.ViewControllers.LeftScreen.GlobalSettingsViewController.bsml")]
    internal class GlobalSettingsViewController : BSMLAutomaticViewController
    {
        [Inject] private readonly ConfigViewController _otherViewController;
        [UIValue("globalEnable")]
        private bool globalEnable
        {
            get => PluginConfig.Instance.globalEnable;
            set => PluginConfig.Instance.globalEnable = value;
        }

        [UIComponent("resetAllButton")]
        private Button resetAllButton;

        [UIAction("resetAllButtonOnClick")]
        private void resetAllButtonOnClick()
        {
            StatConfig.clearConfig();
            _otherViewController.notifyPropertyChanged();
        }
    }
}
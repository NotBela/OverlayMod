using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.Tags;
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

        [UIParams] private BSMLParserParams parserParams;

        [UIValue("globalEnable")]
        private bool globalEnable
        {
            get => PluginConfig.Instance.globalEnable;
            set => PluginConfig.Instance.globalEnable = value;
        }

        [UIAction("resetAllButtonOnClick")]
        private void resetAllButtonOnClick()
        {
            parserParams.EmitEvent("resetSettingsModalShow");
        }

        [UIAction("resetSettingsDeny")]
        private void resetButtonDeny()
        {
            parserParams.EmitEvent("resetSettingsModalHide");
        }

        [UIAction("resetSettingsConfirm")]
        private void resetSettingsConfirm()
        {
            parserParams.EmitEvent("resetSettingsModalHide");
            StatConfig.clearConfig();
            _otherViewController.notifyPropertyChanged();
            parserParams.EmitEvent("resetSettingsModalCompletedShow");
        }

        [UIAction("resetSettingsModalCompletedOkButton")]
        private void resetSettingsModalCompletedOkButton()
        {
            parserParams.EmitEvent("resetSettingsModalCompletedHide");
        }
    }
}
﻿using BeatSaberMarkupLanguage;
using HMUI;
using OverlayMod.Views.ViewControllers.CenterScreen;
using OverlayMod.Views.ViewControllers.LeftScreen;
using Zenject;

namespace OverlayMod.Vews.FlowControllers
{
    internal class ConfigFlowController : HMUI.FlowCoordinator
    {
        private MainFlowCoordinator _parent;
        private ConfigViewController _viewController;
        private GlobalSettingsViewController _globalSettingsController;

        [Inject]
        private void Construct(MainFlowCoordinator parent, ConfigViewController viewController, GlobalSettingsViewController leftViewController)
        {
            _parent = parent;
            _viewController = viewController;
            _globalSettingsController = leftViewController;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            showBackButton = true;
            this.SetTitle("OverlayMod");
            ProvideInitialViewControllers(_viewController, leftScreenViewController: _globalSettingsController);
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _parent.DismissFlowCoordinator(this);
        }
    }
}

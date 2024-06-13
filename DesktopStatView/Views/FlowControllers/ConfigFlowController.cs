using BeatSaberMarkupLanguage;
using DesktopStatView.Views.ViewControllers;
using HMUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace DesktopStatView.Vews.FlowControllers
{
    internal class ConfigFlowController : HMUI.FlowCoordinator
    {
        private MainFlowCoordinator _parent;
        private ConfigViewController _viewController;

        [Inject]
        private void Construct(MainFlowCoordinator parent, ConfigViewController viewController)
        {
            _parent = parent;
            _viewController = viewController;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            showBackButton = true;
            this.SetTitle("DesktopStatView");
            ProvideInitialViewControllers(_viewController);
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _parent.DismissFlowCoordinator(this);
        }
    }
}

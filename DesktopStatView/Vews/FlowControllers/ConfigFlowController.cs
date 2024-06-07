using BeatSaberMarkupLanguage;
using DesktopStatView.Vews.ViewControllers;
using HMUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopStatView.Vews.FlowControllers
{
    internal class ConfigFlowController : HMUI.FlowCoordinator
    {
        private readonly MainFlowCoordinator _parent;
        private readonly ConfigViewController _viewController;

        public ConfigFlowController(MainFlowCoordinator parent, ConfigViewController viewController)
        {
            _viewController = viewController;
            _parent = parent;
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

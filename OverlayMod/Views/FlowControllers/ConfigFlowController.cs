using BeatSaberMarkupLanguage;
using HMUI;
using OverlayMod.Stat.Preview;
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

        private PreviewCanvasController _previewCanvasController;

        [Inject]
        private void Construct(MainFlowCoordinator parent, ConfigViewController viewController, GlobalSettingsViewController leftViewController, PreviewCanvasController previewCanvasController)
        {
            _parent = parent;
            _viewController = viewController;
            _globalSettingsController = leftViewController;
            _previewCanvasController = previewCanvasController;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            showBackButton = true;
            this.SetTitle("OverlayMod");
            ProvideInitialViewControllers(_viewController, leftScreenViewController: _globalSettingsController);
            _previewCanvasController.canvasGameObj.SetActive(true);
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _parent.DismissFlowCoordinator(this);
            _previewCanvasController.canvasGameObj.SetActive(false);
        }
    }
}

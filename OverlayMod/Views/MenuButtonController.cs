using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using OverlayMod.Vews.FlowControllers;
using System;
using Zenject;

namespace OverlayMod.Views
{
    internal class MenuButtonController : IInitializable, IDisposable
    {
        private readonly ConfigFlowController _flowController;
        private readonly MainFlowCoordinator _parent;

        private MenuButton _menuButton;

        public MenuButtonController(MainFlowCoordinator parent, ConfigFlowController flowController)
        {
            _flowController = flowController;
            _parent = parent;
            _menuButton = new MenuButton("OverlayMod", string.Empty, buttonClicked);
        }

        private void buttonClicked() => _parent.PresentFlowCoordinator(_flowController);

        public void Initialize() => MenuButtons.instance.RegisterButton(_menuButton);

        public void Dispose() => MenuButtons.instance.UnregisterButton(_menuButton);
    }
}

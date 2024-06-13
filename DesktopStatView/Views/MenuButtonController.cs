using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using DesktopStatView.Vews.FlowControllers;
using HMUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace DesktopStatView.Views
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
            _menuButton = new MenuButton("DesktopStatView", string.Empty, buttonClicked);
        }

        

        private void buttonClicked() => _parent.PresentFlowCoordinator(_flowController);

        public void Initialize()
        {
            MenuButtons.instance.RegisterButton(_menuButton);
        }

        public void Dispose()
        {
            MenuButtons.instance.UnregisterButton(_menuButton);
        }
    }
}

using BeatSaberMarkupLanguage.MenuButtons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace DesktopStatView.Vews
{
    internal class MenuButtonController : IInitializable, IDisposable
    {
        private MenuButton _menuButton;

        public MenuButtonController()
        {
            _menuButton = new MenuButton("DesktopStatView", );
        }

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

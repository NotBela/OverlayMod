using DesktopStatView.Vews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace DesktopStatView.Installers
{
    internal class MenuInstaller : Installer<MenuInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MenuButtonController>().AsSingle();
        }
    }
}

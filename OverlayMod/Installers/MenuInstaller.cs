using OverlayMod.Vews.FlowControllers;
using OverlayMod.Views;
using OverlayMod.Views.ViewControllers.CenterScreen;
using OverlayMod.Views.ViewControllers.LeftScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace OverlayMod.Installers
{
    internal class MenuInstaller : Installer<MenuInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ConfigFlowController>().FromNewComponentOnNewGameObject().AsSingle();

            Container.BindInterfacesAndSelfTo<ConfigViewController>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesAndSelfTo<GlobalSettingsViewController>().FromNewComponentAsViewController().AsSingle();

            Container.BindInterfacesAndSelfTo<MenuButtonController>().AsSingle();
        }
    }
}

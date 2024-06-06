using DesktopStatView.Stat;
using DesktopStatView.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace DesktopStatView.Installers
{
    internal class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CanvasController>().AsSingle();

            Container.BindInterfacesAndSelfTo<MissStat>().AsSingle();
            Container.BindInterfacesAndSelfTo<ComboStat>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreStat>().AsSingle();
            Container.BindInterfacesAndSelfTo<PercentStat>().AsSingle();
        }
    }
}

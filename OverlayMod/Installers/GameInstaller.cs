using OverlayMod.Stat;
using OverlayMod.Stat.Stats;
using Zenject;

namespace OverlayMod.Installers
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
            Container.BindInterfacesAndSelfTo<RankStat>().AsSingle();
            // Container.BindInterfacesAndSelfTo<EnergyStat>().AsSingle(); ill fix this up at some point
        }
    }
}

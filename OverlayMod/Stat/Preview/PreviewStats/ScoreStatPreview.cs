using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayMod.Stat.Preview.PreviewStats
{
    internal class ScoreStatPreview : PreviewStat
    {
        protected override Stats.Stat parentStat => ScoreStat.Instance;

        protected override string text => "1000000";
    }
}

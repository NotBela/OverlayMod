using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayMod.Stat.Preview.PreviewStats
{
    internal class ComboStatPreview : PreviewStat
    {
        protected override Stats.Stat parentStat => ComboStat.Instance;

        protected override string text => "1000";
    }
}

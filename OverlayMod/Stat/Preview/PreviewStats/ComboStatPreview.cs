using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayMod.Stat.Preview.PreviewStats
{
    internal class ComboStatPreview : IPreviewStat
    {
        protected override IStat parentStat => ComboStat.Instance;

        protected override string text => "123";
    }
}

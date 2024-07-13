using Microsoft.SqlServer.Server;
using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayMod.Stat.Preview.PreviewStats
{
    internal class PercentStatPreview : PreviewStat
    {
        protected override Stats.Stat parentStat => PercentStat.Instance;

        protected override string text => 100.ToString($"F{PercentStat.Instance.decimalPrecision}", parentStat.decimalFormat);

        public override void Update()
        {
            base.Update();

            this.textMesh.text = text;
        }
    }
}

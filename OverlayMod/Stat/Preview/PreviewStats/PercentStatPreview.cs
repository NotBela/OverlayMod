using Microsoft.SqlServer.Server;
using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayMod.Stat.Preview.PreviewStats
{
    internal class PercentStatPreview : IPreviewStat
    {
        protected override Stats.Stat parentStat => PercentStat.Instance;

        protected override string text => getPercentDecimalPrecision();

        public override void Update()
        {
            base.Update();

            this.textMesh.text = text;
        }

        private string getPercentDecimalPrecision()
        {
            string output = "0.";
            for (int i = 0; i < PercentStat.Instance.decimalPrecision; i++)
            {
                output += "0";
            }

            return 100.ToString(output);
        }
    }
}

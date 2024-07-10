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
        protected override IStat parentStat => PercentStat.Instance;

        protected override string text => getPercentDecimalPrecision();

        private string getPercentDecimalPrecision()
        {
            string precision = "0.";
            for (int i = 0; i < PercentStat.Instance.decimalPrecision; i++)
            {
                precision += "0";
            }

            return 100.ToString(precision);
        }
    }
}

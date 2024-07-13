using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OverlayMod.Stat.Preview.PreviewStats
{
    internal class MissStatPreview : PreviewStat
    {
        protected override Stats.Stat parentStat => MissStat.Instance;

        protected override string text => "x1";

        
        public override void Update()
        {
            base.Update();

        }

        protected override void doExtraThings()
        {

        }
    }
}

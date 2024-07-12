using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OverlayMod.Stat.Preview.PreviewStats
{
    internal class MissStatPreview : IPreviewStat
    {
        protected override Stats.Stat parentStat => MissStat.Instance;

        private bool redMissCounter
        {
            get => MissStat.Instance.redMissCounter;
        }

        protected override string text => "x1";

        public override void Update()
        {
            base.Update();

            if (redMissCounter)
            {
                this.textMesh.color = Color.red;
                return;
            }

            this.textMesh.color = Color.white;
        }

        protected override void doExtraThings()
        {
            if (redMissCounter)
            {
                this.textMesh.color = Color.red;
                return;
            }

            this.textMesh.color = Color.white;
        }
    }
}

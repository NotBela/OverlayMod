using OverlayMod.Stat.Stats;

namespace OverlayMod.Stat.Preview.PreviewStats
{
    internal class PercentStatPreview : PreviewStat
    {
        protected override Stats.Stat parentStat => PercentStat.Instance;

        protected override string text => 100.ToString($"F{PercentStat.Instance.decimalPrecision}%", parentStat.decimalFormat);

        public override void Update()
        {
            base.Update();

            this.textMesh.text = text;
        }
    }
}

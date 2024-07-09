using OverlayMod.Configuration;
using System;
using TMPro;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class ScoreStat : IStat, IDisposable
    {
        [Inject] private readonly ScoreController _scoreController;

        public StatConfig config = new StatConfig(Instance, "ScoreStat");

        public override TextAlignmentOptions? optionalAllignmentOverride => TextAlignmentOptions.Left;

        public override int posX
        {
            get => config.getConfigEntry<int>("posX") ?? 275;
            set => config.setConfigEntry("posX", value);
        }
        public override int posY
        {
            get => config.getConfigEntry<int>("posY") ?? 75;
            set => config.setConfigEntry("posY", value);
        }
        public override float size
        {
            get => config.getConfigEntry<float>("size") ?? 40;
            set => config.setConfigEntry("size", value);
        }
        public override bool enabled
        {
            get => config.getConfigEntry<bool>("enabled") ?? true;
            set => config.setConfigEntry("enabled", value);
        }

        public static ScoreStat Instance { get; } = new ScoreStat();

        protected override void CreateStat()
        {
            _scoreController.scoreDidChangeEvent += UpdateText;

            setTextParams("0");
        }

        private void UpdateText(int scoreMultiplied, int scoreWithMods)
        {
            this.text.text = scoreWithMods.ToString();
        }

        public void Dispose()
        {
            _scoreController.scoreDidChangeEvent -= UpdateText;
        }
    }
}

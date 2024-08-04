using OverlayMod.Configuration;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class ScoreStat : Stat, IDisposable
    {
        [Inject] private readonly IScoreController _scoreController;

        protected override StatConfig config { get; } = new StatConfig(Instance, "ScoreStat");

        public override TextAlignmentOptions optionalAllignmentOverride => TextAlignmentOptions.Left;

        public override int defaultPosX => 275;
        public override int defaultPosY => 75;
        public override float defaultSize => 40;
        public override bool defaultEnabled => true;
        public override Color defaultColor => Color.white;

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

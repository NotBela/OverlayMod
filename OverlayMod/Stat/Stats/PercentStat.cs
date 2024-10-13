using OverlayMod.Configuration;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class PercentStat : Stat, IDisposable
    {
        [Inject] private readonly RelativeScoreAndImmediateRankCounter _relativeScoreCounter;

        protected override StatConfig config { get; } = new StatConfig(Instance, "PercentStat");

        public int decimalPrecision
        {
            get => config.getConfigEntry<int>("decimalPrecision") ?? 2;
            set => config.setConfigEntry("decimalPrecision", value);
        }
        public override int defaultPosX => 275;
        public override int defaultPosY => 150;
        public override float defaultSize => 100;
        public override bool defaultEnabled => true;

        public override Color defaultColor => Color.white;

        public override TextAlignmentOptions optionalAllignmentOverride => TextAlignmentOptions.Left;

        public static PercentStat Instance { get; } = new PercentStat();

        protected override void CreateStat()
        {
            _relativeScoreCounter.relativeScoreOrImmediateRankDidChangeEvent += UpdateText;

            setTextParams(100.ToString($"F{decimalPrecision}%", this.decimalFormat));
        }

        private void UpdateText()
        {
            this.text.text = $"{(_relativeScoreCounter.relativeScore * 100).ToString($"F{PercentStat.Instance.decimalPrecision}", this.decimalFormat)}%";
        }

        public void Dispose()
        {
            _relativeScoreCounter.relativeScoreOrImmediateRankDidChangeEvent -= UpdateText;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using OverlayMod.Configuration;
using TMPro;

namespace OverlayMod.Stat.Stats
{
    internal class PercentStat : IStat, IDisposable
    {
        [Inject] private readonly RelativeScoreAndImmediateRankCounter _relativeScoreCounter;
        [Inject] private readonly ScoreController _scoreController;

        public StatConfig config { get; } = new StatConfig(Instance, "PercentStat");

        public int decimalPrecision
        {
            get => config.getConfigEntry<int>("decimalPrecision") ?? 2;
            set => config.setConfigEntry("decimalPrecision", value);
        }
        public override int posX 
        {
            get => config.getConfigEntry<int>("posX") ?? 320;
            set => config.setConfigEntry("posX", value);
        }
        public override int posY
        {
            get => config.getConfigEntry<int>("posY") ?? 150;
            set => config.setConfigEntry("posY", value);
        }
        public override float size
        {
            get => config.getConfigEntry<float>("size") ?? 100;
            set => config.setConfigEntry("size", value);
        }
        public override bool enabled
        {
            get => config.getConfigEntry<bool>("enabled") ?? true;
            set => config.setConfigEntry("enabled", value);
        }

        public override TextAlignmentOptions? optionalAllignmentOverride => TextAlignmentOptions.Left;

        public static PercentStat Instance { get; } = new PercentStat();

        protected override void CreateStat()
        {
            _relativeScoreCounter.relativeScoreOrImmediateRankDidChangeEvent += UpdateText;
            setTextParams("100.00");
        }

        private void UpdateText()
        {
            this.text.text = $"{(_relativeScoreCounter.relativeScore * 100).ToString("0.00")}";
        }

        public void Dispose()
        {
            _relativeScoreCounter.relativeScoreOrImmediateRankDidChangeEvent -= UpdateText;
        }
    }
}

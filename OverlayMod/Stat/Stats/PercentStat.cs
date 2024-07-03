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

        public override StatTypes enumType => StatTypes.PercentStat;

        public override int posX 
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posX") ?? 275;
            set => StatConfig.setConfigEntry(enumType, "posX", value);
        }
        public override int posY
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posY") ?? 150;
            set => StatConfig.setConfigEntry(enumType, "posY", value);
        }
        public override float size
        {
            get => StatConfig.getConfigEntry<float>(enumType, "size") ?? 70;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override bool enabled
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? true;
            set => StatConfig.setConfigEntry(enumType, "enabled", value);
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

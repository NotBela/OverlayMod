using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using OverlayMod.Configuration;

namespace OverlayMod.Stat.Stats
{
    internal class PercentStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly RelativeScoreAndImmediateRankCounter _relativeScoreCounter;
        [Inject] private readonly ScoreController _scoreController;

        public override StatTypes enumType => StatTypes.PercentStat;

        public override int posX 
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posX") ?? 250;
            set => StatConfig.setConfigEntry(enumType, "posX", value);
        }
        public override int posY
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posY") ?? 150;
            set => StatConfig.setConfigEntry(enumType, "posY", value);
        }
        public override int size
        {
            get => StatConfig.getConfigEntry<int>(enumType, "size") ?? 70;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override bool enabled
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? true;
            set => StatConfig.setConfigEntry(enumType, "enabled", value);
        }

        public static PercentStat Instance { get; } = new PercentStat();

        public override void Initialize()
        {
            base.Initialize();

            _relativeScoreCounter.relativeScoreOrImmediateRankDidChangeEvent += UpdateText;

            textObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 200);
            setTextParams("100.00");
        }

        private void UpdateText()
        {
            float percent = ((float) _scoreController.modifiedScore / _scoreController.immediateMaxPossibleModifiedScore) * 100;

            // really fucking dumb fix
            if (percent.ToString() == "NaN")
            {
                this.text.text = "100.00";
                return;
            }

            this.text.text = $"{percent.ToString("0.00")}";
        }

        public void Dispose()
        {
            _relativeScoreCounter.relativeScoreOrImmediateRankDidChangeEvent -= UpdateText;
        }
    }
}

using OverlayMod.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class ScoreStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly ScoreController _scoreController;

        public override StatTypes enumType => StatTypes.ScoreStat;

        public override TextAlignmentOptions? optionalAllignmentOverride => TMPro.TextAlignmentOptions.Left;

        public override int posX { 
            get => StatConfig.getConfigEntry<int>(enumType, "posX") ?? 275; 
            set => StatConfig.setConfigEntry(enumType, "posX", value); 
        }
        public override int posY
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posY") ?? 75;
            set => StatConfig.setConfigEntry(enumType, "posY", value);
        }
        public override float size
        {
            get => StatConfig.getConfigEntry<float>(enumType, "size") ?? 40;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override bool enabled
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? true;
            set => StatConfig.setConfigEntry(enumType, "enabled", value);
        }

        public static ScoreStat Instance { get; } = new ScoreStat();

        public override void Initialize()
        {
            base.Initialize();

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

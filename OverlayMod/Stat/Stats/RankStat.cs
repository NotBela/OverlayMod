using OverlayMod.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class RankStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly RelativeScoreAndImmediateRankCounter _relativeScore;

        public override StatTypes enumType => StatTypes.RankStat;

        public override bool enabled
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? true;
            set => StatConfig.setConfigEntry(enumType, "enabled", value);
        }
        public override int posX 
        { 
            get => StatConfig.getConfigEntry<int>(enumType, "posX") ?? Screen.width / 2; 
            set => StatConfig.setConfigEntry(enumType, "posX", value); 
        }
        public override int posY 
        { 
            get => StatConfig.getConfigEntry<int>(enumType, "posY") ?? Screen.height / 2; 
            set => StatConfig.setConfigEntry(enumType, "posY", value); 
        }
        public override float size
        { 
            get => StatConfig.getConfigEntry<float>(enumType, "size") ?? 100;
            set => StatConfig.setConfigEntry(enumType, "size", value); 
        }

        public static RankStat Instance = new RankStat();

        public override void Initialize()
        {
            base.Initialize();
            setTextParams($"{_relativeScore.immediateRank.ToString()}");
            _relativeScore.relativeScoreOrImmediateRankDidChangeEvent += Update;
        }

        private void Update()
        {
            this.text.text = $"{_relativeScore.immediateRank}";

        }
        public void Dispose()
        {
            _relativeScore.relativeScoreOrImmediateRankDidChangeEvent -= Update;
        }
    }
}

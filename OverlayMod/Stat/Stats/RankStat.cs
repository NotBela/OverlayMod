using OverlayMod.Configuration;
using System;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class RankStat : Stat, IDisposable
    {
        [Inject] private readonly RelativeScoreAndImmediateRankCounter _relativeScore;

        public StatConfig config = new StatConfig(Instance, "RankStat");

        public override bool enabled
        {
            get => config.getConfigEntry<bool>("enabled") ?? false;
            set => config.setConfigEntry("enabled", value);
        }
        public override int posX
        {
            get => config.getConfigEntry<int>("posX") ?? 275;
            set => config.setConfigEntry("posX", value);
        }
        public override int posY
        {
            get => config.getConfigEntry<int>("posY") ?? 275;
            set => config.setConfigEntry("posY", value);
        }
        public override float size
        {
            get => config.getConfigEntry<float>("size") ?? 100;
            set => config.setConfigEntry("size", value);
        }

        public static RankStat Instance = new RankStat();

        protected override void CreateStat()
        {
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

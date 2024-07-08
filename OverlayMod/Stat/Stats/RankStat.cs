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
    internal class RankStat : IStat, IDisposable
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
            get => config.getConfigEntry<int>("posX") ?? Screen.width / 2; 
            set => config.setConfigEntry("posX", value); 
        }
        public override int posY 
        { 
            get => config.getConfigEntry<int>("posY") ?? Screen.height / 2; 
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

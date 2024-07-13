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

        #region colors
        public Color ssColor
        {
            get => config.getConfigEntry<Color>("ssColor") ?? Color.white;
            set => config.setConfigEntry("ssColor", value);
        }

        public Color sColor
        {
            get => config.getConfigEntry<Color>("sColor") ?? Color.white;
            set => config.setConfigEntry("sColor", value);
        }

        public Color aColor
        {
            get => config.getConfigEntry<Color>("aColor") ?? Color.white;
            set => config.setConfigEntry("aColor", value);
        }

        public Color bColor
        {
            get => config.getConfigEntry<Color>("bColor") ?? Color.white;
            set => config.setConfigEntry("bColor", value);
        }

        public Color cColor
        {
            get => config.getConfigEntry<Color>("cColor") ?? Color.white;
            set => config.setConfigEntry("cColor", value);
        }

        public Color dColor
        {
            get => config.getConfigEntry<Color>("dColor") ?? Color.white;
            set => config.setConfigEntry("dColor", value);
        }

        public Color eColor
        {
            get => config.getConfigEntry<Color>("eColor") ?? Color.white;
            set => config.setConfigEntry("eColor", value);
        }
        #endregion colors
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

        public override Color color
        {
            get => config.getConfigEntry<Color>("color") ?? Color.white;
            set => config.setConfigEntry("color", value);
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
            this.text.color = getColorForRank(_relativeScore.immediateRank);

        }
        public void Dispose()
        {
            _relativeScore.relativeScoreOrImmediateRankDidChangeEvent -= Update;
        }

        private Color getColorForRank(RankModel.Rank rank)
        {
            switch(rank)
            {
                case RankModel.Rank.SS: return ssColor;
                case RankModel.Rank.S: return sColor;
                case RankModel.Rank.A: return aColor;
                case RankModel.Rank.B: return bColor;
                case RankModel.Rank.C: return cColor;
                case RankModel.Rank.D: return dColor;
                case RankModel.Rank.E: return eColor;
                default: return color;
            }
        }
    }
}

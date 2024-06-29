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

        //public bool changeRankColor
        //{
        //    get => StatConfig.getConfigEntry<bool>(enumType, "changeRankColor") ?? false;
        //    set => StatConfig.setConfigEntry(enumType, "changeRankColor", value);
        //}

        //public RankColor SSColor
        //{
        //    get => StatConfig.getConfigEntry<RankColor>(enumType, "SSColor") ?? new RankColor(Color.cyan);
        //    set => StatConfig.setConfigEntry(enumType, "SSColor", value);
        //}
        //public RankColor SColor
        //{
        //    get => StatConfig.getConfigEntry<RankColor>(enumType, "SColor") ?? new RankColor(Color.white);
        //    set => StatConfig.setConfigEntry(enumType, "SColor", value);
        //}
        //public RankColor AColor
        //{
        //    get => StatConfig.getConfigEntry<RankColor>(enumType, "AColor") ?? new RankColor(Color.green);
        //    set => StatConfig.setConfigEntry(enumType, "AColor", value);
        //}
        //public RankColor BColor
        //{
        //    get => StatConfig.getConfigEntry<RankColor>(enumType, "BColor") ?? new RankColor(Color.yellow); 
        //    set => StatConfig.setConfigEntry(enumType, "BColor", value);
        //}
        //public RankColor CColor
        //{
        //    get => StatConfig.getConfigEntry<RankColor>(enumType, "CColor") ?? new RankColor(1, 0.5f, 0); 
        //    set => StatConfig.setConfigEntry(enumType, "CColor", value);
        //}
        //public RankColor DColor
        //{
        //    get => StatConfig.getConfigEntry<RankColor>(enumType, "DColor") ?? new RankColor(Color.red); 
        //    set => StatConfig.setConfigEntry(enumType, "DColor", value);
        //}
        //public RankColor EColor
        //{
        //    get => StatConfig.getConfigEntry<RankColor>(enumType, "EColor") ?? new RankColor(Color.red);
        //    set => StatConfig.setConfigEntry(enumType, "EColor", value);
        //}

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

        //private RankColor getColorForRank(RankModel.Rank rank)
        //{
        //    switch (rank)
        //    {
        //        case (RankModel.Rank.SS):
        //            return SSColor;
        //        case (RankModel.Rank.S):
        //            return SColor;
        //        case (RankModel.Rank.A):
        //            return AColor;
        //        case RankModel.Rank.B:
        //            return BColor;
        //        case (RankModel.Rank.C):
        //            return CColor;
        //        case (RankModel.Rank.D):
        //            return DColor;
        //        case (RankModel.Rank.E):
        //            return EColor;
        //        default:
        //            return new RankColor(Color.white);
        //    }
        //}

    }
}

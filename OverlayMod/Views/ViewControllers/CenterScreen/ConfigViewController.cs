using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using OverlayMod.Stat.Stats;
using UnityEngine;


namespace OverlayMod.Views.ViewControllers.CenterScreen
{
    [ViewDefinition("OverlayMod.Views.ViewControllers.CenterScreen.ConfigViewController.bsml")]
    internal class ConfigViewController : BSMLAutomaticViewController
    {
        [UIValue("maxHeight")] private int maxHeight => Screen.height;
        [UIValue("maxWidth")] private int maxWidth => Screen.width;

        #region Combo
        [UIValue("comboEnabled")]
        private bool comboEnabled
        {
            get => ComboStat.Instance.enabled;
            set => ComboStat.Instance.enabled = value;
        }

        [UIValue("comboHeightValue")]
        private int comboHeightValue
        {
            get => ComboStat.Instance.posY;
            set => ComboStat.Instance.posY = value;
        }

        [UIValue("comboWidthValue")]
        private int comboWidthValue
        {
            get => ComboStat.Instance.posY;
            set => ComboStat.Instance.posY = value;
        }

        [UIValue("comboSize")]
        private float comboSize
        {
            get => ComboStat.Instance.size;
            set => ComboStat.Instance.size = (int)value;
        }

        #endregion Combo

        #region percent
        [UIValue("percentEnabled")]
        private bool percentEnabled
        {
            get => PercentStat.Instance.enabled;
            set => PercentStat.Instance.enabled = value;
        }

        [UIValue("percentHeightValue")]
        private int percentHeightValue
        {
            get => PercentStat.Instance.posY;
            set => PercentStat.Instance.posY = (int)value;
        }

        [UIValue("percentWidthValue")]
        private int percentWidthValue
        {
            get => PercentStat.Instance.posX;
            set => PercentStat.Instance.posX = (int)value;
        }

        [UIValue("percentSize")]
        private float percentSize
        {
            get => PercentStat.Instance.size;
            set => PercentStat.Instance.size = (int)value;
        }
        #endregion percent

        #region miss
        [UIValue("missEnabled")]
        private bool missEnabled
        {
            get => MissStat.Instance.enabled;
            set => MissStat.Instance.enabled = value;
        }

        [UIValue("redMissText")]
        private bool redMissText
        {
            get => MissStat.Instance.redMissCounter;
            set => MissStat.Instance.redMissCounter = value;
        }

        [UIValue("hideWhileFc")]
        private bool hideWhileFc
        {
            get => MissStat.Instance.hideUntilMissed;
            set => MissStat.Instance.hideUntilMissed = value;
        }

        [UIValue("missHeightValue")]
        private int missHeightValue
        {
            get => MissStat.Instance.posY;
            set => MissStat.Instance.posY = value;
        }

        [UIValue("missWidthValue")]
        private int missWidthValue
        {
            get => MissStat.Instance.posX;
            set => MissStat.Instance.posX = value;
        }

        [UIValue("missSize")]
        private float missSize
        {
            get => MissStat.Instance.size;
            set => MissStat.Instance.size = (int)value;
        }

        #endregion miss 

        #region score
        [UIValue("scoreEnabled")]
        private bool scoreEnabled
        {
            get => ScoreStat.Instance.enabled;
            set => ScoreStat.Instance.enabled = value;
        }

        [UIValue("scoreWidthValue")]
        private int scoreWidthValue
        {
            get => ScoreStat.Instance.posX;
            set => ScoreStat.Instance.posX = value;
        }

        [UIValue("scoreHeightValue")]
        private int scoreHeightValue
        {
            get => ScoreStat.Instance.posY;
            set => ScoreStat.Instance.posY = value;
        }

        [UIValue("scoreSize")]
        private float scoreSize
        {
            get => ScoreStat.Instance.size;
            set => ScoreStat.Instance.size = (int)value;
        }
        #endregion score

        #region energy

        [UIValue("energyEnabled")]
        private bool energyEnabled
        {
            get => EnergyStat.Instance.enabled;
            set => EnergyStat.Instance.enabled = value;
        }

        [UIValue("energyWidthValue")]
        private int energyWidthValue
        {
            get => EnergyStat.Instance.posX;
            set => EnergyStat.Instance.posX = value;
        }

        [UIValue("energyHeightValue")]
        private int energyHeightValue
        {
            get => EnergyStat.Instance.posY;
            set => EnergyStat.Instance.posY = value;
        }

        [UIValue("energySize")]
        private float energySize
        {
            get => EnergyStat.Instance.size;
            set => EnergyStat.Instance.size = value;
        }

        [UIValue("redBarOnLowEnergy")]
        private bool redBarOnLowEnergy
        {
            get => EnergyStat.Instance.changeBarColorOnLowEnergy;
            set => EnergyStat.Instance.changeBarColorOnLowEnergy = value;
        }

        #endregion energy

        #region rank

        [UIValue("rankEnabled")]
        private bool rankEnabled
        {
            get => RankStat.Instance.enabled;
            set => RankStat.Instance.enabled = value;
        }

        [UIValue("rankWidthValue")]
        private int rankWidthValue
        {
            get => RankStat.Instance.posX;
            set => RankStat.Instance.posX = value;
        }

        [UIValue("rankHeightValue")]
        private int rankHeightValue
        {
            get => RankStat.Instance.posY;
            set => RankStat.Instance.posY = value;
        }

        [UIValue("rankSize")]
        private float rankSize
        {
            get => RankStat.Instance.size;
            set => RankStat.Instance.size = value;
        }

        #endregion rank

        [UIParams] private BSMLParserParams parserParams;

        public void notifyPropertyChanged()
        {
            foreach (var property in typeof(ConfigViewController).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance))
            {
                NotifyPropertyChanged(property.Name);
            }
        }

    }
}
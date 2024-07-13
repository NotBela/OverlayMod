using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BeatSaberMarkupLanguage.ViewControllers;
using OverlayMod.Stat.Preview;
using OverlayMod.Stat.Stats;
using UnityEngine;
using Zenject;


namespace OverlayMod.Views.ViewControllers.CenterScreen
{
    [ViewDefinition("OverlayMod.Views.ViewControllers.CenterScreen.ConfigViewController.bsml")]
    internal class ConfigViewController : BSMLAutomaticViewController
    {
        [UIValue("maxHeight")] private int maxHeight => Screen.height;
        [UIValue("maxWidth")] private int maxWidth => Screen.width;

        [Inject] private readonly PreviewCanvasController _previewCanvasController;

        #region Combo
        [UIValue("comboEnabled")]
        private bool comboEnabled
        {
            get => ComboStat.Instance.enabled;
            set { ComboStat.Instance.enabled = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("comboHeightValue")]
        private int comboHeightValue
        {
            get => ComboStat.Instance.posY;
            set { ComboStat.Instance.posY = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("comboWidthValue")]
        private int comboWidthValue
        {
            get => ComboStat.Instance.posX;
            set { ComboStat.Instance.posX = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("comboSize")]
        private float comboSize
        {
            get => ComboStat.Instance.size;
            set { ComboStat.Instance.size = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("comboColor")]
        private Color comboColor
        {
            get => ComboStat.Instance.color;
            set { ComboStat.Instance.color = value; _previewCanvasController.updateStats(); }
        }

        #endregion Combo

        #region percent
        [UIValue("percentEnabled")]
        private bool percentEnabled
        {
            get => PercentStat.Instance.enabled;
            set { PercentStat.Instance.enabled = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("percentHeightValue")]
        private int percentHeightValue
        {
            get => PercentStat.Instance.posY;
            set { PercentStat.Instance.posY = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("percentWidthValue")]
        private int percentWidthValue
        {
            get => PercentStat.Instance.posX;
            set { PercentStat.Instance.posX = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("percentSize")]
        private float percentSize
        {
            get => PercentStat.Instance.size;
            set { PercentStat.Instance.size = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("percentDecimalPrecision")]
        private int percentDecimalPrecision
        {
            get => PercentStat.Instance.decimalPrecision;
            set { PercentStat.Instance.decimalPrecision = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("percentColor")]
        private Color percentColor
        {
            get => PercentStat.Instance.color;
            set { PercentStat.Instance.color = value; _previewCanvasController.updateStats(); }
        }

        #endregion percent

        #region miss
        [UIValue("missEnabled")]
        private bool missEnabled
        {
            get => MissStat.Instance.enabled;
            set { MissStat.Instance.enabled = value; _previewCanvasController.updateStats(); }
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
            set { MissStat.Instance.posY = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("missWidthValue")]
        private int missWidthValue
        {
            get => MissStat.Instance.posX;
            set { MissStat.Instance.posX = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("missSize")]
        private float missSize
        {
            get => MissStat.Instance.size;
            set
            {
                MissStat.Instance.size = value;
                _previewCanvasController.updateStats();
            }
        }

        [UIValue("missColor")]
        private Color missColor
        {
            get => MissStat.Instance.color;
            set { MissStat.Instance.color = value; _previewCanvasController.updateStats(); }
        }

        #endregion miss 

        #region score
        [UIValue("scoreEnabled")]
        private bool scoreEnabled
        {
            get => ScoreStat.Instance.enabled;
            set { ScoreStat.Instance.enabled = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("scoreWidthValue")]
        private int scoreWidthValue
        {
            get => ScoreStat.Instance.posX;
            set { ScoreStat.Instance.posX = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("scoreHeightValue")]
        private int scoreHeightValue
        {
            get => ScoreStat.Instance.posY;
            set { ScoreStat.Instance.posY = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("scoreSize")]
        private float scoreSize
        {
            get => ScoreStat.Instance.size;
            set { ScoreStat.Instance.size = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("scoreColor")]
        private Color scoreColor
        {
            get => ScoreStat.Instance.color;
            set { ScoreStat.Instance.color = value; _previewCanvasController.updateStats(); }
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
        /*
        [UIValue("energyColor")]
        private Color energyColor
        {
            get => ScoreStat.Instance.color;
            set { ScoreStat.Instance.color = value; _previewCanvasController.updateStats(); }
        }
        */
        #endregion energy

        #region rank

        [UIValue("rankEnabled")]
        private bool rankEnabled
        {
            get => RankStat.Instance.enabled;
            set { RankStat.Instance.enabled = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("rankWidthValue")]
        private int rankWidthValue
        {
            get => RankStat.Instance.posX;
            set { RankStat.Instance.posX = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("rankHeightValue")]
        private int rankHeightValue
        {
            get => RankStat.Instance.posY;
            set { RankStat.Instance.posY = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("rankSize")]
        private float rankSize
        {
            get => RankStat.Instance.size;
            set { RankStat.Instance.size = value; _previewCanvasController.updateStats(); }
        }

        [UIValue("rankColor")]
        private Color rankColor
        {
            get => RankStat.Instance.color;
            set { RankStat.Instance.color = value; _previewCanvasController.updateStats(); }
        }
        #endregion rank

        [UIParams] private BSMLParserParams parserParams;

        public void notifyPropertyChanged()
        {
            foreach (var property in typeof(ConfigViewController).GetProperties(
                System.Reflection.BindingFlags.Public | 
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance
                ))
            {
                NotifyPropertyChanged(property.Name);
            }
        }

    }
}
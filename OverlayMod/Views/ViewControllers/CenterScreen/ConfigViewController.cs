using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Notify;
using BeatSaberMarkupLanguage.ViewControllers;
using OverlayMod.Configuration;
using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using Zenject;
using System.ComponentModel;
using UnityEngine;
using System.Xml.Schema;


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
            set => ComboStat.Instance.size = (int) value;
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
            get => PercentStat.Instance.posX;
            set => PercentStat.Instance.posX = (int)value;
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
            set => MissStat.Instance.size = (int) value;
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
            set => ScoreStat.Instance.size = (int) value;
        }
        #endregion score

        public void notifyPropertyChanged()
        {
            // implement
        }

    }
}

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
            get
            {
                var comboEnabled = StatConfig.getConfigEntry<bool>(IStat.StatTypes.ComboStat, "enabled");
                return comboEnabled ?? false;
            }
            set
            {
                Configuration.StatConfig.setConfigEntry(IStat.StatTypes.ComboStat, "enabled", value);
            }
        }

        [UIValue("comboHeightValue")]
        private int comboHeightValue
        {
            get => StatConfig.getConfigEntry<int>(IStat.StatTypes.ComboStat, "posY") ?? Screen.height / 2;
            set => StatConfig.setConfigEntry(IStat.StatTypes.ComboStat, "posY", value);
        }

        [UIValue("comboWidthValue")]
        private int comboWidthValue
        {
            get => StatConfig.getConfigEntry<int>(IStat.StatTypes.ComboStat, "posX") ?? Screen.width / 2;
            set => StatConfig.setConfigEntry(IStat.StatTypes.ComboStat, "posX", value);
        }

        [UIValue("comboSize")]
        private float comboSize
        {
            get => StatConfig.getConfigEntry<float>(IStat.StatTypes.ComboStat, "size") ?? 60;
            set => StatConfig.setConfigEntry(IStat.StatTypes.ComboStat, "size", value);
        }

        #endregion Combo

        #region percent
        [UIValue("percentEnabled")]
        private bool percentEnabled
        {
            get
            {
                return Configuration.StatConfig.getConfigEntry<bool>(IStat.StatTypes.PercentStat, "enabled") ?? true;
            }
            set
            {
                Configuration.StatConfig.setConfigEntry(IStat.StatTypes.PercentStat, "enabled", value);
            }
        }

        [UIValue("percentHeightValue")]
        private int percentHeightValue
        {
            get => StatConfig.getConfigEntry<int>(IStat.StatTypes.PercentStat, "posY") ?? 250;
            set => StatConfig.setConfigEntry(IStat.StatTypes.PercentStat, "posY", value);
        }

        [UIValue("percentWidthValue")]
        private int percentWidthValue
        {
            get => StatConfig.getConfigEntry<int>(IStat.StatTypes.PercentStat, "posX") ?? 150;
            set => StatConfig.setConfigEntry(IStat.StatTypes.PercentStat, "posX", value);
        }

        [UIValue("percentSize")]
        private float percentSize
        {
            get => StatConfig.getConfigEntry<float>(IStat.StatTypes.PercentStat, "size") ?? 70;
            set => StatConfig.setConfigEntry(IStat.StatTypes.PercentStat, "size", value);
        }
        #endregion percent

        #region miss
        [UIValue("missEnabled")]
        private bool missEnabled
        {
            get => StatConfig.getConfigEntry<bool>(IStat.StatTypes.MissStat, "enabled") ?? true;
            set => StatConfig.setConfigEntry(IStat.StatTypes.MissStat, "enabled", value);
        }

        [UIValue("redMissText")]
        private bool redMissText
        {
            get => StatConfig.getConfigEntry<bool>(IStat.StatTypes.MissStat, "redMissText") ?? true;
            set => StatConfig.setConfigEntry(IStat.StatTypes.MissStat, "redMissText", value);
        }

        [UIValue("hideWhileFc")]
        private bool hideWhileFc
        {
            get => StatConfig.getConfigEntry<bool>(IStat.StatTypes.MissStat, "hideWhileFc") ?? true;
            set => StatConfig.setConfigEntry(IStat.StatTypes.MissStat, "hideWhileFc", value);
        }

        [UIValue("missHeightValue")]
        private int missHeightValue
        {
            get => StatConfig.getConfigEntry<int>(IStat.StatTypes.MissStat, "posY") ?? 100;
            set => StatConfig.setConfigEntry(IStat.StatTypes.MissStat, "posY", value);
        }

        [UIValue("missWidthValue")]
        private int missWidthValue
        {
            get => StatConfig.getConfigEntry<int>(IStat.StatTypes.MissStat, "posX") ?? 400;
            set => StatConfig.setConfigEntry(IStat.StatTypes.MissStat, "posX", value);
        }

        [UIValue("missSize")]
        private float missSize
        {
            get => StatConfig.getConfigEntry<float>(IStat.StatTypes.MissStat, "size") ?? 40;
            set => StatConfig.setConfigEntry(IStat.StatTypes.MissStat, "size", value);
        }

        #endregion miss 

        public void notifyPropertyChanged()
        {
            // implement
        }

    }
}

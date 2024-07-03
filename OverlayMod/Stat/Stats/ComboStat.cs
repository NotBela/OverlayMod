﻿using OverlayMod.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class ComboStat : IStat, IDisposable
    {
        [Inject] private readonly ComboController _comboController;

        public override StatTypes enumType { get => StatTypes.ComboStat; }

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
            get => StatConfig.getConfigEntry<float>(enumType, "size") ?? 40;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override bool enabled
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? false;
            set => StatConfig.setConfigEntry(enumType, "enabled", value);
        }

        public static ComboStat Instance { get; } = new ComboStat();

        protected override void CreateStat()
        {
            _comboController.comboDidChangeEvent += UpdateText;

            setTextParams("0");
        }

        private void UpdateText(int combo)
        {
            this.text.text = $"{combo}";
        }

        public void Dispose()
        {
            _comboController.comboDidChangeEvent -= UpdateText;
        }
    }
}

using OverlayMod.Configuration;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class ComboStat : Stat, IDisposable
    {
        [Inject] private readonly IComboController _comboController;

        public StatConfig config = new StatConfig(Instance, "ComboStat");

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
            get => config.getConfigEntry<float>("size") ?? 40;
            set => config.setConfigEntry("size", value);
        }
        public override bool enabled
        {
            get => config.getConfigEntry<bool>("enabled") ?? false;
            set => config.setConfigEntry("enabled", value);
        }
        public override Color color { 
            get => config.getConfigEntry<Color>("color") ?? Color.white; 
            set => config.setConfigEntry("color", value); 
        }
    
        public static ComboStat Instance { get; } = new ComboStat();

        protected override void CreateStat()
        {
            if (_comboController == null) return;
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

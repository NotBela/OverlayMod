using OverlayMod.Configuration;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class ComboStat : Stat, IDisposable
    {
        [Inject] private readonly ComboController _comboController;

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

        public bool showComboLines
        {
            get => config.getConfigEntry<bool>("showComboLines") ?? true;
            set => config.setConfigEntry("showComboLines", value);
        }


        private GameObject upperComboLineObj = new GameObject();
        private GameObject lowerComboLineObj = new GameObject();

    
        public static ComboStat Instance { get; } = new ComboStat();

        protected override void CreateStat()
        {
            _comboController.comboDidChangeEvent += UpdateText;
            _comboController.comboBreakingEventHappenedEvent += OnComboBroken;

            setTextParams("0");

            upperComboLineObj.SetActive(enabled && showComboLines);
            lowerComboLineObj.SetActive(enabled && showComboLines);

            upperComboLineObj.AddComponent<Image>();
            upperComboLineObj.transform.parent = this._canvasController.canvas.transform;
            upperComboLineObj.GetComponent<RectTransform>().sizeDelta = new Vector2(size * 1.5f, 5 * (size / 40));
            upperComboLineObj.GetComponent<RectTransform>().localPosition = new Vector2(text.bounds.center.x, text.bounds.center.y + (size / 2) + 6);

            lowerComboLineObj.AddComponent<Image>();
            lowerComboLineObj.transform.parent = this._canvasController.canvas.transform;
            lowerComboLineObj.GetComponent<RectTransform>().sizeDelta = new Vector2(size * 1.5f, 5 * (size / 40));
            lowerComboLineObj.GetComponent<RectTransform>().localPosition = new Vector2(text.bounds.center.x, text.bounds.center.y - (size / 2));

        }

        private void OnComboBroken()
        {
            upperComboLineObj.SetActive(false);
            lowerComboLineObj.SetActive(false);
        }

        private void UpdateText(int combo)
        {
            this.text.text = $"{combo}";

            upperComboLineObj.GetComponent<RectTransform>().sizeDelta = new Vector2(Math.Max(size * 1.5f, text.maxWidth * 1.5f), 5 * (size / 40));
            lowerComboLineObj.GetComponent<RectTransform>().sizeDelta = new Vector2(Math.Max(size * 1.5f, text.maxWidth * 1.5f), 5 * (size / 40));
        }

        public void Dispose()
        {
            _comboController.comboDidChangeEvent -= UpdateText;
        }
    }
}

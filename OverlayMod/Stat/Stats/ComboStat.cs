using OverlayMod.Configuration;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class ComboStat : Stat, IDisposable
    {
        [Inject] private readonly ComboController _comboController;

        protected override StatConfig config { get; } = new StatConfig(Instance, "ComboStat");

        public override int defaultPosX => Screen.width / 2;
        public override int defaultPosY => Screen.height / 2;
        public override float defaultSize => 40;
        public override bool defaultEnabled => false;
        public override Color defaultColor => Color.white;

        public bool showComboLines
        {
            get => config.getConfigEntry<bool>("showComboLines") ?? true;
            set => config.setConfigEntry("showComboLines", value);
        }
        public bool animateText
        {
            get => config.getConfigEntry<bool>("animateText") ?? true;
            set => config.setConfigEntry("animateText", value);
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
            upperComboLineObj.GetComponent<RectTransform>().localPosition = new Vector2(text.bounds.center.x, text.bounds.center.y + (size / 2) + (4 * (size / 40f)));

            lowerComboLineObj.AddComponent<Image>();
            lowerComboLineObj.transform.parent = this._canvasController.canvas.transform;
            lowerComboLineObj.GetComponent<RectTransform>().sizeDelta = new Vector2(size * 1.5f, 5 * (size / 40));
            lowerComboLineObj.GetComponent<RectTransform>().localPosition = new Vector2(text.bounds.center.x, text.bounds.center.y - (size / 2) + (2 * (size / 40f)));
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

            // if (animateText)
            // {
            //     var task = new Task(doTextAnimation);
            //     await Task.Run(() => task);
            // }
        }

        private void doTextAnimation() // unused because very laggy and breaks combo after like 50 notes
        {
            text.fontSize = size * 1.2f;

            while (text.fontSize > size)
            {
                text.fontSize -= .02f * (size / 40.0f);
            }
        }

        public void Dispose()
        {
            _comboController.comboDidChangeEvent -= UpdateText;
        }
    }
}

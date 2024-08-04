/*
using OverlayMod.Configuration;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class EnergyStat : Stat, IDisposable
    {
        private GameObject barObject;
        private Image bar;

        private GameObject backgroundObject;
        private Image background;

        public StatConfig config = new StatConfig(Instance, "EnergyStat");

        public override int posX
        {
            get => config.getConfigEntry<int>("posX") ?? 300;
            set => config.setConfigEntry("posX", value);
        }
        public override int posY
        {
            get => config.getConfigEntry<int>("posY") ?? 1000;
            set => config.setConfigEntry("posY", value);
        }
        public override float size
        {
            get => config.getConfigEntry<float>("size") ?? 1;
            set => config.setConfigEntry("size", value);
        }
        public override bool enabled
        {
            get => config.getConfigEntry<bool>("enabled") ?? false;
            set => config.setConfigEntry("enabled", value);
        }
        public bool changeBarColorOnLowEnergy
        {
            get => config.getConfigEntry<bool>("changeBarColorOnLowEnergy") ?? false;
            set => config.setConfigEntry("changeBarColorOnLowEnergy", value);
        }

        public override Color color
        {
            get => config.getConfigEntry<Color>("color") ?? Color.white;
            set => config.setConfigEntry("color", value);
        }

        public static EnergyStat Instance = new EnergyStat();

        private int maxEnergySize = 300;
        private int height = 10;

        [Inject] private readonly GameEnergyCounter _energyCounter;

        protected override void CreateStat()
        {
            _energyCounter.gameEnergyDidChangeEvent += Update;
            base.text.color = color;
        }

        public void Dispose()
        {
            _energyCounter.gameEnergyDidChangeEvent -= Update;
        }

        private void Update(float energyPercentage)
        {
            var transform = barObject.GetComponent<RectTransform>();

            transform.sizeDelta = new Vector2(energyPercentage * maxEnergySize - 4, height - 4);
            transform.localPosition = new Vector2(this.getNormalizedPosition(posX, posY).x - ((maxEnergySize - (energyPercentage * maxEnergySize)) * (size * Plugin.scaleX) / 2), this.getNormalizedPosition(posX, posY).y);

            if (energyPercentage < .15 && changeBarColorOnLowEnergy)
                bar.color = Color.red;
            else
                bar.color = color;
        }

        protected override void setTextParams(string defaultText)
        {
            if (!enabled) return;

            barObject = new GameObject();
            barObject.transform.parent = this._canvasController.canvasGameObj.transform;
            bar = barObject.AddComponent<Image>();

            backgroundObject = new GameObject();
            backgroundObject.transform.parent = this._canvasController.canvasGameObj.transform;
            background = backgroundObject.AddComponent<Image>();

            this.barObject.transform.localScale = new Vector3(size * Plugin.scaleX, size * Plugin.scaleY);
            this.backgroundObject.transform.localScale = new Vector3(size * Plugin.scaleX, size * Plugin.scaleY);

            var backgroundTransform = backgroundObject.GetComponent<RectTransform>();

            backgroundTransform.localPosition = this.getNormalizedPosition(posX, posY);
            backgroundTransform.sizeDelta = new Vector2(maxEnergySize, height);

            background.color = new Color(1, 1, 1, 0.01f);
        }

        // unused code for your pfp beside the energy counter kind of like osu
        // maybe some day...
        /*
        private void getAndDrawPfp()
        {
            var pfpObject = new GameObject();
            pfpObject.transform.parent = this._canvasController.canvasGameObj.transform;
            var pfpImage = pfpObject.AddComponent<Image>();
            var pfpTransform = pfpObject.GetComponent<RectTransform>();
            pfpTransform.localPosition = this.getNormalizedPosition(posX - (maxEnergySize / 2), posY);
            // WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
            // yield return frameEnd;
            Texture2D playerPfp = BS_Utils.Gameplay.GetUserInfo.GetUserAvatar();
            var rect = new Rect(0, 0, playerPfp.width, playerPfp.height);
            pfpImage.sprite = Sprite.Create(playerPfp, rect, Vector2.zero);
        }
        
    }
}
*/
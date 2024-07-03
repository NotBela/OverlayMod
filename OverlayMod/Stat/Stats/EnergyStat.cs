using BeatSaberMarkupLanguage;
using Newtonsoft.Json.Linq;
using OverlayMod.Configuration;
using System;
using System.Collections;
using System.Net.Http;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class EnergyStat : IStat, IDisposable
    {
        public override StatTypes enumType => StatTypes.EnergyStat;

        private GameObject barObject;
        private Image bar;

        private GameObject backgroundObject;
        private Image background;

        public override int posX
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posX") ?? 300;
            set => StatConfig.setConfigEntry(enumType, "posX", value);
        }
        public override int posY
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posY") ?? 1000;
            set => StatConfig.setConfigEntry(enumType, "posY", value);
        }
        public override float size
        {
            get => StatConfig.getConfigEntry<float>(enumType, "size") ?? 1;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override bool enabled
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? false;
            set => StatConfig.setConfigEntry(enumType, "enabled", value);
        }
        public bool changeBarColorOnLowEnergy
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "changeBarColorOnLowEnergy") ?? false;
            set => StatConfig.setConfigEntry(enumType, "changeBarColorOnLowEnergy", value);
        }

        public static EnergyStat Instance = new EnergyStat();

        private int maxEnergySize = 300;
        private int height = 10;

        [Inject] private readonly GameEnergyCounter _energyCounter;

        protected override void CreateStat()
        {
            _energyCounter.gameEnergyDidChangeEvent += Update;
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
                bar.color = Color.white;
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
        */
    }
}
using OverlayMod.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;
using System.Runtime.CompilerServices;
using System.CodeDom;
using System.Diagnostics.PerformanceData;
using JetBrains.Annotations;

namespace OverlayMod.Stat.Stats
{
    internal abstract class IStat
    {
        public TextMeshProUGUI text;
        public GameObject textObject;

        public enum StatTypes
        {
            PercentStat,
            ComboStat,
            ScoreStat,
            MissStat
        }

        public abstract StatTypes enumType { get; }

        public bool enabled;
        public Vector2 position;
        public int size;

        public Vector2 defaultPosition { get; protected set; }
        public int defaultSize { get; protected set; }
        public bool defaultEnabled { get; protected set; }


        public readonly CanvasController _canvasController;

        public IStat(CanvasController _canvasController)
        {
            this._canvasController = _canvasController;

            textObject = new GameObject();

            textObject.transform.parent = _canvasController.canvasGameObj.transform;
            text = textObject.AddComponent<TextMeshProUGUI>();
        }

        protected void setTextParams()
        {
            this.enabled = StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? defaultEnabled;
            this.textObject.SetActive(this.enabled);
            this.text.fontSize = StatConfig.getConfigEntry<int>(enumType, "size") ?? defaultSize;
            this.text.alignment = TextAlignmentOptions.Center;

            float textPosX = (-Screen.width / 2) + (StatConfig.getConfigEntry<float>(enumType, "posX") ?? defaultPosition.x);
            float textPosY = (-Screen.height / 2) + (StatConfig.getConfigEntry<float>(enumType, "posY") ?? defaultPosition.y);

            this.textObject.transform.localPosition = new Vector2(textPosX, textPosY);
        }
    }
}

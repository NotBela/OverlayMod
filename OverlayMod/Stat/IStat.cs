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
    internal abstract class IStat : IInitializable
    {
        protected CanvasController _canvasController;

        protected TextMeshProUGUI text;
        protected GameObject textObject;

        public enum StatTypes
        {
            PercentStat,
            ComboStat,
            ScoreStat,
            MissStat
        }

        public abstract StatTypes enumType { get; }

        public abstract int posX { get; set; }
        public abstract int posY { get; set; }
        public abstract int size { get; set; }
        public abstract bool enabled { get; set; }
        public virtual TextAlignmentOptions? optionalAllignmentOverride { get; }

        [Inject]
        public void Inject(CanvasController canvasController)
        {
            this._canvasController = canvasController;
        }

        public virtual void Initialize()
        {
            textObject = new GameObject();
            textObject.transform.parent = _canvasController.canvasGameObj.transform;
            text = textObject.AddComponent<TextMeshProUGUI>();
        }

        protected void setTextParams(string defaultText)
        {
            this.text.text = defaultText;

            this.textObject.SetActive(enabled);
            this.text.fontSize = size * ((Plugin.scaleX + Plugin.scaleY) / 2); // last part averages the difference in text size incase the display ratio isnt 16:9
            this.text.alignment = optionalAllignmentOverride ?? TextAlignmentOptions.Center;

            float textPosX = (-Screen.width / 2) + (posX * Plugin.scaleX);
            float textPosY = (-Screen.height / 2) + (posY * Plugin.scaleY);

            this.textObject.transform.localPosition = new Vector2(textPosX, textPosY);
        }
    }
}

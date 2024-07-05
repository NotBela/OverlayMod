﻿using OverlayMod.Configuration;
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

        public TextMeshProUGUI text;
        public GameObject textObject;

        public enum StatTypes
        {
            PercentStat,
            ComboStat,
            ScoreStat,
            MissStat,
            EnergyStat,
            RankStat
        }

        public abstract StatTypes enumType { get; }

        public abstract int posX { get; set; }
        public abstract int posY { get; set; }
        public abstract float size { get; set; }
        public abstract bool enabled { get; set; }
        public virtual TextAlignmentOptions? optionalAllignmentOverride { get; }

        [Inject]
        public void Construct(CanvasController canvasController)
        {
            this._canvasController = canvasController;
        }

        public void Initialize()
        {
            textObject = new GameObject();
            textObject.transform.parent = _canvasController.canvasGameObj.transform;
            text = textObject.AddComponent<TextMeshProUGUI>();

            CreateStat();
        }

        protected abstract void CreateStat();

        protected virtual void setTextParams(string defaultText)
        {
            this.text.text = defaultText;

            this.textObject.SetActive(enabled);
            this.text.fontSize = size * ((Plugin.scaleX + Plugin.scaleY) / 2); // last part averages the difference in text size incase the display ratio isnt 16:9
            this.text.alignment = optionalAllignmentOverride ?? TextAlignmentOptions.Center;

            this.textObject.transform.localPosition = getNormalizedPosition(posX, posY);
        }

        protected Vector2 getNormalizedPosition(float posX, float posY)
        {
            float textPosX = (-Screen.width / 2) + (posX * Plugin.scaleX);
            float textPosY = (-Screen.height / 2) + (posY * Plugin.scaleY);

            return new Vector2(textPosX, textPosY);
        }
    }
}

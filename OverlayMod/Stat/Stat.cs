using OverlayMod.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal abstract class Stat : IInitializable
    {
        protected CanvasController _canvasController;

        protected TextMeshProUGUI text;
        protected GameObject textObject;

        public abstract int posX { get; set; }
        public abstract int posY { get; set; }
        public abstract float size { get; set; }
        public abstract bool enabled { get; set; }


        public abstract Color color { get; set; }
        

        public CultureInfo decimalFormat
        {
            get
            {
                if (PluginConfig.Instance.prefDecimalFormatting == PluginConfig.decimalFormat.Reigonal)
                    return CultureInfo.CurrentCulture;
                return CultureInfo.InvariantCulture;
            }
        }

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
            this.text.enableWordWrapping = false;
            this.text.color = color;

            this.textObject.GetComponent<RectTransform>().localPosition = getNormalizedPosition(posX, posY);
        }

        public Vector2 getNormalizedPosition(float posX, float posY)
        {
            float textPosX = (-Screen.width / 2) + (posX * Plugin.scaleX);
            float textPosY = (-Screen.height / 2) + (posY * Plugin.scaleY);

            return new Vector2(textPosX, textPosY);
        }
    }
}

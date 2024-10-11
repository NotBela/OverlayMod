using OverlayMod.Configuration;
using System.Globalization;
using TMPro;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal abstract class Stat : IInitializable
    {
        protected CanvasController _canvasController;

        protected TextMeshProUGUI text;
        protected GameObject textObject;

        protected abstract StatConfig config { get; }

        public abstract int defaultPosX { get; }
        public abstract int defaultPosY { get; }
        public abstract float defaultSize { get; }
        public abstract bool defaultEnabled { get; }
        public abstract Color defaultColor { get; }

        public int posX
        {
            get => config.getConfigEntry<int>("posX") ?? defaultPosX;
            set => config.setConfigEntry("posX", value);
        }
        public int posY
        {
            get => config.getConfigEntry<int>("posY") ?? defaultPosY;
            set => config.setConfigEntry("posX", value);
        }
        public float size
        {
            get => config.getConfigEntry<float>("size") ?? defaultSize;
            set => config.setConfigEntry("size", value);
        }
        public bool enabled
        {
            get => config.getConfigEntry<bool>("enabled") ?? defaultEnabled;
            set => config.setConfigEntry("enabled", value);
        }

        public Color color
        {
            get => config.getConfigEntry<Color>("color") ?? defaultColor;
            set => config.setConfigEntry("color", value);
        }

        public CultureInfo decimalFormat
        {
            get
            {
                if (PluginConfig.Instance.prefDecimalFormatting == PluginConfig.decimalFormat.Reigonal)
                    return CultureInfo.CurrentCulture;
                return CultureInfo.InvariantCulture;
            }
        }

        public virtual TextAlignmentOptions optionalAllignmentOverride { get; } = TextAlignmentOptions.Center;

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
            this.text.alignment = optionalAllignmentOverride;
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

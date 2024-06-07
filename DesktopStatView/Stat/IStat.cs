using DesktopStatView.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace DesktopStatView.Stat.Stats
{
    internal abstract class IStat
    {
        [JsonIgnore] public TextMeshProUGUI text;
        public bool enabled;
        [JsonIgnore] public GameObject textObject;
        [JsonIgnore] public string counterName;
        [JsonIgnore] public StatConfig config;
        public Vector2 position;
        public int size;

        [JsonIgnore] internal Vector2 defaultPosition;
        [JsonIgnore] internal int defaultSize;

        public readonly CanvasController _canvasController;

        public IStat(CanvasController _canvasController)
        {
            this._canvasController = _canvasController;

            config = new StatConfig(this);

            textObject = new GameObject();

            textObject.transform.parent = _canvasController.canvasGameObj.transform;
            text = textObject.AddComponent<TextMeshProUGUI>();
        }

        internal void setTextParams()
        {
            // using ?? operator doesnt work apparently
            // this sucks
            bool? configEnabled = config.getConfigEntry<bool>("enabled");
            Vector2? configPosition = config.getConfigEntry<Vector2>("position");
            int? configSize = config.getConfigEntry<int>("size");

            if (configEnabled == null)
                enabled = true;
            else
                enabled = configEnabled.Value;

            if (configPosition == null)
                position = defaultPosition;
            else
                position = configPosition.Value;

            if (configSize == null)
                size = defaultSize;
            else
                size = configSize.Value;

            this.textObject.transform.localPosition = position;
            this.text.fontSize = size;
        }
    }
}

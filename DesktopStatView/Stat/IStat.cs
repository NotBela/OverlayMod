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

namespace OverlayMod.Stat.Stats
{
    internal abstract class IStat
    {
        public TextMeshProUGUI text;
        public GameObject textObject;

        public bool enabled;
        public Vector2 position;
        public int size;

        public static Vector2 defaultPosition { get; internal set; }
        public static int defaultSize { get; protected set; }
        public static bool defaultEnabled { get; protected set; }


        public readonly CanvasController _canvasController;

        public IStat(CanvasController _canvasController)
        {
            this._canvasController = _canvasController;

            textObject = new GameObject();

            textObject.transform.parent = _canvasController.canvasGameObj.transform;
            text = textObject.AddComponent<TextMeshProUGUI>();
        }

        internal void setTextParams()
        {
            // using ?? operator doesnt work apparently
            // this sucks
            // bool? configEnabled = // implement when config done
            // Vector2? configPosition = // implement when config done
            // int? configSize = // implement when config done
            /*
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
            */
        }
    }
}

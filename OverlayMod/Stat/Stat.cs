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
    internal abstract class Stat : IInitializable, IDisposable
    {
        public Vector2 position;
        public TextMeshProUGUI text;
        public bool enabled;
        public GameObject textObject;

        public static OverlayModCanvasController controller = new OverlayModCanvasController();

        public Stat()
        {
            textObject = new GameObject();

            textObject.transform.parent = controller.canvasObject.transform;

            text = textObject.AddComponent<TextMeshProUGUI>();

            enabled = true;

            RectTransform rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
            rectTransform.sizeDelta = position;
        }

        public void Initialize()
        {
            controller = new OverlayModCanvasController();
        }

        public void Dispose()
        {
            controller = null;
        }
    }
}

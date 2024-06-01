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
    internal abstract class Stat
    {
        public Vector2 position;
        public TextMeshProUGUI text;
        public bool enabled;
        public GameObject textObject;
        public GameObject canvasObject;
        public Canvas canvas;

        public Stat()
        {
            canvasObject = new GameObject();
            textObject = new GameObject();
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            textObject.transform.parent = canvasObject.transform;

            text = textObject.AddComponent<TextMeshProUGUI>();

            enabled = true;
            position = new Vector2(200, 400);

            RectTransform rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.localPosition = position;
        }
    }
}

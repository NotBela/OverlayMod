using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DesktopStatView
{
    internal class StatController : IInitializable
    {
        private GameObject gameObject;
        private Canvas canvas;

        private TextMeshProUGUI text;

        public void Initialize()
        {
            Plugin.Log.Info("hi");
        }

        public StatController()
        {
            gameObject = new GameObject();

            canvas = gameObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            var myText = new GameObject();
            myText.transform.parent = gameObject.transform;
            text = myText.AddComponent<TextMeshProUGUI>();
            text.text = "hi";
            text.fontSize = 40;

            RectTransform textTransform = myText.GetComponent<RectTransform>();
            textTransform.localPosition = Vector3.zero;
            textTransform.sizeDelta = new Vector2(800, 200);
        }
    }
}

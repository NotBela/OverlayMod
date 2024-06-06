using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DesktopStatView.Stat
{
    internal class DesktopStatViewCanvasController : IInitializable
    {
        public Canvas canvas;
        public GameObject canvasObject;

        public DesktopStatViewCanvasController()
        {
            canvasObject = new GameObject();
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvas.name = "DesktopStatViewCanvas";
        }

        public void Initialize()
        {
            Plugin.Log.Info("THIS IS NORMAL!!!!");
        }
    }
}

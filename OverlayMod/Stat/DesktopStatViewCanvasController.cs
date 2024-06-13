using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat
{
    internal class OverlayModCanvasController : IInitializable
    {
        public Canvas canvas;
        public GameObject canvasObject;

        public OverlayModCanvasController()
        {
            canvasObject = new GameObject();
            canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvas.name = "OverlayModCanvas";
        }

        public void Initialize()
        {
            Plugin.Log.Info("THIS IS NORMAL!!!!");
        }
    }
}

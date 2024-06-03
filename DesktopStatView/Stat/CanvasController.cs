using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DesktopStatView.Stat
{
    internal class CanvasController : IInitializable
    {
        public GameObject canvasGameObj;
        public Canvas canvas;

        public CanvasController()
        {
            canvasGameObj = new GameObject();
            canvas = canvasGameObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        public void Initialize()
        {
            Plugin.Log.Info("hi");
        }
    }
}

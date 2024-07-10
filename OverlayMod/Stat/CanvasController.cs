using OverlayMod.Configuration;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat
{
    internal class CanvasController : IInitializable
    {
        public GameObject canvasGameObj;
        public Canvas canvas;

        public void Initialize()
        {
            canvasGameObj = new GameObject();
            canvas = canvasGameObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvas.name = "OverlayMod";

            canvasGameObj.SetActive(PluginConfig.Instance.globalEnable);

            canvas.transform.SetAsLastSibling();
            canvasGameObj.transform.SetAsLastSibling();
        }
    }
}

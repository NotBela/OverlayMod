using OverlayMod.Configuration;
using OverlayMod.Stat.Preview;
using OverlayMod.Stat.Preview.PreviewStats;
using OverlayMod.Stat.Stats;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat
{
    internal class CanvasController : IInitializable
    {
        public GameObject canvasGameObj;
        public Canvas canvas;

        [InjectOptional] private readonly GameplayModifiers _gameplayModifiers;

        public virtual void Initialize()
        {
            canvasGameObj = new GameObject();
            canvas = canvasGameObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvas.name = "OverlayMod";

            canvasGameObj.SetActive(PluginConfig.Instance.globalEnable);

            canvas.overrideSorting = true;
            canvas.sortingOrder = 1;

            if (_gameplayModifiers != null && PluginConfig.Instance.zenModeDisable && _gameplayModifiers.zenMode) 
                canvasGameObj.SetActive(false);
        }
    }
}
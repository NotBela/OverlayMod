using OverlayMod.Configuration;
using OverlayMod.Stat.Preview;
using OverlayMod.Stat.Preview.PreviewStats;
using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat
{
    internal class CanvasController : IInitializable
    {
        public GameObject canvasGameObj;
        public Canvas canvas;

        public virtual bool isPreview { get; } = false;

        [InjectOptional] private readonly GameplayModifiers _gameplayModifiers;

        public void Initialize()
        {
            canvasGameObj = new GameObject();
            canvas = canvasGameObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvas.name = "OverlayMod";

            canvasGameObj.SetActive(PluginConfig.Instance.globalEnable);

            canvas.overrideSorting = true;
            canvas.sortingOrder = 1;

            if (isPreview)
                canvasGameObj.SetActive(false);
            else
                canvasGameObj.SetActive(PluginConfig.Instance.globalEnable);

            if (!PluginConfig.Instance.zenModeDisable) return;

            if (_gameplayModifiers != null && _gameplayModifiers.zenMode) canvasGameObj.SetActive(false);
        }
    }
}
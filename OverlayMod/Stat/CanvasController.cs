﻿using OverlayMod.Configuration;
using System;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat
{
    internal class CanvasController : IInitializable
    {
        public GameObject canvasGameObj;
        public Canvas canvas;

        public virtual bool isPreview { get; } = false;

        public void Initialize()
        {
            canvasGameObj = new GameObject();
            canvas = canvasGameObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            canvas.name = "OverlayMod";

            canvasGameObj.SetActive(PluginConfig.Instance.globalEnable);

            canvas.transform.SetAsLastSibling();
            canvasGameObj.transform.SetAsLastSibling();

            if (isPreview)
                canvasGameObj.SetActive(false);
            else
                canvasGameObj.SetActive(PluginConfig.Instance.globalEnable);
        }
    }
}
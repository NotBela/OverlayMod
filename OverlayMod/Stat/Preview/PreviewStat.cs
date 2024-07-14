using OverlayMod.Stat.Stats;
using OverlayMod.Views.ViewControllers.CenterScreen;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Preview
{
    internal abstract class PreviewStat : IInitializable
    {
        [Inject] private PreviewCanvasController _canvasController;

        protected abstract Stats.Stat parentStat { get; }

        protected bool enabled => parentStat.enabled;
        protected int posX => parentStat.posX;
        protected int posY => parentStat.posY;
        protected float size => parentStat.size;
        protected Color color => parentStat.color;

        private GameObject textObject = new GameObject();
        protected TextMeshProUGUI textMesh;

        protected abstract string text { get; }

        public void Initialize()
        {
            textObject = new GameObject();
            textObject.transform.parent = _canvasController.canvasGameObj.transform;
            textMesh = textObject.AddComponent<TextMeshProUGUI>();

            this.textMesh.text = text;

            // bottom two lines not necessary because of update()

            // this.textObject.SetActive(enabled);
            // this.textMesh.fontSize = size * ((Plugin.scaleX + Plugin.scaleY) / 2); // last part averages the difference in text size incase the display ratio isnt 16:9
            this.textMesh.alignment = parentStat.optionalAllignmentOverride ?? TextAlignmentOptions.Center;
            this.textMesh.enableWordWrapping = false;
            Update();

            doExtraThings();
        }

        protected virtual void doExtraThings() { return; }

        #region notifypropertychanged garbage
        public virtual void Update()
        {
            this.textMesh.text = text;
            this.textMesh.fontSize = size * ((Plugin.scaleX + Plugin.scaleY) / 2);

            var normalPos = parentStat.getNormalizedPosition(posX, posY);
            normalPos.x -= 50;

            this.textObject.transform.localPosition = normalPos;
            this.textObject.SetActive(enabled);
            this.textMesh.color = color;
        }
        #endregion
    }
}

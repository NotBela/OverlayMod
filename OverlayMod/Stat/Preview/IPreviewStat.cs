using OverlayMod.Stat.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMPro;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Preview
{
    internal abstract class IPreviewStat : IInitializable
    {
        [Inject] private PreviewCanvasController _canvasController;
 
        protected abstract IStat parentStat { get; }

        protected bool enabled => parentStat.enabled;
        protected int posX => parentStat.posX;
        protected int posY => parentStat.posY;
        protected float size => parentStat.size;

        private GameObject textObject = new GameObject();
        private TextMeshProUGUI textMesh;

        protected abstract string text { get; }

        public void Initialize()
        {
            textObject = new GameObject();
            textObject.transform.parent = _canvasController.canvasGameObj.transform;
            textMesh = textObject.AddComponent<TextMeshProUGUI>();

            this.textMesh.text = text;
            this.textMesh.fontSize = size * ((Plugin.scaleX + Plugin.scaleY) / 2);
            this.textObject.transform.localPosition = parentStat.getNormalizedPosition(posX, posY);
            this.textObject.SetActive(enabled);
            this.textMesh.alignment = parentStat.optionalAllignmentOverride ?? TextAlignmentOptions.Center;

            this.textObject.GetComponent<RectTransform>().sizeDelta = new Vector2(posX + size, posY);
        }
    }
}

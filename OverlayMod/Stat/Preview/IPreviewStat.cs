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
    internal abstract class IPreviewStat : IInitializable, INotifyPropertyChanged
    {
        [Inject] private PreviewCanvasController _canvasController;

        protected abstract IStat parentStat { get; }

        protected bool enabled => parentStat.enabled;
        protected int posX => parentStat.posX;
        protected int posY => parentStat.posY;
        protected float size => parentStat.size;

        private GameObject textObject = new GameObject();
        protected TextMeshProUGUI textMesh;

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

            doExtraThings();
        }

        protected virtual void doExtraThings() { return; }

        #region notifypropertychanged garbage

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void notifyPropertyChanged()
        {
            foreach (var property in this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance))
            {
                NotifyPropertyChanged(property.Name);
            }
        }

        #endregion
    }
}

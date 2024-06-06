using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace DesktopStatView.Stat.Stats
{
    internal abstract class IStat
    {
        public TextMeshProUGUI text;
        public bool enabled;
        public GameObject textObject;

        public readonly CanvasController _canvasController;

        public IStat(CanvasController _canvasController)
        {
            this._canvasController = _canvasController;

            textObject = new GameObject();

            textObject.transform.parent = _canvasController.canvasGameObj.transform;
            text = textObject.AddComponent<TextMeshProUGUI>();

            enabled = true;
        }
    }
}

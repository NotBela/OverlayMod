using OverlayMod.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class ComboStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly ComboController _comboController;

        public override StatTypes enumType { get => StatTypes.ComboStat; }

        public ComboStat(CanvasController controller) : base(controller)
        {

            this.text.text = "0";
            defaultSize = 60;
            defaultPosition = new Vector2(-500, -300);
            defaultEnabled = false;

            this.textObject.transform.localPosition = position;
            this.text.fontSize = size;

            setTextParams();

        }

        public void Initialize()
        {
            _comboController.comboDidChangeEvent += Update;
        }

        private void Update(int combo)
        {
            this.text.text = $"{combo}";
        }

        public void Dispose()
        {
            _comboController.comboDidChangeEvent -= Update;
        }
    }
}

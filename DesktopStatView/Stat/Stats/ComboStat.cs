using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DesktopStatView.Stat.Stats
{
    internal class ComboStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly ComboController _comboController;

        public ComboStat(CanvasController controller) : base(controller) 
        {
            this.text.text = "0";
            this.text.fontSize = 60;
            this.textObject.transform.localPosition = new Vector2(-500, -300);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;

namespace DesktopStatView.Stat.Stats
{
    internal class PercentStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly ScoreController _scoreController;

        public PercentStat(CanvasController controller) : base(controller) 
        {
            this.text.fontSize = 120;
            this.text.text = "100.00";
            this.textObject.transform.localPosition = new Vector2(-350, -300);

            textObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 200);
        }

        public void Initialize()
        {
            _scoreController.scoreDidChangeEvent += Update;
        }

        private void Update(int changedScore, int modifierScore)
        {
            
            if (changedScore == 0f || modifierScore == 0f || _scoreController.immediateMaxPossibleModifiedScore == 0f) return;
            float percent = ((float) modifierScore / _scoreController.immediateMaxPossibleModifiedScore) * 100;

            this.text.text = $"{percent.ToString("0.00")}";
        }

        public void Dispose()
        {
            _scoreController.scoreDidChangeEvent -= Update;
        }
    }
}

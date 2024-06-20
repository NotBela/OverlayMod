using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using OverlayMod.Configuration;

namespace OverlayMod.Stat.Stats
{
    internal class PercentStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly RelativeScoreAndImmediateRankCounter _relativeScoreCounter;
        [Inject] private readonly ScoreController _scoreController;

        public override StatTypes enumType => StatTypes.PercentStat;

        public PercentStat(CanvasController controller) : base(controller)
        {

            defaultSize = 70;
            text.text = "100.00";
            defaultPosition = new Vector2(250, 150);
            defaultEnabled = true;

            textObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 200);

            setTextParams();
        }

        public void Initialize()
        {
            _relativeScoreCounter.relativeScoreOrImmediateRankDidChangeEvent += updateText;
        }

        private void updateText()
        {
            float percent = ((float) _scoreController.modifiedScore / _scoreController.immediateMaxPossibleModifiedScore) * 100;

            // really fucking dumb fix
            if (percent.ToString() == "NaN")
            {
                this.text.text = "100.00";
                return;
            }

            this.text.text = $"{percent.ToString("0.00")}";
        }

        public void Dispose()
        {
            _relativeScoreCounter.relativeScoreOrImmediateRankDidChangeEvent -= updateText;
        }
    }
}

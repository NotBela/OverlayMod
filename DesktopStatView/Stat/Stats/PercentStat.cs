﻿using System;
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
        [Inject] private readonly RelativeScoreAndImmediateRankCounter _relativeScoreCounter;
        [Inject] private readonly ScoreController _scoreController;

        public PercentStat(CanvasController controller) : base(controller) 
        {
            this.text.fontSize = 80;
            this.text.text = "100.00";
            this.textObject.transform.localPosition = new Vector2(-700, -450);

            textObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 200);
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
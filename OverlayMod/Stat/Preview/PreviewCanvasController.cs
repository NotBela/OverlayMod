using OverlayMod.Configuration;
using OverlayMod.Stat.Preview.PreviewStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Preview
{
    internal class PreviewCanvasController : CanvasController
    {
        public override bool isPreview => true;

        [Inject] private readonly ComboStatPreview _previewCombo;
        [Inject] private readonly MissStatPreview _missStatPreview;
        [Inject] private readonly PercentStatPreview _percentStatPreview;
        [Inject] private readonly RankStatPreview _rankStatPreview;
        [Inject] private readonly ScoreStatPreview _scoreStatPreview;

        public void updateStats()
        {
            _previewCombo.Update();
            _missStatPreview.Update();
            _percentStatPreview.Update();
            _scoreStatPreview.Update();
            _rankStatPreview.Update();
        }
    }
}

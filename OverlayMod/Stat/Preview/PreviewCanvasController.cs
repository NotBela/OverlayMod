using OverlayMod.Configuration;
using OverlayMod.Stat.Preview.PreviewStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OverlayMod.Stat.Preview
{
    internal class PreviewCanvasController : CanvasController
    {
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

        public override void Initialize()
        {
            base.Initialize();

            canvasGameObj.SetActive(false); // sets false in menu
        }
    }
}

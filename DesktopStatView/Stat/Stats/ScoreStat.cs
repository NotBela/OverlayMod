using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace DesktopStatView.Stat.Stats
{
    internal class ScoreStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly ScoreController _scoreController;

        public ScoreStat(CanvasController controller) : base(controller)
        {
            this.text.text = "0";
            this.text.fontSize = 60;
            this.textObject.transform.localPosition = new Vector2(-350, -300);
        }

        public void Initialize()
        {
            _scoreController.scoreDidChangeEvent += Update;
        }

        private void Update(int scoreMultiplied, int scoreWithMods)
        {
            this.text.text = scoreWithMods.ToString();
        }

        public void Dispose()
        {
            _scoreController.scoreDidChangeEvent -= Update;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using TMPro;
using BS_Utils.Utilities;

namespace DesktopStatView.Stat.Stats
{
    internal class TestStat : Stat, IInitializable, IDisposable
    {
        [Inject] private readonly BeatmapObjectManager _beatmapObjectManager;

        private int missedAmt;

        public TestStat() 
        {
            missedAmt = 0;

            this.text.text = $"{missedAmt}";
            this.text.fontSize = 60;
            this.position = new Vector2(0, 0);
        }

        public void Initialize()
        {
            _beatmapObjectManager.noteWasMissedEvent += Update;
        }

        public void Dispose()
        {
            _beatmapObjectManager.noteWasMissedEvent -= Update;
        }

        private void Update(NoteController controller)
        {
            missedAmt++;
            this.text.text = $"{missedAmt}";
        }
    }
}

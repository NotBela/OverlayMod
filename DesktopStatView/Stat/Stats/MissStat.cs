using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using TMPro;
using BS_Utils.Utilities;
using System.Runtime.CompilerServices;

namespace DesktopStatView.Stat.Stats
{
    internal class MissStat : Stat, IInitializable, IDisposable
    {
        [Inject] private readonly BeatmapObjectManager _beatmapObjectManager;

        private int missedAmt;

        public MissStat(CanvasController canvasController) : base(canvasController)
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
            if (controller.name == "BombNote(Clone)") return;

            missedAmt++;
            this.text.text = $"{missedAmt}";
        }
    }
}

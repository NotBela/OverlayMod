using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

namespace DesktopStatView.Stat.Stats
{
    internal class MissStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly BeatmapObjectManager _beatmapObjectManager;

        private int missedAmt;

        public MissStat(CanvasController canvasController) : base(canvasController)
        {
            this.counterName = "Miss";

            missedAmt = 0;

            this.text.text = $"{missedAmt}";
            this.defaultSize = 60;
            this.defaultPosition = new Vector2(100, 0);

            this.textObject.transform.localPosition = position;
            this.text.fontSize = size;

            setTextParams();
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

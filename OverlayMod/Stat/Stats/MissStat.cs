using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using OverlayMod.Configuration;

namespace OverlayMod.Stat.Stats
{
    internal class MissStat : IStat, IInitializable, IDisposable
    {
        [Inject] private readonly BeatmapObjectManager _beatmapObjectManager;

        private int missedAmt;

        public override StatTypes enumType => StatTypes.MissStat;

        public MissStat(CanvasController canvasController) : base(canvasController)
        {

            missedAmt = 0;

            this.text.text = $"{missedAmt}";
            defaultSize = 60;
            defaultPosition = new Vector2(100, 0);
            defaultEnabled = true;

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

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
        public bool hideUntilMissed
        {
            get => StatConfig.getConfigEntry<bool>(this.enumType, "hideWhileFc") ?? true;
        }

        public bool redMissCounter
        {
            get => StatConfig.getConfigEntry<bool>(this.enumType, "redMissText") ?? true;
        }

        public override StatTypes enumType => StatTypes.MissStat;

        public MissStat(CanvasController canvasController) : base(canvasController)
        {

            missedAmt = 0;

            this.text.text = $"x{missedAmt}";

            if (redMissCounter) this.text.color = Color.red;

            defaultSize = 40;
            defaultPosition = new Vector2(400, 100);
            defaultEnabled = true;

            this.textObject.transform.localPosition = position;
            this.text.fontSize = size;

            setTextParams();

            if (hideUntilMissed)
                this.textObject.SetActive(false);
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
            this.textObject.SetActive(this.enabled);
            Plugin.Log.Info($"{this.enabled}");
            if (controller.name == "BombNote(Clone)") return;

            missedAmt++;
            this.text.text = $"x{missedAmt}";
        }
    }
}

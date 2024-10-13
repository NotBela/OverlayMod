using OverlayMod.Configuration;
using System;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class MissStat : Stat, IDisposable
    {
        [Inject] private readonly BeatmapObjectManager _beatmapObjectManager;

        private int missedAmt;

        protected override StatConfig config { get; } = new StatConfig(Instance, "MissStat");

        public bool hideUntilMissed
        {
            get => config.getConfigEntry<bool>("hideWhileFc") ?? true;
            set => config.setConfigEntry("hideWhileFc", value);
        }
        
        public override int defaultPosY => 100;
        public override int defaultPosX => 500;
        public override float defaultSize => 40;
        public override bool defaultEnabled => true;

        public override Color defaultColor => Color.red;

        public static MissStat Instance { get; } = new MissStat();

        protected override void CreateStat()
        {
            _beatmapObjectManager.noteWasCutEvent += UpdateTextOnBadCut;
            _beatmapObjectManager.noteWasMissedEvent += UpdateTextOnMiss;

            missedAmt = 0;

            setTextParams($"x{missedAmt}");

            this.textObject.SetActive(!hideUntilMissed);
        }

        private void UpdateTextOnBadCut(NoteController noteController, in NoteCutInfo noteCutInfo)
        {
            if (noteCutInfo.allIsOK || noteController.noteData.colorType == ColorType.None) return;

            this.textObject.SetActive(enabled);
            this.text.text = $"x{++missedAmt}";
        }

        public void Dispose()
        {
            _beatmapObjectManager.noteWasMissedEvent -= UpdateTextOnMiss;
            _beatmapObjectManager.noteWasCutEvent -= UpdateTextOnBadCut;
        }

        private void UpdateTextOnMiss(NoteController controller)
        {
            if (controller.noteData.colorType == ColorType.None) return;

            this.textObject.SetActive(enabled);

            this.text.text = $"x{++missedAmt}";
        }
    }
}

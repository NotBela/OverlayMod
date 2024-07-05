using OverlayMod.Configuration;
using System;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class MissStat : IStat, IDisposable
    {
        [Inject] private readonly BeatmapObjectManager _beatmapObjectManager;

        private int missedAmt;
        public bool hideUntilMissed
        {
            get => StatConfig.getConfigEntry<bool>(this.enumType, "hideWhileFc") ?? true;
            set => StatConfig.setConfigEntry(enumType, "hideUntilMissed", value);
        }

        public bool redMissCounter
        {
            get => StatConfig.getConfigEntry<bool>(this.enumType, "redMissText") ?? true;
            set => StatConfig.setConfigEntry(enumType, "redMissText", value);
        }

        public override StatTypes enumType => StatTypes.MissStat;

        public override int posY
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posY") ?? 100;
            set => StatConfig.setConfigEntry(enumType, "posY", value);
        }
        public override int posX
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posX") ?? 400;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override float size
        {
            get => StatConfig.getConfigEntry<float>(enumType, "size") ?? 40;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override bool enabled
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? true;
            set => StatConfig.setConfigEntry(enumType, "enabled", value);
        }

        public static MissStat Instance { get; } = new MissStat();

        protected override void CreateStat()
        {
            _beatmapObjectManager.noteWasMissedEvent += UpdateTextOnMiss;
            _beatmapObjectManager.noteWasCutEvent += UpdateTextOnBadCut;

            missedAmt = 0;
            if (redMissCounter) this.text.color = Color.red;

            setTextParams($"x{missedAmt}");

            if (hideUntilMissed)
                this.textObject.SetActive(false);
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

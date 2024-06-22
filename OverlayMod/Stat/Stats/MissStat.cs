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
            set => StatConfig.setConfigEntry(enumType, "hideUntilMissed", value);
        }

        public bool redMissCounter
        {
            get => StatConfig.getConfigEntry<bool>(this.enumType, "redMissText") ?? true;
            set => StatConfig.setConfigEntry(enumType, "redMissText", value);
        }

        public override StatTypes enumType => StatTypes.MissStat;

        public override int posY {
            get => StatConfig.getConfigEntry<int>(enumType, "posY") ?? 100;
            set => StatConfig.setConfigEntry(enumType, "posY", value);
        }
        public override int posX
        {
            get => StatConfig.getConfigEntry<int>(enumType, "posX") ?? 400;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override int size
        {
            get => StatConfig.getConfigEntry<int>(enumType, "size") ?? 40;
            set => StatConfig.setConfigEntry(enumType, "size", value);
        }
        public override bool enabled 
        {
            get => StatConfig.getConfigEntry<bool>(enumType, "enabled") ?? true;
            set => StatConfig.setConfigEntry(enumType, "enabled", value);
        }

        public static MissStat Instance { get; } = new MissStat();

        public override void Initialize()
        {
            base.Initialize();

            _beatmapObjectManager.noteWasMissedEvent += UpdateText;

            missedAmt = 0;
            if (redMissCounter) this.text.color = Color.red;

            setTextParams($"x{missedAmt}");

            if (hideUntilMissed)
                this.textObject.SetActive(false);
        }

        public void Dispose()
        {
            _beatmapObjectManager.noteWasMissedEvent -= UpdateText;
        }

        private void UpdateText(NoteController controller)
        {
            if (controller.name == "BombNote(Clone)") return;

            this.textObject.SetActive(enabled);

            missedAmt++;
            this.text.text = $"x{missedAmt}";
        }
    }
}

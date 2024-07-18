﻿using OverlayMod.Configuration;
using System;
using UnityEngine;
using Zenject;

namespace OverlayMod.Stat.Stats
{
    internal class MissStat : Stat, IDisposable
    {
        [InjectOptional] private readonly BeatmapObjectManager _beatmapObjectManager;
        [InjectOptional] private readonly MultiplayerConnectedPlayerBeatmapObjectManager _multiplayerBeatmapObjectManager;

        private int missedAmt;

        public StatConfig config = new StatConfig(Instance, "MissStat");

        public bool hideUntilMissed
        {
            get => config.getConfigEntry<bool>("hideWhileFc") ?? true;
            set => config.setConfigEntry("hideWhileFc", value);
        }
        /*
        public bool redMissCounter
        {
            get => config.getConfigEntry<bool>("redMissText") ?? true;
            set => config.setConfigEntry("redMissText", value);
        }
        */
        public override int posY
        {
            get => config.getConfigEntry<int>("posY") ?? 100;
            set => config.setConfigEntry("posY", value);
        }
        public override int posX
        {
            get => config.getConfigEntry<int>("posX") ?? 500;
            set => config.setConfigEntry("posX", value);
        }
        public override float size
        {
            get => config.getConfigEntry<float>("size") ?? 40;
            set => config.setConfigEntry("size", value);
        }
        public override bool enabled
        {
            get => config.getConfigEntry<bool>("enabled") ?? true;
            set => config.setConfigEntry("enabled", value);
        }

        public override Color color
        {
            get => config.getConfigEntry<Color>("color") ?? Color.red;
            set => config.setConfigEntry("color", value);
        }

        public static MissStat Instance { get; } = new MissStat();

        protected override void CreateStat()
        {
            if (_beatmapObjectManager != null)
            {
                _beatmapObjectManager.noteWasCutEvent += UpdateTextOnBadCut;
                _beatmapObjectManager.noteWasMissedEvent += UpdateTextOnMiss;
                return;
            }

            _multiplayerBeatmapObjectManager.noteWasMissedEvent += UpdateTextOnMiss;
            _multiplayerBeatmapObjectManager.noteWasCutEvent += UpdateTextOnBadCut;

            missedAmt = 0;
            //if (redMissCounter) base.text.color = Color.red;

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

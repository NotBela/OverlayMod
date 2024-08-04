using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace OverlayMod.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual bool globalEnable { get; set; } = true;
        public virtual bool zenModeDisable { get; set; } = true;

        public virtual decimalFormat prefDecimalFormatting { get; set; } = decimalFormat.Unified;

        public enum decimalFormat
        {
            Reigonal,
            Unified
        }
    }
}
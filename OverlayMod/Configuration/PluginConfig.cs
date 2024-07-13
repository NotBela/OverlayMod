using System.Globalization;
using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using IPA.Config.Stores.Attributes;

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
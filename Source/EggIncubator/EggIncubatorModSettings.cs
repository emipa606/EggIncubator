using Verse;

namespace EggIncubator;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class EggIncubatorModSettings : ModSettings
{
    public bool IncreaseIncubationSpeed;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref IncreaseIncubationSpeed, "IncreaseIncubationSpeed");
    }
}
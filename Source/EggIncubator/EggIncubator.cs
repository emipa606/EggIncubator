using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace EggIncubator;

[StaticConstructorOnStartup]
public static class EggIncubator
{
    public static readonly ThingCategoryDef FertilizedCategoryDef;

    static EggIncubator()
    {
        new Harmony("Mlie.EggIncubator").PatchAll(Assembly.GetExecutingAssembly());
        FertilizedCategoryDef = ThingCategoryDef.Named("EggsFertilized");
    }

    public static bool IsInIncubator(Thing thing, bool Advanced = false)
    {
        if (thing?.IsInAnyStorage() == false)
        {
            return false;
        }

        var storage = thing?.PositionHeld.GetFirstBuilding(thing.Map);
        if (storage == null)
        {
            return false;
        }

        return storage.def.defName switch
        {
            "Basic_EggIncubator" when Advanced => false,
            "Basic_EggIncubator" => storage.TryGetComp<CompRefuelable>()?.HasFuel == true,
            "Normal_EggIncubator" => storage.TryGetComp<CompPowerTrader>()?.PowerOn == true,
            _ => false
        };
    }
}
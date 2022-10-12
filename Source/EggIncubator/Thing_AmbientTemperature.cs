using HarmonyLib;
using RimWorld;
using Verse;

namespace EggIncubator;

[HarmonyPatch(typeof(Thing), "AmbientTemperature", MethodType.Getter)]
public static class Thing_AmbientTemperature
{
    public static bool Prefix(ref Thing __instance, ref float __result)
    {
        if (__instance?.def?.thingCategories == null || !__instance.def.thingCategories.Any() ||
            !__instance.def.thingCategories.Contains(EggIncubator.FertilizedCategoryDef) ||
            !EggIncubator.IsInIncubator(__instance))
        {
            return true;
        }

        var props = __instance.TryGetComp<CompTemperatureRuinable>()?.Props;
        if (props == null)
        {
            return true;
        }

        var minSafe = props.minSafeTemperature;
        var maxSafe = props.maxSafeTemperature;
        __result = minSafe + ((maxSafe - minSafe) / 2);

        return false;
    }
}
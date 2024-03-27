using System.Text.RegularExpressions;
using HarmonyLib;
using RimWorld;

namespace EggIncubator;

[HarmonyPatch(typeof(CompHatcher), nameof(CompHatcher.CompInspectStringExtra))]
public static class CompHatcher_CompInspectStringExtra
{
    public static void Postfix(ref CompHatcher __instance, ref string __result)
    {
        if (!EggIncubatorMod.instance.Settings.IncreaseIncubationSpeed ||
            !EggIncubator.IsInIncubator(__instance.parent, true))
        {
            return;
        }

        var pattern = new Regex(@"\d+\.*\d*");
        var matches = pattern.Matches(__result);
        if (matches.Count != 2)
        {
            return;
        }

        var hatchesIn = float.Parse(matches[1].Value);
        var hatchesInString = (hatchesIn / 2).ToString("F1");
        __result = __result.Replace(matches[1].Value, hatchesInString);
    }
}
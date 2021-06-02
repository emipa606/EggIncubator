using HarmonyLib;
using RimWorld;

namespace EggIncubator
{
    [HarmonyPatch(typeof(CompHatcher), "CompTick")]
    public static class CompHatcher_CompTick
    {
        private static bool skipPostfix;

        public static void Postfix(ref CompHatcher __instance)
        {
            if (skipPostfix || !EggIncubatorMod.instance.Settings.IncreaseIncubationSpeed ||
                !EggIncubator.IsInIncubator(__instance.parent, true))
            {
                return;
            }

            skipPostfix = true;
            __instance.CompTick();
            skipPostfix = false;
        }
    }
}
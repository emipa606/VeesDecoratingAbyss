using HarmonyLib;
using RimWorld;
using Verse;

namespace DesignatorPatch;

[StaticConstructorOnStartup]
internal class DesignatorCostHarmony
{
    static DesignatorCostHarmony()
    {
        if (!Harmony.HasAnyPatches("Mlie.DesignatorCost"))
        {
            new Harmony("Mlie.DesignatorCost").PatchAll();
        }
    }

    [HarmonyPatch(typeof(Designator_Dropdown), "GetDesignatorCost")]
    public static class DesignatorDropdownCostPatch
    {
        public static bool Prefix(ref ThingDef __result, Designator des)
        {
            if (des is not Designator_Place designator_Place)
            {
                return true;
            }

            var placingDef = designator_Place.PlacingDef;
            if (placingDef.costList != null)
            {
                return true;
            }

            __result = null;
            return false;
        }
    }
}

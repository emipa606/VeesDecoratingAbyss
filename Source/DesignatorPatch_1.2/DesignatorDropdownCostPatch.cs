using HarmonyLib;
using RimWorld;
using Verse;

namespace DesignatorPatch;

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
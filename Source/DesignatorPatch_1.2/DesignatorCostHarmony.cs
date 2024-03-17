using HarmonyLib;
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
}
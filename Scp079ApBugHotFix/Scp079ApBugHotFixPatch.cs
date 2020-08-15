using HarmonyLib;
using Mirror;
using UnityEngine;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace Scp079ApBugHotFix
{
    [HarmonyPatch(typeof(Scp079PlayerScript), nameof(Scp079PlayerScript.ServerUpdateMana))]
    public class Scp079ApBugHotFixPatch
    {
        public static bool Prefix(Scp079PlayerScript __instance)
        {
            if (!NetworkServer.active || !NetworkServer.active || !__instance.iAm079) return false;

            bool isDraining = false;
            if (!string.IsNullOrEmpty(__instance.Speaker))
            {
                isDraining = true;
                __instance.Mana -= __instance.GetManaFromLabel("Speaker Update", __instance.abilities) * Time.deltaTime;
                if (__instance.Mana <= 0f) __instance.Speaker = string.Empty;
            }

            if (__instance.lockedDoors.Count > 0)
            {
                isDraining = true;
                __instance.Mana -= __instance.GetManaFromLabel("Door Lock", __instance.abilities) * Time.deltaTime *
                                   __instance.lockedDoors.Count;
                if (__instance.Mana <= 0f) __instance.lockedDoors.Clear();
            }

            if (!isDraining)
                __instance.Mana =
                    Mathf.Clamp(
                        __instance.curMana + __instance.levels[__instance.curLvl].manaPerSecond * Time.deltaTime *
                        __instance.generatorAuxRegenerationFactor[Generator079.mainGenerator.totalVoltage], 0f,
                        __instance.levels[__instance.curLvl].maxMana);

            return true;
        }
    }
}
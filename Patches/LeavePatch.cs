using CSync.Lib;
using HarmonyLib;

namespace CSync.Patches;

[HarmonyPatch(typeof(GameNetworkManager))]
public class LeavePatch {
    [HarmonyPostfix]
    [HarmonyPatch("StartDisconnect")]
    private static void RevertOnDisconnect() {
        ConfigManager.RevertSyncedInstances();
    }
}
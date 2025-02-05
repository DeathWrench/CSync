using BepInEx;
using BepInEx.Logging;

using CSync.Core;
using HarmonyLib;
using System;

namespace CSync;

/// <summary>
/// The plugin and main entry point of this library, responsible for holding the logger.<br></br>
/// Helps with public logging and caching of config files through static references.<br></br>
/// <br></br>
/// Do <b>NOT</b> use this class directly or create any instances of it!
/// </summary>
[BepInPlugin(Metadata.GUID, Metadata.NAME, Metadata.VERSION)]
public class Plugin : BaseUnityPlugin {
    public static new ManualLogSource Logger { get; private set; }
    
    Harmony Patcher;

    private void Awake() {
        Logger = base.Logger;

        try {
            Patcher = new(Metadata.GUID);
            Patcher.PatchAll();

            Logger.LogInfo("CSync successfully applied patches.");
        } catch(Exception e) {
            Logger.LogError(e);
        }
    }
}
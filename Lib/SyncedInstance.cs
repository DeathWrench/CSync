using CSync.Util;
using System;
using Unity.Netcode;

namespace CSync.Lib;

/// <summary>
/// Generic class that can be serialized to bytes.<br></br>
/// Handles syncing and reverting as well as holding references to the client-side and synchronized instances.<br></br>
/// <br></br><br></br>
/// This class should always be inherited from, never use it directly!
/// </summary>
[Serializable]
public class SyncedInstance<T> : ByteSerializer<T> where T : class {
    public static CustomMessagingManager MessageManager => NetworkManager.Singleton.CustomMessagingManager;
    public static bool IsClient => NetworkManager.Singleton.IsClient;
    public static bool IsHost => NetworkManager.Singleton.IsHost;

    public static T Default { get; private set; }
    public static T Instance { get; private set; }

    public static bool Synced;
    
    public void InitInstance(T instance) {
        Default = instance;
        Instance = instance;
    }
    
    public void SyncInstance(byte[] data) {
        Instance = DeserializeFromBytes(data);
        Synced = Instance != null;
    }

    public void RevertSync() {
        Instance = Default;
        Synced = false;
    }
}
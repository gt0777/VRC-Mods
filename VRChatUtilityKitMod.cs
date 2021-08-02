using System;
using MelonLoader;
using VRChatUtilityKit.Ui;
using VRChatUtilityKit.Utilities;


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace VRChatUtilityKit
{
    public class VRChatUtilityKitMod
    {
        internal static VRChatUtilityKitMod Instance { get; private set; }

        public void OnApplicationStart()
        {
            MelonLogger.Msg("Initializing...");
            Instance = this;
            UiManager.Init();
            VRCUtils.Init();
            VRCUtils.OnUiManagerInit += OnUiManagerInit;
        }

        internal void OnUiManagerInit()
        {
            MelonLogger.Msg("Initializing UI...");
            UiManager.UiInit();
            NetworkEvents.NetworkInit();
            VRCUtils.UiInit();
        }

        public void OnUpdate()
        {
            if (AsyncUtils._toMainThreadQueue.TryDequeue(out Action result))
                result.Invoke();
        }
    }
}

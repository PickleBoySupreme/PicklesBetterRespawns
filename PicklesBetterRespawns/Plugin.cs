using BepInEx;
using GameNetcodeStuff;
using HarmonyLib;

namespace PicklesBetterRespawns
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class LCBetterRespawn : BaseUnityPlugin
    {
        
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        private static LCBetterRespawn Instance;
        
        
        void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            if (Instance == null)
            {
                Instance = this;
            }

            harmony.PatchAll();
        }
    }
}

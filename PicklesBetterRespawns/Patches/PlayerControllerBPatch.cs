using System.Collections.Generic;
using GameNetcodeStuff;
using HarmonyLib;
using BepInEx.Logging;


namespace PicklesBetterRespawns.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        public static List<ulong> deadPlayers = new List<ulong>();

        [HarmonyPatch(nameof(PlayerControllerB.KillPlayerServerRpc))]
        [HarmonyPostfix]

        static void rememberDeadPlayer(ref StartOfRound ___playersManager, int playerId)
        {
            ulong deadPlayer = ___playersManager.allPlayerScripts[playerId].playerSteamId;
            
            deadPlayers.Add(deadPlayer);
            
            ManualLogSource mls = Logger.CreateLogSource("Pickle.Respawn");
            mls.LogInfo($"Players ID is: " + deadPlayer);
            
            
            //deadPlayers.Clear();
        }
    }
}
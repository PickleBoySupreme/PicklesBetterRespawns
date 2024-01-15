using System.Collections.Generic;
using GameNetcodeStuff;
using HarmonyLib;
using System;


namespace PicklesBetterRespawns.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class Patch
    {
        public static List<ulong> deadPlayers = new List<ulong>();

        [HarmonyPatch(nameof(PlayerControllerB.KillPlayerServerRpc))]
        [HarmonyPostfix]

        static void rememberDeadPlayer(ulong playerSteamId)
        {
            deadPlayers.Add(playerSteamId);
            
            Console.WriteLine($"Players ID is: " + playerSteamId);
        }
        
    }

}
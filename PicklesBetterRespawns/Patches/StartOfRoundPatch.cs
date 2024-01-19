using HarmonyLib;

namespace PicklesBetterRespawns.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        [HarmonyPatch(nameof(StartOfRound.ReviveDeadPlayers))]
        [HarmonyPrefix]
        static void keepEmDead(ref bool __runOriginal)
        {
            __runOriginal = false;
        }
        

    }

}

/*
Need to skip "ApplyPenalty" for players that are already dead - maybe best way to do this is to replace playersDead with a new list that only takes into account players that died this round

Need a way to call the "ReviveDeadPlayers" method when the quota has been reached - revive after quota is reached on ship
            find way to set when you want the dead players to be revived via a config file

Disable HUD for dead players on ship
Disable "leave early" HUD when on ship

Create ship upgrade that lets you revive teamates when the body is present

Clear list and attempt to spawn all players when the quota or time is reached
*/
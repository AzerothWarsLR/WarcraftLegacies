//Give each player their starting gold and lumber as the opening cinematic ends.

using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Game_Logic
{
  public static class StartingResources
  {
    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 60, false);
      TriggerAddAction(trig, () =>
      {
        foreach (var player in GetAllPlayers())
        {
          if (PlayerData.ByHandle(player) != null)
          {
            SetPlayerState(player, PLAYER_STATE_RESOURCE_GOLD, PlayerData.ByHandle(player)!.Faction.StartingGold);
            SetPlayerState(player, PLAYER_STATE_RESOURCE_LUMBER, PlayerData.ByHandle(player)!.Faction.StartingLumber);
          }
        }
      });
    }
  }
}
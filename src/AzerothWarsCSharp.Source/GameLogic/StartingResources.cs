//Give each player their starting gold and lumber as the opening cinematic ends.

using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.GameLogic
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
          SetPlayerState(player, PLAYER_STATE_RESOURCE_GOLD, player.GetFaction().StartingGold);
          SetPlayerState(player, PLAYER_STATE_RESOURCE_LUMBER, player.GetFaction().StartingLumber);
        }
      });
    }
  }
}
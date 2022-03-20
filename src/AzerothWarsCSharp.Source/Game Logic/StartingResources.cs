//Give each player their starting gold and lumber as the opening cinematic ends.

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;

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
        foreach (var player in GeneralHelpers.GetAllPlayers())
        {
          if (Person.ByHandle(player) != null)
          {
            SetPlayerState(player, PLAYER_STATE_RESOURCE_GOLD, Person.ByHandle(player)!.Faction.StartingGold);
            SetPlayerState(player, PLAYER_STATE_RESOURCE_LUMBER, Person.ByHandle(player)!.Faction.StartingLumber);
          }
        }
      });
    }
  }
}
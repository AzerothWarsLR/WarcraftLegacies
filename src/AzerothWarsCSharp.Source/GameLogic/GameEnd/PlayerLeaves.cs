using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.GameLogic.GameEnd
{
  public static class PlayerLeaves
  {
    private static void PlayerLeavesGame()
    {
      var triggerPlayer = GetTriggerPlayer();

      //Display leaving message
      if (triggerPlayer.GetFaction() != null)
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, triggerPlayer.GetFaction().ColoredName + " has left the game.");
      else
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, GetPlayerName(triggerPlayer) + "has left the game.");

      //Defeat the player
      if (triggerPlayer.GetFaction() != null && triggerPlayer.GetFaction().ScoreStatus != ScoreStatus.Defeated)
        triggerPlayer.GetFaction().ScoreStatus = ScoreStatus.Defeated;
    }

    public static void Setup()
    {
      var trig = CreateTrigger();
      var i = 0;
      while (true)
      {
        if (i > 24) break;
        TriggerRegisterPlayerEvent(trig, Player(i), EVENT_PLAYER_LEAVE);
        i += 1;
      }

      TriggerAddAction(trig, PlayerLeavesGame);
    }
  }
}
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Game_Logic.GameEnd
{
  public class PlayerLeaves{

    private static void PlayerLeavesGame( ){
      var p = GetTriggerPlayer();
      var triggerPerson = Person.ByHandle(GetTriggerPlayer());

      //Display leaving message
      if (triggerPerson?.Faction != null){
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, triggerPerson.Faction.ColoredName + " has left the game.");
      }else {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, GetPlayerName(triggerPerson?.Player) + "has left the game.");
      }

      //Defeat the player
      if (triggerPerson?.Faction != null && triggerPerson.Faction.ScoreStatus != ScoreStatus.Defeated){
        triggerPerson.Faction.ScoreStatus = ScoreStatus.Defeated;
      }
    }

    public static void Setup( ){
      var trig = CreateTrigger(  );
      var i = 0;
      while(true){
        if ( i > 24){ break; }
        TriggerRegisterPlayerEvent(trig, Player(i), EVENT_PLAYER_LEAVE);
        i += 1;
      }
      TriggerAddAction( trig, PlayerLeavesGame);
    }

  }
}

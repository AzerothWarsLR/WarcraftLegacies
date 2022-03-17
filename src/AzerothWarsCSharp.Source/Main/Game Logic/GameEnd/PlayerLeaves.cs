namespace AzerothWarsCSharp.Source.Main.Game_Logic.GameEnd
{
  public class PlayerLeaves{

    private static void PlayerLeaves( ){
      player p = GetTriggerPlayer();
      int pId = GetPlayerId(p);
      Person triggerPerson = Person.ByHandle(GetTriggerPlayer());

      //Display leaving message
      if (triggerPerson.Faction != 0){
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, triggerPerson.Faction.ColoredName + " has left the game.");
      }else {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, GetPlayerName(triggerPerson.Player) + "has left the game.");
      }

      //Defeat the player
      if (triggerPerson != 0 && triggerPerson.Faction != 0 && triggerPerson.Faction.ScoreStatus != SCORESTATUS_DEFEATED){
        triggerPerson.Faction.ScoreStatus = SCORESTATUS_DEFEATED;
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger(  );
      int i = 0;
      while(true){
        if ( i > 24){ break; }
        TriggerRegisterPlayerEvent(trig, Player(i), EVENT_PLAYER_LEAVE);
        i = i + 1;
      }
      TriggerAddCondition( trig, ( PlayerLeaves) );
    }

  }
}

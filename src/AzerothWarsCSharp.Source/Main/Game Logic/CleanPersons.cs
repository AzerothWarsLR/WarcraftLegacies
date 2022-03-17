namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public class CleanPersons{

    //Removes players from the game if their slot is unoccupied

    private static void Actions( ){
      int i = 0;
      Person loopPerson = 0;

      if (!AreCheatsActive){
        while(true){
          if ( i > MAX_PLAYERS){ break; }
          loopPerson = Person.ById(i);
          if (loopPerson != 0 && GetPlayerSlotState(Player(i)) != PLAYER_SLOT_STATE_PLAYING && loopPerson.Faction.ScoreStatus == SCORESTATUS_NORMAL){
            loopPerson.Faction.ScoreStatus = SCORESTATUS_DEFEATED;
          }
          i = i + 1;
        }
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 2, false);
      TriggerAddCondition(trig, ( Actions));
    }

  }
}

//Give each player their starting gold and lumber as the opening cinematic ends.

using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public class StartingResources{

    private static void Actions( ){
      int i = 0;
      Person loopPerson;
      Faction loopFaction;
      while(true){
        if ( i > MAX_PLAYERS){ break; }
        loopPerson = Person.ById(i);
        if (loopPerson != 0){
          loopFaction = loopPerson.Faction;
          if (loopFaction != 0){
            if (loopFaction.StartingGold != 0){
              SetPlayerState(loopPerson.Player, PLAYER_STATE_RESOURCE_GOLD, loopPerson.Faction.StartingGold);
            }
            if (loopFaction.StartingLumber != 0){
              SetPlayerState(loopPerson.Player, PLAYER_STATE_RESOURCE_LUMBER, loopPerson.Faction.StartingLumber);
            }
          }
        }
        i = i + 1;
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 60, false);
      TriggerAddCondition(trig, ( Actions));
    }

  }
}

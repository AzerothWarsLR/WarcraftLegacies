//A command that pings all units belonging to the user that have a limit on how many of them can be made.

using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Commands
{
  public class LimitedCommand{

	
    private const string COMMAND = "-limited";
  

    private static void Actions( ){
      Person triggerPerson = Person.ByHandle(GetTriggerPlayer());
      Faction triggerFaction = triggerPerson.Faction;
      group tempGroup = CreateGroup();
      int i = 0;
      unit u;
      GroupEnumUnitsOfPlayer(tempGroup, triggerPerson.Player, null);

      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        i = 0;
        while(true){
          if ( i == triggerFaction.ObjectLimitCount){ break; }
          if (GetUnitTypeId(u) == triggerFaction.objectList[i] && triggerFaction.objectLimits[triggerFaction.objectList[i]] < UNLIMITED){
            PingMinimapForPlayer(triggerPerson.Player, GetUnitX(u), GetUnitY(u), 5);
          }
          i = i + 1;
        }
        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger(  );
      int i = 0;

      while(true){
        if ( i > MAX_PLAYERS){ break; }
        TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, true );
        i = i + 1;
      }

      TriggerAddAction(trig,  Actions);
    }

  }
}

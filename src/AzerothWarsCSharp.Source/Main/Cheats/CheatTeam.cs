using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatTeam{

  
    private const string COMMAND     = "-team ";
    private string parameter = null;
  

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      int pId = GetPlayerId(p);
      Team t;
      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      t = Team.teamsByName[parameter];
      Person.ById(pId).Faction.Team = t;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to team to " + t.Name + ".");
    }

    //===========================================================================
    private static void OnInit( ){
      trigger trig = CreateTrigger(  );
      int i = 0;
      while(true){
        if ( i > MAX_PLAYERS){ break; }
        TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, false );
        i = i + 1;
      }
      TriggerAddCondition(trig, ( CheatCondition));
      TriggerAddAction( trig,  Actions );
    }

  }
}

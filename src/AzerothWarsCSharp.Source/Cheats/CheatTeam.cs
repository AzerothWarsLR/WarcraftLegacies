using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatTeam{

  
    private const string COMMAND     = "-team ";
    private string parameter;
  

    private static void Actions( ){
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      Team t;
      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      t = Team.teamsByName[parameter];
      Person.ById(pId).Faction.Team = t;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to team to " + t.Name + ".");
    }

    //===========================================================================
    public static void Setup( ){
      trigger trig = CreateTrigger();
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }
      TriggerAddAction(trig, Actions);
    }

  }
}

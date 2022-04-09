using AzerothWarsCSharp.MacroTools;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatRemove{

  
    private const string COMMAND     = "-remove";
    private string _parameter = null;
  

    private static void Remove( ){
      RemoveUnit(GetEnumUnit());
    }

    private static void Actions( ){
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);

      ForGroupBJ( GetUnitsSelectedAll(p),  Remove );
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Permanently removing selected units.");
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }
      TriggerAddAction(trig, Actions);
    }

  }
}

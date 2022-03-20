using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatHP{

  
    private const string COMMAND     = "-hp ";
    private string parameter;
  

    private static void SetHP( ){
      SetUnitLifeBJ( GetEnumUnit(), S2R(parameter));
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
      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (S2I(parameter) >= 0){
        ForGroupBJ( GetUnitsSelectedAll(p),  SetHP );
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting hitpoints of selected units to " + parameter + ".");
      }
    }

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

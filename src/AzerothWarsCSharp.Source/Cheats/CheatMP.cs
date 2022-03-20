using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatMP{

  
    private const string COMMAND     = "-mp ";
    private string parameter;
  

    private static void SetMana( ){
      SetUnitManaBJ( GetEnumUnit(), S2R(parameter));
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
        ForGroupBJ( GetUnitsSelectedAll(p),  SetMana );
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting mana of selected units to " + parameter + ".");
      }
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

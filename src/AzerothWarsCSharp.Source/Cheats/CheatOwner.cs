using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatOwner{

  
    private const string COMMAND     = "-owner ";
    private string parameter;
  

    private static void SetOwner( ){
      SetUnitOwner(GetEnumUnit(), Player(S2I(parameter)), true);
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
        ForGroupBJ( GetUnitsSelectedAll(p),  SetOwner );
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting owner of selected units to " + GetPlayerName(Player(S2I(parameter))) + ".");
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

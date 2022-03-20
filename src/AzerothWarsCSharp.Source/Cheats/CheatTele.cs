
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatTele{

    //**CONFIG
  
    private const string COMMAND     = "-tele ";
    private bool[] TeleToggle;
  
    //*ENDCONFIG

    private static void Patrol( ){
      if (GetIssuedOrderId() == 851990 && TeleToggle[GetPlayerId(GetTriggerPlayer())]){
        SetUnitX(GetTriggerUnit(), GetOrderPointX());
        SetUnitY(GetTriggerUnit(), GetOrderPointY());
      }
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
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "on"){
        TeleToggle[pId] = true;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Teleport activated. Use patrol to move instantly.");
      }else if (parameter == "off"){
        TeleToggle[pId] = false;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Teleport deactivated. Patrol works normally.");
      }
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }
      TriggerAddAction(trig, Actions);

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_ISSUED_POINT_ORDER,  Patrol);
    }

  }
}

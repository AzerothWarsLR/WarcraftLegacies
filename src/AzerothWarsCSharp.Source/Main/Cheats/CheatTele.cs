
namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatTele{

    //**CONFIG
  
    private const string COMMAND     = "-tele ";
    private boolean[] TeleToggle;
  
    //*ENDCONFIG

    private static void Patrol( ){
      if (GetIssuedOrderId() == 851990 && TeleToggle[GetPlayerId(GetTriggerPlayer())]){
        SetUnitX(GetTriggerUnit(), GetOrderPointX());
        SetUnitY(GetTriggerUnit(), GetOrderPointY());
      }
    }

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      int pId = GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "on"){
        TeleToggle[pId] = true;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Teleport activated. Use patrol to move instantly.");
      }else if (parameter == "off"){
        TeleToggle[pId] = false;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Teleport deactivated. Patrol works normally.");
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger(  );
      int i = 0;

      while(true){
        if ( i > MAX_PLAYERS){ break; }
        TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, false );
        i = i + 1;
      }
      TriggerAddCondition(trig, ( CheatCondition));
      TriggerAddAction(trig,  Actions);

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_ISSUED_POINT_ORDER,  Patrol);
    }

  }
}

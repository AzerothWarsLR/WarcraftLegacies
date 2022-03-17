
namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatBuild{

    //**CONFIG
  
    private const string COMMAND     = "-build ";
    private boolean[] BuildToggle;
  
    //*ENDCONFIG

    private static void Build( ){
      if (GetIssuedOrderId() == 851976 && BuildToggle[GetPlayerId(GetTriggerPlayer())]){

        UnitSetUpgradeProgress(GetTriggerUnit(), 100);
      }
    }

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      int pId = GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "on"){
        BuildToggle[pId] = true;

      }else if (parameter == "off"){
        BuildToggle[pId] = false;

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

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_ISSUED_ORDER,  Build);
    }

  }
}

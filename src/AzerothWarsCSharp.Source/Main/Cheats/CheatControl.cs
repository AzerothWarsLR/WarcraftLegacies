
namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatControl{

    //**CONFIG
  
    private const string COMMAND     = "-control ";
  
    //*ENDCONFIG

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      int pId = GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "all"){
        i = 0;
        while(true){
          if ( i > MAX_PLAYERS){ break; }
          SetPlayerAllianceStateBJ( GetTriggerPlayer(), Player(i), bj_ALLIANCE_ALLIED_ADVUNITS );
          SetPlayerAllianceStateBJ( Player(i), GetTriggerPlayer(), bj_ALLIANCE_ALLIED_ADVUNITS );
          i = i + 1;
        }
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted control of all players.");
      }else {
        SetPlayerAllianceStateBJ( Player(S2I(parameter)), GetTriggerPlayer(), bj_ALLIANCE_ALLIED_ADVUNITS );
        SetPlayerAllianceStateBJ( GetTriggerPlayer(), Player(S2I(parameter)), bj_ALLIANCE_ALLIED_ADVUNITS );
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted control of player " + GetPlayerName(Player(S2I(parameter))) + ".");
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
      TriggerAddAction( trig,  Actions );
    }

  }
}

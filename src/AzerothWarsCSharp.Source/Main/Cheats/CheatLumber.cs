
namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatLumber{

    //**CONFIG
    
    private const string COMMAND     = "-lumber ";
    
    //*ENDCONFIG

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      string parameter = null;
      player p = GetTriggerPlayer();

      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      SetPlayerState(p, PLAYER_STATE_RESOURCE_LUMBER, S2I(parameter));
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Set to " + parameter + " lumber.");
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

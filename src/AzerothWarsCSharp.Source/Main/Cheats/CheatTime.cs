
public class CheatTime{

  //**CONFIG
  
      private const string COMMAND     = "-time ";
  
  //*ENDCONFIG

  private static void Actions( ){
    int i = 0;
    string enteredString = GetEventPlayerChatString();
    player p = GetTriggerPlayer();
    int pId = GetPlayerId(p);
    string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

    SetFloatGameState(GAME_STATE_TIME_OF_DAY, S2R(parameter));
    DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Time of day to " + parameter + ".");
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

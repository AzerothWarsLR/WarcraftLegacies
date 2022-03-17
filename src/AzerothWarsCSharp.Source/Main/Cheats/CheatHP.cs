public class CheatHP{

  
    private const string COMMAND     = "-hp ";
    private string parameter = null;
  

  private static void SetHP( ){
    SetUnitLifeBJ( GetEnumUnit(), S2R(parameter));
  }

  private static void Actions( ){
    int i = 0;
    string enteredString = GetEventPlayerChatString();
    player p = GetTriggerPlayer();
    int pId = GetPlayerId(p);
    parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

    if (S2I(parameter) >= 0){
      ForGroupBJ( GetUnitsSelectedAll(p),  SetHP );
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting hitpoints of selected units to " + parameter + ".");
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

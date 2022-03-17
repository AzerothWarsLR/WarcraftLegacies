
public class CheatVision{

  //**CONFIG
  
    private const string COMMAND     = "-vision ";
    private fogmodifier[] fogs;
  
  //*ENDCONFIG

  private static void Actions( ){
    int i = 0;
    string enteredString = GetEventPlayerChatString();
    player p = GetTriggerPlayer();
    int pId = GetPlayerId(p);
    string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

    if (parameter == "on"){
      fogs[pId] = CreateFogModifierRectBJ( true, p, FOG_OF_WAR_VISIBLE, GetPlayableMapRect() );
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map revealed.");
    }else if (parameter == "off"){
      DestroyFogModifier(fogs[pId]);
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map unrevealed.");
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

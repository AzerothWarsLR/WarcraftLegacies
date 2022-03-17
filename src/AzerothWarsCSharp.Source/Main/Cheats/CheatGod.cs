
public class CheatGod{

  
    private const string COMMAND     = "-god ";
    private boolean[] Toggle;
  

  private static void Damage( ){
    if (Toggle[GetPlayerId(GetTriggerPlayer())]){
      BlzSetEventDamage(0);
    }else if (Toggle[GetPlayerId(GetOwningPlayer(GetEventDamageSource()))]){
      BlzSetEventDamage(GetEventDamage() * 100);
    }
  }

  private static void Actions( ){
    int i = 0;
    string enteredString = GetEventPlayerChatString();
    player p = GetTriggerPlayer();
    int pId = GetPlayerId(p);
    string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

    if (parameter == "on"){
        Toggle[pId] = true;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r God mod activated. Your units will deal 100x damage && take no damage.");
    }else if (parameter == "off"){
      Toggle[pId] = false;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r God mode deactivated.");
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

    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED,  Damage);
  }

}

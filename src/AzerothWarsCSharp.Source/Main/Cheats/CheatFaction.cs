public class CheatFaction{

  
    private const string COMMAND = "-faction ";
    private string parameter = null;
  

  private static void Actions( ){
    int i = 0;
    string enteredString = GetEventPlayerChatString();
    player p = GetTriggerPlayer();
    int pId = GetPlayerId(p);
    Faction f;
    parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
    f = Faction.factionsByName[parameter];

    Person.ById(pId).Faction = f;
    DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to faction to " + f.Name + ".");
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

public class CheatSpawn{

  
    private const string COMMAND     = "-spawn ";
    private string parameter = null;
    private string parameter2 = null;
  

  private static integer Char2Id(string c ){
    int i = 0;
    string abc = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    string t;

    while(true){
      t = SubString(abc,i,i + 1);
      if ( t == null || t == c){ break; }
      i = i + 1;
    }
    if (i < 10){
      return i + 48;
    }else if (i < 36){
      return i + 65 - 10;
    }
    return i + 97 - 36;
  }

  private static integer S2Raw(string s ){
    return ((Char2Id(SubString(s,0,1)) * 256 + Char2Id(SubString(s,1,2))) * 256 + Char2Id(SubString(s,2,3))) * 256 + Char2Id(SubString(s,3,4));
  }

  private static void Spawn( ){
    int i = 0;
    while(true){
    if ( i == S2I(parameter2)){ break; }
      CreateUnit( GetTriggerPlayer(), S2Raw(parameter), GetUnitX(GetEnumUnit()), GetUnitY(GetEnumUnit()), 0 );
      CreateItem( S2Raw(parameter), GetUnitX(GetEnumUnit()), GetUnitY(GetEnumUnit()) );
      i = i + 1;
    }
  }

  private static void Actions( ){
    int i = 0;
    string enteredString = GetEventPlayerChatString();
    player p = GetTriggerPlayer();
    int pId = GetPlayerId(p);
    parameter = SubString(enteredString, StringLength(COMMAND), StringLength(COMMAND)+4);
    parameter2 = SubString(enteredString, StringLength(COMMAND) + StringLength(parameter)+1, StringLength(enteredString));

    if (S2I(parameter2) < 1){
      parameter2 = "1";
    }

    if (S2Raw(parameter) >= 0){
      ForGroupBJ( GetUnitsSelectedAll(p),  Spawn );
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to spawn " + parameter2 + " of object " + GetObjectName(S2Raw(parameter)) + ".");
    }
  }

  //===========================================================================
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

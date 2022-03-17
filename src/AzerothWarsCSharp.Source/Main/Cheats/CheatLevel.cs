namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatLevel{

  
    private const string COMMAND     = "-level ";
    private string parameter = null;
  

    private static void SetLevel( ){
      SetHeroLevelBJ( GetEnumUnit(), S2I(parameter), true );
    }

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      int pId = GetPlayerId(p);
      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (S2I(parameter) > 0){
        ForGroupBJ( GetUnitsSelectedAll(p),  SetLevel );
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting hero level of selected units to " + parameter + ".");
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

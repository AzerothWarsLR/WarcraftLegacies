namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatKick{

  
    private const string COMMAND     = "-kick ";
    private string parameter = null;
  

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      int pId = GetPlayerId(p);
      int kickId = 0;

      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      kickId = (S2I(parameter));

      Person.ById(kickId).Faction.ScoreStatus = SCORESTATUS_DEFEATED;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to kick player " + GetPlayerName(Player(kickId)) + ".");
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

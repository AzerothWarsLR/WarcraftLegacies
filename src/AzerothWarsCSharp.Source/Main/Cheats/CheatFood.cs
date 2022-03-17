
namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatFood{

  
    private const string COMMAND     = "-food ";
  

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      string parameter = null;
      player p = GetTriggerPlayer();

      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      AdjustPlayerStateBJ(S2I(parameter), p, PLAYER_STATE_RESOURCE_FOOD_CAP);
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted " + parameter + " food.");
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

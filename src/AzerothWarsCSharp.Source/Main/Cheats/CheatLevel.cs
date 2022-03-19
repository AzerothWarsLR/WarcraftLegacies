namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatLevel{

  
    private const string COMMAND     = "-level ";
    private string parameter;
  

    private static void SetLevel( ){
      SetHeroLevelBJ( GetEnumUnit(), S2I(parameter), true );
    }

    private static void Actions( ){
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (S2I(parameter) > 0){
        ForGroupBJ( GetUnitsSelectedAll(p),  SetLevel );
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting hero level of selected units to " + parameter + ".");
      }
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }
      TriggerAddAction(trig, Actions);
    }

  }
}

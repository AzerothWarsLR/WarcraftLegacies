namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatKick{

  
    private const string COMMAND     = "-kick ";
    private string parameter;
  

    private static void Actions( ){
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      var kickId = 0;

      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      kickId = (S2I(parameter));

      Person.ById(kickId).Faction.ScoreStatus = SCORESTATUS_DEFEATED;
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Attempted to kick player " + GetPlayerName(Player(kickId)) + ".");
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

using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatFood{

  
    private const string COMMAND     = "-food ";
  

    private static void Actions( ){
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      string parameter = null;
      player p = GetTriggerPlayer();

      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      AdjustPlayerStateBJ(S2I(parameter), p, PLAYER_STATE_RESOURCE_FOOD_CAP);
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted " + parameter + " food.");
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

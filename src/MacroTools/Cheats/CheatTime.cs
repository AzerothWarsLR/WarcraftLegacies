using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Cheats
{
  public static class CheatTime
  {
    private const string COMMAND = "-time ";

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      SetFloatGameState(GAME_STATE_TIME_OF_DAY, S2R(parameter));
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Time of day to " + parameter + ".");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);
    }
  }
}
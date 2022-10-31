using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.Cheats
{
  public static class CheatGold
  {
    private const string COMMAND = "-gold ";

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      string parameter = null;
      player p = GetTriggerPlayer();

      parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      SetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD, S2I(parameter));
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Set to " + parameter + " gold.");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);
    }
  }
}
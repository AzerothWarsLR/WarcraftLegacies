using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static class CheatLumber
  {
    //**CONFIG

    private const string Command = "-lumber ";

    //*ENDCONFIG

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      string parameter = null;
      player p = GetTriggerPlayer();

      parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));
      SetPlayerState(p, PLAYER_STATE_RESOURCE_LUMBER, S2I(parameter));
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Set to " + parameter + " lumber.");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}
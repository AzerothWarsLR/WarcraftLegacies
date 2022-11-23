using MacroTools.FactionSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static class CheatFood
  {
    private const string Command = "-food ";


    private static void Actions()
    {
      if (!TestMode.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();

      string parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));
      p.AdjustPlayerState(PLAYER_STATE_RESOURCE_FOOD_CAP, S2I(parameter));
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted " + parameter + " food.");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}
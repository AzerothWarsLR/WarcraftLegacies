using MacroTools.Wrappers;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static class CheatOwner
  {
    private const string COMMAND = "-owner ";
    private static string? _parameter;

    private static void SetOwner(unit whichUnit)
    {
      SetUnitOwner(whichUnit, Player(S2I(_parameter)), true);
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (S2I(_parameter) >= 0)
      {
        foreach (var unit in new GroupWrapper().EnumSelectedUnits(p).EmptyToList())
        {
          SetOwner(unit);
        }
        DisplayTextToPlayer(p, 0, 0,
          "|cffD27575CHEAT:|r Setting owner of selected units to " + GetPlayerName(Player(S2I(_parameter))) + ".");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}
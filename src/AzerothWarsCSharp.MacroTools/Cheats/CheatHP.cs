using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatHp
  {
    private const string COMMAND = "-hp ";
    private static string? _parameter;

    private static void SetHp(unit whichUnit)
    {
      SetUnitState(whichUnit, UNIT_STATE_LIFE, S2R(_parameter));
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      GetPlayerId(p);
      _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (S2I(_parameter) >= 0)
      {
        foreach (var unit in new GroupWrapper().EnumSelectedUnits(p).EmptyToList())
        {
          SetHp(unit);
        }
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting hitpoints of selected units to " + _parameter + ".");
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
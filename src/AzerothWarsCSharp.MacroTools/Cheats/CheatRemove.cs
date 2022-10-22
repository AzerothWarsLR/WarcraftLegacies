using AzerothWarsCSharp.MacroTools.Wrappers;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatRemove
  {
    private const string COMMAND = "-remove";

    private static void Remove(unit whichUnit)
    {
      RemoveUnit(whichUnit);
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      player p = GetTriggerPlayer();
      foreach (var unit in new GroupWrapper().EnumSelectedUnits(p).EmptyToList())
      {
        Remove(unit);
      }
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Permanently removing selected units.");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);
    }
  }
}
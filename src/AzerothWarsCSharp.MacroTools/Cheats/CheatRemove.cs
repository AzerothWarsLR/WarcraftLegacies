using static War3Api.Common;

using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatRemove
  {
    private const string COMMAND = "-remove";
    private static string _parameter = null;


    private static void Remove()
    {
      RemoveUnit(GetEnumUnit());
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      player p = GetTriggerPlayer();
      ForGroupBJ(GetUnitsSelectedAll(p), Remove);
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
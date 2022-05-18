using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatOwner
  {
    private const string COMMAND = "-owner ";
    private static string? _parameter;

    private static void SetOwner()
    {
      SetUnitOwner(GetEnumUnit(), Player(S2I(_parameter)), true);
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (S2I(_parameter) >= 0)
      {
        ForGroupBJ(GetUnitsSelectedAll(p), SetOwner);
        DisplayTextToPlayer(p, 0, 0,
          "|cffD27575CHEAT:|r Setting owner of selected units to " + GetPlayerName(Player(S2I(_parameter))) + ".");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}
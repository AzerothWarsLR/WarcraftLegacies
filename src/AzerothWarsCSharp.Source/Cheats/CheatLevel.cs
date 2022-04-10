using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Cheats
{
  public static class CheatLevel
  {
    private const string COMMAND = "-level ";
    private static string? _parameter;


    private static void SetLevel()
    {
      SetHeroLevelBJ(GetEnumUnit(), S2I(_parameter), true);
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      GetPlayerId(p);
      _parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (S2I(_parameter) > 0)
      {
        ForGroupBJ(GetUnitsSelectedAll(p), SetLevel);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting hero level of selected units to " + _parameter + ".");
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
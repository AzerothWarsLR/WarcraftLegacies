using MacroTools.Wrappers;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static class CheatLevel
  {
    private const string Command = "-level ";
    private static string? _parameter;
    
    private static void SetLevel(unit whichUnit)
    {
      SetHeroLevel(whichUnit, S2I(_parameter), true);
    }

    private static void Actions()
    {
      if (!TestMode.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      GetPlayerId(p);
      _parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      if (S2I(_parameter) > 0)
      {
        foreach (var unit in new GroupWrapper().EnumSelectedUnits(p).EmptyToList())
        {
          SetLevel(unit);
        }
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Setting hero level of selected units to " + _parameter + ".");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}